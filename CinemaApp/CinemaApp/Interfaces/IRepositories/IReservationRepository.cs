using CinemaApp.Model;

namespace CinemaApp.Interfaces
{
    public interface IReservationRepository
    {
        void MakeReservation(string? reservation_id, string movie_id, List<string> seatsNumbers);
        string[] GetTicket();
        List<string> CheckModificatedMoviesWithReservation();
        List<string> CheckDeletedReservations();
        public Reservation GetLastReservation();
        void DeleteReservation(string id);
        void ModifyMovieDateOrRoomWithReservation(string id, string new_date, string new_room_number);
        void RemoveMovieWithReservation(string id);
        Dictionary<string, int> GetMostPopularMovies();
        Dictionary<string, double> GetMoviesIncome();
        double GetTotalIncome();
        List<Reservation> GetReservationsList();
        void ReadReservationsFromFile();
        void SaveReservationsToFile();
        void CreateTempDeleteFile();
        void CreateTempModificationFile();
    }
}