using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IRepositories;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.Presenters.UserPresenters;
using GUI.UserForms;

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

        /*IMovieRepository movieRepository = new MovieRepository();
        movieRepository.ReadMoviesFromFile(); // throws exceptions
        IReservationRepository reservationRepository = new ReservationRepository(movieRepository);
        IReservationListView reservationListView = new ReservationListView();

        UserReservationPresenter URP = new UserReservationPresenter(reservationListView, reservationRepository);
        Application.Run((Form)reservationListView);
        //Application.Run(new MainUserForm());*/

        IMainUserForm mainUserForm = new MainUserForm();
        new MainUserPresenter(mainUserForm);
        Application.Run((Form)mainUserForm);
    }    
}