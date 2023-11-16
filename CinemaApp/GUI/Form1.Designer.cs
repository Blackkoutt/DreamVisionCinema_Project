namespace GUI;

partial class Form1
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
        panelUserMenu = new Panel();
        backButton = new FontAwesome.Sharp.IconButton();
        showReservationsButton = new FontAwesome.Sharp.IconButton();
        buyTicketButton = new FontAwesome.Sharp.IconButton();
        panelLogo = new Panel();
        logoPictureBox = new PictureBox();
        panelUserMenu.SuspendLayout();
        panelLogo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
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
        panelUserMenu.Size = new Size(220, 556);
        panelUserMenu.TabIndex = 0;
        // 
        // backButton
        // 
        backButton.Cursor = Cursors.Hand;
        backButton.Dock = DockStyle.Top;
        backButton.FlatAppearance.BorderSize = 0;
        backButton.FlatStyle = FlatStyle.Flat;
        backButton.ForeColor = Color.Gainsboro;
        backButton.IconChar = FontAwesome.Sharp.IconChar.CircleChevronLeft;
        backButton.IconColor = Color.Gainsboro;
        backButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
        backButton.IconSize = 32;
        backButton.ImageAlign = ContentAlignment.MiddleLeft;
        backButton.Location = new Point(0, 260);
        backButton.Name = "backButton";
        backButton.Padding = new Padding(10, 0, 20, 0);
        backButton.Size = new Size(220, 60);
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
        showReservationsButton.ForeColor = Color.Gainsboro;
        showReservationsButton.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
        showReservationsButton.IconColor = Color.Gainsboro;
        showReservationsButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
        showReservationsButton.IconSize = 32;
        showReservationsButton.ImageAlign = ContentAlignment.MiddleLeft;
        showReservationsButton.Location = new Point(0, 200);
        showReservationsButton.Name = "showReservationsButton";
        showReservationsButton.Padding = new Padding(10, 0, 20, 0);
        showReservationsButton.Size = new Size(220, 60);
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
        buyTicketButton.ForeColor = Color.Gainsboro;
        buyTicketButton.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
        buyTicketButton.IconColor = Color.Gainsboro;
        buyTicketButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
        buyTicketButton.IconSize = 32;
        buyTicketButton.ImageAlign = ContentAlignment.MiddleLeft;
        buyTicketButton.Location = new Point(0, 140);
        buyTicketButton.Name = "buyTicketButton";
        buyTicketButton.Padding = new Padding(10, 0, 20, 0);
        buyTicketButton.Size = new Size(220, 60);
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
        panelLogo.Size = new Size(220, 140);
        panelLogo.TabIndex = 0;
        // 
        // logoPictureBox
        // 
        logoPictureBox.Cursor = Cursors.Hand;
        logoPictureBox.Image = Properties.Resources.logo;
        logoPictureBox.Location = new Point(3, 3);
        logoPictureBox.Name = "logoPictureBox";
        logoPictureBox.Size = new Size(214, 131);
        logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        logoPictureBox.TabIndex = 0;
        logoPictureBox.TabStop = false;
        logoPictureBox.Click += logoPictureBox_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1107, 556);
        Controls.Add(panelUserMenu);
        Name = "Form1";
        Text = "Form1";
        panelUserMenu.ResumeLayout(false);
        panelLogo.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel panelUserMenu;
    private FontAwesome.Sharp.IconButton showReservationsButton;
    private FontAwesome.Sharp.IconButton buyTicketButton;
    private Panel panelLogo;
    private FontAwesome.Sharp.IconButton backButton;
    private PictureBox logoPictureBox;
}
