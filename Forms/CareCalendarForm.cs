using System.Drawing.Drawing2D;
using GreenGuard.Data;
using GreenGuard.Models;
using GreenGuard.Services;
using Microsoft.EntityFrameworkCore;

namespace GreenGuard.Forms
{
    public partial class CareCalendarForm : Form
    {
        private readonly GreenGuardDbContext _context;
        private readonly ReminderService _reminderService;
        private List<Plant> _allPlants = new();
        private DateTime _currentMonth;
        private DateTime? _selectedDate;

        // Filtreler
        private bool _showWatering = true;
        private bool _showFertilizing = true;
        private bool _showPruning = true;

        // Takvim için hesaplanan bakım günleri
        private Dictionary<DateTime, List<CareItem>> _careSchedule = new();

        public CareCalendarForm()
        {
            _context = new GreenGuardDbContext();
            _reminderService = new ReminderService(_context);
            _currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            InitializeComponent();
        }

        private async void CareCalendarForm_Load(object sender, EventArgs e)
        {
            await LoadPlantsAsync();
            CalculateCareSchedule();
            UpdateDisplay();
        }

        /// <summary>
        /// Bitkileri yükler
        /// </summary>
        private async Task LoadPlantsAsync()
        {
            if (AuthService.CurrentUser == null) return;

            _allPlants = await _context.Plants
                .Include(p => p.PlantType)
                .Where(p => p.UserId == AuthService.CurrentUser.Id)
                .ToListAsync();
        }

        /// <summary>
        /// Bakım takvimini hesaplar (gelecek 60 gün)
        /// </summary>
        private void CalculateCareSchedule()
        {
            _careSchedule.Clear();
            var today = DateTime.Today;

            foreach (var plant in _allPlants)
            {
                if (plant.PlantType == null) continue;

                // Sulama tarihleri
                if (_showWatering)
                {
                    var nextWater = CalculateNextCareDate(plant.LastWateredDate, plant.PlantType.OptimalWateringDays);
                    AddCareItem(nextWater, plant, CareType.Watering);
                }

                // Gübreleme tarihleri
                if (_showFertilizing)
                {
                    var nextFertilize = CalculateNextCareDate(plant.LastFertilizedDate, plant.PlantType.OptimalFertilizingDays);
                    AddCareItem(nextFertilize, plant, CareType.Fertilizing);
                }

                // Budama tarihleri
                if (_showPruning && plant.PlantType.OptimalPruningDays > 0)
                {
                    var nextPrune = CalculateNextCareDate(plant.LastPrunedDate, plant.PlantType.OptimalPruningDays);
                    AddCareItem(nextPrune, plant, CareType.Pruning);
                }
            }
        }

        private DateTime CalculateNextCareDate(DateTime? lastCareDate, int optimalDays)
        {
            if (lastCareDate == null)
                return DateTime.Today; // Hiç yapılmadıysa bugün

            return lastCareDate.Value.AddDays(optimalDays);
        }

        private void AddCareItem(DateTime date, Plant plant, CareType careType)
        {
            var dateOnly = date.Date;

            if (!_careSchedule.ContainsKey(dateOnly))
                _careSchedule[dateOnly] = new List<CareItem>();

            _careSchedule[dateOnly].Add(new CareItem
            {
                Plant = plant,
                CareType = careType,
                DueDate = dateOnly
            });
        }

