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
            // To do optymalizacji - dodać w inna metode która zwraca 
            List<string> info_about_deleted_movies = new List<string>();
            List<string> info_about_modificated_movies = new List<string>();
            try
            {
                info_about_deleted_movies = reservationRepository.CheckDeletedReservations();
                info_about_modificated_movies = reservationRepository.CheckModificatedMoviesWithReservation();
            }
            catch (CannotReadFileException CRFE)
            {
                userView.ClearConsole();
                userView.RenderMainFrame(Console.WindowWidth, Console.WindowHeight);
                userView.ShowSuccessOrException("[!] " + CRFE.Message);
                //break;
                return;
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }



            int valueUserMenu = 0;
            userView.ClearConsole();

            //int a = info_about_deleted_movies.Count;
            userView.RenderMainFrame(Console.WindowWidth, Console.WindowHeight);



            //userView.RenderMainUserView();

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

            //FilteredList = false;

            while (valueUserMenu != 3)
            {

                valueUserMenu = userView.RenderMainUserView();

                switch (valueUserMenu)
                {
                    case 1: // Przeglądaj filmy / Dokonaj rezerwacji
                        {

                            UserMoviesController userMoviesController = new UserMoviesController(movieRepository, reservationRepository, userView);
                            userMoviesController.Run();
                            //UserMoviesController.Run();
                            break;
                        }
                    case 2: // Przeglądaj rezerwacje
                        {
                            UserReservationsController userReservationsController = new UserReservationsController(reservationRepository, userView);
                            userReservationsController.Run();
                            //UserReservationsController.Run();
                            break;
                        }
                }
            }
        }

    }
}
