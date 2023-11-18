using CinemaApp.Interfaces;
using CinemaApp.Model;
using GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Presenters.UserPresenters
{
    
    public class UserReservationPresenter
    {
        private IReservationListView _reservationlistView;
        private IReservationRepository _reservationRepository;
        private BindingSource reservationBindingSource;
        private List<Reservation> reservationsList;
        public UserReservationPresenter(IReservationListView reservationlistView, IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
            _reservationlistView  = reservationlistView;

            this.reservationBindingSource = new BindingSource();
            this._reservationlistView.SetReservationListBindingSource(reservationBindingSource);
            // Load data
            LoadReservationList();
            _reservationlistView.BringToFront();
            _reservationlistView.Show();
        }

        private void LoadReservationList()
        {
            
            // Throws exceptions
           _reservationRepository.ReadReservationsFromFile();
           reservationsList = _reservationRepository.GetReservationsList();
            //reservationBindingSource.DataSource = reservationsList;
            reservationBindingSource.DataSource = reservationsList.Select
                (r => new { 
                    ID = r.Id,
                    Tytuł = r.Movie.Title,
                    Data = r.Movie.Date.ToString("dd/MM/yyyy HH:mm"),
                    Sala = r.Movie.Room.Number.ToString(),
                    Cena = r.Ticket.CalculatePrice(r.Movie.Price, r.Seats.Count).ToString(),
                    Miejsca = string.Join(" ", r.Seats)});
            // _reservationlistView.SetReservationListBindingSource(res);
        }
    }
}
