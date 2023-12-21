using GUI.Interfaces;
using System.Windows.Forms;

namespace GUI.UserForms
{
    public partial class ReservationListView : Form, IReservationListView
    {
        private Rectangle orignialFormSize = new Rectangle(
            new Point(0, 0),
            new Size(1240, 779));
        private Rectangle orginalDataGrid = new Rectangle(
            new Point(182, 129),
            new Size(840, 560)
            );

        float orginalDataGridHeaderFont = 14f;
        float orginalDataGridCellFont = 12f;

        public ReservationListView()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            deleteReservationButton.Click += delegate { DeleteEvent?.Invoke(this, EventArgs.Empty); };
            //this.BringToFront();
            //childForm.Show();
        }
        public event EventHandler DeleteEvent;
        /*public void SetReservationListBindingSource(BindingSource res)
        {
            reservationList.Items.Clear();

            foreach (string item in res.List)
            {
                reservationList.Items.Add(item);
            }
        }*/
        /*public void SetReservationListBindingSource(List<Reservation> reservations)
        {
            ListViewItem new_item;
            foreach (Reservation res in reservations)
            {
                new_item = new ListViewItem(res.Id.ToString());
                new_item.SubItems.Add(res.Movie.Title);
                new_item.SubItems.Add(res.Movie.Date.ToString("dd/MM/yyyy HH:mm"));
                new_item.SubItems.Add(res.Movie.Room.Number.ToString());

                // to do poprawy
                string ticketPrice = res.Ticket.CalculatePrice(res.Movie.Price, res.Seats.Count).ToString();
                new_item.SubItems.Add(ticketPrice);

                string seats_nr = string.Join(" ", res.Seats);
                new_item.SubItems.Add(seats_nr);
                reservationList.Items.Add(new_item);
            }
        }*/

        public void SetReservationListBindingSource(BindingSource reservationList)
        {
            dataGridView.DataSource = reservationList;
        }

        private void resizeControl(Rectangle r, Control c, float? originalFontSize)
        {
            float xRatio = (float)(this.Width) / (float)(orignialFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(orignialFormSize.Height);

            int newX = (int)(r.Width * xRatio);
            int newY = (int)(r.Height * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            /*if(!(c is PictureBox))
            {
                c.Location = new Point(newX, newY);
            }*/

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

                dataGridView.DefaultCellStyle.Font = newFontCell;
                dataGridView.ColumnHeadersDefaultCellStyle.Font = newFontHeader;
                dataGridView.RowHeadersDefaultCellStyle.Font = newFontHeader;
            }

        }

        private void ReservationListView_Load(object sender, EventArgs e)
        {
            orignialFormSize = new Rectangle(
                this.Location,
                this.Size
                );
            orginalDataGrid = new Rectangle(
                orginalDataGrid.Location,
                orginalDataGrid.Size
                );
        }

        private void ReservationListView_Resize(object sender, EventArgs e)
        {
            resizeControl(orginalDataGrid, this.dataGridView, null);
        }
    }
}
