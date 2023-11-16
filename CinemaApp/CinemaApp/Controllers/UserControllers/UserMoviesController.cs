using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Interfaces.IViews;
using CinemaApp.Model;
using CinemaApp.Views;

namespace CinemaApp.Controllers.UserControllers
{
    public class UserMoviesController
    {
        private IUserView userView;
        private IMovieRepository movieRepository;
        private IReservationRepository reservationRepository;
        private List<Movie> movies;
        private List<Movie> filteredMovies;
        
        private bool FilteredList;
        public UserMoviesController(IMovieRepository movieRepository, IReservationRepository reservationRepository, IUserView userView)
        {
            this.movieRepository = movieRepository;
            this.reservationRepository = reservationRepository;
            this.userView = userView;
            movies = new List<Movie>();
            filteredMovies = new List<Movie>();
            FilteredList = false;
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
                movies = movieRepository.GetAllMovies();
                userView.SetHowManyMoviesWereDisplayed();
                userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                return;
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            int valueUserMovies = 0;
            while (valueUserMovies != 8)
            {
                if (FilteredList)
                {
                    valueUserMovies = userView.RenderMoviesUserView(filteredMovies);
                }
                else
                {
                    valueUserMovies = userView.RenderMoviesUserView(movies);
                }
                switch (valueUserMovies)
                {
                    // Przewijanie listy filmów do dołu
                    case 1:
                        {
                            ScrollDown();
                            break;
                        }

                    // Przewijanie listy filmów do góry
                    case 2:
                        {
                            ScrollUp();
                            break;
                        }

                    // Przejście do widoku dokonywania rezerwacji
                    case 3:
                        {
                            MakeReservation();
                            break;
                        }

                    // Filtrowanie listy filmów
                    case 4:
                        {
                            FilterList();
                            break;
                        }

                    // Sortowanie rosnąco listy filmów
                    case 5:
                        {
                            SortASC();
                            break;
                        }

                    // Sortowanie malejąco listy filmów
                    case 6:
                        {
                            SortDESC();
                            break;
                        }

                    // Usunięcie filtrów
                    case 7:
                        {
                            UnfilterList();
                            break;
                        }

                    // Powrót do poprzedniego widoku
                    case 8:
                        {
                            GoBack();
                            break;
                        }
                }
            }
        }

        
        // Metoda przewijająca listę filmów do dołu
        private void ScrollDown()
        {
            if (FilteredList)
            {
                userView.ScrollDown(filteredMovies);
            }
            else
            {
                userView.ScrollDown(movies);
            }
        }


        // Metoda przewijająca listę filmów do góry
        private void ScrollUp()
        {
            if (FilteredList)
            {
                userView.ScrollUp(filteredMovies);
            }
            else
            {
                userView.ScrollUp(movies);
            }
        }


        // Metoda dokonująca rezerwacji (pobranie od użytkownika id oraz miejsc i wywołanie metody dokonującej rezerwcacji a także wyświetlenie biletu)
        private void MakeReservation()
        {
            string id = userView.GetFilmId();
            if (id == null)
            {
                userView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                userView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                userView.PrintInputArt();
                return;
            }
            Movie? movie = null;
            try
            {
                movie = movieRepository.GetOneMovie(id);
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
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            string seats = userView.MakeReservation(movie);
            if (seats == null || seats == "")
            {
                userView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                userView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                userView.PrintInputArt();
                userView.SetHowManyMoviesWereDisplayed();
                try
                {
                    userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
                }
                catch (MovieListIsEmptyException MLIEE)
                {
                    ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                    return;
                }
                catch (Exception ex)
                {
                    userView.PrintUnknownErrorInfo(ex.Message);
                    Environment.Exit(1);
                }
                return;
            }

            List<string> Seats = seats.Split(' ').ToList();
            try
            {
                reservationRepository.MakeReservation(null, movie.Id.ToString(), Seats);
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
            catch (NoSeatWithGivenNumberException NSWGNE)
            {
                ExceptionOrSuccessHandler("[!] " + NSWGNE.Message);
                userView.SetHowManyMoviesWereDisplayed();
                try
                {
                    userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
                }
                catch (MovieListIsEmptyException MLIEE)
                {
                    ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                    return;
                }
                catch (Exception ex)
                {
                    userView.PrintUnknownErrorInfo(ex.Message);
                    Environment.Exit(1);
                }
                return;
            }
            catch (SeatIsNotAvailableException SINAE)
            {
                ExceptionOrSuccessHandler("[!] " + SINAE.Message);
                userView.SetHowManyMoviesWereDisplayed();
                try
                {
                    userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
                }
                catch (MovieListIsEmptyException MLIEE)
                {
                    ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                    return;
                }
                catch (Exception ex)
                {
                    userView.PrintUnknownErrorInfo(ex.Message);
                    Environment.Exit(1);
                }
                return;
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
            string success_message = "[V] Pomyślnie dokonano rezerwacji!";
            userView.ShowSuccessOrException(success_message);

            userView.PrinterAnimation();

            string[] ticket = reservationRepository.GetTicket();
            userView.ShowTicket(ticket[0], ticket[1]);

            Console.ReadKey();
            Console.Clear();
            userView.RenderMainFrame(Console.WindowWidth, Console.WindowHeight);
            userView.PrintInputArt();
            userView.SetHowManyMoviesWereDisplayed();
            try
            {
                userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                return;
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
        }


        // Metoda filtrująca listę filmów (pobranie frazy od użytkownika i uruchomienie metody wyszukującej filmy zawierające dana frazę)
        private void FilterList()
        {
            string search = userView.FilterList();
            if (search == null)
            {
                userView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                userView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                userView.PrintInputArt();
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
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            ExceptionOrSuccessHandler("[V] Lista została przefiltrowana!");

            FilteredList = true;
            userView.SetHowManyMoviesWereDisplayed();

            try
            {
                userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                return;
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
        }



        // Metoda sortująca rosnąco listę filmów (pobranie atrybutu od użytkownika i uruchomienie metody sortującej listę według podanego parametru)
        private void SortASC()
        {
            string attribute = userView.SortList();
            if (attribute == null)
            {
                userView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                userView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                userView.PrintInputArt();
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
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            ExceptionOrSuccessHandler("[V] Lista została posortowana!");

            FilteredList = true;

            userView.SetHowManyMoviesWereDisplayed();
            try
            {
                userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                return;
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
        }



        // Metoda sortująca malejąco listę filmów (pobranie atrybutu od użytkownika i uruchomienie metody sortującej listę według podanego parametru)
        private void SortDESC()
        {
            string attribute = userView.SortList();
            if (attribute == null)
            {
                userView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                userView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                userView.PrintInputArt();
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
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            ExceptionOrSuccessHandler("[V] Lista została posortowana!");

            FilteredList = true;

            userView.SetHowManyMoviesWereDisplayed();
            try
            {
                userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
                return;
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
        }


        // Metoda usuwająca filtry 
        private void UnfilterList()
        {
            FilteredList = false;

            userView.SetHowManyMoviesWereDisplayed();
            try
            {
                userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                ExceptionOrSuccessHandler("[!] " + MLIEE.Message);
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