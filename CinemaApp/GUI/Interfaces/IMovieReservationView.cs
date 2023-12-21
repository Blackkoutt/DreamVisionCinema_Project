namespace GUI.Interfaces
{
    public interface IMovieReservationView
    {
        void Show();
        void Close();
        void BringToFront();
        public Label SeatsLabel { get; }
        event EventHandler Undo;
        event EventHandler BuyTicket;
        public Control.ControlCollection GetControls();
        public void AddSeatControl(Control control);
    }
}
