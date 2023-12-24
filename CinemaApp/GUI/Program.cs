using GUI.Interfaces;
using GUI.Presenters;
using GUI.Views;

namespace GUI;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        LoadingForm form = new LoadingForm();
        form.ShowDialog();

        ISelectionView selectionView = new ModeSelectionForm();       
        new MainPresenter(selectionView);
        Application.Run((Form)selectionView);
    }
}