using FontAwesome.Sharp;
using GUI.Interfaces;

namespace GUI.UserForms
{
    public partial class ReservationListView : Form, IReservationListView
    {
        // Wartości odrazu są inicjowane ponieważ na początek wywołuje się metoda Resize jeszcze przez załadowaniem formularza
        private Rectangle orignialFormSize = new Rectangle(
            new Point(0, 0),
            new Size(1240, 779)
            );
        private Rectangle orginalDataGrid = new Rectangle(
            new Point(182, 129),
            new Size(850, 560)
            );
        private Rectangle resInfo = new Rectangle(
            new Point(173,38),
            new Size(559, 50)
            );
        private Rectangle resBtn = new Rectangle(
            new Point(735, 34),
            new Size(260, 54)
            );


        // Oryginalne rozmiary czcionek
        private float orginalDataGridHeaderFont = 14f;
        private float orginalDataGridCellFont = 12f;
        private float resInfoFont = 15f;
        private float resBtnFont = 13f;

        public ReservationListView()
        {
            InitializeComponent();

            // Formularz znajduje się wewnątrz innego formularza
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            deleteReservaationButton.Click += delegate { DeleteEvent?.Invoke(this, EventArgs.Empty); };

        }
        public event EventHandler DeleteEvent;


        // Metoda ustawiająca bindingSource dla dataGridView
        public void SetReservationListBindingSource(BindingSource reservationList)
        {
            dataGridView.DataSource = reservationList;
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
                    dataGridView.DefaultCellStyle.Font = newFontCell;

                }
                if (newFontHeaderSize > 0 && newFontHeaderSize != float.NegativeInfinity && newFontHeaderSize != float.PositiveInfinity)
                {
                    Font newFontHeader = new Font(c.Font.FontFamily, newFontHeaderSize);
                    dataGridView.ColumnHeadersDefaultCellStyle.Font = newFontHeader;
                    dataGridView.RowHeadersDefaultCellStyle.Font = newFontHeader;
                }
            }

        }


        // Metoda wywoływana automatycznie w przypadku zmiany rozmiaru okna 
        private void ReservationListView_Resize(object sender, EventArgs e)
        {
            resizeControl(orginalDataGrid, this.dataGridView, null);
            resizeControl(resInfo, this.reservationListLabel, resInfoFont);
            resizeControl(resBtn, this.deleteReservaationButton, resBtnFont);
        }
    }
}
