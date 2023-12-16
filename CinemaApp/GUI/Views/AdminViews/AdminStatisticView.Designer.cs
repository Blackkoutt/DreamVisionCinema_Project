
namespace GUI.Views.AdminViews
{
    partial class AdminStatisticView
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
            earningsPanel = new Panel();
            earningsLabel = new Label();
            earnigsLabel = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            panel1 = new Panel();
            progressBar = new CircularProgressBar.CircularProgressBar();
            guidelineLabel = new Label();
            label3 = new Label();
            popularButton = new FontAwesome.Sharp.IconButton();
            profitableButton = new FontAwesome.Sharp.IconButton();
            earningsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // earningsPanel
            // 
            earningsPanel.BackColor = Color.FromArgb(50, 52, 102);
            earningsPanel.Controls.Add(earningsLabel);
            earningsPanel.Controls.Add(earnigsLabel);
            earningsPanel.Controls.Add(iconPictureBox1);
            earningsPanel.Location = new Point(74, 96);
            earningsPanel.Name = "earningsPanel";
            earningsPanel.Size = new Size(516, 199);
            earningsPanel.TabIndex = 0;
            // 
            // earningsLabel
            // 
            earningsLabel.Font = new Font("Montserrat", 24F, FontStyle.Regular, GraphicsUnit.Point);
            earningsLabel.ForeColor = Color.FromArgb(143, 241, 126);
            earningsLabel.Location = new Point(17, 78);
            earningsLabel.Name = "earningsLabel";
            earningsLabel.Size = new Size(359, 75);
            earningsLabel.TabIndex = 106;
            earningsLabel.Text = "1223 $";
            earningsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // earnigsLabel
            // 
            earnigsLabel.Font = new Font("Montserrat", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            earnigsLabel.ForeColor = SystemColors.Window;
            earnigsLabel.Location = new Point(17, 29);
            earnigsLabel.Name = "earnigsLabel";
            earnigsLabel.Size = new Size(359, 34);
            earnigsLabel.TabIndex = 105;
            earnigsLabel.Text = "Całkowity dochód kina:";
            earnigsLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.FromArgb(50, 52, 102);
            iconPictureBox1.ForeColor = Color.FromArgb(143, 241, 126);
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.SackDollar;
            iconPictureBox1.IconColor = Color.FromArgb(143, 241, 126);
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 122;
            iconPictureBox1.Location = new Point(382, 42);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(122, 124);
            iconPictureBox1.TabIndex = 0;
            iconPictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(50, 52, 102);
            panel1.Controls.Add(progressBar);
            panel1.Controls.Add(guidelineLabel);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(679, 96);
            panel1.Name = "panel1";
            panel1.Size = new Size(516, 199);
            panel1.TabIndex = 1;
            // 
            // progressBar
            // 
            progressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            progressBar.AnimationSpeed = 500;
            progressBar.BackColor = Color.Transparent;
            progressBar.Font = new Font("Myanmar Text", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            progressBar.ForeColor = Color.FromArgb(192, 125, 255);
            progressBar.InnerColor = Color.FromArgb(42, 40, 60);
            progressBar.InnerMargin = 2;
            progressBar.InnerWidth = -1;
            progressBar.Location = new Point(30, 29);
            progressBar.MarqueeAnimationSpeed = 2000;
            progressBar.Name = "progressBar";
            progressBar.OuterColor = Color.FromArgb(28, 26, 43);
            progressBar.OuterMargin = -25;
            progressBar.OuterWidth = 26;
            progressBar.ProgressColor = Color.FromArgb(192, 125, 255);
            progressBar.ProgressWidth = 7;
            progressBar.SecondaryFont = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            progressBar.Size = new Size(130, 130);
            progressBar.StartAngle = 270;
            progressBar.SubscriptColor = Color.FromArgb(166, 166, 166);
            progressBar.SubscriptMargin = new Padding(10, -35, 0, 0);
            progressBar.SubscriptText = "";
            progressBar.SuperscriptColor = Color.FromArgb(166, 166, 166);
            progressBar.SuperscriptMargin = new Padding(10, 35, 0, 0);
            progressBar.SuperscriptText = "";
            progressBar.TabIndex = 4;
            progressBar.Text = "60%";
            progressBar.TextMargin = new Padding(8, 8, 0, 0);
            progressBar.Value = 68;
            // 
            // guidelineLabel
            // 
            guidelineLabel.Font = new Font("Montserrat", 24F, FontStyle.Regular, GraphicsUnit.Point);
            guidelineLabel.ForeColor = Color.FromArgb(192, 125, 255);
            guidelineLabel.Location = new Point(163, 78);
            guidelineLabel.Name = "guidelineLabel";
            guidelineLabel.Size = new Size(350, 75);
            guidelineLabel.TabIndex = 106;
            guidelineLabel.Text = "1223/2400 $";
            guidelineLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Montserrat", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Window;
            label3.Location = new Point(177, 29);
            label3.Name = "label3";
            label3.Size = new Size(308, 34);
            label3.TabIndex = 105;
            label3.Text = "Wytyczna zarobków:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // popularButton
            // 
            popularButton.BackColor = Color.FromArgb(50, 52, 102);
            popularButton.FlatAppearance.BorderSize = 0;
            popularButton.FlatStyle = FlatStyle.Flat;
            popularButton.Font = new Font("Montserrat", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            popularButton.ForeColor = SystemColors.Window;
            popularButton.IconChar = FontAwesome.Sharp.IconChar.RankingStar;
            popularButton.IconColor = Color.FromArgb(255, 165, 31);
            popularButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            popularButton.IconSize = 122;
            popularButton.Location = new Point(74, 366);
            popularButton.Name = "popularButton";
            popularButton.Size = new Size(516, 332);
            popularButton.TabIndex = 2;
            popularButton.Text = "Diagram najpopularniejszych filmów";
            popularButton.TextImageRelation = TextImageRelation.ImageAboveText;
            popularButton.UseVisualStyleBackColor = false;
            // 
            // profitableButton
            // 
            profitableButton.BackColor = Color.FromArgb(50, 52, 102);
            profitableButton.FlatAppearance.BorderSize = 0;
            profitableButton.FlatStyle = FlatStyle.Flat;
            profitableButton.Font = new Font("Montserrat", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            profitableButton.ForeColor = SystemColors.Window;
            profitableButton.IconChar = FontAwesome.Sharp.IconChar.ArrowUpRightDots;
            profitableButton.IconColor = Color.FromArgb(125, 208, 255);
            profitableButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            profitableButton.IconSize = 122;
            profitableButton.Location = new Point(679, 366);
            profitableButton.Name = "profitableButton";
            profitableButton.Size = new Size(516, 332);
            profitableButton.TabIndex = 3;
            profitableButton.Text = "Diagram najbardziej dochodowych filmów";
            profitableButton.TextImageRelation = TextImageRelation.ImageAboveText;
            profitableButton.UseVisualStyleBackColor = false;
            // 
            // AdminStatisticView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(1438, 841);
            Controls.Add(profitableButton);
            Controls.Add(popularButton);
            Controls.Add(panel1);
            Controls.Add(earningsPanel);
            Name = "AdminStatisticView";
            Text = "AdminStatisticView";
            earningsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel earningsPanel;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Label earningsLabel;
        private Label earnigsLabel;
        private Panel panel1;
        private Label guidelineLabel;
        private Label label3;
        private FontAwesome.Sharp.IconButton popularButton;
        private FontAwesome.Sharp.IconButton profitableButton;
        private CircularProgressBar.CircularProgressBar progressBar;
    }
}