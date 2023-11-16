using CinemaApp.Enums;
using CinemaApp.Interfaces.IViews;
using CinemaApp.Model;

namespace CinemaApp.Views
{
    public class UserView : MainView, IUserView
    {
        private readonly string[] userMenuOptions;
        private readonly string[] userMoviesOptions;
        private readonly string[] userReservationsOptions;

        private readonly string[] inputDataForRemoveAndMakeReservation_ID;
        private readonly string[] infoForRemoveReservation;

        private readonly string[] infoForMakeReservation_Id;
        private readonly string[] infoForMakeReservation_Seats;
        private readonly string[] inputDataForMakeReservation_Seats;

        private readonly string[] PrinterAnimaton1 =
        {
               "       ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓       ",
               "████████████████████████████████",
               "██                            ██",
               "██   ██ ██                    ██",
               "██                            ██",
               "████████████████████████████████"
        };
        private readonly string[] PrinterAnimaton2 =
        {
               "       ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓       ",
               "       ▓▓  ══════════  ▓▓       ",
               "████████████████████████████████",
               "██                            ██",
               "██   ██ ██                    ██",
               "██                            ██",
               "████████████████████████████████"
        };
        private readonly string[] PrinterAnimaton3 =
        {
               "       ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓       ",
               "       ▓▓  ══════════  ▓▓       ",
               "       ▓▓  ══════════  ▓▓       ",
               "████████████████████████████████",
               "██                            ██",
               "██   ██ ██                    ██",
               "██                            ██",
               "████████████████████████████████"
        };
        private readonly string[] PrinterAnimaton4 =
        {
               "       ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓       ",
               "       ▓▓  ══════════  ▓▓       ",
               "       ▓▓  ══════════  ▓▓       ",
               "       ▓▓  ══════════  ▓▓       ",
               "████████████████████████████████",
               "██                            ██",
               "██   ██ ██                    ██",
               "██                            ██",
               "████████████████████████████████"
        };


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
                "[?] Aby wyjść z wprowadzania danych wciśnij ESC.",
                "[?] ID rezerwacji powinno być liczbą całkowitą"
            };

