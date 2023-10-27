using CinemaApp.Enums;
using CinemaApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Model
{
    public class Room
    {
        private int number;
        private Seat[] seats;
        private int AvailableSeats;

        public Room(int number, int NumberOfSeats) {
            this.number = number;
            seats = new Seat[NumberOfSeats];
            InitSeats();
        }
        public int Number {
            get {  return number; }
            set { this.number = value; }
        }
        public Seat[] Seats
        {
            get { return seats; }
        }
        public void CheckSeatsAvailable(List<int> SeatsNumbers)
        {
            List<int> UnavailableSeats=new List<int>();
            foreach (int seat_nr in SeatsNumbers)
            {
                if(seat_nr<1 || seat_nr > (int)Rooms.NUMBER_OF_SEATS)
                {
                    throw new NoSeatWithGivenNumberException("Brak miejsca o podanym numerze.");
                }
                if(!GetSeat(seat_nr).IsAvailable)
                {
                    UnavailableSeats.Add(seat_nr);
                }
            }
            if (UnavailableSeats.Count > 0)
            {
                string unavailableSeatsMessage = string.Join(", ", UnavailableSeats);
                throw new SeatIsNotAvailableException($"Wybrane miejsca: {unavailableSeatsMessage} są niedostępne");
            }
        }
        
        private Seat GetSeat(int seat_nr) {
            return seats[seat_nr-1];    // Nie wyrzuci wyjątku bo jest sprawdzana poprawność indexu w CheckSeatsAvailable
        }
        
        public List<Seat> MarkSeatsAsReservatedAndGet(List<int> SeatsNumbers)
        {
            List<Seat> Seats = new List<Seat>();
            // Tutaj już mamy pewność że wybrane siedzenia istnieją i nie są zarezerwowane
            foreach (int seat_nr in SeatsNumbers)
            {
                Seat seat = GetSeat(seat_nr);
                seat.IsAvailable = false;
                Seats.Add(seat);
            }
            return Seats;
        }
        public void MarkSeatsAsAvailable(List <int> SeatsNumbers)
        {
            foreach (int seat_nr in SeatsNumbers)
            {
                Seat seat = GetSeat(seat_nr);
                seat.IsAvailable = true;
            }
        }
        private void InitSeats()
        {
            for(int i = 0; i < seats.Length; i++)
            {
                //Tu powinno być sprawdzenie w pliku czy miejsce jest dostępne
                seats[i] = new Seat(i+1, (i+1/10));
            }
        }
        public int CheckAvailableSeatsCount()
        {
            return AvailableSeats;
        }
        // Wyznaczenie ilości dostępnych miejsc w danym pomieszczeniu

        //
    }
}
