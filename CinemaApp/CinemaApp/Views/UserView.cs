using CinemaApp.Enums;
using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Views
{
    public class UserView : MainView
    {
        private readonly string[] userMenuOptions;
        private readonly string[] userMoviesOptions;
        private readonly string[] infos;
        private readonly string[] userReservationsOptions;

        private readonly string[] inputDataForRemoveAndMakeReservation_ID;
        private readonly string[] infoForRemoveReservation;

        private readonly string[] infoForMakeReservation_Id;
        private readonly string[] infoForMakeReservation_Seats;
        private readonly string[] inputDataForMakeReservation_Seats;


        public UserView()
        {
            userReservationsOptions = new string[]{
                "Przewiń listę do dołu v",
                "Przewiń listę do góry ^",
                "Anuluj rezerwację",
                "Wróć"
            };
            userMenuOptions = new string[]
            {
                "Przeglądaj filmy / Dokonaj rezerwacji",
                "Przeglądaj dokonane rezerwacje",
                "Wróć"
            };
            infos = new string[] {
                "[?] Poruszaj się za pomocą strzałek. Aby wybrać opcję wciśnij ENTER.",
                "[!] Wcisnij dowolny przycisk aby odświeżyć konsolę."
            };
            userMoviesOptions = new string[]
            {
                "Przewiń listę do dołu v",
                "Przewiń listę do góry ^",
                "Dokonaj rezerwacji",
                "Wyszukaj",
                "Sortuj rosnąco",
                "Sortuj malejąco",
                "Usuń filtry",
                "Wróć"
            };
            inputDataForRemoveAndMakeReservation_ID = new string[]
            {
                "ID: "
            };
            inputDataForMakeReservation_Seats = new string[]
            {
                "Miejsca: "
            };
            infoForRemoveReservation = new string[]
            {
                "[?] Podaj ID rezerwacji, którą chcesz usunąc. Zatwierdź klawiszem ENTER.",
                "[?] ID rezerwacji powinno być liczbą całkowitą"
            };

            infoForMakeReservation_Id = new string[]
            {
                "[?] Podaj ID filmu, na który chcesz dokonać rezerwacji. Zatwierdź klawiszem ENTER.",
                "[?] ID filmu powinno być liczbą całkowitą"
            };
            infoForMakeReservation_Seats = new string[]
            {
                "[?] Podaj numery miejsc które chcesz zarezerwować. Zatwierdź klawiszem ENTER.",
                "[?] Numery miejsc powinny być liczbami całkowitymi odzielonymi spacją np: 1 2 3 21",
                "[?] Kolorem czerwonym oznaczono zajęte miejsca, a kolorem zielonym wolne miejsca",
            };
        }

        
        public int RenderMoviesUserView(List<Movie> movies)
        {
            return RenderMoviesView(infos, movies, userMoviesOptions);
        }
        public string RemoveReservation()
        {
            return EnterDataForFilterSortAndRemove(infoForRemoveReservation, inputDataForRemoveAndMakeReservation_ID);
        }

        public string GetFilmId()
        {
            return EnterDataForFilterSortAndRemove(infoForMakeReservation_Id, inputDataForRemoveAndMakeReservation_ID);
        }
        public string MakeReservation(Movie movie)
        {
            Console.ResetColor();
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            ClearViewInputPart(WindowWidth, WindowHeight);
            ClearViewOutputDataPart(WindowWidth, WindowHeight);

            // Tutaj teraz rysowanie w output miejsc zajetych i nie zajętych
            Seat[] seats = movie.Room.Seats;

            int row=2;
            int current_position = 1;
            int length = 0;
            for(int i=0;i<seats.Length;i++)
            {
                //SetCursorInDataOutputPart(WindowWidth, WindowHeight, current_position, row);
                if (i!=0 && i % 17 == 0)
                {
                    row+=4;
                    current_position = 1;
                }
                if (seats[i].IsAvailable)
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, current_position, row + 1);

                if (i < 9)
                {
                    length = 2;
                    Console.Write("│" + seats[i] + " │");
                }
                else
                {
                    length = seats[i].ToString().Length;
                    Console.Write("│" + seats[i] + "│");
                }

                SetCursorInDataOutputPart(WindowWidth, WindowHeight, current_position, row);
                Console.Write($"┌{new string('─', length)}┐");

                SetCursorInDataOutputPart(WindowWidth, WindowHeight, current_position, row + 2);
                Console.Write($"└{new string('─', length)}┘");
                current_position += length + 3;
            }

            // Potem wywołanie EnterDataForilterAndRemove zeby pobrac numery siedzeń
            // Zwrócenie numerów siedzeń 
            Console.ResetColor();
            return EnterDataForFilterSortAndRemove(infoForMakeReservation_Seats, inputDataForMakeReservation_Seats);
        }

        public int RenderReservationsUserView(List<Reservation> res)
        {
            return RenderReservationsView(infos, res, userReservationsOptions);
        }
        public int RenderMainUserView()
        {
            return RenderMainAdminUserView(infos, userMenuOptions);        
        }
        public void SetInfoAboutDeletedReservations(List<string> deleted_reservations)
        {

            
            for(int i = 0; i < deleted_reservations.Count; i++)
            {
                if (i + 1 == deleted_reservations.Count)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                SetCursorInDataOutputPart(Console.WindowWidth, Console.WindowHeight, 2, 2*i+2);
                Console.Write("[!] " +deleted_reservations[i]);
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                SetCursorInDataOutputPart(Console.WindowWidth, Console.WindowHeight, 2, 2*i+3);
                Console.Write("[V] " + deleted_reservations[i+1]);
                Console.ResetColor();
            }
            //Console.ResetColor();
            Thread displayThread = new Thread(() =>
            {
                Thread.Sleep(6000);

                ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);
            });

            displayThread.Start();
        }
    }
}
