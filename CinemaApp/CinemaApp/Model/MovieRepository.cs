using CinemaApp.Enums;
using CinemaApp.Exceptions;
using CinemaApp.Extensions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CinemaApp.Model
{
    public class MovieRepository
    {
        private List<Movie> movies;
        public MovieRepository()
        {
            movies = new List<Movie>();
        }

        // Read Movies From File
        public void ReadMoviesFromFile()
        {
            // Throws Exception CannotReadFileException
            StreamReader sr;
            try
            {
                sr = new StreamReader("movies.txt");
            }
            catch
            {
                throw new CannotReadFileException("Błąd otwarcia pliku. Sprawdź czy plik movies.txt znajduje się w katalogu CinemaApp.");
            }
            sr.ReadLine();

            string id, title, date, price, duration, roomNumber;

            string line;
            string[] strings_tab;

            while (!sr.EndOfStream) 
            {
                line = sr.ReadLine();
                strings_tab = line.Split(" ");

                if (strings_tab.Length != 7)
                {
                    throw new FileSyntaxException("Bład w składni pliku movies.txt. Sprawdź czy plik jest sformułowany według wzoru podanego w pierwszej linii.");
                }

                // Throws CannotConvert Exception
                /*id = Conversions.TryParseToInt(strings_tab[0], ErrorMessage);
                title = strings_tab[1].Replace("_"," ");
                date = Conversions.TryParseToDateTime(strings_tab[2]+" " + strings_tab[3], ErrorMessage);
                price = Conversions.TryParseToDouble(strings_tab[4], ErrorMessage);
                duration = strings_tab[5];
                roomNumber = Conversions.TryParseToInt(strings_tab[6], ErrorMessage);

                room = roomRepository.GetRoom(roomNumber);  // Throws NoRoomWithGivenNumberException

                movies.Add(new Movie(id, title,date, price, duration,room));
                
                // Zamist tego tu AddMovie metoda*/
                id = strings_tab[0];
                title = strings_tab[1].Replace("_", " ");
                date = strings_tab[2] + " " + strings_tab[3];
                price = strings_tab[4];
                duration = strings_tab[5];
                roomNumber = strings_tab[6];
                AddMovie(id, title, date, price, duration, roomNumber);
            }
            sr.Close();
        }

        // Add Movie To List
        // Wszystkie parametry jako string tutaj bedzie konwersja
        public void AddMovie(string? id, string title, string date, string price, string duration, string roomNumber)
        {
            //TO DO
            // Tutaj jeszcze sprawdzenie czy jest wolna sala w podanej dacie lub czy wpasowuje sie w harmonogram tzn czy koniec filmu nie przypada w trakcie trwania innego w tej samej sali

            DateTime Date;
            double Price;
            int RoomNumber, Id = 1;// default value

            // Throws Exceptions CannotConvertException
            if (id != null)
            {
                Id = Conversions.TryParseToInt(id, "Id musi być liczbą całkowitą.");
            }
            Date = Conversions.TryParseToDateTime(date, "Data powinna byc zapisana w postaci: dd/MM/yyyy HH:mm.");
            RoomNumber = Conversions.TryParseToInt(roomNumber, "Numer pokoju musi być liczbą całkowitą.");
            price = price.Replace(".", ",");
            Price = Conversions.TryParseToDouble(price, "Cena powinna być wartością zmiennoprzecinkową np 23,99.");

            Validation.IsDurationCorrect(duration); // Thorws Exception IncorrectParametrException


            //Room room = roomRepository.GetRoom(RoomNumber); // Throws Exception NoRoomWithGivenNumberException
            if (!Validation.IsValidRoomNumber(RoomNumber))
            {
                throw new NoRoomWithGivenNumberException("Brak sali o podanym numerze. Wybierz salę od 1 do 4");
            }

            CheckTimeCollisionsBetweenMovies(Date, duration, RoomNumber); //Throws MoviesCollisionException

            // Jeśli metode wywołano przy dodawaniu filmu przez administatora i lista filmów zawiera cokolwiek
            if (id == null && movies.Any()) 
            {
                movies.Add(new Movie((getLastMovie().Id) + 1, title, Date, Price, duration, new Room(RoomNumber, (int)Rooms.NUMBER_OF_SEATS)));              
            }
            else
            {
                movies.Add(new Movie(Id, title, Date, Price, duration, new Room(RoomNumber, (int)Rooms.NUMBER_OF_SEATS)));
            }
            // Jeśli metode wywołano przy czytaniu z pliku (id!=null) to Id będzie odczytanym id
            // Jeśli metode wywołał administartor (id==null) i nie ma na liście jeszcze żadnych filmów to Id będzie wartością domyślną = 1           
        }
        private Movie getLastMovie()
        {
            return movies[movies.Count - 1];
        }
        public void CheckTimeCollisionsBetweenMovies(DateTime date, string duration, int roomNumber)
        {
            DateTime newMovieStartDate = date;  // Godzina rozpoczecia
            TimeSpan timeSpan = TimeSpan.Parse(duration);   // Godzina zakonczenia i tak wyjątku nie ma bo wcześniej sprawdzilismy czy duration prawidłowe
            DateTime newMovieEndDate = newMovieStartDate.Add(timeSpan);

            TimeSpan span;
            DateTime movieEndDate, movieStartDate;

            foreach(Movie movie in movies)
            {
                // Jeśli nowy film jest wyświetlany w tej samej sali co inny film
                if(movie.Room.Number == roomNumber)
                {
                    span = TimeSpan.Parse(movie.Duration);
                    movieStartDate = movie.Date;
                    movieEndDate = movie.Date.Add(span);

                    // Albo początek innego filmu jest między początkiem a końcem nowego filmu
                    // Albo koniec innego filmu jest między początkiem a końcem nowego filmu
                    if ((movieStartDate >= newMovieStartDate && movieStartDate < newMovieEndDate) || (movieEndDate>newMovieStartDate && movieEndDate <= newMovieEndDate))
                    {
                        throw new MoviesCollisionException("Czas filmu koliduje innym filmem. Wybierz inną godzinę, datę lub salę.");
                    }
                }
               
            }
        }

        // Remove movie From List tutaj może być podane id
        public void RemoveMovie(int id)
        {
            movies.RemoveAll(x => x.Id == id);
            // Sprawdzamy czy na dany film zostało zarezerwowane miejsce (czy film znajduje się na liście Reservation)
            // Jeśli tak to wywołujemy odpowiednią metodę ReservationRepository
            // Metoda ta oznacza bilet (pole w klasie Bilet na true) jako nieważny lub odwołany
            // Bilet jest modyfikowany w pliku
            // Przy logowaniu użytkownika na początku wczytywana jest lista biletów
            // Jeśli jakiś bilet jest nieważny lub zostało coś zmienione to wyświetlany jest odpowiedni komunikat - Seans odwołany środki zwrócone
            // Usuwamy film z listy który ma podane id 
        }

        // Modyfikacja filmu na liście tutaj tez moze być podane id
        public void ModifyMovieDateOrRoom(Movie movie, DateTime newDate, int newRoomNumber)
        {
            movie.Date = newDate;
            movie.Room.Number = newRoomNumber;
            // Sprawdzenie czy podana sala nie jest wtedy zajeta i czy wszystko jest zgodne z harmonogramem
            // Podobnie jak wcześniej przed modyfikacja sprawdzane jest czy jest zarezerwowane miejsce na dany film
            // Oznaczenie biletu jako zmodyfikowany 
            // Modyfikacja filmu i biletu
        }
        public void ModifyMoviePrice(string id, string new_price)
        {
            // Sprawdzenie new price
            int Id = Conversions.TryParseToInt(id, "Id powinno być wartością całkowitą");
            double newPrice = Conversions.TryParseToDouble(new_price, "Cena powinna być wartością zmiennoprzecinkową");

            Movie movie = GetOneMovie(Id);
            if (movie == null)
            {
                throw new NoMovieWithGivenIdException("Brak filmu o podanym Id.");
            }

            movie.Price = newPrice;
        }

        // Sprawdzenie czy jest wolna sala o podanej dacie przy dodaniu do listy

        // Wyświetlenie listy
        public List<Movie> GetAllMovies() 
        {
            if (!movies.Any())
            {
                throw new MovieListIsEmptyException("Lista filmów jest pusta.");
            }
            return movies; // Lista może być pusta wtedy w kontrolerze trzeba sprawdzić czy jest pusta
        }
        public Movie GetOneMovie(string id)
        {
            int ID = Conversions.TryParseToInt(id, "ID powinno być liczbą całkowitą.");
            Movie movie = movies.FirstOrDefault(m => m.Id == ID);
            if (movie == null)
            {
                throw new NoMovieWithGivenIdException("Brak filmu o podanym ID.");
            }
            return movie;
        }
        public Movie GetOneMovie(int id)
        {
            return movies.FirstOrDefault(m => m.Id == id);  // Jeśli nie znajdzie zwróci null wtedy w kontrolerze trzeba sprawdzić
        }

        // Filtrowanie i zwrócenie tymczasowej listy - nie wiadomo czy dziala
        // Może być problem z room
        public List<Movie> FilterList(string userInput)
        {
            PropertyInfo[] properties = typeof(Movie).GetProperties();  // Atrybuty klasy Movie

            //Tutaj może być problem z room
            List<Movie> filteredMovies = movies.Where(movie =>
            {
                return properties.Any(property =>
                {
                    string? propertyValue = property.GetValue(movie).ToString(); // Pobranie wartości kolejnych atrybutów kolejnych filmów
                    // Dopasowanie wartości pobranej od użytkownika do wartości atrybutu
                    // Szukanie podciągu znaków podanego przez użytkownika znajdującego się w wartości atrybutu
                    return propertyValue != null && propertyValue.IndexOf(userInput, StringComparison.OrdinalIgnoreCase) >= 0;
                });
            }).ToList();
            if (!filteredMovies.Any())
            {
                throw new CannotFindMatchingMovieException("Brak wyników wyszukiwania");
            }
            return filteredMovies;
        }

        // Sortowanie ASC i zwrócenie tymczasowej listy lepiej może zroić inaczej niż po stringu
        public List<Movie> SortAscending(string attribute)
        {
            // Tutaj coś jednak może pójść nie tak może warto wyjątki
            attribute = attribute.ToLower();
            List<Movie> SortedMovies = new List<Movie>();
            switch (attribute)
            {
                case "id":
                    {
                        SortedMovies = movies.OrderBy(movie => movie.Id).ToList();
                        break;
                    }
                case "tytuł":
                    {
                        SortedMovies = movies.OrderBy(movie => movie.Title).ToList();
                        break;
                    }
                case "data":
                    {
                        SortedMovies = movies.OrderBy(movie => movie.Date).ToList();
                        break;
                    }
                case "cena":
                    {
                        SortedMovies = movies.OrderBy(movie => movie.Price).ToList();
                        break;
                    }
                case "czas":
                    {
                        SortedMovies = movies.OrderBy(movie => movie.Price).ToList();
                        break;
                    }
                // Sortowanie po sali chyba nie potrzebne ale można dodać 
                case "nr sali":
                    {
                        SortedMovies = movies.OrderBy(movie => movie.Room.Number).ToList();
                        break;
                    }
                default:
                    {
                        throw new BadAttributeException("Brak atrybutu o podanej nazwie");
                    }
            }
            if (!SortedMovies.Any())
            {
                throw new ListIsEmptyException("Lista jest pusta!");
            }
            return SortedMovies;
        }

        // Sortowanie DSC i zwrócenie tymczasowej listy lepiej może zrobić inaczej niż po stringu
        public List<Movie> SortDescending(string attribute)
        {
            List<Movie> SortedMovies = new List<Movie>();
            attribute = attribute.ToLower();
            switch (attribute)
            {
                case "id":
                    {
                        SortedMovies = movies.OrderByDescending(movie => movie.Id).ToList();
                        break;
                    }
                case "tytuł":
                    {
                        SortedMovies = movies.OrderByDescending(movie => movie.Title).ToList();
                        break;
                    }
                case "data":
                    {
                        SortedMovies = movies.OrderByDescending(movie => movie.Date).ToList();
                        break;
                    }
                case "cena":
                    {
                        SortedMovies = movies.OrderByDescending(movie => movie.Price).ToList();
                        break;
                    }
                case "czas":
                    {
                        SortedMovies = movies.OrderByDescending(movie => movie.Price).ToList();
                        break;
                    }
                // Sortowanie po sali chyba nie potrzebne ale można dodać 
                case "nr sali":
                    {
                        SortedMovies = movies.OrderByDescending(movie => movie.Room.Number).ToList();
                        break;
                    }
                default:
                    {
                        throw new BadAttributeException("Brak atrybutu o podanej nazwie");
                    }
            }
            if (!SortedMovies.Any())
            {
                throw new ListIsEmptyException("Lista jest pusta!");
            }
            return SortedMovies;
        } 

        // Zapis listy do pliku
        public void SaveMoviesToFile()
        {
            StreamWriter sw = new StreamWriter("movies.txt");
            string title, date_hour;

            sw.WriteLine("//id tytuł data godzina cena czas_trwania numer_sali");
            foreach (Movie movie in movies) 
            {
                title = movie.Title.Replace(" ", "_");
                date_hour = movie.Date.ToString("dd/MM/yyyy HH:mm");
                sw.WriteLine($"{movie.Id} {title} {date_hour} {movie.Price} {movie.Duration} {movie.Room.Number}");
            }
            sw.Close();
        }

    }
}
