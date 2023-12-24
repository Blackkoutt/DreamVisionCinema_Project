using GUI.Interfaces;

namespace GUI.Views
{
    public partial class ModeSelectionForm : Form, ISelectionView
    {
        public ModeSelectionForm()
        {
            InitializeComponent();

            // Deletowane Eventy
            adminButton.Click += delegate { ShowAuthenticationView?.Invoke(this, EventArgs.Empty); };
            userButton.Click += delegate { ShowMainUserView?.Invoke(this, EventArgs.Empty); };

            this.FormClosed += delegate { closeSelectionEvent?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler closeSelectionEvent;
        public event EventHandler ShowAuthenticationView;
        public event EventHandler ShowMainUserView;

        // Metoda wywoływana w momenice błędy krytycznego uniemożliwiającego dalsze korzystanie z aplikacji
        public void StartFailure(string msg)
        {
            this.Controls.Clear();
            FontAwesome.Sharp.IconPictureBox failLogo = new FontAwesome.Sharp.IconPictureBox();
            failLogo.Anchor = AnchorStyles.None;
            failLogo.Location = new Point(215, 100);
            failLogo.Name = "failLogo";
            failLogo.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            failLogo.ForeColor = Color.Red;
            failLogo.Size = new Size(416, 250);
            failLogo.SizeMode = PictureBoxSizeMode.Zoom;

            Label failLabel = new Label();
            failLabel.Font = new Font("Montserrat", 16F, FontStyle.Regular, GraphicsUnit.Point);
            failLabel.ForeColor = Color.Red;
            failLabel.Location = new Point(0, 320);
            failLabel.Name = "filmEditlabel";
            failLabel.Size = new Size(860, 300);
            failLabel.Text = msg;
            failLabel.TextAlign = ContentAlignment.TopCenter;

            this.Controls.Add(failLabel);
            this.Controls.Add(failLogo);

        }
    }
}