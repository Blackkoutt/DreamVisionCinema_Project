namespace GUI;

partial class MainUserForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUserForm));
        panelUserMenu = new Panel();
        backButton = new FontAwesome.Sharp.IconButton();
        showReservationsButton = new FontAwesome.Sharp.IconButton();
        buyTicketButton = new FontAwesome.Sharp.IconButton();
        panelLogo = new Panel();
        logoPictureBox = new PictureBox();
        titleBar = new Panel();
        lblTitleChildForm = new Label();
        iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
        panelShadow = new Panel();
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
        panelUserMenu.Controls.Add(backButton);
        panelUserMenu.Controls.Add(showReservationsButton);
        panelUserMenu.Controls.Add(buyTicketButton);
        panelUserMenu.Controls.Add(panelLogo);
        panelUserMenu.Dock = DockStyle.Left;
        panelUserMenu.Location = new Point(0, 0);
        panelUserMenu.Name = "panelUserMenu";
        panelUserMenu.Size = new Size(250, 700);
        panelUserMenu.TabIndex = 0;
        // 
        // backButton
        // 
        backButton.Cursor = Cursors.Hand;
        backButton.Dock = DockStyle.Top;
        backButton.FlatAppearance.BorderSize = 0;
        backButton.FlatStyle = FlatStyle.Flat;
        backButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        backButton.ForeColor = Color.Gainsboro;
        backButton.IconChar = FontAwesome.Sharp.IconChar.CircleChevronLeft;
        backButton.IconColor = Color.Gainsboro;
        backButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
        backButton.IconSize = 32;
        backButton.ImageAlign = ContentAlignment.MiddleLeft;
        backButton.Location = new Point(0, 260);
        backButton.Name = "backButton";
        backButton.Padding = new Padding(10, 0, 20, 0);
        backButton.Size = new Size(250, 60);
        backButton.TabIndex = 3;
        backButton.Text = "Wróć";
        backButton.TextAlign = ContentAlignment.MiddleLeft;
        backButton.TextImageRelation = TextImageRelation.ImageBeforeText;
        backButton.UseVisualStyleBackColor = true;
        backButton.Click += backButton_Click;
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
        // buyTicketButton
        // 
        buyTicketButton.Cursor = Cursors.Hand;
        buyTicketButton.Dock = DockStyle.Top;
        buyTicketButton.FlatAppearance.BorderSize = 0;
        buyTicketButton.FlatStyle = FlatStyle.Flat;
        buyTicketButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        buyTicketButton.ForeColor = Color.Gainsboro;
        buyTicketButton.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
        buyTicketButton.IconColor = Color.Gainsboro;
        buyTicketButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
        buyTicketButton.IconSize = 32;
        buyTicketButton.ImageAlign = ContentAlignment.MiddleLeft;
        buyTicketButton.Location = new Point(0, 140);
        buyTicketButton.Name = "buyTicketButton";
        buyTicketButton.Padding = new Padding(10, 0, 20, 0);
        buyTicketButton.Size = new Size(250, 60);
        buyTicketButton.TabIndex = 1;
        buyTicketButton.Text = "Kup bilet na film";
        buyTicketButton.TextAlign = ContentAlignment.MiddleLeft;
        buyTicketButton.TextImageRelation = TextImageRelation.ImageBeforeText;
        buyTicketButton.UseVisualStyleBackColor = true;
        buyTicketButton.Click += buyTicketButton_Click;
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
        titleBar.Size = new Size(1169, 75);
        titleBar.TabIndex = 1;
        titleBar.MouseDown += titleBar_MouseDown;
        // 
        // lblTitleChildForm
        // 
        lblTitleChildForm.AutoSize = true;
        lblTitleChildForm.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblTitleChildForm.ForeColor = Color.Gainsboro;
        lblTitleChildForm.Location = new Point(73, 33);
        lblTitleChildForm.Name = "lblTitleChildForm";
        lblTitleChildForm.Size = new Size(120, 23);
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
        // panelShadow
        // 
        panelShadow.BackColor = Color.FromArgb(26, 24, 58);
        panelShadow.Dock = DockStyle.Top;
        panelShadow.Location = new Point(250, 75);
        panelShadow.Name = "panelShadow";
        panelShadow.Size = new Size(1169, 9);
        panelShadow.TabIndex = 2;
        // 
        // panelDesktop
        // 
        panelDesktop.BackColor = Color.FromArgb(34, 33, 74);
        panelDesktop.Controls.Add(bigLogo);
        panelDesktop.Dock = DockStyle.Fill;
        panelDesktop.Location = new Point(250, 84);
        panelDesktop.Name = "panelDesktop";
        panelDesktop.Size = new Size(1169, 616);
        panelDesktop.TabIndex = 3;
        // 
        // bigLogo
        // 
        bigLogo.Anchor = AnchorStyles.None;
        bigLogo.Image = Properties.Resources.logo;
        bigLogo.Location = new Point(266, 141);
        bigLogo.Name = "bigLogo";
        bigLogo.Size = new Size(646, 320);
        bigLogo.SizeMode = PictureBoxSizeMode.Zoom;
        bigLogo.TabIndex = 1;
        bigLogo.TabStop = false;
        // 
        // MainUserForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1419, 700);
        Controls.Add(panelDesktop);
        Controls.Add(panelShadow);
        Controls.Add(titleBar);
        Controls.Add(panelUserMenu);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MinimumSize = new Size(1437, 747);
        Name = "MainUserForm";
        Text = "Panel użytkownika";
        panelUserMenu.ResumeLayout(false);
        panelLogo.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
        titleBar.ResumeLayout(false);
        titleBar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).EndInit();
        panelDesktop.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)bigLogo).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel panelUserMenu;
    private FontAwesome.Sharp.IconButton showReservationsButton;
    private FontAwesome.Sharp.IconButton buyTicketButton;
    private Panel panelLogo;
    private FontAwesome.Sharp.IconButton backButton;
    private PictureBox logoPictureBox;
    private Panel titleBar;
    private Label lblTitleChildForm;
    private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
    private Panel panelShadow;
    private Panel panelDesktop;
    private PictureBox bigLogo;
}
