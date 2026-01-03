using System.IO;
using DevExpress.XtraEditors;
using GreenGuard.Data;
using GreenGuard.Models;
using GreenGuard.Services;
using Microsoft.EntityFrameworkCore;

namespace GreenGuard.Forms
{
    public partial class PlantEditForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly GreenGuardDbContext _context;
        private readonly ReminderService _reminderService;
        private Plant? _plant;
        private bool _isEdit;
        private int? _slotNumber;
        private string? _selectedPhotoPath;
        private readonly string _pixelArtPath;

        public PlantEditForm(Plant? plant = null)
        {
            _context = new GreenGuardDbContext();
            _reminderService = new ReminderService(_context);
            _plant = plant;
            _isEdit = plant != null;
            _pixelArtPath = Path.Combine(Application.StartupPath, "..", "..", "..", "Resources", "PixelPlants");

            InitializeComponent();
        }

        // ID ile bitki yükleyen constructor
        public PlantEditForm(int plantId) : this()
        {
            _plant = _context.Plants.Include(p => p.PlantType).FirstOrDefault(p => p.Id == plantId);
            _isEdit = _plant != null;
        }

        // Slot numarası ayarla (yeni bitki eklerken)
        public void SetSlotNumber(int slotNumber)
        {
            _slotNumber = slotNumber;
        }

        private void PlantEditForm_Load(object sender, EventArgs e)
        {
            // Form başlığını ayarla
            if (_isEdit)
            {
                lblTitle.Text = "🌿 Bitki Düzenle";
                this.Text = "Bitki Düzenle";
                btnSave.Text = "Güncelle";
                btnWater.Visible = true;
                btnFertilize.Visible = true;
            }
            else
            {
                dateAcquired.EditValue = DateTime.Now;
            }

            LoadPlantTypes();
            LoadPixelArtGallery();

            if (_isEdit && _plant != null)
            {
                LoadPlantData();
            }
        }

        private void LoadPlantTypes()
        {
            var plantTypes = _context.PlantTypes.OrderBy(pt => pt.Category).ThenBy(pt => pt.Name).ToList();

            cmbPlantType.Properties.Items.Clear();
            foreach (var pt in plantTypes)
            {
                cmbPlantType.Properties.Items.Add($"{pt.Name} ({pt.Category})");
            }

            if (cmbPlantType.Properties.Items.Count > 0)
            {
                cmbPlantType.SelectedIndex = 0;
            }
        }

