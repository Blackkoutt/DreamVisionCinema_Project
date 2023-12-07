using CinemaApp.Interfaces;
using CinemaApp.Model;
using GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Presenters.AdminPresenters
{
    public class AdminReservationPresenter
    {
        private IAdminReservationsView _view;

        private IReservationRepository _reservationRepository;

        private BindingSource reservationBindingSource;
        private List<Reservation> reservationsList;

        public AdminReservationPresenter(IReservationRepository reservationRepository, IAdminReservationsView view)
        {
            _reservationRepository = reservationRepository;

            this._view = view;

            this.reservationBindingSource = new BindingSource();
            this._view.SetReservationListBindingSource(reservationBindingSource);

            LoadReservationList();
            _view.BringToFront();
            _view.Show();
        }

        private void LoadReservationList()
        {
            // Throws exceptions
            //_reservationRepository.ReadReservationsFromFile();
            reservationsList = _reservationRepository.GetReservationsList();
            //reservationBindingSource.DataSource = reservationsList;
            reservationBindingSource.DataSource = reservationsList.Select
                (r => new {
                    ID = r.Id,
                    Tytuł = r.Movie.Title,
                    Data = r.Movie.Date.ToString("dd/MM/yyyy HH:mm"),
                    Sala = r.Movie.Room.Number.ToString(),
                    Cena = r.Ticket.CalculatePrice(r.Movie.Price, r.Seats.Count).ToString(),
                    Miejsca = string.Join(" ", r.Seats)
                });
            // _reservationlistView.SetReservationListBindingSource(res);
        }
    }
}
