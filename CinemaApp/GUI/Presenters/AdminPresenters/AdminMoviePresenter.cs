using CinemaApp.Exceptions;
using CinemaApp.Extensions;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.Views;
using GUI.Views.AdminViews;
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

        // Listy otwartych okien
        private List<IDeleteMessage> deleteMessages = new List<IDeleteMessage>();
        private List<IEditMovieView> editMovieViews = new List<IEditMovieView>();

        public AdminMoviePresenter(IMovieRepository movieRepository, IReservationRepository reservationRepository, IAdminMoviesView view)
        {
            this.movieRepository = movieRepository;
            this.reservationRepository = reservationRepository;

            this._view = view;

            // Przypisanie bindingSource do dataGridView
            this.movieBindingSource = new BindingSource();
            this._view.SetMoviesListBindingSource(movieBindingSource);
            

            // Dodanie obsługi eventów generowanych przez widok 
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
                moviesList = movieRepository.GetAllMovies();    // Pobranie listy filmów
                LoadMoviesList(moviesList); // Załadowanie listy filmów do dataGridView
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

        // Metoda tworząca powiadomienie (Success, Error, Info)
        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox(true);
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }


        // Metoda obsługująca event kliknięcia w przycisk "Dodaj film"
        private void AddMovie(object? sender, EventArgs e)
        {
            // Jeśli nie ma otwartego okna "Dodaj film"
            if (addMovieView == null)
            {
                // Otwórz nowe okno (widok)
                addMovieView = new AddMovieForm();
                addMovieView.Show();

                // Dodaj obsługę eventów generowanych przez ten widok
                addMovieView.addFormClosing += HandleCloseAddForm;
                addMovieView.submitAddForm += HandleSubmitAddMovie;
            }
            else
            {
                // Jeśli jest już otwarte okno "Dodaj film" to wyświetl je na froncie ekranu
                addMovieView.BringToFront();
            }          
        }


        // Metoda obsługująca event zamknięcia okna "Dodaj film"
        private void HandleCloseAddForm(object? sender, EventArgs e)
        {
            addMovieView = null;
        }


        // Metoda obsługująca kliknięcie przycisku "Dodaj film" w widoku dodawania filmu
        private void HandleSubmitAddMovie(object? sender, EventArgs e)
        {
            // Pobranie z widoku informacji wprowadzonych przez użytkownika
            string title = addMovieView.TitleValue.Text.ToString();
            string date = addMovieView.DateValue.Value.ToString("dd/MM/yyyy HH:mm");
            string price = addMovieView.PriceValue.Text.ToString();
            string duration = addMovieView.DurationValue.Value.ToString("HH:mm");
            string roomNumber = addMovieView.RoomNumberValue.Text.ToString();

            try
            {
                movieRepository.AddMovie(null, title, date, price, duration, roomNumber);   // Wywołanie metody dodającej film
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
                    moviesList = movieRepository.GetAllMovies();    // Jeśli lista była wcześniej pusta to pobierz całą listę
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

            // Po poprawnym dodaniu filmu wyświetl komunikat, zamknij widok dodawania i odśwież dataGridView
            MakeAlert("Poprawnie dodano film do listy", CustomAlertBox.enmType.Success);
            addMovieView.Close();
            addMovieView = null;
            RefreshMovieList();           
        }


        // Metoda obsługująca zdarzenie kliknięcia w przycisk "Modyfikuj film"
        private void ModifyMovie(object? sender, EventArgs e)
        {
            if (movieBindingSource.Current != null)
            {   
                // Pobranie wymaganych informacji na temat wybranego do edycji filmu
                string[] all = movieBindingSource.Current.ToString().Split(",");
                string title = all[1].Split("=")[1].Trim();
                string id = all[0].Split("=")[1].Trim();
                string date = all[2].Split("=")[1].Trim();
                string price = all[3].Split("=")[1].Trim();
                string roomNumber = all[5].Split("=")[1].Trim()[0].ToString();

                // Utworzenie widoku edycji filmu i uzupełnienie go akutualnymi informacjami na temat filmu
                IEditMovieView editMovieView = new EditMovieForm(id, title, date, price, roomNumber);

                // Sprawdzenie czy taki widok już istnieje 
                IEditMovieView? existingView = editMovieViews.FirstOrDefault(form => form.ID == editMovieView.ID);
                if (existingView != null)
                {   
                    // Jeśli istnieje wyświetl go na froncie ekranu
                    existingView.BringToFront();
                }
                else
                {
                    // Jeśli nie pokaż nowy widok edycji, dodaj eventHandlery i dodaj widok do listy widoków
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


        // Metoda obsługująca event zamknięcia formulrza edycji
        private void HandleCloseEditForm(object? sender, EventArgs e)
        {
            // Usunięcie formularza edycji z listy widoków edycji
            IEditMovieView edit = (IEditMovieView)sender;
            editMovieViews.Remove(edit);
        }


        // Metoda obsługująca event kliknięcia w przycisk "Zapisz" w formualrzu edycji filmu
        private void HandleSubmitEditMovie(object? sender, EventArgs e)
        {
            // Defaultowe wartości
            string id = "";
            string date = "";
            string price = "";
            string room_nr = "";

            // Pobranie wprowadzonych w formularzu danych
            IEditMovieView edit = (IEditMovieView)sender;
            if (e is EditEventArgs editEventArgs)
            {
                id = editEventArgs.Id;
                date = (editEventArgs.Date != edit.OldDate) ? editEventArgs.Date : "";
                price = (editEventArgs.Price != edit.OldPrice) ? editEventArgs.Price : "";
                room_nr = (editEventArgs.RoomNumber != edit.OldRoomNumber) ? editEventArgs.RoomNumber : "";
            }

            // Jeśli cena filmu została zmieniona
            if (price != "")
            {
                try
                {
                    // Zaktualizuj cenę filmu a następnie widok
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

            // Jeżeli data lub numer sali filmu zostały zmienione
            if (date != "" || room_nr != "")
            {
                try
                {
                    // Zaktualizuj datę lub salę oraz odpowiedni bilet, a następnie także widok listy filmów
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
            
            // Jeśli nic nie uległo zmianie wyświetl odpowiedni komunikat
            if(price =="" && date=="" && room_nr == "")
            {
                MakeAlert("Nie dokonano żadnej zmiany. Film nie został zmodyfikowany.", CustomAlertBox.enmType.Info);
            }
            else
            {
                MakeAlert("Poprawnie zmodyfikowano film", CustomAlertBox.enmType.Success);
            }

            // Po pomyślnym wydkonaniu edycji zamknij formularz i usuń go z listy widoków edycji
            edit.Close();
            editMovieViews.Remove(edit);          
        }


        // Metoda modyfikująca bilet zapisany w pliku JPG
        private void ModifyTicketJPG(string id)
        {
            int Id = Conversions.TryParseToInt(id, "Id powinno być wartością całkowitą");

            // Pobranie filmu o podanym ID
            Movie movie = movieRepository.GetOneMovie(Id);
            if (movie == null)
            {
                throw new NoMovieWithGivenIdException("Brak filmu o podanym Id.");
            }
            // Jeśli film posiada jakąkolwiek rezerwację
            if (reservationRepository.IsMovieHaveReservation(movie))
            {
                // Pobierz wszytskie rezerwacje na dany film
                List<Reservation> reservation_list = reservationRepository.GetReservationForMovie(movie);
                foreach (Reservation res in reservation_list)
                {
                    // Dla każdej rezerwacji zaktualizuj bilet
                    ITicketCreator ticketCreator = new TicketCreatorForm();
                    TicketCreatorPresenter ticketPresenter = new TicketCreatorPresenter(reservationRepository, ticketCreator);
                    ticketPresenter.UpdateTicket(res);
                    ticketCreator.Close();
                }
            }
        }



        // Metoda obsługująca event kliknięcia w przycisk "Usuń"
        private void DeleteMovie(object? sender, EventArgs e)
        {
            if(movieBindingSource.Current!=null) 
            {
                // Pobranie podstawowych informacji o wybranym filmie
                string title = movieBindingSource.Current.ToString().Split(",")[1].Split("=")[1].Trim();
                string id = movieBindingSource.Current.ToString().Split(",")[0].Split("=")[1].Trim();

                // Utworzenie nowego okna potwierdzenie usunięcia filmu
                IDeleteMessage newMessage = new DeleteMessage(title, id);

                // Sprawdzenie czy takie okno jest już otwarte
                IDeleteMessage? existingView = deleteMessages.FirstOrDefault(form => form.ID == newMessage.ID);

               
                if (existingView != null)
                {
                    // Jeśli jest już otwarte pokaż je na froncie ekranu
                    existingView.BringToFront();
                }
                else
                {
                    // Jeśli nie jest otwarte wyświetl je i dodaj odpowiednie eventHandlery, a następnie dodaj ten widok do listy widoków
                    newMessage.Show();
                    newMessage.submitDelete += HandleSubmitDeleteMovie;
                    newMessage.cancelDelete += HandleCancelDeleteMovie;
                    newMessage.deleteFormClosing += HandleCloseDeleteForm;
                    deleteMessages.Add(newMessage);
                }
            }
            else
            {
                MakeAlert("Lista filmów jest pusta", CustomAlertBox.enmType.Info);
            }
            
        }


        // Metoda obsługująca event zamknięcia okna potwierdzenia usunięcia filmu
        private void HandleCloseDeleteForm(object? sender, EventArgs e)
        {
            // Usunięcie widoku z listy
            IDeleteMessage delete = (IDeleteMessage)sender;
            deleteMessages.Remove(delete);
        }


        // Metoda obsługujaca kliknięcie przycisku "Usuń" w widoku potwierdzenia usunięcia filmu
        private void HandleSubmitDeleteMovie(object? sender, EventArgs e)
        {
            // Pobranie id filmu
            string id="";
            if (e is DeleteEventArgs deleteEventArgs)
            {
                id = deleteEventArgs.Id;
            }
            try
            {
                reservationRepository.RemoveTicketForReservatedMovies(id);  // Usunięcie biletu w formacie JPG dla wszytskich rezerwacji na dany film
                reservationRepository.RemoveMovieWithReservation(id);   // Usunięcie filmu i wszytskich dotyczących do rezerwacji
                
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
            // Po poprawnym usunięciu filmu wyśweitl odpowiedni komunikat, zamknij okno potwierdzenia i odśwież listę filmów
            MakeAlert("Pomyślnie usunięto film z listy", CustomAlertBox.enmType.Success);
            CloseDeleteMessage(sender);
            RefreshMovieList();
            if(moviesList.Count == 0)
            {
                moviesList = null;
            }
        }


        // Metoda obsługująca zdarzenie anulowania potwierdzenia usunięcia filmu
        private void HandleCancelDeleteMovie(object? sender, EventArgs e)
        {
            CloseDeleteMessage(sender);
        }


        // Metoda zamykająca okno potwierdzenia usunięcia filmu
        private void CloseDeleteMessage(object? sender)
        {
            // Wyszukaj dany widok na liście otwartych okien
            IDeleteMessage temp = null;
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
                deleteMessages.RemoveAll(m => m == temp);   // Zamknij ten widok
            }
        }



        // Metoda obsługująca event kliknięcia w przycisk "Wyczyść filtry"
        private void ClearFilters(object? sender, EventArgs e)
        {
            _view.SearchValue.Text = string.Empty;
            RefreshMovieList(); 
        }


        // Metoda odświeżająca listę filmów
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


        // Metoda obsługująca event kliknięcia w przycisk "Szukaj"
        private void SearchMovie(object? sender, EventArgs e)
        {
            // Pobranie wartości wyszukiwania z widoku
            string search_value = (_view.SearchValue.Text != null) ? _view.SearchValue.Text : string.Empty;
            List<Movie> filtredList;
            if (moviesList != null)
            {
                try
                {
                    filtredList = movieRepository.FilterList(search_value); // Metoda zwracająca przefiltrowaną listę
                      
                    LoadMoviesList(filtredList);    // Dodanie przefiltrowanej listy do widoku
                        
                    movieBindingSource.ResetBindings(false);    // Odświeżenie listy dataGridView
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


        // Metoda obsługująca event kliknięcia w przycisk ASC - sortowanie
        private void SortASC(object? sender, EventArgs e)
        {
            // Pobranie z widoku atrybutu wybranego przez użytkownika z listy rozwijanej
            string atribute = (_view.SortCriteria.SelectedItem != null) ? _view.SortCriteria.SelectedItem.ToString() : string.Empty;
            List<Movie> sortedMovies;
            if (moviesList != null)
            {
                try
                {
                    sortedMovies = movieRepository.SortAscending(atribute); // Metoda pobierajca posortowaną liste względem danego atrybutu

                    LoadMoviesList(sortedMovies);   // Metoda ładująca posortowaną listę do dataGridView

                    movieBindingSource.ResetBindings(false);    // Odświeżenie listy dataGridView
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


        // Metoda obsługująca event kliknięcia w przycisk DSC - sortowanie
        private void SortDSC(object? sender, EventArgs e)
        {
            // Pobranie z widoku atrybutu wybranego przez użytkownika z listy rozwijanej
            string atribute = (_view.SortCriteria.SelectedItem != null) ? _view.SortCriteria.SelectedItem.ToString() : string.Empty;
            List<Movie> sortedMovies;
            if (moviesList != null)
            {             
                try
                {
                    sortedMovies = movieRepository.SortDescending(atribute);    // Metoda pobierajca posortowaną liste względem danego atrybutu

                    LoadMoviesList(sortedMovies);   // Metoda ładująca posortowaną listę do dataGridView

                    movieBindingSource.ResetBindings(false);    // Odświeżenie listy dataGridView
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


        // Metoda ładująca listę do dataGridView
        private void LoadMoviesList(List<Movie> movies)
        {
            if (movies != null)
            {
                // Przypisanie listy do bindingSource dataGridView
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
