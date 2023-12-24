namespace GUI.Interfaces
{
    public interface IReservationListView
    {
        event EventHandler DeleteEvent;
        void SetReservationListBindingSource(BindingSource reservationList);
        void Show();
        void Close();
        void BringToFront();
    }
}
