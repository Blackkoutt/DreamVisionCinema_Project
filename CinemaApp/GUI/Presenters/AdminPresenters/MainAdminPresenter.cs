using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Interfaces;
using GUI.Interfaces;
using GUI.Views.AdminViews;

namespace GUI.Presenters.AdminPresenters
{
    public class MainAdminPresenter
    {
        private IMovieRepository movieRepository;
        private IReservationRepository reservationRepository;
        private IMainAdminForm _mainAdminForm;

        private IAdminMoviesView adminMoviesView;
        private IAdminStatisticsView adminStatisticsView;
        private IAdminReservationsView adminReservationsView;
        public MainAdminPresenter(IMovieRepository movieRepository, IReservationRepository reservationRepository, IMainAdminForm mainAdminForm)
        {
            this.movieRepository = movieRepository;
            this.reservationRepository = reservationRepository;

            _mainAdminForm = mainAdminForm;
            
            // Dodanie osbługi eventów widoku
            _mainAdminForm.AdminLoadDefault += LoadDefault;
            _mainAdminForm.ShowAdminStatisticsView += ShowStatisticsView;
            _mainAdminForm.ShowAdminMoviesView += ShowMoviesView;
            _mainAdminForm.ShowAdminReservationsView += ShowReservationsView;
        }

        // Metoda wywoływana w momencie kliknięcia na logo (ładuje podstawowy widok)
        private void LoadDefault(object? sender, EventArgs e)
        {
            // Jeśli wcześniej był otwarty formularz rezerwacji, filmów lub statystyk to zamknij go
            if (adminReservationsView != null)
            {
                adminReservationsView.Close();
                adminReservationsView = null;
            }
            if (adminMoviesView != null)
            {
                adminMoviesView.Close();
                adminMoviesView = null;
            }
            if(adminStatisticsView != null)
            {
                adminStatisticsView.Close();
                adminStatisticsView = null;
            }

            // Dodaj do głównego kontenera logo
            _mainAdminForm.MainBigLogo.Anchor = AnchorStyles.None;
            _mainAdminForm.MainBigLogo.Dock = DockStyle.None;
            _mainAdminForm.PanelContainer.Controls.Add(_mainAdminForm.MainBigLogo);
        }


        // Metoda pokazująca widok listy rezerwacji
        private void ShowReservationsView(object? sender, EventArgs e)
        {
            // Jeśli wcześniej był otwarty widok statystyk lub listy filmów to go zamknij
            if (adminMoviesView != null)
            {
                adminMoviesView.Close();
                adminMoviesView = null;
            }
            if (adminStatisticsView != null)
            {
                adminStatisticsView.Close();
                adminStatisticsView = null;
            }
            if (adminReservationsView == null)
            {
                // Utwórz nowy widok listy rezerwacji i dodaj go do głównego kontenera
                adminReservationsView = new AdminReservationListView();
                new AdminReservationPresenter(reservationRepository, adminReservationsView);
                _mainAdminForm.PanelContainer.Controls.Clear();
                _mainAdminForm.PanelContainer.Controls.Add((Form)adminReservationsView);
                _mainAdminForm.PanelContainer.Tag = (Form)adminReservationsView;
            }
        }


        // Metoda pokazująca widok listy filmów
        private void ShowMoviesView(object? sender, EventArgs e)
        {
            // Jeżeli wcześniej był otwarty widok rezerwacji lub statystyk to go zamknij
            if (adminReservationsView != null)
            {
                adminReservationsView.Close();
                adminReservationsView = null;
            }
            if (adminStatisticsView != null)
            {
                adminStatisticsView.Close();
                adminStatisticsView = null;
            }
            if (adminMoviesView == null)
            {
                // Utwórz nowy widok listy filmów i dodaj go do głównego kontenera
                adminMoviesView = new AdminMoviesListView();
                new AdminMoviePresenter(movieRepository,reservationRepository, adminMoviesView);
                _mainAdminForm.PanelContainer.Controls.Clear();
                _mainAdminForm.PanelContainer.Controls.Add((Form)adminMoviesView);
                _mainAdminForm.PanelContainer.Tag = (Form)adminMoviesView;
            }
        }


        // Metoda pokazująca widok statystyk
        private void ShowStatisticsView(object? sender, EventArgs e)
        {
            // Jeżeli wcześniej był pokazany widok rezerwacji lub filmów to go zamknij
            if (adminReservationsView != null)
            {
                adminReservationsView.Close();
                adminReservationsView = null;
            }
            if (adminMoviesView != null)
            {
                adminMoviesView.Close();
                adminMoviesView = null;
            }
            if (adminStatisticsView == null)
            {
                // Utwórz nowy widok statysyk i dodaj go do głównego kontenera
                adminStatisticsView = new AdminStatisticView();
                new AdminStatisticPresenter(reservationRepository, adminStatisticsView, _mainAdminForm);
                _mainAdminForm.PanelContainer.Controls.Clear();
                _mainAdminForm.PanelContainer.Controls.Add((Form)adminStatisticsView);
                _mainAdminForm.PanelContainer.Tag = (Form)adminStatisticsView;
            }
        }
    }
}
