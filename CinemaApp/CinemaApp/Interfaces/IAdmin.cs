using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Interfaces
{
    public interface IAdmin
    {
        /*
         - wyświetlenie statystyk:
	        x najpopularniejsze filmy (największa ilość zarezerwowanych miejsc)
	        - najbardziej zapełnione sale ?
	        x łączny dochód
            x najbardziej dochodowe filmy - film może być drogi ale może być na nim mało osób i wtedy i tak bedzie najbardziej dochodowy
         - można też dodać sortowanie i filtrowanie do rezerwacji ale to zależy od tego jak to będzie wyświetlane
         */
        // Reservations
        void ModifyMovieDateOrRoomWithReservation(string id, string new_date, string new_room_number);
        void RemoveMovieWithReservation(int id);
        List<Reservation> GetReservationsList();
        public double GetTotalIncome();
        Dictionary<string, double> GetMoviesIncome();
        Dictionary<string, int> MostPopularMovies();

        // Movies
        void AddMovie(string? id, string title, string date, string price, string duration, string roomNumber);
        void ModifyMoviePrice(string id, string new_price);
        List<Movie> GetAllMovies();
        List<Movie> FilterList(string userInput);
        List<Movie> SortAscending(string attribute);
        List<Movie> SortDescending(string attribute);
    }
}
