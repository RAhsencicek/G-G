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
        private Plant? _plant;
        private bool _isEdit;
        private int? _slotNumber;

        public PlantEditForm(Plant? plant = null)
        {
            _context = new GreenGuardDbContext();
            _plant = plant;
            _isEdit = plant != null;

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
                        SlotNumber = _slotNumber  // Dashboard slot numarası
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
    }
}
