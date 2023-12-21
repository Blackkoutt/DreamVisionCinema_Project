using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.Views;

namespace GUI.Presenters.UserPresenters
{

    public class UserReservationPresenter
    {
        private IReservationListView _reservationlistView;
        private IReservationRepository _reservationRepository;
        private BindingSource reservationBindingSource;
        private List<Reservation> reservationsList;
        public UserReservationPresenter(IReservationListView reservationlistView, IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
            _reservationlistView  = reservationlistView;

            this.reservationBindingSource = new BindingSource();
            this._reservationlistView.SetReservationListBindingSource(reservationBindingSource);
           
            this._reservationlistView.DeleteEvent += DeleteCurrentReservation;
            // Load data
            LoadReservationList();
            _reservationlistView.BringToFront();
            _reservationlistView.Show();
        }
        private void RefreshReservationsList()
        {
            LoadReservationList();
            reservationBindingSource.ResetBindings(false);
        }
        private void DeleteCurrentReservation(object? sender, EventArgs e)
        {
            string currentReservationIdString = reservationBindingSource.Current.ToString().Split(",")[0].Split("=")[1].Trim();
            try
            {
                _reservationRepository.DestroyTicketJPG(currentReservationIdString);// throw exception nieobsluzone
                _reservationRepository.DeleteReservation(currentReservationIdString); // throws Exceptions
                RefreshReservationsList();
                
            }
            catch(CannotConvertException CCE)
            {
                MakeAlert(CCE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch(NoReservationWithGivenIdException NRWGIE)
            {
                MakeAlert(NRWGIE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch(CannotDestroyTicketException CDTE)
            {
                MakeAlert(CDTE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch(Exception ex)
            {
                MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                return;
            }
           
            MakeAlert("Poprawnie anulowano rezerwację", CustomAlertBox.enmType.Success);
        }
        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox(true);
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }

        private void LoadReservationList()
        {
            // Throws exceptions
            try
            {
                reservationsList = _reservationRepository.GetReservationsList();
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
            catch (ReservationListIsEmptyException RLIEE)
            {
                MakeAlert(RLIEE.Message, CustomAlertBox.enmType.Info);
            }
            catch(Exception ex)
            {
                MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
            }
        }
    }
}
