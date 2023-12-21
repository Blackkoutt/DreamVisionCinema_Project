using GUI.Interfaces;

namespace GUI.Views
{
    public partial class AdminAuthenticationForm : Form, IAuthenticationView
    {
        public AdminAuthenticationForm()
        {
            InitializeComponent();
            // signInButton.
            signInButton.Click += delegate { SignIn?.Invoke(this, EventArgs.Empty); };
            KeyPreview = true;
            KeyDown += Form_KeyDown; 
        }

        private void Form_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SignIn?.Invoke(this, EventArgs.Empty);
            }
        }

        public TextBox Login
        {
            get { return loginText; }
        }
        public TextBox Password
        {
            get { return passwordText; }
        }

        public event EventHandler SignIn;

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
