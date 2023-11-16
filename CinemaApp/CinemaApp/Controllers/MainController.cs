using CinemaApp.Controllers.AdminControllers;
using CinemaApp.Controllers.UserControllers;
using CinemaApp.Exceptions;
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

            // Odczyt filmów z pliku
            try
            {
                movieRepository.ReadMoviesFromFile();
            }
            catch(CannotReadFileException)
            {
                movieRepository.SaveMoviesToFile();
            }

            IReservationRepository reservationRepository = new ReservationRepository(movieRepository);

            // Odczyt rezerwacji z pliku
            try
            {
                reservationRepository.ReadReservationsFromFile();
            }
            catch (CannotReadFileException)
            {
                reservationRepository.SaveReservationsToFile();
            }
            

            while (true)
            {
                int valueMainMenu = mainMenuView.RenderMainMenu();
                switch (valueMainMenu)
                {
                    // Panel administratora
                    case 1: 
                        {
                            MainAdminController adminController = new MainAdminController(movieRepository, reservationRepository);
                            adminController.Run();
                            break;
                        }

                    // Panel użytkownika
                    case 2: 
                        {
                            MainUserController userController = new MainUserController(movieRepository, reservationRepository);
                            userController.Run();
                            break;
                        }

                    // Ustawienia
                    case 3: 
                        {
                            break;
                        }

                    // Wyjście z programu
                    case 4: 
                        {
                            // Zapisanie filmów i rezerwacji do plików
                            movieRepository.SaveMoviesToFile();
                            reservationRepository.SaveReservationsToFile();
                            Environment.Exit(0);    // Wyjście z programu 
                            break;
                        }
                }
            }
        }
    }
}