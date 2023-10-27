using CinemaApp.Exceptions;
using CinemaApp.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Model
{
    public class ReservationRepository
    {
        private List<Reservation> reservations;
        private MovieRepository movies;

        public ReservationRepository(MovieRepository movies)
        {
            reservations = new List<Reservation>();
            this.movies = movies;
        }
        public void MakeReservation(string? reservation_id, string movie_id, List<string> seatsNumbers)
        {
            // to do zmiany
            string ErrorMessage = "Sprawdź poprawność danych w pliku reservations.txt lub wprowadź poprawne dane.";

            int Movie_Id, Reservation_Id = 1;
            List<int> SeatsNumbers = new List<int>();

            // Throws Exceptions
            if(reservation_id != null)
            {
                Reservation_Id = Conversions.TryParseToInt(reservation_id, ErrorMessage);
            }
            
            Movie_Id = Conversions.TryParseToInt(movie_id, ErrorMessage);

            foreach(string str in seatsNumbers)
            {
                SeatsNumbers.Add(Conversions.TryParseToInt(str, ErrorMessage));
            }


            Movie movie = movies.GetOneMovie(Movie_Id); // Może zwrócić null
            if(movie == null)
            {
                throw new NoMovieWithGivenIdException("Brak filmu o podanym Id.");
            }

            // Sprawdzenie czy wybrane miejsca istnieją i są dostępne
            movie.Room.CheckSeatsAvailable(SeatsNumbers); // Throws NoSeatWithGivenNumberException i SeatIsNotAvailableException

            // Jeśli są dostępne rezerwujemy je
            List<Seat> seats = movie.Room.MarkSeatsAsReservatedAndGet(SeatsNumbers);
            //Rezerwacje trzeba przechowywać w pliku jako id_filmu(tu może być problem po usunięciu filmu z listy) id_rezerwacji i zarezerwowane miejsca
            if (reservation_id == null && reservations.Any())
            {
                reservations.Add(new Reservation((GetLastReservation().Id) + 1, movie, seats));
                // Jeśli użytkownik doda rezerwację samodzielnie w pliku to nie otrzyma biletu
                string Seats = string.Join(",", seats);
                reservations[reservations.Count - 1].Ticket.SaveTicketToFile(movie, Seats);
            }
            else
            {
                reservations.Add(new Reservation(Reservation_Id, movie, seats));

                // To trzeba usunąc
               // string Seats = string.Join(",", seats);
               // reservations[reservations.Count - 1].Ticket.SaveTicketToFile(movie, Seats);
            }
            // Tutaj tylko przy tworzeniu nowej rezerwacji w programie - wywoływane jest zapis biletu do pliku
                
            // Użytkownik może dokonać rezerwacji na kilka miejsc na danym filmie ale jedna rezerwacja dotyczy jednego filmu

            //Tą metode wywołuje kontroler
        }
        public List<string> CheckDeletedReservations()
        {
            List<string> info = new List<string>(); 
            StreamReader sr;
            try
            {
                sr = new StreamReader("deleted_movies.txt");
            }
            catch (Exception ex)
            {
                throw new CannotReadFileException("Sprawdź czy plik deleted_movies.txt znajduje się w katalogu");
            }
            while (!sr.EndOfStream) 
            {
                info.Add(sr.ReadLine());
            }
            int i = info.Count;
            sr.Close();

            StreamWriter sw = new StreamWriter("deleted_movies.txt");
            sw.Close();

            return info;
        }
        private Reservation GetOneReservation(int id)
        {
            return reservations.FirstOrDefault(r => r.Id == id);
        }

        //To też dla użytkownika wiec musi być public 
        public void DeleteReservation(string id)
        {
            // Tutaj usunięcie rezerwacji i usinięcie biletu oraz pliku z biletem
            int Id = Conversions.TryParseToInt(id, "ID musi być liczbą całkowitą"); // Throws CannotConvertException

            Reservation res = GetOneReservation(Id);
            if (res == null)
            {
                throw new NoReservationWithGivenIdException("Brak rezerwacji o podanym Id.");
            }

            res.Ticket.DestroyTicket(res.Movie.Title); //Throws CannotDestroyTicket 

            reservations.RemoveAll(reservation => reservation == res);
        }

        // Sprawdza czy dany film posiada jakąkolwiek rezerwację
        private bool IsMovieHaveReservation(Movie movie)
        {
            return reservations.Any(reservation => reservation.Movie == movie);
        }
        public void ModifyMovieDateOrRoomWithReservation(string id, string new_date, string new_room_number)
        {
            // Podanie daty w złym formacie throw exception 
            // podanie numeru pokoju który nie istnieje throw exception
            int Id = Conversions.TryParseToInt(id, "Id powinno być wartością całkowitą");
            DateTime NewDate;
            int newRoomNumber;

            // Podanie id które nie istnieje throw exception
            Movie movie = movies.GetOneMovie(Id);
            if (movie == null)
            {
                throw new NoMovieWithGivenIdException("Brak filmu o podanym Id.");
            }
            int previousRoomNumber = movie.Room.Number;
            string previousDate = movie.Date.ToString("dd/MM/yyyy HH:mm");


            if (new_date != "")
            {
                NewDate = Conversions.TryParseToDateTime(new_date, "Sprawdź czy data jest podana w formacie dd/MM/yyyy HH:mm");
                movies.CheckTimeCollisionsBetweenMovies(NewDate, movie.Duration, movie.Room.Number);
                movies.ModifyMovieDateOrRoom(movie, NewDate, movie.Room.Number);
            }
            if (new_room_number != "")
            {
                newRoomNumber = Conversions.TryParseToInt(new_room_number, "Numer sali powinien być wartością całkowitą");
                if (!Validation.IsValidRoomNumber(newRoomNumber))
                {
                    throw new NoRoomWithGivenNumberException("Brak sali o podanym numerze");
                }
                movies.CheckTimeCollisionsBetweenMovies(movie.Date, movie.Duration, newRoomNumber);
                movies.ModifyMovieDateOrRoom(movie, movie.Date, newRoomNumber);
            }

            // Sprawdzenie czy podana data lub/i sala nie koliduje z innym filmem
            if (IsMovieHaveReservation(movie))
            {
                // Modyfikacja filmu
                List<Reservation> reservation_list = GetReservationForMovie(movie); // Tutaj wyszukujemy po id bo id sie nie zmienia

                StreamWriter sw = new StreamWriter("modificated_movies.txt", true);

                // tutaj jescze nagłówek pliku i może dodać też info o id filmu i id rezerwacji
                // Tutaj wystarczy jedna informacja odnośnie wszystkich rezerwacji po prostu data filmu została zmieniona
                // Ale bilety trzeba zmienić dla każdej rezerwacji
                //movies.ModifyMovieDateOrRoom(movie, NewDate, newRoomNumber);
                
                foreach (Reservation res in reservation_list)
                {
                    string seats = string.Join(", ", res.Seats);                 
                    res.Ticket.DestroyTicket(res.Movie.Title);
                    res.Ticket.SaveTicketToFile(res.Movie, seats);
                }
                if (previousDate != movie.Date.ToString("dd/MM/yyyy HH:mm"))
                {
                    sw.WriteLine($"Zmieniono datę seansu filmu: {movie.Title}. Poprzednia data: {previousDate}. Nowa data: {movie.Date.ToString("dd/MM/yyyy HH:mm")}.");
                }
                if (previousRoomNumber != movie.Room.Number)
                {
                    sw.WriteLine($"Zmieniono salę dla filmu: {movie.Title}. Poprzednia sala: {previousRoomNumber}. Nowa sala: {movie.Room.Number}");
                }
                sw.WriteLine("Wszystkie bilety zostały zaktualizowane!");
                sw.Close();

                // Informacja o modyfikacji (zapis do pliku info i wyświetlenie przy logowaniu użytkownika)
                // Wydrukowanie nowego biletu i skasowanie poprzedniego
            }
            /*else
            {
                movies.ModifyMovieDateOrRoom(movie, NewDate, newRoomNumber);
            }*/
        }

        // Usuwa film i wszytskie powiązane z nim rezerwacje zapisując informacje o nich w pliku tymaczasowym
        public void RemoveMovieWithReservation(string id)
        {
            int Id = Conversions.TryParseToInt(id, "ID musi być liczbą całkowitą"); //Throw exception
            Movie movie = movies.GetOneMovie(Id);
            if (movie == null)
            {
                throw new NoMovieWithGivenIdException("Brak filmu o podanym Id.");
            }
            // Jeśli film posiada jakąkolwiek rezerwacje
            if (IsMovieHaveReservation(movie))
            {
                // Pobierane są wszystkie rezerwacje dla danego filmu
                List<Reservation> reservation_list = GetReservationForMovie(movie); // Tutaj wyszukujemy po id bo id sie nie zmienia

                // Zapisywane są informacje o filmie i rezerwacji w tymczasowym pliku
                StreamWriter sw = new StreamWriter("deleted_movies.txt", true);

                // tutaj jescze nagłówek pliku i może dodać też info o id filmu i id rezerwacji
                // Tutaj informacja dla każdej rezerwacji która została usunięta !!!
                foreach(Reservation res in reservation_list)
                {
                    string seats = string.Join(", ", res.Seats);
                    sw.WriteLine($"Odwołano rezerwacje na film: \"{movie.Title}\" w dniu: {movie.Date.ToString("dd/MM/yyyy HH:mm")}.");
                    sw.WriteLine($"Środki w liczbie {res.Ticket.CalculatePrice(movie.Price, res.Seats.Count)} zostały zwrócone na konto.");
                    res.Ticket.DestroyTicket(res.Movie.Title);
                }
                sw.Close();

                // Usunięcie rezerwacji
                DeleteGivenReservations(reservation_list);

                // Zwolnienie miejsca w sali - chyba nie trzeba kasując film kasujemy też sale

                // Usunięcie biletu
                
            }
            // Usunięcie filmu
            movies.RemoveMovie(movie.Id);
        }

        // Zwraca listę rezerwacji dla danego filmu
        private List<Reservation> GetReservationForMovie(Movie movie)
        {
            return reservations.Where(reservation => reservation.Movie.Id == movie.Id).ToList();
        }

        // To dla administartora
        private void DeleteGivenReservations(List<Reservation> res)
        {
            reservations.RemoveAll(reservation => res.Contains(reservation));
        }
        public Dictionary<string, int> GetMostPopularMovies()
        {
            Dictionary<string, int> MostPopularMovies = new Dictionary<string, int>();

            foreach (Reservation res in reservations)
            {
                if (MostPopularMovies.ContainsKey(res.Movie.Title))
                {
                    MostPopularMovies[res.Movie.Title] += res.Seats.Count;
                }
                else
                {
                    MostPopularMovies.Add(res.Movie.Title, res.Seats.Count);
                }
            }
            if (!MostPopularMovies.Any())
            {
                throw new ListIsEmptyException("Lista jest pusta");
            }
            return MostPopularMovies.OrderByDescending(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        public Dictionary<string, double> GetMoviesIncome()
        {
            Dictionary<string, double> MoviesStats = new Dictionary<string, double>();

            foreach(Reservation res in reservations)
            {
                if (MoviesStats.ContainsKey(res.Movie.Title))
                {
                    MoviesStats[res.Movie.Title] += Math.Round(res.Movie.Price * res.Seats.Count, 2); 
                }
                else
                {
                    MoviesStats.Add(res.Movie.Title, Math.Round(res.Movie.Price * res.Seats.Count, 2));
                }
            }
            if (!MoviesStats.Any())
            {
                throw new ListIsEmptyException("Lista jest pusta");
            }
            return MoviesStats.OrderByDescending(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        public double GetTotalIncome()
        {
            double total = 0;  
            foreach (Reservation res in reservations)
            {
                total += res.Movie.Price * res.Seats.Count;
            }
            return total;
        }
        private Reservation GetLastReservation()
        {
            // Tu wyjątek gdy lista jest pusta na wszelki wypadek
            if (reservations.Count == 0)
            {
                throw new ReservationListIsEmptyException("Lista rezerwacji jest pusta.");
            }
            return reservations[reservations.Count - 1];
        }
        public List<Reservation> GetReservationsList()
        {
            if(!reservations.Any())
            {
                throw new ReservationListIsEmptyException("Lista rezerwacji jest pusta.");
            }
            return reservations;
        }

        // Odczyt rezerwacji z pliku
        public void ReadReservationsFromFile()
        {
            StreamReader sr;         
            try
            {
                sr = new StreamReader("reservations.txt");
            }
            catch
            {
                throw new CannotReadFileException("Błąd otwarcia pliku. Sprawdź czy plik reservations.txt znajduje się w katalogu CinemaApp.");
            }
            sr.ReadLine();

            string line;
            string[] strings_tab;

            // W teorii tu nie trzeba id
           
            string reservation_id;
            string movie_id;
            List<string> seats_numbers = new List<string>();


            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                strings_tab = line.Split(" ");

                if (strings_tab.Length != 3)
                {
                    throw new FileSyntaxException("Bład w składni pliku reservations.txt. Sprawdź czy plik jest sformułowany według wzoru podanego w pierwszej linii.");
                }

                // Tutaj może być problem że rezerwacja istnieje na film o danym id ale on został już usunięty czyli movie == null
                
                // Throws CannotConvertException
                reservation_id = strings_tab[0];
                movie_id = strings_tab[1];
                strings_tab = strings_tab[2].Split(",");
                seats_numbers = strings_tab.ToList();
                //id = Conversions.TryParseToInt(strings_tab[0], ErrorMessage);
                //movie_id = Conversions.TryParseToInt(strings_tab[1], ErrorMessage);

                /*strings_tab = strings_tab[2].Split(",");
                foreach(string str in strings_tab)
                {
                    seats_numbers.Add(Conversions.TryParseToInt(str,ErrorMessage));
                }*/

                // Tutaj wyowłanie metody MakeReservation 
                MakeReservation(reservation_id, movie_id, seats_numbers); // Metoda wyrzuca dużo wyjątków !!
            }
            sr.Close();
        }

        // Zapis rezerwacji do pliku
        public void SaveReservationsToFile()
        {
            StreamWriter sw = new StreamWriter("reservations.txt");
            sw.WriteLine("// id_rezerwacji id_filmu numery_miejsc");
            foreach(Reservation res in reservations)
            {
                string seats = string.Join(",", res.Seats);
                sw.WriteLine($"{res.Id} {res.Movie.Id} {seats}");
            }
            sw.Close();
        }
        
    }
}
