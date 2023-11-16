using CinemaApp.Exceptions;
using CinemaApp.Model;
using System.Text;

namespace CinemaApp.Views
{
    public abstract class MainView
    {
        private static readonly int INFO_OFFSET = 1; 
        private static readonly int vertical_line_part = 3; // 1/3 szerokości widoku
        private static readonly int horizontal_line_part = 3; // 1/3 wysokości widoku

        private readonly string[] keyboradArt =
        {
            "                  ▄▄▄               ",
            "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄██▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄",
            "█                                  █",
            "█    ██  ██  ██  ██  ██  ██  ██    █",
            "█                                  █",
            "█  ██  ██  ██  ██  ██  ██  ██  ██  █",
            "█                                  █",
            "█   ██    ████████████████    ██   █",
            "█                                  █",
            "▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
        };

        private int howManyReservationsWereDisplayed = 0;
        private int howManyMoviesWereDisplayed = 0;
        private int FirstDisplayedMovie = 0;
        private int FirstDisplayedReservation = 0;
        private bool scrollDownReservations;
        private bool scrollDownMovies;

        protected string[] infos = new string[] {
                "[?] Poruszaj się za pomocą strzałek. Aby wybrać opcję wystarczy wcisnąć ENTER.",
                "[!] Po zmianie rozmiaru okna należy wcisnąć dowolny przycisk aby odświeżyć konsolę."
        };

        private readonly string[] infoForFilterList = new string[]
        {
            "[?] Wprowadź frazę i wyszukaj wszytskie filmy do niej pasujące."
        };
        private readonly string[] inputDataForFilterList = new string[]
        {
            "Wyszukaj: "
        };
        private readonly string[] infoForSortList =  new string[]
        {
            "[?] Wprowadź atrybut według którego chcesz sortować listę.",
            "[?] Atrybuty: id, tytuł, data, cena, czas, sala.",
            "[?] Wielkość liter nie ma znaczenia.",
            "[?] Polskie znaki nie mają znaczenia.",
        };
        private readonly string[] inputDataForSortList = new string[]
        {
            "Atrybut: "
        };


        // Metoda ustawiająca domyślne informację w sekcji INFO/ERRORS
        public void SetDefaultInfo()
        {
            SetInfo(infos, Console.WindowWidth, Console.WindowHeight);
        }


        // Metoda wyświetlająca ASCII art w sekcji INPUT
        public void PrintInputArt()
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            // Czyszczenie sekcji INPUT
            ClearViewInputPart(WindowWidth, WindowHeight);  
            
            // Przesunięcia w pionie i poziomie, aby wyśrodkować
            int offest_row = (GetInputPartHeight() - keyboradArt.Length) / 2;
            int offset = (GetInputPartWidth() - (keyboradArt[0].Length)) / 2;

            for (int i = 0; i < keyboradArt.Length; i++)
            {
                // Ustawienie kursora w sekcji INPUT z odpowiednimi przesunięciami
                SetCursorInInputPart(WindowWidth, WindowHeight, offset, i + offest_row+1);
                Console.WriteLine(keyboradArt[i]);
            }
        }


        // Metoda czyszcząca sekcje OPTIONS
        public void ClearViewOptionsPart(int WindowWidth, int WindowHeight)
        {
            int vertical_line_x = WindowWidth / vertical_line_part; ;  // Pozycja lini pionowej
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);   // Pozycja linii poziomej
            for (int j = 2; j < horizontal_line_y; j++)      
            {
                for (int i = 1; i < vertical_line_x; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
        }


        // Metoda czyszcząca sekcje INPUT
        public void ClearViewInputPart(int WindowWidth, int WindowHeight)
        {
            int vertical_line_x = WindowWidth / vertical_line_part; ;  // Pozycja lini pionowej
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);      // Pozycja linii poziomej
            for (int j = horizontal_line_y + 2; j < WindowHeight - 1; j++)
            {
                for (int i = 1; i < vertical_line_x; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(' ');
                }
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("║");
                Console.ResetColor();
            }
        }


