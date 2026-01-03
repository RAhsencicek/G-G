namespace GreenGuard.Forms
{
    partial class HealthAnalysisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelTop = new Panel();
            btnClose = new Button();
            btnAllPlants = new Button();
            btnSinglePlant = new Button();
            lblTitle = new Label();
            panelSinglePlant = new Panel();
            btnFertilize = new Button();
            btnWater = new Button();
            panelRecommendations = new Panel();
            lblRecommendationsTitle = new Label();
            listRecommendations = new ListBox();
            lblFertilizeInfo = new Label();
            lblWaterInfo = new Label();
            panelGauge = new Panel();
            lblHealthPercent = new Label();
            lblHealthEmoji = new Label();
            lblHealthStatus = new Label();
            lblPlantName = new Label();
            cmbPlantSelect = new ComboBox();
            lblSelectPlant = new Label();
            panelAllPlants = new Panel();
            flowCriticalPlants = new FlowLayoutPanel();
            lblCriticalTitle = new Label();
            lblHealthyCount = new Label();
            panelSummary = new Panel();
            lblCriticalCount = new Label();
            lblWarningCount = new Label();
            lblGoodCount = new Label();
            lblExcellentCount = new Label();
            lblSummaryTitle = new Label();
            panelTop.SuspendLayout();
            panelSinglePlant.SuspendLayout();
            panelRecommendations.SuspendLayout();
            panelGauge.SuspendLayout();
            panelAllPlants.SuspendLayout();
            panelSummary.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(45, 85, 65);
            panelTop.Controls.Add(btnClose);
            panelTop.Controls.Add(btnAllPlants);
            panelTop.Controls.Add(btnSinglePlant);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(600, 70);
            panelTop.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 80, 80);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(555, 8);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(35, 30);
            btnClose.TabIndex = 3;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnAllPlants
            // 
            btnAllPlants.BackColor = Color.FromArgb(55, 95, 75);
            btnAllPlants.Cursor = Cursors.Hand;
            btnAllPlants.FlatAppearance.BorderSize = 0;
            btnAllPlants.FlatStyle = FlatStyle.Flat;
            btnAllPlants.Font = new Font("Segoe UI", 10F);
            btnAllPlants.ForeColor = Color.FromArgb(180, 220, 180);
            btnAllPlants.Location = new Point(382, 12);
            btnAllPlants.Name = "btnAllPlants";
            btnAllPlants.Size = new Size(140, 52);
            btnAllPlants.TabIndex = 2;
            btnAllPlants.Text = "📊 Tüm Bitkiler";
            btnAllPlants.UseVisualStyleBackColor = false;
            btnAllPlants.Click += btnAllPlants_Click;
            // 
            // btnSinglePlant
            // 
            btnSinglePlant.BackColor = Color.FromArgb(80, 140, 100);
            btnSinglePlant.Cursor = Cursors.Hand;
            btnSinglePlant.FlatAppearance.BorderSize = 0;
            btnSinglePlant.FlatStyle = FlatStyle.Flat;
            btnSinglePlant.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSinglePlant.ForeColor = Color.White;
            btnSinglePlant.Location = new Point(226, 12);
            btnSinglePlant.Name = "btnSinglePlant";
            btnSinglePlant.Size = new Size(130, 52);
            btnSinglePlant.TabIndex = 1;
            btnSinglePlant.Text = "🌿 Tek Bitki";
            btnSinglePlant.UseVisualStyleBackColor = false;
            btnSinglePlant.Click += btnSinglePlant_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(8, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(187, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "💚 Sağlık Analizi";
            // 
            // panelSinglePlant
            // 
            panelSinglePlant.BackColor = Color.Linen;
            panelSinglePlant.Controls.Add(btnFertilize);
            panelSinglePlant.Controls.Add(btnWater);
            panelSinglePlant.Controls.Add(panelRecommendations);
            panelSinglePlant.Controls.Add(lblFertilizeInfo);
            panelSinglePlant.Controls.Add(lblWaterInfo);
            panelSinglePlant.Controls.Add(panelGauge);
            panelSinglePlant.Controls.Add(lblPlantName);
            panelSinglePlant.Controls.Add(cmbPlantSelect);
            panelSinglePlant.Controls.Add(lblSelectPlant);
            panelSinglePlant.Dock = DockStyle.Fill;
            panelSinglePlant.Location = new Point(0, 70);
            panelSinglePlant.Name = "panelSinglePlant";
            panelSinglePlant.Padding = new Padding(20);
            panelSinglePlant.Size = new Size(600, 480);
            panelSinglePlant.TabIndex = 1;
            // 
            // btnFertilize
            // 
            btnFertilize.BackColor = Color.FromArgb(139, 195, 74);
            btnFertilize.Cursor = Cursors.Hand;
            btnFertilize.FlatAppearance.BorderSize = 0;
            btnFertilize.FlatStyle = FlatStyle.Flat;
            btnFertilize.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnFertilize.ForeColor = Color.White;
            btnFertilize.Location = new Point(382, 406);
            btnFertilize.Name = "btnFertilize";
            btnFertilize.Size = new Size(130, 40);
            btnFertilize.TabIndex = 8;
            btnFertilize.Text = "🌱 Gübrele";
            btnFertilize.UseVisualStyleBackColor = false;
            btnFertilize.Click += btnFertilize_Click;
            // 
            // btnWater
            // 
            btnWater.BackColor = Color.FromArgb(33, 150, 243);
            btnWater.Cursor = Cursors.Hand;
            btnWater.FlatAppearance.BorderSize = 0;
            btnWater.FlatStyle = FlatStyle.Flat;
            btnWater.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnWater.ForeColor = Color.White;
            btnWater.Location = new Point(382, 343);
            btnWater.Name = "btnWater";
            btnWater.Size = new Size(130, 40);
            btnWater.TabIndex = 7;
            btnWater.Text = "💧 Sula";
            btnWater.UseVisualStyleBackColor = false;
            btnWater.Click += btnWater_Click;
            // 
            // panelRecommendations
            // 
            panelRecommendations.BackColor = Color.FromArgb(45, 75, 55);
            panelRecommendations.Controls.Add(lblRecommendationsTitle);
            panelRecommendations.Controls.Add(listRecommendations);
            panelRecommendations.Location = new Point(300, 100);
            panelRecommendations.Name = "panelRecommendations";
            panelRecommendations.Padding = new Padding(10);
            panelRecommendations.Size = new Size(280, 200);
            panelRecommendations.TabIndex = 6;
            // 
            // lblRecommendationsTitle
            // 
            lblRecommendationsTitle.AutoSize = true;
            lblRecommendationsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRecommendationsTitle.ForeColor = Color.White;
            lblRecommendationsTitle.Location = new Point(10, 10);
            lblRecommendationsTitle.Name = "lblRecommendationsTitle";
            lblRecommendationsTitle.Size = new Size(92, 20);
            lblRecommendationsTitle.TabIndex = 0;
            lblRecommendationsTitle.Text = "📋 Öneriler:";
            // 
            // listRecommendations
            // 
            listRecommendations.BackColor = Color.FromArgb(45, 75, 55);
            listRecommendations.BorderStyle = BorderStyle.None;
            listRecommendations.Font = new Font("Segoe UI", 9F);
            listRecommendations.ForeColor = Color.White;
            listRecommendations.FormattingEnabled = true;
            listRecommendations.Location = new Point(10, 35);
            listRecommendations.Name = "listRecommendations";
            listRecommendations.SelectionMode = SelectionMode.None;
            listRecommendations.Size = new Size(260, 150);
            listRecommendations.TabIndex = 1;
            // 
            // lblFertilizeInfo
            // 
            lblFertilizeInfo.BackColor = Color.Transparent;
            lblFertilizeInfo.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblFertilizeInfo.ForeColor = Color.FromArgb(0, 64, 0);
            lblFertilizeInfo.Location = new Point(60, 418);
            lblFertilizeInfo.Name = "lblFertilizeInfo";
            lblFertilizeInfo.Size = new Size(280, 20);
            lblFertilizeInfo.TabIndex = 5;
            lblFertilizeInfo.Text = "🌱 Gübreleme: -- gün önce";
            lblFertilizeInfo.Click += lblFertilizeInfo_Click;
            // 
            // lblWaterInfo
            // 
            lblWaterInfo.BackColor = Color.Transparent;
            lblWaterInfo.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblWaterInfo.ForeColor = Color.FromArgb(0, 64, 0);
            lblWaterInfo.Location = new Point(60, 355);
            lblWaterInfo.Name = "lblWaterInfo";
            lblWaterInfo.Size = new Size(280, 25);
            lblWaterInfo.TabIndex = 4;
            lblWaterInfo.Text = "💧 Sulama: -- gün önce";
            lblWaterInfo.Click += lblWaterInfo_Click;
            // 
            // panelGauge
            // 
            panelGauge.BackColor = Color.Transparent;
            panelGauge.Controls.Add(lblHealthPercent);
            panelGauge.Controls.Add(lblHealthEmoji);
            panelGauge.Controls.Add(lblHealthStatus);
            panelGauge.Location = new Point(60, 100);
            panelGauge.Name = "panelGauge";
            panelGauge.Size = new Size(180, 200);
            panelGauge.TabIndex = 3;
            panelGauge.Paint += panelGauge_Paint;
            // 
            // lblHealthPercent
            // 
            lblHealthPercent.BackColor = Color.Transparent;
            lblHealthPercent.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblHealthPercent.ForeColor = Color.FromArgb(100, 200, 100);
            lblHealthPercent.Location = new Point(46, 23);
            lblHealthPercent.Name = "lblHealthPercent";
            lblHealthPercent.Size = new Size(100, 50);
            lblHealthPercent.TabIndex = 0;
            lblHealthPercent.Text = "85%";
            lblHealthPercent.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHealthEmoji
            // 
            lblHealthEmoji.BackColor = Color.Transparent;
            lblHealthEmoji.Font = new Font("Segoe UI Emoji", 32F);
            lblHealthEmoji.ForeColor = Color.FromArgb(0, 64, 0);
            lblHealthEmoji.Location = new Point(0, 66);
            lblHealthEmoji.Name = "lblHealthEmoji";
            lblHealthEmoji.Size = new Size(180, 74);
            lblHealthEmoji.TabIndex = 1;
            lblHealthEmoji.Text = "😊";
            lblHealthEmoji.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHealthStatus
            // 
            lblHealthStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHealthStatus.ForeColor = Color.FromArgb(100, 200, 100);
            lblHealthStatus.Location = new Point(0, 175);
            lblHealthStatus.Name = "lblHealthStatus";
            lblHealthStatus.Size = new Size(180, 25);
            lblHealthStatus.TabIndex = 2;
            lblHealthStatus.Text = "Mükemmel";
            lblHealthStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblHealthStatus.Click += lblHealthStatus_Click;
            // 
            // lblPlantName
            // 
            lblPlantName.BackColor = Color.Transparent;
            lblPlantName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPlantName.ForeColor = Color.FromArgb(0, 64, 0);
            lblPlantName.Location = new Point(57, 66);
            lblPlantName.Name = "lblPlantName";
            lblPlantName.Size = new Size(183, 30);
            lblPlantName.TabIndex = 2;
            lblPlantName.Text = "🌿 Monstera";
            lblPlantName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbPlantSelect
            // 
            cmbPlantSelect.BackColor = Color.FromArgb(255, 255, 192);
            cmbPlantSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlantSelect.FlatStyle = FlatStyle.Flat;
            cmbPlantSelect.Font = new Font("Segoe UI", 11F);
            cmbPlantSelect.ForeColor = Color.Green;
            cmbPlantSelect.FormattingEnabled = true;
            cmbPlantSelect.Location = new Point(130, 23);
            cmbPlantSelect.Name = "cmbPlantSelect";
            cmbPlantSelect.Size = new Size(300, 28);
            cmbPlantSelect.TabIndex = 1;
            cmbPlantSelect.SelectedIndexChanged += cmbPlantSelect_SelectedIndexChanged;
            // 
            // lblSelectPlant
            // 
            lblSelectPlant.AutoSize = true;
            lblSelectPlant.Font = new Font("Segoe UI", 11F);
            lblSelectPlant.ForeColor = Color.FromArgb(0, 64, 0);
            lblSelectPlant.Location = new Point(23, 26);
            lblSelectPlant.Name = "lblSelectPlant";
            lblSelectPlant.Size = new Size(91, 20);
            lblSelectPlant.TabIndex = 0;
            lblSelectPlant.Text = "Bitki Seçiniz:";
            // 
            // panelAllPlants
            // 
            panelAllPlants.BackColor = Color.FromArgb(35, 65, 45);
            panelAllPlants.Controls.Add(flowCriticalPlants);
            panelAllPlants.Controls.Add(lblCriticalTitle);
            panelAllPlants.Controls.Add(lblHealthyCount);
            panelAllPlants.Controls.Add(panelSummary);
            panelAllPlants.Dock = DockStyle.Fill;
            panelAllPlants.Location = new Point(0, 70);
            panelAllPlants.Name = "panelAllPlants";
            panelAllPlants.Padding = new Padding(20);
            panelAllPlants.Size = new Size(600, 480);
            panelAllPlants.TabIndex = 2;
            panelAllPlants.Visible = false;
            // 
            // flowCriticalPlants
            // 
            flowCriticalPlants.AutoScroll = true;
            flowCriticalPlants.Location = new Point(23, 220);
            flowCriticalPlants.Name = "flowCriticalPlants";
            flowCriticalPlants.Padding = new Padding(5);
            flowCriticalPlants.Size = new Size(554, 180);
            flowCriticalPlants.TabIndex = 4;
            // 
            // lblCriticalTitle
            // 
            lblCriticalTitle.AutoSize = true;
            lblCriticalTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCriticalTitle.ForeColor = Color.FromArgb(255, 193, 7);
            lblCriticalTitle.Location = new Point(23, 190);
            lblCriticalTitle.Name = "lblCriticalTitle";
            lblCriticalTitle.Size = new Size(235, 21);
            lblCriticalTitle.TabIndex = 3;
            lblCriticalTitle.Text = "⚠️ Dikkat Gerektiren Bitkiler:";
            // 
            // lblHealthyCount
            // 
            lblHealthyCount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHealthyCount.ForeColor = Color.FromArgb(100, 200, 100);
            lblHealthyCount.Location = new Point(23, 420);
            lblHealthyCount.Name = "lblHealthyCount";
            lblHealthyCount.Size = new Size(554, 30);
            lblHealthyCount.TabIndex = 2;
            lblHealthyCount.Text = "✅ Sağlıklı Bitkiler: 8 adet";
            lblHealthyCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelSummary
            // 
            panelSummary.BackColor = Color.FromArgb(45, 75, 55);
            panelSummary.Controls.Add(lblCriticalCount);
            panelSummary.Controls.Add(lblWarningCount);
            panelSummary.Controls.Add(lblGoodCount);
            panelSummary.Controls.Add(lblExcellentCount);
            panelSummary.Controls.Add(lblSummaryTitle);
            panelSummary.Location = new Point(23, 23);
            panelSummary.Name = "panelSummary";
            panelSummary.Padding = new Padding(15);
            panelSummary.Size = new Size(554, 150);
            panelSummary.TabIndex = 1;
            // 
            // lblCriticalCount
            // 
            lblCriticalCount.Font = new Font("Segoe UI", 14F);
            lblCriticalCount.ForeColor = Color.FromArgb(244, 67, 54);
            lblCriticalCount.Location = new Point(280, 95);
            lblCriticalCount.Name = "lblCriticalCount";
            lblCriticalCount.Size = new Size(250, 30);
            lblCriticalCount.TabIndex = 4;
            lblCriticalCount.Text = "😱 Kritik: 1";
            // 
            // lblWarningCount
            // 
            lblWarningCount.Font = new Font("Segoe UI", 14F);
            lblWarningCount.ForeColor = Color.FromArgb(255, 193, 7);
            lblWarningCount.Location = new Point(18, 95);
            lblWarningCount.Name = "lblWarningCount";
            lblWarningCount.Size = new Size(250, 30);
            lblWarningCount.TabIndex = 3;
            lblWarningCount.Text = "😟 Dikkat: 2";
            // 
            // lblGoodCount
            // 
            lblGoodCount.Font = new Font("Segoe UI", 14F);
            lblGoodCount.ForeColor = Color.FromArgb(139, 195, 74);
            lblGoodCount.Location = new Point(280, 60);
            lblGoodCount.Name = "lblGoodCount";
            lblGoodCount.Size = new Size(250, 30);
            lblGoodCount.TabIndex = 2;
            lblGoodCount.Text = "😐 İyi: 5";
            // 
            // lblExcellentCount
            // 
            lblExcellentCount.Font = new Font("Segoe UI", 14F);
            lblExcellentCount.ForeColor = Color.FromArgb(76, 175, 80);
            lblExcellentCount.Location = new Point(18, 60);
            lblExcellentCount.Name = "lblExcellentCount";
            lblExcellentCount.Size = new Size(250, 30);
            lblExcellentCount.TabIndex = 1;
            lblExcellentCount.Text = "😊 Mükemmel: 3";
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.AutoSize = true;
            lblSummaryTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSummaryTitle.ForeColor = Color.White;
            lblSummaryTitle.Location = new Point(15, 18);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(157, 25);
            lblSummaryTitle.TabIndex = 0;
            lblSummaryTitle.Text = "📊 Genel Durum";
            // 
            // HealthAnalysisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 65, 45);
            ClientSize = new Size(600, 550);
            Controls.Add(panelSinglePlant);
            Controls.Add(panelAllPlants);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HealthAnalysisForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sağlık Analizi";
            Load += HealthAnalysisForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelSinglePlant.ResumeLayout(false);
            panelSinglePlant.PerformLayout();
            panelRecommendations.ResumeLayout(false);
            panelRecommendations.PerformLayout();
            panelGauge.ResumeLayout(false);
            panelAllPlants.ResumeLayout(false);
            panelAllPlants.PerformLayout();
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSinglePlant;
        private System.Windows.Forms.Button btnAllPlants;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelSinglePlant;
        private System.Windows.Forms.Label lblSelectPlant;
        private System.Windows.Forms.ComboBox cmbPlantSelect;
        private System.Windows.Forms.Label lblPlantName;
        private System.Windows.Forms.Panel panelGauge;
        private System.Windows.Forms.Label lblHealthPercent;
        private System.Windows.Forms.Label lblHealthEmoji;
        private System.Windows.Forms.Label lblHealthStatus;
        private System.Windows.Forms.Label lblWaterInfo;
        private System.Windows.Forms.Label lblFertilizeInfo;
        private System.Windows.Forms.Panel panelRecommendations;
        private System.Windows.Forms.Label lblRecommendationsTitle;
        private System.Windows.Forms.ListBox listRecommendations;
        private System.Windows.Forms.Button btnWater;
        private System.Windows.Forms.Button btnFertilize;
        private System.Windows.Forms.Panel panelAllPlants;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblExcellentCount;
        private System.Windows.Forms.Label lblGoodCount;
        private System.Windows.Forms.Label lblWarningCount;
        private System.Windows.Forms.Label lblCriticalCount;
        private System.Windows.Forms.Label lblHealthyCount;
        private System.Windows.Forms.Label lblCriticalTitle;
        private System.Windows.Forms.FlowLayoutPanel flowCriticalPlants;
    }
}
