using GreenGuard.Data;
using GreenGuard.Models;
using GreenGuard.Services;
using GreenGuard.Helpers;

namespace GreenGuard.Forms
{
    /// <summary>
    /// Hatırlatmalar ve Yapılacaklar Detay Formu
    /// Dashboard'daki özet panele tıklandığında açılır
    /// </summary>
    public partial class RemindersDetailForm : Form
    {
        private readonly GreenGuardDbContext _context;
        private readonly ReminderService _reminderService;
        private readonly int _userId;
        
        // Form taşıma için
        private bool _isDragging = false;
        private Point _dragOffset;
        
        public RemindersDetailForm(int userId)
        {
            _userId = userId;
            _context = new GreenGuardDbContext();
            _reminderService = new ReminderService(_context);
            
            InitializeComponent();
            
            // Form taşıma olaylarını bağla
            this.panelHeader.MouseDown += PanelHeader_MouseDown;
            this.panelHeader.MouseMove += PanelHeader_MouseMove;
            this.panelHeader.MouseUp += PanelHeader_MouseUp;
        }
        
        private async void RemindersDetailForm_Load(object sender, EventArgs e)
        {
            await LoadRemindersAsync();
        }
        
        /// <summary>
        /// Tüm hatırlatmaları yükler ve görüntüler
        /// </summary>
        private async Task LoadRemindersAsync()
        {
            flowLayoutReminders.Controls.Clear();
            
            var reminders = await _reminderService.GetActiveRemindersAsync(_userId);
            
            // Kategorilere ayır
            var urgentReminders = reminders.Where(r => !r.IsCompleted && r.Priority == ReminderPriority.Urgent).ToList();
            var upcomingReminders = reminders.Where(r => !r.IsCompleted && r.Priority == ReminderPriority.Upcoming).ToList();
            var normalReminders = reminders.Where(r => !r.IsCompleted && r.Priority == ReminderPriority.Normal).ToList();
            var userNotes = reminders.Where(r => !r.IsCompleted && r.Type == ReminderType.UserNote).ToList();
            var completedReminders = reminders.Where(r => r.IsCompleted).ToList();
            
            // Acil bölümü
            if (urgentReminders.Any())
            {
                AddSectionHeader("🔴 ACİL (Bugün / Gecikmiş)", Color.FromArgb(200, 50, 50));
                foreach (var reminder in urgentReminders)
                {
                    AddReminderItem(reminder);
                }
            }
            
            // Yakın bölümü
            if (upcomingReminders.Any())
            {
                AddSectionHeader("🟡 YAKIN (1-3 gün)", Color.FromArgb(180, 140, 20));
                foreach (var reminder in upcomingReminders.Where(r => r.Type != ReminderType.UserNote))
                {
                    AddReminderItem(reminder);
                }
            }
            
            // Kişisel notlar bölümü (UserNote ve Normal)
            var allNotes = normalReminders.Concat(userNotes.Where(r => r.Priority == ReminderPriority.Normal)).Distinct().ToList();
            if (allNotes.Any() || userNotes.Any())
            {
                AddSectionHeader("📝 KİŞİSEL NOTLAR", Color.FromArgb(50, 100, 150));
                foreach (var reminder in userNotes.Union(normalReminders).Distinct())
                {
                    AddReminderItem(reminder);
                }
            }
            
            // Tamamlananlar bölümü
            if (completedReminders.Any())
            {
                AddSectionHeader("✅ TAMAMLANAN", Color.FromArgb(100, 150, 100));
                foreach (var reminder in completedReminders)
                {
                    AddReminderItem(reminder, isCompleted: true);
                }
            }
            
            // Hiç hatırlatma yoksa
            if (!reminders.Any())
            {
                var emptyLabel = new Label
                {
                    Text = "🌿 Şu an hatırlatma yok!\nBitki ekledikçe bakım hatırlatmaları\notomatik olarak görünecek.",
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.FromArgb(100, 130, 100),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Padding = new Padding(20)
                };
                flowLayoutReminders.Controls.Add(emptyLabel);
            }
        }
        
        /// <summary>
        /// Bölüm başlığı ekler
        /// </summary>
        private void AddSectionHeader(string text, Color color)
        {
            var header = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = color,
                AutoSize = false,
                Width = flowLayoutReminders.Width - 30,
                Height = 30,
                Padding = new Padding(0, 10, 0, 0)
            };
            flowLayoutReminders.Controls.Add(header);
        }
        
