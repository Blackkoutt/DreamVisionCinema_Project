using GUI.Interfaces;

namespace GUI.Views
{
    public partial class AdminAuthenticationForm : Form, IAuthenticationView
    {
        public AdminAuthenticationForm()
        {
            InitializeComponent();
            signInButton.Click += delegate { SignIn?.Invoke(this, EventArgs.Empty); };
            KeyPreview = true;
            KeyDown += Form_KeyDown;
        }

        public event EventHandler SignIn;

        public TextBox Login
        {
            get { return loginText; }
        }
        public TextBox Password
        {
            get { return passwordText; }
        }
   

        // Metoda do obsługi logowania za pomocą entera
        private void Form_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SignIn?.Invoke(this, EventArgs.Empty);
            }
        }


        // Metoda zmieniająca wyśweitlanie się hasła w zależości od zaznaczenia checkBoxa
        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPasswordCheckBox.Checked)
            {
                passwordText.PasswordChar = '\0';
            }
            else
            {
                passwordText.PasswordChar = '*';
            }
        }
    }
}
