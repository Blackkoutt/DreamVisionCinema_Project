using GUI.Interfaces;
using System;
using FontAwesome.Sharp;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CinemaApp.Enums;

namespace GUI.Views.UserViews
{
    public partial class MovieReservationView : Form, IMovieReservationView
    {
        public MovieReservationView()
        {
            InitializeComponent();
            undoButton.Click += delegate { Undo?.Invoke(this, EventArgs.Empty); };
            buyTicketButton.Click += delegate { BuyTicket?.Invoke(this, EventArgs.Empty); };
            //AddSeatControl
        }
        public Label SeatsLabel
        {
            get { return this.seatsLabel; }
        }
        public Control.ControlCollection GetControls()
        {
            return this.Controls;
        }


        public event EventHandler Undo;
        public event EventHandler BuyTicket;

        public void AddSeatControl(Control control)
        {
            this.Controls.Add(control);
        }

    }
}
