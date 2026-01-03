namespace GreenGuard.Forms
{
    partial class PlantNewsDetailForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.lblReadTime = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblArticleTitle = new System.Windows.Forms.Label();
            this.picArticle = new System.Windows.Forms.PictureBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.flowRelated = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRelatedTitle = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picArticle)).BeginInit();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 60);
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
            this.btnClose.Location = new System.Drawing.Point(950, 10);
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
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📰 Makale Detayı";
            // 
            // panelLeft
            // 
            this.panelLeft.AutoScroll = true;
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.txtContent);
            this.panelLeft.Controls.Add(this.lblReadTime);
            this.panelLeft.Controls.Add(this.lblCategory);
            this.panelLeft.Controls.Add(this.lblArticleTitle);
            this.panelLeft.Controls.Add(this.picArticle);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 60);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(25);
            this.panelLeft.Size = new System.Drawing.Size(700, 640);
            this.panelLeft.TabIndex = 1;
            // 
            // txtContent
            // 
            this.txtContent.BackColor = System.Drawing.Color.White;
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContent.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtContent.Location = new System.Drawing.Point(25, 280);
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(640, 340);
            this.txtContent.TabIndex = 4;
            this.txtContent.Text = "";
            // 
            // lblReadTime
            // 
            this.lblReadTime.AutoSize = true;
            this.lblReadTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReadTime.ForeColor = System.Drawing.Color.Gray;
            this.lblReadTime.Location = new System.Drawing.Point(200, 250);
            this.lblReadTime.Name = "lblReadTime";
            this.lblReadTime.Size = new System.Drawing.Size(100, 15);
            this.lblReadTime.TabIndex = 3;
            this.lblReadTime.Text = "⏱️ 3 dakika okuma";
            // 
            // lblCategory
            // 
            this.lblCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.White;
            this.lblCategory.Location = new System.Drawing.Point(25, 245);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(80, 22);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Bakım";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblArticleTitle
            // 
            this.lblArticleTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblArticleTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(40)))));
            this.lblArticleTitle.Location = new System.Drawing.Point(200, 25);
            this.lblArticleTitle.Name = "lblArticleTitle";
            this.lblArticleTitle.Size = new System.Drawing.Size(470, 70);
            this.lblArticleTitle.TabIndex = 1;
            this.lblArticleTitle.Text = "Makale Başlığı";
            // 
            // picArticle
            // 
            this.picArticle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.picArticle.Location = new System.Drawing.Point(25, 25);
            this.picArticle.Name = "picArticle";
            this.picArticle.Size = new System.Drawing.Size(160, 160);
            this.picArticle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picArticle.TabIndex = 0;
            this.picArticle.TabStop = false;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(245)))));
            this.panelRight.Controls.Add(this.flowRelated);
            this.panelRight.Controls.Add(this.lblRelatedTitle);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(700, 60);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(15);
            this.panelRight.Size = new System.Drawing.Size(300, 640);
            this.panelRight.TabIndex = 2;
            // 
            // flowRelated
            // 
            this.flowRelated.AutoScroll = true;
            this.flowRelated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowRelated.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowRelated.Location = new System.Drawing.Point(15, 50);
            this.flowRelated.Name = "flowRelated";
            this.flowRelated.Size = new System.Drawing.Size(270, 575);
            this.flowRelated.TabIndex = 1;
            this.flowRelated.WrapContents = false;
            // 
            // lblRelatedTitle
            // 
            this.lblRelatedTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRelatedTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRelatedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblRelatedTitle.Location = new System.Drawing.Point(15, 15);
            this.lblRelatedTitle.Name = "lblRelatedTitle";
            this.lblRelatedTitle.Size = new System.Drawing.Size(270, 35);
            this.lblRelatedTitle.TabIndex = 0;
            this.lblRelatedTitle.Text = "📚 Benzer İçerikler";
            // 
            // PlantNewsDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlantNewsDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Makale Detayı";
            this.Load += new System.EventHandler(this.PlantNewsDetailForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picArticle)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.PictureBox picArticle;
        private System.Windows.Forms.Label lblArticleTitle;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblReadTime;
        private System.Windows.Forms.RichTextBox txtContent;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblRelatedTitle;
        private System.Windows.Forms.FlowLayoutPanel flowRelated;
    }
}
