using System.IO;
using GreenGuard.Helpers;

namespace GreenGuard.Forms
{
    public partial class PlantNewsForm : Form
    {
        public PlantNewsForm()
        {
            InitializeComponent();
        }

        private void PlantNewsForm_Load(object sender, EventArgs e)
        {
            LoadFeaturedNews();
            LoadNewsCards();
        }

        /// <summary>
        /// Öne çıkan haberi yükler
        /// </summary>
        private void LoadFeaturedNews()
        {
            var featured = PlantNewsData.GetArticleOfTheDay();
            
            lblFeaturedTitle.Text = "🌟 " + featured.Title;
            lblFeaturedText.Text = featured.Summary + "\n\n💡 Detaylar için tıklayın!";
            
            // Görsel yükle
            LoadImage(picFeatured, featured.ImageName);
            
            // Tıklama olayı
            panelFeatured.Cursor = Cursors.Hand;
            panelFeatured.Click += (s, e) => OpenArticle(featured);
            lblFeaturedTitle.Click += (s, e) => OpenArticle(featured);
            lblFeaturedText.Click += (s, e) => OpenArticle(featured);
            picFeatured.Click += (s, e) => OpenArticle(featured);
        }

        /// <summary>
        /// Görsel yükler
        /// </summary>
        private void LoadImage(PictureBox pic, string imageName)
        {
            try
            {
                if (string.IsNullOrEmpty(imageName))
                {
                    imageName = "flower.png";
                }
                
                var imagePath = Path.Combine(Application.StartupPath, "Resources", "PixelPlants", imageName);
                if (File.Exists(imagePath))
                {
                    pic.Image = Image.FromFile(imagePath);
                }
            }
            catch { }
        }

        /// <summary>
        /// Haber kartlarını yükler
        /// </summary>
        private void LoadNewsCards()
        {
            flowNewsCards.Controls.Clear();

            foreach (var article in PlantNewsData.AllArticles)
            {
                var card = CreateNewsCard(article);
                flowNewsCards.Controls.Add(card);
            }
        }

        /// <summary>
        /// Haber kartı oluşturur
        /// </summary>
        private Panel CreateNewsCard(PlantArticle article)
        {
            var card = new Panel
            {
                Size = new Size(260, 130),
                BackColor = GetCategoryColor(article.Category),
                Margin = new Padding(10),
                Cursor = Cursors.Hand,
                Padding = new Padding(10)
            };

            // Mini pixel art görsel
            var pic = new PictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(10, 10),
                BackColor = Color.White,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            LoadImage(pic, article.ImageName);
            card.Controls.Add(pic);

            // Başlık
            var lblTitle = new Label
            {
                Text = article.Title,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 60, 40),
                Location = new Point(70, 10),
                Size = new Size(175, 40),
                AutoEllipsis = true
            };
            card.Controls.Add(lblTitle);

            // Özet
            var lblSummary = new Label
            {
                Text = article.Summary.Length > 50 ? article.Summary.Substring(0, 50) + "..." : article.Summary,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(60, 90, 70),
                Location = new Point(10, 70),
                Size = new Size(240, 35)
            };
            card.Controls.Add(lblSummary);

            // Kategori ve okuma süresi
            var lblInfo = new Label
            {
                Text = $"{article.Category} • ⏱️{article.ReadTimeMinutes} dk",
                Font = new Font("Segoe UI", 7F),
                ForeColor = Color.FromArgb(76, 175, 80),
                Location = new Point(70, 52),
                Size = new Size(175, 15)
            };
            card.Controls.Add(lblInfo);

            // Hover efekti
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(220, 240, 220);
            card.MouseLeave += (s, e) => card.BackColor = GetCategoryColor(article.Category);

            // Tıklama - detay form aç
            card.Click += (s, e) => OpenArticle(article);
            foreach (Control ctrl in card.Controls)
            {
                ctrl.Click += (s, e) => OpenArticle(article);
            }

            return card;
        }

        /// <summary>
        /// Makale detay formunu açar
        /// </summary>
        private void OpenArticle(PlantArticle article)
        {
            var detailForm = new PlantNewsDetailForm(article);
            detailForm.ShowDialog(this);
        }

        /// <summary>
        /// Kategoriye göre renk döndürür
        /// </summary>
        private Color GetCategoryColor(string category)
        {
            return category switch
            {
                "Sulama" => Color.FromArgb(230, 245, 255),
                "Bakım" => Color.FromArgb(230, 245, 230),
                "Mevsimsel" => Color.FromArgb(255, 245, 230),
                "İlginç" => Color.FromArgb(255, 235, 245),
                "Sağlık" => Color.FromArgb(230, 255, 245),
                "Gübreleme" => Color.FromArgb(245, 240, 230),
                "Hastalık" => Color.FromArgb(255, 240, 240),
                "Çoğaltma" => Color.FromArgb(240, 245, 255),
                "Sebze" => Color.FromArgb(255, 250, 230),
                _ => Color.FromArgb(245, 245, 245)
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
