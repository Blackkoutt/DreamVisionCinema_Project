using CinemaApp.Model;
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
