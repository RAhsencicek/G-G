namespace GreenGuard.Forms
{
    partial class BigiAssistantForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BigiAssistantForm));
            panelTop = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            panelCharacter = new Panel();
            lblWelcome = new Label();
            picCharacter = new PictureBox();
            panelChat = new Panel();
            txtChat = new RichTextBox();
            panelInput = new Panel();
            btnSend = new Button();
            txtInput = new TextBox();
            panelTop.SuspendLayout();
            panelCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCharacter).BeginInit();
            panelChat.SuspendLayout();
            panelInput.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(255, 255, 192);
            panelTop.Controls.Add(btnClose);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(550, 50);
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
            btnClose.Location = new Point(505, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(35, 30);
            btnClose.TabIndex = 1;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Green;
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(182, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🌱 BİGİ - AI Asistan";
            // 
            // panelCharacter
            // 
            panelCharacter.BackColor = Color.FromArgb(255, 255, 192);
            panelCharacter.Controls.Add(picCharacter);
            panelCharacter.Controls.Add(lblWelcome);
            panelCharacter.Dock = DockStyle.Top;
            panelCharacter.Location = new Point(0, 50);
            panelCharacter.Name = "panelCharacter";
            panelCharacter.Size = new Size(550, 120);
            panelCharacter.TabIndex = 1;
            // 
            // lblWelcome
            // 
            lblWelcome.BackColor = Color.FromArgb(255, 255, 192);
            lblWelcome.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            lblWelcome.ForeColor = Color.Green;
            lblWelcome.Location = new Point(38, 15);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(298, 90);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Merhaba! Ben BİGİ, senin bitki asistanın!\r\nBitkiler hakkında her şeyi sorabilirsin.\r\nSana yardımcı olmak için buradayım! 🌱";
            // 
            // picCharacter
            // 
            picCharacter.BackgroundImage = (Image)resources.GetObject("picCharacter.BackgroundImage");
            picCharacter.BackgroundImageLayout = ImageLayout.Stretch;
            picCharacter.Location = new Point(363, 0);
            picCharacter.Name = "picCharacter";
            picCharacter.Size = new Size(119, 120);
            picCharacter.SizeMode = PictureBoxSizeMode.Zoom;
            picCharacter.TabIndex = 0;
            picCharacter.TabStop = false;
            // 
            // panelChat
            // 
            panelChat.BackColor = Color.FromArgb(0, 64, 0);
            panelChat.Controls.Add(txtChat);
            panelChat.Dock = DockStyle.Fill;
            panelChat.Location = new Point(0, 170);
            panelChat.Name = "panelChat";
            panelChat.Padding = new Padding(15);
            panelChat.Size = new Size(550, 300);
            panelChat.TabIndex = 2;
            // 
            // txtChat
            // 
            txtChat.BackColor = Color.FromArgb(0, 64, 0);
            txtChat.BorderStyle = BorderStyle.None;
            txtChat.Dock = DockStyle.Fill;
            txtChat.Font = new Font("Lucida Fax", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            txtChat.ForeColor = Color.White;
            txtChat.Location = new Point(15, 15);
            txtChat.Name = "txtChat";
            txtChat.ReadOnly = true;
            txtChat.Size = new Size(520, 270);
            txtChat.TabIndex = 0;
            txtChat.Text = "";
            // 
            // panelInput
            // 
            panelInput.BackColor = Color.FromArgb(0, 64, 0);
            panelInput.Controls.Add(btnSend);
            panelInput.Controls.Add(txtInput);
            panelInput.Dock = DockStyle.Bottom;
            panelInput.Location = new Point(0, 470);
            panelInput.Name = "panelInput";
            panelInput.Padding = new Padding(15);
            panelInput.Size = new Size(550, 70);
            panelInput.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSend.BackColor = Color.FromArgb(76, 175, 80);
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(445, 15);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(90, 35);
            btnSend.TabIndex = 1;
            btnSend.Text = "Gönder 🌱";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // txtInput
            // 
            txtInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInput.BackColor = Color.FromArgb(255, 255, 192);
            txtInput.BorderStyle = BorderStyle.FixedSingle;
            txtInput.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            txtInput.ForeColor = Color.Green;
            txtInput.Location = new Point(15, 18);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(420, 27);
            txtInput.TabIndex = 0;
            txtInput.KeyDown += txtInput_KeyDown;
            // 
            // BigiAssistantForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 65, 45);
            ClientSize = new Size(550, 540);
            Controls.Add(panelChat);
            Controls.Add(panelInput);
            Controls.Add(panelCharacter);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BigiAssistantForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "BİGİ - AI Asistan";
            Load += BigiAssistantForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCharacter).EndInit();
            panelChat.ResumeLayout(false);
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelCharacter;
        private System.Windows.Forms.PictureBox picCharacter;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.RichTextBox txtChat;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
    }
}
