using GreenGuard.Data;
using GreenGuard.Models;
using GreenGuard.Services;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Runtime.InteropServices;

namespace GreenGuard.Forms
{
    public partial class PlantSlotPopup : Form
    {
        private readonly int _slotNumber;
        private readonly GreenGuardDbContext _context;
        private readonly HealthAnalyzerService _healthAnalyzer;
        private Plant? _plant;
        public bool PlantChanged { get; private set; } = false;

        // Rounded corners için Windows API
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        // Fade-in için timer
        private System.Windows.Forms.Timer? _fadeTimer;
        private double _opacity = 0;

        // Auto-close için timer
        private System.Windows.Forms.Timer? _closeTimer;
        public bool IsMouseOver { get; private set; } = false;

        public PlantSlotPopup(int slotNumber)
        {
            _slotNumber = slotNumber;
            _context = new GreenGuardDbContext();
            _healthAnalyzer = new HealthAnalyzerService();

            InitializeComponent();
            
            // Rounded corners uygula
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            
            // Mouse event'leri
            this.MouseEnter += PlantSlotPopup_MouseEnter;
            this.MouseLeave += PlantSlotPopup_MouseLeave;
            
            // Tüm child kontrollere de mouse event ekle
            foreach (Control ctrl in this.panelMain.Controls)
            {
                ctrl.MouseEnter += PlantSlotPopup_MouseEnter;
                ctrl.MouseLeave += PlantSlotPopup_MouseLeave;
            }
            panelMain.MouseEnter += PlantSlotPopup_MouseEnter;
            panelMain.MouseLeave += PlantSlotPopup_MouseLeave;
            
            // Fade-in başlat
            this.Opacity = 0;
            StartFadeIn();
            
            LoadPlantData();
        }

        private void PlantSlotPopup_MouseEnter(object? sender, EventArgs e)
        {
            IsMouseOver = true;
            _closeTimer?.Stop();
        }

        private void PlantSlotPopup_MouseLeave(object? sender, EventArgs e)
        {
            // Fare hala popup içinde mi kontrol et
            Point cursorPos = this.PointToClient(Cursor.Position);
            if (!this.ClientRectangle.Contains(cursorPos))
            {
                IsMouseOver = false;
                StartCloseTimer();
            }
        }

        public void StartCloseTimer()
        {
            if (_closeTimer == null)
            {
                _closeTimer = new System.Windows.Forms.Timer();
                _closeTimer.Interval = 150; // 150ms gecikme
                _closeTimer.Tick += CloseTimer_Tick;
            }
            _closeTimer.Start();
        }

        public void CancelClose()
        {
            _closeTimer?.Stop();
            IsMouseOver = true;
        }

        private void CloseTimer_Tick(object? sender, EventArgs e)
        {
            _closeTimer?.Stop();
            if (!IsMouseOver)
            {
                this.Close();
            }
        }

        private void StartFadeIn()
        {
            _fadeTimer = new System.Windows.Forms.Timer();
            _fadeTimer.Interval = 15;
            _fadeTimer.Tick += FadeTimer_Tick;
            _fadeTimer.Start();
        }

        private void FadeTimer_Tick(object? sender, EventArgs e)
        {
            _opacity += 0.08;
            if (_opacity >= 1)
            {
                _opacity = 1;
                _fadeTimer?.Stop();
                _fadeTimer?.Dispose();
            }
            this.Opacity = _opacity;
        }

        private void LoadPlantData()
        {
            if (AuthService.CurrentUser == null) return;

            _plant = _context.Plants
                .Include(p => p.PlantType)
                .FirstOrDefault(p => p.UserId == AuthService.CurrentUser.Id && p.SlotNumber == _slotNumber);

            if (_plant != null)
            {
                ShowPlantInfo();
            }
            else
            {
                ShowEmptySlot();
            }
        }