        /// <summary>
        /// Tek bir hatırlatma öğesi ekler
        /// </summary>
        private void AddReminderItem(UserReminder reminder, bool isCompleted = false)
        {
            var panel = new Panel
            {
                Width = flowLayoutReminders.Width - 30,
                Height = 50,
                BackColor = isCompleted ? Color.FromArgb(230, 240, 230) : Color.White,
                Margin = new Padding(0, 2, 0, 2),
                Cursor = Cursors.Hand,
                Tag = reminder
            };
            
            // Yuvarlak köşeler için
            panel.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using var pen = new Pen(Color.FromArgb(200, 220, 200), 1);
                g.DrawRoundedRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1, 8);
            };
            
            // Checkbox
            var checkbox = new CheckBox
            {
                Checked = isCompleted,
                Location = new Point(10, 15),
                Size = new Size(20, 20),
                Tag = reminder.Id
            };
            checkbox.CheckedChanged += async (s, e) => await OnReminderCheckedChangedAsync(reminder.Id, checkbox.Checked);
            panel.Controls.Add(checkbox);
            
            // Başlık
            var lblTitle = new Label
            {
                Text = reminder.Title,
                Font = new Font("Segoe UI", 10F, isCompleted ? FontStyle.Strikeout : FontStyle.Regular),
                ForeColor = isCompleted ? Color.Gray : Color.FromArgb(53, 94, 59),
                Location = new Point(35, 5),
                AutoSize = true
            };
            panel.Controls.Add(lblTitle);
            
            // Detay bilgisi
            string detailText = "";
            if (reminder.DueDate.HasValue)
            {
                var daysUntil = (reminder.DueDate.Value - DateTime.Now).Days;
                if (daysUntil < 0)
                    detailText = $"📅 {Math.Abs(daysUntil)} gün gecikmiş!";
                else if (daysUntil == 0)
                    detailText = "📅 Bugün";
                else
                    detailText = $"📅 {daysUntil} gün sonra";
            }
            if (reminder.Plant != null)
            {
                detailText += $" │ 📍 {reminder.Plant.Location}";
            }
            if (isCompleted && reminder.CompletedAt.HasValue)
            {
                var daysAgo = (DateTime.Now - reminder.CompletedAt.Value).Days;
                var remainingDays = 5 - daysAgo;
                detailText = $"✅ Tamamlandı ({remainingDays} gün sonra silinir)";
            }
            
            if (!string.IsNullOrEmpty(detailText))
            {
                var lblDetail = new Label
                {
                    Text = detailText,
                    Font = new Font("Segoe UI", 8F),
                    ForeColor = Color.Gray,
                    Location = new Point(35, 28),
                    AutoSize = true
                };
                panel.Controls.Add(lblDetail);
            }
            
            // Silme butonu (sadece kullanıcı notları için)
            if (reminder.Type == ReminderType.UserNote)
            {
                var btnDelete = new Button
                {
                    Text = "🗑",
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(25, 25),
                    Location = new Point(panel.Width - 35, 12),
                    BackColor = Color.Transparent,
                    ForeColor = Color.FromArgb(200, 100, 100),
                    Cursor = Cursors.Hand,
                    Tag = reminder.Id
                };
                btnDelete.FlatAppearance.BorderSize = 0;
                btnDelete.Click += async (s, e) => await OnDeleteReminderAsync(reminder.Id);
                panel.Controls.Add(btnDelete);
            }
            
            flowLayoutReminders.Controls.Add(panel);
        }
        
        /// <summary>
        /// Hatırlatma checkbox değiştiğinde
        /// </summary>
        private async Task OnReminderCheckedChangedAsync(int reminderId, bool isChecked)
        {
            if (isChecked)
            {
                await _reminderService.MarkAsCompletedAsync(reminderId);
            }
            else
            {
                await _reminderService.MarkAsUncompletedAsync(reminderId);
            }
            
            // Listeyi yenile
            await LoadRemindersAsync();
        }
        
        /// <summary>
        /// Hatırlatma silindiğinde
        /// </summary>
        private async Task OnDeleteReminderAsync(int reminderId)
        {
            var result = MessageBox.Show("Bu notu silmek istediğinize emin misiniz?", 
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                await _reminderService.DeleteReminderAsync(reminderId);
                await LoadRemindersAsync();
            }
        }
        
        /// <summary>
        /// Yeni not ekle butonuna tıklandığında
        /// </summary>
        private async void btnAddNote_Click(object sender, EventArgs e)
        {
            using var addForm = new AddReminderForm(_userId);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await LoadRemindersAsync();
            }
        }
        
        /// <summary>
        /// Kapat butonuna tıklandığında
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        #region Form Dragging
        
        private void PanelHeader_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _dragOffset = e.Location;
            }
        }
        
        private void PanelHeader_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                var newLocation = this.PointToScreen(e.Location);
                this.Location = new Point(newLocation.X - _dragOffset.X, newLocation.Y - _dragOffset.Y);
            }
        }
        
        private void PanelHeader_MouseUp(object? sender, MouseEventArgs e)
        {
            _isDragging = false;
        }
        
        #endregion
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
    
    /// <summary>
    /// Graphics extension for rounded rectangles
    /// </summary>
    public static class GraphicsExtensions
    {
        public static void DrawRoundedRectangle(this Graphics g, Pen pen, float x, float y, float width, float height, float radius)
        {
            using var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(x, y, radius * 2, radius * 2, 180, 90);
            path.AddArc(x + width - radius * 2, y, radius * 2, radius * 2, 270, 90);
            path.AddArc(x + width - radius * 2, y + height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(x, y + height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            g.DrawPath(pen, path);
        }
    }
}
