namespace GreenGuard.Forms
{
    partial class RemindersDetailForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNote = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.flowLayoutReminders = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUrgentHeader = new System.Windows.Forms.Label();
            this.lblUpcomingHeader = new System.Windows.Forms.Label();
            this.lblNotesHeader = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(143, 188, 143);
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Controls.Add(this.btnAddNote);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(450, 50);
            this.panelHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(244, 164, 164);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(410, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNote
            // 
            this.btnAddNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNote.BackColor = System.Drawing.Color.FromArgb(172, 225, 175);
            this.btnAddNote.FlatAppearance.BorderSize = 0;
            this.btnAddNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNote.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAddNote.ForeColor = System.Drawing.Color.FromArgb(53, 94, 59);
            this.btnAddNote.Location = new System.Drawing.Point(370, 10);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(30, 30);
            this.btnAddNote.TabIndex = 1;
            this.btnAddNote.Text = "+";
            this.btnAddNote.UseVisualStyleBackColor = false;
            this.btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(53, 94, 59);
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 Hatırlatmalar & Yapılacaklar";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(245, 255, 250);
            this.panelContent.Controls.Add(this.flowLayoutReminders);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 50);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(10);
            this.panelContent.Size = new System.Drawing.Size(450, 450);
            this.panelContent.TabIndex = 1;
            // 
            // flowLayoutReminders
            // 
            this.flowLayoutReminders.AutoScroll = true;
            this.flowLayoutReminders.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutReminders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutReminders.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutReminders.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutReminders.Name = "flowLayoutReminders";
            this.flowLayoutReminders.Size = new System.Drawing.Size(430, 430);
            this.flowLayoutReminders.TabIndex = 0;
            this.flowLayoutReminders.WrapContents = false;
            // 
            // lblUrgentHeader
            // 
            this.lblUrgentHeader.AutoSize = true;
            this.lblUrgentHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUrgentHeader.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.lblUrgentHeader.Location = new System.Drawing.Point(0, 0);
            this.lblUrgentHeader.Name = "lblUrgentHeader";
            this.lblUrgentHeader.Size = new System.Drawing.Size(180, 19);
            this.lblUrgentHeader.TabIndex = 0;
            this.lblUrgentHeader.Text = "🔴 ACİL (Bugün / Gecikmiş)";
            // 
            // lblUpcomingHeader
            // 
            this.lblUpcomingHeader.AutoSize = true;
            this.lblUpcomingHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUpcomingHeader.ForeColor = System.Drawing.Color.FromArgb(180, 140, 20);
            this.lblUpcomingHeader.Location = new System.Drawing.Point(0, 0);
            this.lblUpcomingHeader.Name = "lblUpcomingHeader";
            this.lblUpcomingHeader.Size = new System.Drawing.Size(140, 19);
            this.lblUpcomingHeader.TabIndex = 0;
            this.lblUpcomingHeader.Text = "🟡 YAKIN (1-3 gün)";
            // 
            // lblNotesHeader
            // 
            this.lblNotesHeader.AutoSize = true;
            this.lblNotesHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNotesHeader.ForeColor = System.Drawing.Color.FromArgb(50, 100, 150);
            this.lblNotesHeader.Location = new System.Drawing.Point(0, 0);
            this.lblNotesHeader.Name = "lblNotesHeader";
            this.lblNotesHeader.Size = new System.Drawing.Size(120, 19);
            this.lblNotesHeader.TabIndex = 0;
            this.lblNotesHeader.Text = "📝 KİŞİSEL NOTLAR";
            // 
            // RemindersDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 255, 250);
            this.ClientSize = new System.Drawing.Size(450, 500);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RemindersDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hatırlatmalar";
            this.Load += new System.EventHandler(this.RemindersDetailForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddNote;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutReminders;
        private System.Windows.Forms.Label lblUrgentHeader;
        private System.Windows.Forms.Label lblUpcomingHeader;
        private System.Windows.Forms.Label lblNotesHeader;
    }
}
