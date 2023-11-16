using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Interfaces.IViews;
using CinemaApp.Model;

namespace CinemaApp.Controllers.AdminControllers
{
    public class AdminReservationsController
    {
        private IAdminView adminView;
        private IReservationRepository reservationRepository;
        List<Reservation> res;
        public AdminReservationsController(IReservationRepository reservationRepository, IAdminView adminView)
        {
            this.reservationRepository = reservationRepository;
            this.adminView = adminView;
            res = new List<Reservation>();
        }

        // Metoda pobierająca i wyświetlająca listę rezerwacji
        public void GetReservationList()
        {
            try
            {
                res = reservationRepository.GetReservationsList();
                adminView.SetHowManyResWereDisplayed();
                adminView.ShowReservationList(res, 0);
            }
            catch (ReservationListIsEmptyException RLIEE)
            {
                adminView.ShowSuccessOrException("[!] " + RLIEE.Message);
                return;
            }
            catch (Exception ex)
            {
                adminView.PrintUnknownErrorInfo(ex.Message);
                Environment.Exit(1);
            }
        }

        // Metoda przewijająca listę rezerwacji do dołu
        public void ScrollDown()
        {
            adminView.ScrollDown(res);
        }


        // Metoda przewijająca listę rezerwacji do góry
        public void ScrollUp()
        {
            adminView.ScrollUp(res);
        }
    }
}