            infoForMakeReservation_Id = new string[]
            {
                "[?] Podaj ID filmu, na który chcesz dokonać rezerwacji. Zatwierdź klawiszem ENTER.",
                "[?] Aby wyjść z wprowadzania danych wciśnij ESC.",
                "[?] ID filmu powinno być liczbą całkowitą"
            };
            infoForMakeReservation_Seats = new string[]
            {
                "[?] Podaj numery miejsc które chcesz zarezerwować. Zatwierdź klawiszem ENTER.",
                "[?] Aby wyjść z wprowadzania danych wciśnij ESC.",
                "[?] Numery miejsc powinny być liczbami całkowitymi odzielonymi spacją np: 1 2 3 21",
                "[?] Kolorem czerwonym oznaczono zajęte miejsca, a kolorem zielonym wolne miejsca",
            };
        }



        // Metoda służąca do wyświetlenia animacji ASCII drukarki
        public void PrinterAnimation()
        {
            string[] info =
            {
                "Trwa drukowanie biletu",
                "Trwa drukowanie biletu.",
                "Trwa drukowanie biletu..",
                "Trwa drukowanie biletu...",
            };
            for(int j=0;j<3;j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
                    switch (i)
                    {
                        case 0:
                            {
                                DrawPrinter(PrinterAnimaton1, info[0]);
                                
                                break;
                            }
                        case 1:
                            {
                                DrawPrinter(PrinterAnimaton2, info[1]);
                                break;
                            }
                        case 2:
                            {
                                DrawPrinter(PrinterAnimaton3, info[2]);
                                break;
                            }
                        case 3:
                            {
                                DrawPrinter(PrinterAnimaton4, info[3]);
                                break;
                            }
                    }
                    Thread.Sleep(300);

                }
            }      
        }


        // Metoda służąca do wyświetlenia klatek animacji drukraki
        private void DrawPrinter(string[] art, string info)
        {
            int max_Length = PrinterAnimaton4.Length;
            for (int i = art.Length-1; i >= 0; i--)
            {
                SetCursorInInfoPart(Console.WindowWidth, Console.WindowHeight, 2, i+(max_Length-art.Length-1));
                Console.Write(art[i]);
            }
            SetCursorInInfoPart(Console.WindowWidth, Console.WindowHeight, 4 + art[art.Length - 1].Length, max_Length - 2);
            Console.Write(info);
        }


        // Metoda służąca do wyświetlenia sformatowanego biletu w oknie konsoli
        public void ShowTicket(string ticket, string ticket_file_name)
        {
            Console.Clear();
            Console.WriteLine(ticket);
            Console.WriteLine();
            Console.WriteLine($"Bilet został zapisany w pliku {ticket_file_name} w katalogu CinemaApp/bin/Debug/net7.0");
            Console.WriteLine("Wciśnij dowolny przycisk aby kontynuować...");
            
        }


        // Metoda służąca do wyrenderowania widoku filmów
        public int RenderMoviesUserView(List<Movie> movies)
        {
            return RenderMoviesView(infos, movies, userMoviesOptions);
        }


        // Metoda służąca do usunięcia rezerwacji (pobrania id od użytkownika)
        public string RemoveReservation()
        {
            return EnterDataForFilterSortAndRemove(infoForRemoveReservation, inputDataForRemoveAndMakeReservation_ID);
        }


        // Metoda służąca do pobrania id filmu od użytkownika
        public string GetFilmId()
        {
            return EnterDataForFilterSortAndRemove(infoForMakeReservation_Id, inputDataForRemoveAndMakeReservation_ID);
        }


        // Metoda służąca do dokonania rezerwacji (wizualizacja sali kinowej i pobranie numerów miejsc od użytkownika)
        public string MakeReservation(Movie movie)
        {
            Console.ResetColor();
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            ClearViewInputPart(WindowWidth, WindowHeight);
            ClearViewOutputDataPart(WindowWidth, WindowHeight);

            Seat[] seats = movie.Room.Seats;

            int SeatsInOneRow = 15;

            int row_offset = (GetOutputPartHeight() - (((int)Rooms.NUMBER_OF_SEATS / SeatsInOneRow) * 3 + 1))/2;

            int offset  = (GetOutputPartWidth() - (SeatsInOneRow*4 + SeatsInOneRow-1))/2;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row_offset);
            Console.Write(new string('▓', SeatsInOneRow * 4 + SeatsInOneRow - 1));
            Console.ResetColor();

            int row = row_offset + 2;
            int current_position = offset;
            int length = 0;
            for(int i=0;i<seats.Length;i++)
            {
                if (i!=0 && i % SeatsInOneRow == 0)
                {
                    row+=3;
                    if(seats.Length - i < SeatsInOneRow)
                    {
                        current_position = offset + (((SeatsInOneRow - (seats.Length - i)) / 2) * 4)+3;
                    }
                    else
                    {
                        current_position = offset;
                    }
                    
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

            Console.ResetColor();
            return EnterDataForFilterSortAndRemove(infoForMakeReservation_Seats, inputDataForMakeReservation_Seats);
        }



        // Metoda renderująca widok rezerwacji
        public int RenderReservationsUserView(List<Reservation> res)
        {
            return RenderReservationsView(infos, res, userReservationsOptions);
        }


        // Metoda renderująca główny widok użytkownika
        public int RenderMainUserView()
        {
            return RenderMainAdminUserView(infos, userMenuOptions);        
        }


        // Metoda pokazująca informacje o odwołanych rezerwacjach lub zmodyfikowanych dacie, godzinie lub sali filmu na który była rezerwacja
        public void SetInfoAboutDeletedOrModificatedReservations(List<string> deleted_modificated_reservations)
        {
            ClearViewOutputDataPart(Console.WindowWidth, Console.WindowHeight);

            int row = 0;
            for(int i = 0; i < deleted_modificated_reservations.Count; i++)
            {
                if(i!=0 && deleted_modificated_reservations[i - 1][1] == 'V')
                {
                    row++;
                }
                if (deleted_modificated_reservations[i][1] == '!')
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if(deleted_modificated_reservations[i][1] == 'V')
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                SetCursorInDataOutputPart(Console.WindowWidth, Console.WindowHeight, 2, row+i+2 );
                Console.Write(deleted_modificated_reservations[i]);
                
            }
            Console.ResetColor();

            Thread displayThread = new Thread(() =>
            {
                Thread.Sleep(6000);
            });

            displayThread.Start();
            displayThread.Join();
        }
    }
}