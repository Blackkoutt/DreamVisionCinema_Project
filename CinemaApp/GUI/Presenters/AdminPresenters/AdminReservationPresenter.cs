using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.Views;

namespace GUI.Presenters.AdminPresenters
{
    public class AdminReservationPresenter
    {
        private IAdminReservationsView _view;

        private IReservationRepository _reservationRepository;

        private BindingSource reservationBindingSource;
        private List<Reservation> reservationsList;

        public AdminReservationPresenter(IReservationRepository reservationRepository, IAdminReservationsView view)
        {
            _reservationRepository = reservationRepository;

            this._view = view;

            // Ustawienie bindingSource dla dataGridView
            this.reservationBindingSource = new BindingSource();
            this._view.SetReservationListBindingSource(reservationBindingSource);

            // Pobranie listy rezerwacji i przypisanie jej do dataGridView
            LoadReservationList();
            _view.BringToFront();
            _view.Show();
        }

        // Metoda tworząca powiadomienie (Success, Error, Info)
        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox(true);
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }


        // Metoda przypisująca pobrane dane do dataGridView
        private void LoadReservationList()
        {
            try
            {
                reservationsList = _reservationRepository.GetReservationsList();    // Pobranie danych odnośnie rezerwacji
                
                // Przypisanie danych do dataGridView
                reservationBindingSource.DataSource = reservationsList.Select   
                    (r => new {
                        ID = r.Id,
                        Tytuł = r.Movie.Title,
                        Data = r.Movie.Date.ToString("dd/MM/yyyy HH:mm"),
                        Sala = r.Movie.Room.Number.ToString(),
                        Cena = r.Ticket.CalculatePrice(r.Movie.Price, r.Seats.Count).ToString(),
                        Miejsca = string.Join(" ", r.Seats)
                    });
            }
            catch(ReservationListIsEmptyException RLIEE)
            {
                MakeAlert(RLIEE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch(Exception ex)
            {
                MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                return;
            }        
        }
    }
}