        /// <summary>
        /// Görünümü günceller
        /// </summary>
        private void UpdateDisplay()
        {
            // Ay label'ı
            var turkishMonths = new[] { "", "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
                                        "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };
            lblMonth.Text = $"{turkishMonths[_currentMonth.Month]} {_currentMonth.Year}";

            // Takvimi yeniden çiz
            panelDays.Invalidate();

            // Timeline güncelle
            UpdateTimeline();

            // Buton renklerini güncelle
            UpdateFilterButtons();
        }

        private void UpdateFilterButtons()
        {
            btnWatering.BackColor = _showWatering
                ? Color.FromArgb(33, 150, 243)
                : Color.FromArgb(55, 95, 75);

            btnFertilizing.BackColor = _showFertilizing
                ? Color.FromArgb(139, 195, 74)
                : Color.FromArgb(55, 95, 75);

            btnPruning.BackColor = _showPruning
                ? Color.FromArgb(255, 152, 0)
                : Color.FromArgb(55, 95, 75);
        }

        #region Calendar Drawing

        private void panelDays_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int cellWidth = panelDays.Width / 7;
            int cellHeight = 25;

            // Haftanın günleri başlığı
            string[] days = { "Pzt", "Sal", "Çar", "Per", "Cum", "Cmt", "Paz" };
            using (var headerFont = new Font("Segoe UI", 9F, FontStyle.Bold))
            using (var headerBrush = new SolidBrush(Color.FromArgb(180, 220, 180)))
            {
                for (int i = 0; i < 7; i++)
                {
                    var rect = new Rectangle(i * cellWidth, 0, cellWidth, cellHeight);
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(days[i], headerFont, headerBrush, rect, sf);
                }
            }

            // Ayın günleri
            var firstDay = _currentMonth;
            int firstDayOfWeek = ((int)firstDay.DayOfWeek + 6) % 7; // Pazartesi = 0
            int daysInMonth = DateTime.DaysInMonth(_currentMonth.Year, _currentMonth.Month);

            using (var dayFont = new Font("Segoe UI", 10F))
            using (var todayBrush = new SolidBrush(Color.FromArgb(80, 140, 100)))
            using (var selectedBrush = new SolidBrush(Color.FromArgb(100, 180, 120)))
            {
                for (int day = 1; day <= daysInMonth; day++)
                {
                    var date = new DateTime(_currentMonth.Year, _currentMonth.Month, day);
                    int col = (firstDayOfWeek + day - 1) % 7;
                    int row = (firstDayOfWeek + day - 1) / 7 + 1;

                    var rect = new Rectangle(col * cellWidth, row * cellHeight, cellWidth, cellHeight);

                    // Bugün vurgula
                    if (date.Date == DateTime.Today)
                    {
                        g.FillRectangle(todayBrush, rect);
                    }

                    // Seçili gün vurgula
                    if (_selectedDate.HasValue && date.Date == _selectedDate.Value.Date)
                    {
                        using (var pen = new Pen(Color.FromArgb(150, 255, 150), 2))
                        {
                            g.DrawRectangle(pen, rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4);
                        }
                    }

                    // Gün numarası
                    var textColor = date.Date == DateTime.Today ? Color.White : Color.FromArgb(200, 230, 200);
                    using (var textBrush = new SolidBrush(textColor))
                    {
                        var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        g.DrawString(day.ToString(), dayFont, textBrush, rect, sf);
                    }

                    // Bakım göstergeleri
                    if (_careSchedule.ContainsKey(date.Date))
                    {
                        var items = _careSchedule[date.Date];
                        int dotX = rect.X + rect.Width / 2 - 10;
                        int dotY = rect.Y + rect.Height - 8;
                        int dotSize = 6;

                        bool hasWater = items.Any(i => i.CareType == CareType.Watering);
                        bool hasFertilize = items.Any(i => i.CareType == CareType.Fertilizing);
                        bool hasPrune = items.Any(i => i.CareType == CareType.Pruning);

                        int offset = 0;
                        if (hasWater)
                        {
                            using (var brush = new SolidBrush(Color.FromArgb(33, 150, 243)))
                                g.FillEllipse(brush, dotX + offset, dotY, dotSize, dotSize);
                            offset += 8;
                        }
                        if (hasFertilize)
                        {
                            using (var brush = new SolidBrush(Color.FromArgb(139, 195, 74)))
                                g.FillEllipse(brush, dotX + offset, dotY, dotSize, dotSize);
                            offset += 8;
                        }
                        if (hasPrune)
                        {
                            using (var brush = new SolidBrush(Color.FromArgb(255, 152, 0)))
                                g.FillEllipse(brush, dotX + offset, dotY, dotSize, dotSize);
                        }
                    }
                }
            }
        }

