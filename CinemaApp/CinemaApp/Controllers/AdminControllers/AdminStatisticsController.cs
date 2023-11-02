using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IViews;

namespace CinemaApp.Controllers.AdminControllers
{
    public class AdminStatisticsController
    {
        private IAdminView adminView;
        private IReservationRepository reservationRepository;
        private bool infoChanged;
        public AdminStatisticsController(IReservationRepository reservationRepository, IAdminView adminView)
        {
            this.reservationRepository = reservationRepository;
            this.adminView = adminView;
            infoChanged = false;
        }

        public void Run()
        {
            int valueStatisticsAdminOptions = 0;
            adminView.DrawStatiscicArt();
            while (valueStatisticsAdminOptions != 4)
            {
                valueStatisticsAdminOptions = adminView.RenderStatisticsAdminView();
                switch (valueStatisticsAdminOptions)
                {
                    case 1: // Total Income
                        {
                            GetTotalIncome();
                            break;
                        }
                    case 2: // Top 10 movies income
                        {
                            GetTop10MostProfitableMovies();
                            break;
                        }
                    case 3: // Top 10 popular movies
                        {
                            GetTop10MostPopularMovies();
                            break;
                        }
                    case 4: // Go back
                        {
                            GoBack();
                            break;
                        }
                }
            }
        }
        private void GetTotalIncome()
        {
            double income = reservationRepository.GetTotalIncome();
            adminView.ShowTotalIncome(income);
            infoChanged = true;
        }
        private void GetTop10MostProfitableMovies()
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
                adminView.SetDefaultInfo();
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
            infoChanged = true;
        }
        private void GetTop10MostPopularMovies()
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
                adminView.SetDefaultInfo();
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
            infoChanged = true;
        }
        private void GoBack()
        {
            adminView.ClearViewOptionsPart(Console.WindowWidth, Console.WindowHeight);
            if (infoChanged)
            {
                adminView.ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
            }
            adminView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
        }
    }
}
