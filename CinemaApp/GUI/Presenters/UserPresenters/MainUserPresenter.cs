using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Interfaces;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.UserForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FontAwesome.Sharp;

namespace GUI.Presenters.UserPresenters
{
    public class MainUserPresenter
    {
        private IMainUserForm _mainUserForm;
        IReservationListView reservationListView;
        public MainUserPresenter(IMainUserForm mainUserForm)
        {
            _mainUserForm = mainUserForm;
            this._mainUserForm.ShowReservationsView += ShowReservationsView;
            this._mainUserForm.ShowMoviesView += ShowMoviesView;
            this._mainUserForm.LoadDefault += LoadDefault;
        }

        private void LoadDefault(object? sender, EventArgs e)
        {
            if (reservationListView != null)
            {
                reservationListView.Close();
                reservationListView = null;
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
        }

        private void ShowReservationsView(object? sender, EventArgs e)
        {

            // zamkniecie filmu
            if (reservationListView == null)
            {
                // to możliwe ze trzeba stad wywalic
                IMovieRepository movieRepository = new MovieRepository();
                movieRepository.ReadMoviesFromFile(); // throws exceptions
                IReservationRepository reservationRepository = new ReservationRepository(movieRepository);



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
