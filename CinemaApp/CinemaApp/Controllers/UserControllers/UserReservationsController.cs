using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IViews;
using CinemaApp.Model;

namespace CinemaApp.Controllers.UserControllers
{
    public class UserReservationsController
    {
        private IUserView userView;
        private IReservationRepository reservationRepository;
        private List<Reservation> res;
        public UserReservationsController(IReservationRepository reservationRepository, IUserView userView)
        {
            this.reservationRepository = reservationRepository;
            this.userView = userView;
            res = new List<Reservation>();
        }

        // Metoda wyświetlająca sukces lub błąd wykonywanej operacji
        private void ExceptionOrSuccessHandler(string message)
        {
            userView.ShowSuccessOrException(message);
            userView.PrintInputArt();
        }
        public void Run()
        {
            userView.ClearViewOptionsPart(Console.WindowWidth, Console.WindowHeight);
            try
            {
                res = reservationRepository.GetReservationsList();
                userView.SetHowManyResWereDisplayed();
                userView.ShowReservationList(res, 0);
            }
            catch (ReservationListIsEmptyException RLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + RLIEE.Message);
                return;
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            int valueUserReservations = 0;
            while (valueUserReservations != 4)
            {
                valueUserReservations = userView.RenderReservationsUserView(res);

                switch (valueUserReservations)
                {

                    // Przewijanie listy rezerwacji do dołu
                    case 1:
                        {
                            ScrollDown();
                            break;
                        }

                    // Przewijanie listy rezerwacji do góry
                    case 2:
                        {
                            ScrollUp();
                            break;
                        }

                    // Anulowawnie rezerwacji
                    case 3:
                        {
                            CancelReservation();
                            break;
                        }

                    // Powrót do poprzedniego widoku
                    case 4:
                        {
                            GoBack();
                            break;
                        }
                }
            }
        }

        // Metoda przewijająca listę rezerwacji do dołu
        private void ScrollDown()
        {
            userView.ScrollDown(res);
        }


        // Metoda przewijająca listę rezerwacji do góry
        private void ScrollUp()
        {
            userView.ScrollUp(res);
        }


        // Metoda usuwająca rezerwację (pobranie wprowadzonego przez użytkownika id z widoku i wywołanie funkcji usuwającej rezerwację o danym id)
        private void CancelReservation()
        {
            string id = userView.RemoveReservation();
            if (id == null)
            {
                userView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                userView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                userView.PrintInputArt();
                return;
            }
            try
            {
                reservationRepository.DeleteReservation(id);
            }
            catch (CannotConvertException CCE)
            {
                ExceptionOrSuccessHandler("[!] " + CCE.Message);
                return;
            }
            catch (NoReservationWithGivenIdException NRWGIE)
            {
                ExceptionOrSuccessHandler("[!] " + NRWGIE.Message);
                return;
            }
            catch (CannotDestroyTicketException CDTE)
            {
                ExceptionOrSuccessHandler("[!] " + CDTE.Message);
                return;
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
            ExceptionOrSuccessHandler("[V] Pomyślnie anulowano rezerwację.");

            userView.SetHowManyResWereDisplayed();
            try
            {
                userView.ShowReservationList(res, 0);
            }
            catch (ReservationListIsEmptyException RLIEE)
            {
                userView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
                ExceptionOrSuccessHandler("[!] " + RLIEE.Message);               
                return;
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

        }


        // Powrót do poprzedniego widoku
        private void GoBack()
        {
            userView.ClearViewOptionsPart(Console.WindowWidth, Console.WindowHeight);
            userView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
        }

    }
}