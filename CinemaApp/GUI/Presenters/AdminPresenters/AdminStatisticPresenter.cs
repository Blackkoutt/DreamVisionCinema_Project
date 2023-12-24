using CinemaApp.Enums;
using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using GUI.Interfaces;
using GUI.Views;
using GUI.Views.AdminViews;

namespace GUI.Presenters.AdminPresenters
{
    public class AdminStatisticPresenter
    {
        private IAdminStatisticsView _view;
        private IPopluarMovies _popularMoviesView;
        private IProfitableMovies _profitableMoviesView;
        private IMainAdminForm _mainAdminForm;

        private IReservationRepository reservationRepository;

        public AdminStatisticPresenter(IReservationRepository reservationRepository, IAdminStatisticsView view, IMainAdminForm mainAdminForm)
        {
            this.reservationRepository = reservationRepository;
            this._view = view;
            this._mainAdminForm = mainAdminForm;

            // Dodanie obsługi eventów generowanych przez widok statystyk
            _view.mostPopularClickEvent += HandlePopularClickEvent;
            _view.mostProfitableClickEvent += HandleProfitableClickEvent;

            PrepareStatisticView(); // Przygotowanie widoku statystyk

            _view.Show();
            _mainAdminForm = mainAdminForm;
        }

        // Metoda tworząca powiadomienie (Success, Info, Error)
        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox(true);
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }

        // Metoda obsługująca kliknięcie w przycisk "Wykres najbardziej dochodowych filmów"
        private void HandleProfitableClickEvent(object? sender, EventArgs e)
        {
            Dictionary<string, double> data;
            try
            {
                data = reservationRepository.GetMoviesIncome(); // Pobranie najbardziej dochodowanych filmów
            }
            catch(ListIsEmptyException LIEE)
            {
                MakeAlert("Lista rezerwacji jest pusta!", CustomAlertBox.enmType.Error);
                return;
            }
            catch(Exception ex)
            {
                MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                return;
            }
            
            data = data.Take(10).ToDictionary(pair => pair.Key, pair => pair.Value);    // Wybranie pierwszych 10 filmów
            // Dodanie pustego elementu na początek w celu lepszej prezentacji danych na wykresie
            data = new Dictionary<string, double> { { "", 0 } }.Concat(data).ToDictionary(pair => pair.Key, pair => pair.Value);

            // Utworzenie widoku najbardziej poularnych filmów
            _profitableMoviesView = new MostProfitableMoviesView(data);
            _mainAdminForm.PanelContainer.Controls.Clear();

            // Dodanie go do głównego kontenera
            _mainAdminForm.PanelContainer.Controls.Add((Form)_profitableMoviesView);

            _profitableMoviesView.Show();
            _profitableMoviesView.BringToFront();
            _profitableMoviesView.BackFromProfitableMovies += HandleBackFromProfitableMovies;   // Obsługa eventu kliknięcia w przycisk "Wróć"
        }

        // Metoda obsługująca kliknięcie przycisku "Wróć" w widoku najbardziej dochodowych filmów
        private void HandleBackFromProfitableMovies(object? sender, EventArgs e)
        {
            // Zamknięcie widoku i usunięcie go z głównego kontenera
            _profitableMoviesView.Close();
            _mainAdminForm.PanelContainer.Controls.Clear();
            _profitableMoviesView = null;
            
            // Ponowne przygotowanie widoku statystyk i dodanie głównego widoku do kontenera
            PrepareStatisticView();
            _mainAdminForm.PanelContainer.Controls.Add((Form)_view);
            _view.Show();
        }


        // Metoda obsługująca event kliknięcia w przycisk "Wykres najpopularniejszych filmów"
        private void HandlePopularClickEvent(object? sender, EventArgs e)
        {
            Dictionary<string, int> data;
            try
            {
                data = reservationRepository.GetMostPopularMovies(); // Pobranie najpopularniejszych filmów
            }
            catch (ListIsEmptyException LIEE)
            {
                MakeAlert("Lista rezerwacji jest pusta!", CustomAlertBox.enmType.Error);
                return;
            }
            catch (Exception ex)
            {
                MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                return;
            }

            // Wybranie pierwszych 10 filmów z listy
            data = data.Take(10).ToDictionary(pair => pair.Key, pair => pair.Value);

            // Dodanie pierwszego pustego elementu w celu lepszej prezentacji danych na wykresie
            data = new Dictionary<string, int> { { "", 0 } }.Concat(data).ToDictionary(pair => pair.Key, pair => pair.Value);

            // Utworzenie nowego widoku i dodanie go do głównego kontenera
            _popularMoviesView = new MostPopularMoviesView(data);
            _mainAdminForm.PanelContainer.Controls.Clear();
            _mainAdminForm.PanelContainer.Controls.Add((Form)_popularMoviesView);

            _popularMoviesView.Show();
            _popularMoviesView.BringToFront();
            _popularMoviesView.BackFromPupularMovies += HandleBackFromPopularMovies;    // Obsługa eventu kliknięcia w przycisk "Wróc"
        }

        
        // Metoda obsługująca event kliknięcia w przycisk "Wróć" w widoku najpopularniejszych filmów
        private void HandleBackFromPopularMovies(object? sender, EventArgs e)
        {
            // Zamknięcie widoku najpoluarniejszych filmów i wyczyszczenie kontenera
            _popularMoviesView.Close();
            _mainAdminForm.PanelContainer.Controls.Clear();
            _popularMoviesView = null;

            // Ponowne przygotowanie głownego widoku statystyk i dodanie go do kontenera
            PrepareStatisticView();
            _mainAdminForm.PanelContainer.Controls.Add((Form)_view);
            _view.Show();
        }



        // Metoda przygotowująca główny widok statystyk
        public void PrepareStatisticView()
        {
            double income = reservationRepository.GetTotalIncome(); // Pobranie całkowitego dochodu kina

            // Przypisanie dochodu do odpowiednich elementów widoku
            _view.Earings.Text = $"{income} $";
            _view.Guideline.Text= $"{income}/{(int)Guideline.ESTIMATED_EARNINGS} $";
            int value = (int)((income / (int)Guideline.ESTIMATED_EARNINGS) * 100);
            _view.Progress.Text = $"{value} %";

            if (value > 100)
            {
                _view.Progress.Value = 100;
            }
            else
            {
                _view.Progress.Value = value;
            }
            
        }
    }
}
