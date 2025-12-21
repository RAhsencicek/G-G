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
            this.panelMain = new System.Windows.Forms.Panel();
            this.picPlantIcon = new System.Windows.Forms.PictureBox();
            this.lblPlantName = new System.Windows.Forms.Label();
            this.lblPlantType = new System.Windows.Forms.Label();
            this.lblLastWatered = new System.Windows.Forms.Label();
            this.progressHealth = new System.Windows.Forms.ProgressBar();
            this.lblHealthText = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblEmptySlot = new System.Windows.Forms.Label();
            this.btnAddPlant = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlantIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain - Ana kart
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(245, 250, 245);
            this.panelMain.Controls.Add(this.btnClose);
            this.panelMain.Controls.Add(this.picPlantIcon);
            this.panelMain.Controls.Add(this.lblPlantName);
            this.panelMain.Controls.Add(this.lblPlantType);
            this.panelMain.Controls.Add(this.lblLastWatered);
            this.panelMain.Controls.Add(this.progressHealth);
            this.panelMain.Controls.Add(this.lblHealthText);
            this.panelMain.Controls.Add(this.lblLocation);
            this.panelMain.Controls.Add(this.btnEdit);
            this.panelMain.Controls.Add(this.lblEmptySlot);
            this.panelMain.Controls.Add(this.btnAddPlant);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(12);
            this.panelMain.Size = new System.Drawing.Size(320, 400);
            this.panelMain.TabIndex = 0;
            // 
            // btnClose - Kapat X
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 200, 200);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.btnClose.Location = new System.Drawing.Point(275, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "×";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picPlantIcon - Pixel art ikon
            // 
            this.picPlantIcon.BackColor = System.Drawing.Color.FromArgb(230, 245, 230);
            this.picPlantIcon.Location = new System.Drawing.Point(110, 20);
            this.picPlantIcon.Name = "picPlantIcon";
            this.picPlantIcon.Size = new System.Drawing.Size(100, 100);
            this.picPlantIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlantIcon.TabIndex = 1;
            this.picPlantIcon.TabStop = false;
            // 
            // lblPlantName
            // 
            this.lblPlantName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblPlantName.ForeColor = System.Drawing.Color.FromArgb(53, 94, 59);
            this.lblPlantName.Location = new System.Drawing.Point(12, 130);
            this.lblPlantName.Name = "lblPlantName";
            this.lblPlantName.Size = new System.Drawing.Size(296, 35);
            this.lblPlantName.TabIndex = 2;
            this.lblPlantName.Text = "Bitki Adı";
            this.lblPlantName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlantType
            // 
            this.lblPlantType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPlantType.ForeColor = System.Drawing.Color.FromArgb(100, 140, 100);
            this.lblPlantType.Location = new System.Drawing.Point(12, 165);
            this.lblPlantType.Name = "lblPlantType";
            this.lblPlantType.Size = new System.Drawing.Size(296, 22);
            this.lblPlantType.TabIndex = 3;
            this.lblPlantType.Text = "🏷️ Tür: Sukulent";
            this.lblPlantType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastWatered
            // 
            this.lblLastWatered.BackColor = System.Drawing.Color.FromArgb(220, 240, 220);
            this.lblLastWatered.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLastWatered.ForeColor = System.Drawing.Color.FromArgb(53, 94, 59);
            this.lblLastWatered.Location = new System.Drawing.Point(12, 200);
            this.lblLastWatered.Name = "lblLastWatered";
            this.lblLastWatered.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.lblLastWatered.Size = new System.Drawing.Size(296, 32);
            this.lblLastWatered.TabIndex = 4;
            this.lblLastWatered.Text = "💧 Son Sulama: 2 gün önce";
            // 
            // progressHealth - Sağlık bar
            // 
            this.progressHealth.Location = new System.Drawing.Point(12, 270);
            this.progressHealth.Maximum = 100;
            this.progressHealth.Name = "progressHealth";
            this.progressHealth.Size = new System.Drawing.Size(296, 20);
            this.progressHealth.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressHealth.TabIndex = 5;
            this.progressHealth.Value = 85;
            // 
            // lblHealthText
            // 
            this.lblHealthText.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHealthText.ForeColor = System.Drawing.Color.FromArgb(53, 94, 59);
            this.lblHealthText.Location = new System.Drawing.Point(12, 245);
            this.lblHealthText.Name = "lblHealthText";
            this.lblHealthText.Size = new System.Drawing.Size(296, 22);
            this.lblHealthText.TabIndex = 6;
            this.lblHealthText.Text = "❤️ Sağlık: 85/100";
            // 
            // lblLocation
            // 
            this.lblLocation.BackColor = System.Drawing.Color.FromArgb(220, 240, 220);
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(53, 94, 59);
            this.lblLocation.Location = new System.Drawing.Point(12, 300);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.lblLocation.Size = new System.Drawing.Size(296, 32);
            this.lblLocation.TabIndex = 7;
            this.lblLocation.Text = "📍 Pencere önü";
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(143, 188, 143);
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(120, 170, 120);
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(12, 345);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(296, 42);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "✏️ Düzenle";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblEmptySlot
            // 
            this.lblEmptySlot.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblEmptySlot.ForeColor = System.Drawing.Color.FromArgb(120, 160, 120);
            this.lblEmptySlot.Location = new System.Drawing.Point(12, 120);
            this.lblEmptySlot.Name = "lblEmptySlot";
            this.lblEmptySlot.Size = new System.Drawing.Size(296, 100);
            this.lblEmptySlot.TabIndex = 9;
            this.lblEmptySlot.Text = "🌱\r\n\r\nBu alana henüz\r\nbitki eklenmemiş";
            this.lblEmptySlot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmptySlot.Visible = false;
            // 
            // btnAddPlant
            // 
            this.btnAddPlant.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAddPlant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPlant.FlatAppearance.BorderSize = 0;
            this.btnAddPlant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(56, 142, 60);
            this.btnAddPlant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPlant.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddPlant.ForeColor = System.Drawing.Color.White;
            this.btnAddPlant.Location = new System.Drawing.Point(12, 240);
            this.btnAddPlant.Name = "btnAddPlant";
            this.btnAddPlant.Size = new System.Drawing.Size(296, 50);
            this.btnAddPlant.TabIndex = 10;
            this.btnAddPlant.Text = "➕ Bitki Ekle";
            this.btnAddPlant.UseVisualStyleBackColor = false;
            this.btnAddPlant.Visible = false;
            this.btnAddPlant.Click += new System.EventHandler(this.btnAddPlant_Click);
            // 
            // PlantSlotPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 250, 245);
            this.ClientSize = new System.Drawing.Size(320, 400);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlantSlotPopup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Bitki Detayları";
            this.Deactivate += new System.EventHandler(this.PlantSlotPopup_Deactivate);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPlantIcon)).EndInit();
            this.ResumeLayout(false);
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
