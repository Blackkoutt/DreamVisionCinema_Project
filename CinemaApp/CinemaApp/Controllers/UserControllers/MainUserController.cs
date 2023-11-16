using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Interfaces.IViews;
using CinemaApp.Views;

namespace CinemaApp.Controllers.UserControllers
{
    public class MainUserController
    {
        private IMovieRepository movieRepository;
        private IReservationRepository reservationRepository;
        private IUserView userView;
        public MainUserController(IMovieRepository movieRepository, IReservationRepository reservationRepository)
        {
            this.movieRepository = movieRepository;
            this.reservationRepository = reservationRepository;
            userView = new UserView();    
        }

        public void Run()
        {
            // Sprawdzenie czy istnieją odwołane lub zmodyfikowane rezerwacje

            List<string> info_about_deleted_movies = new List<string>();
            List<string> info_about_modificated_movies = new List<string>();
            try
            {
                info_about_deleted_movies = reservationRepository.CheckDeletedReservations();
            }
            catch (CannotReadFileException)
            {
                reservationRepository.CreateTempDeleteFile();
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
            try
            {
                
                info_about_modificated_movies = reservationRepository.CheckModificatedMoviesWithReservation();
            }
            catch (CannotReadFileException)
            {
                reservationRepository.CreateTempModificationFile();
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            int valueUserMenu = 0;
            userView.ClearConsole();

            userView.RenderMainFrame(Console.WindowWidth, Console.WindowHeight);

            if (info_about_deleted_movies.Any())
            {
                userView.SetInfoAboutDeletedOrModificatedReservations(info_about_deleted_movies);
            }
            if (info_about_modificated_movies.Any())
            {
                userView.SetInfoAboutDeletedOrModificatedReservations(info_about_modificated_movies);
            }
            userView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
            userView.PrintInputArt();

            while (valueUserMenu != 3)
            {

                valueUserMenu = userView.RenderMainUserView();

                switch (valueUserMenu)
                {
                    // Przejście do widoku przeglądania filmów / dokonania rezerwacji
                    case 1: 
                        {

                            UserMoviesController userMoviesController = new UserMoviesController(movieRepository, reservationRepository, userView);
                            userMoviesController.Run();
                            break;
                        }

                    // Przejście do widoku przeglądania rezerwacji
                    case 2: 
                        {
                            UserReservationsController userReservationsController = new UserReservationsController(reservationRepository, userView);
                            userReservationsController.Run();
                            break;
                        }
                }
            }
        }

    }
}