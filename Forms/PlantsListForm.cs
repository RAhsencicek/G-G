using System.IO;
using GreenGuard.Data;
using GreenGuard.Models;
using GreenGuard.Services;
using Microsoft.EntityFrameworkCore;

namespace GreenGuard.Forms
{
    public partial class PlantsListForm : Form
    {
        private readonly GreenGuardDbContext _context;
        private List<Plant> _allPlants = new();
        private readonly string _pixelArtPath;

        public PlantsListForm()
        {
            _context = new GreenGuardDbContext();
            _pixelArtPath = Path.Combine(Application.StartupPath, "..", "..", "..", "Resources", "PixelPlants");
            
            InitializeComponent();
        }

        private async void PlantsListForm_Load(object sender, EventArgs e)
        {
            // Varsayılan seçimler
            cmbCategory.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            
            await LoadPlantsAsync();
        }

        /// <summary>
        /// Tüm bitkileri veritabanından yükler
        /// </summary>
        private async Task LoadPlantsAsync()
        {
            if (AuthService.CurrentUser == null) return;

            try
            {
                _allPlants = await _context.Plants
                    .Include(p => p.PlantType)
                    .Where(p => p.UserId == AuthService.CurrentUser.Id)
                    .OrderBy(p => p.Name)
                    .ToListAsync();

                ApplyFiltersAndDisplay();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Bitki yükleme hatası: {ex.Message}");
            }
        }

        /// <summary>
        /// Filtreleri uygular ve kartları gösterir
        /// </summary>
        private void ApplyFiltersAndDisplay()
        {
            var filtered = _allPlants.AsEnumerable();

            // Kategori filtresi
            if (cmbCategory.SelectedIndex > 0)
            {
                var selectedCategory = cmbCategory.SelectedItem?.ToString();
                filtered = filtered.Where(p => p.PlantType?.Category == selectedCategory);
            }

            // Sıralama
            filtered = cmbSort.SelectedIndex switch
            {
                1 => filtered.OrderByDescending(p => p.HealthScore), // Sağlığa göre
                2 => filtered.OrderBy(p => GetNextWateringDays(p)), // Sulama ihtiyacı
                3 => filtered.OrderByDescending(p => p.CreatedAt), // Ekleme tarihi
                _ => filtered.OrderBy(p => p.Name) // İsme göre
            };

            DisplayPlants(filtered.ToList());
        }

        /// <summary>
        /// Sonraki sulama gününü hesaplar
        /// </summary>
        private int GetNextWateringDays(Plant plant)
        {
            if (plant.LastWateredDate == null || plant.PlantType == null)
                return 0; // Hemen sulanmalı

            var daysSinceWater = (DateTime.Now - plant.LastWateredDate.Value).Days;
            var daysRemaining = plant.PlantType.OptimalWateringDays - daysSinceWater;
            return Math.Max(0, daysRemaining);
        }

        /// <summary>
        /// Bitkileri kart olarak gösterir
        /// </summary>
        private void DisplayPlants(List<Plant> plants)
        {
            panelCards.Controls.Clear();

            lblTotalPlants.Text = $"Toplam: {plants.Count} bitki";

            if (plants.Count == 0)
            {
                var emptyLabel = new Label
                {
                    Text = "🌱 Henüz bitki eklenmemiş.\nYeni bitki eklemek için yukarıdaki butonu kullanın.",
                    Font = new Font("Segoe UI", 14F),
                    ForeColor = Color.FromArgb(150, 200, 150),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Margin = new Padding(50, 100, 50, 50)
                };
                panelCards.Controls.Add(emptyLabel);
                return;
            }

            foreach (var plant in plants)
            {
                var card = CreatePlantCard(plant);
                panelCards.Controls.Add(card);
            }
        }

        /// <summary>
        /// Tek bir bitki kartı oluşturur
        /// </summary>
        private Panel CreatePlantCard(Plant plant)
        {
            var card = new Panel
            {
                Size = new Size(200, 260),
                BackColor = Color.FromArgb(50, 90, 70),
                Margin = new Padding(10),
                Cursor = Cursors.Hand,
                Tag = plant
            };

            // Yuvarlak köşe efekti için
            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            };

