using DevExpress.XtraEditors;
using GreenGuard.Data;
using GreenGuard.Services;

namespace GreenGuard.Forms
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly GreenGuardDbContext _context;
        private readonly AuthService _authService;

        public LoginForm()
        {
            _context = new GreenGuardDbContext();
            _authService = new AuthService(_context);
            
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(
                DevExpress.LookAndFeel.SkinStyle.WXICompact);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                XtraMessageBox.Show("Lütfen kullanıcı adı ve şifre giriniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Giriş yapılıyor...";

            try
            {
                var (success, message) = await _authService.LoginAsync(txtUsername.Text, txtPassword.Text);

                if (success)
                {
                    this.Hide();
                    var dashboard = new DashboardForm();
                    dashboard.FormClosed += (s, args) => this.Close();
                    dashboard.Show();
                }
                else
                {
                    XtraMessageBox.Show(message, "Giriş Başarısız",
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
                btnLogin.Enabled = true;
                btnLogin.Text = "Giriş Yap";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
}
