using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.Presenters.AdminPresenters;
using GUI.Presenters.UserPresenters;
using GUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

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
        public MainPresenter(ISelectionView selectionView)
        {
            _selectionView = selectionView;
            GetMoviesAndReservations();
            _selectionView.ShowMainUserView += ShowUserView;
            _selectionView.ShowAuthenticationView += ShowAdminAuthenticationView;
        }
        private void GetMoviesAndReservations()
        {
            movieRepository = new MovieRepository();
            movieRepository.ReadMoviesFromFile(); // throws exceptions
            reservationRepository = new ReservationRepository(movieRepository);
            reservationRepository.ReadReservationsFromFile();
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

            //throws exceptions
            bool isValidLoginAndPassword = Login.SignIn(login, passwd);
            if (isValidLoginAndPassword)
            {
                // zamknij formualrz i przejdz do widoku admina
                mainAdminForm = new MainAdminForm();
                mainAdminForm.goBackEvent += HandleAdminBackClick;
                new MainAdminPresenter(movieRepository, reservationRepository, mainAdminForm);
                mainAdminForm.Show();
                authenticationView.Hide();
                _selectionView.Hide();
            }
            else
            {
                MakeAlert("Błędny login lub hasło", CustomAlertBox.enmType.Error);
            }
        }
        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox();
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }
        private void HandleAdminBackClick(object? sender, EventArgs e)
        {
            _selectionView.Show();
            _selectionView.BringToFront();
            mainAdminForm.Close();
            mainAdminForm = null;
        }

        private void ShowUserView(object? sender, EventArgs e)
        {
           
            mainUserForm = new MainUserForm();
            mainUserForm.GoBack += HandleUserBackClick;
            new MainUserPresenter(mainUserForm, movieRepository, reservationRepository);
            mainUserForm.Show();
            _selectionView.Hide();

            //Application.Run((Form)mainUserForm);
        }

        private void HandleUserBackClick(object? sender, EventArgs e)
        {
            _selectionView.Show();
            _selectionView.BringToFront();
            mainUserForm.Close();
            mainUserForm = null;
        }
    }
}
