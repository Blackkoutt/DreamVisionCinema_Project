using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.UserForms;
using GUI.Views.UserViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Presenters.UserPresenters
{
    public class UserMoviePresenter
    {
        private IMoviesListView _movieslistView;
        private IMovieRepository _movieRepository;
        private IMovieReservationView movieReservationView;
        private IReservationRepository _reservationRepository;
        private BindingSource movieBindingSource;
        private List<Movie> moviesList;
        public UserMoviePresenter(IMoviesListView movieslistView, IMovieRepository moviesRepository, IReservationRepository reservationRepository)
        {
            _movieslistView = movieslistView;
            _movieRepository = moviesRepository;   
            _reservationRepository= reservationRepository;

            this.movieBindingSource = new BindingSource();
            this._movieslistView.SetMoviesListBindingSource(movieBindingSource);

            this._movieslistView.ShowMovieRoom += ShowMovieRoom;

            // Load data
            LoadMoviesList();
            _movieslistView.BringToFront();
            _movieslistView.Show();
        }

        private void ShowMovieRoom(object? sender, EventArgs e)
        {
            movieReservationView = new MovieReservationView();
            string currentMovieIdString = movieBindingSource.Current.ToString().Split(",")[0].Split("=")[1].Trim();
            Movie movie = _movieRepository.GetOneMovie(currentMovieIdString);

            new MovieReservationPresenter(movieReservationView, _reservationRepository, movie);
        }

        private void LoadMoviesList()
        {
            // Throws exceptions
            //_movieRepository.ReadMoviesFromFile();
            moviesList = _movieRepository.GetAllMovies();
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
