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
            adminView.ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
            adminView.DrawStatiscicArt();
            while (valueStatisticsAdminOptions != 4)
            {
                valueStatisticsAdminOptions = adminView.RenderStatisticsAdminView();
                switch (valueStatisticsAdminOptions)
                {
                    // Całkowity dochód kina
                    case 1: 
                        {
                            GetTotalIncome();
                            break;
                        }

                    // Top 10 najbardziej dochodowych filmów
                    case 2:
                        {
                            GetTop10MostProfitableMovies();
                            break;
                        }

                    // Top 10 najpopularniejszych filmów
                    case 3:
                        {
                            GetTop10MostPopularMovies();
                            break;
                        }

                    // Powrót do poprzedniego widoku
                    case 4:
                        {
                            GoBack();
                            break;
                        }
                }
            }
        }


        // Metoda pobierająca i wyświetlająca całkowity dochód kina
        private void GetTotalIncome()
        {
            double income = reservationRepository.GetTotalIncome();
            adminView.ShowTotalIncome(income);
            infoChanged = true;
        }


        // Metoda pobierająca i wyświetlająca TOP 10 najbardziej dochodowych filmów
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


        // Metoda pobierająca i wyświetlająca TOP 10 najpopuularniejszych filmów
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


        // Powrót do poprzedniego widoku
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