namespace GUI.Interfaces
{
    public interface IReservationListView
    {
        //bool isSuccesful { get; set; }
        //string Message { get; set; }

        event EventHandler DeleteEvent;

        //void SetReservationListBindingSource(List<Reservation> res);
        void SetReservationListBindingSource(BindingSource reservationList);
        void Show();
        void Close();
        void BringToFront();
    }
}
