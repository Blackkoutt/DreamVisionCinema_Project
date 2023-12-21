namespace GUI.Interfaces
{
    public interface IAdminReservationsView
    {
        void Show();
        void Close();
        void BringToFront();
        void SetReservationListBindingSource(BindingSource reservationList);
    }
}
