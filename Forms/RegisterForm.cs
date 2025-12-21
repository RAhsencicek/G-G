using DevExpress.XtraEditors;
using GreenGuard.Data;
using GreenGuard.Services;

namespace GreenGuard.Forms
{
    public partial class RegisterForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly GreenGuardDbContext _context;
        private readonly AuthService _authService;

        public RegisterForm()
        {
            _context = new GreenGuardDbContext();
            _authService = new AuthService(_context);
            
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                XtraMessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                XtraMessageBox.Show("Şifreler eşleşmiyor.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnRegister.Enabled = false;
            btnRegister.Text = "Kaydediliyor...";

            try
            {
                var (success, message) = await _authService.RegisterAsync(
                    txtUsername.Text,
                    txtEmail.Text,
                    txtPassword.Text,
                    txtFullName.Text);

                if (success)
                {
                    XtraMessageBox.Show(message, "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show(message, "Kayıt Başarısız",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRegister.Enabled = true;
                btnRegister.Text = "Kayıt Ol";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
}
