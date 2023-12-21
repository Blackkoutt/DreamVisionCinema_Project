using GUI.Interfaces;

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

            searchButton.Click += delegate { searchMovieUser?.Invoke(this, EventArgs.Empty); };
            ascButton.Click += delegate { sortASCUser?.Invoke(this, EventArgs.Empty); };
            dscButton.Click += delegate { sortDSCUser?.Invoke(this, EventArgs.Empty); };
            clearButton.Click += delegate { clearFiltersUser?.Invoke(this, EventArgs.Empty); };
        }
        public DataGridView dataGridView
        {
            get { return this.dataGridView1; }
        }

        public event EventHandler ShowMovieRoom;
        public event EventHandler searchMovieUser;
        public event EventHandler sortASCUser;
        public event EventHandler sortDSCUser;
        public event EventHandler clearFiltersUser;

        public ComboBox SortCriteria
        {
            get { return sortCriteria; }
        }

        public TextBox SearchValue
        {
            get { return searchValue; }
        }

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
