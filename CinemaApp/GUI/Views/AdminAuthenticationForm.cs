using GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Views
{
    public partial class AdminAuthenticationForm : Form, IAuthenticationView
    {
        public AdminAuthenticationForm()
        {
            InitializeComponent();
            // signInButton.
            signInButton.Click += delegate { SignIn?.Invoke(this, EventArgs.Empty); };
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
