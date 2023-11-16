using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Interfaces.IViews;
using CinemaApp.Model;

namespace CinemaApp.Controllers.AdminControllers
{
    public class AdminMoviesController
    {
        private IAdminView adminView;
        private IMovieRepository movieRepository;
        private IReservationRepository reservationRepository;
        private List<Movie> movies;
        private List<Movie> filteredMovies;

        private bool FilteredList;

        public AdminMoviesController(IMovieRepository movieRepository, IReservationRepository reservationRepository, IAdminView adminView)
        {
            this.adminView = adminView;
            this.movieRepository = movieRepository;
            this.reservationRepository = reservationRepository;

            movies = new List<Movie>();
            filteredMovies = new List<Movie>();
            FilteredList = false;
        }

        // Metoda do wyświetlania informacji o powodzeniu i błędów
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
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            int valueAdminMovies = 0;
            while (valueAdminMovies != 10)
            {
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
                    // Scroll Down
                    case 1: 
                        {
                            ScrollDown();
                            break;
                        }

                    // Scroll Up
                    case 2: 
                        {
                            ScrollUp();
                            break;
                        }

                    // Dodanie filmu
                    case 3: 
                        {
                            AddMovie();
                            break;
                        }

                    // Usunięcie filmu
                    case 4: 
                        {
                            RemoveMovie();
                            break;
                        }

                    // Modyfikacja filmu
                    case 5: 
                        {
                            ModifyMovie();
                            break;
                        }

                    // Filtrowanie listy filmów
                    case 6: 
                        {
                            FilterList();
                            break;
                        }

                    // Sortowanie rosnąco
                    case 7: 
                        {
                            SortASC();
                            break;
                        }

                    // Sortowanie malejąco
                    case 8: 
                        {
                            SortDESC();
                            break;
                        }

                    // Usunięcie filtrów
                    case 9: 
                        {
                            UnfilterList();
                            break;
                        }

                    // Powrót do poprzedniego menu
                    case 10: 
                        {
                            GoBack();
                            break;
                        }
                }
            }
        }


        // Przewijanie listy do dołu
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


        // Przewijanie listy do góry
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


        // Dodawanie filmu (pobranie wartości z widoku i uruchomienie metody dodającej film do listy z pobranymi parametrami)
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
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
        }



        // Usunięcie filmu (pobranie id filmu z widoku i uruchomienie metody usuwającej film o podanym id)
        private void RemoveMovie()
        {
            string? id = adminView.RemoveMovie();
            if (id == null)
            {

                adminView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                adminView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                adminView.PrintInputArt();
                return;
            }
            try
            {
                reservationRepository.RemoveMovieWithReservation(id);
            }
            catch (CannotConvertException CCE)
            {
                ExceptionOrSuccessHandler("[!] " + CCE.Message);
                return;
            }
            catch (NoMovieWithGivenIdException NMWGIE)
            {
                ExceptionOrSuccessHandler("[!] " + NMWGIE.Message);
                return;
            }
            catch (CannotDestroyTicketException CDTE)
            {
                ExceptionOrSuccessHandler("[!] " + CDTE.Message);
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            ExceptionOrSuccessHandler("[V] Pomyślnie usunięto film z listy!");

            try
            {
                movies = movieRepository.GetAllMovies();
                adminView.SetHowManyMoviesWereDisplayed();
                adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                adminView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
        }



        // Modyfikacja filmu (pobranie wprowadzonych atrybutów filmu z widoku i uruchomienie metody modyfikującej film z podanymi parametrami)
        private void ModifyMovie()
        {
            string?[] newMovieData = adminView.ModifyMovie();
            if (newMovieData == null)
            {
                adminView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                adminView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                adminView.PrintInputArt();
                return;
            }
            string id = newMovieData[0];
            string data = newMovieData[1];
            string price = newMovieData[2];
            string room_number = newMovieData[3];
            if (id == "")
            {
                ExceptionOrSuccessHandler("[!] Należy podać ID filmu.");
                return;
            }
            if (price == "" && data == "" && room_number == "")
            {
                ExceptionOrSuccessHandler("[!] Należy podać nową cenę lub datę lub numer sali, aby zmodyfikować film.");
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
                    return;
                }
                catch (IncorrectParametrException IPE)
                {
                    ExceptionOrSuccessHandler("[!] " + IPE.Message);
                    return;
                }
                catch (NoMovieWithGivenIdException NMWGIE)
                {
                    ExceptionOrSuccessHandler("[!] " + NMWGIE.Message);
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
                    return;
                }
                catch (NoMovieWithGivenIdException NMWGIE)
                {
                    ExceptionOrSuccessHandler("[!] " + NMWGIE.Message);
                    return;
                }
                catch (MoviesCollisionException MCE)
                {
                    ExceptionOrSuccessHandler("[!] " + MCE.Message);
                    return;
                }
                catch (NoRoomWithGivenNumberException NRWGNE)
                {
                    ExceptionOrSuccessHandler("[!] " + NRWGNE.Message);
                    return;
                }
                catch (CannotDestroyTicketException CDTE)
                {
                    ExceptionOrSuccessHandler("[!] " + CDTE.Message);
                    return;
                }
                catch (Exception ex)
                {
                    adminView.PrintUnknownErrorInfo(ex.Message);
                    Environment.Exit(1);
                }
            }
            ExceptionOrSuccessHandler("[V] Pomyślnie zmodyfikowano film!");

            try
            {
                movies = movieRepository.GetAllMovies();
                adminView.SetHowManyMoviesWereDisplayed();
                adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
        }



        // Filtrowanie listy (pobranie wprowadzonej frazy z widoku i uruchomienie metody filtrującej listę)
        private void FilterList()
        {
            string search = adminView.FilterList();
            if (search == null)
            {
                adminView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                adminView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                adminView.PrintInputArt();
                return;
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                ExceptionOrSuccessHandler("[!] Fraza wyszukiwania nie może być pustym ciągiem znaków.");
                return;
            }
            try
            {
                filteredMovies = movieRepository.FilterList(search);
            }
            catch (CannotFindMatchingMovieException CFMME)
            {
                ExceptionOrSuccessHandler("[!] " + CFMME.Message);
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
            ExceptionOrSuccessHandler("[V] Lista została przefiltrowana!");

            FilteredList = true;
            adminView.SetHowManyMoviesWereDisplayed();
            try
            {
                adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
            }
            catch(MovieListIsEmptyException MLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

        }


        // Sortowanie rosnąco listy (pobranie wprowadzonego atrybutu z widoku i uruchomienie metody sortującej listę na podstawie danego parametru)
        private void SortASC()
        {
            string attribute = adminView.SortList();
            if (attribute == null)
            {
                adminView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                adminView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                adminView.PrintInputArt();
                return;
            }
            if (string.IsNullOrWhiteSpace(attribute))
            {
                ExceptionOrSuccessHandler("[!] Atrybut sortowania nie może być pustym ciągiem znaków.");
                return;
            }
            try
            {
                filteredMovies = movieRepository.SortAscending(attribute);
            }
            catch (BadAttributeException BAE)
            {
                ExceptionOrSuccessHandler("[!] " + BAE.Message);
                return;
            }
            catch (ListIsEmptyException LIEE)
            {
                ExceptionOrSuccessHandler("[!] " + LIEE.Message);
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
            try
            {
                adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
        }


        // Sortowanie malejąco listy (pobranie wprowadzonego atrybutu z widoku i uruchomienie metody sortującej listę na podstawie danego parametru)
        private void SortDESC()
        {
            string attribute = adminView.SortList();
            if (attribute == null)
            {
                adminView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                adminView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                adminView.PrintInputArt();
                return;
            }
            if (string.IsNullOrWhiteSpace(attribute))
            {
                ExceptionOrSuccessHandler("[!] Atrybut sortowania nie może być pustym ciągiem znaków.");
                return;
            }
            try
            {
                filteredMovies = movieRepository.SortDescending(attribute);
            }
            catch (BadAttributeException BAE)
            {
                ExceptionOrSuccessHandler("[!] " + BAE.Message);
                return;
            }
            catch (ListIsEmptyException LIEE)
            {
                ExceptionOrSuccessHandler("[!] " + LIEE.Message);
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
            try
            {
                adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
        }


        // Usunięcie filtrów 
        private void UnfilterList()
        {
            FilteredList = false;
            adminView.SetHowManyMoviesWereDisplayed();
            try
            {
                adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
        }


        // Powrót do poprzedniego widoku
        private void GoBack()
        {
            adminView.ClearViewOptionsPart(Console.WindowWidth, Console.WindowHeight);
            adminView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
        }
    }
}