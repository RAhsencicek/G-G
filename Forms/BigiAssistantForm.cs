using System.IO;
using GreenGuard.Services;

namespace GreenGuard.Forms
{
    public partial class BigiAssistantForm : Form
    {
        private readonly GroqService _groqService;
        private readonly string _userName;

        public BigiAssistantForm()
        {
            // API anahtarını ortam değişkeninden oku
            var apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY") ?? "";
            _groqService = new GroqService(apiKey);
            _userName = AuthService.CurrentUser?.FullName ?? "Arkadaş";
            
            InitializeComponent();
        }

        private void BigiAssistantForm_Load(object sender, EventArgs e)
        {
            // Karakter resmini yükle
            LoadCharacterImage();
            
            // Kişiselleştirilmiş karşılama
            lblWelcome.Text = $"Merhaba {_userName}! 🌞\nBen BİGİ, senin bitki asistanın!\nBitkiler hakkında her şeyi sorabilirsin. 🌱";
            
            txtInput.Focus();
        }

        /// <summary>
        /// Karakter resmini yükler
        /// </summary>
        private void LoadCharacterImage()
        {
            try
            {
                var imagePath = Path.Combine(Application.StartupPath, "Resources", "PixelPlants", "gardener_avatar.png");
                if (File.Exists(imagePath))
                {
                    picCharacter.Image = Image.FromFile(imagePath);
                }
            }
            catch
            {
                // Resim yüklenemezse varsayılan emoji göster
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            await SendMessageAsync();
        }

        private async void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                await SendMessageAsync();
            }
        }

        private async Task SendMessageAsync()
        {
            var question = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(question)) return;

            // Kullanıcı mesajını göster
            AppendMessage($"Sen: {question}", Color.FromArgb(180, 220, 180));
            txtInput.Clear();
            txtInput.Enabled = false;
            btnSend.Enabled = false;
            btnSend.Text = "...";

            // Yazıyor göstergesi
            AppendMessage("BİGİ düşünüyor... 🤔", Color.FromArgb(150, 150, 150));

            try
            {
                // API'dan cevap al
                var response = await _groqService.AskGardenerAsync(_userName, question);
                
                // Yazıyor mesajını kaldır (son satırı sil)
                RemoveLastLine();
                
                // Gerçek cevabı göster
                AppendMessage($"🌱 BİGİ: {response}", Color.FromArgb(255, 200, 100));
            }
            catch (Exception ex)
            {
                RemoveLastLine();
                AppendMessage($"😅 Bir sorun oluştu: {ex.Message}", Color.FromArgb(255, 100, 100));
            }
            finally
            {
                txtInput.Enabled = true;
                btnSend.Enabled = true;
                btnSend.Text = "Gönder 🌱";
                txtInput.Focus();
            }
        }

        /// <summary>
        /// Sohbete mesaj ekler
        /// </summary>
        private void AppendMessage(string text, Color color)
        {
            txtChat.SelectionStart = txtChat.TextLength;
            txtChat.SelectionLength = 0;
            txtChat.SelectionColor = color;
            txtChat.AppendText(text + Environment.NewLine + Environment.NewLine);
            txtChat.ScrollToCaret();
        }

        /// <summary>
        /// Son satırı kaldırır (yazıyor göstergesi için)
        /// </summary>
        private void RemoveLastLine()
        {
            var lines = txtChat.Lines.ToList();
            if (lines.Count >= 2)
            {
                // Son 2 satırı kaldır (mesaj + boş satır)
                lines.RemoveAt(lines.Count - 1);
                lines.RemoveAt(lines.Count - 1);
                txtChat.Lines = lines.ToArray();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
