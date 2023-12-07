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

namespace GUI.Views.AdminViews
{
    public partial class AdminMoviesListView : Form, IAdminMoviesView
    {
        public AdminMoviesListView()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // Ustawianie Dock
            this.Dock = DockStyle.None;
        }

        public void SetMoviesListBindingSource(BindingSource moviesList)
        {
            dataGridView1.RowTemplate.Height = 45;
            dataGridView1.DataSource = moviesList;
        }
    }
}