        private void panelDays_MouseClick(object sender, MouseEventArgs e)
        {
            int cellWidth = panelDays.Width / 7;
            int cellHeight = 25;

            int col = e.X / cellWidth;
            int row = (e.Y / cellHeight) - 1;

            if (row < 0) return;

            var firstDay = _currentMonth;
            int firstDayOfWeek = ((int)firstDay.DayOfWeek + 6) % 7;

            int dayIndex = row * 7 + col - firstDayOfWeek + 1;
            int daysInMonth = DateTime.DaysInMonth(_currentMonth.Year, _currentMonth.Month);

            if (dayIndex >= 1 && dayIndex <= daysInMonth)
            {
                _selectedDate = new DateTime(_currentMonth.Year, _currentMonth.Month, dayIndex);
                UpdateDisplay();
            }
        }

        #endregion

        #region Timeline

        private void UpdateTimeline()
        {
            flowTimeline.Controls.Clear();

            var today = DateTime.Today;
            var upcomingDays = _careSchedule
                .Where(kv => kv.Key >= today)
                .OrderBy(kv => kv.Key)
                .Take(14) // Sonraki 14 gün
                .ToList();

            // Seçili gün varsa önce onu göster
            if (_selectedDate.HasValue && _careSchedule.ContainsKey(_selectedDate.Value.Date))
            {
                var selected = _selectedDate.Value.Date;
                lblTimelineTitle.Text = $"📋 {GetDateTitle(selected)}";

                foreach (var item in _careSchedule[selected])
                {
                    var card = CreateTimelineCard(item, selected);
                    flowTimeline.Controls.Add(card);
                }
                return;
            }

            // Varsayılan: yaklaşan bakımlar
            lblTimelineTitle.Text = "📋 Yaklaşan Bakımlar";

            if (upcomingDays.Count == 0)
            {
                var emptyLabel = new Label
                {
                    Text = "✅ Yaklaşan bakım bulunmuyor!",
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.FromArgb(150, 200, 150),
                    AutoSize = true,
                    Margin = new Padding(10)
                };
                flowTimeline.Controls.Add(emptyLabel);
                return;
            }

            foreach (var dayGroup in upcomingDays)
            {
                // Gün başlığı
                var dateLabel = new Label
                {
                    Text = GetDateTitle(dayGroup.Key),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = GetDateColor(dayGroup.Key),
                    AutoSize = true,
                    Margin = new Padding(5, 10, 5, 5),
                    Width = flowTimeline.Width - 30
                };
                flowTimeline.Controls.Add(dateLabel);

                foreach (var item in dayGroup.Value)
                {
                    var card = CreateTimelineCard(item, dayGroup.Key);
                    flowTimeline.Controls.Add(card);
                }
            }
        }

        private string GetDateTitle(DateTime date)
        {
            var today = DateTime.Today;
            if (date.Date == today) return "🔴 BUGÜN";
            if (date.Date == today.AddDays(1)) return "🟡 YARIN";
            if (date.Date < today) return $"⚠️ GECİKMİŞ ({(today - date.Date).Days} gün)";
            return $"🟢 {date:d MMMM}";
        }

        private Color GetDateColor(DateTime date)
        {
            var today = DateTime.Today;
            if (date.Date < today) return Color.FromArgb(255, 120, 120); // Açık kırmızı
            if (date.Date == today) return Color.FromArgb(255, 200, 100); // Açık turuncu
            if (date.Date == today.AddDays(1)) return Color.FromArgb(255, 230, 100); // Açık sarı
            return Color.FromArgb(150, 255, 150); // Açık yeşil
        }

