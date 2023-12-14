using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.Presenters.AdminPresenters;
using GUI.Presenters.UserPresenters;
using GUI.UserForms;
using GUI.Views;

namespace GUI;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        IMovieRepository movieRepository = new MovieRepository();
        movieRepository.ReadMoviesFromFile(); // throws exceptions
        IReservationRepository reservationRepository = new ReservationRepository(movieRepository);
        reservationRepository.ReadReservationsFromFile();

        // Admin
        IMainAdminForm mainAdminForm = new MainAdminForm();
        new MainAdminPresenter(movieRepository, reservationRepository, mainAdminForm);
        Application.Run((Form)mainAdminForm);


        /*Form adminForm = new MainAdminForm();
        Application.Run(adminForm);*/

        // User

        /*IMainUserForm mainUserForm = new MainUserForm();
        new MainUserPresenter(mainUserForm, movieRepository, reservationRepository);
        Application.Run((Form)mainUserForm*/
    }
}