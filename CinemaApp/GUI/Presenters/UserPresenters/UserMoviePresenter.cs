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

            // Utstawienie BindingSource dla dataGridView
            this.movieBindingSource = new BindingSource();
            this._movieslistView.SetMoviesListBindingSource(movieBindingSource);

            // Dołączenie obsługi eventów
            _movieslistView.ShowMovieRoom += ShowMovieRoom;

            _movieslistView.clearFiltersUser += ClearFilters;
            _movieslistView.searchMovieUser += SearchMovie;
            _movieslistView.sortASCUser += SortASC;
            _movieslistView.sortDSCUser += SortDSC;

            _movieslistView.BringToFront();
            _movieslistView.Show();

            // Pobranie danych z pliku i dodanie ich do listy dataGridView
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
        }


        // Metoda obslugująca event wciśnięcia przycisku DSC - sortowanie
        private void SortDSC(object? sender, EventArgs e)
        {
            // Pobranie wybranego atrybutu z listy rozwijanej
            string atribute = (_movieslistView.SortCriteria.SelectedItem != null) ? _movieslistView.SortCriteria.SelectedItem.ToString() : string.Empty;
            List<Movie> sortedMovies;
            if (moviesList != null)
            {
                try
                {
                    sortedMovies = _movieRepository.SortDescending(atribute);   // Metoda zwraca postrowaną listę względem danego atrybutu
                       
                    LoadMoviesList(sortedMovies);   // Ładowanie postorowanej listy do dataGridView

                    movieBindingSource.ResetBindings(false);    // Zresetowanie dataGridView
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


        // Metoda obslugująca event wciśnięcia przycisku ASC - sortowanie
        private void SortASC(object? sender, EventArgs e)
        {
            // Pobranie wybranego atrybutu z listy rozwijanej
            string atribute = (_movieslistView.SortCriteria.SelectedItem != null) ? _movieslistView.SortCriteria.SelectedItem.ToString() : string.Empty;
            List<Movie> sortedMovies;
            if (moviesList != null)
            {
                try
                {
                    sortedMovies = _movieRepository.SortAscending(atribute);    // Metoda zwraca postrowaną listę względem danego atrybutu

                    LoadMoviesList(sortedMovies);   // Ładowanie postorowanej listy do dataGridView

                    movieBindingSource.ResetBindings(false);    // Zresetowanie dataGridView
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


        // Metoda obsługująca event wciśnięcia przycisku "Szukaj"
        private void SearchMovie(object? sender, EventArgs e)
        {
            // Poberanie z widoku wartości względem której odbędzie się wyszukiwanie 
            string search_value = (_movieslistView.SearchValue.Text != null) ? _movieslistView.SearchValue.Text : string.Empty;
            List<Movie> filtredList;
            if (moviesList != null)
            {
                try
                {
                    filtredList = _movieRepository.FilterList(search_value);    // Metoda zwraca dopasowane rekordy

                    LoadMoviesList(filtredList);    // Ładowanie przefiltrowanej listy do dataGridView

                    movieBindingSource.ResetBindings(false);    // Odświeżenie dataGridView
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


        // Metoda obsługująca event wciśnięcia przycisku "Wyczyść filtry"
        private void ClearFilters(object? sender, EventArgs e)
        {
            _movieslistView.SearchValue.Text = string.Empty;
            RefreshMovieList();
        }


        // Metoda odwieżająca listę dataGridView
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


        // Metoda obsługująca event wciśnięcia przycisku "Rezerwuj"
        private void ShowMovieRoom(object? sender, EventArgs e)
        {
            movieReservationView = new MovieReservationView();

            // Pobranie id wybranego filmu
            string currentMovieIdString = movieBindingSource.Current.ToString().Split(",")[0].Split("=")[1].Trim();
            Movie movie;
            try
            {
                // Pobranie filmu o danym id z listy
                movie = _movieRepository.GetOneMovie(currentMovieIdString);

                // Utworzenie prezentera - graficzna reprezentacja miejsc w sali kinowej
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


        // Metoda tworząca Alert (Success, Info, Error)
        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox(true);
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }

        // Metoda ładująca listę do dataGridView
        private void LoadMoviesList(List<Movie> movies)
        {
            if (movies != null)
            {
                // Przypisanie listy do BindingSource dataGridView
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
