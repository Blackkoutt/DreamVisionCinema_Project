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
            //this.Load
        }
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
        public event EventHandler ShowAuthenticationView;
        public event EventHandler ShowMainUserView;
    }
}
