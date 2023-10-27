using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Interfaces
{
    public interface IUser
    {
        /* 
         - najpopularniejsze filmy(największa ilość zarezerwowanych miejsc) - ale tutaj bez ilości miejsc tylko kolejne filmy
               
         */
        // Reservations
        void MakeReservation(string? reservation_id, string movie_id, List<string> seatsNumbers);
        void DeleteReservation(int id);
        List<Reservation> GetReservationsList(); // To powinna być lista rezerwacji tylko tego użytkownika ale mamy jednego

        // Movies
        List<Movie> GetAllMovies();
        List<Movie> FilterList(string userInput);
        List<Movie> SortAscending(string attribute);
        List<Movie> SortDescending(string attribute);
    }
}
