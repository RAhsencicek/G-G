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
            btnLogout = new Button();
            btnHealthAnalysis = new Button();
            btnCalendar = new Button();
            btnAddPlant = new Button();
            btnPlants = new Button();
            btnHome = new Button();
            lblLogo = new Label();
            panelMain = new Panel();
            button4 = new Button();
            textBox1 = new TextBox();
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
            panelTopBar.SuspendLayout();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelTopBar
            // 
            panelTopBar.BackColor = Color.FromArgb(143, 188, 143);
            panelTopBar.Controls.Add(btnLogout);
            panelTopBar.Controls.Add(btnHealthAnalysis);
            panelTopBar.Controls.Add(btnCalendar);
            panelTopBar.Controls.Add(btnAddPlant);
            panelTopBar.Controls.Add(btnPlants);
            panelTopBar.Controls.Add(btnHome);
            panelTopBar.Controls.Add(lblLogo);
            panelTopBar.Dock = DockStyle.Top;
            panelTopBar.Location = new Point(0, 0);
            panelTopBar.Name = "panelTopBar";
            panelTopBar.Size = new Size(1450, 60);
            panelTopBar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.FromArgb(244, 164, 164);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F);
            btnLogout.ForeColor = Color.FromArgb(120, 50, 50);
            btnLogout.Location = new Point(1330, 12);
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
            // panelMain
            // 
            panelMain.BackColor = Color.Transparent;
            panelMain.BackgroundImage = (Image)resources.GetObject("panelMain.BackgroundImage");
            panelMain.BackgroundImageLayout = ImageLayout.Stretch;
            panelMain.Controls.Add(button4);
            panelMain.Controls.Add(textBox1);
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
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 60);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1450, 901);
            panelMain.TabIndex = 1;
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
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(255, 128, 128);
            textBox1.Location = new Point(480, 488);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(220, 23);
            textBox1.TabIndex = 2;
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
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(184, 212, 232);
            ClientSize = new Size(1450, 961);
            Controls.Add(panelMain);
            Controls.Add(panelTopBar);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GreenGuard - Dashboard";
            Load += DashboardForm_Load;
            Resize += DashboardForm_Resize;
            panelTopBar.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
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
        private TextBox textBox1;
    }
}