        // Metoda czyszcząca sekcje OUTPUT
        public void ClearViewOutputDataPart(int WindowWidth, int WindowHeight)
        {
            int vertical_line_x = WindowWidth / vertical_line_part; ;  // Pozycja lini pionowej
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);      // Pozycja linii poziomej
            for (int j = 2; j < horizontal_line_y; j++)
            {
                for (int i = vertical_line_x + 1; i < WindowWidth - 1; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("║");
                Console.ResetColor();
            }
        }


        // Metoda czyszcząca sekcje INFO
        public void ClearViewInfoPart(int WindowWidth, int WindowHeight)
        {
            int vertical_line_x = WindowWidth / vertical_line_part; ;  // Pozycja lini pionowej
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);     // Pozycja linii poziomej
            for (int j = horizontal_line_y + 2; j < WindowHeight - 1; j++)
            {
                for (int i = vertical_line_x + 1; i < WindowWidth - 1; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("║");
                Console.ResetColor();
            }
        }


        // Metoda czyszcząca konsolę - w kontrolrze czasem było to potrzebne
        public void ClearConsole()
        {
            Console.Clear();
        }


        // Metoda ustawiająca kursor w sekcji OPTIONS 
        private int SetCursorInOptionsPart(int WindowWidth, int WindowHeight, int optionLength, int optionsCount, int row)
        {
            int vertical_line_x = WindowWidth / vertical_line_part; ;  // Pozycja lini pionowej
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);   // Pozycja linii poziomej
            int x = ((WindowWidth - (WindowWidth - vertical_line_x)) / 2) - optionLength / 2;
            int y = (WindowHeight - (WindowHeight - horizontal_line_y)) / 2 - optionsCount;
            Console.SetCursorPosition(x-2, y + row);
            return y + row;
        }


        // Metoda ustawiająca kursor w sekcji INPUT
        protected void SetCursorInInputPart(int WindowWidth, int WindowHeight, int offset, int row)
        {
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);   // Pozycja linii poziomej
            Console.SetCursorPosition(1 + offset, (horizontal_line_y + 1) + row);
        }


        // Metoda ustawiająca kursor w sekcji OUTPUT
        protected void SetCursorInDataOutputPart(int WindowWidth, int WindowHeight, int offset, int row)
        {
            int vertical_line_x = WindowWidth / vertical_line_part; // Pozycja linii pionowej
            Console.SetCursorPosition((vertical_line_x + 1) + offset, row);
        }


        // Metoda ustawiająca kursor w sekcji INFO/ERRORS
        protected void SetCursorInInfoPart(int WindowWidth, int WindowHeight, int offset, int row)
        {
            int vertical_line_x = WindowWidth / vertical_line_part;  // Pozycja linii pionowej
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);      // Pozycja linii poziomej
            Console.SetCursorPosition((vertical_line_x + 1) + offset, (horizontal_line_y + 1) + row + 2); 
        }


        // Metoda ustawiająca pointer
        protected void SetPointer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(">");
        }


        // Metoda usuwająca pointer
        protected void RemovePointer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }


        // Metoda pobierająca szerokość sekcji OUTPUT
        protected int GetOutputPartWidth()
        {
            int WindowWidth = Console.WindowWidth; 
            int vertical_line_x = WindowWidth / vertical_line_part; // Pozycja lini pionowej
            int OutputWidth = WindowWidth - vertical_line_x - 2;
            return OutputWidth;
        }


        // Metoda pobierająca wysokość sekcji OUTPUT
        protected int GetOutputPartHeight()
        {
            int WindowHeight = Console.WindowHeight;
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part); // Pozycja linii poziomej
            int OutputHeight = WindowHeight - (WindowHeight - horizontal_line_y)-2;
            return OutputHeight;
        }


        // Metoda pobierająca szerokość sekcji INPUT
        private int GetInputPartWidth()
        {
            int WindowWidth = Console.WindowWidth;
            int vertical_line_x = WindowWidth / vertical_line_part; // Pozycja lini pionowej
            int InputWidth = WindowWidth - (WindowWidth - vertical_line_x) - 2;
            return InputWidth;
        }


        // Metoda pobierająca wysokość sekcji INPUT
        private int GetInputPartHeight()
        {
            int WindowHeight = Console.WindowHeight;
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);   // Pozycja lini poziomej
            int InputHeight = WindowHeight  - horizontal_line_y - 2;
            return InputHeight;
        }
       

        // Metoda ustawiająca podane informacje w sekcji INFO/ERRORS
        protected void SetInfo(string[] infos, int WindowWidth, int WindowHeight)
        {
            for(int i = 0; i < infos.Length; i++)
            {
                SetCursorInInfoPart(WindowWidth, WindowHeight, INFO_OFFSET, i*2);
                if (infos[i][1] == '!')
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if (infos[i][1] == 'V')
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                if (infos[i][1] == '?')
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.Write(infos[i]);
            }
            Console.ResetColor ();
        }


        // Metoda wypisująca na ekranie błąd krytyczny (błąd nie przewidziany przez twórce aplikacji)
        public void PrintUnknownErrorInfo(string exception_message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[!] Wystąpił nieznany błąd. Program został zakończony.");
            Console.WriteLine("[!] Błąd: "+ exception_message);
            Console.WriteLine("[!] Skontaktuj się z obsługą techniczną podając okoliczności wystąpienia błędu.");
            Console.ResetColor();
        }


        // Metoda wypisująca na ekranie błąd (nie ma możliwości wyrenderowania widoku)
        protected void ShowError()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[!] Zbyt mały rozmiar ekranu. Zwiększ rozmiar i spróbuj odświeżyć konsolę wciskając dowolny przycisk");
            Console.ReadKey();
            Console.ResetColor();
        }


        // Metoda wyświetlająca komunikat powodzenia lub błędu w sekcji INFO/ERRORS
        public void ShowSuccessOrException(string succes_or_error_message)
        {
            string[] temp_tab = new string[1]{
                succes_or_error_message
            };
            ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
            SetInfo(temp_tab, Console.WindowWidth, Console.WindowHeight);
            if (succes_or_error_message[1] == 'V')
            {
                Thread.Sleep(1000);
            }
            else
            {
                Thread.Sleep(2000);
            }
            ClearViewInfoPart(Console.WindowWidth, Console.WindowHeight);
        }


        // Metoda tworząca główną ramkę widoku
        public void RenderMainFrame(int WindowWidth, int WindowHeight)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            int vertical_line_x = WindowWidth / vertical_line_part;
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);
            Console.SetCursorPosition(0, 0);

            Console.Write("╔");
            for (int i = 0; i < WindowWidth-2; i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            Console.SetCursorPosition(vertical_line_x, 0);
            Console.Write("╦");

            for (int i = 0; i < WindowHeight-2; i++)
            {
                Console.SetCursorPosition(0, i+1);
                Console.Write("║");
                Console.SetCursorPosition(vertical_line_x, i + 1);
                Console.Write("║");
                Console.SetCursorPosition(WindowWidth-1, i+1);
                Console.Write("║");
            }
            Console.SetCursorPosition(0, horizontal_line_y);
            Console.Write("╠");
            for (int i = 0; i < WindowWidth-2; i++)
            {
                Console.Write("═");        
            }
            Console.Write("╣");
            Console.SetCursorPosition(vertical_line_x, horizontal_line_y);
            Console.Write("╬");

            Console.SetCursorPosition(0, WindowHeight-1);
            Console.Write("╚");
            for (int i = 0; i < WindowWidth - 2; i++)
            {
                if(i== vertical_line_x-1)
                {
                    Console.Write("╩");
                }
                else
                {
                    Console.Write("═");
                }       
            }
            Console.Write("╝");
            Console.ResetColor();
            string menu = "[MENU]";
            string input = "[INPUT]";
            string output = "[OUTPUT]";

            string info = "INFO";
            string errors = "ERRORS";

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition((vertical_line_x/2 - menu.Length/2)-1, 1);
            Console.Write(menu);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition((vertical_line_x / 2 - input.Length / 2) - 1, horizontal_line_y + 1);
            Console.Write(input);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(vertical_line_x + (WindowWidth - vertical_line_x) / 2 - output.Length / 2 - 2, 1);
            Console.Write(output);
            Console.ResetColor();
            Console.SetCursorPosition(vertical_line_x + (WindowWidth - vertical_line_x) / 2 - output.Length / 2 - 2, horizontal_line_y+1);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("[");
            Console.Write(info);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(errors);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("]");
            Console.ResetColor();
        }



        // Metoda renderująca główny widok użytkownika i administratora - pierwsze menu po przejściu do wybranego trybu
        protected int RenderMainAdminUserView(string[] info, string[] options)
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            RenderMainFrame(WindowWidth, WindowHeight);
            SetInfo(info, WindowWidth, WindowHeight);
            Console.CursorVisible = false;

            bool isOptionSelected = false;
            int selectOption = 1;

            while (!isOptionSelected)
            {
                // Jeśli nastąpiła zmiana rozmiaru ekranu
                if (Console.WindowWidth != WindowWidth || Console.WindowHeight != WindowHeight)
                {
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;

                    // Jeśli rozmiar ekranu jest zbyt mały
                    while (WindowWidth < 130 || WindowHeight < 40)
                    {
                        ShowError();
                        WindowWidth = Console.WindowWidth;
                        WindowHeight = Console.WindowHeight;
                    }

                    // Odśwież widok i dostosuj wszystkie jego elementy do aktualnego rozmiaru okna
                    Console.Clear();
                    RenderMainFrame(WindowWidth, WindowHeight);
                    SetHowManyResWereDisplayed();
                    SetInfo(info, WindowWidth, WindowHeight);
                    PrintInputArt();
                    Console.CursorVisible = false;
                }
                // Wybierz opcję
                MakeChoice(options, ref isOptionSelected, ref selectOption, WindowWidth, WindowHeight);
            }
            return selectOption;

        }


        // Metoda służaca do wybrania opcji menu
        protected void MakeChoice(string[] options, ref bool isOptionSelected, ref int selectOption, int WindowWidth, int WindowHeight)
        {
            string pointer = ">";
            int row = 0;
            Console.ResetColor();
            for (int i = 0; i < options.Length; i++)
            {
                row = SetCursorInOptionsPart(WindowWidth, WindowHeight, options[i].Length, options.Length, (i * 2)+2);
                if(selectOption == i + 1)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write($"{pointer} {options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"  {options[i]}");
                }
            }
            Console.SetCursorPosition(0, row + 1);
            ConsoleKeyInfo key = Console.ReadKey();
            Console.SetCursorPosition(0, row + 1);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("║");
            Console.ResetColor();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectOption = selectOption == 1 ? options.Length : selectOption - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectOption = selectOption == options.Length ? 1 : selectOption + 1;
                    break;

                case ConsoleKey.Enter:
                    isOptionSelected = true;
                    break;
            }
        }

        // Metoda służąca do przewijania listy filmów do góry
        public void ScrollUp(List<Movie> mov)
        {
            scrollDownMovies = false;
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            int HowManyMoviesCanDisplay = (WindowHeight - (WindowHeight / 3) - 7) / 2;

            if (FirstDisplayedMovie - HowManyMoviesCanDisplay + 1 >= 0)
            {
                ClearViewOutputDataPart(WindowWidth, WindowHeight);

                howManyMoviesWereDisplayed -= (HowManyMoviesCanDisplay + 1);

                ShowMoviesList(WindowWidth, WindowHeight ,mov, FirstDisplayedMovie - (HowManyMoviesCanDisplay + 1));
            }
        }


        // Metoda służąca do przewijania listy filmów do dołu
        public void ScrollDown(List<Movie> mov)
        {
            scrollDownMovies = true;
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            SetCursorInInputPart(WindowWidth, WindowHeight, 2, 6);

            if (howManyMoviesWereDisplayed < mov.Count)
            {
                ClearViewOutputDataPart(WindowWidth, WindowHeight);
                ShowMoviesList(WindowWidth, WindowHeight,mov, howManyMoviesWereDisplayed);
            }
        }


        // Metoda służąca do przewijania listy rezerwacji do góry
        public void ScrollUp(List<Reservation> res)
        {
            scrollDownReservations = false;
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            int HowManyReservationsCanDisplay = (WindowHeight - (WindowHeight / 3) - 7) / 2;

            if (FirstDisplayedReservation - HowManyReservationsCanDisplay + 1 >= 0)
            {
                ClearViewOutputDataPart(WindowWidth, WindowHeight);

                howManyReservationsWereDisplayed -= (HowManyReservationsCanDisplay + 1);

                ShowReservationList(res, FirstDisplayedReservation - (HowManyReservationsCanDisplay + 1));
            }
        }


        // Metoda służąca do przewijania listy rezerwacji do dołu
        public void ScrollDown(List<Reservation> res)
        {
            scrollDownReservations = true;
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            if (howManyReservationsWereDisplayed < res.Count)
            {
                ClearViewOutputDataPart(WindowWidth, WindowHeight);
                ShowReservationList(res, howManyReservationsWereDisplayed);
            }
        }


        // Metoda służąca do ustawienie ile rezerwacji zostało wyświetlonych
        public void SetHowManyResWereDisplayed()
        {
            howManyReservationsWereDisplayed = ((Console.WindowHeight - (Console.WindowHeight / 3) - 5) / 2);
            scrollDownReservations = false;
        }


        // Metoda służąca do ustawienie ile filmów zostało wyświetlonych
        public void SetHowManyMoviesWereDisplayed()
        {
            howManyMoviesWereDisplayed = ((Console.WindowHeight - (Console.WindowHeight / 3) - 5) / 2);
            scrollDownMovies = false;
        }


        // Metoda służąca do wyświetlenia listy rezerwacji w sekcji OUTPUT
        public void ShowReservationList(List<Reservation> res, int startIndex)
        {
            // Wyjątek konieczny bo są problemy przy usunięciu ostatniej rezerwacji i próbie wyświetlenia listy
            if (!res.Any())
            {
                throw new ReservationListIsEmptyException("Lista jest pusta !");
            }
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            FirstDisplayedReservation = startIndex;

            int HowManyReservationsCanDisplay = (WindowHeight - (WindowHeight / 3) - 7) / 2;

            int longestTitle = res.Max(item => item.Movie.Title.Length);
            int maxSeats = res.Max(item => item.Seats.Count);
            int date_length = res.Max(item => item.Movie.Date.ToString("dd/MM/yyyy HH:mm").Length);
            int longestId = res.Max(item => item.Movie.Id.ToString().Length);

            string id = "[ID]";
            string title = "[Tytuł filmu]";
            string date = "[Data]";
            string room = "[Sala]";
            string price = "[Cena]";
            string seats = "[Miejsca]";


            int longestPrice = res.Max(r => r.Movie.Price.ToString().Length);
            if (longestTitle < title.Length)
            {
                longestTitle = title.Length;
            }
            if (longestId < id.Length - 2)
            {
                longestId += 1;
            }
            if (longestPrice == 1)
            {
                longestPrice += 2;
            }
            else if (longestPrice == 2)
            {
                longestPrice += 1;
            }
            
            string topTable = $"┌{new string('─', id.Length)}┬{new string('─', longestTitle + 2)}┬{new string('─', date_length + 2)}┬" +
                $"{new string('─', room.Length + 2)}┬{new string('─', price.Length + 2)}┬{new string('─', maxSeats + maxSeats + 1)}┐";

            int offset = (GetOutputPartWidth() - topTable.Length) / 2;

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, 2);
            Console.Write(topTable);
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, 3);

            Console.Write("│");
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset + 1, 3);

            Console.Write($"{id}│ {title.PadLeft(longestTitle / 2 + 3).PadRight(longestTitle)} │ {date.PadLeft((date_length - date.Length / 2) - 2)}      " +
                $"│ {room} │ {price.PadRight(price.Length + longestPrice - 3)} │ {seats.PadRight(2 * maxSeats)}│");

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, 4);
            Console.Write($"├{new string('─', id.Length)}┼{new string('─', longestTitle + 2)}┼{new string('─', date_length + 2)}" +
                $"┼{new string('─', room.Length + 2)}┼{new string('─', price.Length + 2)}┼{new string('─', maxSeats + maxSeats + 1)}┤");

            int row = 5;
            int iter = 0;
            string ticketPrice;
            int pad;
            for (int i = startIndex; i < res.Count; i++)
            {
                pad = 0;
                ticketPrice = res[i].Ticket.CalculatePrice(res[i].Movie.Price, res[i].Seats.Count).ToString();
                if (ticketPrice.Length == 1) pad = 4;
                if (ticketPrice.Length == 2) pad = 3;
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row);
                string seats_nr = string.Join(" ", res[i].Seats);
                Console.Write($"│ {res[i].Id.ToString().PadRight(longestId)} │ {res[i].Movie.Title.PadRight(longestTitle)} │ {res[i].Movie.Date.ToString("dd/MM/yyyy HH:mm")}" +
                    $" │   {res[i].Movie.Room.Number}    │  {ticketPrice.PadRight(pad)}" +
                    $"   │{seats_nr.PadRight(2 * maxSeats)} │");

                SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row + 1);
                Console.Write($"├{new string('─', id.Length)}┼{new string('─', longestTitle + 2)}┼{new string('─', date_length + 2)}" +
                $"┼{new string('─', room.Length + 2)}┼{new string('─', price.Length + 2)}┼{new string('─', maxSeats + maxSeats + 1)}┤");
                row += 2;


                if (iter == HowManyReservationsCanDisplay)
                {
                    if (scrollDownReservations)
                    {
                        howManyReservationsWereDisplayed += HowManyReservationsCanDisplay + 1;
                    }
                    break;
                }
                iter++;
            }
            if (scrollDownReservations && startIndex + HowManyReservationsCanDisplay + 1 > res.Count)
            {
                howManyReservationsWereDisplayed += HowManyReservationsCanDisplay + 1;
            }

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row - 1);
            Console.Write($"└{new string('─', id.Length)}┴{new string('─', longestTitle + 2)}┴{new string('─', date_length + 2)}" +
                $"┴{new string('─', room.Length + 2)}┴{new string('─', price.Length + 2)}┴{new string('─', maxSeats + maxSeats + 1)}┘");

        }



        // Metoda służąca do wyświetlenia listy filmów w sekcji OUTPUT
        public void ShowMoviesList(int WindowWidth, int WindowHeight, List<Movie> movies, int startIndex)
        {
            // Wyjątek konieczny bo są problemy przy usunięciu ostatniego filmu i próbie wyświetlenia listy
            if (!movies.Any())
            {
                throw new MovieListIsEmptyException("Lista jest pusta!");
            }
            int HowManyMoviesCanDisplay = (WindowHeight - (WindowHeight / 3) - 7) / 2;
            ClearViewOutputDataPart(WindowWidth,WindowHeight);
            int longestTitle = movies.Max(m => m.Title.Length);
            int longestPrice = movies.Max(m => m.Price.ToString().Length);
            int longestId = movies.Max(m => m.Id.ToString().Length);
            int date_length = movies.Max(item => item.Date.ToString("dd/MM/yyyy HH:mm").Length);

            FirstDisplayedMovie = startIndex;

            string id = "[ID]";
            string title = "[Tytuł]";
            string date = "[Data]";
            string price = "[Cena]";
            string duration = "[Czas]";
            string roomNr = "[Sala]";
            if (longestTitle < title.Length)
            {
                longestTitle = title.Length;
            }
            if (longestId < id.Length - 2)
            {
                longestId += 1;
            }
            if (longestPrice == 1)
            {
                longestPrice += 2;
            }
            else if (longestPrice == 2)
            {
                longestPrice += 1;
            }

            string topTable = $"┌{new string('─', id.Length)}┬{new string('─', longestTitle + 2)}┬{new string('─', date_length + 2)}┬" +
                $"{new string('─', price.Length + longestPrice - 1)}┬{new string('─', duration.Length + 2)}┬{new string('─', roomNr.Length + 2)}┐";

            int offset = (GetOutputPartWidth() - topTable.Length) / 2;

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, 2);
            Console.Write(topTable);
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, 3);
            Console.Write("│");

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset+1, 3);
            Console.Write($"{id}│ {title.PadLeft(longestTitle/2+3).PadRight(longestTitle)} │ {date.PadLeft((date_length - date.Length / 2) - 2)}      " +
                $"│ {price.PadRight(price.Length + longestPrice - 3)} │ {duration} │ {roomNr} │");

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, 4);
            Console.Write($"├{new string('─', id.Length)}┼{new string('─', longestTitle + 2)}┼{new string('─', date_length + 2)}" +
                $"┼{new string('─', price.Length + longestPrice - 1)}┼{new string('─', duration.Length + 2)}┼{new string('─', roomNr.Length + 2)}┤");

            int row = 5;
            int iter = 0;
            for (int i = startIndex; i < movies.Count; i++)
            {
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row);
                Console.Write($"│ {movies[i].Id.ToString().PadRight(longestId)} │ {movies[i].Title.PadRight(longestTitle)} │ {movies[i].Date.ToString("dd/MM/yyyy HH:mm")}" +
                    $" │  {movies[i].Price.ToString().PadRight(longestPrice)}   │  {movies[i].Duration}" +
                    $"  │   {movies[i].Room.Number}    │");

                SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row + 1);
                Console.Write($"├{new string('─', id.Length)}┼{new string('─', longestTitle + 2)}┼{new string('─', date_length + 2)}" +
                $"┼{new string('─', price.Length+longestPrice-1)}┼{new string('─', duration.Length + 2)}┼{new string('─', roomNr.Length + 2)}┤");
                row += 2;
                
                if (iter == HowManyMoviesCanDisplay)
                {
                    if (scrollDownMovies)
                    {
                        howManyMoviesWereDisplayed += HowManyMoviesCanDisplay + 1;
                    }
                    break;
                }
                iter++;
            }
            if (scrollDownMovies && startIndex + HowManyMoviesCanDisplay + 1 > movies.Count)
            {
                howManyMoviesWereDisplayed += HowManyMoviesCanDisplay + 1;
            }

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row - 1);
            Console.Write($"└{new string('─', id.Length)}┴{new string('─', longestTitle + 2)}┴{new string('─', date_length + 2)}" +
                $"┴{new string('─', price.Length + longestPrice - 1)}┴{new string('─', duration.Length + 2)}┴{new string('─', roomNr.Length + 2)}┘");
            
        }


        // Metoda wyświetlająca formularz w sekcji INPUT 
        protected void SetInput(int WindowWidth, int WindowHeight, string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                SetCursorInInputPart(WindowWidth, WindowHeight, 3, i + 2);
                Console.Write(input[i]);
            }
        }


        // Metoda służaca do wprowadzania danych do formularza
        protected string EnterDataForFilterSortAndRemove(string[] info, string[] inputData)
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            ClearViewInputPart(WindowWidth, WindowHeight);
            ClearViewInfoPart(WindowWidth, WindowHeight);
            SetInfo(info, WindowWidth, WindowHeight);

            SetInput(WindowWidth, WindowHeight, inputData);

            int offset = inputData[0].Length + 3;

            string pointer = "> ";
            SetCursorInInputPart(WindowWidth, WindowHeight, 1, 2);
            Console.Write(pointer);
            SetCursorInInputPart(WindowWidth, WindowHeight, offset, 2);

            StringBuilder inputBuilder = new StringBuilder();
            bool isEnterPressed = false;
            while (!isEnterPressed)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            return null;
                        }
                    case ConsoleKey.Enter:
                        {
                            isEnterPressed = true;
                            break;
                        }
                    case ConsoleKey.Backspace:
                        {
                            if (inputBuilder.Length == 0)
                            {
                                SetCursorInInputPart(WindowWidth, WindowHeight, inputData[0].Length + 3, 2);
                            }
                            else
                            {
                                inputBuilder.Remove(inputBuilder.Length - 1, 1);
                                Console.Write(" ");
                                SetCursorInInputPart(WindowWidth, WindowHeight, offset - 1, 2);
                                offset--;
                            }
                            break;
                        }
                    default:
                        {
                            if (!char.IsControl(keyInfo.KeyChar))
                            {
                                inputBuilder.Append(keyInfo.KeyChar);
                                offset++;
                            }
                            break;
                        }
                }
            }
            return inputBuilder.ToString();
        }


        // Metoda służąca do filtrowania listy filmów
        public string FilterList()
        {
            // Wywołanie metody służącej do wprowadzania danych do formularza z odpowiednimi parametrami
            return EnterDataForFilterSortAndRemove(infoForFilterList, inputDataForFilterList);           
        }


        // Metoda służąca do srotowania listy filmów
        public string SortList()
        {
            // Wywołanie metody służącej do wprowadzania danych do formularza z odpowiednimi parametrami
            return EnterDataForFilterSortAndRemove(infoForSortList, inputDataForSortList);
        }


        // Metoda służąca do wyrenderowania widoku rezerwacji
        protected int RenderReservationsView(string[] infos, List<Reservation> res, string[] options)
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            SetInfo(infos, WindowWidth, WindowHeight);

            Console.CursorVisible = false;

            bool isOptionSelected = false;
            int selectOption = 1;

            while (!isOptionSelected)
            {
                if (Console.WindowWidth != WindowWidth || Console.WindowHeight != WindowHeight)
                {
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;

                    while (WindowWidth < 130 || WindowHeight < 40)
                    {
                        ShowError();
                        WindowWidth = Console.WindowWidth;
                        WindowHeight = Console.WindowHeight;
                    }
                    Console.Clear();
                    RenderMainFrame(WindowWidth, WindowHeight);
                    SetHowManyResWereDisplayed();
                    ShowReservationList(res, 0);
                    SetInfo(infos, WindowWidth, WindowHeight);
                    PrintInputArt();
                    Console.CursorVisible = false;
                }
                MakeChoice(options, ref isOptionSelected, ref selectOption, WindowWidth, WindowHeight);
            }
            return selectOption;
        }


        // Metoda służąca do wyrenderowania widoku filmów
        protected int RenderMoviesView(string[] infos, List<Movie> movies, string[] options)
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            SetInfo(infos, WindowWidth, WindowHeight);

            Console.CursorVisible = false;

            bool isOptionSelected = false;
            int selectOption = 1;

            while (!isOptionSelected)
            {
                if (Console.WindowWidth != WindowWidth || Console.WindowHeight != WindowHeight)
                {
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;

                    while (WindowWidth < 130 || WindowHeight < 40)
                    {
                        ShowError();
                        WindowWidth = Console.WindowWidth;
                        WindowHeight = Console.WindowHeight;
                    }
                    Console.Clear();
                    RenderMainFrame(WindowWidth, WindowHeight);
                    SetHowManyMoviesWereDisplayed();
                    ShowMoviesList(WindowWidth, WindowHeight, movies, 0);
                    SetInfo(infos, WindowWidth, WindowHeight);
                    PrintInputArt();
                    Console.CursorVisible = false;
                }
                MakeChoice(options, ref isOptionSelected, ref selectOption, WindowWidth, WindowHeight);
            }
            return selectOption;
        }
    }
}