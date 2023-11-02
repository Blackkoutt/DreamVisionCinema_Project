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
        private void ExceptionOrSuccessHandler(string message)
        {
            userView.ShowSuccessOrException(message);
            userView.PrintInputArt();
        }
        public void Run()
        {
            userView.ClearViewOptionsPart(Console.WindowWidth, Console.WindowHeight);
            // List<Reservation> res = new List<Reservation>();
            try
            {
                res = reservationRepository.GetReservationsList();
                userView.SetHowManyResWereDisplayed();
                userView.ShowReservationList(res, 0);
            }
            catch (ReservationListIsEmptyException RLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + RLIEE.Message);
                //break;
                return;
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
            // userView.ClearConsole();
            int valueUserReservations = 0;
            while (valueUserReservations != 4)
            {
                valueUserReservations = userView.RenderReservationsUserView(res);
                //List<Movie> movies = movieRepository.GetAllMovies();

                switch (valueUserReservations)
                {
                    case 1:
                        {
                            ScrollDown();
                            break;
                        }
                    case 2:
                        {
                            ScrollUp();
                            break;
                        }
                    case 3:
                        {
                            CancelReservation();
                            break;
                        }
                    case 4:
                        {
                            GoBack();
                            break;
                        }
                }
            }
        }
        private void ScrollDown()
        {
            userView.ScrollDown(res);
        }
        private void ScrollUp()
        {
            userView.ScrollUp(res);
        }
        private void CancelReservation()
        {
            string id = userView.RemoveReservation();
            if (id == null)
            {
                userView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                userView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                userView.PrintInputArt();
                return;
                //break;
            }
            try
            {
                reservationRepository.DeleteReservation(id);
            }
            catch (CannotConvertException CCE)
            {
                ExceptionOrSuccessHandler("[!] " + CCE.Message);
                return;
                //break;
            }
            catch (NoReservationWithGivenIdException NRWGIE)
            {
                ExceptionOrSuccessHandler("[!] " + NRWGIE.Message);
                return;
                //break;
            }
            catch (CannotDestroyTicketException CDTE)
            {
                ExceptionOrSuccessHandler("[!] " + CDTE.Message);
                return;
                //break;
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
            ExceptionOrSuccessHandler("[V] Pomyślnie anulowano rezerwację.");

            userView.SetHowManyResWereDisplayed();
            userView.ShowReservationList(res, 0);
        }
        private void GoBack()
        {
            userView.ClearViewOptionsPart(Console.WindowWidth, Console.WindowHeight);
            userView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
        }

    }
}
