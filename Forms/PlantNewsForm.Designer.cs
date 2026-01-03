namespace GreenGuard.Forms
{
    partial class PlantNewsForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.flowNewsCards = new System.Windows.Forms.FlowLayoutPanel();
            this.panelFeatured = new System.Windows.Forms.Panel();
            this.lblFeaturedText = new System.Windows.Forms.Label();
            this.lblFeaturedTitle = new System.Windows.Forms.Label();
            this.picFeatured = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelFeatured.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFeatured)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 60);
            this.panelTop.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(850, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🌿 Bitki Haberleri && İpuçları";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(245)))));
            this.panelContent.Controls.Add(this.flowNewsCards);
            this.panelContent.Controls.Add(this.panelFeatured);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(900, 640);
            this.panelContent.TabIndex = 1;
            // 
            // flowNewsCards
            // 
            this.flowNewsCards.AutoScroll = true;
            this.flowNewsCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowNewsCards.Location = new System.Drawing.Point(20, 200);
            this.flowNewsCards.Name = "flowNewsCards";
            this.flowNewsCards.Padding = new System.Windows.Forms.Padding(10);
            this.flowNewsCards.Size = new System.Drawing.Size(860, 420);
            this.flowNewsCards.TabIndex = 1;
            // 
            // panelFeatured
            // 
            this.panelFeatured.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.panelFeatured.Controls.Add(this.lblFeaturedText);
            this.panelFeatured.Controls.Add(this.lblFeaturedTitle);
            this.panelFeatured.Controls.Add(this.picFeatured);
            this.panelFeatured.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFeatured.Location = new System.Drawing.Point(20, 20);
            this.panelFeatured.Name = "panelFeatured";
            this.panelFeatured.Size = new System.Drawing.Size(860, 180);
            this.panelFeatured.TabIndex = 0;
            // 
            // lblFeaturedText
            // 
            this.lblFeaturedText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFeaturedText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(50)))));
            this.lblFeaturedText.Location = new System.Drawing.Point(200, 60);
            this.lblFeaturedText.Name = "lblFeaturedText";
            this.lblFeaturedText.Size = new System.Drawing.Size(640, 100);
            this.lblFeaturedText.TabIndex = 2;
            this.lblFeaturedText.Text = "Monstera deliciosa, yapraklarındaki karakteristik deliklerle tanınır. Bu delikler" +
    ", yağmur ormanlarında rüzgar direncini azaltmak ve alt yapraklara ışık geçirmek " +
    "için evrimleşmiştir.";
            // 
            // lblFeaturedTitle
            // 
            this.lblFeaturedTitle.AutoSize = true;
            this.lblFeaturedTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFeaturedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblFeaturedTitle.Location = new System.Drawing.Point(200, 20);
            this.lblFeaturedTitle.Name = "lblFeaturedTitle";
            this.lblFeaturedTitle.Size = new System.Drawing.Size(370, 25);
            this.lblFeaturedTitle.TabIndex = 1;
            this.lblFeaturedTitle.Text = "🌟 Günün Bilgisi: Monstera Yaprakları";
            // 
            // picFeatured
            // 
            this.picFeatured.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.picFeatured.Location = new System.Drawing.Point(20, 20);
            this.picFeatured.Name = "picFeatured";
            this.picFeatured.Size = new System.Drawing.Size(150, 140);
            this.picFeatured.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFeatured.TabIndex = 0;
            this.picFeatured.TabStop = false;
            // 
            // PlantNewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlantNewsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bitki Haberleri";
            this.Load += new System.EventHandler(this.PlantNewsForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelFeatured.ResumeLayout(false);
            this.panelFeatured.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFeatured)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelFeatured;
        private System.Windows.Forms.PictureBox picFeatured;
        private System.Windows.Forms.Label lblFeaturedTitle;
        private System.Windows.Forms.Label lblFeaturedText;
        private System.Windows.Forms.FlowLayoutPanel flowNewsCards;
    }
}
