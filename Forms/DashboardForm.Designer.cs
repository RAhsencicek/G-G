namespace GreenGuard.Forms
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            panelTopBar = new Panel();
            label3 = new Label();
            button15 = new Button();
            btnLogout = new Button();
            btnHealthAnalysis = new Button();
            btnCalendar = new Button();
            btnAddPlant = new Button();
            btnPlants = new Button();
            button16 = new Button();
            btnHome = new Button();
            lblLogo = new Label();
            pictureBox3 = new PictureBox();
            panelMain = new Panel();
            label2 = new Label();
            button17 = new Button();
            label1 = new Label();
            btnRefresh = new Button();
            checkedListBox1 = new CheckedListBox();
            picWateringCan = new PictureBox();
            button4 = new Button();
            button14 = new Button();
            button13 = new Button();
            button12 = new Button();
            button11 = new Button();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panelTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picWateringCan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panelTopBar
            // 
            panelTopBar.BackColor = Color.FromArgb(143, 188, 143);
            panelTopBar.Controls.Add(label3);
            panelTopBar.Controls.Add(button15);
            panelTopBar.Controls.Add(btnLogout);
            panelTopBar.Controls.Add(btnRefresh);
            panelTopBar.Controls.Add(btnHealthAnalysis);
            panelTopBar.Controls.Add(btnCalendar);
            panelTopBar.Controls.Add(btnAddPlant);
            panelTopBar.Controls.Add(btnPlants);
            panelTopBar.Controls.Add(button16);
            panelTopBar.Controls.Add(btnHome);
            panelTopBar.Controls.Add(lblLogo);
            panelTopBar.Controls.Add(pictureBox3);
            panelTopBar.Dock = DockStyle.Top;
            panelTopBar.Location = new Point(0, 0);
            panelTopBar.Name = "panelTopBar";
            panelTopBar.Size = new Size(1450, 60);
            panelTopBar.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Microsoft JhengHei", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Green;
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.ImageAlign = ContentAlignment.BottomCenter;
            label3.Location = new Point(948, 12);
            label3.Name = "label3";
            label3.Size = new Size(86, 19);
            label3.TabIndex = 29;
            label3.Text = "BİGİ'ye sor";
            // 
            // button15
            // 
            button15.Location = new Point(800, 131);
            button15.Name = "button15";
            button15.Size = new Size(75, 23);
            button15.TabIndex = 7;
            button15.Text = "button15";
            button15.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.FromArgb(244, 164, 164);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F);
            btnLogout.ForeColor = Color.FromArgb(120, 50, 50);
            btnLogout.Location = new Point(1206, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(105, 36);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "🚪 Çıkış";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnHealthAnalysis
            // 
            btnHealthAnalysis.BackColor = Color.FromArgb(172, 225, 175);
            btnHealthAnalysis.FlatAppearance.BorderSize = 0;
            btnHealthAnalysis.FlatStyle = FlatStyle.Flat;
            btnHealthAnalysis.Font = new Font("Segoe UI", 10F);
            btnHealthAnalysis.ForeColor = Color.FromArgb(53, 94, 59);
            btnHealthAnalysis.Location = new Point(710, 12);
            btnHealthAnalysis.Name = "btnHealthAnalysis";
            btnHealthAnalysis.Size = new Size(110, 36);
            btnHealthAnalysis.TabIndex = 5;
            btnHealthAnalysis.Text = "📊 Analiz";
            btnHealthAnalysis.UseVisualStyleBackColor = false;
            btnHealthAnalysis.Click += btnHealthAnalysis_Click;
            // 
            // btnCalendar
            // 
            btnCalendar.BackColor = Color.FromArgb(172, 225, 175);
            btnCalendar.FlatAppearance.BorderSize = 0;
            btnCalendar.FlatStyle = FlatStyle.Flat;
            btnCalendar.Font = new Font("Segoe UI", 10F);
            btnCalendar.ForeColor = Color.FromArgb(53, 94, 59);
            btnCalendar.Location = new Point(590, 12);
            btnCalendar.Name = "btnCalendar";
            btnCalendar.Size = new Size(110, 36);
            btnCalendar.TabIndex = 4;
            btnCalendar.Text = "📅 Takvim";
            btnCalendar.UseVisualStyleBackColor = false;
            btnCalendar.Click += btnCalendar_Click;
            // 
            // btnAddPlant
            // 
            btnAddPlant.BackColor = Color.FromArgb(172, 225, 175);
            btnAddPlant.FlatAppearance.BorderSize = 0;
            btnAddPlant.FlatStyle = FlatStyle.Flat;
            btnAddPlant.Font = new Font("Segoe UI", 10F);
            btnAddPlant.ForeColor = Color.FromArgb(53, 94, 59);
            btnAddPlant.Location = new Point(470, 12);
            btnAddPlant.Name = "btnAddPlant";
            btnAddPlant.Size = new Size(110, 36);
            btnAddPlant.TabIndex = 3;
            btnAddPlant.Text = "➕ Bitki Ekle";
            btnAddPlant.UseVisualStyleBackColor = false;
            btnAddPlant.Click += btnAddPlant_Click;
            // 
            // btnPlants
            // 
            btnPlants.BackColor = Color.FromArgb(172, 225, 175);
            btnPlants.FlatAppearance.BorderSize = 0;
            btnPlants.FlatStyle = FlatStyle.Flat;
            btnPlants.Font = new Font("Segoe UI", 10F);
            btnPlants.ForeColor = Color.FromArgb(53, 94, 59);
            btnPlants.Location = new Point(350, 12);
            btnPlants.Name = "btnPlants";
            btnPlants.Size = new Size(110, 36);
            btnPlants.TabIndex = 2;
            btnPlants.Text = "🌿 Bitkilerim";
            btnPlants.UseVisualStyleBackColor = false;
            btnPlants.Click += btnPlants_Click;
            // 
            // button16
            // 
            button16.BackColor = Color.Transparent;
            button16.BackgroundImage = (Image)resources.GetObject("button16.BackgroundImage");
            button16.BackgroundImageLayout = ImageLayout.Stretch;
            button16.ForeColor = Color.DeepPink;
            button16.Location = new Point(865, 0);
            button16.Name = "button16";
            button16.Size = new Size(65, 60);
            button16.TabIndex = 8;
            button16.UseVisualStyleBackColor = false;
            button16.Click += button16_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(172, 225, 175);
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 10F);
            btnHome.ForeColor = Color.FromArgb(53, 94, 59);
            btnHome.Location = new Point(230, 12);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(110, 36);
            btnHome.TabIndex = 1;
            btnHome.Text = "🏠 Ana Sayfa";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // lblLogo
            // 
            lblLogo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(53, 94, 59);
            lblLogo.Location = new Point(15, 12);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(200, 38);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "🌱 GreenGuard";
            lblLogo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(936, 6);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(112, 48);
            pictureBox3.TabIndex = 29;
            pictureBox3.TabStop = false;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.Transparent;
            panelMain.BackgroundImage = (Image)resources.GetObject("panelMain.BackgroundImage");
            panelMain.BackgroundImageLayout = ImageLayout.Stretch;
            panelMain.Controls.Add(label2);
            panelMain.Controls.Add(button17);
            panelMain.Controls.Add(label1);
            panelMain.Controls.Add(checkedListBox1);
            panelMain.Controls.Add(picWateringCan);
            panelMain.Controls.Add(button4);
            panelMain.Controls.Add(button14);
            panelMain.Controls.Add(button13);
            panelMain.Controls.Add(button12);
            panelMain.Controls.Add(button11);
            panelMain.Controls.Add(button10);
            panelMain.Controls.Add(button9);
            panelMain.Controls.Add(button8);
            panelMain.Controls.Add(button7);
            panelMain.Controls.Add(button6);
            panelMain.Controls.Add(button5);
            panelMain.Controls.Add(button3);
            panelMain.Controls.Add(button2);
            panelMain.Controls.Add(button1);
            panelMain.Controls.Add(pictureBox1);
            panelMain.Controls.Add(pictureBox2);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 60);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1450, 901);
            panelMain.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Ink Free", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.ImageAlign = ContentAlignment.BottomCenter;
            label2.Location = new Point(948, 407);
            label2.Name = "label2";
            label2.Size = new Size(192, 69);
            label2.TabIndex = 27;
            label2.Text = "bitkiler dünyasından \r\n    yeni haberler\r\n      alabilirsin\r\n";
            // 
            // button17
            // 
            button17.BackColor = Color.Transparent;
            button17.ForeColor = Color.DarkCyan;
            button17.Location = new Point(976, 488);
            button17.Name = "button17";
            button17.Size = new Size(130, 28);
            button17.TabIndex = 28;
            button17.Text = "Daha fazlası için tıkla";
            button17.UseVisualStyleBackColor = false;
            button17.Click += button17_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Ink Free", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.ImageAlign = ContentAlignment.BottomCenter;
            label1.Location = new Point(976, 368);
            label1.Name = "label1";
            label1.Size = new Size(130, 23);
            label1.TabIndex = 21;
            label1.Text = "Selam naber! ";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(76, 175, 80);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 12F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1137, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(63, 36);
            btnRefresh.TabIndex = 30;
            btnRefresh.Text = "🔄 Yenile";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = Color.DarkSeaGreen;
            checkedListBox1.BorderStyle = BorderStyle.None;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(24, 585);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(164, 162);
            checkedListBox1.TabIndex = 25;
            // 
            // picWateringCan
            // 
            picWateringCan.BackColor = Color.Transparent;
            picWateringCan.BackgroundImage = (Image)resources.GetObject("picWateringCan.BackgroundImage");
            picWateringCan.BackgroundImageLayout = ImageLayout.Stretch;
            picWateringCan.Cursor = Cursors.Hand;
            picWateringCan.Location = new Point(253, 798);
            picWateringCan.Name = "picWateringCan";
            picWateringCan.Size = new Size(140, 100);
            picWateringCan.SizeMode = PictureBoxSizeMode.Zoom;
            picWateringCan.TabIndex = 20;
            picWateringCan.TabStop = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.ForeColor = Color.FromArgb(192, 255, 192);
            button4.Location = new Point(305, 82);
            button4.Name = "button4";
            button4.Size = new Size(48, 91);
            button4.TabIndex = 4;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            button14.ForeColor = Color.FromArgb(192, 255, 192);
            button14.Location = new Point(688, 669);
            button14.Name = "button14";
            button14.Size = new Size(132, 127);
            button14.TabIndex = 2;
            button14.Text = "button14";
            button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            button13.ForeColor = Color.FromArgb(192, 255, 192);
            button13.Location = new Point(1319, 742);
            button13.Name = "button13";
            button13.Size = new Size(116, 112);
            button13.TabIndex = 2;
            button13.Text = "button13";
            button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            button12.ForeColor = Color.FromArgb(192, 255, 192);
            button12.Location = new Point(1176, 488);
            button12.Name = "button12";
            button12.Size = new Size(74, 171);
            button12.TabIndex = 2;
            button12.Text = "button12";
            button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.ForeColor = Color.FromArgb(192, 255, 192);
            button11.Location = new Point(1256, 610);
            button11.Name = "button11";
            button11.Size = new Size(149, 49);
            button11.TabIndex = 2;
            button11.Text = "button11";
            button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.ForeColor = Color.FromArgb(192, 255, 192);
            button10.Location = new Point(1330, 116);
            button10.Name = "button10";
            button10.Size = new Size(65, 167);
            button10.TabIndex = 2;
            button10.Text = "button10";
            button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.ForeColor = Color.FromArgb(192, 255, 192);
            button9.Location = new Point(1227, 144);
            button9.Name = "button9";
            button9.Size = new Size(75, 139);
            button9.TabIndex = 2;
            button9.Text = "button9";
            button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.ForeColor = Color.FromArgb(192, 255, 192);
            button8.Location = new Point(1330, 328);
            button8.Name = "button8";
            button8.Size = new Size(75, 148);
            button8.TabIndex = 2;
            button8.Text = "button8";
            button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.ForeColor = Color.FromArgb(192, 255, 192);
            button7.Location = new Point(1206, 340);
            button7.Name = "button7";
            button7.Size = new Size(62, 136);
            button7.TabIndex = 7;
            button7.Text = "button7";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.ForeColor = Color.FromArgb(192, 255, 192);
            button6.Location = new Point(1052, 786);
            button6.Name = "button6";
            button6.Size = new Size(123, 115);
            button6.TabIndex = 6;
            button6.Text = "button6";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.ForeColor = Color.FromArgb(192, 255, 192);
            button5.Location = new Point(509, 669);
            button5.Name = "button5";
            button5.Size = new Size(110, 115);
            button5.TabIndex = 5;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.ForeColor = Color.FromArgb(192, 255, 192);
            button3.Location = new Point(215, 40);
            button3.Name = "button3";
            button3.Size = new Size(49, 133);
            button3.TabIndex = 3;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.ForeColor = Color.FromArgb(192, 255, 192);
            button2.Location = new Point(130, 766);
            button2.Name = "button2";
            button2.Size = new Size(105, 123);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.ForeColor = Color.FromArgb(192, 255, 192);
            button1.Location = new Point(253, 488);
            button1.Name = "button1";
            button1.Size = new Size(152, 162);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(916, 351);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(254, 247);
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Location = new Point(15, 549);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(184, 211);
            pictureBox2.TabIndex = 26;
            pictureBox2.TabStop = false;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(184, 212, 232);
            ClientSize = new Size(1450, 961);
            Controls.Add(panelMain);
            Controls.Add(panelTopBar);
            DoubleBuffered = true;
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GreenGuard - Dashboard";
            Load += DashboardForm_Load;
            Resize += DashboardForm_Resize;
            panelTopBar.ResumeLayout(false);
            panelTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picWateringCan).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnPlants;
        private System.Windows.Forms.Button btnAddPlant;
        private System.Windows.Forms.Button btnCalendar;
        private System.Windows.Forms.Button btnHealthAnalysis;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelMain;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button14;
        private Button button13;
        private Button button12;
        private Button button11;
        private Button button10;
        private Button button9;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private PictureBox picWateringCan;
        private PictureBox pictureBox1;
        private CheckedListBox checkedListBox1;
        private PictureBox pictureBox2;
        private Button button16;
        private Button button15;
        private Button button17;
        private Label label2;
        private Label label1;
        private Label label3;
        private PictureBox pictureBox3;
        private Button btnRefresh;
    }
}
