using FontAwesome.Sharp;
using GUI.Interfaces;
using System.Runtime.InteropServices;

namespace GUI.Views
{
    public partial class MainAdminForm : Form, IMainAdminForm
    {
        private IconButton currentButton;
        private Panel leftBorderButton;
        public event EventHandler ShowAdminReservationsView;
        public event EventHandler ShowAdminMoviesView;
        public event EventHandler ShowAdminStatisticsView;
        public event EventHandler AdminLoadDefault;
        public event EventHandler goBackEvent;
        public event EventHandler closeEvent;

        private Rectangle PanelOriginalRectangle;
        private Rectangle orignialFormSize;
        private Rectangle orginalPanelLogoRectangle;
        private Rectangle originalTopPanelRectangle;
        private Rectangle originalBigLogoRectangle;
        private Rectangle originalMenuButtonSize1;
        private Rectangle originalMenuButtonSize2;
        private Rectangle originalMenuButtonSize3;
        private Rectangle originalMenuButtonSize4;

        private Rectangle originalTextTopSize;

        float originalbuttonMenuFont1;
        float originalbuttonMenuFont2;
        float originalbuttonMenuFont3;
        float originalbuttonMenuFont4;

        float originalTextTopFont;
        //float 
        // private float fontScale = 9f;

        public MainAdminForm()
        {
            InitializeComponent();

            backButton.Click += delegate { goBackEvent?.Invoke(this, EventArgs.Empty); };

            showReservationsButton.Click += delegate { ShowAdminReservationsView?.Invoke(this, EventArgs.Empty); };

            showMoviesListButton.Click += delegate { ShowAdminMoviesView?.Invoke(this, EventArgs.Empty); };

            statisticButton.Click += delegate { ShowAdminStatisticsView?.Invoke(this, EventArgs.Empty); };

            logoPictureBox.Click += delegate { AdminLoadDefault?.Invoke(this, EventArgs.Empty); };
            this.FormClosed += delegate { closeEvent?.Invoke(this, EventArgs.Empty); };




            leftBorderButton = new Panel();
            leftBorderButton.Size = new Size(7, 60);
            panelUserMenu.Controls.Add(leftBorderButton);
        }

        private void MainAdminForm_Load(object sender, EventArgs e)
        {
            orignialFormSize = new Rectangle(
                this.Location,
                this.Size
                );
            PanelOriginalRectangle = new Rectangle(
                panelUserMenu.Location,
                panelUserMenu.Size
                );
            orginalPanelLogoRectangle = new Rectangle(
                logoPictureBox.Location,
                logoPictureBox.Size);
            originalTopPanelRectangle = new Rectangle(
               titleBar.Location,
               titleBar.Size
               );
            originalBigLogoRectangle = new Rectangle(
               bigLogo.Location,
               bigLogo.Size);
            originalMenuButtonSize1 = new Rectangle(
               showMoviesListButton.Location,
               showMoviesListButton.Size);
            originalMenuButtonSize2 = new Rectangle(
               showReservationsButton.Location,
                showReservationsButton.Size);
            originalMenuButtonSize3 = new Rectangle(
               statisticButton.Location,
               statisticButton.Size);
            originalMenuButtonSize4 = new Rectangle(
               backButton.Location,
               backButton.Size);

            originalTextTopSize = new Rectangle(
               lblTitleChildForm.Location,
               lblTitleChildForm.Size);

            originalbuttonMenuFont1 = showMoviesListButton.Font.Size;
            originalbuttonMenuFont2 = showReservationsButton.Font.Size;
            originalbuttonMenuFont3 = statisticButton.Font.Size;
            originalbuttonMenuFont4 = backButton.Font.Size;
            originalTextTopFont = lblTitleChildForm.Font.Size;



        }
        private void resizeControl(Rectangle r, Control c, float originalFontSize)
        {
            float xRatio = (float)(this.Width) / (float)(orignialFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(orignialFormSize.Height);

            int newX = (int)(r.Width * xRatio);
            int newY = (int)(r.Height * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            // c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
            float ratio = xRatio;
            if (xRatio >= yRatio)
            {
                ratio = yRatio;
            }
            float newFontSize = originalFontSize * ratio;

            Font newFont = new Font(c.Font.FontFamily, newFontSize);
            c.Font = newFont;
        }
        private void MainAdminForm_Resize(object sender, EventArgs e)
        {
            resizeControl(PanelOriginalRectangle, this.panelUserMenu, this.panelUserMenu.Font.Size);
            resizeControl(originalTopPanelRectangle, this.titleBar, this.titleBar.Font.Size);
            resizeControl(originalBigLogoRectangle, this.bigLogo, this.bigLogo.Font.Size);
            resizeControl(orginalPanelLogoRectangle, this.logoPictureBox, this.logoPictureBox.Font.Size);
            resizeControl(originalMenuButtonSize1, this.showMoviesListButton, originalbuttonMenuFont1);
            resizeControl(originalMenuButtonSize2, this.showReservationsButton, originalbuttonMenuFont2);
            resizeControl(originalMenuButtonSize3, this.statisticButton, originalbuttonMenuFont3);
            resizeControl(originalMenuButtonSize4, this.backButton, originalbuttonMenuFont4);

            resizeControl(originalTextTopSize, this.lblTitleChildForm, originalTextTopFont);
        }
        public PictureBox MainBigLogo
        {
            get { return this.bigLogo; }
        }
        public Panel PanelContainer
        {
            get { return this.panelDesktop; }
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(143, 241, 126);
            public static Color color4 = Color.FromArgb(253, 138, 114);

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

                //lblTitleChildForm.Text = currentButton.Text;

                leftBorderButton.BackColor = color;
                leftBorderButton.Location = new Point(0, currentButton.Location.Y);
                leftBorderButton.Visible = true;
                leftBorderButton.BringToFront();

                iconCurrentChildForm.IconChar = currentButton.IconChar;
                iconCurrentChildForm.IconColor = color;

                switch (currentButton.Text)
                {
                    case "Pokaż listę filmów":
                        {
                            lblTitleChildForm.Text = "Lista filmów";
                            break;
                        }
                    case "Pokaż listę rezerwacji":
                        {
                            lblTitleChildForm.Text = "Lista rezerwacji";
                            break;
                        }
                    case "Pokaż statystyki":
                        {
                            lblTitleChildForm.Text = "Statystyki";
                            break;
                        }
                }
            }
        }
        public void DisableButton()
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


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwNd, int wMsg, int wParam, int lParam);

        private void titleBar_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {
            /*if (currentChildForm != null)
            {
                currentChildForm.Close();
            }*/

            DisableButton();
            leftBorderButton.Visible = false;

            iconCurrentChildForm.IconChar = IconChar.House;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Strona główna";
        }

        private void showMoviesListButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
        }

        private void showReservationsButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
        }

        private void statisticButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
        }


    }
}
