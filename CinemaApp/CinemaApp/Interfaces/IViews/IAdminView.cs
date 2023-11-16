using CinemaApp.Model;

namespace CinemaApp.Interfaces.IViews
{
    public interface IAdminView
    {
        string? RemoveMovie();
        void ShowTotalIncome(double income);
        void ShowMostPopularMovies(Dictionary<string, int> movies);
        void ShowMoviesIncome(Dictionary<string, double> income);
        string?[] ModifyMovie();
        string?[] AddMovie();
        void DrawStatiscicArt();
        int RenderStatisticsAdminView();
        int RenderMoviesAdminView(List<Movie> movies);
        int RenderMainAdminView();

        // Odziedziczone
        void PrintInputArt();
        void ClearViewOptionsPart(int WindowWidth, int WindowHeight);
        void ClearViewInputPart(int WindowWidth, int WindowHeight);
        void ClearViewOutputDataPart(int WindowWidth, int WindowHeight);
        void ClearViewInfoPart(int WindowWidth, int WindowHeight);
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