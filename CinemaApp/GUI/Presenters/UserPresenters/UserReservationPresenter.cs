using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.Views;
using GUI.Views.UserViews;

namespace GUI.Presenters.UserPresenters
{

    public class UserReservationPresenter
    {
        private IReservationListView _reservationlistView;
        private IReservationRepository _reservationRepository;
        private BindingSource reservationBindingSource;
        private List<Reservation> reservationsList;

        private List<ICancelMessage> cancelMessages = new List<ICancelMessage>();
        public UserReservationPresenter(IReservationListView reservationlistView, IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
            _reservationlistView  = reservationlistView;

            // Przypisanie bindingSource do listy
            this.reservationBindingSource = new BindingSource();
            this._reservationlistView.SetReservationListBindingSource(reservationBindingSource);

            // Dodanie obsługi eventu kliknięcia przycisku Anuluj rezerwację
            this._reservationlistView.DeleteEvent += DeleteCurrentReservation;  
            
            // Załadowanie danych na listę dataGridView
            LoadReservationList();
            _reservationlistView.BringToFront();
            _reservationlistView.Show();
        }

        // Metoda odświeżająca listę dataGridView
        private void RefreshReservationsList()
        {
            LoadReservationList();
            reservationBindingSource.ResetBindings(false);
        }

        // Metoda obsługująca event klinknięcia przcisku "Anuluj rezerwację"
        private void DeleteCurrentReservation(object? sender, EventArgs e)
        {
            if(reservationBindingSource.Current != null)
            {
                // Pobranie niezbędnych danych z listy
                string title = reservationBindingSource.Current.ToString().Split(",")[1].Split("=")[1].Trim();
                string date = reservationBindingSource.Current.ToString().Split(",")[2].Split("=")[1].Trim();
                string id = reservationBindingSource.Current.ToString().Split(",")[0].Split("=")[1].Trim();

                // Utworzenie powiadomienia w celu upewnienia się czy użytkownik napewno chce anulować daną rezerwację
                ICancelMessage newMessage = new CancelMessage(id, title, date);

                // Sprawdzenie czy na liscie otwartych okien nie ma już okna z daną rezerwacją
                ICancelMessage? existingView = cancelMessages.FirstOrDefault(form => form.ID == newMessage.ID);

                // Jeśli takie okno istnieje to wyświetl je na froncie
                if(existingView != null)
                {
                    existingView.BringToFront();
                }
                // Jeśli nie istnieje pokaż nowe okno, dodaj obsługe eventów i dodaj je do listy otwartych okien
                else
                {
                    newMessage.Show();
                    newMessage.submitCancel += HandleSubmitCancelRes;
                    newMessage.cancelCancel += HandleCancelCancelRes;
                    newMessage.cancelFormClosing += HandleCloseCancelForm;
                    cancelMessages.Add(newMessage);
                }
            }
            else
            {
                MakeAlert("Lista rezerwacji jest pusta", CustomAlertBox.enmType.Info);
            }
        }


        // Metoda obsługująca event zamknięcia okna (potwierdzenia)
        private void HandleCloseCancelForm(object? sender, EventArgs e)
        {
            ICancelMessage cancel = (ICancelMessage)sender;
            cancelMessages.Remove(cancel);
        }

        // Metoda obsługjąca anulowanie Anulowania rezerwacji 
        private void HandleCancelCancelRes(object? sender, EventArgs e)
        {
            CloseCancelMessage(sender);
        }

        // Metoda obsługująca event potwierdzenia anulowania rezerwacji
        private void HandleSubmitCancelRes(object? sender, EventArgs e)
        {
            string id = "";
            // Pobranie id rezerwacji która jest anulowywana
            if(e is CancelMessage.CancelEventArgs cancelEventArgs)
            {
                id = cancelEventArgs.Id;
            }
            try
            {
                _reservationRepository.DestroyTicketJPG(id); // Usunięcie pliku z biletem danej rezerwacji
                _reservationRepository.DeleteReservation(id);   // Usunięcie rezerwacji z listy
                RefreshReservationsList();  // Odświeżenie listy dataGridView

            }
            catch (CannotConvertException CCE)
            {
                MakeAlert(CCE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch (NoReservationWithGivenIdException NRWGIE)
            {
                MakeAlert(NRWGIE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch (CannotDestroyTicketException CDTE)
            {
                MakeAlert(CDTE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch (Exception ex)
            {
                MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                return;
            }

            MakeAlert("Poprawnie anulowano rezerwację", CustomAlertBox.enmType.Success);
            CloseCancelMessage(sender); // Zamknięcie okna potwierdzenia anulowania rezerwacji
        }


        // Metoda zamykającja okno potwierdzenia anulowania rezerwacji
        private void CloseCancelMessage(object? sender)
        {
            // Wyszukiwanie na liście otwartych okien tego które wygenerowało event
            ICancelMessage temp = null;
             foreach(ICancelMessage mess in cancelMessages)
             {
                if(mess == sender)
                {
                    mess.Close();
                    temp = mess;
                    break;
                }
             }
             if(temp != null)
             {
                cancelMessages.RemoveAll(m => m == temp);   // Usunięcie go z listy otwartych okien
             }
        }


        // Metoda tworząca powiadomienia (Info, Succes, Error)
        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox(true);
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }

        // Metoda ładujaca listę rezerwacji do dataGridView
        private void LoadReservationList()
        {
            try
            {
                // Pobranie listy rezerwacji
                reservationsList = _reservationRepository.GetReservationsList();
                // Przypisanie listy rezerwacji do BindingSource dataGridView
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
