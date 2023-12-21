namespace GUI.Views
{
    partial class LoadingForm
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
            components = new System.ComponentModel.Container();
            LoadingProgressBar = new CircularProgressBar.CircularProgressBar();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // LoadingProgressBar
            // 
            LoadingProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            LoadingProgressBar.AnimationSpeed = 500;
            LoadingProgressBar.BackColor = Color.FromArgb(34, 35, 68);
            LoadingProgressBar.Font = new Font("Myanmar Text", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            LoadingProgressBar.ForeColor = Color.FromArgb(192, 125, 255);
            LoadingProgressBar.InnerColor = Color.FromArgb(34, 35, 68);
            LoadingProgressBar.InnerMargin = 2;
            LoadingProgressBar.InnerWidth = -1;
            LoadingProgressBar.Location = new Point(109, 232);
            LoadingProgressBar.MarqueeAnimationSpeed = 2000;
            LoadingProgressBar.Name = "LoadingProgressBar";
            LoadingProgressBar.OuterColor = Color.FromArgb(26, 28, 43);
            LoadingProgressBar.OuterMargin = -25;
            LoadingProgressBar.OuterWidth = 26;
            LoadingProgressBar.ProgressColor = Color.FromArgb(192, 125, 255);
            LoadingProgressBar.ProgressWidth = 6;
            LoadingProgressBar.SecondaryFont = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            LoadingProgressBar.Size = new Size(230, 230);
            LoadingProgressBar.StartAngle = 270;
            LoadingProgressBar.SubscriptColor = Color.FromArgb(166, 166, 166);
            LoadingProgressBar.SubscriptMargin = new Padding(10, -35, 0, 0);
            LoadingProgressBar.SubscriptText = "";
            LoadingProgressBar.SuperscriptColor = Color.FromArgb(166, 166, 166);
            LoadingProgressBar.SuperscriptMargin = new Padding(10, 35, 0, 0);
            LoadingProgressBar.SuperscriptText = "";
            LoadingProgressBar.TabIndex = 0;
            LoadingProgressBar.TextMargin = new Padding(8, 8, 0, 0);
            LoadingProgressBar.Value = 68;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(53, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(329, 198);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Myanmar Text", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(122, 465);
            label1.Name = "label1";
            label1.Size = new Size(202, 53);
            label1.TabIndex = 2;
            label1.Text = "Ładowanie...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Myanmar Text", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Window;
            label2.Location = new Point(109, 537);
            label2.Name = "label2";
            label2.Size = new Size(230, 32);
            label2.TabIndex = 3;
            label2.Text = "DreamVisionCinema©2023";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // LoadingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(455, 578);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(LoadingProgressBar);
            Cursor = Cursors.WaitCursor;
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoadingForm";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoadingForm";
            Load += LoadingForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CircularProgressBar.CircularProgressBar LoadingProgressBar;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}