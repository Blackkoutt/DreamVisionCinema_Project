using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Interfaces.IViews;
using CinemaApp.Model;

namespace CinemaApp.Controllers.AdminControllers
{
    public class AdminMoviesController
    {
        // To bedzie raz utworzone i wstrzykiwane przez konstruktor jako interfejs
        private IAdminView adminView;
        private IMovieRepository movieRepository;
        private IReservationRepository reservationRepository;
        private List<Movie> movies;
        private List<Movie> filteredMovies;

        private bool FilteredList;

        public AdminMoviesController(IMovieRepository movieRepository, IReservationRepository reservationRepository, IAdminView adminView)
        {
            //adminView = new AdminView();
            this.adminView = adminView;
            this.movieRepository = movieRepository;
            this.reservationRepository = reservationRepository;

            movies = new List<Movie>();
            filteredMovies = new List<Movie>();
            //movieRepository = new MovieRepository();
            //reservationRepository = new ReservationRepository(movieRepository);
            FilteredList = false;
        }
        private void ExceptionOrSuccessHandler(string message)
        {
            adminView.ShowSuccessOrException(message);
            adminView.PrintInputArt();
        }
        public void Run()
        {
            adminView.ClearViewOptionsPart(Console.WindowWidth, Console.WindowHeight);
            try
            {
                movies = movieRepository.GetAllMovies();
                adminView.SetHowManyMoviesWereDisplayed();
                adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                adminView.ShowSuccessOrException("[!] " + MLIEE.Message);
                //break;
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            //bool FilteredList = false;
            int valueAdminMovies = 0;
            while (valueAdminMovies != 10)
            {
                //List<Movie> movies = movieRepository.GetAllMovies();
                if (FilteredList)
                {
                    valueAdminMovies = adminView.RenderMoviesAdminView(filteredMovies);
                }
                else
                {
                    valueAdminMovies = adminView.RenderMoviesAdminView(movies);
                }
                switch (valueAdminMovies)
                {
                    case 1: // Scroll Down
                        {
                            ScrollDown();
                            break;
                        }
                    case 2: // Scroll Up
                        {
                            ScrollUp();
                            break;
                        }
                    case 3: // Add Movie
                        {
                            AddMovie();
                            break;
                        }
                    case 4: // Delete Movie
                        {
                            RemoveMovie();
                            break;
                        }
                    case 5: // Modify Movie
                        {
                            ModifyMovie();
                            break;
                        }
                    case 6: // Filter Movie List
                        {
                            FilterList();
                            break;
                        }
                    case 7: // Sort ASC
                        {
                            SortASC();
                            break;
                        }
                    case 8: // Sort DESC
                        {
                            SortDESC();
                            break;
                        }
                    case 9: // Unfilter List
                        {
                            UnfilterList();
                            break;
                        }
                    case 10: // Back
                        {
                            GoBack();
                            break;
                        }
                }
            }
        }
        private void ScrollDown()
        {
            if (FilteredList)
            {
                adminView.ScrollDown(filteredMovies);
            }
            else
            {
                adminView.ScrollDown(movies);
            }
        }
        private void ScrollUp()
        {
            if (FilteredList)
            {
                adminView.ScrollUp(filteredMovies);
            }
            else
            {
                adminView.ScrollUp(movies);
            }
        }
        private void AddMovie()
        {
            string?[] movieData = adminView.AddMovie();
            if (movieData == null)
            {
                adminView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                adminView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                adminView.PrintInputArt();
                return;
            }
            string title = movieData[0];
            string date = movieData[1];
            string price = movieData[2];
            string duration = movieData[3];
            string roomNumber = movieData[4];
            try
            {
                movieRepository.AddMovie(null, title, date, price, duration, roomNumber);
            }
            catch (CannotConvertException CCE)
            {
                ExceptionOrSuccessHandler("[!] " + CCE.Message);
                return;
            }
            catch (IncorrectParametrException IPE)
            {
                ExceptionOrSuccessHandler("[!] " + IPE.Message);
                return;
            }
            catch (NoRoomWithGivenNumberException NRWGNE)
            {
                ExceptionOrSuccessHandler("[!] " + NRWGNE.Message);
                return;
            }
            catch (MoviesCollisionException MCE)
            {
                ExceptionOrSuccessHandler("[!] " + MCE.Message);
                return;
            }
            catch(Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            ExceptionOrSuccessHandler("[V] Pomyślnie dodano film do listy!");


            try
            {
                movies = movieRepository.GetAllMovies();
                adminView.SetHowManyMoviesWereDisplayed();
                adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                //break;
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
        }
        private void RemoveMovie()
        {
            string? id = adminView.RemoveMovie();
            if (id == null)
            {

                adminView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                adminView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                adminView.PrintInputArt();
                //break;
                return;
            }
            try
            {
                reservationRepository.RemoveMovieWithReservation(id);
            }
            catch (CannotConvertException CCE)
            {
                ExceptionOrSuccessHandler("[!] " + CCE.Message);
                //break;
                return;
            }
            catch (NoMovieWithGivenIdException NMWGIE)
            {
                ExceptionOrSuccessHandler("[!] " + NMWGIE.Message);
                //break;
                return;
            }
            catch (CannotDestroyTicketException CDTE)
            {
                ExceptionOrSuccessHandler("[!] " + CDTE.Message);
                //break;
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            ExceptionOrSuccessHandler("[V] Pomyślnie usunięto film z listy!");

            // Tutaj jeszcze na nowo pobranie listy filmów tak aby ją zaktualizować
            // I zerowanie indexu i licznika
            // I na nowo wyświetelnie listy filmów
            try
            {
                movies = movieRepository.GetAllMovies();
                adminView.SetHowManyMoviesWereDisplayed();
                adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                //break;
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
        }
        private void ModifyMovie()
        {
            string?[] newMovieData = adminView.ModifyMovie();
            if (newMovieData == null)
            {
                adminView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                adminView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                adminView.PrintInputArt();
                //break;
                return;
            }
            string id = newMovieData[0];
            string data = newMovieData[1];
            string price = newMovieData[2];
            string room_number = newMovieData[3];
            if (id == "")
            {
                ExceptionOrSuccessHandler("[!] Należy podać ID filmu.");
                //break;
                return;
            }
            if (price == "" && data == "" && room_number == "")
            {
                ExceptionOrSuccessHandler("[!] Należy podać nową cenę lub datę lub numer sali, aby zmodyfikować film.");
                //break;
                return;
            }
            if (price != "")
            {
                try
                {
                    movieRepository.ModifyMoviePrice(id, price);
                }
                catch (CannotConvertException CCE)
                {
                    ExceptionOrSuccessHandler("[!] " + CCE.Message);
                    //break;
                    return;
                }
                catch (IncorrectParametrException IPE)
                {
                    ExceptionOrSuccessHandler("[!] " + IPE.Message);
                    //break;
                    return;
                }
                catch (NoMovieWithGivenIdException NMWGIE)
                {
                    ExceptionOrSuccessHandler("[!] " + NMWGIE.Message);
                    //break;
                    return;
                }
                catch (Exception ex)
                {
                    adminView.PrintUnknownErrorInfo(ex.Message);
                    Environment.Exit(1);
                }
            }
            if (data != "" || room_number != "")
            {
                try
                {
                    reservationRepository.ModifyMovieDateOrRoomWithReservation(id, data, room_number);
                }
                catch (CannotConvertException CCE)
                {
                    ExceptionOrSuccessHandler("[!] " + CCE.Message);
                    //break;
                    return;
                }
                catch (NoMovieWithGivenIdException NMWGIE)
                {
                    ExceptionOrSuccessHandler("[!] " + NMWGIE.Message);
                    //break;
                    return;
                }
                catch (MoviesCollisionException MCE)
                {
                    ExceptionOrSuccessHandler("[!] " + MCE.Message);
                    //break;
                    return;
                }
                catch (NoRoomWithGivenNumberException NRWGNE)
                {
                    ExceptionOrSuccessHandler("[!] " + NRWGNE.Message);
                    //break;
                    return;
                }
                catch (CannotDestroyTicketException CDTE)
                {
                    ExceptionOrSuccessHandler("[!] " + CDTE.Message);
                    //break;
                    return;
                }
                catch (Exception ex)
                {
                    adminView.PrintUnknownErrorInfo(ex.Message);
                    Environment.Exit(1);
                }
            }
            ExceptionOrSuccessHandler("[V] Pomyślnie zmodyfikowano film!");
            // Tutaj jeszcze na nowo pobranie listy filmów tak aby ją zaktualizować
            // I zerowanie indexu i licznika
            // I na nowo wyświetelnie listy filmów
            try
            {
                movies = movieRepository.GetAllMovies();
                adminView.SetHowManyMoviesWereDisplayed();
                adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                //break;
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
        }
        private void FilterList()
        {
            string search = adminView.FilterList();
            if (search == null)
            {
                adminView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                adminView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                adminView.PrintInputArt();
                //break;
                return;
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                ExceptionOrSuccessHandler("[!] Fraza wyszukiwania nie może być pustym ciągiem znaków.");
                //break;
                return;
            }
            //List<Movie> filtered_list = new List<Movie>();
            try
            {
                filteredMovies = movieRepository.FilterList(search);
                // Show movies z filtered Movies i indexem 0
                // do tego ustawienie od nowa licznika tak jak niżej
            }
            catch (CannotFindMatchingMovieException CFMME)
            {
                ExceptionOrSuccessHandler("[!] " + CFMME.Message);
                //break;
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
            ExceptionOrSuccessHandler("[V] Lista została przefiltrowana!");

            FilteredList = true;
            // Tutaj tak samo z 0 indexem i zerownanie licznika
            adminView.SetHowManyMoviesWereDisplayed();
            adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
        }
        private void SortASC()
        {
            string attribute = adminView.SortList();
            if (attribute == null)
            {
                adminView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                adminView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                adminView.PrintInputArt();
                //break;
                return;
            }
            if (string.IsNullOrWhiteSpace(attribute))
            {
                ExceptionOrSuccessHandler("[!] Atrybut sortowania nie może być pustym ciągiem znaków.");
                //break;
                return;
            }
            try
            {
                filteredMovies = movieRepository.SortAscending(attribute);
                // Show movies z filtered Movies i indexem 0
                // do tego ustawienie od nowa licznika tak jak niżej
            }
            catch (BadAttributeException BAE)
            {
                ExceptionOrSuccessHandler("[!] " + BAE.Message);
                //break;
                return;
            }
            catch (ListIsEmptyException LIEE)
            {
                ExceptionOrSuccessHandler("[!] " + LIEE.Message);
                //break;
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            ExceptionOrSuccessHandler("[V] Lista została posortowana!");

            FilteredList = true;
            // do tego ustawienie od nowa licznika tak jak niżej
            adminView.SetHowManyMoviesWereDisplayed();
            adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
        }
        private void SortDESC()
        {
            string attribute = adminView.SortList();
            if (attribute == null)
            {
                adminView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                adminView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                adminView.PrintInputArt();
                //break;
                return;
            }
            if (string.IsNullOrWhiteSpace(attribute))
            {
                ExceptionOrSuccessHandler("[!] Atrybut sortowania nie może być pustym ciągiem znaków.");
                //break;
                return;
            }
            try
            {
                filteredMovies = movieRepository.SortDescending(attribute);
                // Show movies z filtered Movies i indexem 0
                // do tego ustawienie od nowa licznika tak jak niżej
            }
            catch (BadAttributeException BAE)
            {
                ExceptionOrSuccessHandler("[!] " + BAE.Message);
                //break;
                return;
            }
            catch (ListIsEmptyException LIEE)
            {
                ExceptionOrSuccessHandler("[!] " + LIEE.Message);
                //break;
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
            ExceptionOrSuccessHandler("[V] Lista została posortowana!");

            FilteredList = true;

            adminView.SetHowManyMoviesWereDisplayed();
            adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
        }
        private void UnfilterList()
        {
            FilteredList = false;
            // Tutaj wyświetlenie listy filmów normalnie i też wyzerowanie licznika
            adminView.SetHowManyMoviesWereDisplayed();
            adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
        }
        private void GoBack()
        {
            adminView.ClearViewOptionsPart(Console.WindowWidth, Console.WindowHeight);
            adminView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
        }
    }
}
