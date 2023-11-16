using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Interfaces.IViews;
using CinemaApp.Model;
using CinemaApp.Views;

namespace CinemaApp.Controllers.AdminControllers
{
    public class MainAdminController
    {
        private IAdminView adminView;
        private ILoginView loginView;
        private IMovieRepository movieRepository;
        private IReservationRepository reservationRepository;

        private AdminReservationsController adminReservationsController;
        public MainAdminController(IMovieRepository movieRepository, IReservationRepository reservationRepository)
        {
            this.movieRepository = movieRepository;
            this.reservationRepository = reservationRepository;
            adminView = new AdminView();
            loginView = new LoginView();
            adminReservationsController = new AdminReservationsController(reservationRepository, adminView);
        }

        public void Run()
        {
            if (!LoginAsAdministrator())
            {
                return;
            }
            int valueAdminMenu = 0;

            adminView.ClearConsole();

            adminView.PrintInputArt();

            while (valueAdminMenu != 6)
            {
                valueAdminMenu = adminView.RenderMainAdminView();
                switch (valueAdminMenu)
                {
                    // Wyświetlenie listy rezerwacji
                    case 1:
                        {
                            adminReservationsController.GetReservationList();
                            break;
                        }

                    // Przewinięcie listy rezerwacji do dołu
                    case 2:
                        {
                            adminReservationsController.ScrollDown();
                            break;
                        }

                    // Przewinięcie listy rezeracji do góry
                    case 3: // Scroll Up
                        {
                            adminReservationsController.ScrollUp();
                            break;
                        }

                    // Przejście do widoku zarządzania filmami
                    case 4:
                        {
                            AdminMoviesController adminMoviesController = new AdminMoviesController(movieRepository, reservationRepository, adminView);
                            adminMoviesController.Run();
                            break;
                        }

                    // Przejście do widoku statystyk 
                    case 5:
                        {
                            AdminStatisticsController statisticsController = new AdminStatisticsController(reservationRepository, adminView);
                            statisticsController.Run();
                            break;
                        }
                }
            }
        }

        // Metoda odpowiadająca za logowanie na konto administratora
        private bool LoginAsAdministrator()
        {
            bool isLoginSuccesful = false;
            string[] login_password;
            bool exceptionThrown;
            while (!isLoginSuccesful)
            {
                exceptionThrown = false;
                login_password = loginView.RenderLoginView();
                if (login_password == null)
                {
                    return false;
                }
                try
                {
                    isLoginSuccesful = Login.SignIn(login_password[0], login_password[1]);
                }
                catch (CannotReadFileException CRFE)
                {
                    exceptionThrown = true;
                    string[] new_login_password = loginView.ShowMissingPasswordFileError(CRFE.Message);
                    Thread.Sleep(2000);
                    Login.HashPassword(new_login_password[0], new_login_password[1]);
                }
                catch (Exception ex)
                {
                    adminView.PrintUnknownErrorInfo(ex.Message);
                    Environment.Exit(1);
                }

                if (!isLoginSuccesful && !exceptionThrown)
                {
                    loginView.PrintError();
                }
            }
            return true;
        }
    }
}