using GreenGuard.Data;
using GreenGuard.Services;
using Microsoft.EntityFrameworkCore;

namespace GreenGuard.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly GreenGuardDbContext _context;
        private readonly HealthAnalyzerService _healthAnalyzer;
        private PlantSlotPopup? _currentPopup;  // Aktif popup takibi

        public DashboardForm()
        {
            _context = new GreenGuardDbContext();
            _healthAnalyzer = new HealthAnalyzerService();

            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Başlık güncelle
            if (AuthService.CurrentUser != null)
            {
                this.Text = $"GreenGuard - Hoş Geldiniz, {AuthService.CurrentUser.FullName}";
            }

            // Bitki slot butonlarını ayarla
            WirePlantButtons();
        }

        private void DashboardForm_Resize(object sender, EventArgs e)
        {
            // Layout sabit kalacak, resize işlemi yok
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Ana sayfa
        }

        private void btnPlants_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Resmin üzerindeki bitkilere tıklayarak detayları görebilirsiniz!",
                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAddPlant_Click(object sender, EventArgs e)
        {
            var form = new PlantEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Yeni bitki eklendi
            }
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
            var result = MessageBox.Show(
                "Çıkış yapmak istediğinize emin misiniz?",
                "Çıkış",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AuthService.CurrentUser = null;
                this.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }

        private void picBackground_Click(object sender, EventArgs e)
        {

        }

        // Bitki slot butonlarını bağla
        private void WirePlantButtons()
        {
            var plantButtons = new[] { button1, button2, button3, button4, button5, button6, button7,
                                       button8, button9, button10, button11, button12, button13, button14 };

            for (int i = 0; i < plantButtons.Length; i++)
            {
                int slotNumber = i + 1;
                Button btn = plantButtons[i];
                
                // Hover'da popup aç
                btn.MouseEnter += (s, e) => {
                    // Mevcut popup'ı iptal et
                    if (_currentPopup != null && !_currentPopup.IsDisposed)
                    {
                        _currentPopup.CancelClose();
                    }
                    OpenPlantSlot(slotNumber, btn);
                };
                
                // Butondan çıkınca close timer başlat
                btn.MouseLeave += (s, e) => {
                    if (_currentPopup != null && !_currentPopup.IsDisposed)
                    {
                        _currentPopup.StartCloseTimer();
                    }
                };
            }

            // Butonları şeffaf yap
            MakePlantButtonsTransparent();
        }

        private void MakePlantButtonsTransparent()
        {
            var plantButtons = new[] { button1, button2, button3, button4, button5, button6, button7,
                                       button8, button9, button10, button11, button12, button13, button14 };

            foreach (var btn in plantButtons)
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
            // Mevcut popup varsa kapat
            if (_currentPopup != null && !_currentPopup.IsDisposed)
            {
                _currentPopup.Close();
            }

            // Yeni popup oluştur
            var popup = new PlantSlotPopup(slotNumber);
            _currentPopup = popup;
            
            // Popup konumunu hesapla
            var buttonScreenPos = button.PointToScreen(Point.Empty);
            int popupX = buttonScreenPos.X + button.Width + 10;
            int popupY = buttonScreenPos.Y - 50;

            // Ekran sınırlarını kontrol et
            var screen = Screen.FromControl(this);
            if (popupX + popup.Width > screen.WorkingArea.Right)
            {
                popupX = buttonScreenPos.X - popup.Width - 10;
            }
            if (popupY + popup.Height > screen.WorkingArea.Bottom)
            {
                popupY = screen.WorkingArea.Bottom - popup.Height - 20;
            }
            if (popupY < screen.WorkingArea.Top)
            {
                popupY = screen.WorkingArea.Top + 20;
            }

            popup.Location = new Point(popupX, popupY);
            popup.Show(this);  // Non-modal göster
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Bu artık WirePlantButtons'da bağlanıyor
        }
    }
}
