using CinemaApp.Model;
using System.Text;

namespace CinemaApp.Views
{
    public abstract class MainView
    {
        private static readonly int INFO_OFFSET = 1; 
        private static readonly int vertical_line_part = 3; // 1/4 szerokości widoku
        private static readonly int horizontal_line_part = 3; // 1/2 wysokości widoku

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

        public void SetDefaultInfo()
        {
            SetInfo(infos, Console.WindowWidth, Console.WindowHeight);
        }

        public void PrintInputArt()
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            ClearViewInputPart(WindowWidth, WindowHeight);
            int offest_row = (GetInputPartHeight() - keyboradArt.Length) / 2;
            int offset = (GetInputPartWidth() - (keyboradArt[0].Length)) / 2;
            for (int i = 0; i < keyboradArt.Length; i++)
            {
                SetCursorInInputPart(WindowWidth, WindowHeight, offset, i + offest_row+1);//row_offset);
                Console.WriteLine(keyboradArt[i]);
            }
        }
        public void ClearViewOptionsPart(int WindowWidth, int WindowHeight)
        {
            int vertical_line_x = WindowWidth / vertical_line_part; ;  // pionowa
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);      // pozioma
            for (int j = 2; j < horizontal_line_y; j++)      
            {
                for (int i = 1; i < vertical_line_x; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
        }
        private int SetCursorInOptionsPart(int WindowWidth, int WindowHeight, int optionLength, int optionsCount, int row)
        {
            //Console.SetCursorPosition(WindowWidth / 2 - (menuOptions[i].Length / 2), WindowHeight / 2 - (menuOptions.Length / 2) + i * 2);
            int vertical_line_x = WindowWidth / vertical_line_part; ;  // pionowa
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);      // pozioma
            int x = ((WindowWidth - (WindowWidth - vertical_line_x)) / 2) - optionLength / 2;
            int y = (WindowHeight - (WindowHeight - horizontal_line_y)) / 2 - optionsCount;
            Console.SetCursorPosition(x-2, y + row);
            return y + row;
            //Console.SetCursorPosition(1 + offset, row+1); // Tutaj może być problem jeśli row będzie za duże i też nie może być zerem
        }
        protected void SetPointer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(">");
        }
        protected void RemovePointer(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        protected void SetCursorInInputPart(int WindowWidth, int WindowHeight, int offset, int row)
        {
            int vertical_line_x = WindowWidth / vertical_line_part; ;  // pionowa
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);      // pozioma
            // Offset tez nie mozebyc za duży
            Console.SetCursorPosition(1+offset, (horizontal_line_y+1)+row); // Tutaj może być problem jeśli row będzie za duże i też nie może być zerem
        }
        protected int GetOutputPartHeight()
        {
            int WindowHeight = Console.WindowHeight;
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);
            int OutputHeight = WindowHeight - (WindowHeight - horizontal_line_y)-2;
            return OutputHeight;
        }
        private int GetInputPartWidth()
        {
            int WindowWidth = Console.WindowWidth;
            int vertical_line_x = WindowWidth / vertical_line_part;
            int InputWidth = WindowWidth - (WindowWidth - vertical_line_x) - 2;
            return InputWidth;
        }
        private int GetInputPartHeight()
        {
            int WindowHeight = Console.WindowHeight;
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);
            int InputHeight = WindowHeight  - horizontal_line_y - 2;
            return InputHeight;
        }
        protected int GetOutputPartWidth()
        {
            int WindowWidth = Console.WindowWidth;
            int vertical_line_x = WindowWidth / vertical_line_part;
            int OutputWidth = WindowWidth - vertical_line_x-2;
            return OutputWidth;
        }
        protected void SetCursorInDataOutputPart(int WindowWidth, int WindowHeight, int offset, int row)
        {
            int vertical_line_x = WindowWidth / vertical_line_part;  // pionowa
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);      // pozioma
            // Offset tez nie mozebyc za duży
            Console.SetCursorPosition((vertical_line_x+ 1) + offset, row); // Tutaj może być problem jeśli row będzie za duże i też nie może być zerem
        }
        protected void SetCursorInInfoPart(int WindowWidth, int WindowHeight, int offset, int row)
        {
            int vertical_line_x = WindowWidth / vertical_line_part;  // pionowa
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);      // pozioma
            // Offset tez nie mozebyc za duży
            Console.SetCursorPosition((vertical_line_x + 1) + offset, (horizontal_line_y + 1) + row+2); // Tutaj może być problem jeśli row będzie za duże i też nie może być zerem
        }
        public void ClearViewInputPart(int WindowWidth, int WindowHeight)
        {
            int vertical_line_x = WindowWidth / vertical_line_part; ;  // pionowa
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);      // pozioma
            for (int j = horizontal_line_y + 2; j < WindowHeight-1; j++)     
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
        public void ClearViewOutputDataPart(int WindowWidth, int WindowHeight)
        {
            int vertical_line_x = WindowWidth / vertical_line_part; ;  // pionowa
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);      // pozioma
            for (int j = 2; j < horizontal_line_y; j++)      
            {
                for (int i = vertical_line_x + 1; i < WindowWidth-1; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("║");
                Console.ResetColor();
            }
        }
        public void ClearViewInfoPart(int WindowWidth, int WindowHeight)
        {
            int vertical_line_x = WindowWidth / vertical_line_part; ;  // pionowa
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);      // pozioma
            for (int j = horizontal_line_y + 2; j < WindowHeight-1; j++)    
            {
                for (int i = vertical_line_x + 1; i < WindowWidth-1; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("║");
                Console.ResetColor();
            }
        }
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

        public void PrintUnknownErrorInfo(string exception_message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[!] Wystąpił nieznany błąd. Program został zakończony.");
            Console.WriteLine("[!] Błąd: "+ exception_message);
            Console.WriteLine("[!] Skontaktuj się z obsługą techniczną podając okoliczności wystąpienia błędu.");
            Console.ResetColor();
        }
        protected void ShowError()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[!] Zbyt mały rozmiar ekranu. Zwiększ rozmiar i spróbuj odświeżyć konsolę wciskając dowolny przycisk");
            Console.ReadKey();
            Console.ResetColor();
        }

        public void RenderMainFrame(int WindowWidth, int WindowHeight)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            int vertical_line_x = WindowWidth / vertical_line_part;  // pionowa
            int horizontal_line_y = WindowHeight - (WindowHeight / horizontal_line_part);               // pozioma
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

            //string info = CYAN_FOREGROUND+"[INFO"+WHITE_FOREGROUND+"/" + RED_FOREGROUND + "ERROS" + CYAN_FOREGROUND + "]" + WHITE_FOREGROUND;
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


            //Console.Write(info);
            //Console.ResetColor();
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


        protected int RenderMainAdminUserView(string[] info, string[] options)
        {
            //Console.SetWindowSize(130, 35);
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            //Console.Clear();
            RenderMainFrame(WindowWidth, WindowHeight);
            SetInfo(info, WindowWidth, WindowHeight);
            Console.CursorVisible = false;

            bool isOptionSelected = false;
            int selectOption = 1;

            while (!isOptionSelected)
            {
                if (Console.WindowWidth != WindowWidth || Console.WindowHeight != WindowHeight)
                {
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;
                    // Tutaj throw exception jeśli rozmiar jest zły w while aby wyrzucać non stop wyjątek jeśli rozmiar jest zły
                    while (WindowWidth < 130 || WindowHeight < 40)
                    {
                        ShowError();
                        WindowWidth = Console.WindowWidth;
                        WindowHeight = Console.WindowHeight;
                    }
                    Console.Clear();
                    RenderMainFrame(WindowWidth, WindowHeight);
                    SetHowManyResWereDisplayed();
                    SetInfo(info, WindowWidth, WindowHeight);
                    PrintInputArt();
                    // Tutaj ponownie uzupełnienie pól
                    Console.CursorVisible = false;
                }
                MakeChoice(options, ref isOptionSelected, ref selectOption, WindowWidth, WindowHeight);
            }
            return selectOption;

        }
        public void ClearConsole()
        {
            Console.Clear();
        }



        protected void MakeChoice(string[] options, ref bool isOptionSelected, ref int selectOption, int WindowWidth, int WindowHeight)
        {
            //string pointer = BLACK_FOREGROUND + WHITE_BACKGROUND + ">";
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
                //Console.WriteLine($"{(selectOption == i + 1 ? pointer : " ")} {options[i]}" + WHITE_FOREGROUND + BLACK_BACKGROUND);
            }

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



        // Mogą być problemy z scrollDown zmienna bool 

        public void ScrollUp(List<Movie> mov)
        {
            scrollDownMovies = false;
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            int HowManyMoviesCanDisplay = (WindowHeight - (WindowHeight / 3) - 7) / 2;

            /*SetCursorInInputPart(WindowWidth, WindowHeight, 2, 6);
            Console.Write("HowManyCanDispaly " + HowManyReservationsCanDisplay);*/

            if (FirstDisplayedMovie - HowManyMoviesCanDisplay + 1 >= 0)
            {
                ClearViewOutputDataPart(WindowWidth, WindowHeight);

                howManyMoviesWereDisplayed -= (HowManyMoviesCanDisplay + 1);

                ShowMoviesList(WindowWidth, WindowHeight ,mov, FirstDisplayedMovie - (HowManyMoviesCanDisplay + 1));
            }
        }
        public void ScrollDown(List<Movie> mov)
        {
            scrollDownMovies = true;
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            SetCursorInInputPart(WindowWidth, WindowHeight, 2, 6);
            //Console.Write("ScrollDownHowManyres were disp " + howManyReservationsWereDisplayed);

            if (howManyMoviesWereDisplayed < mov.Count)
            {
                ClearViewOutputDataPart(WindowWidth, WindowHeight);
                ShowMoviesList(WindowWidth, WindowHeight,mov, howManyMoviesWereDisplayed);
            }
        }
        public void ScrollUp(List<Reservation> res)
        {
            scrollDownReservations = false;
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            int HowManyReservationsCanDisplay = (WindowHeight - (WindowHeight / 3) - 7) / 2;

            /*SetCursorInInputPart(WindowWidth, WindowHeight, 2, 6);
            Console.Write("HowManyCanDispaly " + HowManyReservationsCanDisplay);*/

            if (FirstDisplayedReservation - HowManyReservationsCanDisplay + 1 >= 0)
            {
                ClearViewOutputDataPart(WindowWidth, WindowHeight);

                howManyReservationsWereDisplayed -= (HowManyReservationsCanDisplay + 1);

                ShowReservationList(res, FirstDisplayedReservation - (HowManyReservationsCanDisplay + 1));
            }
        }
        public void ScrollDown(List<Reservation> res)
        {
            scrollDownReservations = true;
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            //SetCursorInInputPart(WindowWidth, WindowHeight, 2, 6);
            //Console.Write("ScrollDownHowManyres were disp " + howManyReservationsWereDisplayed);

            if (howManyReservationsWereDisplayed < res.Count)
            {
                ClearViewOutputDataPart(WindowWidth, WindowHeight);
                ShowReservationList(res, howManyReservationsWereDisplayed);
            }
        }
        public void SetHowManyResWereDisplayed()
        {
            howManyReservationsWereDisplayed = ((Console.WindowHeight - (Console.WindowHeight / 3) - 5) / 2);
            scrollDownReservations = false;
        }
        public void SetHowManyMoviesWereDisplayed()
        {
            howManyMoviesWereDisplayed = ((Console.WindowHeight - (Console.WindowHeight / 3) - 5) / 2);
            scrollDownMovies = false;
            //SetCursorInInfoPart(Console.WindowWidth, Console.WindowHeight, 2, 3);
            //Console.Write("howManyReservationsWereDisplayed" + howManyReservationsWereDisplayed);
        }
        public void ShowReservationList(List<Reservation> res, int startIndex)
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            FirstDisplayedReservation = startIndex;

            /*ClearViewInputPart(WindowWidth, WindowHeight);
            SetCursorInInputPart(WindowWidth, WindowHeight,2, 2);
            Console.Write("HowManyResDisplayed " + howManyReservationsWereDisplayed);
            SetCursorInInputPart(WindowWidth, WindowHeight, 2, 3);
            Console.Write("FirstDisplayedRes " + FirstDisplayedReservation);*/

            // TUTAJ POWINNO BYĆ /3 - HORIZOTAL LINE JESLI PRZESNIESIE SIE TO DO MAIN VIEW
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

            string topTable = $"┌{new string('─', id.Length)}┬{new string('─', longestTitle + 2)}┬{new string('─', date_length + 2)}┬" +
                $"{new string('─', room.Length + 2)}┬{new string('─', price.Length + 2)}┬{new string('─', maxSeats + maxSeats + 1)}┐";

            int offset = (GetOutputPartWidth() - topTable.Length) / 2;

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, 2);
            Console.Write(topTable);
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, 3);

            Console.Write("│");
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset+1, 3);
            Console.Write($"{id}│ {title.PadLeft(longestTitle-4)}     │ {date.PadLeft((date_length - date.Length / 2) - 2)}      " +
                $"│ {room} │ {price} │ {seats.PadRight(2 * maxSeats)}│");

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, 4);
            Console.Write($"├{new string('─', id.Length)}┼{new string('─', longestTitle + 2)}┼{new string('─', date_length + 2)}" +
                $"┼{new string('─', room.Length + 2)}┼{new string('─', price.Length + 2)}┼{new string('─', maxSeats + maxSeats + 1)}┤");

            int row = 5;
            int iter = 0;
            for (int i = startIndex; i < res.Count; i++)
            {
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row);
                string seats_nr = string.Join(" ", res[i].Seats);
                Console.Write($"│ {res[i].Id.ToString().PadRight(longestId)} │ {res[i].Movie.Title.PadRight(longestTitle)} │ {res[i].Movie.Date.ToString("dd/MM/yyyy HH:mm")}" +
                    $" │   {res[i].Movie.Room.Number}    │  {res[i].Ticket.CalculatePrice(res[i].Movie.Price, res[i].Seats.Count)}" +
                    $"   │{seats_nr.PadRight(2 * maxSeats)} │");

                SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row + 1);
                Console.Write($"├{new string('─', id.Length)}┼{new string('─', longestTitle + 2)}┼{new string('─', date_length + 2)}" +
                $"┼{new string('─', room.Length + 2)}┼{new string('─', price.Length + 2)}┼{new string('─', maxSeats + maxSeats + 1)}┤");
                row += 2;


                if (iter == HowManyReservationsCanDisplay)
                {
                    //LastDisplayedReservation = i;
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

            /*SetCursorInInputPart(WindowWidth, WindowHeight, 2, 4);
            Console.Write("AFHowManyResDisplayed " + howManyReservationsWereDisplayed);
            SetCursorInInputPart(WindowWidth, WindowHeight, 2, 5);
            Console.Write("AFFirstDisplayedRes " + FirstDisplayedReservation);*/

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row - 1);
            Console.Write($"└{new string('─', id.Length)}┴{new string('─', longestTitle + 2)}┴{new string('─', date_length + 2)}" +
                $"┴{new string('─', room.Length + 2)}┴{new string('─', price.Length + 2)}┴{new string('─', maxSeats + maxSeats + 1)}┘");

        }

        public void ShowMoviesList(int WindowWidth, int WindowHeight, List<Movie> movies, int startIndex)
        {
            int HowManyMoviesCanDisplay = (WindowHeight - (WindowHeight / 3) - 7) / 2;
            ClearViewOutputDataPart(WindowWidth,WindowHeight);
            int longestTitle = movies.Max(m => m.Title.Length);
            int longestPrice = movies.Max(m => m.Price.ToString().Length);
            int longestId = movies.Max(m => m.Id.ToString().Length);
            int date_length = movies.Max(item => item.Date.ToString("dd/MM/yyyy HH:mm").Length);

            FirstDisplayedMovie = startIndex;

            /*ClearViewInputPart(WindowWidth, WindowHeight);

            SetCursorInInputPart(WindowWidth, WindowHeight,2, 2);
            Console.Write("HowManyMovDisplayed " + howManyMoviesWereDisplayed);
            SetCursorInInputPart(WindowWidth, WindowHeight, 2, 3);*/

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

            //default price.lenght+2
            string topTable = $"┌{new string('─', id.Length)}┬{new string('─', longestTitle + 2)}┬{new string('─', date_length + 2)}┬" +
                $"{new string('─', price.Length + longestPrice - 1)}┬{new string('─', duration.Length + 2)}┬{new string('─', roomNr.Length + 2)}┐";

            int offset = (GetOutputPartWidth() - topTable.Length) / 2;


            // default offset = 2 

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
           /* SetCursorInInputPart(WindowWidth, WindowHeight, offset, 4);
            Console.Write("AFHowManyMovDisplayed " + howManyMoviesWereDisplayed);
            SetCursorInInputPart(WindowWidth, WindowHeight, offset, 5);
            Console.Write("AFFirstDisplayedMov " + FirstDisplayedMovie);*/

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row - 1);
            Console.Write($"└{new string('─', id.Length)}┴{new string('─', longestTitle + 2)}┴{new string('─', date_length + 2)}" +
                $"┴{new string('─', price.Length + longestPrice - 1)}┴{new string('─', duration.Length + 2)}┴{new string('─', roomNr.Length + 2)}┘");
            
        }

        protected void SetInput(int WindowWidth, int WindowHeight, string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                SetCursorInInputPart(WindowWidth, WindowHeight, 3, i + 2);
                Console.Write(input[i]);
            }
        }
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
                                // Usuń ostatni znak
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
        public string FilterList()
        {
            return EnterDataForFilterSortAndRemove(infoForFilterList, inputDataForFilterList);           
        }
        public string SortList()
        {
            return EnterDataForFilterSortAndRemove(infoForSortList, inputDataForSortList);
        }
        protected int RenderReservationsView(string[] infos, List<Reservation> res, string[] options)
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            //Console.WriteLine(WindowWidth + " " + WindowHeight);
           // ClearViewInfoPart(WindowWidth, WindowHeight);
            //ClearViewOptionsPart(WindowWidth, WindowHeight);
            // ClearViewOutputDataPart(WindowWidth, WindowHeight);            
            //ClearViewInputPart(WindowWidth, WindowHeight);

            SetInfo(infos, WindowWidth, WindowHeight);
            // ShowMoviesList(WindowWidth, WindowHeight, movies);

            Console.CursorVisible = false;

            bool isOptionSelected = false;
            int selectOption = 1;

            while (!isOptionSelected)
            {
                if (Console.WindowWidth != WindowWidth || Console.WindowHeight != WindowHeight)
                {
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;
                    // Tutaj throw exception jeśli rozmiar jest zły w while aby wyrzucać non stop wyjątek jeśli rozmiar jest zły
                    while (WindowWidth < 130 || WindowHeight < 40)
                    {
                        ShowError();
                        WindowWidth = Console.WindowWidth;
                        WindowHeight = Console.WindowHeight;
                    }
                    Console.Clear();
                    RenderMainFrame(WindowWidth, WindowHeight);
                    SetHowManyResWereDisplayed();
                    ShowReservationList(res, 0); // z indexem 0
                    SetInfo(infos, WindowWidth, WindowHeight);
                    PrintInputArt();
                    // Tutaj ponownie uzupełnienie pól
                    Console.CursorVisible = false;
                }
                MakeChoice(options, ref isOptionSelected, ref selectOption, WindowWidth, WindowHeight);
            }
            return selectOption;
        }
        protected int RenderMoviesView(string[] infos, List<Movie> movies, string[] options)
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            //Console.WriteLine(WindowWidth + " " + WindowHeight);

            //ClearViewInfoPart(WindowWidth, WindowHeight);
            //ClearViewOptionsPart(WindowWidth, WindowHeight);

            // ClearViewOutputDataPart(WindowWidth, WindowHeight);            
            //ClearViewInputPart(WindowWidth, WindowHeight);

            SetInfo(infos, WindowWidth, WindowHeight);
            // ShowMoviesList(WindowWidth, WindowHeight, movies);

            Console.CursorVisible = false;

            bool isOptionSelected = false;
            int selectOption = 1;

            while (!isOptionSelected)
            {
                if (Console.WindowWidth != WindowWidth || Console.WindowHeight != WindowHeight)
                {
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;
                    // Tutaj throw exception jeśli rozmiar jest zły w while aby wyrzucać non stop wyjątek jeśli rozmiar jest zły
                    while (WindowWidth < 130 || WindowHeight < 40)
                    {
                        ShowError();
                        WindowWidth = Console.WindowWidth;
                        WindowHeight = Console.WindowHeight;
                    }
                    Console.Clear();
                    RenderMainFrame(WindowWidth, WindowHeight);
                    SetHowManyMoviesWereDisplayed();
                   // adminView.ShowMoviesList(Console.WindowWidth, Console.WindowHeight, movies, 0);
                    ShowMoviesList(WindowWidth, WindowHeight, movies, 0); // z indexem 0
                    SetInfo(infos, WindowWidth, WindowHeight);
                    PrintInputArt();
                    // Tutaj ponownie uzupełnienie pól
                    Console.CursorVisible = false;
                }
                MakeChoice(options, ref isOptionSelected, ref selectOption, WindowWidth, WindowHeight);
            }
            return selectOption;
        }
    }
}
