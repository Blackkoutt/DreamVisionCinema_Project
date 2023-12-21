using CinemaApp.Enums;
using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using GUI.Interfaces;
using GUI.Views;
using GUI.Views.AdminViews;

namespace GUI.Presenters.AdminPresenters
{
    public class AdminStatisticPresenter
    {
        private IAdminStatisticsView _view;
        private IPopluarMovies _popularMoviesView;
        private IProfitableMovies _profitableMoviesView;
        private IMainAdminForm _mainAdminForm;

        private IReservationRepository reservationRepository;

        public AdminStatisticPresenter(IReservationRepository reservationRepository, IAdminStatisticsView view, IMainAdminForm mainAdminForm)
        {
            this.reservationRepository = reservationRepository;
            this._view = view;
            this._mainAdminForm = mainAdminForm;

            _view.mostPopularClickEvent += HandlePopularClickEvent;
            _view.mostProfitableClickEvent += HandleProfitableClickEvent;

            PrepareStatisticView();

            _view.Show();
            _mainAdminForm = mainAdminForm;
        }
        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox(true);
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }

        private void HandleProfitableClickEvent(object? sender, EventArgs e)
        {
            Dictionary<string, double> data;
            try
            {
                data = reservationRepository.GetMoviesIncome();
            }
            catch(ListIsEmptyException LIEE)
            {
                MakeAlert("Lista rezerwacji jest pusta!", CustomAlertBox.enmType.Error);
                return;
            }
            catch(Exception ex)
            {
                MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                return;
            }
             
            data = data.Take(10).ToDictionary(pair => pair.Key, pair => pair.Value);
            data = new Dictionary<string, double> { { "", 0 } }.Concat(data).ToDictionary(pair => pair.Key, pair => pair.Value);

            _profitableMoviesView = new MostProfitableMoviesView(data);
            _mainAdminForm.PanelContainer.Controls.Clear();
            _mainAdminForm.PanelContainer.Controls.Add((Form)_profitableMoviesView);

            _profitableMoviesView.Show();
            _profitableMoviesView.BringToFront();
            _profitableMoviesView.BackFromProfitableMovies += HandleBackFromProfitableMovies;
        }

        private void HandleBackFromProfitableMovies(object? sender, EventArgs e)
        {
            _profitableMoviesView.Close();
            _mainAdminForm.PanelContainer.Controls.Clear();
            _profitableMoviesView = null;
            PrepareStatisticView();
            _mainAdminForm.PanelContainer.Controls.Add((Form)_view);
            _view.Show();
        }

        private void HandlePopularClickEvent(object? sender, EventArgs e)
        {
            Dictionary<string, int> data;
            try
            {
                data = reservationRepository.GetMostPopularMovies();
            }
            catch (ListIsEmptyException LIEE)
            {
                MakeAlert("Lista rezerwacji jest pusta!", CustomAlertBox.enmType.Error);
                return;
            }
            catch (Exception ex)
            {
                MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                return;
            }

            data = data.Take(10).ToDictionary(pair => pair.Key, pair => pair.Value);
            data = new Dictionary<string, int> { { "", 0 } }.Concat(data).ToDictionary(pair => pair.Key, pair => pair.Value);

            _popularMoviesView = new MostPopularMoviesView(data);

            _mainAdminForm.PanelContainer.Controls.Clear();
            _mainAdminForm.PanelContainer.Controls.Add((Form)_popularMoviesView);
            //_mainAdminForm.PanelContainer.Tag = (Form)adminStatisticsView;

            _popularMoviesView.Show();
            _popularMoviesView.BringToFront();
            _popularMoviesView.BackFromPupularMovies += HandleBackFromPopularMovies;
        }

        private void HandleBackFromPopularMovies(object? sender, EventArgs e)
        {
            _popularMoviesView.Close();
            _mainAdminForm.PanelContainer.Controls.Clear();
            _popularMoviesView = null;
            PrepareStatisticView();
            _mainAdminForm.PanelContainer.Controls.Add((Form)_view);
            _view.Show();
           // _view.BringToFront();
        }

        public void PrepareStatisticView()
        {
            double income = reservationRepository.GetTotalIncome(); // nie wyrzuca wyjątku
            _view.Earings.Text = $"{income} $";
            _view.Guideline.Text= $"{income}/{(int)Guideline.ESTIMATED_EARNINGS} $";
            int value = (int)((income / (int)Guideline.ESTIMATED_EARNINGS) * 100);
            _view.Progress.Text = $"{value} %";
            if (value > 100)
            {
                _view.Progress.Value = 100;
            }
            else
            {
                _view.Progress.Value = value;
            }
            
        }
    }
}
