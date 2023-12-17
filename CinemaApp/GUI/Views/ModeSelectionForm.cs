using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Interfaces;
using CinemaApp.Model;
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
    public partial class ModeSelectionForm : Form, ISelectionView
    {
        public ModeSelectionForm()
        {
            InitializeComponent();

            

            adminButton.Click += delegate { ShowAuthenticationView?.Invoke(this, EventArgs.Empty); };
            userButton.Click += delegate { ShowMainUserView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowAuthenticationView;
        public event EventHandler ShowMainUserView;
    }
}
