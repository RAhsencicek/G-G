using System.Drawing.Drawing2D;
using GreenGuard.Data;
using GreenGuard.Models;
using GreenGuard.Services;
using Microsoft.EntityFrameworkCore;

namespace GreenGuard.Forms
{
    public partial class HealthAnalysisForm : Form
    {
        private GreenGuardDbContext? _context;
        private HealthAnalyzerService? _healthAnalyzer;
        private List<Plant> _allPlants = new();
        private Plant? _selectedPlant;
        private int _currentHealthScore = 0;

        public HealthAnalysisForm()
        {
            InitializeComponent();

            // Designer modunda servisleri oluşturma
            if (!DesignMode)
            {
                _context = new GreenGuardDbContext();
                _healthAnalyzer = new HealthAnalyzerService();
            }
        }

        private async void HealthAnalysisForm_Load(object sender, EventArgs e)
        {
            await LoadPlantsAsync();

            if (_allPlants.Count > 0)
            {
                cmbPlantSelect.SelectedIndex = 0;
            }
            else
            {
                ShowNoPlants();
            }
        }

        /// <summary>
        /// Tüm bitkileri yükler
        /// </summary>
        private async Task LoadPlantsAsync()
        {
            if (AuthService.CurrentUser == null) return;

            _allPlants = await _context.Plants
                .Include(p => p.PlantType)
                .Where(p => p.UserId == AuthService.CurrentUser.Id)
                .OrderBy(p => p.Name)
                .ToListAsync();

            // Dropdown'u doldur
            cmbPlantSelect.Items.Clear();
            foreach (var plant in _allPlants)
            {
                var displayName = string.IsNullOrEmpty(plant.Nickname)
                    ? plant.Name
                    : $"{plant.Nickname} ({plant.Name})";
                cmbPlantSelect.Items.Add(displayName);
            }

            // Tüm bitkiler görünümünü güncelle
            UpdateAllPlantsView();
        }

        /// <summary>
        /// Bitki yoksa göster
        /// </summary>
        private void ShowNoPlants()
        {
            lblPlantName.Text = "Henüz bitki eklenmemiş";
            lblHealthPercent.Text = "--";
            lblHealthEmoji.Text = "🌱";
            lblHealthStatus.Text = "Bitki ekleyin";
            lblWaterInfo.Text = "💧 --";
            lblFertilizeInfo.Text = "🌱 --";
            listRecommendations.Items.Clear();
            listRecommendations.Items.Add("Bitkilerim sayfasından bitki ekleyebilirsiniz.");
        }

        #region Single Plant View

        private void cmbPlantSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlantSelect.SelectedIndex < 0 || cmbPlantSelect.SelectedIndex >= _allPlants.Count)
                return;

