using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.Views.UserViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Presenters.AdminPresenters
{
    public class AdminMoviePresenter
    {
        private IAdminMoviesView _view;

        private IMovieRepository movieRepository;
        private IReservationRepository  reservationRepository;
        private BindingSource movieBindingSource;
        private List<Movie> moviesList;

        public AdminMoviePresenter(IMovieRepository movieRepository, IReservationRepository reservationRepository, IAdminMoviesView view)
        {
            this.movieRepository = movieRepository;
            this.reservationRepository = reservationRepository;

            this._view = view;

            this.movieBindingSource = new BindingSource();
            this._view.SetMoviesListBindingSource(movieBindingSource);

            LoadMoviesList();
            _view.BringToFront();
            _view.Show();
        }

        private void LoadMoviesList()
        {
            // Throws exceptions
            //_movieRepository.ReadMoviesFromFile();
            moviesList = movieRepository.GetAllMovies();
            //reservationBindingSource.DataSource = reservationsList;
            movieBindingSource.DataSource = moviesList.Select
                (mov => new {
                    ID = mov.Id,
                    Tytuł = mov.Title,
                    Data = mov.Date.ToString("dd/MM/yyyy HH:mm"),
                    Cena = mov.Price,
                    Długość = $"{mov.Duration} h",
                    Sala = mov.Room.Number.ToString(),
                });
            // _reservationlistView.SetReservationListBindingSource(res);
        }
    }
}
