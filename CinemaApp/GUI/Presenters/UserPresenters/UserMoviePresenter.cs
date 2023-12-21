using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.Views;
using GUI.Views.UserViews;

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

            _movieslistView.clearFiltersUser += ClearFilters;
            _movieslistView.searchMovieUser += SearchMovie;
            _movieslistView.sortASCUser += SortASC;
            _movieslistView.sortDSCUser += SortDSC;

            _movieslistView.BringToFront();
            _movieslistView.Show();

            // Load data
            try
            {
                moviesList = _movieRepository.GetAllMovies();
                LoadMoviesList(moviesList);
            }
            catch (MovieListIsEmptyException MLIEE)
            {
                MakeAlert(MLIEE.Message, CustomAlertBox.enmType.Info);
            }
            catch (Exception ex)
            {
                MakeAlert(ex.Message, CustomAlertBox.enmType.Info);
            }
            // LoadMoviesList();
            
        }

        private void SortDSC(object? sender, EventArgs e)
        {
            string atribute = (_movieslistView.SortCriteria.SelectedItem != null) ? _movieslistView.SortCriteria.SelectedItem.ToString() : string.Empty;
            List<Movie> sortedMovies;
            // jeśli "" wyrzuci wyjątek braku atrybutu
            if (moviesList != null)
            {
                try
                {
                    sortedMovies = _movieRepository.SortDescending(atribute);

                    LoadMoviesList(sortedMovies);

                    movieBindingSource.ResetBindings(false);
                }
                catch (BadAttributeException BAE)
                {
                    MakeAlert(BAE.Message, CustomAlertBox.enmType.Info);
                    return;
                }
                catch (ListIsEmptyException LIEE)
                {
                    MakeAlert(LIEE.Message, CustomAlertBox.enmType.Info);
                    return;
                }
                catch (Exception ex)
                {
                    MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                    return;
                }
            }
            else
            {
                MakeAlert("Lista filmów jest pusta", CustomAlertBox.enmType.Info);
            }
        }

        private void SortASC(object? sender, EventArgs e)
        {
            string atribute = (_movieslistView.SortCriteria.SelectedItem != null) ? _movieslistView.SortCriteria.SelectedItem.ToString() : string.Empty;
            List<Movie> sortedMovies;
            // jeśli "" wyrzuci wyjątek braku atrybutu
            if (moviesList != null)
            {
                try
                {
                    sortedMovies = _movieRepository.SortAscending(atribute);

                    LoadMoviesList(sortedMovies);

                    movieBindingSource.ResetBindings(false);
                }
                catch (BadAttributeException BAE)
                {
                    MakeAlert(BAE.Message, CustomAlertBox.enmType.Info);
                    return;
                }
                catch (ListIsEmptyException LIEE)
                {
                    MakeAlert(LIEE.Message, CustomAlertBox.enmType.Info);
                    return;
                }
                catch (Exception ex)
                {
                    MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                    return;
                }

            }
            else
            {
                MakeAlert("Lista filmów jest pusta", CustomAlertBox.enmType.Info);
            }
        }

        private void SearchMovie(object? sender, EventArgs e)
        {
            string search_value = (_movieslistView.SearchValue.Text != null) ? _movieslistView.SearchValue.Text : string.Empty;
            List<Movie> filtredList;
            // throws exceptions
            if (moviesList != null)
            {
                try
                {
                    filtredList = _movieRepository.FilterList(search_value);

                    LoadMoviesList(filtredList);

                    movieBindingSource.ResetBindings(false);
                }
                catch (CannotFindMatchingMovieException CFMME)
                {
                    MakeAlert(CFMME.Message, CustomAlertBox.enmType.Info);
                    return;
                }
                catch (Exception ex)
                {
                    MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                    return;
                }
            }
            else
            {
                MakeAlert("Lista filmów jest pusta", CustomAlertBox.enmType.Info);
            }
        }

        private void ClearFilters(object? sender, EventArgs e)
        {
            _movieslistView.SearchValue.Text = string.Empty;
            RefreshMovieList();
        }
        private void RefreshMovieList()
        {
            if (moviesList != null)
            {
                LoadMoviesList(moviesList);
                movieBindingSource.ResetBindings(false);
            }
            else
            {
                MakeAlert("Lista filmów jest pusta", CustomAlertBox.enmType.Info);
            }

        }

        private void ShowMovieRoom(object? sender, EventArgs e)
        {
            movieReservationView = new MovieReservationView();
            string currentMovieIdString = movieBindingSource.Current.ToString().Split(",")[0].Split("=")[1].Trim();
            Movie movie;
            try
            {
                movie = _movieRepository.GetOneMovie(currentMovieIdString);
                new MovieReservationPresenter(movieReservationView, _reservationRepository, movie);
            }
            catch(CannotConvertException CCE)
            {
                MakeAlert(CCE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch(NoMovieWithGivenIdException NMWGIE)
            {
                MakeAlert(NMWGIE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch(Exception ex)
            {
                MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                return;
            }
        }

        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox(true);
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }

        private void LoadMoviesList(List<Movie> movies)
        {
            if (movies != null)
            {
                movieBindingSource.DataSource = movies.Select
               (mov => new {
                   ID = mov.Id,
                   Tytuł = mov.Title,
                   Data = mov.Date.ToString("dd/MM/yyyy HH:mm"),
                   Cena = mov.Price,
                   Długość = $"{mov.Duration} h",
                   Sala = mov.Room.Number.ToString(),
               });
            }
        }
    }
}
