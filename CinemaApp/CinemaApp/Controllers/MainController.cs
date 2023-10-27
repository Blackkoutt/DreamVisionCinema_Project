using CinemaApp.Exceptions;
using CinemaApp.Model;
using CinemaApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Controllers
{
    public class MainController
    {
        public void Run()
        {
            MainMenuView mainMenuView = new MainMenuView();
            LoginView loginView = new LoginView();
            MovieRepository movieRepository = new MovieRepository();
            movieRepository.ReadMoviesFromFile();
            ReservationRepository reservationRepository = new ReservationRepository(movieRepository);
            reservationRepository.ReadReservationsFromFile();
            List<Movie> movies = new List<Movie>();
            AdminView adminView = new AdminView();
            UserView userView = new UserView();
            bool FilteredList;
            List<Movie> filteredMovies = new List<Movie>();
            while (true)
            {
                int valueMainMenu = mainMenuView.RenderMainMenu();
                switch (valueMainMenu)
                {
                    case 1: // Panel administratora
                        {
                            bool isLoginSuccesful = false;
                            string[] login_password;
                            while (!isLoginSuccesful)
                            {
                                login_password = loginView.RenderLoginView();
                                isLoginSuccesful = Login.SignIn(login_password[0], login_password[1]);
                                if (!isLoginSuccesful)
                                {
                                    loginView.PrintError();
                                }
                            }
                            int valueAdminMenu = 0;
                            FilteredList = false;
                            

                            adminView.ClearConsole();

                            // Tutaj wyswietlenie listy filmów
                            
                            while (valueAdminMenu != 6)
                            {
                                valueAdminMenu = adminView.RenderMainAdminView();
                                switch (valueAdminMenu)
                                {
                                    // Na poczatek scroll down 
                                    // Potem scroll up
                                    case 1:
                                        {
                                            try
                                            {
                                                movies = movieRepository.GetAllMovies();
                                                adminView.SetHowManyMoviesWereDisplayed();
                                                adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
                                            }
                                            catch(MovieListIsEmptyException MLIEE)
                                            {
                                                adminView.ShowSuccessOrException("[!] " + MLIEE.Message);
                                                break;
                                            }

                                            int valueAdminMovies = 0; 
                                            while(valueAdminMovies != 10)
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
                                                    case 1:
                                                        {
                                                            if (FilteredList)
                                                            {
                                                                adminView.ScrollDown(filteredMovies);
                                                            }
                                                            else
                                                            {
                                                                adminView.ScrollDown(movies);
                                                            }                                                          
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            if (FilteredList)
                                                            {
                                                                adminView.ScrollUp(filteredMovies);
                                                            }
                                                            else
                                                            {
                                                                adminView.ScrollUp(movies);
                                                            }
                                                            break;
                                                        }
                                                    case 3: // Dodanie filmu
                                                        {
                                                            string?[] movieData = adminView.AddMovie();
                                                            if(movieData == null){
                                                                break; 
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
                                                            catch(CannotConvertException CCE) 
                                                            {
                                                                adminView.ShowSuccessOrException("[!] "+CCE.Message);
                                                                break;
                                                            }
                                                            catch (IncorrectParametrException IPE)
                                                            {
                                                                adminView.ShowSuccessOrException("[!] " + IPE.Message);
                                                                break;
                                                            }
                                                            catch (NoRoomWithGivenNumberException NRWGNE)
                                                            {
                                                                adminView.ShowSuccessOrException("[!] " + NRWGNE.Message);
                                                                break;
                                                            }
                                                            catch (MoviesCollisionException MCE)
                                                            {
                                                                adminView.ShowSuccessOrException("[!] " + MCE.Message);
                                                                break;
                                                            }
                                                            string success_message = "[V] Pomyślnie dodano film do listy!";
                                                            adminView.ShowSuccessOrException(success_message);
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
                                                                adminView.ShowSuccessOrException("[!] " + MLIEE.Message);
                                                                break;
                                                            }
                                                            break;
                                                        }
                                                    case 4: // Usunięcie filmu
                                                        {
                                                            string id = adminView.RemoveMovie();
                                                            if(id == null)
                                                            {
                                                                break;
                                                            }
                                                            try
                                                            {
                                                                reservationRepository.RemoveMovieWithReservation(id);
                                                            }
                                                            catch (CannotConvertException CCE)
                                                            {
                                                                adminView.ShowSuccessOrException("[!] " + CCE.Message);
                                                                break;
                                                            }
                                                            catch (NoMovieWithGivenIdException NMWGIE)
                                                            {
                                                                adminView.ShowSuccessOrException("[!] " + NMWGIE.Message);
                                                                break;
                                                            }
                                                            catch (CannotDestroyTicketException CDTE)
                                                            {
                                                                adminView.ShowSuccessOrException("[!] " + CDTE.Message);
                                                                break;
                                                            }
                                                            string success_message = "[V] Pomyślnie usunięto film z listy!";
                                                            adminView.ShowSuccessOrException(success_message);
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
                                                                adminView.ShowSuccessOrException("[!] " + MLIEE.Message);
                                                                break;
                                                            }
                                                            break;
                                                        }
                                                    case 5: // Modyfikacja filmu
                                                        {
                                                            string?[] newMovieData = adminView.ModifyMovie();
                                                            if (newMovieData == null)
                                                            {
                                                                break;
                                                            }
                                                            string id = newMovieData[0];
                                                            string data = newMovieData[1];
                                                            string price = newMovieData[2];
                                                            string room_number = newMovieData[3];
                                                            if (id == "")
                                                            {
                                                                break;
                                                            }
                                                            if (price != "")
                                                            {
                                                                try 
                                                                {
                                                                    movieRepository.ModifyMoviePrice(id, price);
                                                                }
                                                                catch(CannotConvertException CCE) 
                                                                {
                                                                    adminView.ShowSuccessOrException("[!] " + CCE.Message);
                                                                    break;
                                                                }
                                                                catch (NoMovieWithGivenIdException NMWGIE)
                                                                {
                                                                    adminView.ShowSuccessOrException("[!] " + NMWGIE.Message);
                                                                    break;
                                                                }
                                                            }
                                                            if(data!="" || room_number != "")
                                                            {
                                                                try
                                                                {
                                                                    reservationRepository.ModifyMovieDateOrRoomWithReservation(id, data, room_number);
                                                                }
                                                                catch (CannotConvertException CCE)
                                                                {
                                                                    adminView.ShowSuccessOrException("[!] " + CCE.Message);
                                                                    break;
                                                                }
                                                                catch (NoMovieWithGivenIdException NMWGIE)
                                                                {
                                                                    adminView.ShowSuccessOrException("[!] " + NMWGIE.Message);
                                                                    break;
                                                                }
                                                                catch (MoviesCollisionException MCE)
                                                                {
                                                                    adminView.ShowSuccessOrException("[!] " + MCE.Message);
                                                                    break;
                                                                }
                                                                catch (NoRoomWithGivenNumberException NRWGNE)
                                                                {
                                                                    adminView.ShowSuccessOrException("[!] " + NRWGNE.Message);
                                                                    break;
                                                                }
                                                                catch (CannotDestroyTicketException CDTE)
                                                                {
                                                                    adminView.ShowSuccessOrException("[!] " + CDTE.Message);
                                                                    break;
                                                                }
                                                            }
                                                            string success_message = "[V] Pomyślnie zmodyfikowano film!";
                                                            adminView.ShowSuccessOrException(success_message);
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
                                                                adminView.ShowSuccessOrException("[!] " + MLIEE.Message);
                                                                break;
                                                            }
                                                            break;
                                                        }
                                                    case 6: // Filtrowanie
                                                        {
                                                            string search = adminView.FilterList();
                                                            if(search == null || search == "") 
                                                            {
                                                                break;
                                                            }
                                                            //List<Movie> filtered_list = new List<Movie>();
                                                            try
                                                            {
                                                                filteredMovies = movieRepository.FilterList(search);
                                                                // Show movies z filtered Movies i indexem 0
                                                                // do tego ustawienie od nowa licznika tak jak niżej
                                                            }
                                                            catch(CannotFindMatchingMovieException CFMME)
                                                            {
                                                                adminView.ShowSuccessOrException("[!] " + CFMME.Message);
                                                                break;
                                                            }
                                                            string success_message = "[V] Lista została przefiltrowana!";
                                                            adminView.ShowSuccessOrException(success_message);
                                                            FilteredList = true;
                                                            // Tutaj tak samo z 0 indexem i zerownanie licznika
                                                            adminView.SetHowManyMoviesWereDisplayed();
                                                            adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
                                                            break;
                                                        }
                                                    case 7: // Sortowanie rosnąco
                                                        {
                                                            string attribute = adminView.SortList();
                                                            if (attribute==null ||attribute == "")
                                                            {
                                                                break;
                                                            }
                                                            try
                                                            {
                                                                filteredMovies = movieRepository.SortAscending(attribute);
                                                                // Show movies z filtered Movies i indexem 0
                                                                // do tego ustawienie od nowa licznika tak jak niżej
                                                            }
                                                            catch (BadAttributeException BAE)
                                                            {
                                                                adminView.ShowSuccessOrException("[!] " + BAE.Message);
                                                                break;
                                                            }
                                                            catch (ListIsEmptyException LIEE)
                                                            {
                                                                adminView.ShowSuccessOrException("[!] " + LIEE.Message);
                                                                break;
                                                            }
                                                            

                                                            string success_message = "[V] Lista została przefiltrowana!";
                                                            adminView.ShowSuccessOrException(success_message);
                                                            FilteredList = true;
                                                            // do tego ustawienie od nowa licznika tak jak niżej
                                                            adminView.SetHowManyMoviesWereDisplayed();
                                                            adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
                                                            break;
                                                        }
                                                    case 8: // Sortowanie malejąco
                                                        {
                                                            string attribute = adminView.SortList();
                                                            if (attribute == null || attribute == "")
                                                            {
                                                                break;
                                                            }
                                                            try
                                                            {
                                                                filteredMovies = movieRepository.SortDescending(attribute);
                                                                // Show movies z filtered Movies i indexem 0
                                                                // do tego ustawienie od nowa licznika tak jak niżej
                                                            }
                                                            catch (BadAttributeException BAE)
                                                            {
                                                                adminView.ShowSuccessOrException("[!] " + BAE.Message);
                                                                break;
                                                            }
                                                            catch (ListIsEmptyException LIEE)
                                                            {
                                                                adminView.ShowSuccessOrException("[!] " + LIEE.Message);
                                                                break;
                                                            }
                                                            string success_message = "[V] Lista została przefiltrowana!";
                                                            adminView.ShowSuccessOrException(success_message);
                                                            FilteredList = true;

                                                            adminView.SetHowManyMoviesWereDisplayed();
                                                            adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
                                                            break;
                                                        }
                                                    case 9:
                                                        {
                                                            FilteredList = false;
                                                            // Tutaj wyświetlenie listy filmów normalnie i też wyzerowanie licznika
                                                            adminView.SetHowManyMoviesWereDisplayed();
                                                            adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
                                                            break;
                                                        }
                                                    case 10:
                                                        {
                                                            adminView.ClearViewOptionsPart(Console.WindowWidth, Console.WindowHeight);
                                                            adminView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
                                                            break;
                                                        }

                                                }
                                            }
                                            break;
                                        }
                                    case 2: // Lista rezerwacji
                                        {
                                            List<Reservation> res = new List<Reservation>();
                                            try
                                            {
                                                res = reservationRepository.GetReservationsList();
                                                adminView.SetHowManyResWereDisplayed();
                                                adminView.ShowReservationList(res, 0);
                                            }
                                            catch (ReservationListIsEmptyException RLIEE)
                                            {
                                                adminView.ShowSuccessOrException("[!] " + RLIEE.Message);
                                                break;
                                            }
                                            
                                            break;
                                        }
                                    case 3:
                                        {
                                            List<Reservation> res = new List<Reservation>();
                                            try
                                            {
                                                res = reservationRepository.GetReservationsList();
                                                adminView.ScrollDown(res);
                                            }
                                            catch (ReservationListIsEmptyException RLIEE)
                                            {
                                                adminView.ShowSuccessOrException("[!] " + RLIEE.Message);
                                                break;
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            List<Reservation> res = new List<Reservation>();
                                            try
                                            {
                                                res = reservationRepository.GetReservationsList();
                                                adminView.ScrollUp(res);
                                            }
                                            catch (ReservationListIsEmptyException RLIEE)
                                            {
                                                adminView.ShowSuccessOrException("[!] " + RLIEE.Message);
                                                break;
                                            }
                                            break;
                                        }
                                    case 5: // Statystyki
                                        {
                                            int valueStatisticsAdminOptions = 0; 
                                            while (valueStatisticsAdminOptions != 4)
                                            {
                                                valueStatisticsAdminOptions = adminView.RenderStatisticsAdminView();
                                                switch (valueStatisticsAdminOptions)
                                                {
                                                    case 1: 
                                                        {
                                                            double income = reservationRepository.GetTotalIncome();
                                                            adminView.ShowTotalIncome(income);
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            Dictionary<string, double> movies_income = new Dictionary<string, double>();
                                                            try
                                                            {
                                                                movies_income = reservationRepository.GetMoviesIncome();
                                                                adminView.ShowMoviesIncome(movies_income);
                                                            }
                                                            catch (ListIsEmptyException LIEE)
                                                            {
                                                                adminView.ShowSuccessOrException("[!] " + LIEE.Message);
                                                                break;
                                                            }
                                                            
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            Dictionary<string, int> popular_movies = new Dictionary<string, int>();
                                                            try
                                                            {
                                                                popular_movies = reservationRepository.GetMostPopularMovies();
                                                                adminView.ShowMostPopularMovies(popular_movies);
                                                            }
                                                            catch (ListIsEmptyException LIEE)
                                                            {
                                                                adminView.ShowSuccessOrException("[!] " + LIEE.Message);
                                                                break;
                                                            }
                                                            
                                                            break;
                                                        }
                                                    case 4:
                                                        {
                                                            //adminView.ClearConsole();
                                                            adminView.ClearViewOptionsPart(Console.WindowWidth, Console.WindowHeight);
                                                            adminView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
                                                            break;
                                                        }
                                                }
                                            }

                                            break;
                                        }
                                   /* case 4:
                                        {
                                            adminView.ClearConsole();
                                            break;
                                        }*/
                                }
                            }

                            //Thread.Sleep(1000);
                            //adminView.ClearViewOptionsPart();
                            break;
                        }
                    case 2: // Panel użytkownika
                        {
                            List<string> info = reservationRepository.CheckDeletedReservations();

                            //List<Reservation> res = reservationRepository.GetReservationsList();
                            int valueUserMenu = 0;
                            userView.ClearConsole();

                            FilteredList = false;



                            while (valueUserMenu != 3)
                            {
                                if (info.Any())
                                {
                                    userView.SetInfoAboutDeletedReservations(info);
                                }                                
                                valueUserMenu = userView.RenderMainUserView();

                                switch (valueUserMenu)
                                {
                                    case 1: // Przeglądaj filmy / Dokonaj rezerwacji
                                        {
                                            try
                                            {
                                                movies = movieRepository.GetAllMovies();
                                                userView.SetHowManyMoviesWereDisplayed();
                                                userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
                                            }
                                            catch (MovieListIsEmptyException MLIEE)
                                            {
                                                userView.ShowSuccessOrException("[!] " + MLIEE.Message);
                                                break;
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
                                                    case 1: // Scroll down
                                                        {
                                                            if (FilteredList)
                                                            {
                                                                userView.ScrollDown(filteredMovies);
                                                            }
                                                            else
                                                            {
                                                                userView.ScrollDown(movies);
                                                            }
                                                            break;
                                                        }
                                                    case 2: // Scroll up
                                                        {
                                                            if (FilteredList)
                                                            {
                                                                userView.ScrollUp(filteredMovies);
                                                            }
                                                            else
                                                            {
                                                                userView.ScrollUp(movies);
                                                            }
                                                            break;
                                                        }
                                                    case 3: // Dokonanie rezerwacji
                                                        {
                                                            string id = userView.GetFilmId();
                                                            if (id == null)
                                                            {
                                                                break;
                                                            }
                                                            Movie movie;
                                                            try
                                                            {
                                                                movie = movieRepository.GetOneMovie(id);
                                                            }
                                                            catch (CannotConvertException CCE)
                                                            {
                                                                userView.ShowSuccessOrException("[!] " + CCE.Message);
                                                                break;
                                                            }
                                                            catch(NoMovieWithGivenIdException NMWGIE)
                                                            {
                                                                userView.ShowSuccessOrException("[!] " + NMWGIE.Message);
                                                                break;
                                                            }
                                                            userView.MakeReservation(movie);
                                                            

                                                            break;
                                                        }
                                                    case 4: //Wyszukiwanie
                                                        {
                                                            string search = userView.FilterList();
                                                            if (search == null || search == "")
                                                            {
                                                                break;
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
                                                                userView.ShowSuccessOrException("[!] " + CFMME.Message);
                                                                break;
                                                            }
                                                            string success_message = "[V] Lista została przefiltrowana!";
                                                            userView.ShowSuccessOrException(success_message);
                                                            FilteredList = true;
                                                            // Tutaj tak samo z 0 indexem i zerownanie licznika
                                                            userView.SetHowManyMoviesWereDisplayed();
                                                            userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
                                                            break;
                                                        }
                                                    case 5: // Sortowanie rosnąco
                                                        {
                                                            string attribute = userView.SortList();
                                                            if (attribute == null || attribute == "")
                                                            {
                                                                break;
                                                            }
                                                            try
                                                            {
                                                                filteredMovies = movieRepository.SortAscending(attribute);
                                                                // Show movies z filtered Movies i indexem 0
                                                                // do tego ustawienie od nowa licznika tak jak niżej
                                                            }
                                                            catch (BadAttributeException BAE)
                                                            {
                                                                userView.ShowSuccessOrException("[!] " + BAE.Message);
                                                                break;
                                                            }
                                                            catch (ListIsEmptyException LIEE)
                                                            {
                                                                userView.ShowSuccessOrException("[!] " + LIEE.Message);
                                                                break;
                                                            }


                                                            string success_message = "[V] Lista została przefiltrowana!";
                                                            userView.ShowSuccessOrException(success_message);
                                                            FilteredList = true;
                                                            // do tego ustawienie od nowa licznika tak jak niżej
                                                            userView.SetHowManyMoviesWereDisplayed();
                                                            userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
                                                            break;
                                                        }
                                                    case 6: // Sortowanie malejąco
                                                        {
                                                            string attribute = userView.SortList();
                                                            if (attribute == null || attribute == "")
                                                            {
                                                                break;
                                                            }
                                                            try
                                                            {
                                                                filteredMovies = movieRepository.SortDescending(attribute);
                                                                // Show movies z filtered Movies i indexem 0
                                                                // do tego ustawienie od nowa licznika tak jak niżej
                                                            }
                                                            catch (BadAttributeException BAE)
                                                            {
                                                                userView.ShowSuccessOrException("[!] " + BAE.Message);
                                                                break;
                                                            }
                                                            catch (ListIsEmptyException LIEE)
                                                            {
                                                                userView.ShowSuccessOrException("[!] " + LIEE.Message);
                                                                break;
                                                            }
                                                            string success_message = "[V] Lista została przefiltrowana!";
                                                            userView.ShowSuccessOrException(success_message);
                                                            FilteredList = true;

                                                            userView.SetHowManyMoviesWereDisplayed();
                                                            userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, filteredMovies, 0);
                                                            break;
                                                        }
                                                    case 7: // Usuń filtry
                                                        {
                                                            FilteredList = false;
                                                            // Tutaj wyświetlenie listy filmów normalnie i też wyzerowanie licznika
                                                            userView.SetHowManyMoviesWereDisplayed();
                                                            userView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
                                                            break;
                                                        }
                                                    case 8:
                                                        {
                                                            userView.ClearViewOptionsPart(Console.WindowWidth, Console.WindowHeight);
                                                            userView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
                                                            break;
                                                        }
                                                }
                                            }

                                            break;
                                        }
                                    case 2: // Przeglądaj rezerwacje
                                        {
                                            List<Reservation> res = new List<Reservation>();
                                            try
                                            {
                                                res = reservationRepository.GetReservationsList();
                                                userView.SetHowManyResWereDisplayed();
                                                userView.ShowReservationList(res, 0);
                                            }
                                            catch (ReservationListIsEmptyException RLIEE)
                                            {
                                                userView.ShowSuccessOrException("[!] " + RLIEE.Message);
                                                break;
                                            }
                                           // userView.ClearConsole();
                                            int valueUserReservations = 0;
                                            while (valueUserReservations != 4)
                                            {
                                                valueUserReservations = userView.RenderReservationsUserView(res);
                                                //List<Movie> movies = movieRepository.GetAllMovies();

                                                switch (valueUserReservations)
                                                {
                                                    case 1: // Scroll Down
                                                        {
                                                            userView.ScrollDown(res);
                                                            break;
                                                        }
                                                    case 2: // Scroll Up
                                                        {
                                                            userView.ScrollUp(res);
                                                            break;
                                                        }
                                                    case 3: // Anulowanie rezerwacji
                                                        {
                                                            string id = userView.RemoveReservation();
                                                            try
                                                            {
                                                                reservationRepository.DeleteReservation(id);
                                                            }
                                                            catch (CannotConvertException CCE)
                                                            {
                                                                userView.ShowSuccessOrException("[!] " + CCE.Message);
                                                                break;
                                                            }
                                                            catch (NoReservationWithGivenIdException NRWGIE)
                                                            {
                                                                userView.ShowSuccessOrException("[!] " + NRWGIE.Message);
                                                                break;
                                                            }
                                                            catch (CannotDestroyTicketException CDTE)
                                                            {
                                                                userView.ShowSuccessOrException("[!] " + CDTE.Message);
                                                                break;
                                                            }
                                                            string success_message = "[V] Pomyślnie anulowano rezerwację.";
                                                            userView.ShowSuccessOrException(success_message);
                                                            userView.SetHowManyResWereDisplayed();
                                                            userView.ShowReservationList(res, 0);
                                                            break;
                                                        }
                                                    case 4: //Powrót
                                                        {
                                                            userView.ClearViewOptionsPart(Console.WindowWidth, Console.WindowHeight);
                                                            userView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
                                                            break;
                                                        }
                                                }
                                            }

                                            break;
                                        }
                                }
                            }


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
