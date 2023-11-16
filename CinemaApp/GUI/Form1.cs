namespace GUI;
using FontAwesome.Sharp;
public partial class Form1 : Form
{
    private IconButton currentButton;
    private Panel leftBorderButton;
    public Form1()
    {
        InitializeComponent();
        leftBorderButton = new Panel();
        leftBorderButton.Size = new Size(7, 60);
        panelUserMenu.Controls.Add(leftBorderButton);
    }

    private struct RGBColors
    {
        public static Color color1 = Color.FromArgb(172, 126, 241);
        public static Color color2 = Color.FromArgb(249, 118, 176);
        public static Color color3 = Color.FromArgb(253, 138, 114);
    }

    private void ActivateButton(object sender, Color color)
    {
        if (sender != null)
        {
            DisableButton();
            currentButton = (IconButton)sender;
            currentButton.BackColor = Color.FromArgb(37, 36, 81);
            currentButton.ForeColor = color;
            currentButton.TextAlign = ContentAlignment.MiddleCenter;
            currentButton.IconColor = color;
            currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            currentButton.ImageAlign = ContentAlignment.MiddleRight;


            leftBorderButton.BackColor = color;
            leftBorderButton.Location = new Point(0, currentButton.Location.Y);
            leftBorderButton.Visible = true;
            leftBorderButton.BringToFront();
        }
    }
    private void DisableButton()
    {
        if (currentButton != null)
        {
            currentButton.BackColor = Color.FromArgb(31, 30, 68);
            currentButton.ForeColor = Color.Gainsboro;
            currentButton.TextAlign = ContentAlignment.MiddleLeft;
            currentButton.IconColor = Color.Gainsboro;
            currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            currentButton.ImageAlign = ContentAlignment.MiddleLeft;

        }
    }

    private void buyTicketButton_Click(object sender, EventArgs e)
    {
        ActivateButton(sender, RGBColors.color1);
    }

    private void showReservationsButton_Click(object sender, EventArgs e)
    {
        ActivateButton(sender, RGBColors.color2);
    }

    private void backButton_Click(object sender, EventArgs e)
    {
        ActivateButton(sender, RGBColors.color3);
    }

    private void logoPictureBox_Click(object sender, EventArgs e)
    {
        DisableButton();
        leftBorderButton.Visible = false;
    }
}