        private Panel CreateTimelineCard(CareItem item, DateTime date)
        {
            var isOverdue = date.Date < DateTime.Today;
            var icon = item.CareType switch
            {
                CareType.Watering => "💧",
                CareType.Fertilizing => "🌱",
                CareType.Pruning => "✂️",
                _ => "🌿"
            };
            var careColor = item.CareType switch
            {
                CareType.Watering => Color.FromArgb(100, 200, 255),    // Açık mavi
                CareType.Fertilizing => Color.FromArgb(180, 255, 150), // Açık yeşil
                CareType.Pruning => Color.FromArgb(255, 220, 120),     // Açık turuncu
                _ => Color.LightGray
            };
            var cardBgColor = isOverdue ? Color.FromArgb(90, 60, 60) : Color.FromArgb(50, 85, 65);
            var cardHoverColor = isOverdue ? Color.FromArgb(110, 80, 80) : Color.FromArgb(70, 110, 85);

            // Bitki adı - Boş string kontrolü de yap!
            string plantName;
            if (!string.IsNullOrWhiteSpace(item.Plant.Nickname))
                plantName = item.Plant.Nickname;
            else if (!string.IsNullOrWhiteSpace(item.Plant.Name))
                plantName = item.Plant.Name;
            else if (item.Plant.PlantType != null && !string.IsNullOrWhiteSpace(item.Plant.PlantType.Name))
                plantName = item.Plant.PlantType.Name;
            else
                plantName = $"Bitki #{item.Plant.Id}";
            
            // Debug log
            System.Diagnostics.Debug.WriteLine($"[Timeline Card] PlantId={item.Plant.Id}, Name='{item.Plant.Name}', Nickname='{item.Plant.Nickname}', Resolved='{plantName}'");

            // Dinamik kart genişliği
            int cardWidth = Math.Max(flowTimeline.Width - 20, 400);
            
            var card = new Panel
            {
                Size = new Size(cardWidth, 40),
                BackColor = cardBgColor,
                Margin = new Padding(5, 2, 5, 2),
                Cursor = Cursors.Hand,
                Tag = item
            };

            // Sol tarafta renkli şerit
            var colorStrip = new Panel
            {
                Size = new Size(4, 40),
                BackColor = careColor,
                Location = new Point(0, 0)
            };
            card.Controls.Add(colorStrip);

            // İKON + BİTKİ ADI - TEK LABEL
            var lblMain = new Label
            {
                Text = $"{icon}  {plantName}",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 255, 200),  // Krem sarı
                BackColor = cardBgColor,
                Location = new Point(10, 2),
                Size = new Size(cardWidth - 120, 22),  // Dinamik genişlik
                TextAlign = ContentAlignment.MiddleLeft
            };
            card.Controls.Add(lblMain);

            // Alt satır - Bakım türü açıklaması
            var lblCareType = new Label
            {
                Text = GetCareTypeName(item.CareType),
                Font = new Font("Segoe UI", 9F),
                ForeColor = careColor,
                BackColor = cardBgColor,
                Location = new Point(35, 22),
                Size = new Size(200, 16),
                TextAlign = ContentAlignment.MiddleLeft
            };
            card.Controls.Add(lblCareType);

            // Sağda durum
            var statusText = isOverdue ? "⚠️ Gecikti!" : "✓ Tıkla";
            var lblStatus = new Label
            {
                Text = statusText,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = isOverdue ? Color.FromArgb(255, 150, 150) : Color.FromArgb(150, 255, 150),
                BackColor = cardBgColor,
                Location = new Point(cardWidth - 90, 10),  // Dinamik pozisyon
                Size = new Size(80, 20),
                TextAlign = ContentAlignment.MiddleRight
            };
            card.Controls.Add(lblStatus);

            // Tıklama eventleri
            Action clickHandler = async () => await MarkAsCompletedAsync(item);
            card.Click += (s, e) => clickHandler();
            lblMain.Click += (s, e) => clickHandler();
            lblCareType.Click += (s, e) => clickHandler();
            lblStatus.Click += (s, e) => clickHandler();
            colorStrip.Click += (s, e) => clickHandler();

