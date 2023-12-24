using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.Presenters.AdminPresenters;
using GUI.Presenters.UserPresenters;
using GUI.Views;

namespace GUI.Presenters
{
    public class MainPresenter
    {
        private ISelectionView _selectionView;
        private IReservationRepository reservationRepository;
        private IMovieRepository movieRepository;
        private IAuthenticationView authenticationView;

        private IMainUserForm mainUserForm;
        private IMainAdminForm mainAdminForm;
        private bool UserBackClick; // flaga - czy w profilu użytkownika kliknięto przycisk wróć
        private bool AdminBackClick; // flaga - czy w profilu admina kliknięto przycisk wróć
        public MainPresenter(ISelectionView selectionView)
        {
            _selectionView = selectionView;
            GetMoviesAndReservations(); // Pobranie filmów i rezerwacji z plików tekstowych
            CreateTickets();    // Utworzenie biletów na podstawie aktualnych rezerwacji

            // Obsługa eventów widoku ModeSelectonForm
            _selectionView.closeSelectionEvent += HandleCloseSelectionView;
            _selectionView.ShowMainUserView += ShowUserView;
            _selectionView.ShowAuthenticationView += ShowAdminAuthenticationView;
        }

        // Metoda tworząca bilety
        private void CreateTickets()
        {
            // Tworzy ona ukryty widok TicketCreatora oraz jego presentera 
            ITicketCreator ticketCreator = new TicketCreatorForm();
            TicketCreatorPresenter ticketPresenter = new TicketCreatorPresenter(reservationRepository, ticketCreator);
            ticketPresenter.PrepareTickets();
            ticketCreator.Close();
        }


        // Metoda wywołująca odczyt filmów i rezerwacji z plików tekstowych
        private void GetMoviesAndReservations()
        {
            // Wywołanie metod modelu i obsługa wyjątków
            movieRepository = new MovieRepository();
            try
            {
                movieRepository.ReadMoviesFromFile(); 
                reservationRepository = new ReservationRepository(movieRepository);
                reservationRepository.ReadReservationsFromFile();
            }
            catch (CannotReadFileException CRFE)
            {
                // Uniemożliwia to dalsze korzstanie z aplikacji - w głównym oknie wyświetla się odpowiedni komunikat
                _selectionView.StartFailure(CRFE.Message);
            }
            catch (FileSyntaxException FSE)
            {
                // Uniemożliwia to dalsze korzstanie z aplikacji - w głównym oknie wyświetla się odpowiedni komunikat
                _selectionView.StartFailure(FSE.Message);
            }
            catch (Exception ex)
            {
                // Uniemożliwia to dalsze korzstanie z aplikacji - w głównym oknie wyświetla się odpowiedni komunikat
                _selectionView.StartFailure(ex.Message);
            }
        }

        // Metoda tworząca alert danego typu (Success, Info, Error)
        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox(true);
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }


        // Obsługa eventu - kliknięcie w panel administratora
        private void ShowAdminAuthenticationView(object? sender, EventArgs e)
        {
            // Otworzenie widoku logowania
            authenticationView = new AdminAuthenticationForm();
            authenticationView.SignIn += HandleSignInEvent; // Obsługa eventu kliknięcia w przycisk Zaloguj się
            authenticationView.Show();
        }


