using GUI.Interfaces;
using GUI.Presenters;
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



        // Admin
        /*IMainAdminForm mainAdminForm = new MainAdminForm();
        new MainAdminPresenter(movieRepository, reservationRepository, mainAdminForm);
        Application.Run((Form)mainAdminForm);*/


        /*Form adminForm = new MainAdminForm();
        Application.Run(adminForm);*/
        LoadingForm form = new LoadingForm();
        //form.Show();
        form.ShowDialog();
        //form.Close();

        // User
        ISelectionView selectionView = new ModeSelectionForm();       
        new MainPresenter(selectionView);
        Application.Run((Form)selectionView);


        /*IMainUserForm mainUserForm = new MainUserForm();
        new MainUserPresenter(mainUserForm, movieRepository, reservationRepository);
        Application.Run((Form)mainUserForm);*/
    }
}