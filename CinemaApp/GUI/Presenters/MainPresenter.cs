using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.Presenters.AdminPresenters;
using GUI.Presenters.UserPresenters;
using GUI.Views;
using System.Collections.Generic;

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
        private bool UserBackClick;
        private bool AdminBackClick;
        public MainPresenter(ISelectionView selectionView)
        {
            _selectionView = selectionView;
            GetMoviesAndReservations();
            CreateTickets();
            _selectionView.ShowMainUserView += ShowUserView;
            _selectionView.ShowAuthenticationView += ShowAdminAuthenticationView;
        }
        private void CreateTickets()
        {
            ITicketCreator ticketCreator = new TicketCreatorForm();
            TicketCreatorPresenter ticketPresenter = new TicketCreatorPresenter(reservationRepository, ticketCreator);
            ticketPresenter.PrepareTickets();
            ticketCreator.Close();
        }
        private void GetMoviesAndReservations()
        {
            movieRepository = new MovieRepository();
            try
            {
                movieRepository.ReadMoviesFromFile(); 
                reservationRepository = new ReservationRepository(movieRepository);
                reservationRepository.ReadReservationsFromFile();
            }
            catch (CannotReadFileException CRFE)
            {
                _selectionView.StartFailure(CRFE.Message);
            }
            catch (FileSyntaxException FSE)
            {
                _selectionView.StartFailure(FSE.Message);
            }
            catch (Exception ex)
            {
                _selectionView.StartFailure(ex.Message);
            }
        }

        private void ShowAdminAuthenticationView(object? sender, EventArgs e)
        {
            authenticationView = new AdminAuthenticationForm();
            authenticationView.SignIn += HandleSignInEvent;
            authenticationView.Show();
        }

        private void HandleSignInEvent(object? sender, EventArgs e)
        {
            // obsługa walidacji hasła
            string login = authenticationView.Login.Text;
            string passwd = authenticationView.Password.Text;

            bool isValidLoginAndPassword=false;
            try
            {
                isValidLoginAndPassword = Login.SignIn(login, passwd);
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
            
            if (isValidLoginAndPassword)
            {
                // zamknij formualrz i przejdz do widoku admina
                AdminBackClick = false;
                mainAdminForm = new MainAdminForm();
                mainAdminForm.goBackEvent += HandleAdminBackClick;
                mainAdminForm.closeEvent += HandleCloseAdminForm;
                new MainAdminPresenter(movieRepository, reservationRepository, mainAdminForm);
                mainAdminForm.Show();
                authenticationView.Close();
                _selectionView.Hide();
                MakeAlert("Pomyślnie zalogowano jako administrator", CustomAlertBox.enmType.Success);
            }
            else
            {
                MakeAlert("Błędny login lub hasło", CustomAlertBox.enmType.Error);
            }
        }

        private void HandleCloseAdminForm(object? sender, EventArgs e)
        {
            if (!AdminBackClick)
            {
                _selectionView.Close();
            }            
        }

        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox(true);
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }
        private void HandleAdminBackClick(object? sender, EventArgs e)
        {
            AdminBackClick = true;
            _selectionView.Show();
            _selectionView.BringToFront();
            mainAdminForm.Close();
            mainAdminForm = null;
        }

        private void ShowUserView(object? sender, EventArgs e)
        {
            UserBackClick = false;
           
            mainUserForm = new MainUserForm();
            mainUserForm.GoBack += HandleUserBackClick;
            mainUserForm.MainUserFormCloseEvent += HandleUserFormCloseEvent;
            new MainUserPresenter(mainUserForm, movieRepository, reservationRepository);
            mainUserForm.Show();
            _selectionView.Hide();
        }

        private void HandleUserFormCloseEvent(object? sender, EventArgs e)
        {
            if (!UserBackClick)
            {
                _selectionView.Close();
            }          
        }

        private void HandleUserBackClick(object? sender, EventArgs e)
        {
            UserBackClick = true;
            _selectionView.Show();
            _selectionView.BringToFront();
            mainUserForm.Close();
            mainUserForm = null;
        }
    }
}
