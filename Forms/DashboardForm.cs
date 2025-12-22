using GreenGuard.Data;
using GreenGuard.Models;
using GreenGuard.Services;
using Microsoft.EntityFrameworkCore;

namespace GreenGuard.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly GreenGuardDbContext _context;
        private readonly HealthAnalyzerService _healthAnalyzer;
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

        public DashboardForm()
        {
            _context = new GreenGuardDbContext();
            _healthAnalyzer = new HealthAnalyzerService();

            InitializeComponent();
            EnableDoubleBuffering(panelMain);
        }

        private void EnableDoubleBuffering(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | 
                System.Reflection.BindingFlags.Instance | 
                System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            if (AuthService.CurrentUser != null)
            {
                this.Text = $"GreenGuard - Hoş Geldiniz, {AuthService.CurrentUser.FullName}";
            }

            WirePlantButtons();
            SetupWateringCan();
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

        private void btnPlants_Click(object sender, EventArgs e)
        {
            MessageBox.Show("💧 Sulama kabını sürükleyip bitkilerin üzerine bırakarak sulayabilirsiniz!",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAddPlant_Click(object sender, EventArgs e)
        {
            var form = new PlantEditForm();
            form.ShowDialog();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bakım Takvimi özelliği yakında eklenecek!", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHealthAnalysis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Detaylı Sağlık Analizi özelliği yakında eklenecek!", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void WirePlantButtons()
        {
            var plantButtons = GetPlantButtons();

            for (int i = 0; i < plantButtons.Length; i++)
            {
                int slotNumber = i + 1;
                Button btn = plantButtons[i];
                
                btn.MouseEnter += (s, e) => {
                    // Sürükleme veya sulama sırasında popup açma
                    if (_isDragging || _blockPopups) return;
                    
                    if (_currentPopup != null && !_currentPopup.IsDisposed)
                    {
                        _currentPopup.CancelClose();
                    }
                    OpenPlantSlot(slotNumber, btn);
                };
                
                btn.MouseLeave += (s, e) => {
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

        private void button2_Click(object sender, EventArgs e) { }
    }
}
