using CinemaApp.Exceptions;
using CinemaApp.Extensions;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Model;
using CinemaApp.Views;
using GUI.Interfaces;
using GUI.Views;
using GUI.Views.AdminViews;
using System.Resources;
using System.Windows.Shapes;
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
            
            _view.addMovie += AddMovie;
            _view.modifyMovie += ModifyMovie;
            _view.deleteMovie += DeleteMovie;
            _view.clearFilters += ClearFilters;
            _view.searchMovie += SearchMovie;
            _view.sortASC += SortASC;
            _view.sortDSC += SortDSC;
         
            _view.BringToFront();
            _view.Show();
            try
            {
                moviesList = movieRepository.GetAllMovies();
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
        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox(true);
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }
        private void AddMovie(object? sender, EventArgs e)
        {
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
        }

        private void HandleCloseAddForm(object? sender, EventArgs e)
        {
            addMovieView = null;
        }

        private void HandleSubmitAddMovie(object? sender, EventArgs e)
        {
            string title = addMovieView.TitleValue.Text.ToString();
            string date = addMovieView.DateValue.Value.ToString("dd/MM/yyyy HH:mm");
            string price = addMovieView.PriceValue.Text.ToString();
            string duration = addMovieView.DurationValue.Value.ToString("HH:mm");
            string roomNumber = addMovieView.RoomNumberValue.Text.ToString();

            try
            {
                movieRepository.AddMovie(null, title, date, price, duration, roomNumber);
            }
            catch (CannotConvertException CCE)
            {
                MakeAlert(CCE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch (IncorrectParametrException IPE)
            {
                MakeAlert(IPE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch (NoRoomWithGivenNumberException NRWGNE)
            {
                MakeAlert(NRWGNE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch (MoviesCollisionException MCE)
            {
                MakeAlert(MCE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch (Exception ex)
            {
                MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                return;
            }

            if (moviesList == null)
            {
                try
                {
                    moviesList = movieRepository.GetAllMovies();
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
            MakeAlert("Poprawnie dodano film do listy", CustomAlertBox.enmType.Success);
            // Po wszytskim jeśli udało się poprawnie dodać zamknięcie formularza i ustawienie wartości na null
            addMovieView.Close();
            addMovieView = null;

            // Po dodaniu należy odświeżyć listę filmów
            RefreshMovieList();           
        }

        private void ModifyMovie(object? sender, EventArgs e)
        {
            if (movieBindingSource.Current != null)
            {
                string[] all = movieBindingSource.Current.ToString().Split(",");
                string title = all[1].Split("=")[1].Trim();
                string id = all[0].Split("=")[1].Trim();
                string date = all[2].Split("=")[1].Trim();
                string price = all[3].Split("=")[1].Trim();
                string roomNumber = all[5].Split("=")[1].Trim()[0].ToString();

                IEditMovieView editMovieView = new EditMovieForm(id, title, date, price, roomNumber);
                IEditMovieView? existingView = editMovieViews.FirstOrDefault(form => form.ID == editMovieView.ID);
                if (existingView != null)
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
            else
            {
                MakeAlert("Lista filmów jest pusta", CustomAlertBox.enmType.Info);
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
                try
                {
                    movieRepository.ModifyMoviePrice(id, price);
                    RefreshMovieList();
                }
                catch (CannotConvertException CCE)
                {
                    MakeAlert(CCE.Message, CustomAlertBox.enmType.Error);
                    return;
                }
                catch(IncorrectParametrException IPE)
                {
                    MakeAlert(IPE.Message, CustomAlertBox.enmType.Error);
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
            if (date != "" || room_nr != "")
            {
                try
                {
                    reservationRepository.ModifyMovieDateOrRoomWithReservation(id, date, room_nr);
                    ModifyTicketJPG(id);
                    RefreshMovieList();
                }
                catch (CannotConvertException CCE)
                {
                    MakeAlert(CCE.Message, CustomAlertBox.enmType.Error);
                    return;
                }
                catch(NoMovieWithGivenIdException NMWGIE)
                {
                    MakeAlert(NMWGIE.Message, CustomAlertBox.enmType.Error);
                    return;
                }
                catch(IncorrectParametrException IPE)
                {
                    MakeAlert(IPE.Message, CustomAlertBox.enmType.Error);
                    return;
                }
                catch(NoRoomWithGivenNumberException NRWGNE)
                {
                    MakeAlert(NRWGNE.Message, CustomAlertBox.enmType.Error);
                    return;
                }
                catch(MoviesCollisionException MCE)
                {
                    MakeAlert(MCE.Message, CustomAlertBox.enmType.Error);
                    return;
                }
                catch(CannotDestroyTicketException CDTE)
                {
                    MakeAlert(CDTE.Message, CustomAlertBox.enmType.Error);
                    return;
                }
                catch(Exception ex)
                {
                    MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                    return;
                }
               
            }
            // jeśli to przeszło to powiadomienie i zamknięcie formularza
           
            if(price =="" && date=="" && room_nr == "")
            {
                MakeAlert("Nie dokonano żadnej zmiany. Film nie został zmodyfikowany.", CustomAlertBox.enmType.Info);
            }
            else
            {
                MakeAlert("Poprawnie zmodyfikowano film", CustomAlertBox.enmType.Success);
            }
            edit.Close();
            editMovieViews.Remove(edit);          
        }
        private void ModifyTicketJPG(string id)
        {
            int Id = Conversions.TryParseToInt(id, "Id powinno być wartością całkowitą");

            Movie movie = movieRepository.GetOneMovie(Id);
            if (movie == null)
            {
                throw new NoMovieWithGivenIdException("Brak filmu o podanym Id.");
            }
            if (reservationRepository.IsMovieHaveReservation(movie))
            {
                List<Reservation> reservation_list = reservationRepository.GetReservationForMovie(movie);
                foreach (Reservation res in reservation_list)
                {
                    //string seats = string.Join(", ", res.Seats);
                    //reservationRepository.DestroyTicketJPG(res.Id.ToString());
                    ITicketCreator ticketCreator = new TicketCreatorForm();
                    TicketCreatorPresenter ticketPresenter = new TicketCreatorPresenter(reservationRepository, ticketCreator);
                    ticketPresenter.UpdateTicket(res);
                    ticketCreator.Close();
                }
            }
        }

        private void DeleteMovie(object? sender, EventArgs e)
        {
            // tutaj powinno pokazać się message box z pytaniem czy napewno usunać chcesz
            if(movieBindingSource.Current!=null) 
            {
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
                    int a = 1;
                }
            }
            else
            {
                MakeAlert("Lista filmów jest pusta", CustomAlertBox.enmType.Info);
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
            try
            {
                reservationRepository.RemoveTicketForReservatedMovies(id);
                reservationRepository.RemoveMovieWithReservation(id);
                
            }
            catch (CannotConvertException CCE)
            {
                MakeAlert(CCE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch(NoMovieWithGivenIdException NMWGIE)
            {
                MakeAlert(NMWGIE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch(NoReservationWithGivenIdException NRWGIE)
            {
                MakeAlert(NRWGIE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch(CannotDestroyTicketException CDTE)
            {
                MakeAlert(CDTE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch(Exception ex)
            {
                MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                return;
            }
            MakeAlert("Pomyślnie usunięto film z listy", CustomAlertBox.enmType.Success);
            int b = deleteMessages.Count;
            CloseDeleteMessage(sender);
            // Po usunięciu należy odświeżyć listę filmów
            RefreshMovieList();
            if(moviesList.Count == 0)
            {
                moviesList = null;
            }
        }

        private void HandleCancelDeleteMovie(object? sender, EventArgs e)
        {
            CloseDeleteMessage(sender);
        }
        private void CloseDeleteMessage(object? sender)
        {
            IDeleteMessage temp = null;
            int c = deleteMessages.Count;
            foreach (IDeleteMessage mess in deleteMessages)
            {
                if (mess == sender)
                {
                    mess.Close();
                    temp = mess;
                    break;
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
            if(moviesList != null)
            {
                LoadMoviesList(moviesList);
                movieBindingSource.ResetBindings(false);
            }
            else
            {
                MakeAlert("Lista filmów jest pusta", CustomAlertBox.enmType.Info);
            }
            
        }

        private void SearchMovie(object? sender, EventArgs e)
        {
            string search_value = (_view.SearchValue.Text != null) ? _view.SearchValue.Text : string.Empty;
            List<Movie> filtredList;
            // throws exceptions
            if (moviesList != null)
            {
                try
                {
                    filtredList = movieRepository.FilterList(search_value);

                    LoadMoviesList(filtredList);

                    movieBindingSource.ResetBindings(false);
                }
                catch (CannotFindMatchingMovieException CFMME) 
                {
                    MakeAlert(CFMME.Message, CustomAlertBox.enmType.Info);
                    return;
                }
                catch(Exception ex)
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
            string atribute = (_view.SortCriteria.SelectedItem != null) ? _view.SortCriteria.SelectedItem.ToString() : string.Empty;
            List<Movie> sortedMovies;
            // jeśli "" wyrzuci wyjątek braku atrybutu
            if (moviesList != null)
            {
                try
                {
                    sortedMovies = movieRepository.SortAscending(atribute);

                    LoadMoviesList(sortedMovies);

                    movieBindingSource.ResetBindings(false);
                }
                catch (BadAttributeException BAE)
                {
                    MakeAlert(BAE.Message, CustomAlertBox.enmType.Info);
                    return;
                }
                catch(ListIsEmptyException LIEE)
                {
                    MakeAlert(LIEE.Message, CustomAlertBox.enmType.Info);
                    return;
                }
                catch(Exception ex)
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

        private void SortDSC(object? sender, EventArgs e)
        {
            string atribute = (_view.SortCriteria.SelectedItem != null) ? _view.SortCriteria.SelectedItem.ToString() : string.Empty;
            List<Movie> sortedMovies;
            // jeśli "" wyrzuci wyjątek braku atrybutu
            if (moviesList != null)
            {             
                try
                {
                    sortedMovies = movieRepository.SortDescending(atribute);

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
