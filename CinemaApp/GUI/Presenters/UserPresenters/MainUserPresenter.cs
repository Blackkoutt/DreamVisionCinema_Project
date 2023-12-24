using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Interfaces;
using GUI.Interfaces;
using GUI.UserForms;
using FontAwesome.Sharp;
using GUI.Views.UserViews;
using CinemaApp.Exceptions;
using GUI.Views;
using CinemaApp.Model;

namespace GUI.Presenters.UserPresenters
{
    public class MainUserPresenter
    {
        private IMainUserForm _mainUserForm;
        private IReservationListView reservationListView;
        private IMoviesListView moviesListView;
        private IMovieRepository movieRepository;
        private IReservationRepository reservationRepository;

        private List<Movie> moviesList;

        public MainUserPresenter(IMainUserForm mainUserForm, IMovieRepository movieRepository, IReservationRepository reservationRepository)
        {
            this.movieRepository = movieRepository;
            this.reservationRepository = reservationRepository;
            _mainUserForm = mainUserForm;

            // Dodanie obsługi eventów widoku
            this._mainUserForm.ShowMoviesView += ShowMoviesView;
            this._mainUserForm.ShowReservationsView += ShowReservationsView;
            this._mainUserForm.ShowMoviesView += ShowMoviesView;
            this._mainUserForm.LoadDefault += LoadDefault;
            CheckForDeletedOrEditedMovies();    // Sprawdzenie czy istnieją usunięte lub zmodyfikowane filmy
        }

        // Metoda tworząca powiadomienie (Success, Error, Info)
        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox(false);
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }

        // Metoda sprawdzająca czy istnieją usunięte lub edytowane filmy
        private void CheckForDeletedOrEditedMovies()
        {
            List<string> info_about_deleted_movies = new List<string>();
            List<string> info_about_modificated_movies = new List<string>();
            try
            {
                // Pobranie listy usuniętych filmów z pliku
                info_about_deleted_movies = reservationRepository.CheckDeletedReservations();
            }
            catch (CannotReadFileException)
            {
                reservationRepository.CreateTempDeleteFile();
            }
            catch (Exception ex)
            {
                MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                return;
            }
            try
            {
                // Pobranie listy zmodyfikowanych filmów z pliku
                info_about_modificated_movies = reservationRepository.CheckModificatedMoviesWithReservation();
            }
            catch (CannotReadFileException)
            {
                reservationRepository.CreateTempModificationFile();
            }
            catch (Exception ex)
            {
                MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                return;
            }

            // Jeśli któraś z list zawiera cokolwiek wypisz informację na ekranie
            if (info_about_deleted_movies.Any())
            {
                SetInfoAboutDeletedReservations(info_about_deleted_movies);
            }
            if (info_about_modificated_movies.Any())
            {
                SetInfoAboutModificatedReservations(info_about_modificated_movies);
            }
        }


        // Metoda wypisująca informacje o zmodyfikowanych filmach (zmodyfikowane zostały także bilety)
        private void SetInfoAboutModificatedReservations(List<string> info_list)
        {
            string info;
            for(int i = info_list.Count - 1; i > 0; i--)
            {
                if (info_list[i][1] == '!')
                {
                    info = info_list[i-1].Substring("[!] ".Length) + " " + info_list[i].Substring("[!] ".Length);
                    MakeAlert(info, CustomAlertBox.enmType.Info);
                    i -= 1;
                }
                else
                {
                    info = info_list[i].Substring("[V] ".Length);
                    MakeAlert(info, CustomAlertBox.enmType.Success);
                }
                if ((i - 1) == 0)
                {
                    break;
                }
            }
        }


        // Metoda wypisująca informacje o usuniętych filmach (usunięte zostały także bilety)
        private void SetInfoAboutDeletedReservations(List<string> info_list)
        {
            string info;
            for (int i = 0; i < info_list.Count; i++)
            {
                info = info_list[i].Substring("[!] ".Length) + " " + info_list[i + 1].Substring("[!] ".Length);
                MakeAlert(info, CustomAlertBox.enmType.Info);
                if ((i + 1) == info_list.Count)
                {
                    break;
                }
                i += 1;
            }
        }

        // Metoda ładująca podstawowy widok (logo aplikacji)
        private void LoadDefault(object? sender, EventArgs e)
        {
            // Jeśli wcześniej otwarty był formularz rezerwacji lub filmów to zamknij je 
            if (reservationListView != null)
            {
                reservationListView.Close();
                reservationListView = null;
            }
            if (moviesListView != null)
            {
                moviesListView.Close();
                moviesListView = null;
            }
            // Zmień właściowści przycisku w menu
            _mainUserForm.DisableButton();
            _mainUserForm.ButtonBorderLeft.Visible = false;

            // Zmień właściowści wyświetlanego tyułu na górze
            _mainUserForm.topIcon.IconChar = IconChar.House;
            _mainUserForm.topIcon.IconColor = Color.MediumPurple;

            _mainUserForm.lblTitle.Text = "Strona główna";
            _mainUserForm.MainBigLogo.Anchor= AnchorStyles.None;
            _mainUserForm.MainBigLogo.Dock = DockStyle.None;

            // Dodaj do głównego kontenera logo
            _mainUserForm.PanelContainer.Controls.Add(_mainUserForm.MainBigLogo); 
        }


        // Metoda pokazująca widok listy fimów
        private void ShowMoviesView(object? sender, EventArgs e)
        {
            // Jeśli był otwarty widok rezerwacji to go zamknij
            if(reservationListView != null) 
            {
                reservationListView.Close();
                reservationListView = null;
            }
            if (moviesListView == null)
            {
                // Utwórz nowy widok listy filmów
                moviesListView = new MoviesListView();
                new UserMoviePresenter(moviesListView, movieRepository, reservationRepository);
                _mainUserForm.PanelContainer.Controls.Clear();

                // Dodaj go do głównego kontenera 
                _mainUserForm.PanelContainer.Controls.Add((Form)moviesListView);
                _mainUserForm.PanelContainer.Tag = (Form)moviesListView;
                _mainUserForm.lblTitle.Text = ((Form)moviesListView).Text;  // Ustaw tekst na górze ekranu
            }       
        }


        // Metoda pokazująca widok listy rezerwacji
        private void ShowReservationsView(object? sender, EventArgs e)
        {
            // Jeśli był otwarty widok listy filmów to go zamknij
            if (moviesListView != null)
            {
                moviesListView.Close();
                moviesListView = null;
            }
            if (reservationListView == null)
            {
                // Utwórz nowy widok listy rezerwacji
                reservationListView = new ReservationListView();
                new UserReservationPresenter(reservationListView, reservationRepository);
                _mainUserForm.PanelContainer.Controls.Clear();

                // Dodaj go do głównego kontenera 
                _mainUserForm.PanelContainer.Controls.Add((Form)reservationListView);
                _mainUserForm.PanelContainer.Tag = (Form)reservationListView;
                _mainUserForm.lblTitle.Text = ((Form)reservationListView).Text; // Ustaw tekst na górze ekranu
            } 
        }
    }
}
