namespace GreenGuard.Forms
{
    partial class PlantEditForm
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
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnFertilize = new DevExpress.XtraEditors.SimpleButton();
            this.btnWater = new DevExpress.XtraEditors.SimpleButton();
            this.txtNotes = new DevExpress.XtraEditors.MemoEdit();
            this.lblNotes = new DevExpress.XtraEditors.LabelControl();
            this.dateAcquired = new DevExpress.XtraEditors.DateEdit();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.cmbPlantType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblPlantType = new DevExpress.XtraEditors.LabelControl();
            this.txtLocation = new DevExpress.XtraEditors.TextEdit();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.txtNickname = new DevExpress.XtraEditors.TextEdit();
            this.lblNickname = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblImageTitle = new DevExpress.XtraEditors.LabelControl();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.panelGallery = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelectImage = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAcquired.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAcquired.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlantType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNickname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnSelectImage);
            this.panelMain.Controls.Add(this.panelGallery);
            this.panelMain.Controls.Add(this.picPreview);
            this.panelMain.Controls.Add(this.lblImageTitle);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.btnSave);
            this.panelMain.Controls.Add(this.btnFertilize);
            this.panelMain.Controls.Add(this.btnWater);
            this.panelMain.Controls.Add(this.txtNotes);
            this.panelMain.Controls.Add(this.lblNotes);
            this.panelMain.Controls.Add(this.dateAcquired);
            this.panelMain.Controls.Add(this.lblDate);
            this.panelMain.Controls.Add(this.cmbPlantType);
            this.panelMain.Controls.Add(this.lblPlantType);
            this.panelMain.Controls.Add(this.txtLocation);
            this.panelMain.Controls.Add(this.lblLocation);
            this.panelMain.Controls.Add(this.txtNickname);
            this.panelMain.Controls.Add(this.lblNickname);
            this.panelMain.Controls.Add(this.txtName);
            this.panelMain.Controls.Add(this.lblName);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(750, 600);
            this.panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(456, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🌱 Yeni Bitki Ekle";
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            // 
            // lblName
            // 
            this.lblName.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblName.Appearance.Options.UseFont = true;
            this.lblName.Location = new System.Drawing.Point(40, 65);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(58, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Bitki Adı *";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(40, 88);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Size = new System.Drawing.Size(400, 26);
            this.txtName.TabIndex = 2;
            // 
            // lblNickname
            // 
            this.lblNickname.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNickname.Appearance.Options.UseFont = true;
            this.lblNickname.Location = new System.Drawing.Point(40, 125);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(130, 19);
            this.lblNickname.TabIndex = 3;
            this.lblNickname.Text = "Takma Ad (opsiyonel)";
            // 
            // txtNickname
            // 
            this.txtNickname.Location = new System.Drawing.Point(40, 148);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNickname.Properties.Appearance.Options.UseFont = true;
            this.txtNickname.Size = new System.Drawing.Size(400, 26);
            this.txtNickname.TabIndex = 4;
            // 
            // lblLocation
            // 
            this.lblLocation.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLocation.Appearance.Options.UseFont = true;
            this.lblLocation.Location = new System.Drawing.Point(40, 185);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(156, 19);
            this.lblLocation.TabIndex = 5;
            this.lblLocation.Text = "Konum (örn: Salon, Balkon)";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(40, 208);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLocation.Properties.Appearance.Options.UseFont = true;
            this.txtLocation.Size = new System.Drawing.Size(400, 26);
            this.txtLocation.TabIndex = 6;
            // 
            // lblPlantType
            // 
            this.lblPlantType.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPlantType.Appearance.Options.UseFont = true;
            this.lblPlantType.Location = new System.Drawing.Point(40, 245);
            this.lblPlantType.Name = "lblPlantType";
            this.lblPlantType.Size = new System.Drawing.Size(67, 19);
            this.lblPlantType.TabIndex = 7;
            this.lblPlantType.Text = "Bitki Türü *";
            // 
            // cmbPlantType
            // 
            this.cmbPlantType.Location = new System.Drawing.Point(40, 268);
            this.cmbPlantType.Name = "cmbPlantType";
            this.cmbPlantType.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPlantType.Properties.Appearance.Options.UseFont = true;
            this.cmbPlantType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPlantType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPlantType.Size = new System.Drawing.Size(400, 26);
            this.cmbPlantType.TabIndex = 8;
            // 
            // lblDate
            // 
            this.lblDate.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDate.Appearance.Options.UseFont = true;
            this.lblDate.Location = new System.Drawing.Point(40, 305);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(137, 19);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "Bitkiyi Aldığınız Tarih";
            // 
            // dateAcquired
            // 
            this.dateAcquired.EditValue = null;
            this.dateAcquired.Location = new System.Drawing.Point(40, 328);
            this.dateAcquired.Name = "dateAcquired";
            this.dateAcquired.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateAcquired.Properties.Appearance.Options.UseFont = true;
            this.dateAcquired.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateAcquired.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateAcquired.Size = new System.Drawing.Size(200, 26);
            this.dateAcquired.TabIndex = 10;
            // 
            // lblNotes
            // 
            this.lblNotes.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNotes.Appearance.Options.UseFont = true;
            this.lblNotes.Location = new System.Drawing.Point(40, 365);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(36, 19);
            this.lblNotes.TabIndex = 11;
            this.lblNotes.Text = "Notlar";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(40, 388);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNotes.Properties.Appearance.Options.UseFont = true;
            this.txtNotes.Size = new System.Drawing.Size(400, 60);
            this.txtNotes.TabIndex = 12;
            // 
            // btnWater
            // 
            this.btnWater.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnWater.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnWater.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnWater.Appearance.Options.UseBackColor = true;
            this.btnWater.Appearance.Options.UseFont = true;
            this.btnWater.Appearance.Options.UseForeColor = true;
            this.btnWater.Location = new System.Drawing.Point(40, 460);
            this.btnWater.Name = "btnWater";
            this.btnWater.Size = new System.Drawing.Size(120, 35);
            this.btnWater.TabIndex = 13;
            this.btnWater.Text = "💧 Suladım";
            this.btnWater.Visible = false;
            this.btnWater.Click += new System.EventHandler(this.btnWater_Click);
            // 
            // btnFertilize
            // 
            this.btnFertilize.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            this.btnFertilize.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnFertilize.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnFertilize.Appearance.Options.UseBackColor = true;
            this.btnFertilize.Appearance.Options.UseFont = true;
            this.btnFertilize.Appearance.Options.UseForeColor = true;
            this.btnFertilize.Location = new System.Drawing.Point(170, 460);
            this.btnFertilize.Name = "btnFertilize";
            this.btnFertilize.Size = new System.Drawing.Size(130, 35);
            this.btnFertilize.TabIndex = 14;
            this.btnFertilize.Text = "🌱 Gübreledim";
            this.btnFertilize.Visible = false;
            this.btnFertilize.Click += new System.EventHandler(this.btnFertilize_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Location = new System.Drawing.Point(40, 510);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(195, 40);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(245, 510);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(195, 40);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "İptal";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblImageTitle
            // 
            this.lblImageTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblImageTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblImageTitle.Appearance.Options.UseFont = true;
            this.lblImageTitle.Appearance.Options.UseForeColor = true;
            this.lblImageTitle.Location = new System.Drawing.Point(480, 15);
            this.lblImageTitle.Name = "lblImageTitle";
            this.lblImageTitle.Size = new System.Drawing.Size(100, 20);
            this.lblImageTitle.TabIndex = 17;
            this.lblImageTitle.Text = "🖼️ Bitki Resmi";
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(75)))), ((int)(((byte)(55)))));
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(510, 45);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(200, 200);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 18;
            this.picPreview.TabStop = false;
            // 
            // panelGallery
            // 
            this.panelGallery.AutoScroll = true;
            this.panelGallery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(45)))));
            this.panelGallery.Location = new System.Drawing.Point(480, 255);
            this.panelGallery.Name = "panelGallery";
            this.panelGallery.Padding = new System.Windows.Forms.Padding(5);
            this.panelGallery.Size = new System.Drawing.Size(255, 250);
            this.panelGallery.TabIndex = 19;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSelectImage.Appearance.Options.UseFont = true;
            this.btnSelectImage.Location = new System.Drawing.Point(480, 515);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(255, 35);
            this.btnSelectImage.TabIndex = 20;
            this.btnSelectImage.Text = "📁 Kendi Resmimi Yükle...";
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // PlantEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 600);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlantEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bitki Ekle/Düzenle";
            this.Load += new System.EventHandler(this.PlantEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAcquired.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAcquired.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlantType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNickname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelMain;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl lblNickname;
        private DevExpress.XtraEditors.TextEdit txtNickname;
        private DevExpress.XtraEditors.LabelControl lblLocation;
        private DevExpress.XtraEditors.TextEdit txtLocation;
        private DevExpress.XtraEditors.LabelControl lblPlantType;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPlantType;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.DateEdit dateAcquired;
        private DevExpress.XtraEditors.LabelControl lblNotes;
        private DevExpress.XtraEditors.MemoEdit txtNotes;
        private DevExpress.XtraEditors.SimpleButton btnWater;
        private DevExpress.XtraEditors.SimpleButton btnFertilize;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lblImageTitle;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.FlowLayoutPanel panelGallery;
        private DevExpress.XtraEditors.SimpleButton btnSelectImage;
    }
}
