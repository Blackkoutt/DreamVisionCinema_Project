using GUI.Interfaces;

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
