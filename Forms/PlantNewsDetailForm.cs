using System.IO;
using GreenGuard.Helpers;

namespace GreenGuard.Forms
{
    public partial class PlantNewsDetailForm : Form
    {
        private readonly PlantArticle _article;
        
        public PlantNewsDetailForm(PlantArticle article)
        {
            _article = article;
            InitializeComponent();
        }

        private void PlantNewsDetailForm_Load(object sender, EventArgs e)
        {
            LoadArticle();
            LoadRelatedArticles();
        }

        /// <summary>
        /// Makaleyi yükler
        /// </summary>
        private void LoadArticle()
        {
            lblArticleTitle.Text = _article.Title;
            lblCategory.Text = _article.Category;
            lblReadTime.Text = $"⏱️ {_article.ReadTimeMinutes} dakika okuma";
            txtContent.Text = _article.FullContent;
            
            // Pixel art görselini yükle
            LoadArticleImage();
        }

        /// <summary>
        /// Makale görselini yükler
        /// </summary>
        private void LoadArticleImage()
        {
            try
            {
                if (!string.IsNullOrEmpty(_article.ImageName))
                {
                    var imagePath = Path.Combine(Application.StartupPath, "Resources", "PixelPlants", _article.ImageName);
                    if (File.Exists(imagePath))
                    {
                        picArticle.Image = Image.FromFile(imagePath);
                        return;
                    }
                }
                
                // Varsayılan görsel
                var defaultPath = Path.Combine(Application.StartupPath, "Resources", "PixelPlants", "flower.png");
                if (File.Exists(defaultPath))
                {
                    picArticle.Image = Image.FromFile(defaultPath);
                }
            }
            catch { }
        }

        /// <summary>
        /// Benzer makaleleri yükler
        /// </summary>
        private void LoadRelatedArticles()
        {
            flowRelated.Controls.Clear();
            
            // Aynı kategoriden diğer makaleleri al
            var related = PlantNewsData.AllArticles
                .Where(a => a.Category == _article.Category && a.Id != _article.Id)
                .Take(5)
                .ToList();
            
            // Yeterli değilse diğer kategorilerden ekle
            if (related.Count < 5)
            {
                var others = PlantNewsData.AllArticles
                    .Where(a => a.Id != _article.Id && !related.Contains(a))
                    .Take(5 - related.Count);
                related.AddRange(others);
            }
            
            foreach (var article in related)
            {
                var card = CreateRelatedCard(article);
                flowRelated.Controls.Add(card);
            }
        }

        /// <summary>
        /// İlgili makale kartı oluşturur
        /// </summary>
        private Panel CreateRelatedCard(PlantArticle article)
        {
            var card = new Panel
            {
                Size = new Size(250, 80),
                BackColor = Color.White,
                Margin = new Padding(5),
                Cursor = Cursors.Hand,
                Tag = article
            };

            // Mini görsel
            var pic = new PictureBox
            {
                Size = new Size(60, 60),
                Location = new Point(10, 10),
                BackColor = Color.FromArgb(230, 245, 230),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            
            try
            {
                var imagePath = Path.Combine(Application.StartupPath, "Resources", "PixelPlants", article.ImageName);
                if (File.Exists(imagePath))
                {
                    pic.Image = Image.FromFile(imagePath);
                }
            }
            catch { }
            
            card.Controls.Add(pic);

            // Başlık
            var lblTitle = new Label
            {
                Text = article.Title,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 60, 40),
                Location = new Point(75, 10),
                Size = new Size(165, 35),
                AutoEllipsis = true
            };
            card.Controls.Add(lblTitle);

            // Kategori
            var lblCat = new Label
            {
                Text = article.Category,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(76, 175, 80),
                Location = new Point(75, 50),
                Size = new Size(100, 20)
            };
            card.Controls.Add(lblCat);

            // Hover efekti
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(240, 250, 240);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;

            // Tıklama - yeni makale aç
            card.Click += (s, e) =>
            {
                var detailForm = new PlantNewsDetailForm(article);
                detailForm.ShowDialog(this);
            };
            
            foreach (Control ctrl in card.Controls)
            {
                ctrl.Click += (s, e) =>
                {
                    var detailForm = new PlantNewsDetailForm(article);
                    detailForm.ShowDialog(this);
                };
            }

            return card;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
