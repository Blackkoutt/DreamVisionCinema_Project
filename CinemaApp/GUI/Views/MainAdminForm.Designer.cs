namespace GUI.Views
{
    partial class MainAdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainAdminForm));
            panelUserMenu = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            statisticButton = new FontAwesome.Sharp.IconButton();
            showReservationsButton = new FontAwesome.Sharp.IconButton();
            showMoviesListButton = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            logoPictureBox = new PictureBox();
            titleBar = new Panel();
            lblTitleChildForm = new Label();
            iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            panelDesktop = new Panel();
            bigLogo = new PictureBox();
            panelUserMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).BeginInit();
            panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bigLogo).BeginInit();
            SuspendLayout();
            // 
            // panelUserMenu
            // 
            panelUserMenu.BackColor = Color.FromArgb(31, 30, 68);
            panelUserMenu.Controls.Add(iconButton1);
            panelUserMenu.Controls.Add(statisticButton);
            panelUserMenu.Controls.Add(showReservationsButton);
            panelUserMenu.Controls.Add(showMoviesListButton);
            panelUserMenu.Controls.Add(panelLogo);
            panelUserMenu.Dock = DockStyle.Left;
            panelUserMenu.Location = new Point(0, 0);
            panelUserMenu.Name = "panelUserMenu";
            panelUserMenu.Size = new Size(250, 900);
            panelUserMenu.TabIndex = 1;
            // 
            // iconButton1
            // 
            iconButton1.Cursor = Cursors.Hand;
            iconButton1.Dock = DockStyle.Top;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            iconButton1.ForeColor = Color.Gainsboro;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.CircleChevronLeft;
            iconButton1.IconColor = Color.Gainsboro;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 32;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(0, 320);
            iconButton1.Name = "iconButton1";
            iconButton1.Padding = new Padding(10, 0, 20, 0);
            iconButton1.Size = new Size(250, 60);
            iconButton1.TabIndex = 4;
            iconButton1.Text = "Wróć";
            iconButton1.TextAlign = ContentAlignment.MiddleLeft;
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // statisticButton
            // 
            statisticButton.Cursor = Cursors.Hand;
            statisticButton.Dock = DockStyle.Top;
            statisticButton.FlatAppearance.BorderSize = 0;
            statisticButton.FlatStyle = FlatStyle.Flat;
            statisticButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            statisticButton.ForeColor = Color.Gainsboro;
            statisticButton.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            statisticButton.IconColor = Color.Gainsboro;
            statisticButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            statisticButton.IconSize = 32;
            statisticButton.ImageAlign = ContentAlignment.MiddleLeft;
            statisticButton.Location = new Point(0, 260);
            statisticButton.Name = "statisticButton";
            statisticButton.Padding = new Padding(10, 0, 20, 0);
            statisticButton.Size = new Size(250, 60);
            statisticButton.TabIndex = 3;
            statisticButton.Text = "Pokaż statystyki";
            statisticButton.TextAlign = ContentAlignment.MiddleLeft;
            statisticButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            statisticButton.UseVisualStyleBackColor = true;
            statisticButton.Click += statisticButton_Click;
            // 
            // showReservationsButton
            // 
            showReservationsButton.Cursor = Cursors.Hand;
            showReservationsButton.Dock = DockStyle.Top;
            showReservationsButton.FlatAppearance.BorderSize = 0;
            showReservationsButton.FlatStyle = FlatStyle.Flat;
            showReservationsButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            showReservationsButton.ForeColor = Color.Gainsboro;
            showReservationsButton.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
            showReservationsButton.IconColor = Color.Gainsboro;
            showReservationsButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            showReservationsButton.IconSize = 32;
            showReservationsButton.ImageAlign = ContentAlignment.MiddleLeft;
            showReservationsButton.Location = new Point(0, 200);
            showReservationsButton.Name = "showReservationsButton";
            showReservationsButton.Padding = new Padding(10, 0, 20, 0);
            showReservationsButton.Size = new Size(250, 60);
            showReservationsButton.TabIndex = 2;
            showReservationsButton.Text = "Pokaż listę rezerwacji";
            showReservationsButton.TextAlign = ContentAlignment.MiddleLeft;
            showReservationsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            showReservationsButton.UseVisualStyleBackColor = true;
            showReservationsButton.Click += showReservationsButton_Click;
            // 
            // showMoviesListButton
            // 
            showMoviesListButton.Cursor = Cursors.Hand;
            showMoviesListButton.Dock = DockStyle.Top;
            showMoviesListButton.FlatAppearance.BorderSize = 0;
            showMoviesListButton.FlatStyle = FlatStyle.Flat;
            showMoviesListButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            showMoviesListButton.ForeColor = Color.Gainsboro;
            showMoviesListButton.IconChar = FontAwesome.Sharp.IconChar.Film;
            showMoviesListButton.IconColor = Color.Gainsboro;
            showMoviesListButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            showMoviesListButton.IconSize = 32;
            showMoviesListButton.ImageAlign = ContentAlignment.MiddleLeft;
            showMoviesListButton.Location = new Point(0, 140);
            showMoviesListButton.Name = "showMoviesListButton";
            showMoviesListButton.Padding = new Padding(10, 0, 20, 0);
            showMoviesListButton.Size = new Size(250, 60);
            showMoviesListButton.TabIndex = 1;
            showMoviesListButton.Text = "Pokaż listę filmów";
            showMoviesListButton.TextAlign = ContentAlignment.MiddleLeft;
            showMoviesListButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            showMoviesListButton.UseVisualStyleBackColor = true;
            showMoviesListButton.Click += showMoviesListButton_Click;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(logoPictureBox);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(250, 140);
            panelLogo.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Cursor = Cursors.Hand;
            logoPictureBox.Image = Properties.Resources.logo;
            logoPictureBox.Location = new Point(0, 0);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(250, 140);
            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            logoPictureBox.Click += logoPictureBox_Click;
            // 
            // titleBar
            // 
            titleBar.BackColor = Color.FromArgb(31, 30, 68);
            titleBar.Controls.Add(lblTitleChildForm);
            titleBar.Controls.Add(iconCurrentChildForm);
            titleBar.Dock = DockStyle.Top;
            titleBar.Location = new Point(250, 0);
            titleBar.Name = "titleBar";
            titleBar.Size = new Size(1369, 75);
            titleBar.TabIndex = 2;
            titleBar.MouseDown += titleBar_MouseDown_1;
            // 
            // lblTitleChildForm
            // 
            lblTitleChildForm.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitleChildForm.ForeColor = Color.Gainsboro;
            lblTitleChildForm.Location = new Point(73, 33);
            lblTitleChildForm.Name = "lblTitleChildForm";
            lblTitleChildForm.Size = new Size(321, 23);
            lblTitleChildForm.TabIndex = 1;
            lblTitleChildForm.Text = "Strona główna";
            // 
            // iconCurrentChildForm
            // 
            iconCurrentChildForm.BackColor = Color.FromArgb(31, 30, 68);
            iconCurrentChildForm.ForeColor = Color.MediumPurple;
            iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCurrentChildForm.IconSize = 40;
            iconCurrentChildForm.Location = new Point(16, 21);
            iconCurrentChildForm.Name = "iconCurrentChildForm";
            iconCurrentChildForm.Size = new Size(40, 40);
            iconCurrentChildForm.TabIndex = 0;
            iconCurrentChildForm.TabStop = false;
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(34, 33, 74);
            panelDesktop.Controls.Add(bigLogo);
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(250, 75);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1369, 825);
            panelDesktop.TabIndex = 4;
            // 
            // bigLogo
            // 
            bigLogo.Anchor = AnchorStyles.None;
            bigLogo.Image = Properties.Resources.logo;
            bigLogo.Location = new Point(375, 253);
            bigLogo.Name = "bigLogo";
            bigLogo.Size = new Size(646, 320);
            bigLogo.SizeMode = PictureBoxSizeMode.Zoom;
            bigLogo.TabIndex = 1;
            bigLogo.TabStop = false;
            // 
            // MainAdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1619, 900);
            Controls.Add(panelDesktop);
            Controls.Add(titleBar);
            Controls.Add(panelUserMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1637, 947);
            Name = "MainAdminForm";
            Text = "Panel administratora";
            panelUserMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            titleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).EndInit();
            panelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bigLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelUserMenu;
        private FontAwesome.Sharp.IconButton statisticButton;
        private FontAwesome.Sharp.IconButton showReservationsButton;
        private FontAwesome.Sharp.IconButton showMoviesListButton;
        private Panel panelLogo;
        private PictureBox logoPictureBox;
        private Panel titleBar;
        private Label lblTitleChildForm;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private Panel panelDesktop;
        private PictureBox bigLogo;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}