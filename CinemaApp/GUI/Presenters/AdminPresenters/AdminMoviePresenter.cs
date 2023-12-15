using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.Views.AdminViews;
using GUI.Views.UserViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GUI.Views.AdminViews.DeleteMessage;
using static GUI.Views.AdminViews.EditMovieForm;

namespace GUI.Presenters.AdminPresenters
{
    public class AdminMoviePresenter
    {
        private IAdminMoviesView _view;

        private IMovieRepository movieRepository;
        private IReservationRepository  reservationRepository;
        private BindingSource movieBindingSource;
        private List<Movie> moviesList;

        private IAddMovieView addMovieView;
        private List<IDeleteMessage> deleteMessages = new List<IDeleteMessage>();
        private List<IEditMovieView> editMovieViews = new List<IEditMovieView>();

        public AdminMoviePresenter(IMovieRepository movieRepository, IReservationRepository reservationRepository, IAdminMoviesView view)
        {
            this.movieRepository = movieRepository;
            this.reservationRepository = reservationRepository;

            this._view = view;

            this.movieBindingSource = new BindingSource();
            this._view.SetMoviesListBindingSource(movieBindingSource);
            moviesList = movieRepository.GetAllMovies();

            _view.addMovie += AddMovie;
            _view.modifyMovie += ModifyMovie;
            _view.deleteMovie += DeleteMovie;
            _view.clearFilters += ClearFilters;
            _view.searchMovie += SearchMovie;
            _view.sortASC += SortASC;
            _view.sortDSC += SortDSC;


            LoadMoviesList(moviesList);
            _view.BringToFront();
            _view.Show();
        }

        private void AddMovie(object? sender, EventArgs e)
        {
            // dużo wyjątków
            if (addMovieView == null)
            {
                addMovieView = new AddMovieForm();
                addMovieView.Show();
                addMovieView.addFormClosing += HandleCloseAddForm;
                addMovieView.submitAddForm += HandleSubmitAddMovie;
            }
            else
            {
                addMovieView.BringToFront();
            }          
            // tutaj formularz do wypełnienia (nowe okno ale może się otworzyć tylko raz dla danego filmu)
        }

        private void HandleCloseAddForm(object? sender, EventArgs e)
        {
            addMovieView = null;
        }

        private void HandleSubmitAddMovie(object? sender, EventArgs e)
        {
            // to nigdy null bo wywoła się zawsze gdy będzie już utworzony formularz
            string title = addMovieView.TitleValue.Text.ToString();
            string date = addMovieView.DateValue.Value.ToString("dd/MM/yyyy HH:mm");
            string price = addMovieView.PriceValue.Text.ToString();
            string duration = addMovieView.DurationValue.Value.ToString("HH:mm");
            string roomNumber = addMovieView.RoomNumberValue.Text.ToString();

            //AddMovie(string ? id, string title, string date, string price, string duration, string roomNumber)

            // UWAGA wyrzuca dużo wyjątków
            movieRepository.AddMovie(null, title, date, price, duration, roomNumber);

            // Po wszytskim jeśli udało się poprawnie dodać zamknięcie formularza i ustawienie wartości na null
            addMovieView.Close();
            addMovieView = null;

            // Po dodaniu należy odświeżyć listę filmów
            RefreshMovieList();           
        }

        private void ModifyMovie(object? sender, EventArgs e)
        {
            // tutaj formularz do wypełnienia (nowe okno ale może się otworzyć tylko raz dla danego filmu)
            // dużo wyjątków
            // Formularz powinien zawierać wypełnione wartości atrybutami filmu
            
            string[] all = movieBindingSource.Current.ToString().Split(",");
            string title = all[1].Split("=")[1].Trim();
            string id = all[0].Split("=")[1].Trim();
            string date = all[2].Split("=")[1].Trim();
            string price = all[3].Split("=")[1].Trim();
            string roomNumber = all[5].Split("=")[1].Trim()[0].ToString();

            IEditMovieView editMovieView = new EditMovieForm(id, title, date, price, roomNumber);
            IEditMovieView? existingView = editMovieViews.FirstOrDefault(form => form.ID == editMovieView.ID);
            if (existingView!=null)
            {
                existingView.BringToFront();
            }
            else
            {
                editMovieView.Show();
                editMovieView.submitEditForm += HandleSubmitEditMovie;
                editMovieView.editFormClosing += HandleCloseEditForm;
                editMovieViews.Add(editMovieView);
            }          
        }

        private void HandleCloseEditForm(object? sender, EventArgs e)
        {
            IEditMovieView edit = (IEditMovieView)sender;
            editMovieViews.Remove(edit);
        }

