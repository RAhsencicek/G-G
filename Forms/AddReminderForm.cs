using GreenGuard.Data;
using GreenGuard.Services;

namespace GreenGuard.Forms
{
    /// <summary>
    /// Yeni not/hatırlatma ekleme formu
    /// </summary>
    public partial class AddReminderForm : Form
    {
        private readonly GreenGuardDbContext _context;
        private readonly ReminderService _reminderService;
        private readonly int _userId;
        
        public AddReminderForm(int userId)
        {
            _userId = userId;
            _context = new GreenGuardDbContext();
            _reminderService = new ReminderService(_context);
            
            InitializeComponent();
        }
        
        /// <summary>
        /// Tarih checkbox değiştiğinde
        /// </summary>
        private void chkHasDate_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker.Enabled = chkHasDate.Checked;
            if (chkHasDate.Checked)
            {
                dateTimePicker.Value = DateTime.Now.AddDays(1);
            }
        }
        
        /// <summary>
        /// Kaydet butonuna tıklandığında
        /// </summary>
        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Lütfen bir başlık girin.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }
            
            btnSave.Enabled = false;
            btnSave.Text = "Kaydediliyor...";
            
            try
            {
                DateTime? dueDate = chkHasDate.Checked ? dateTimePicker.Value : null;
                string? description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text;
                
                await _reminderService.AddUserNoteAsync(
                    _userId,
                    txtTitle.Text.Trim(),
                    description,
                    dueDate
                );
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "✓ Kaydet";
            }
        }
        
        /// <summary>
        /// İptal butonuna tıklandığında
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
}