        // Metoda obsługująca event kliknięcia w przycisk Zaloguj się
        private void HandleSignInEvent(object? sender, EventArgs e)
        {
            // Pobranie z widoku wartości loginu i hasła wprowadzonych przez użytkownika
            string login = authenticationView.Login.Text;
            string passwd = authenticationView.Password.Text;

            bool isValidLoginAndPassword=false; // Flaga informująca o poprawności logowania
            try
            {
                isValidLoginAndPassword = Login.SignIn(login, passwd);  // Metoda sprawdzająca hasze loginu i hasła z tymi zapisanymi w pliku
            }
            catch(CannotReadFileException CRFE)
            {
                MakeAlert(CRFE.Message, CustomAlertBox.enmType.Error);
                return;
            }
            catch(Exception ex)
            {
                MakeAlert("Wystąpił nieznany błąd: "+ex.Message, CustomAlertBox.enmType.Error);
                return;
            }
            
            // Jeśli logowanie się powiodło
            if (isValidLoginAndPassword)
            {
                // Utwórz widok panelu administratora
                AdminBackClick = false;
                mainAdminForm = new MainAdminForm();
                mainAdminForm.goBackEvent += HandleAdminBackClick;  // obsługa eventu kliknięcia w przycisk "wróć" w panelu admina
                mainAdminForm.closeEvent += HandleCloseAdminForm;   // obsługa eventu zamknięcia panelu admina
                new MainAdminPresenter(movieRepository, reservationRepository, mainAdminForm);
                mainAdminForm.Show();
                authenticationView.Close();
                _selectionView.Hide();  // Ukrycie widoku wyboru trybu działania - konieczne ponieważ jest on EntryPointem aplikacji
                MakeAlert("Pomyślnie zalogowano jako administrator", CustomAlertBox.enmType.Success);
            }
            else
            {
                MakeAlert("Błędny login lub hasło", CustomAlertBox.enmType.Error);
            }
        }


        // Metoda tworząca widok panelu uzytkownika 
        private void ShowUserView(object? sender, EventArgs e)
        {
            UserBackClick = false; // Ustawienie flagi informującej o kliknięciu przycisku wróć na false

            // Utworzenie widoku panelu użytkownika
            mainUserForm = new MainUserForm();
            mainUserForm.GoBack += HandleUserBackClick; // Dodanie obsługi wciśnięcia przycisku wróć
            mainUserForm.MainUserFormCloseEvent += HandleUserFormCloseEvent;    // Dodanie obsługi zamknięcia widoku użytkownika
            new MainUserPresenter(mainUserForm, movieRepository, reservationRepository);
            mainUserForm.Show();
            _selectionView.Hide();  // Ukrycie widoku wyboru trybu
        }


        // Metoda obsługująca zamknięcie widoku wyboru trybu
        // Event generuje się w momencie zamknięcia panelu administora użytkownika lub  bezpośrednio widoku wyboru trybu
        private void HandleCloseSelectionView(object? sender, EventArgs e)
        {
            // Zapis list filmów oraz rezerwacji do plików tekstowych
            movieRepository.SaveMoviesToFile();
            reservationRepository.SaveReservationsToFile();
        }


        // Metoda obslugująca zamknięcie okna panelu administrtora
        private void HandleCloseAdminForm(object? sender, EventArgs e)
        {
            // Jeśli zamknięcie okna nie było spowodowane przez przycisk "Wróć"
            if (!AdminBackClick)
            {
                // Zamknij także ukryty widok wyboru trybu
                _selectionView.Close();
            }            
        }


        // Metoda obsługująca kliknięcie przycisku wróc w panelu administratora
        private void HandleAdminBackClick(object? sender, EventArgs e)
        {
            AdminBackClick = true; // Ustawienie flagi informującej o kliknięciu przycisku wróć

            // Ponowne pokazanie widoku wyboru trybu
            _selectionView.Show();
            _selectionView.BringToFront();

            // Zamknięcie panelu administratora
            mainAdminForm.Close();
            mainAdminForm = null;
        }


        // Metoda obslugująca zamknięcie okna panelu użytkownika
        private void HandleUserFormCloseEvent(object? sender, EventArgs e)
        {
            // Jeśli zamknięcie okna nie było spowodowane przez przycisk "Wróć"
            if (!UserBackClick)
            {
                // Zamknij także ukryty widok wyboru trybu
                _selectionView.Close();
            }
        }


        // Metoda obsługująca kliknięcie przycisku wróc w panelu użytkownika
        private void HandleUserBackClick(object? sender, EventArgs e)
        {
            UserBackClick = true; // Ustawienie flagi informującej o kliknięciu przycisku wróć

            // Ponowne pokazanie widoku wyboru trybu
            _selectionView.Show();
            _selectionView.BringToFront();

            // Zamknięcie panelu administratora
            mainUserForm.Close();
            mainUserForm = null;
        }          
    }
}