        private void HandleSubmitEditMovie(object? sender, EventArgs e)
        {
            string id = "";
            string date = "";
            string price = "";
            string room_nr = "";
            IEditMovieView edit = (IEditMovieView)sender;
            if (e is EditEventArgs editEventArgs)
            {
                id = editEventArgs.Id;
                date = (editEventArgs.Date != edit.OldDate) ? editEventArgs.Date : "";
                price = (editEventArgs.Price != edit.OldPrice) ? editEventArgs.Price : "";
                room_nr = (editEventArgs.RoomNumber != edit.OldRoomNumber) ? editEventArgs.RoomNumber : "";
            }
            if (price != "")
            {
                //THROWS EXCEPTIONS
                movieRepository.ModifyMoviePrice(id, price);
                RefreshMovieList();
            }
            if (date != "" || room_nr != "")
            {
                //THROWS EXCEPTIONS
                reservationRepository.ModifyMovieDateOrRoomWithReservation(id, date, room_nr);
                RefreshMovieList();
            }
            // jeśli to przeszło to powiadomienie i zamknięcie formularza
           
            if(price =="" && date=="" && room_nr == "")
            {
                // jeśli nic nie zmieniono to powinno wyświetlić się poraiwdomienie też 
            }
            edit.Close();
            editMovieViews.Remove(edit);          
        }

        private void DeleteMovie(object? sender, EventArgs e)
        {
            // tutaj powinno pokazać się message box z pytaniem czy napewno usunać chcesz
            string title = movieBindingSource.Current.ToString().Split(",")[1].Split("=")[1].Trim();
            string id = movieBindingSource.Current.ToString().Split(",")[0].Split("=")[1].Trim();

            IDeleteMessage newMessage = new DeleteMessage(title, id);
            IDeleteMessage? existingView = deleteMessages.FirstOrDefault(form => form.ID == newMessage.ID);
            if (existingView != null)
            {
                existingView.BringToFront();
            }
            else
            {
                newMessage.Show();
                newMessage.submitDelete += HandleSubmitDeleteMovie;
                newMessage.cancelDelete += HandleCancelDeleteMovie;
                newMessage.deleteFormClosing += HandleCloseDeleteForm;
                deleteMessages.Add(newMessage);
            }   
        }

        private void HandleCloseDeleteForm(object? sender, EventArgs e)
        {
            IDeleteMessage delete = (IDeleteMessage)sender;
            deleteMessages.Remove(delete);
        }

        private void HandleSubmitDeleteMovie(object? sender, EventArgs e)
        {
            string id="";
            if (e is DeleteEventArgs deleteEventArgs)
            {
                id = deleteEventArgs.Id;
            }

            // throws exceptions
            reservationRepository.RemoveMovieWithReservation(id);
            CloseDeleteMessage(sender);
            // Po usunięciu należy odświeżyć listę filmów
            RefreshMovieList();
        }

        private void HandleCancelDeleteMovie(object? sender, EventArgs e)
        {
            CloseDeleteMessage(sender);
        }
        private void CloseDeleteMessage(object? sender)
        {
            IDeleteMessage temp = null;
            foreach (IDeleteMessage mess in deleteMessages)
            {
                if (mess == sender)
                {
                    mess.Close();
                    temp = mess;
                }
            }
            if (temp != null)
            {
                deleteMessages.RemoveAll(m => m == temp);
            }
        }

        private void ClearFilters(object? sender, EventArgs e)
        {
            _view.SearchValue.Text = string.Empty;
            RefreshMovieList();
        }
        private void RefreshMovieList()
        {
            LoadMoviesList(moviesList);
            movieBindingSource.ResetBindings(false);
        }

        private void SearchMovie(object? sender, EventArgs e)
        {
            string search_value = (_view.SearchValue.Text != null) ? _view.SearchValue.Text : string.Empty;

            // throws exceptions
            List<Movie> filtredList = movieRepository.FilterList(search_value);

            LoadMoviesList(filtredList);

            movieBindingSource.ResetBindings(false);

        }

        private void SortASC(object? sender, EventArgs e)
        {
            string atribute = (_view.SortCriteria.SelectedItem != null) ? _view.SortCriteria.SelectedItem.ToString() : string.Empty;
            // jeśli "" wyrzuci wyjątek braku atrybutu
            List<Movie> sortedMovies = movieRepository.SortAscending(atribute);

            LoadMoviesList(sortedMovies);

            movieBindingSource.ResetBindings(false);
        }

        private void SortDSC(object? sender, EventArgs e)
        {
            string atribute = (_view.SortCriteria.SelectedItem != null) ? _view.SortCriteria.SelectedItem.ToString() : string.Empty;
            // jeśli "" wyrzuci wyjątek braku atrybutu
            List<Movie> sortedMovies = movieRepository.SortDescending(atribute);

            LoadMoviesList(sortedMovies);

            movieBindingSource.ResetBindings(false);
        }

        private void LoadMoviesList(List<Movie> movies)
        {
            // Throws exceptions
            //_movieRepository.ReadMoviesFromFile();
            
            //reservationBindingSource.DataSource = reservationsList;
            movieBindingSource.DataSource = movies.Select
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
