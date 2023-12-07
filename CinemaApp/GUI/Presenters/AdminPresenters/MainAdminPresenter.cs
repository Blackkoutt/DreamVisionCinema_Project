using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Interfaces;
using GUI.UserForms;
using GUI.Views.UserViews;
using GUI.Views.AdminViews;
using GUI.Presenters.UserPresenters;

namespace GUI.Presenters.AdminPresenters
{
    public class MainAdminPresenter
    {
        private IMovieRepository movieRepository;
        private IReservationRepository reservationRepository;
        // widoki
        private IMainAdminForm _mainAdminForm;
        // widoki
        private IAdminMoviesView adminMoviesView;
        private IAdminStatisticsView adminStatisticsView;
        private IAdminReservationsView adminReservationsView;
        public MainAdminPresenter(IMovieRepository movieRepository, IReservationRepository reservationRepository, IMainAdminForm mainAdminForm)
        {
            this.movieRepository = movieRepository;
            this.reservationRepository = reservationRepository;

            _mainAdminForm = mainAdminForm;

            _mainAdminForm.AdminLoadDefault += LoadDefault;
            _mainAdminForm.ShowAdminStatisticsView += ShowStatisticsView;
            _mainAdminForm.ShowAdminMoviesView += ShowMoviesView;
            _mainAdminForm.ShowAdminReservationsView += ShowReservationsView;
        }
        private void LoadDefault(object? sender, EventArgs e)
        {
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
            _mainAdminForm.MainBigLogo.Anchor = AnchorStyles.None;
            _mainAdminForm.MainBigLogo.Dock = DockStyle.None;
            _mainAdminForm.PanelContainer.Controls.Add(_mainAdminForm.MainBigLogo);
        }

        private void ShowReservationsView(object? sender, EventArgs e)
        {
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
                adminReservationsView = new AdminReservationListView();
                new AdminReservationPresenter(reservationRepository, adminReservationsView);
                _mainAdminForm.PanelContainer.Controls.Clear();
                _mainAdminForm.PanelContainer.Controls.Add((Form)adminReservationsView);
                _mainAdminForm.PanelContainer.Tag = (Form)adminReservationsView;

                //_mainUserForm.lblTitle.Text = ((Form)moviesListView).Text;

            }
        }

        private void ShowMoviesView(object? sender, EventArgs e)
        {
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
                adminMoviesView = new AdminMoviesListView();
                new AdminMoviePresenter(movieRepository,reservationRepository, adminMoviesView);
                _mainAdminForm.PanelContainer.Controls.Clear();
                _mainAdminForm.PanelContainer.Controls.Add((Form)adminMoviesView);
                _mainAdminForm.PanelContainer.Tag = (Form)adminMoviesView;
            }
        }

        private void ShowStatisticsView(object? sender, EventArgs e)
        {
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
                adminStatisticsView = new AdminStatisticView();
                new AdminStatisticPresenter(reservationRepository, adminStatisticsView);

                _mainAdminForm.PanelContainer.Controls.Clear();
                _mainAdminForm.PanelContainer.Controls.Add((Form)adminStatisticsView);
                _mainAdminForm.PanelContainer.Tag = (Form)adminStatisticsView;
            }
        }

        
    }
}
