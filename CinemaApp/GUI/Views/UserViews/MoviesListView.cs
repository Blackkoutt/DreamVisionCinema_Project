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

namespace GUI.Views.UserViews
{
    public partial class MoviesListView : Form, IMoviesListView
    {
        public MoviesListView()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            reserveationButton.Click += delegate { ShowMovieRoom?.Invoke(this, EventArgs.Empty); };
        }
        public DataGridView dataGridView
        {
            get { return this.dataGridView1; }
        }

        public event EventHandler ShowMovieRoom;

        public void SetMoviesListBindingSource(BindingSource moviesList)
        {

            // Ustawianie stałej wysokości wierszy
            dataGridView1.RowTemplate.Height = 45;
            dataGridView1.DataSource = moviesList;
        }

        /*private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }*/
    }
}
