namespace GreenGuard.Forms
{
    partial class CareCalendarForm
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
            btnPruning = new Button();
            btnFertilizing = new Button();
            btnWatering = new Button();
            lblTitle = new Label();
            panelCalendar = new Panel();
            btnNextMonth = new Button();
            btnPrevMonth = new Button();
            lblMonth = new Label();
            panelDays = new Panel();
            panelTimeline = new Panel();
            flowTimeline = new FlowLayoutPanel();
            lblTimelineTitle = new Label();
            panelTop.SuspendLayout();
            panelCalendar.SuspendLayout();
            panelTimeline.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(45, 85, 65);
            panelTop.Controls.Add(btnClose);
            panelTop.Controls.Add(btnPruning);
            panelTop.Controls.Add(btnFertilizing);
            panelTop.Controls.Add(btnWatering);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(700, 60);
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
            btnClose.Location = new Point(655, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(35, 30);
            btnClose.TabIndex = 4;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnPruning
            // 
            btnPruning.BackColor = Color.FromArgb(255, 255, 192);
            btnPruning.Cursor = Cursors.Hand;
            btnPruning.FlatAppearance.BorderSize = 0;
            btnPruning.FlatStyle = FlatStyle.Flat;
            btnPruning.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnPruning.ForeColor = Color.Green;
            btnPruning.Location = new Point(480, 1);
            btnPruning.Name = "btnPruning";
            btnPruning.Size = new Size(80, 44);
            btnPruning.TabIndex = 3;
            btnPruning.Text = "✂️";
            btnPruning.UseVisualStyleBackColor = false;
            btnPruning.Click += btnPruning_Click;
            // 
            // btnFertilizing
            // 
            btnFertilizing.BackColor = Color.FromArgb(255, 255, 192);
            btnFertilizing.Cursor = Cursors.Hand;
            btnFertilizing.FlatAppearance.BorderSize = 0;
            btnFertilizing.FlatStyle = FlatStyle.Flat;
            btnFertilizing.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnFertilizing.ForeColor = Color.Green;
            btnFertilizing.Location = new Point(380, -1);
            btnFertilizing.Name = "btnFertilizing";
            btnFertilizing.Size = new Size(80, 46);
            btnFertilizing.TabIndex = 2;
            btnFertilizing.Text = "🌱";
            btnFertilizing.UseVisualStyleBackColor = false;
            btnFertilizing.Click += btnFertilizing_Click;
            // 
            // btnWatering
            // 
            btnWatering.BackColor = Color.FromArgb(255, 255, 192);
            btnWatering.Cursor = Cursors.Hand;
            btnWatering.FlatAppearance.BorderSize = 0;
            btnWatering.FlatStyle = FlatStyle.Flat;
            btnWatering.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnWatering.ForeColor = Color.Green;
            btnWatering.Location = new Point(280, -1);
            btnWatering.Name = "btnWatering";
            btnWatering.Size = new Size(80, 46);
            btnWatering.TabIndex = 1;
            btnWatering.Text = "💧";
            btnWatering.UseVisualStyleBackColor = false;
            btnWatering.Click += btnWatering_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(198, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📅 Bakım Takvimi";
            // 
            // panelCalendar
            // 
            panelCalendar.BackColor = Color.FromArgb(45, 85, 65);
            panelCalendar.Controls.Add(btnNextMonth);
            panelCalendar.Controls.Add(btnPrevMonth);
            panelCalendar.Controls.Add(lblMonth);
            panelCalendar.Controls.Add(panelDays);
            panelCalendar.Dock = DockStyle.Top;
            panelCalendar.Location = new Point(0, 60);
            panelCalendar.Name = "panelCalendar";
            panelCalendar.Padding = new Padding(15);
            panelCalendar.Size = new Size(700, 260);
            panelCalendar.TabIndex = 1;
            // 
            // btnNextMonth
            // 
            btnNextMonth.BackColor = Color.Transparent;
            btnNextMonth.Cursor = Cursors.Hand;
            btnNextMonth.FlatAppearance.BorderSize = 0;
            btnNextMonth.FlatStyle = FlatStyle.Flat;
            btnNextMonth.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnNextMonth.ForeColor = Color.IndianRed;
            btnNextMonth.Location = new Point(420, 10);
            btnNextMonth.Name = "btnNextMonth";
            btnNextMonth.Size = new Size(40, 35);
            btnNextMonth.TabIndex = 2;
            btnNextMonth.Text = "▶";
            btnNextMonth.UseVisualStyleBackColor = false;
            btnNextMonth.Click += btnNextMonth_Click;
            // 
            // btnPrevMonth
            // 
            btnPrevMonth.BackColor = Color.Transparent;
            btnPrevMonth.Cursor = Cursors.Hand;
            btnPrevMonth.FlatAppearance.BorderSize = 0;
            btnPrevMonth.FlatStyle = FlatStyle.Flat;
            btnPrevMonth.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnPrevMonth.ForeColor = Color.IndianRed;
            btnPrevMonth.Location = new Point(240, 10);
            btnPrevMonth.Name = "btnPrevMonth";
            btnPrevMonth.Size = new Size(40, 35);
            btnPrevMonth.TabIndex = 1;
            btnPrevMonth.Text = "◀";
            btnPrevMonth.UseVisualStyleBackColor = false;
            btnPrevMonth.Click += btnPrevMonth_Click;
            // 
            // lblMonth
            // 
            lblMonth.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblMonth.ForeColor = Color.FromArgb(255, 255, 192);
            lblMonth.Location = new Point(280, 15);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(140, 30);
            lblMonth.TabIndex = 0;
            lblMonth.Text = "Aralık 2025";
            lblMonth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelDays
            // 
            panelDays.BackColor = Color.FromArgb(45, 85, 65);
            panelDays.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            panelDays.ForeColor = Color.FromArgb(255, 255, 192);
            panelDays.Location = new Point(12, 55);
            panelDays.Name = "panelDays";
            panelDays.Size = new Size(670, 190);
            panelDays.TabIndex = 3;
            panelDays.Paint += panelDays_Paint;
            panelDays.MouseClick += panelDays_MouseClick;
            // 
            // panelTimeline
            // 
            panelTimeline.BackColor = Color.FromArgb(255, 255, 192);
            panelTimeline.Controls.Add(flowTimeline);
            panelTimeline.Controls.Add(lblTimelineTitle);
            panelTimeline.Dock = DockStyle.Fill;
            panelTimeline.Location = new Point(0, 320);
            panelTimeline.Name = "panelTimeline";
            panelTimeline.Padding = new Padding(15);
            panelTimeline.Size = new Size(700, 280);
            panelTimeline.TabIndex = 2;
            // 
            // flowTimeline
            // 
            flowTimeline.AutoScroll = true;
            flowTimeline.BackColor = Color.FromArgb(255, 255, 192);
            flowTimeline.Dock = DockStyle.Fill;
            flowTimeline.FlowDirection = FlowDirection.TopDown;
            flowTimeline.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            flowTimeline.ForeColor = Color.FromArgb(64, 0, 64);
            flowTimeline.Location = new Point(15, 50);
            flowTimeline.Name = "flowTimeline";
            flowTimeline.Padding = new Padding(5);
            flowTimeline.Size = new Size(670, 215);
            flowTimeline.TabIndex = 1;
            flowTimeline.WrapContents = false;
            flowTimeline.Paint += flowTimeline_Paint;
            // 
            // lblTimelineTitle
            // 
            lblTimelineTitle.BackColor = Color.FromArgb(255, 255, 192);
            lblTimelineTitle.Dock = DockStyle.Top;
            lblTimelineTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTimelineTitle.ForeColor = Color.FromArgb(45, 85, 65);
            lblTimelineTitle.Location = new Point(15, 15);
            lblTimelineTitle.Name = "lblTimelineTitle";
            lblTimelineTitle.Size = new Size(670, 35);
            lblTimelineTitle.TabIndex = 0;
            lblTimelineTitle.Text = "📋 Yaklaşan Bakımlar";
            lblTimelineTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTimelineTitle.Click += lblTimelineTitle_Click;
            // 
            // CareCalendarForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 65, 45);
            ClientSize = new Size(700, 600);
            Controls.Add(panelTimeline);
            Controls.Add(panelCalendar);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CareCalendarForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bakım Takvimi";
            Load += CareCalendarForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelCalendar.ResumeLayout(false);
            panelTimeline.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnWatering;
        private System.Windows.Forms.Button btnFertilizing;
        private System.Windows.Forms.Button btnPruning;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelCalendar;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Button btnPrevMonth;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Panel panelDays;
        private System.Windows.Forms.Panel panelTimeline;
        private System.Windows.Forms.Label lblTimelineTitle;
        private System.Windows.Forms.FlowLayoutPanel flowTimeline;
    }
}
