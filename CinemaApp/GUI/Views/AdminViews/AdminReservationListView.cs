using FontAwesome.Sharp;
using GUI.Interfaces;

namespace GUI.Views.AdminViews
{
    public partial class AdminReservationListView : Form, IAdminReservationsView
    {
        // Wartości odrazu są inicjowane ponieważ na początek wywołuje się metoda Resize jeszcze przez załadowaniem formularza
        private Rectangle orignialFormSize = new Rectangle(
            new Point(0, 0),
            new Size(1256, 848)
            );
        private Rectangle dataGridSize = new Rectangle(
            new Point(189, 128),
            new Size(861, 686)
            );
        private Rectangle infoLabelSize = new Rectangle(
            new Point(189, 54),
            new Size(755, 54)
            );

        // Oryginalne rozmiary czcionek
        private float orginalDataGridHeaderFont = 16.5f;
        private float orginalDataGridCellFont = 13.5f;
        private float labelFont = 15f;
        public AdminReservationListView()
        {
            InitializeComponent();

            // Formularz znajduje się wewnątrz innego formularza
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
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


        // Metoda ustawiająca bindingSource dla dataGridView
        public void SetReservationListBindingSource(BindingSource reservationList)
        {
            dataGridView1.RowTemplate.Height = 45;
            dataGridView1.DataSource = reservationList;
        }


        // Metoda wywoływana automatycznie w przypadku zmiany rozmiaru okna 
        private void AdminReservationListView_Resize(object sender, EventArgs e)
        {
            resizeControl(dataGridSize, this.dataGridView1, null);
            resizeControl(infoLabelSize, this.InfoTextBox, labelFont);
        }
    }
}
