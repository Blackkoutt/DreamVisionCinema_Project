using CinemaApp.Model;

namespace CinemaApp.Interfaces.IViews
{
    public interface IUserView
    {
        void PrinterAnimation();
        void ShowTicket(string ticket, string ticket_file_name);
        int RenderMoviesUserView(List<Movie> movies);
        string RemoveReservation();
        string GetFilmId();
        string MakeReservation(Movie movie);
        int RenderReservationsUserView(List<Reservation> res);
        int RenderMainUserView();
        void SetInfoAboutDeletedOrModificatedReservations(List<string> deleted_modificated_reservations);

        // Odziedziczone
        void PrintInputArt();
        void ClearViewOptionsPart(int WindowWidth, int WindowHeight);
        void ClearViewInputPart(int WindowWidth, int WindowHeight);
        void ClearViewOutputDataPart(int WindowWidth, int WindowHeight);
        void ClearViewInfoPart(int WindowWidth, int WindowHeight);
        void RenderMainFrame(int WindowWidth, int WindowHeight);
        void ClearConsole();
        void ShowSuccessOrException(string succes_or_error_message);
        void ScrollUp(List<Movie> mov);
        void ScrollDown(List<Movie> mov);
        void ScrollUp(List<Reservation> res);
        void ScrollDown(List<Reservation> res);
        void SetHowManyResWereDisplayed();
        void SetHowManyMoviesWereDisplayed();
        void ShowReservationList(List<Reservation> res, int startIndex);
        void ShowMoviesList(int WindowWidth, int WindowHeight, List<Movie> movies, int startIndex);
        string FilterList();
        string SortList();
        void SetDefaultInfo();
        void PrintUnknownErrorInfo(string exception_message);
    }
}
