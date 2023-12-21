using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Interfaces;
using GUI.Interfaces;
using GUI.UserForms;
using FontAwesome.Sharp;
using GUI.Views.UserViews;
using CinemaApp.Exceptions;
using CinemaApp.Views;
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
            this._mainUserForm.ShowMoviesView += ShowMoviesView;
            this._mainUserForm.ShowReservationsView += ShowReservationsView;
            this._mainUserForm.ShowMoviesView += ShowMoviesView;
            this._mainUserForm.LoadDefault += LoadDefault;
            CheckForDeletedOrEditedMovies();
        }
        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox(false);
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }
        private void CheckForDeletedOrEditedMovies()
        {

            List<string> info_about_deleted_movies = new List<string>();
            List<string> info_about_modificated_movies = new List<string>();
            try
            {
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

            if (info_about_deleted_movies.Any())
            {
                SetInfoAboutDeletedReservations(info_about_deleted_movies);
            }
            if (info_about_modificated_movies.Any())
            {
                SetInfoAboutModificatedReservations(info_about_modificated_movies);
            }
        }
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
        private void LoadDefault(object? sender, EventArgs e)
        {
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
            // też dla filmu

            _mainUserForm.DisableButton();
            _mainUserForm.ButtonBorderLeft.Visible = false;

            _mainUserForm.topIcon.IconChar = IconChar.House;
            _mainUserForm.topIcon.IconColor = Color.MediumPurple;

            _mainUserForm.lblTitle.Text = "Strona główna";
            // tutaj może być problem z tym że logo jest umiejscowione wzgledem poprzedniego rozmiaru okna
            _mainUserForm.MainBigLogo.Anchor= AnchorStyles.None;
            _mainUserForm.MainBigLogo.Dock = DockStyle.None;
            _mainUserForm.PanelContainer.Controls.Add(_mainUserForm.MainBigLogo); 
        }

        private void ShowMoviesView(object? sender, EventArgs e)
        {
            // Tutaj inicjalizacja nowego formularza
            if(reservationListView != null) 
            {
                reservationListView.Close();
                reservationListView = null;
            }
            if (moviesListView == null)
            {
                moviesListView = new MoviesListView();
                new UserMoviePresenter(moviesListView, movieRepository, reservationRepository);
                _mainUserForm.PanelContainer.Controls.Clear();
                _mainUserForm.PanelContainer.Controls.Add((Form)moviesListView);
                _mainUserForm.PanelContainer.Tag = (Form)moviesListView;

                _mainUserForm.lblTitle.Text = ((Form)moviesListView).Text;
            }
            
           
        }

        private void ShowReservationsView(object? sender, EventArgs e)
        {
                if (moviesListView != null)
                {
                    moviesListView.Close();
                    moviesListView = null;
                }
                if (reservationListView == null)
                {
                    reservationListView = new ReservationListView();
                    new UserReservationPresenter(reservationListView, reservationRepository);
                    _mainUserForm.PanelContainer.Controls.Clear();
                    _mainUserForm.PanelContainer.Controls.Add((Form)reservationListView);
                    _mainUserForm.PanelContainer.Tag = (Form)reservationListView;

                    _mainUserForm.lblTitle.Text = ((Form)reservationListView).Text;
                }
            
        }
    }
}
