using GUI.Interfaces;
using System.ComponentModel;

namespace GUI.Views.UserViews
{
    public partial class MoviesListView : Form, IMoviesListView
    {
        private Rectangle orignialFormSize = new Rectangle(
            new Point(0, 0),
            new Size(1222, 913));
        private Rectangle orginalDataGrid = new Rectangle(
            new Point(178, 223),
            new Size(838, 678)
            );
        private Rectangle info = new Rectangle(
            new Point(125, 45),
            new Size(631, 44)
            );
        private Rectangle info_sort = new Rectangle(
            new Point(125, 108),
            new Size(183, 41)
            );
        private Rectangle info_search = new Rectangle(
            new Point(178, 171),
            new Size(130, 39)
            );
        private Rectangle sort_box = new Rectangle(
            new Point(307, 110),
            new Size(217, 39)
            );
        private Rectangle search_box = new Rectangle(
            new Point(307, 171),
            new Size(217, 38)
            );
        private Rectangle sortASCBtn = new Rectangle(
            new Point(540, 108),
            new Size(102, 46)
            );
        private Rectangle sortDSCBtn = new Rectangle(
            new Point(678, 108),
            new Size(102, 46)
            );
        private Rectangle searchBtn = new Rectangle(
           new Point(540, 170),
           new Size(240, 45)
           );
        private Rectangle resBtn = new Rectangle(
           new Point(846, 103),
           new Size(192, 51)
           );
        private Rectangle clrBtn = new Rectangle(
           new Point(846, 165),
           new Size(192, 54)
           );


        //float originaldataGridFont = 9;
        float orginalDataGridHeaderFont = 16.5f;
        float orginalDataGridCellFont = 14.5f;

       float infoFont = 16f;


        float infoSortFont = 16f;
        float infoSearchFont = 16f;
        float SortBoxFont = 16f;
        float SearchBoxFont = 16f;
        float SortASCBtnFont = 13f;
        float SortDSCBtnFont = 13f;
        float SearchBtnFont = 13f;
        float ResBtnFont = 15f;
        float ClrBtnFont = 14f;

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
        private void resizeControl(Rectangle r, Control c, float? originalFontSize)
        {
            float xRatio = (float)(this.Width) / (float)(orignialFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(orignialFormSize.Height);

            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            if(!(c is PictureBox)&&!(c is DataGridView))
            {
                c.Location = new Point(newX, newY);
            }

            // c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
            float ratio = xRatio;
            if (xRatio >= yRatio)
            {
                ratio = yRatio;
            }
            if (originalFontSize != null)
            {
                float newFontSize = (float)(originalFontSize * ratio);
                Font newFont = new Font(c.Font.FontFamily, newFontSize);
                c.Font = newFont;
            }


            if (c is DataGridView)
            {
                float newFontHeaderSize = orginalDataGridHeaderFont * ratio;
                Font newFontHeader = new Font(c.Font.FontFamily, newFontHeaderSize);
                float newFontCellSize = orginalDataGridCellFont * ratio;
                Font newFontCell = new Font(c.Font.FontFamily, newFontCellSize);

                dataGridView1.DefaultCellStyle.Font = newFontCell;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = newFontHeader;
                dataGridView1.RowHeadersDefaultCellStyle.Font = newFontHeader;
            }

        }

        private void MoviesListView_Load(object sender, EventArgs e)
        {
            orignialFormSize = new Rectangle(
                this.Location,
                this.Size
                );
            orginalDataGrid = new Rectangle(
                orginalDataGrid.Location,
                orginalDataGrid.Size
                );

            //originaldataGridFont = dataGridView1.Font.Size;
        }

        private void MoviesListView_Resize(object sender, EventArgs e)
        {
            resizeControl(orginalDataGrid, this.dataGridView1, null);
            resizeControl(info, this.InfoTextBox, infoFont);

            resizeControl(info_sort, this.label1, infoSortFont);
            resizeControl(info_search, this.label2, infoSearchFont);
            resizeControl(sort_box, this.sortCriteria, SortBoxFont);
            resizeControl(search_box, this.searchValue, SearchBoxFont);
            resizeControl(sortASCBtn, this.ascButton, SortASCBtnFont);
            resizeControl(sortDSCBtn, this.dscButton, SortDSCBtnFont);
            resizeControl(searchBtn, this.searchButton, SearchBtnFont);
            resizeControl(resBtn, this.reserveationButton, ResBtnFont);
            resizeControl(clrBtn, this.clearButton, ClrBtnFont);
        }

        /*private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }*/
    }
}
