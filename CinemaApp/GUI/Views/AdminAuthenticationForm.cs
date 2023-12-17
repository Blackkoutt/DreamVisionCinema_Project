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
        public RichTextBox Login
        {
            get { return loginTextView; }
        }
        public RichTextBox Password
        {
            get { return passwordTextView; }
        }

        public event EventHandler SignIn;
    }
}