        private void ShowPlantInfo()
        {
            picPlantIcon.Visible = true;
            lblPlantName.Visible = true;
            lblPlantType.Visible = true;
            lblLastWatered.Visible = true;
            progressHealth.Visible = true;
            lblHealthText.Visible = true;
            lblLocation.Visible = true;
            btnEdit.Visible = true;

            lblEmptySlot.Visible = false;
            btnAddPlant.Visible = false;

            LoadPlantIcon(_plant!.PlantType?.Name);
            lblPlantName.Text = _plant.Name;
            lblPlantType.Text = $"Tür: {_plant.PlantType?.Name ?? "Bilinmiyor"}";

            if (_plant.LastWateredDate.HasValue)
            {
                var daysSinceWatered = (DateTime.Now - _plant.LastWateredDate.Value).Days;
                lblLastWatered.Text = daysSinceWatered == 0 
                    ? "💧 Son Sulama: Bugün" 
                    : $"💧 Son Sulama: {daysSinceWatered} gün önce";
            }
            else
            {
                lblLastWatered.Text = "💧 Henüz sulanmadı";
            }

            var healthScore = _healthAnalyzer.CalculateHealthScore(_plant);
            progressHealth.Value = healthScore;
            lblHealthText.Text = $"❤️ Sağlık: {healthScore}/100";
            
            if (healthScore >= 70)
                progressHealth.ForeColor = Color.FromArgb(76, 175, 80);
            else if (healthScore >= 40)
                progressHealth.ForeColor = Color.FromArgb(255, 193, 7);
            else
                progressHealth.ForeColor = Color.FromArgb(244, 67, 54);

            lblLocation.Text = $"📍 {_plant.Location ?? "Konum belirtilmemiş"}";
        }

        private void LoadPlantIcon(string? plantTypeName)
        {
            string iconFile = GetIconFileName(plantTypeName);
            string iconPath = Path.Combine(Application.StartupPath, "..", "..", "..", "Resources", "PixelPlants", iconFile);
            
            try
            {
                if (File.Exists(iconPath))
                {
                    picPlantIcon.Image = Image.FromFile(iconPath);
                }
                else
                {
                    picPlantIcon.Image = null;
                }
            }
            catch
            {
                picPlantIcon.Image = null;
            }
        }

        private string GetIconFileName(string? plantTypeName)
        {
            return plantTypeName?.ToLower() switch
            {
                "sukulent" or "aloe vera" => "succulent.png",
                "kaktüs" => "cactus.png",
                "orkide" => "orchid.png",
                "monstera" or "filodendron" or "pothos" => "monstera.png",
                "palmiye" => "palm.png",
                "fern" or "eğrelti" => "fern.png",
                "fikus" or "yucca" => "ficus.png",
                "gül" or "yasemin" or "lale" or "menekşe" or "lavanta" => "flower.png",
                "domates" or "biber" => "tomato.png",
                "fesleğen" or "nane" or "maydanoz" => "herbs.png",
                _ => "succulent.png"
            };
        }

        private void ShowEmptySlot()
        {
            picPlantIcon.Image = null;
            picPlantIcon.Visible = false;
            lblPlantName.Visible = false;
            lblPlantType.Visible = false;
            lblLastWatered.Visible = false;
            progressHealth.Visible = false;
            lblHealthText.Visible = false;
            lblLocation.Visible = false;
            btnEdit.Visible = false;

            lblEmptySlot.Visible = true;
            btnAddPlant.Visible = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_plant == null) return;

            var editForm = new PlantEditForm(_plant.Id);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                PlantChanged = true;
                LoadPlantData();
            }
        }

        private void btnAddPlant_Click(object sender, EventArgs e)
        {
            var addForm = new PlantEditForm();
            addForm.SetSlotNumber(_slotNumber);
            
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                PlantChanged = true;
                LoadPlantData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlantSlotPopup_Deactivate(object sender, EventArgs e)
        {
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _fadeTimer?.Dispose();
            _closeTimer?.Dispose();
            _context.Dispose();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000; // CS_DROPSHADOW
                return cp;
            }
        }
    }
}
