using GreenGuard.Data;
using GreenGuard.Helpers;
using GreenGuard.Models;
using GreenGuard.Services;
using Microsoft.EntityFrameworkCore;

namespace GreenGuard.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly GreenGuardDbContext _context;
        private readonly HealthAnalyzerService _healthAnalyzer;
        private readonly ReminderService _reminderService;
        private PlantSlotPopup? _currentPopup;

        // Sürükleme için
        private Point _wateringCanOriginalPos;
        private bool _isDragging = false;
        private Point _dragOffset;

        // Animasyon timer'ı (iptal edilebilir)
        private System.Windows.Forms.Timer? _returnAnimTimer;

        // Popup engelleme (sulama sırasında ve sonrasında)
        private bool _blockPopups = false;
        private System.Windows.Forms.Timer? _blockPopupsTimer;

        // Badge label
        private Label? _badgeLabel;

        // Dönen ipuçları için timer
        private System.Windows.Forms.Timer? _tipsTimer;
        private int _currentTipIndex = 0;
        private List<string> _rotatingTips = new();

        public DashboardForm()
        {
            _context = new GreenGuardDbContext();
            _healthAnalyzer = new HealthAnalyzerService();
            _reminderService = new ReminderService(_context);

            InitializeComponent();
            EnableDoubleBuffering(panelMain);

            // Hatırlatma paneli tıklama olayı
            checkedListBox1.Click += CheckedListBox1_Click;
            checkedListBox1.DoubleClick += CheckedListBox1_DoubleClick;
        }

        private void EnableDoubleBuffering(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            if (AuthService.CurrentUser != null)
            {
                this.Text = $"GreenGuard - Hoş Geldiniz, {AuthService.CurrentUser.FullName}";
            }

            // NOT: SamplePlantSeeder kaldırıldı - yeni kullanıcılara otomatik bitki eklenmeyecek
            // Test için bitki eklemek isterseniz PlantEditForm kullanın

            WirePlantButtons();
            SetupWateringCan();
            SetupCareBadge();
            UpdateCareBadge();

            // Hatırlatmaları yükle
            await LoadRemindersAsync();
            
            // Sağlık skorlarını güncelle
            await UpdateHealthScoresAsync();

            // Dönen ipuçları timer'ı başlat
            SetupTipsTimer();
        }

        private void SetupWateringCan()
        {
            _wateringCanOriginalPos = picWateringCan.Location;

            picWateringCan.MouseDown += WateringCan_MouseDown;
            picWateringCan.MouseMove += WateringCan_MouseMove;
            picWateringCan.MouseUp += WateringCan_MouseUp;
        }

        private void WateringCan_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Geri dönüş animasyonu çalışıyorsa iptal et
                CancelReturnAnimation();

                _isDragging = true;
                _blockPopups = true; // Popup'ları engelle
                _dragOffset = e.Location;
                picWateringCan.Cursor = Cursors.NoMove2D;
                picWateringCan.Capture = true;

                // Mevcut popup'u kapat
                if (_currentPopup != null && !_currentPopup.IsDisposed)
                {
                    _currentPopup.Close();
                }
            }
        }

        private void WateringCan_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                var newX = picWateringCan.Location.X + e.X - _dragOffset.X;
                var newY = picWateringCan.Location.Y + e.Y - _dragOffset.Y;

                // Sınırlar içinde tut
                newX = Math.Max(0, Math.Min(newX, panelMain.Width - picWateringCan.Width));
                newY = Math.Max(0, Math.Min(newY, panelMain.Height - picWateringCan.Height));

                picWateringCan.Location = new Point(newX, newY);
                HighlightPlantUnderCursor();
            }
        }

        private void WateringCan_MouseUp(object? sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                _isDragging = false;
                picWateringCan.Cursor = Cursors.Hand;
                picWateringCan.Capture = false;

                int slotNumber = GetPlantSlotAtPosition();

                if (slotNumber > 0)
                {
                    WaterPlantAsync(slotNumber);
                }

                ClearAllBorders();
                StartReturnAnimation();
            }
        }

        private void CancelReturnAnimation()
        {
            if (_returnAnimTimer != null)
            {
                _returnAnimTimer.Stop();
                _returnAnimTimer.Dispose();
                _returnAnimTimer = null;
            }
        }

        private void StartBlockPopupsTimer()
        {
            // Önceki timer varsa iptal et
            if (_blockPopupsTimer != null)
            {
                _blockPopupsTimer.Stop();
                _blockPopupsTimer.Dispose();
            }

            _blockPopups = true;

            // 3 saniye sonra popup'lara izin ver
            _blockPopupsTimer = new System.Windows.Forms.Timer { Interval = 3000 };
            _blockPopupsTimer.Tick += (s, e) =>
            {
                _blockPopupsTimer?.Stop();
                _blockPopupsTimer?.Dispose();
                _blockPopupsTimer = null;
                _blockPopups = false;
            };
            _blockPopupsTimer.Start();
        }

        private void HighlightPlantUnderCursor()
        {
            var plantButtons = GetPlantButtons();
            var canRect = new Rectangle(picWateringCan.Location, picWateringCan.Size);

            foreach (var btn in plantButtons)
            {
                var btnRect = new Rectangle(btn.Location, btn.Size);
                if (btnRect.IntersectsWith(canRect))
                {
                    btn.FlatAppearance.BorderSize = 3;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(100, 200, 255);
                }
                else
                {
                    btn.FlatAppearance.BorderSize = 0;
                }
            }
        }

        private void ClearAllBorders()
        {
            foreach (var btn in GetPlantButtons())
            {
                btn.FlatAppearance.BorderSize = 0;
            }
        }

        private int GetPlantSlotAtPosition()
        {
            var plantButtons = GetPlantButtons();
            var canCenter = new Point(
                picWateringCan.Location.X + picWateringCan.Width / 2,
                picWateringCan.Location.Y + picWateringCan.Height / 2
            );

            for (int i = 0; i < plantButtons.Length; i++)
            {
                var btnRect = new Rectangle(plantButtons[i].Location, plantButtons[i].Size);
                if (btnRect.Contains(canCenter))
                {
                    return i + 1;
                }
            }
            return 0;
        }

        private async void WaterPlantAsync(int slotNumber)
        {
            if (AuthService.CurrentUser == null) return;

            try
            {
                var plant = await _context.Plants
                    .FirstOrDefaultAsync(p => p.UserId == AuthService.CurrentUser.Id && p.SlotNumber == slotNumber);

                if (plant != null)
                {
                    plant.LastWateredDate = DateTime.Now;

                    var careLog = new CareLog
                    {
                        PlantId = plant.Id,
                        CareType = CareType.Watering,
                        CareDate = DateTime.Now,
                        Notes = "Dashboard'dan sulama 💧"
                    };
                    _context.CareLogs.Add(careLog);
                    await _context.SaveChangesAsync();

                    // Hatırlatmayı tamamlandı olarak işaretle
                    await _reminderService.OnPlantCaredAsync(plant.Id, ReminderType.Watering);

                    // Hatırlatma listesini yenile
                    await LoadRemindersAsync();

                    var btn = GetPlantButtons()[slotNumber - 1];
                    ShowWaterDroplets(btn);

                    // 5 saniye popup engelleme
                    StartBlockPopupsTimer();
                }
                else
                {
                    var btn = GetPlantButtons()[slotNumber - 1];
                    ShowQuickMessage("Bu slotta bitki yok!", Color.FromArgb(255, 200, 200), btn);

                    // Boş slot için de 3 saniye popup engelleme
                    StartBlockPopupsTimer();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Sulama hatası: {ex.Message}");
            }
        }

        private void ShowWaterDroplets(Button targetButton)
        {
            // Damla görseli yolu
            var dropImagePath = System.IO.Path.Combine(Application.StartupPath, "..", "..", "..", "Resources", "PixelPlants", "water_drop.png");
            Image? dropImage = null;

            if (System.IO.File.Exists(dropImagePath))
            {
                dropImage = Image.FromFile(dropImagePath);
            }

            // 4 damla oluştur - dikey düşen tarzda
            var droplets = new PictureBox[4];
            int dropSize = 24; // Uygun boyut

            // Yatay pozisyonlar (biraz sağa sola dağılımlı)
            int[] xOffsets = { 15, 35, 25, 45 };
            // Dikey pozisyonlar (kademeli düşüş efekti)
            int[] yOffsets = { 0, 20, 40, 60 };

            for (int i = 0; i < 4; i++)
            {
                var droplet = new PictureBox
                {
                    Size = new Size(dropSize, dropSize),
                    Image = dropImage,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Transparent,
                    Location = new Point(
                        targetButton.Location.X + xOffsets[i],
                        targetButton.Location.Y + yOffsets[i]
                    )
                };

                droplets[i] = droplet;
                panelMain.Controls.Add(droplet);
                droplet.BringToFront();
            }

            // Yanıp sönme animasyonu
            int blinkCount = 0;
            var blinkTimer = new System.Windows.Forms.Timer { Interval = 200 };
            blinkTimer.Tick += (s, e) =>
            {
                blinkCount++;

                // Sırayla yanıp sön (dalga efekti)
                for (int i = 0; i < droplets.Length; i++)
                {
                    if (droplets[i] != null && !droplets[i].IsDisposed)
                    {
                        // Her damla farklı zamanda yanıp sönsün
                        droplets[i].Visible = ((blinkCount + i) % 2 == 0);
                    }
                }

                if (blinkCount >= 8)
                {
                    blinkTimer.Stop();
                    blinkTimer.Dispose();

                    foreach (var drop in droplets)
                    {
                        if (drop != null && !drop.IsDisposed)
                        {
                            panelMain.Controls.Remove(drop);
                            drop.Dispose();
                        }
                    }

                    ShowQuickMessage("✅ Sulandı!", Color.FromArgb(200, 255, 200), targetButton);
                }
            };
            blinkTimer.Start();
        }

        private void ShowQuickMessage(string message, Color backColor, Button nearButton)
        {
            var lbl = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 100, 50),
                BackColor = backColor,
                AutoSize = true,
                Padding = new Padding(8, 4, 8, 4),
                Location = new Point(nearButton.Location.X, nearButton.Location.Y - 30)
            };

            panelMain.Controls.Add(lbl);
            lbl.BringToFront();

            var removeTimer = new System.Windows.Forms.Timer { Interval = 1500 };
            removeTimer.Tick += (s, e) =>
            {
                removeTimer.Stop();
                removeTimer.Dispose();
                if (!lbl.IsDisposed)
                {
                    panelMain.Controls.Remove(lbl);
                    lbl.Dispose();
                }
            };
            removeTimer.Start();
        }

        private void StartReturnAnimation()
        {
            CancelReturnAnimation(); // Öncekini iptal et

            _returnAnimTimer = new System.Windows.Forms.Timer { Interval = 20 };
            _returnAnimTimer.Tick += (s, e) =>
            {
                if (_isDragging)
                {
                    // Kullanıcı tekrar sürüklemeye başladı, animasyonu iptal et
                    CancelReturnAnimation();
                    return;
                }

                var dx = _wateringCanOriginalPos.X - picWateringCan.Location.X;
                var dy = _wateringCanOriginalPos.Y - picWateringCan.Location.Y;

                if (Math.Abs(dx) < 3 && Math.Abs(dy) < 3)
                {
                    picWateringCan.Location = _wateringCanOriginalPos;
                    CancelReturnAnimation();
                }
                else
                {
                    picWateringCan.Location = new Point(
                        picWateringCan.Location.X + dx / 4,
                        picWateringCan.Location.Y + dy / 4
                    );
                }
            };
            _returnAnimTimer.Start();
        }

        private Button[] GetPlantButtons()
        {
            return new[] { button1, button2, button3, button4, button5, button6, button7,
                          button8, button9, button10, button11, button12, button13, button14 };
        }

        private void DashboardForm_Resize(object sender, EventArgs e) { }
        private void btnHome_Click(object sender, EventArgs e) { }

        private async void btnPlants_Click(object sender, EventArgs e)
        {
            var plantsListForm = new PlantsListForm();
            plantsListForm.ShowDialog(this);
            
            // Form kapandıktan sonra yenile
            await RefreshDashboardAsync();
        }

        private async void btnAddPlant_Click(object sender, EventArgs e)
        {
            var form = new PlantEditForm();
            form.ShowDialog();
            
            // Form kapandıktan sonra yenile
            await RefreshDashboardAsync();
        }

        private async void btnCalendar_Click(object sender, EventArgs e)
        {
            var calendarForm = new CareCalendarForm();
            calendarForm.ShowDialog(this);
            
            // Form kapandıktan sonra yenile
            await RefreshDashboardAsync();
        }

        private async void btnHealthAnalysis_Click(object sender, EventArgs e)
        {
            var healthForm = new HealthAnalysisForm();
            healthForm.ShowDialog(this);
            
            // Form kapandıktan sonra yenile
            await RefreshDashboardAsync();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AuthService.CurrentUser = null;
                this.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            CancelReturnAnimation();
            _context.Dispose();
        }

        private void picBackground_Click(object sender, EventArgs e) { }

        #region Care Badge

        /// <summary>
        /// Bakım badge'ini oluşturur (sağ üst köşe)
        /// </summary>
        private void SetupCareBadge()
        {
            _badgeLabel = new Label
            {
                AutoSize = false,
                Size = new Size(45, 28),
                Location = new Point(this.Width - 120, 15),
                Anchor = AnchorStyles.Top | AnchorStyles.Right, // Resize'da sağ üstte kal
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(220, 80, 80),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                Text = "0",
                Visible = false
            };

            _badgeLabel.Click += (s, e) =>
            {
                var calendarForm = new CareCalendarForm();
                calendarForm.ShowDialog(this);
                UpdateCareBadge(); // Takvim kapandıktan sonra güncelle
            };

            // Rounded corners efekti için
            _badgeLabel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            };

            this.Controls.Add(_badgeLabel);
            _badgeLabel.BringToFront();
        }

        /// <summary>
        /// Bakım badge'ini günceller
        /// </summary>
        private void UpdateCareBadge()
        {
            if (_badgeLabel == null) return;

            var count = SamplePlantSeeder.GetPendingCareCount(_context);

            if (count > 0)
            {
                _badgeLabel.Text = count > 99 ? "99+" : $"🔔{count}";
                _badgeLabel.Visible = true;

                // Renk: kırmızı (acil) veya turuncu (normal)
                _badgeLabel.BackColor = count >= 5
                    ? Color.FromArgb(220, 60, 60)
                    : Color.FromArgb(255, 152, 0);
            }
            else
            {
                _badgeLabel.Visible = false;
            }
        }
        
        /// <summary>
        /// Tüm bitkilerin sağlık skorlarını günceller
        /// </summary>
        private async Task UpdateHealthScoresAsync()
        {
            if (AuthService.CurrentUser == null) return;
            
            try
            {
                var plants = await _context.Plants
                    .Include(p => p.PlantType)
                    .Where(p => p.UserId == AuthService.CurrentUser.Id)
                    .ToListAsync();
                
                foreach (var plant in plants)
                {
                    var newScore = _healthAnalyzer.CalculateHealthScore(plant);
                    if (plant.HealthScore != newScore)
                    {
                        plant.HealthScore = newScore;
                    }
                }
                
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Health score güncelleme hatası: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Dashboard'ı yeniler - hatırlatmalar, badge ve skorları günceller
        /// </summary>
        private async Task RefreshDashboardAsync()
        {
            try
            {
                await LoadRemindersAsync();
                await UpdateHealthScoresAsync();
                UpdateCareBadge();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Dashboard yenileme hatası: {ex.Message}");
            }
        }

        #endregion

        #region Tips Timer (Dönen İpuçları)

        /// <summary>
        /// Dönen ipuçları timer'ını ayarlar
        /// </summary>
        private void SetupTipsTimer()
        {
            // PlantNewsData'dan ipuçlarını yükle
            _rotatingTips = GreenGuard.Helpers.PlantNewsData.AllArticles
                .Select(a => a.ShortTip)
                .Where(t => !string.IsNullOrEmpty(t))
                .ToList();
            
            if (_rotatingTips.Count == 0)
            {
                _rotatingTips.Add("bitkiler dünyasından\nyeni haberler alabilirsin");
            }
            
            _tipsTimer = new System.Windows.Forms.Timer
            {
                Interval = 5000 // 5 saniye
            };
            _tipsTimer.Tick += TipsTimer_Tick;
            _tipsTimer.Start();
        }

        /// <summary>
        /// Her 5 saniyede ipucu değiştirir
        /// </summary>
        private void TipsTimer_Tick(object? sender, EventArgs e)
        {
            if (_rotatingTips.Count == 0) return;
            
            _currentTipIndex = (_currentTipIndex + 1) % _rotatingTips.Count;
            if (label2 != null)
            {
                label2.Text = _rotatingTips[_currentTipIndex];
            }
        }

        #endregion

        private void WirePlantButtons()
        {
            var plantButtons = GetPlantButtons();

            for (int i = 0; i < plantButtons.Length; i++)
            {
                int slotNumber = i + 1;
                Button btn = plantButtons[i];

                btn.MouseEnter += (s, e) =>
                {
                    // Sürükleme veya sulama sırasında popup açma
                    if (_isDragging || _blockPopups) return;

                    if (_currentPopup != null && !_currentPopup.IsDisposed)
                    {
                        _currentPopup.CancelClose();
                    }
                    OpenPlantSlot(slotNumber, btn);
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (_currentPopup != null && !_currentPopup.IsDisposed)
                    {
                        _currentPopup.StartCloseTimer();
                    }
                };
            }

            MakePlantButtonsTransparent();
        }

        private void MakePlantButtonsTransparent()
        {
            foreach (var btn in GetPlantButtons())
            {
                btn.BackColor = Color.Transparent;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 143, 188, 143);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, 143, 188, 143);
                btn.Text = "";
                btn.Cursor = Cursors.Hand;
            }
        }

        private void OpenPlantSlot(int slotNumber, Button button)
        {
            if (_currentPopup != null && !_currentPopup.IsDisposed)
            {
                _currentPopup.Close();
            }

            var popup = new PlantSlotPopup(slotNumber);
            _currentPopup = popup;

            var buttonScreenPos = button.PointToScreen(Point.Empty);
            int popupX = buttonScreenPos.X + button.Width + 10;
            int popupY = buttonScreenPos.Y - 50;

            var screen = Screen.FromControl(this);
            if (popupX + popup.Width > screen.WorkingArea.Right)
                popupX = buttonScreenPos.X - popup.Width - 10;
            if (popupY + popup.Height > screen.WorkingArea.Bottom)
                popupY = screen.WorkingArea.Bottom - popup.Height - 20;
            if (popupY < screen.WorkingArea.Top)
                popupY = screen.WorkingArea.Top + 20;

            popup.Location = new Point(popupX, popupY);
            popup.Show(this);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnRefresh.Text = "⏳ Yenileniyor...";
            
            await RefreshDashboardAsync();
            
            btnRefresh.Text = "🔄 Yenile";
            btnRefresh.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        #region Hatırlatmalar

        /// <summary>
        /// Hatırlatmaları yükler ve checkedListBox1'de gösterir
        /// </summary>
        private async Task LoadRemindersAsync()
        {
            if (AuthService.CurrentUser == null) return;

            checkedListBox1.Items.Clear();

            try
            {
                var reminders = await _reminderService.GetSummaryRemindersAsync(AuthService.CurrentUser.Id, 8);

                foreach (var reminder in reminders)
                {
                    string displayText = reminder.Title;

                    // Öncelik ikonunu başa ekle
                    if (!reminder.IsCompleted)
                    {
                        displayText = $"{reminder.GetPriorityIcon()} {displayText}";
                    }

                    checkedListBox1.Items.Add(displayText, reminder.IsCompleted);
                }

                // Listeye "Tümünü Gör" ekle
                if (reminders.Count > 0)
                {
                    checkedListBox1.Items.Add("─────────────────────");
                    checkedListBox1.Items.Add("📋 Tümünü Gör...");
                }
                else
                {
                    checkedListBox1.Items.Add("🌿 Hatırlatma yok");
                    checkedListBox1.Items.Add("📋 Not eklemek için tıkla");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Hatırlatma yükleme hatası: {ex.Message}");
                checkedListBox1.Items.Add("⚠️ Yüklenemedi");
            }
        }

        /// <summary>
        /// CheckedListBox tıklandığında - checkbox işaretleme
        /// </summary>
        private async void CheckedListBox1_Click(object? sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex < 0) return;

            var selectedText = checkedListBox1.SelectedItem?.ToString() ?? "";

            // Ayırıcı satıra tıklandıysa ignore et  
            if (selectedText.Contains("─────") || selectedText == "🌿 Hatırlatma yok")
            {
                return;
            }

            // "Tümünü Gör" veya "Not ekle" tıklandıysa detay formunu aç
            if (selectedText.Contains("Tümünü Gör") || selectedText.Contains("Not eklemek için"))
            {
                OpenRemindersDetailForm();
            }
        }

        /// <summary>
        /// CheckedListBox çift tıklandığında - detay formu aç
        /// </summary>
        private void CheckedListBox1_DoubleClick(object? sender, EventArgs e)
        {
            OpenRemindersDetailForm();
        }

        /// <summary>
        /// Hatırlatmalar detay formunu açar
        /// </summary>
        private void OpenRemindersDetailForm()
        {
            if (AuthService.CurrentUser == null) return;

            var detailForm = new RemindersDetailForm(AuthService.CurrentUser.Id);
            detailForm.FormClosed += async (s, args) => await LoadRemindersAsync(); // Form kapandığında listeyi yenile
            detailForm.ShowDialog(this);
        }

        #endregion

        private void button16_Click(object sender, EventArgs e)
        {
            var bigiForm = new BigiAssistantForm();
            bigiForm.ShowDialog(this);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            var newsForm = new PlantNewsForm();
            newsForm.ShowDialog(this);
        }
    }
}