        private void LoadPlantData()
        {
            if (_plant == null) return;

            txtName.Text = _plant.Name;
            txtNickname.Text = _plant.Nickname;
            txtLocation.Text = _plant.Location;
            txtNotes.Text = _plant.Notes;
            dateAcquired.EditValue = _plant.AcquiredDate;

            // Bitki türünü seç
            if (_plant.PlantType != null)
            {
                var typeText = $"{_plant.PlantType.Name} ({_plant.PlantType.Category})";
                var index = cmbPlantType.Properties.Items.IndexOf(typeText);
                if (index >= 0) cmbPlantType.SelectedIndex = index;
            }

            // Mevcut resmi yükle
            if (!string.IsNullOrEmpty(_plant.PhotoPath))
            {
                _selectedPhotoPath = _plant.PhotoPath;
                LoadPreviewImage(_selectedPhotoPath);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                XtraMessageBox.Show("Bitki adı zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPlantType.SelectedIndex < 0)
            {
                XtraMessageBox.Show("Bitki türü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnSave.Enabled = false;

            try
            {
                // Seçilen bitki türünü bul
                var selectedTypeText = cmbPlantType.SelectedItem?.ToString() ?? "";
                var typeName = selectedTypeText.Split(" (")[0];
                var plantType = await _context.PlantTypes.FirstOrDefaultAsync(pt => pt.Name == typeName);

                if (_isEdit && _plant != null)
                {
                    // Güncelle
                    _plant.Name = txtName.Text;
                    _plant.Nickname = txtNickname.Text;
                    _plant.Location = txtLocation.Text;
                    _plant.Notes = txtNotes.Text;
                    _plant.AcquiredDate = (DateTime)dateAcquired.EditValue;
                    _plant.PlantTypeId = plantType?.Id ?? 1;
                    _plant.PhotoPath = _selectedPhotoPath;

                    _context.Plants.Update(_plant);
                }
                else
                {
                    // Yeni ekle
                    var newPlant = new Plant
                    {
                        Name = txtName.Text,
                        Nickname = txtNickname.Text,
                        Location = txtLocation.Text,
                        Notes = txtNotes.Text,
                        AcquiredDate = (DateTime)dateAcquired.EditValue,
                        PlantTypeId = plantType?.Id ?? 1,
                        UserId = AuthService.CurrentUser!.Id,
                        CreatedAt = DateTime.Now,
                        HealthScore = 100,
                        SlotNumber = _slotNumber,  // Dashboard slot numarası
                        PhotoPath = _selectedPhotoPath
                    };

                    _context.Plants.Add(newPlant);
                }

                await _context.SaveChangesAsync();

                XtraMessageBox.Show(_isEdit ? "Bitki güncellendi!" : "Bitki eklendi!", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private async void btnWater_Click(object sender, EventArgs e)
        {
            if (_plant == null) return;

            _plant.LastWateredDate = DateTime.Now;

            var careLog = new CareLog
            {
                PlantId = _plant.Id,
                CareType = CareType.Watering,
                CareDate = DateTime.Now,
                Notes = "Sulama yapıldı"
            };
            _context.CareLogs.Add(careLog);

            await _context.SaveChangesAsync();
            
            // Hatırlatmayı tamamlandı olarak işaretle
            await _reminderService.OnPlantCaredAsync(_plant.Id, ReminderType.Watering);

            XtraMessageBox.Show("Sulama kaydedildi! 💧", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnFertilize_Click(object sender, EventArgs e)
        {
            if (_plant == null) return;

            _plant.LastFertilizedDate = DateTime.Now;

            var careLog = new CareLog
            {
                PlantId = _plant.Id,
                CareType = CareType.Fertilizing,
                CareDate = DateTime.Now,
                Notes = "Gübreleme yapıldı"
            };
            _context.CareLogs.Add(careLog);

            await _context.SaveChangesAsync();
            
            // Hatırlatmayı tamamlandı olarak işaretle
            await _reminderService.OnPlantCaredAsync(_plant.Id, ReminderType.Fertilizing);

            XtraMessageBox.Show("Gübreleme kaydedildi! 🌱", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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

        #region Pixel Art Gallery

        /// <summary>
        /// Mevcut pixel art resimlerini galeriye yükler
        /// </summary>
        private void LoadPixelArtGallery()
        {
            panelGallery.Controls.Clear();

            if (!Directory.Exists(_pixelArtPath)) return;

            // Kullanılabilir pixel art dosyaları (özel olanları hariç tut)
            var excludeFiles = new[] { "water_drop.png", "watering_can.png", "gardener_avatar.png", "plants_set.png" };
            var imageFiles = Directory.GetFiles(_pixelArtPath, "*.png")
                .Where(f => !excludeFiles.Contains(Path.GetFileName(f)))
                .ToList();

            foreach (var imagePath in imageFiles)
            {
                var thumbnail = CreateGalleryThumbnail(imagePath);
                panelGallery.Controls.Add(thumbnail);
            }
        }

        /// <summary>
        /// Galeri için küçük resim oluşturur
        /// </summary>
        private PictureBox CreateGalleryThumbnail(string imagePath)
        {
            var pic = new PictureBox
            {
                Size = new Size(70, 70),
                Margin = new Padding(5),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(50, 80, 60),
                Cursor = Cursors.Hand,
                Tag = imagePath,
                BorderStyle = BorderStyle.FixedSingle
            };

            try
            {
                pic.Image = Image.FromFile(imagePath);
            }
            catch
            {
                pic.BackColor = Color.Gray;
            }

            // Tıklama olayı
            pic.Click += (s, e) =>
            {
                _selectedPhotoPath = imagePath;
                LoadPreviewImage(imagePath);
                HighlightSelectedThumbnail(pic);
            };

            // Hover efekti
            pic.MouseEnter += (s, e) => pic.BackColor = Color.FromArgb(80, 120, 90);
            pic.MouseLeave += (s, e) => 
            {
                if (pic.Tag?.ToString() == _selectedPhotoPath)
                    pic.BackColor = Color.FromArgb(100, 180, 100);
                else
                    pic.BackColor = Color.FromArgb(50, 80, 60);
            };

            return pic;
        }

        /// <summary>
        /// Seçilen thumbnail'ı vurgular
        /// </summary>
        private void HighlightSelectedThumbnail(PictureBox selected)
        {
            foreach (Control ctrl in panelGallery.Controls)
            {
                if (ctrl is PictureBox pic)
                {
                    pic.BackColor = pic == selected 
                        ? Color.FromArgb(100, 180, 100) 
                        : Color.FromArgb(50, 80, 60);
                }
            }
        }

        /// <summary>
        /// Önizleme resmini yükler
        /// </summary>
        private void LoadPreviewImage(string imagePath)
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    picPreview.Image?.Dispose();
                    picPreview.Image = Image.FromFile(imagePath);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Önizleme hatası: {ex.Message}");
            }
        }

        /// <summary>
        /// Kullanıcıdan özel resim seçmesini sağlar
        /// </summary>
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Title = "Bitki Resmi Seç",
                Filter = "Resim Dosyaları|*.png;*.jpg;*.jpeg;*.bmp;*.gif|Tüm Dosyalar|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // UserPlants klasörünü oluştur
                    var userPlantsPath = Path.Combine(Application.StartupPath, "..", "..", "..", "Resources", "UserPlants");
                    if (!Directory.Exists(userPlantsPath))
                    {
                        Directory.CreateDirectory(userPlantsPath);
                    }

                    // Benzersiz dosya adı oluştur
                    var fileName = $"plant_{DateTime.Now:yyyyMMdd_HHmmss}_{Path.GetFileName(openFileDialog.FileName)}";
                    var destinationPath = Path.Combine(userPlantsPath, fileName);

                    // Dosyayı kopyala
                    File.Copy(openFileDialog.FileName, destinationPath, true);

                    // Seçilen resmi ayarla
                    _selectedPhotoPath = destinationPath;
                    LoadPreviewImage(destinationPath);

                    // Galeri seçimini temizle
                    foreach (Control ctrl in panelGallery.Controls)
                    {
                        if (ctrl is PictureBox pic)
                        {
                            pic.BackColor = Color.FromArgb(50, 80, 60);
                        }
                    }

                    XtraMessageBox.Show("Resim başarıyla yüklendi! 🖼️", "Başarılı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Resim yüklenirken hata oluştu: {ex.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}