            // Hover efekti
            void ApplyHover(Control ctrl)
            {
                ctrl.MouseEnter += (s, e) =>
                {
                    card.BackColor = cardHoverColor;
                    lblMain.BackColor = cardHoverColor;
                    lblCareType.BackColor = cardHoverColor;
                    lblStatus.BackColor = cardHoverColor;
                };
                ctrl.MouseLeave += (s, e) =>
                {
                    card.BackColor = cardBgColor;
                    lblMain.BackColor = cardBgColor;
                    lblCareType.BackColor = cardBgColor;
                    lblStatus.BackColor = cardBgColor;
                };
            }
            ApplyHover(card);
            ApplyHover(lblMain);
            ApplyHover(lblCareType);
            ApplyHover(lblStatus);
            ApplyHover(colorStrip);

            return card;
        }

        private string GetCareTypeName(CareType type)
        {
            return type switch
            {
                CareType.Watering => "Sulama",
                CareType.Fertilizing => "Gübreleme",
                CareType.Pruning => "Budama",
                _ => "Bakım"
            };
        }

        private async Task MarkAsCompletedAsync(CareItem item)
        {
            var result = MessageBox.Show(
                $"{item.Plant.Name} için {GetCareTypeName(item.CareType)} yapıldı olarak işaretlensin mi?",
                "Bakım Tamamla",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            // Bakım tarihini güncelle
            switch (item.CareType)
            {
                case CareType.Watering:
                    item.Plant.LastWateredDate = DateTime.Now;
                    break;
                case CareType.Fertilizing:
                    item.Plant.LastFertilizedDate = DateTime.Now;
                    break;
                case CareType.Pruning:
                    item.Plant.LastPrunedDate = DateTime.Now;
                    break;
            }

            // CareLog ekle
            var careLog = new CareLog
            {
                PlantId = item.Plant.Id,
                CareType = item.CareType,
                CareDate = DateTime.Now,
                Notes = "Bakım takviminden tamamlandı"
            };
            _context.CareLogs.Add(careLog);

            await _context.SaveChangesAsync();

            // Hatırlatmayı tamamlandı olarak işaretle
            var reminderType = item.CareType switch
            {
                CareType.Watering => ReminderType.Watering,
                CareType.Fertilizing => ReminderType.Fertilizing,
                CareType.Pruning => ReminderType.Pruning,
                _ => ReminderType.UserNote
            };
            await _reminderService.OnPlantCaredAsync(item.Plant.Id, reminderType);

            MessageBox.Show($"{GetCareTypeName(item.CareType)} kaydedildi! ✅", "Başarılı",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Yeniden hesapla ve göster
            CalculateCareSchedule();
            UpdateDisplay();
        }

        #endregion

        #region Filter Buttons

        private void btnWatering_Click(object sender, EventArgs e)
        {
            _showWatering = !_showWatering;
            CalculateCareSchedule();
            UpdateDisplay();
        }

        private void btnFertilizing_Click(object sender, EventArgs e)
        {
            _showFertilizing = !_showFertilizing;
            CalculateCareSchedule();
            UpdateDisplay();
        }

        private void btnPruning_Click(object sender, EventArgs e)
        {
            _showPruning = !_showPruning;
            CalculateCareSchedule();
            UpdateDisplay();
        }

        #endregion

        #region Navigation

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            _currentMonth = _currentMonth.AddMonths(-1);
            _selectedDate = null;
            UpdateDisplay();
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            _currentMonth = _currentMonth.AddMonths(1);
            _selectedDate = null;
            UpdateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }

        /// <summary>
        /// Takvim bakım öğesi
        /// </summary>
        private class CareItem
        {
            public Plant Plant { get; set; } = null!;
            public CareType CareType { get; set; }
            public DateTime DueDate { get; set; }
        }

        private void flowTimeline_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTimelineTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
