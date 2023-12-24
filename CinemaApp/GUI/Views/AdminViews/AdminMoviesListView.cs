using FontAwesome.Sharp;
using GUI.Interfaces;

namespace GUI.Views.AdminViews
{
    public partial class AdminMoviesListView : Form, IAdminMoviesView
    {
        // Wartości odrazu są inicjowane ponieważ na początek wywołuje się metoda Resize jeszcze przez załadowaniem formularza
        private Rectangle orignialFormSize = new Rectangle(
            new Point(0,0),
            new Size(1256, 848)
            );
        private Rectangle dataGridSize = new Rectangle(
            new Point(210, 210),
            new Size(898, 569)
            );
        private Rectangle sortLabelSize = new Rectangle(
            new Point(54, 63),
            new Size(183, 41)
            );
        private Rectangle searchLabelSize = new Rectangle(
            new Point(107, 137),
            new Size(130, 39)
            );
        private Rectangle sortBoxSize = new Rectangle(
            new Point(243, 62),
            new Size(217, 33)
            );
        private Rectangle searchBoxSize = new Rectangle(
            new Point(243, 137),
            new Size(217, 31)
            );
        private Rectangle buttonAscSize = new Rectangle(
            new Point(480, 63),
            new Size(102, 43)
            );
        private Rectangle buttonDscSize = new Rectangle(
            new Point(618, 63),
            new Size(102, 43)
            );
        private Rectangle buttonSearchSize = new Rectangle(
            new Point(480, 137),
            new Size(240, 42)
            );
        private Rectangle buttonAddSize = new Rectangle(
            new Point(788, 56),
            new Size(192, 51)
            );
        private Rectangle buttonModifySize = new Rectangle(
            new Point(1003, 56),
            new Size(192, 51)
            );
        private Rectangle buttonClearSize = new Rectangle(
            new Point(788, 130),
            new Size(192, 51)
            );
        private Rectangle buttonDeleteSize = new Rectangle(
            new Point(1003, 130),
            new Size(192, 51)
            );


        // Oryginalne rozmiary czcionek
        private float orginalDataGridHeaderFont = 16f;
        private float orginalDataGridCellFont = 13f;
        private float SortBoxFont = 16f;
        private float SearchBoxFont = 16f;
        private float labelFont = 14f;
        private float boxFont = 11f;
        private float buttonFont = 12f;

        public AdminMoviesListView()
        {
            InitializeComponent();

            // Formularz znajduje się wewnątrz innego formularza
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.Dock = DockStyle.None;

            // Delegowanie obsługi eventów 
            addButton.Click += delegate { addMovie?.Invoke(this, EventArgs.Empty); };
            modifyButton.Click += delegate { modifyMovie?.Invoke(this, EventArgs.Empty); };
            deleteButton.Click += delegate { deleteMovie?.Invoke(this, EventArgs.Empty); };
            clearButton.Click += delegate { clearFilters?.Invoke(this, EventArgs.Empty); };
            searchButton.Click += delegate { searchMovie?.Invoke(this, EventArgs.Empty); };
            ascButton.Click += delegate { sortASC?.Invoke(this, EventArgs.Empty); };
            dscButton.Click += delegate { sortDSC?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler addMovie;
        public event EventHandler modifyMovie;
        public event EventHandler deleteMovie;
        public event EventHandler clearFilters;
        public event EventHandler searchMovie;
        public event EventHandler sortASC;
        public event EventHandler sortDSC;

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

            if (!(c is PictureBox))
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
                if (newFontCellSize > 0 && newFontCellSize != float.NegativeInfinity && newFontCellSize != float.PositiveInfinity)
                {
                    Font newFontCell = new Font(c.Font.FontFamily, newFontCellSize);
                    dataGridView1.DefaultCellStyle.Font = newFontCell;

                }
                if (newFontHeaderSize > 0 && newFontHeaderSize != float.NegativeInfinity && newFontHeaderSize != float.PositiveInfinity)
                {
                    Font newFontHeader = new Font(c.Font.FontFamily, newFontHeaderSize);
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = newFontHeader;
                    dataGridView1.RowHeadersDefaultCellStyle.Font = newFontHeader;
                }
            }

        }


        // Metoda wywoływana automatycznie w przypadku zmiany rozmiaru okna 
        private void AdminMoviesListView_Resize(object sender, EventArgs e)
        {
            resizeControl(dataGridSize, this.dataGridView1, null);
            resizeControl(sortLabelSize, this.label1, labelFont);
            resizeControl(searchLabelSize, this.label2, labelFont);
            resizeControl(sortBoxSize, this.sortCriteria, SortBoxFont);
            resizeControl(searchBoxSize, this.searchValue, SearchBoxFont);
            resizeControl(buttonAscSize, this.ascButton, boxFont);
            resizeControl(buttonDscSize, this.dscButton, boxFont);
            resizeControl(buttonSearchSize, this.searchButton, boxFont);
            resizeControl(buttonAddSize, this.addButton, buttonFont);
            resizeControl(buttonModifySize, this.modifyButton, buttonFont);
            resizeControl(buttonClearSize, this.clearButton, buttonFont);
            resizeControl(buttonDeleteSize, this.deleteButton, buttonFont);
        }
    }
}
