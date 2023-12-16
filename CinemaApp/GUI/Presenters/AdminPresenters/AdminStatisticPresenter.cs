using CinemaApp.Enums;
using CinemaApp.Interfaces;
using GUI.Interfaces;
using GUI.Views.AdminViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Presenters.AdminPresenters
{
    public class AdminStatisticPresenter
    {
        private IAdminStatisticsView _view;
        private IPopluarMovies _popularMoviesView;
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

        private void HandleProfitableClickEvent(object? sender, EventArgs e)
        {
            
        }

        private void HandlePopularClickEvent(object? sender, EventArgs e)
        {
            Dictionary<string, int> data = reservationRepository.GetMostPopularMovies();
            data = data.Take(10).ToDictionary(pair => pair.Key, pair => pair.Value);
            data = new Dictionary<string, int> { { "", 0 } }.Concat(data).ToDictionary(pair => pair.Key, pair => pair.Value);

            _popularMoviesView = new MostPopularMoviesView(data);

            _mainAdminForm.PanelContainer.Controls.Clear();
            _mainAdminForm.PanelContainer.Controls.Add((Form)_popularMoviesView);
            //_mainAdminForm.PanelContainer.Tag = (Form)adminStatisticsView;

            _popularMoviesView.Show();
            _popularMoviesView.BringToFront();
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
