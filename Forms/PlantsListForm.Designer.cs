namespace GreenGuard.Forms
{
    partial class PlantsListForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTotalPlants = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnAddPlant = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelCards = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(85)))), ((int)(((byte)(65)))));
            this.panelTop.Controls.Add(this.btnBack);
            this.panelTop.Controls.Add(this.lblTotalPlants);
            this.panelTop.Controls.Add(this.cmbSort);
            this.panelTop.Controls.Add(this.lblSort);
            this.panelTop.Controls.Add(this.cmbCategory);
            this.panelTop.Controls.Add(this.lblCategory);
            this.panelTop.Controls.Add(this.btnAddPlant);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(984, 80);
            this.panelTop.TabIndex = 0;
            // 
            // lblTotalPlants
            // 
            this.lblTotalPlants.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPlants.AutoSize = true;
            this.lblTotalPlants.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalPlants.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(200)))));
            this.lblTotalPlants.Location = new System.Drawing.Point(854, 50);
            this.lblTotalPlants.Name = "lblTotalPlants";
            this.lblTotalPlants.Size = new System.Drawing.Size(108, 19);
            this.lblTotalPlants.TabIndex = 7;
            this.lblTotalPlants.Text = "Toplam: 0 bitki";
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "İsme Göre",
            "Sağlığa Göre",
            "Sulama İhtiyacı",
            "Ekleme Tarihi"});
            this.cmbSort.Location = new System.Drawing.Point(520, 40);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(150, 25);
            this.cmbSort.TabIndex = 5;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(200)))));
            this.lblSort.Location = new System.Drawing.Point(520, 20);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(52, 15);
            this.lblSort.TabIndex = 4;
            this.lblSort.Text = "Sıralama";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Tümü",
            "İç Mekan",
            "Dış Mekan",
            "Sebze",
            "Aromatik"});
            this.cmbCategory.Location = new System.Drawing.Point(350, 40);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(150, 25);
            this.cmbCategory.TabIndex = 3;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(200)))));
            this.lblCategory.Location = new System.Drawing.Point(350, 20);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 15);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Kategori";
            // 
            // btnAddPlant
            // 
            this.btnAddPlant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPlant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(100)))));
            this.btnAddPlant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPlant.FlatAppearance.BorderSize = 0;
            this.btnAddPlant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPlant.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddPlant.ForeColor = System.Drawing.Color.White;
            this.btnAddPlant.Location = new System.Drawing.Point(834, 12);
            this.btnAddPlant.Name = "btnAddPlant";
            this.btnAddPlant.Size = new System.Drawing.Size(138, 35);
            this.btnAddPlant.TabIndex = 1;
            this.btnAddPlant.Text = "🌱 Yeni Bitki";
            this.btnAddPlant.UseVisualStyleBackColor = false;
            this.btnAddPlant.Click += new System.EventHandler(this.btnAddPlant_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(55, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(170, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🌿 Bitkilerim";
            // 
            // panelCards
            // 
            this.panelCards.AutoScroll = true;
            this.panelCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(45)))));
            this.panelCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCards.Location = new System.Drawing.Point(0, 80);
            this.panelCards.Name = "panelCards";
            this.panelCards.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelCards.Size = new System.Drawing.Size(984, 481);
            this.panelCards.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(80)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(12, 22);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 35);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "←";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // PlantsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panelCards);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "PlantsListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitkilerim - GreenGuard";
            this.Load += new System.EventHandler(this.PlantsListForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddPlant;
        private System.Windows.Forms.FlowLayoutPanel panelCards;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.Label lblTotalPlants;
        private System.Windows.Forms.Button btnBack;
    }
}
