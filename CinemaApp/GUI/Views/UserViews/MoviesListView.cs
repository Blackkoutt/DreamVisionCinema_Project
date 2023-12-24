using FontAwesome.Sharp;
using GUI.Interfaces;
using System.ComponentModel;

namespace GUI.Views.UserViews
{
    public partial class MoviesListView : Form, IMoviesListView
    {
        // Wartości odrazu są inicjowane ponieważ na początek wywołuje się metoda Resize jeszcze przez załadowaniem formularza
        private Rectangle orignialFormSize = new Rectangle(
            new Point(0, 0),
            new Size(1222, 913)
            );
        private Rectangle orginalDataGrid = new Rectangle(
            new Point(178, 253),
            new Size(838, 628)
            );
        private Rectangle info = new Rectangle(
            new Point(125, 39),
            new Size(631, 44)
            );
        private Rectangle info_sort = new Rectangle(
            new Point(125, 102),
            new Size(183, 41)
            );
        private Rectangle info_search = new Rectangle(
            new Point(178, 165),
            new Size(130, 39)
            );
        private Rectangle sort_box = new Rectangle(
            new Point(307, 104),
            new Size(217, 39)
            );
        private Rectangle search_box = new Rectangle(
            new Point(307, 165),
            new Size(217, 38)
            );
        private Rectangle sortASCBtn = new Rectangle(
            new Point(540, 102),
            new Size(102, 46)
            );
        private Rectangle sortDSCBtn = new Rectangle(
            new Point(678, 102),
            new Size(102, 46)
            );
        private Rectangle searchBtn = new Rectangle(
           new Point(540, 164),
           new Size(240, 45)
           );
        private Rectangle resBtn = new Rectangle(
           new Point(846, 97),
           new Size(192, 51)
           );
        private Rectangle clrBtn = new Rectangle(
           new Point(846, 159),
           new Size(192, 54)
           );

        // Originalne rozmiary czcionek
        private float orginalDataGridHeaderFont = 16.5f;
        private float orginalDataGridCellFont = 14.5f;
        private float infoFont = 16f;
        private float infoSortFont = 16f;
        private float infoSearchFont = 16f;
        private float SortBoxFont = 16f;
        private float SearchBoxFont = 16f;
        private float SortASCBtnFont = 13f;
        private float SortDSCBtnFont = 13f;
        private float SearchBtnFont = 13f;
        private float ResBtnFont = 15f;
        private float ClrBtnFont = 14f;

        public MoviesListView()
        {
            InitializeComponent();

            // Formularz znajduje się wewnątrz innego formularza
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            reserveationButton.Click += delegate { ShowMovieRoom?.Invoke(this, EventArgs.Empty); };
            searchButton.Click += delegate { searchMovieUser?.Invoke(this, EventArgs.Empty); };
            ascButton.Click += delegate { sortASCUser?.Invoke(this, EventArgs.Empty); };
            dscButton.Click += delegate { sortDSCUser?.Invoke(this, EventArgs.Empty); };
            clearButton.Click += delegate { clearFiltersUser?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowMovieRoom;
        public event EventHandler searchMovieUser;
        public event EventHandler sortASCUser;
        public event EventHandler sortDSCUser;
        public event EventHandler clearFiltersUser;

        public DataGridView dataGridView
        {
            get { return this.dataGridView1; }
        }
        public ComboBox SortCriteria
        {
            get { return sortCriteria; }
        }

        public TextBox SearchValue
        {
            get { return searchValue; }
        }


        // Metoda ustawiająca bindingSource dla dataGridView
        public void SetMoviesListBindingSource(BindingSource moviesList)
        {
            dataGridView1.RowTemplate.Height = 45;
            dataGridView1.DataSource = moviesList;
        }


        // Metoda zmieniająca rozmiar kontrolki i jej czcionki
        private void resizeControl(Rectangle r, Control c, float? originalFontSize)
        {
            float xRatio = (float)(this.Width) / (float)(orignialFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(orignialFormSize.Height);

            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            if(!(c is PictureBox))
            {
                c.Location = new Point(newX, newY);
            }
            c.Size = new Size(newWidth, newHeight);
            float ratio = xRatio;
            if (xRatio >= yRatio)
            {
                ratio = yRatio;
            }
            if (originalFontSize != null)
            {
                float newFontSize = (float)(originalFontSize * ratio);
                if (newFontSize > 0 && newFontSize != float.NegativeInfinity && newFontSize != float.PositiveInfinity)
                {
                    Font newFont = new Font(c.Font.FontFamily, newFontSize);
                    if (c is IconButton)
                    {
                        newFont = new Font(c.Font.FontFamily, newFontSize, FontStyle.Bold);
                    }

                    c.Font = newFont;
                }
            }


            if (c is DataGridView)
            {
                float newFontHeaderSize = orginalDataGridHeaderFont * ratio;
                
                float newFontCellSize = orginalDataGridCellFont * ratio;
                if(newFontCellSize > 0 && newFontCellSize != float.NegativeInfinity && newFontCellSize != float.PositiveInfinity)
                {
                    Font newFontCell = new Font(c.Font.FontFamily, newFontCellSize);
                    dataGridView1.DefaultCellStyle.Font = newFontCell;
                    
                }
                if(newFontHeaderSize > 0 && newFontHeaderSize != float.NegativeInfinity && newFontHeaderSize != float.PositiveInfinity)
                {
                    Font newFontHeader = new Font(c.Font.FontFamily, newFontHeaderSize);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = newFontHeader;
                    dataGridView1.RowHeadersDefaultCellStyle.Font = newFontHeader;
                }
            }

        }


        // Metoda wywoływana automatycznie w przypadku zmiany rozmiaru okna 
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
    }
}
