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

            addButton.Click += delegate { addMovie?.Invoke(this, EventArgs.Empty); };
            modifyButton.Click += delegate { modifyMovie?.Invoke(this, EventArgs.Empty); };
            deleteButton.Click += delegate { deleteMovie?.Invoke(this, EventArgs.Empty); };
            clearButton.Click += delegate { clearFilters?.Invoke(this, EventArgs.Empty); };
            searchButton.Click += delegate { searchMovie?.Invoke(this, EventArgs.Empty); };
            ascButton.Click += delegate { sortASC?.Invoke(this, EventArgs.Empty); };
            dscButton.Click += delegate { sortDSC?.Invoke(this, EventArgs.Empty); };


        }

        public ComboBox SortCriteria
        {
            get { return sortCriteria; }
        }

        public TextBox SearchValue
        {
            get { return  searchValue; }
        }

        public event EventHandler addMovie;
        public event EventHandler modifyMovie;
        public event EventHandler deleteMovie;
        public event EventHandler clearFilters;
        public event EventHandler searchMovie;
        public event EventHandler sortASC;
        public event EventHandler sortDSC;

        public void SetMoviesListBindingSource(BindingSource moviesList)
        {
            dataGridView1.RowTemplate.Height = 45;
            dataGridView1.DataSource = moviesList;
        }

    }
}
