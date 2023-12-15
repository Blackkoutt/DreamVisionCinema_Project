using CinemaApp.Interfaces;
using GUI.Interfaces;
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

        private IReservationRepository reservationRepository;

        public AdminStatisticPresenter(IReservationRepository reservationRepository, IAdminStatisticsView view)
        {
            this.reservationRepository = reservationRepository;
            this._view = view;

            _view.Show();
        }
    }
}