            // Dashboard'da mı? (Yıldız ikonu)
            if (plant.SlotNumber.HasValue && plant.SlotNumber > 0)
            {
                var starLabel = new Label
                {
                    Text = "⭐",
                    Font = new Font("Segoe UI Emoji", 12F),
                    ForeColor = Color.Gold,
                    Location = new Point(5, 5),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                card.Controls.Add(starLabel);
            }

            // Silme butonu (sağ üst köşe)
            var btnDelete = new Button
            {
                Text = "✕",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(25, 25),
                Location = new Point(170, 5),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(180, 60, 60),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += async (s, e) => await DeletePlantAsync(plant);
            card.Controls.Add(btnDelete);
            btnDelete.BringToFront();

            // Bitki resmi
            var picPlant = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point(60, 15),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };
            
            // Resim yükleme
            var imagePath = GetPlantImagePath(plant);
            if (File.Exists(imagePath))
            {
                try { picPlant.Image = Image.FromFile(imagePath); }
                catch { picPlant.Image = null; }
            }
            card.Controls.Add(picPlant);

            // Bitki adı
            var lblName = new Label
            {
                Text = plant.Nickname ?? plant.Name,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(10, 100),
                Size = new Size(180, 25),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblName);

            // Tür adı
            var lblType = new Label
            {
                Text = plant.PlantType?.Name ?? "Bilinmiyor",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(180, 220, 180),
                Location = new Point(10, 122),
                Size = new Size(180, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblType);

            // Sağlık barı
            var healthPanel = new Panel
            {
                Location = new Point(20, 148),
                Size = new Size(160, 10),
                BackColor = Color.FromArgb(30, 60, 45)
            };
            
            var healthColor = plant.HealthScore >= 70 ? Color.FromArgb(100, 200, 100) :
                             plant.HealthScore >= 40 ? Color.FromArgb(220, 180, 50) :
                             Color.FromArgb(220, 80, 80);
            
            var healthBar = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size((int)(160 * plant.HealthScore / 100.0), 10),
                BackColor = healthColor
            };
            healthPanel.Controls.Add(healthBar);
            card.Controls.Add(healthPanel);

            // Sağlık yüzdesi
            var lblHealth = new Label
            {
                Text = $"❤️ {plant.HealthScore}%",
                Font = new Font("Segoe UI", 9F),
                ForeColor = healthColor,
                Location = new Point(10, 162),
                Size = new Size(180, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblHealth);

            // Sulama durumu
            var wateringDays = GetNextWateringDays(plant);
            var waterText = wateringDays == 0 ? "💧 Bugün sula!" :
                           wateringDays == 1 ? "💧 Yarın" :
                           $"💧 {wateringDays} gün";
            var waterColor = wateringDays == 0 ? Color.FromArgb(100, 180, 255) :
                            Color.FromArgb(150, 200, 150);

            var lblWater = new Label
            {
                Text = waterText,
                Font = new Font("Segoe UI", 9F),
                ForeColor = waterColor,
                Location = new Point(10, 185),
                Size = new Size(180, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblWater);

            // Konum
            var lblLocation = new Label
            {
                Text = $"📍 {plant.Location}",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(150, 180, 150),
                Location = new Point(10, 208),
                Size = new Size(180, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblLocation);

            // Kategori etiketi
            var categoryColor = plant.PlantType?.Category switch
            {
                "İç Mekan" => Color.FromArgb(80, 150, 200),
                "Dış Mekan" => Color.FromArgb(100, 180, 100),
                "Sebze" => Color.FromArgb(200, 150, 80),
                "Aromatik" => Color.FromArgb(180, 120, 180),
                _ => Color.FromArgb(120, 120, 120)
            };

            var lblCategory = new Label
            {
                Text = plant.PlantType?.Category ?? "",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.White,
                BackColor = categoryColor,
                Location = new Point(60, 232),
                AutoSize = true,
                Padding = new Padding(5, 2, 5, 2)
            };
            card.Controls.Add(lblCategory);

            // Kart tıklama olayı
            card.Click += (s, e) => OpenPlantEdit(plant);
            foreach (Control ctrl in card.Controls)
            {
                ctrl.Click += (s, e) => OpenPlantEdit(plant);
            }

            // Hover efekti
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(60, 110, 85);
            card.MouseLeave += (s, e) => card.BackColor = Color.FromArgb(50, 90, 70);

            return card;
        }

        /// <summary>
        /// Bitki için uygun resim yolunu döndürür
        /// </summary>
        private string GetPlantImagePath(Plant plant)
        {
            // Önce kullanıcının seçtiği resim varsa onu kullan
            if (!string.IsNullOrEmpty(plant.PhotoPath) && File.Exists(plant.PhotoPath))
            {
                return plant.PhotoPath;
            }

            // Bitki türüne göre varsayılan pixel art seç
            var typeName = plant.PlantType?.Name?.ToLower() ?? "";
            var category = plant.PlantType?.Category ?? "";

            // İsme göre eşleştir
            if (typeName.Contains("orkide") || typeName.Contains("orchid"))
                return Path.Combine(_pixelArtPath, "orchid.png");
            if (typeName.Contains("monstera"))
                return Path.Combine(_pixelArtPath, "monstera.png");
            if (typeName.Contains("kaktüs") || typeName.Contains("cactus"))
                return Path.Combine(_pixelArtPath, "cactus.png");
            if (typeName.Contains("sukulent") || typeName.Contains("succulent"))
                return Path.Combine(_pixelArtPath, "succulent.png");
            if (typeName.Contains("palmiye") || typeName.Contains("palm"))
                return Path.Combine(_pixelArtPath, "palm.png");
            if (typeName.Contains("ficus") || typeName.Contains("kauçuk"))
                return Path.Combine(_pixelArtPath, "ficus.png");
            if (typeName.Contains("eğrelti") || typeName.Contains("fern"))
                return Path.Combine(_pixelArtPath, "fern.png");
            if (typeName.Contains("domates") || typeName.Contains("tomato"))
                return Path.Combine(_pixelArtPath, "tomato.png");

            // Kategoriye göre varsayılan
            return category switch
            {
                "Aromatik" => Path.Combine(_pixelArtPath, "herbs.png"),
                "Sebze" => Path.Combine(_pixelArtPath, "tomato.png"),
                "İç Mekan" => Path.Combine(_pixelArtPath, "monstera.png"),
                _ => Path.Combine(_pixelArtPath, "flower.png")
            };
        }

        /// <summary>
        /// Bitki düzenleme formunu açar
        /// </summary>
        private void OpenPlantEdit(Plant plant)
        {
            var editForm = new PlantEditForm(plant.Id);
            if (editForm.ShowDialog(this) == DialogResult.OK)
            {
                // Listeyi yenile
                _ = LoadPlantsAsync();
            }
        }

        private void btnAddPlant_Click(object sender, EventArgs e)
        {
            var addForm = new PlantEditForm();
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                _ = LoadPlantsAsync();
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndDisplay();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndDisplay();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }

        /// <summary>
        /// Bitkiyi siler
        /// </summary>
        private async Task DeletePlantAsync(Plant plant)
        {
            var result = MessageBox.Show(
                $"\"{plant.Nickname ?? plant.Name}\" bitkisini silmek istediğinize emin misiniz?\n\n" +
                "Bu işlem geri alınamaz ve bitkiye ait tüm bakım geçmişi silinecektir.",
                "Bitki Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes) return;

            try
            {
                // İlişkili verileri sil
                var careLogs = _context.CareLogs.Where(c => c.PlantId == plant.Id);
                _context.CareLogs.RemoveRange(careLogs);

                var reminders = _context.UserReminders.Where(r => r.PlantId == plant.Id);
                _context.UserReminders.RemoveRange(reminders);

                // Bitkiyi sil
                _context.Plants.Remove(plant);
                await _context.SaveChangesAsync();

                MessageBox.Show("Bitki başarıyla silindi. 🗑️", "Silindi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Listeyi yenile
                await LoadPlantsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme sırasında hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