            _selectedPlant = _allPlants[cmbPlantSelect.SelectedIndex];
            UpdateSinglePlantView();
        }

        /// <summary>
        /// Tek bitki görünümünü günceller
        /// </summary>
        private void UpdateSinglePlantView()
        {
            if (_selectedPlant == null) return;

            // Sağlık skoru hesapla
            _currentHealthScore = _healthAnalyzer.CalculateHealthScore(_selectedPlant);
            var status = _healthAnalyzer.GetHealthStatus(_currentHealthScore);
            var color = _healthAnalyzer.GetHealthColor(_currentHealthScore);

            // Bitki adı
            lblPlantName.Text = $"🌿 {_selectedPlant.Nickname ?? _selectedPlant.Name}";

            // Gauge güncelle
            lblHealthPercent.Text = $"{_currentHealthScore}%";
            lblHealthPercent.ForeColor = color;
            lblHealthStatus.Text = status;
            lblHealthStatus.ForeColor = color;
            lblHealthEmoji.Text = GetHealthEmoji(_currentHealthScore);

            // Gauge'ı yeniden çiz
            panelGauge.Invalidate();

            // Sulama bilgisi
            if (_selectedPlant.LastWateredDate.HasValue)
            {
                var days = (DateTime.Now - _selectedPlant.LastWateredDate.Value).Days;
                var optimal = _selectedPlant.PlantType?.OptimalWateringDays ?? 7;
                lblWaterInfo.Text = $"💧 Sulama: {days} gün önce (Optimal: {optimal} gün)";
                lblWaterInfo.ForeColor = days > optimal
                    ? Color.FromArgb(255, 150, 100)
                    : Color.FromArgb(180, 220, 180);
            }
            else
            {
                lblWaterInfo.Text = "💧 Henüz sulanmadı";
                lblWaterInfo.ForeColor = Color.FromArgb(255, 150, 100);
            }

            // Gübreleme bilgisi
            if (_selectedPlant.LastFertilizedDate.HasValue)
            {
                var days = (DateTime.Now - _selectedPlant.LastFertilizedDate.Value).Days;
                var optimal = _selectedPlant.PlantType?.OptimalFertilizingDays ?? 30;
                lblFertilizeInfo.Text = $"🌱 Gübreleme: {days} gün önce (Optimal: {optimal} gün)";
                lblFertilizeInfo.ForeColor = days > optimal
                    ? Color.FromArgb(255, 150, 100)
                    : Color.FromArgb(180, 220, 180);
            }
            else
            {
                lblFertilizeInfo.Text = "🌱 Henüz gübrelenmedi";
                lblFertilizeInfo.ForeColor = Color.FromArgb(180, 220, 180);
            }

            // Öneriler
            listRecommendations.Items.Clear();
            var recommendations = _healthAnalyzer.GetRecommendations(_selectedPlant);
            foreach (var rec in recommendations)
            {
                listRecommendations.Items.Add(rec);
            }
        }

        /// <summary>
        /// Skor'a göre emoji döndürür
        /// </summary>
        private string GetHealthEmoji(int score)
        {
            if (score >= 80) return "😊";
            if (score >= 60) return "😐";
            if (score >= 40) return "😟";
            return "😱";
        }

        /// <summary>
        /// Dairesel gauge çizer
        /// </summary>
        private void panelGauge_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int size = Math.Min(panelGauge.Width, panelGauge.Height) - 20;
            int x = (panelGauge.Width - size) / 2;
            int y = 5;

            // Arka plan daire
            using (var bgPen = new Pen(Color.FromArgb(40, 70, 50), 12))
            {
                g.DrawArc(bgPen, x, y, size, size, 135, 270);
            }

            // Skor dairesi
            if (_currentHealthScore > 0)
            {
                var color = _healthAnalyzer.GetHealthColor(_currentHealthScore);
                using (var scorePen = new Pen(color, 12))
                {
                    scorePen.StartCap = LineCap.Round;
                    scorePen.EndCap = LineCap.Round;

                    float sweepAngle = 270f * _currentHealthScore / 100f;
                    g.DrawArc(scorePen, x, y, size, size, 135, sweepAngle);
                }
            }
        }

        #endregion

        #region All Plants View

        /// <summary>
        /// Tüm bitkiler görünümünü günceller
        /// </summary>
        private void UpdateAllPlantsView()
        {
            int excellent = 0, good = 0, warning = 0, critical = 0;
            var criticalPlants = new List<Plant>();

            foreach (var plant in _allPlants)
            {
                var score = _healthAnalyzer.CalculateHealthScore(plant);

                if (score >= 80) excellent++;
                else if (score >= 60) good++;
                else if (score >= 40)
                {
                    warning++;
                    criticalPlants.Add(plant);
                }
                else
                {
                    critical++;
                    criticalPlants.Add(plant);
                }
            }

            // Özet sayıları güncelle
            lblExcellentCount.Text = $"😊 Mükemmel: {excellent}";
            lblGoodCount.Text = $"😐 İyi: {good}";
            lblWarningCount.Text = $"😟 Dikkat: {warning}";
            lblCriticalCount.Text = $"😱 Kritik: {critical}";

            // Sağlıklı sayısı
            lblHealthyCount.Text = $"✅ Sağlıklı Bitkiler: {excellent + good} adet";

            // Dikkat gerektiren bitkiler
            flowCriticalPlants.Controls.Clear();

            if (criticalPlants.Count == 0)
            {
                lblCriticalTitle.Text = "✅ Tüm bitkileriniz sağlıklı!";
                lblCriticalTitle.ForeColor = Color.FromArgb(100, 200, 100);
            }
            else
            {
                lblCriticalTitle.Text = "⚠️ Dikkat Gerektiren Bitkiler:";
                lblCriticalTitle.ForeColor = Color.FromArgb(255, 193, 7);

                foreach (var plant in criticalPlants.OrderBy(p => _healthAnalyzer.CalculateHealthScore(p)))
                {
                    var card = CreateCriticalPlantCard(plant);
                    flowCriticalPlants.Controls.Add(card);
                }
            }
        }

        /// <summary>
        /// Kritik bitki kartı oluşturur
        /// </summary>
        private Panel CreateCriticalPlantCard(Plant plant)
        {
            var score = _healthAnalyzer.CalculateHealthScore(plant);
            var color = _healthAnalyzer.GetHealthColor(score);
            var emoji = GetHealthEmoji(score);

            var card = new Panel
            {
                Size = new Size(120, 100),
                BackColor = Color.FromArgb(50, 80, 60),
                Margin = new Padding(8),
                Cursor = Cursors.Hand,
                Tag = plant
            };

            // Yüzde
            var lblPercent = new Label
            {
                Text = $"{score}%",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(0, 10),
                Size = new Size(120, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblPercent);

            // Emoji
            var lblEmoji = new Label
            {
                Text = emoji,
                Font = new Font("Segoe UI Emoji", 14F),
                Location = new Point(0, 38),
                Size = new Size(120, 25),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblEmoji);

            // İsim
            var lblName = new Label
            {
                Text = plant.Nickname ?? plant.Name,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.White,
                Location = new Point(5, 70),
                Size = new Size(110, 25),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblName);

            // Tıklama - o bitkiyi seç ve tek bitki görünümüne geç
            card.Click += (s, e) =>
            {
                var index = _allPlants.IndexOf(plant);
                if (index >= 0)
                {
                    cmbPlantSelect.SelectedIndex = index;
                    ShowSinglePlantView();
                }
            };

            foreach (Control ctrl in card.Controls)
            {
                ctrl.Click += (s, e) =>
                {
                    var index = _allPlants.IndexOf(plant);
                    if (index >= 0)
                    {
                        cmbPlantSelect.SelectedIndex = index;
                        ShowSinglePlantView();
                    }
                };
            }

            // Hover efekti
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(70, 110, 85);
            card.MouseLeave += (s, e) => card.BackColor = Color.FromArgb(50, 80, 60);

            return card;
        }

        #endregion

        #region Tab Toggle

        private void btnSinglePlant_Click(object sender, EventArgs e)
        {
            ShowSinglePlantView();
        }

        private void btnAllPlants_Click(object sender, EventArgs e)
        {
            ShowAllPlantsView();
        }

        private void ShowSinglePlantView()
        {
            panelSinglePlant.Visible = true;
            panelAllPlants.Visible = false;

            btnSinglePlant.BackColor = Color.FromArgb(80, 140, 100);
            btnSinglePlant.ForeColor = Color.White;
            btnSinglePlant.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            btnAllPlants.BackColor = Color.FromArgb(55, 95, 75);
            btnAllPlants.ForeColor = Color.FromArgb(180, 220, 180);
            btnAllPlants.Font = new Font("Segoe UI", 10F);
        }

        private void ShowAllPlantsView()
        {
            panelSinglePlant.Visible = false;
            panelAllPlants.Visible = true;

            btnAllPlants.BackColor = Color.FromArgb(80, 140, 100);
            btnAllPlants.ForeColor = Color.White;
            btnAllPlants.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            btnSinglePlant.BackColor = Color.FromArgb(55, 95, 75);
            btnSinglePlant.ForeColor = Color.FromArgb(180, 220, 180);
            btnSinglePlant.Font = new Font("Segoe UI", 10F);

            UpdateAllPlantsView();
        }

        #endregion

        #region Quick Actions

        private async void btnWater_Click(object sender, EventArgs e)
        {
            if (_selectedPlant == null) return;

            _selectedPlant.LastWateredDate = DateTime.Now;

            var careLog = new CareLog
            {
                PlantId = _selectedPlant.Id,
                CareType = CareType.Watering,
                CareDate = DateTime.Now,
                Notes = "Sağlık analizi formundan sulama"
            };
            _context.CareLogs.Add(careLog);

            await _context.SaveChangesAsync();

            MessageBox.Show("Sulama kaydedildi! 💧", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateSinglePlantView();
            UpdateAllPlantsView();
        }

        private async void btnFertilize_Click(object sender, EventArgs e)
        {
            if (_selectedPlant == null) return;

            _selectedPlant.LastFertilizedDate = DateTime.Now;

            var careLog = new CareLog
            {
                PlantId = _selectedPlant.Id,
                CareType = CareType.Fertilizing,
                CareDate = DateTime.Now,
                Notes = "Sağlık analizi formundan gübreleme"
            };
            _context.CareLogs.Add(careLog);

            await _context.SaveChangesAsync();

            MessageBox.Show("Gübreleme kaydedildi! 🌱", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateSinglePlantView();
            UpdateAllPlantsView();
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }

        private void lblFertilizeInfo_Click(object sender, EventArgs e)
        {

        }

        private void lblWaterInfo_Click(object sender, EventArgs e)
        {

        }

        private void lblHealthStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
