namespace GreenGuard.Forms
{
    partial class PlantSlotPopup
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelMain = new Panel();
            btnClose = new Button();
            picPlantIcon = new PictureBox();
            lblPlantName = new Label();
            lblPlantType = new Label();
            lblLastWatered = new Label();
            progressHealth = new ProgressBar();
            lblHealthText = new Label();
            lblLocation = new Label();
            btnEdit = new Button();
            lblEmptySlot = new Label();
            btnAddPlant = new Button();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPlantIcon).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(245, 250, 245);
            panelMain.Controls.Add(btnClose);
            panelMain.Controls.Add(picPlantIcon);
            panelMain.Controls.Add(lblPlantName);
            panelMain.Controls.Add(lblPlantType);
            panelMain.Controls.Add(lblLastWatered);
            panelMain.Controls.Add(progressHealth);
            panelMain.Controls.Add(lblHealthText);
            panelMain.Controls.Add(lblLocation);
            panelMain.Controls.Add(btnEdit);
            panelMain.Controls.Add(lblEmptySlot);
            panelMain.Controls.Add(btnAddPlant);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(12);
            panelMain.Size = new Size(320, 400);
            panelMain.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 200, 200);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(150, 150, 150);
            btnClose.Location = new Point(275, 8);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(35, 35);
            btnClose.TabIndex = 0;
            btnClose.Text = "×";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // picPlantIcon
            // 
            picPlantIcon.BackColor = Color.FromArgb(230, 245, 230);
            picPlantIcon.Location = new Point(110, 20);
            picPlantIcon.Name = "picPlantIcon";
            picPlantIcon.Size = new Size(100, 100);
            picPlantIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picPlantIcon.TabIndex = 1;
            picPlantIcon.TabStop = false;
            // 
            // lblPlantName
            // 
            lblPlantName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPlantName.ForeColor = Color.FromArgb(53, 94, 59);
            lblPlantName.Location = new Point(12, 130);
            lblPlantName.Name = "lblPlantName";
            lblPlantName.Size = new Size(296, 35);
            lblPlantName.TabIndex = 2;
            lblPlantName.Text = "Bitki Adı";
            lblPlantName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlantType
            // 
            lblPlantType.Font = new Font("Segoe UI", 10F);
            lblPlantType.ForeColor = Color.FromArgb(100, 140, 100);
            lblPlantType.Location = new Point(12, 165);
            lblPlantType.Name = "lblPlantType";
            lblPlantType.Size = new Size(296, 22);
            lblPlantType.TabIndex = 3;
            lblPlantType.Text = "🏷️ Tür: Sukulent";
            lblPlantType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLastWatered
            // 
            lblLastWatered.BackColor = Color.FromArgb(220, 240, 220);
            lblLastWatered.Font = new Font("Segoe UI", 10F);
            lblLastWatered.ForeColor = Color.FromArgb(53, 94, 59);
            lblLastWatered.Location = new Point(12, 200);
            lblLastWatered.Name = "lblLastWatered";
            lblLastWatered.Padding = new Padding(10, 6, 10, 6);
            lblLastWatered.Size = new Size(296, 32);
            lblLastWatered.TabIndex = 4;
            lblLastWatered.Text = "💧 Son Sulama: 2 gün önce";
            // 
            // progressHealth
            // 
            progressHealth.Location = new Point(12, 270);
            progressHealth.Name = "progressHealth";
            progressHealth.Size = new Size(296, 20);
            progressHealth.Style = ProgressBarStyle.Continuous;
            progressHealth.TabIndex = 5;
            progressHealth.Value = 85;
            // 
            // lblHealthText
            // 
            lblHealthText.Font = new Font("Segoe UI", 10F);
            lblHealthText.ForeColor = Color.FromArgb(53, 94, 59);
            lblHealthText.Location = new Point(12, 245);
            lblHealthText.Name = "lblHealthText";
            lblHealthText.Size = new Size(296, 22);
            lblHealthText.TabIndex = 6;
            lblHealthText.Text = "❤️ Sağlık: 85/100";
            // 
            // lblLocation
            // 
            lblLocation.BackColor = Color.FromArgb(220, 240, 220);
            lblLocation.Font = new Font("Segoe UI", 10F);
            lblLocation.ForeColor = Color.FromArgb(53, 94, 59);
            lblLocation.Location = new Point(12, 300);
            lblLocation.Name = "lblLocation";
            lblLocation.Padding = new Padding(10, 6, 10, 6);
            lblLocation.Size = new Size(296, 32);
            lblLocation.TabIndex = 7;
            lblLocation.Text = "📍 Pencere önü";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(143, 188, 143);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, 170, 120);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(12, 345);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(296, 42);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "✏️ Düzenle";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // lblEmptySlot
            // 
            lblEmptySlot.Font = new Font("Segoe UI", 14F);
            lblEmptySlot.ForeColor = Color.FromArgb(120, 160, 120);
            lblEmptySlot.Location = new Point(12, 120);
            lblEmptySlot.Name = "lblEmptySlot";
            lblEmptySlot.Size = new Size(296, 100);
            lblEmptySlot.TabIndex = 9;
            lblEmptySlot.Text = "🌱\r\n\r\nBu alana henüz\r\nbitki eklenmemiş";
            lblEmptySlot.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptySlot.Visible = false;
            // 
            // btnAddPlant
            // 
            btnAddPlant.BackColor = Color.FromArgb(76, 175, 80);
            btnAddPlant.Cursor = Cursors.Hand;
            btnAddPlant.FlatAppearance.BorderSize = 0;
            btnAddPlant.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 142, 60);
            btnAddPlant.FlatStyle = FlatStyle.Flat;
            btnAddPlant.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAddPlant.ForeColor = Color.White;
            btnAddPlant.Location = new Point(12, 240);
            btnAddPlant.Name = "btnAddPlant";
            btnAddPlant.Size = new Size(296, 50);
            btnAddPlant.TabIndex = 10;
            btnAddPlant.Text = "➕ Bitki Ekle";
            btnAddPlant.UseVisualStyleBackColor = false;
            btnAddPlant.Visible = false;
            btnAddPlant.Click += btnAddPlant_Click;
            // 
            // PlantSlotPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 250, 245);
            ClientSize = new Size(320, 400);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PlantSlotPopup";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Bitki Detayları";
            Deactivate += PlantSlotPopup_Deactivate;
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPlantIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox picPlantIcon;
        private System.Windows.Forms.Label lblPlantName;
        private System.Windows.Forms.Label lblPlantType;
        private System.Windows.Forms.Label lblLastWatered;
        private System.Windows.Forms.ProgressBar progressHealth;
        private System.Windows.Forms.Label lblHealthText;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblEmptySlot;
        private System.Windows.Forms.Button btnAddPlant;
    }
}
