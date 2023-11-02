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
            //adminStatisticsController = new AdminStatisticsController();
            adminReservationsController = new AdminReservationsController(reservationRepository, adminView);
        }

        public void Run()
        {
            LoginAsAdministrator();
            int valueAdminMenu = 0;

            //bool FilteredList = false;


            adminView.ClearConsole();

            adminView.PrintInputArt();

            while (valueAdminMenu != 6)
            {
                valueAdminMenu = adminView.RenderMainAdminView();
                switch (valueAdminMenu)
                {
                    case 1: // Lista rezerwacji
                        {
                            adminReservationsController.GetReservationList();
                            //AdminReservationsController.GetReservations()
                            break;
                        }
                    case 2: // Scroll Down
                        {
                            adminReservationsController.ScrollDown();
                            //AdminReservaationsController.ScrollDownResList();
                            break;
                        }
                    case 3: // Scroll Up
                        {
                            adminReservationsController.ScrollUp();
                            //AdminReservaationsController.ScrollUpResList();
                            break;
                        }
                    case 4: // Zarządzanie filmami
                        {
                            AdminMoviesController adminMoviesController = new AdminMoviesController(movieRepository, reservationRepository, adminView);
                            adminMoviesController.Run();
                            // AdminMoviesController.Run()
                            break;
                        }
                    case 5: // Statystyki
                        {
                            AdminStatisticsController statisticsController = new AdminStatisticsController(reservationRepository, adminView);
                            statisticsController.Run();
                            //AdminStatisticController.Run()
                            break;
                        }
                }
            }
        }
        private void LoginAsAdministrator()
        {
            bool isLoginSuccesful = false;
            string[] login_password;
            bool exceptionThrown;
            while (!isLoginSuccesful)
            {
                exceptionThrown = false;
                login_password = loginView.RenderLoginView();
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
        }
    }
}
