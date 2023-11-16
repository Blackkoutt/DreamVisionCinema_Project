namespace GUI;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using UserForms;

public partial class MainUserForm : Form
{
    private IconButton currentButton;
    private Panel leftBorderButton;
    private Form currentChildForm;
    public MainUserForm()
    {
        InitializeComponent();
        leftBorderButton = new Panel();
        leftBorderButton.Size = new Size(7, 60);
        panelUserMenu.Controls.Add(leftBorderButton);

        this.Text = string.Empty;
        this.ControlBox = false;
        this.DoubleBuffered = true;
        this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
    }
    private void OpenChildForm(Form childForm)
    {
        if (currentChildForm != null)
        {
            currentChildForm.Close();
        }
        currentChildForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        panelDesktop.Controls.Add(childForm);
        panelDesktop.Tag = childForm;
        childForm.BringToFront();
        childForm.Show();
        lblTitleChildForm.Text = childForm.Text;
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

            iconCurrentChildForm.IconChar = currentButton.IconChar;
            iconCurrentChildForm.IconColor = color;
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
        OpenChildForm(new ReservationListView());
    }

    private void backButton_Click(object sender, EventArgs e)
    {
        ActivateButton(sender, RGBColors.color3);
    }

    private void logoPictureBox_Click(object sender, EventArgs e)
    {
        if (currentChildForm != null)
        {
            currentChildForm.Close();
        }

        DisableButton();
        leftBorderButton.Visible = false;

        iconCurrentChildForm.IconChar = IconChar.House;
        iconCurrentChildForm.IconColor = Color.MediumPurple;
        lblTitleChildForm.Text = "Strona g��wna";
    }
    [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
    private extern static void ReleaseCapture();
    [DllImport("user32.DLL", EntryPoint = "SendMessage")]
    private extern static void SendMessage(System.IntPtr hwNd, int wMsg, int wParam, int lParam);
    private void titleBar_MouseDown(object sender, MouseEventArgs e)
    {
        ReleaseCapture();
        SendMessage(this.Handle, 0x112, 0xf012, 0);
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void maximiseButton_Click(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Normal)
        {
            WindowState = FormWindowState.Maximized;
            maximiseButton.IconChar = IconChar.WindowRestore;
        }
        else
        {
            WindowState = FormWindowState.Normal;
            maximiseButton.IconChar = IconChar.WindowMaximize;
        }
    }

    private void minimiseButton_Click(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Minimized;
    }
}
