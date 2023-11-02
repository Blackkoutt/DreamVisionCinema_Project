using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Interfaces.IViews;
using CinemaApp.Model;

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

                //break;
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
                //List<Movie> movies = movieRepository.GetAllMovies();
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
                    case 1: // Scroll Down
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
                            MakeReservation();
                            break;
                        }
                    case 4:
                        {
                            FilterList();
                            break;
                        }
                    case 5:
                        {
                            SortASC();
                            break;
                        }
                    case 6:
                        {
                            SortDESC();
                            break;
                        }
                    case 7:
                        {
                            UnfilterList();
                            break;
                        }
                    case 8:
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
                userView.ScrollDown(filteredMovies);
            }
            else
            {
                userView.ScrollDown(movies);
            }
        }
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
        private void MakeReservation()
        {
            string id = userView.GetFilmId();
            if (id == null)
            {
                userView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                userView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                userView.PrintInputArt();
                return;
                //break;
            }
            Movie? movie = null;
            try
            {
                movie = movieRepository.GetOneMovie(id);
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
                userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
                //break;
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
                //break;
                return;
            }
            catch (NoMovieWithGivenIdException NMWGIE)
            {
                ExceptionOrSuccessHandler("[!] " + NMWGIE.Message);
                //break;
                return;
            }
            catch (NoSeatWithGivenNumberException NSWGNE)
            {
                ExceptionOrSuccessHandler("[!] " + NSWGNE.Message);
                userView.SetHowManyMoviesWereDisplayed();
                userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
                //break;
                return;
            }
            catch (SeatIsNotAvailableException SINAE)
            {
                ExceptionOrSuccessHandler("[!] " + SINAE.Message);
                userView.SetHowManyMoviesWereDisplayed();
                userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
                //break;
                return;
            }
            catch (Exception ex)
            {
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
            //ExceptionOrSuccessHandler("[V] Pomyślnie dokonano rezerwacji!");
            //ExceptionOrSuccessHandler("[V] Pomyślnie dokonano rezerwacji!");
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
            userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);

            // Drukowanie biletu

            // Pokazanie biletu



            //userView.SetHowManyMoviesWereDisplayed();
            //userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
        }
        private void FilterList()
        {
            string search = userView.FilterList();
            if (search == null)
            {
                userView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                userView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                userView.PrintInputArt();
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
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            ExceptionOrSuccessHandler("[V] Lista została przefiltrowana!");

            FilteredList = true;
            // Tutaj tak samo z 0 indexem i zerownanie licznika
            userView.SetHowManyMoviesWereDisplayed();
            userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
        }
        private void SortASC()
        {
            string attribute = userView.SortList();
            if (attribute == null)
            {
                userView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                userView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                userView.PrintInputArt();
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
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            ExceptionOrSuccessHandler("[V] Lista została posortowana!");

            FilteredList = true;

            userView.SetHowManyMoviesWereDisplayed();
            userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
        }
        private void SortDESC()
        {
            string attribute = userView.SortList();
            if (attribute == null)
            {
                userView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                userView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
                userView.PrintInputArt();
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
                userView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }

            ExceptionOrSuccessHandler("[V] Lista została posortowana!");

            FilteredList = true;

            userView.SetHowManyMoviesWereDisplayed();
            userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);

        }
        private void UnfilterList()
        {
            FilteredList = false;
            // Tutaj wyświetlenie listy filmów normalnie i też wyzerowanie licznika
            userView.SetHowManyMoviesWereDisplayed();
            userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
        }
        private void GoBack()
        {
            userView.ClearViewOptionsPart(Console.WindowWidth, Console.WindowHeight);
            userView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
        }

    }
}
