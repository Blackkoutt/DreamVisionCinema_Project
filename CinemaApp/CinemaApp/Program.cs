using CinemaApp.Controllers;
using CinemaApp.Model;
using CinemaApp.Views;

class Program
{
    public static void Main(string[] args)
    {
        MainController controler = new MainController();
        controler.Run();
        /*MovieRepository movieRepository = new MovieRepository();
        movieRepository.ReadMoviesFromFile();
        AdminView adminView = new AdminView();

        List<Movie> movies = movieRepository.GetAllMovies();
        //int longestTitle = movieRepository.GetLongestTitle();
        int valueAdminMovies = 0;
        while (valueAdminMovies != 4)
        {
            valueAdminMovies = adminView.RenderMoviesAdminView(movies);
            switch (valueAdminMovies)
            {
                case 1:
                    {
                        string?[] movieData = adminView.AddMovie();
                        if (movieData == null)
                        {
                            //adminView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                            //Console.Clear();
                            break;
                        }
                        break;
                    }
            }
        }*/
        //Console.ForegroundColor = ConsoleColor.Black;
        //Console.BackgroundColor = ConsoleColor.White;
        //MainMenuView MMV = new MainMenuView();
        //MMV.RenderMainMenu();
        //LoginView loginView = new LoginView();
        //loginView.RenderLoginView();

        /*MovieRepository movieRepository = new MovieRepository();
        movieRepository.ReadMoviesFromFile();
        AdminView adminView = new AdminView();

        List<Movie> movies = movieRepository.GetAllMovies();
        adminView.RenderMainAdminView();
        adminView.RenderMoviesAdminView(movies);*/


        /*MainView mainView = new MainView();
        mainView.RenderMainFrame(Console.WindowWidth, Console.WindowHeight);
        mainView.ClearViewInputPart(Console.WindowWidth, Console.WindowHeight);
        mainView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
        mainView.ClearViewOptionsPart(Console.WindowWidth, Console.WindowHeight);
        mainView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);

        mainView.SetCursorInInputPart(Console.WindowWidth, Console.WindowHeight, 0, 1);
        Console.Write("Input");

        mainView.SetCursorInDataOutputPart(Console.WindowWidth, Console.WindowHeight, 0, 1);
        Console.Write("Data Output");

        mainView.SetCursorInOptionsPart(Console.WindowWidth, Console.WindowHeight, 0, 1);
        Console.Write("Options");

        mainView.SetCursorInInfoPart(Console.WindowWidth, Console.WindowHeight, 0, 1);
        Console.Write("Info");*/
        //AdminView adminView = new AdminView();
        //adminView.RenderAdminView();
        //Login login = new Login();
        //login.HashPassword();

        //Console.ReadKey();
        /*MovieRepository movies = new MovieRepository();
        movies.ReadMoviesFromFile();
        List<Movie> movies1 = movies.GetAllMovies();
        foreach (Movie movie in movies1)
        {
            Console.WriteLine($"{movie.Id} {movie.Title} {movie.Date} {movie.Price} {movie.Duration} {movie.Room.Number}");
        }
        Console.WriteLine();
        /*movies1 = movies.SortDescending("id");
        foreach (Movie movie in movies1)
        {
            Console.WriteLine($"{movie.Id} {movie.Title} {movie.Date} {movie.Price} {movie.Duration} {movie.Room.Number}");
        }
        Console.WriteLine();

        //Filtering list
        movies1 = movies.FilterList("5");
        foreach (Movie movie in movies1)
        {
            Console.WriteLine($"{movie.Id} {movie.Title} {movie.Date} {movie.Price} {movie.Duration} {movie.Room.Number}");
        }
        Console.WriteLine();


        // Changing price
        movies.ModifyMoviePrice("1", "100,50");
        movies1 = movies.GetAllMovies();
        foreach (Movie movie in movies1)
        {
            Console.WriteLine($"{movie.Id} {movie.Title} {movie.Date} {movie.Price} {movie.Duration} {movie.Room.Number}");
        }
        Console.WriteLine();

        // Adding Movie
        /*movies.AddMovie(null, "Labirynt fauna", "12/10/2023 07:00", "50,45", "3:30", "3");
        movies1 = movies.GetAllMovies();
        foreach (Movie movie in movies1)
        {
            Console.WriteLine($"{movie.Id} {movie.Title} {movie.Date} {movie.Price} {movie.Duration} {movie.Room.Number}");
        }

        //movies.SaveMoviesToFile();

        */
        /*ReservationRepository reservationRepository = new ReservationRepository(movies);
        reservationRepository.ReadReservationsFromFile();

        List<Reservation> reservations = reservationRepository.GetReservationsList();

        foreach (Reservation res in reservations)
        {
            string seats = string.Join(", ", res.Seats);
            //string seats = string.Join(", ", res.Seats.Select(seat => seat.ToString()));
            Console.WriteLine($" {res.Id} {res.Movie.Id} {res.Movie.Title} {res.Movie.Date.ToString("dd/MM/yyyy HH:mm")} {res.Movie.Room.Number} {seats}");
        }
        Console.WriteLine() ;
        //reservationRepository.RemoveMovieWithReservation(2);

        /*movies1 = movies.GetAllMovies();
        foreach (Movie movie in movies1)
        {
            Console.WriteLine($"{movie.Id} {movie.Title} {movie.Date} {movie.Price} {movie.Duration} {movie.Room.Number}");
        }
        Console.WriteLine();
        reservations = reservationRepository.GetReservationsList();

        foreach (Reservation res in reservations)
        {
            string seats = string.Join(", ", res.Seats);
            //string seats = string.Join(", ", res.Seats.Select(seat => seat.ToString()));
            Console.WriteLine($" {res.Id} {res.Movie.Id} {res.Movie.Title} {res.Movie.Date.ToString("dd/MM/yyyy HH:mm")} {res.Movie.Room.Number} {seats}");
        }
        //movies.SaveMoviesToFile();
        //reservationRepository.SaveReservationsToFile();*/
        //reservationRepository.MakeReservation(null, "0", new List<string> { "20", "30", "50" });
        //reservationRepository.MakeReservation(null, "1", new List<string> { "20", "30", "40" });
        //reservationRepository.MakeReservation(null, "4", new List<string> { "20", "30", "40" });
        //reservationRepository.MakeReservation(null, "4", new List<string> { "10", "50", "60" });
        /*Console.WriteLine();
        foreach (Reservation res in reservations)
        {
            string seats = string.Join(", ", res.Seats);
            //string seats = string.Join(", ", res.Seats.Select(seat => seat.ToString()));
            Console.WriteLine($" {res.Id} {res.Movie.Id} {res.Movie.Title} {res.Movie.Date.ToString("dd/MM/yyyy HH:mm")} {res.Movie.Room.Number} {seats}");
        }
        //reservationRepository.SaveReservationsToFile();
        reservationRepository.RemoveMovieWithReservation(4);
        movies.SaveMoviesToFile();
        reservationRepository.SaveReservationsToFile();
        //Console.Clear();*/
        //Ticket ticket = new Ticket(1);
        // ticket.RenderTemplate();
        //reservationRepository.MakeReservation(null, "0", new List<string> { "11", "1", "5" });



    }
}
