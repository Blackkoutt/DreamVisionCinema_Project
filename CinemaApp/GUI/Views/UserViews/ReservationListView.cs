using GUI.Interfaces;

namespace GUI.UserForms
{
    public partial class ReservationListView : Form, IReservationListView
    {
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
    }
}
