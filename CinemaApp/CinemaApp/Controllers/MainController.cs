using CinemaApp.Controllers.AdminControllers;
using CinemaApp.Controllers.UserControllers;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Interfaces.IViews;
using CinemaApp.Model;
using CinemaApp.Views;

namespace CinemaApp.Controllers
{
    public class MainController
    {
        public MainController() { }
        public void Run()
        {
            IMainMenuView mainMenuView = new MainMenuView();

            IMovieRepository movieRepository = new MovieRepository();
            movieRepository.ReadMoviesFromFile(); //THrows Exceptions

            IReservationRepository reservationRepository = new ReservationRepository(movieRepository);
            reservationRepository.ReadReservationsFromFile(); //THrows Exceptions

            while (true)
            {
                int valueMainMenu = mainMenuView.RenderMainMenu();
                switch (valueMainMenu)
                {
                    case 1: // Panel administratora
                        {
                            MainAdminController adminController = new MainAdminController(movieRepository, reservationRepository);
                            adminController.Run();
                            break;
                        }
                    case 2: // Panel użytkownika
                        {
                            MainUserController userController = new MainUserController(movieRepository, reservationRepository);
                            userController.Run();
                            break;
                        }
                    case 3: // Ustawienia
                        {
                            break;
                        }
                    case 4: // Wyjście z programu
                        {
                            // Tutaj jeszcze zapisanie wszytskich danych do pliku
                            movieRepository.SaveMoviesToFile();
                            reservationRepository.SaveReservationsToFile();
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }
    }
}
