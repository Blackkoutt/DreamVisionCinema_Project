using CinemaApp.Interfaces.IViews;
using CinemaApp.Model;
using System.Text;

namespace CinemaApp.Views
{
    public class AdminView : MainView, IAdminView
    {
        private readonly string[] adminMenuOptions;
        private readonly string[] adminMoviesMenuOptions;
        private readonly string[] inputDataForAddMovie;
        private readonly string[] inputDataForModifyMovie;
        private readonly string[] infoForAddMovie;
        private readonly string[] infoForRemoveMovie;
        private readonly string[] inputDataForRemoveMovie;
        private readonly string[] infoForModifyMovie; 
        private readonly string[] adminStatisticsOptions;
        private readonly string[] statisticArt =
        {
          "   ██                                                                     ▒▒▒▒▒    ",
          " ██████     ░░                  ░░                  ░░                  ░░    ▒▒▒▒ ",     
          "██ ██ ██    ░░                  ░░                  ░░                  ░░▒▒▒▒▒▒▒▒▒",
          "██ ██ ██    ░░                  ░░                  ░░                ▒▒▒▒▒▒▒▒▒▒▒▒ ",
          "   ██       ░░                  ░░                  ░░            ▒▒▒▒▒▒▒▒   ▒▒▒▒  ",
          "   ██       ░░                  ░░                  ░░        ▒▒▒▒▒▒▒▒  ░░  ▒▒▒    ",
          "   ██       ░░                  ░░                  ░░      ▒▒▒▒▒▒      ░░ ▒▒▒     ",
          "   ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒░░░░░░░░░░░▒▒░░░░   ",
          "   ██       ░░        ▒▒▒▒      ░░                  ░░▒▒▒▒▒▒            ░░         ",
          "   ██       ░░       ▒▒▒▒▒▒     ░░                  ▒▒▒▒▒               ░░         ",
          "   ██       ░░       ▒▒▒▒▒▒▒▒   ░░               ▒▒▒▒░                  ░░         ",
          "   ██       ░░     ▒▒▒▒    ▒▒▒▒ ░░              ▒▒▒▒▒░                  ░░         ",
          "   ██       ░░   ▒▒▒▒        ▒▒▒▒░             ▒▒▒▒ ░░                  ░░         ",
          "   ██       ░░ ▒▒▒▒           ▒▒▒▒           ▒▒▒▒   ░░                  ░░         ",
          "   ██░░░░░░░░▒▒▒▒░░░░░░░░░░░░░░░▒▒▒▒░░░░░░░░▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░   ",                                       
          "   ██     ▒▒▒▒▒▒                ░▒▒▒▒     ▒▒▒▒      ░░                  ░░         ",                                
          "   ██    ▒▒▒▒░                  ░░ ▒▒▒▒▒▒▒▒▒▒       ░░                  ░░         ",                                     
          "   ██  ▒▒▒▒ ░░                  ░░   ▒▒▒▒▒▒         ░░                  ░░         ",                               
          "   ██▒▒     ░░                  ░░                  ░░                  ░░ ███     ",               
          "   ██       ░░                  ░░                  ░░                  ░░    ███  ",                 
          " ██████████████████████████████████████████████████████████████████████████████████",
          "   ██                                                                         ███  ",
          "                                                                            ███    "
        };
        private readonly string[] moneyArt =
        {
               "          ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓          ",
               "        ▓▓                      ▓▓        ",
               "      ▓▓                          ▓▓      ",
               "    ▓▓                              ▓▓    ",
               "  ▓▓                ▓▓                ▓▓  ",
               "▓▓               ▓▓▓▓▓▓▓▓               ▓▓",
               "▓▓             ▓▓   ▓▓   ▓▓             ▓▓",
               "▓▓             ▓▓   ▓▓                  ▓▓",
               "▓▓               ▓▓▓▓▓▓▓▓               ▓▓",
               "▓▓                  ▓▓   ▓▓             ▓▓",
               "▓▓             ▓▓   ▓▓   ▓▓             ▓▓",
               "▓▓               ▓▓▓▓▓▓▓▓               ▓▓",
               "▓▓                  ▓▓                  ▓▓",
               "  ▓▓                                  ▓▓  ",
               "    ▓▓                              ▓▓    ",
               "      ▓▓                          ▓▓      ",
               "        ▓▓                      ▓▓        ",
               "          ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓          "
        };
        private readonly string[] topArt =
        {
               "▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓",
               "▓▓                                      ▓▓",
               "▓▓                                      ▓▓",
               "▓▓                ░░░░░░                ▓▓",
               "▓▓                ░░░░░░                ▓▓",
               "▓▓                  ░░                  ▓▓",
               "▓▓      ░░░░      ░░░░░░      ░░░░      ▓▓",
               "▓▓      ░░░░      ░░░░░░      ░░░░      ▓▓",
               "▓▓  ░░    ░░    ░░░░▓▓░░░░    ░░    ░░  ▓▓",
               "▓▓  ░░    ░░░░  ░░▓▓▓▓▓▓░░  ░░░░    ░░  ▓▓",
               "▓▓  ░░░░  ▓▓▓▓░░░░▓▓▓▓▓▓░░▓▓▓▓░░  ░░░░  ▓▓",
               "▓▓  ░░▓▓░░▓▓▓▓░░░░░░▓▓░░░░▓▓▓▓░░░░▓▓░░  ▓▓",
               "▓▓  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  ▓▓",
               "▓▓  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  ▓▓",
               "▓▓  ░░▓▓░░▓▓░░▓▓░░░░▓▓░░░░▓▓░░▓▓░░▓▓░░  ▓▓",
               "▓▓  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  ▓▓",
               "▓▓                                      ▓▓",
               "▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓"
        };
        private readonly string[] mainMoneyArt =
        {
           "              ██████████                               ████                ",
           "               ██    ██                            ████  ░░████            ",
           "             ███      ███                        ██    ▒▒░░▒▒░░██          ",
           "         █████          █████                    ██▒▒▒▒░░░░░░░░██          ",
           "       █████    ▓▓  ▓▓    █████                  ██████░░░░██████          ",
           "     ███     ▓▓▓▓▓▓▓▓▓▓▓     ███                 ██▓▓░░████▒▒░░██          ",
           "     ███  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓   ███                ██████▓▓░░██████          ",
           "   ███    ▓▓▓   ▓▓  ▓▓  ▓▓▓     ███            ▓▓▓▓▓▓  ████▓▓░░██          ",
           "   ███    ▓▓▓   ▓▓  ▓▓          ███        ▓▓▓▓  ▒▒▓▓▓▓▓▓░░██████          ",
           "   ███    ▓▓▓   ▓▓  ▓▓          ███      ▓▓    ░░▒▒░░░░▓▓██▓▓  ██▓▓▓▓      ",
           " ███       ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓        ███    ▓▓░░░░▒▒▒▒░░▒▒▓▓▒▒██▓▓▓▓  ░░▓▓▓▓  ",
           " ███          ▓▓▓▓▓▓▓▓▓▓▓▓▓       ███    ▓▓▓▓▓▓▒▒▒▒▓▓▓▓▓▓██▓▓    ▒▒▒▒░░▒▒▓▓",
           " ███            ▓▓  ▓▓  ▓▓▓       ███    ▓▓▒▒░░▓▓▓▓▒▒  ▓▓░░▓▓▒▒░░▒▒░░░░░░▓▓",
           " ███      ▓▓    ▓▓  ▓▓  ▓▓▓       ███    ▓▓▓▓▓▓▒▒░░▓▓▓▓▓▓██▓▓▓▓▓▓▒▒░░▓▓▓▓▓▓",
           "   ███     ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓        ███    ▓▓▒▒  ▓▓▓▓▒▒  ▓▓  ▓▓▒▒  ▓▓▓▓▒▒  ▓▓",
           "     ███     ▓▓▓▓▓▓▓▓▓▓       ███          ▓▓▓▓▒▒  ▓▓▓▓    ▓▓▓▓▓▓▒▒  ▓▓▓▓▓▓",
           "       ████     ▓▓  ▓▓     ████                ▓▓▓▓        ▓▓░░  ▓▓▓▓░░  ▓▓",
           "         ██████        ██████                                ▓▓▓▓▒▒  ▓▓▓▓  ",
           "             ████████████                                        ▓▓▓▓      "
        };
        public AdminView() 
        {
            adminMenuOptions = new string[]
            {
                "Pobierz listę rezerwacji",
                "Przewiń listę do dołu v",
                "Przewiń listę do góry ^",      
                "Zarządzaj filmami",
                "Pokaż statystyki",
                "Wróć do menu"
            };
            adminMoviesMenuOptions = new string[]
            {
                "Przewiń listę do dołu v",
                "Przewiń listę do góry ^",
                "Dodaj film",
                "Usuń film",
                "Modyfikuj film",
                "Wyszukaj",
                "Sortuj rosnąco",
                "Sortuj malejąco",
                "Usuń filtry",
                "Wróć"
            };
            adminStatisticsOptions = new string[]
            {
                "Pokaż całkowity dochód",
                "Top 10 najbardziej dochodowych filmów",
                "Top 10 najpopularniejszych filmów",
                "Wróć"
            };
            infoForAddMovie = new string[]
            {
                "[?] Wprowadź dane filmu. Przejdź do kolejnej linii wciskając ENTER. Wyjdź wciskając ESC.",
                "[?] Data powinna być podana w formacie: DD/MM/YYYY HH:MM lub DD.MM.YYYY HH:MM",
                "[?] Cena powinna być podana w formacie: XX.YY lub XX lub XX,YY",
                "[?] Czas trwania powinien być podany w formacie: H:MM",
                "[?] Numer sali powinien być liczbą całkowitą od 1 do 4."
            };
            inputDataForAddMovie = new string[]
            {
                "Tytuł: ",
                "Data: ",
                "Cena: ",
                "Czas trwania: ",
                "Numer sali: "
            };
            inputDataForRemoveMovie = new string[]
            {
                "ID: "
            };
            infoForRemoveMovie = new string[]
            {
                "[?] Podaj ID filmu, który chcesz usunąc. Zatwierdź klawiszem ENTER.",
                "[?] Aby wyjść z wprowadzania danych wciśnij ESC.",
                "[?] ID filmu powinno być liczbą całkowitą"
            };
            infoForModifyMovie = new string[]
            {
                "[?] Podaj ID filmu, który chcesz zmodyfikować. Zatwierdź klawiszem ENTER.",
                "[?] Aby wyjść z wprowadzania danych wciśnij ESC.",
                "[?] Następnie podaj nową datę lub numer sali lub cenę.",
                "[?] Jeśli chcesz zmienić tylko wybrane wartości - pozostałe zostaw puste"
            };
            inputDataForModifyMovie = new string[]{
                "ID: ",
                "Data: ",
                "Cena: ",
                "Numer sali: "
            };
        }
        private void DrawASCIIArt(int WindowWidth, int WindowHeight, string[] art, int row_offset)
        {
            int offest_row = (GetOutputPartHeight() - art.Length) / 2;
            int offset = (GetOutputPartWidth() - (art[0].Length)) / 2;
            for (int i = 0; i < art.Length; i++)
            {
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, i + offest_row+row_offset);//row_offset);
                Console.WriteLine(art[i]);
            }
        }
        private void DrawASCIIArt(int WindowWidth, int WindowHeight, int offset, int table_width, string[] art, int row_offset)
        {
            for (int i = 0; i < art.Length; i++)
            {
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset+table_width+5, i + 2 + row_offset);
                Console.WriteLine(art[i]);
            }
        }

        public string? RemoveMovie()
        {
            return EnterDataForFilterSortAndRemove(infoForRemoveMovie, inputDataForRemoveMovie); 
        }
        
        public void ShowTotalIncome(double income)
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            ClearViewOutputDataPart(WindowWidth, WindowHeight);

            ClearViewInfoPart(WindowWidth, WindowHeight);
            string[] info =
            {
                "[?] Powyżej zaprezentowano całkowity dochód wygenerowany przez kino.",
                "[?] Całkowity dochód jest sumą cen wszystkich sprzedanych biletów."
            };
            SetInfo(info, WindowWidth, WindowHeight);

            string message = "Całkowity dochód:";
            string topTable = $"┌{new string('─', message.Length + 2)}┬{new string('─', income.ToString().Length + 3)}┐";

            int offset = (GetOutputPartWidth() - (topTable.Length)) / 2;
            int offest_row = ((GetOutputPartHeight() - mainMoneyArt.Length - 3) / 2) + 2;

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, offest_row);
            Console.Write(topTable);
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, offest_row+1);
            Console.Write($"│ {message} │ {income}$ │");
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, offest_row+2);
            Console.Write($"└{new string('─', message.Length + 2)}┴{new string('─', income.ToString().Length+3)}┘");

            DrawASCIIArt(WindowWidth, WindowHeight, mainMoneyArt, 4);
        }
        
        public void ShowMostPopularMovies(Dictionary<string, int> movies)
        {
            int longestTitle = movies.Max(item => item.Key.Length);

            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            ClearViewOutputDataPart(WindowWidth, WindowHeight);
            ClearViewInfoPart(WindowWidth, WindowHeight);
            string[] info =
            {
                "[?] Powyżej zaprezentowano 10 najpopularniejszych filmów.",
                "[?] Popularność jest mierzona poprzez ilość zajętych miejsc na dany film."
            };
            SetInfo(info, WindowWidth, WindowHeight);

            string title = "[Tytuł]";
            string reserved_seats = "[Miejsca]";

            string topTable = "┌" + new string('─', longestTitle + 2) + "┬" + new string('─', reserved_seats.Length + 1) + "┐";

            int offset = (GetOutputPartWidth() - (topTable.Length + 5 + topArt[0].Length)) / 2;
            
            int offset_row;

            if (movies.Count>=10)
            {
                offset_row = ((GetOutputPartHeight() - (2 * 10 - 1)) / 2);
            }
            else if (2*movies.Count-1>topArt.Length)
            {
                offset_row = ((GetOutputPartHeight() - (2 * movies.Count - 1)) / 2);
            }
            else
            {
                offset_row = ((GetOutputPartHeight() - topArt.Length) / 2);
            }
            //int a = offset_row;
            //Console.ReadKey();

            // default offsetrow =2 

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, offset_row);
            Console.Write(topTable);

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, offset_row+1);
            Console.Write("│");
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, (longestTitle / 2) - (title.Length / 2) + offset, offset_row + 1);
            Console.Write($" {title.PadRight(longestTitle-5)}│ {reserved_seats}│");

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, offset_row+2);
            Console.Write("├" + new string('─', longestTitle + 2) + "┼" + new string('─', reserved_seats.Length + 1) + "┤");

            int row = offset_row+3; // 5
            int iter = 0;
            foreach (var item in movies)
            {
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row);
                Console.WriteLine($"│ {item.Key.PadRight(longestTitle)} │ {item.Value.ToString().PadLeft(reserved_seats.Length /2 +1)}    │");
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row + 1);
                Console.Write("├" + new string('─', longestTitle + 2) + "┼" + new string('─', reserved_seats.Length + 1) + "┤");
                row += 2;
                iter++;
                if (iter == 10)
                {
                    break;
                }
            }
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row - 1);
            Console.Write("└" + new string('─', longestTitle + 2) + "┴" + new string('─', reserved_seats.Length + 1) + "┘");

            DrawASCIIArt(WindowWidth, WindowHeight, offset, topTable.Length, topArt, offset_row);
        }
        public void ShowMoviesIncome(Dictionary<string, double> income)
        {
            int longestTitle = income.Max(item => item.Key.Length);

            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            ClearViewOutputDataPart(WindowWidth, WindowHeight);

            ClearViewInfoPart(WindowWidth, WindowHeight);
            string[] info =
            {
                "[?] Powyżej zaprezentowano 10 najbardziej dochodowych filmów.",
                "[?] Dochody są zliczane na podstawie sumy cen sprzedanych biletów."
            };
            SetInfo(info, WindowWidth, WindowHeight);

            string title = "[Tytuł]";
            string movie_income = "[Dochód]";

            string topTable = "┌" + new string('─', longestTitle + 2) + "┬" + new string('─', movie_income.Length + 1) + "┐";
            int offset = (GetOutputPartWidth() - (topTable.Length + 5 + moneyArt[0].Length)) / 2;

            int offset_row;

            if (income.Count >= 10)
            {
                offset_row = ((GetOutputPartHeight() - (2 * 10 - 1)) / 2);
            }
            else if (2 * income.Count - 1 > topArt.Length)
            {
                offset_row = ((GetOutputPartHeight() - (2 * income.Count - 1)) / 2);
            }
            else
            {
                offset_row = ((GetOutputPartHeight() - moneyArt.Length) / 2);
            }

            // default offsetrow =2 

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, offset_row);
            Console.Write(topTable);

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, offset_row+1);
            Console.Write("│");
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, (longestTitle / 2 ) - (title.Length/2)+ offset, offset_row+1);
            Console.Write($" {title.PadRight(longestTitle-5)}│ {movie_income}│");

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, offset_row+2);
            Console.Write("├" + new string('─', longestTitle + 2) + "┼" + new string('─', movie_income.Length + 1) + "┤");

            int row = offset_row+3;
            int iter = 0;
            foreach (var item in income)
            {
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row);
                Console.WriteLine($"│ {item.Key.PadRight(longestTitle)} │ {item.Value.ToString().PadLeft(movie_income.Length-2)}  │");
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row+1);
                Console.Write("├" + new string('─', longestTitle + 2)+ "┼" + new string('─', movie_income.Length+1) + "┤");
                row+=2;
                iter++;
                if (iter == 10)
                {
                    break;
                }
            }
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, offset, row - 1);
            Console.Write("└" + new string('─', longestTitle + 2) + "┴" + new string('─', movie_income.Length+ 1) + "┘");

            DrawASCIIArt(WindowWidth, WindowHeight,offset, topTable.Length, moneyArt, offset_row);
        }
        public string?[] ModifyMovie()
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            ClearViewInputPart(WindowWidth, WindowHeight);
            ClearViewInfoPart(WindowWidth, WindowHeight);
            SetInfo(infoForModifyMovie, WindowWidth, WindowHeight);
            SetInput(WindowWidth, WindowHeight, inputDataForModifyMovie);

            string[] newMovieData = new string[inputDataForModifyMovie.Length];

            string pointer = "> ";
            for (int i = 0; i < newMovieData.Length; i++)
            {
                int offset = inputDataForModifyMovie[i].Length + 3;
                SetCursorInInputPart(WindowWidth, WindowHeight, 1, i + 2);
                Console.Write(pointer);
                SetCursorInInputPart(WindowWidth, WindowHeight, offset, i + 2);
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
                                    SetCursorInInputPart(WindowWidth, WindowHeight, inputDataForModifyMovie[i].Length + 3, i + 2);
                                }
                                else
                                {
                                    // Usuń ostatni znak
                                    inputBuilder.Remove(inputBuilder.Length - 1, 1);
                                    Console.Write(" ");
                                    SetCursorInInputPart(WindowWidth, WindowHeight, offset - 1, i + 2);
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
                newMovieData[i] = inputBuilder.ToString();
                SetCursorInInputPart(WindowWidth, WindowHeight, 1, i + 2);
                Console.Write(' ');
            }
            return newMovieData;
        }
        public string?[] AddMovie()
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            ClearViewInputPart(WindowWidth, WindowHeight);
            ClearViewInfoPart(WindowWidth, WindowHeight);
            SetInfo(infoForAddMovie, WindowWidth, WindowHeight);
            SetInput(WindowWidth, WindowHeight, inputDataForAddMovie);
            
            string[] movieData = new string[inputDataForAddMovie.Length];

           // bool isDataEntered = false;
           // while (!isDataEntered)
           // {
           /*     if (Console.WindowWidth != WindowWidth || Console.WindowHeight != WindowHeight)
                {
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;
                    // Tutaj throw exception jeśli rozmiar jest zły w while aby wyrzucać non stop wyjątek jeśli rozmiar jest zły
                    while (WindowWidth < 105 || WindowHeight < 30)
                    {
                        ShowError();
                        WindowWidth = Console.WindowWidth;
                        WindowHeight = Console.WindowHeight;
                    }
                    //Tutaj może trzeba rysować okno od nowa
                }*/
                string pointer = "> ";
                for(int i = 0; i < movieData.Length; i++)
                {
                    int offset = inputDataForAddMovie[i].Length + 3;
                    SetCursorInInputPart(WindowWidth, WindowHeight, 1 , i+2);
                    Console.Write(pointer);
                    SetCursorInInputPart(WindowWidth, WindowHeight, offset, i + 2);
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
                                    SetCursorInInputPart(WindowWidth, WindowHeight, inputDataForAddMovie[i].Length + 3, i + 2);
                                }
                                else
                                {
                                    // Usuń ostatni znak
                                    inputBuilder.Remove(inputBuilder.Length - 1, 1);
                                    Console.Write(" ");
                                    SetCursorInInputPart(WindowWidth, WindowHeight, offset - 1, i + 2);
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
                    movieData[i] = inputBuilder.ToString();
                    SetCursorInInputPart(WindowWidth, WindowHeight, 1, i+2);
                    Console.Write(' ');
                }
            return movieData;
        }

        /*public void ShowFilteredList(List<Movies>)
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            ClearViewOutputDataPart(WindowWidth, WindowHeight);

        }*/
        public void DrawStatiscicArt()
        {
            DrawASCIIArt(Console.WindowWidth, Console.WindowHeight, statisticArt, 2);
        }
        public int RenderStatisticsAdminView()
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;
            //Console.WriteLine(WindowWidth + " " + WindowHeight);
            //ClearViewInfoPart(WindowWidth, WindowHeight);
            ClearViewOptionsPart(WindowWidth, WindowHeight);
            
            // ClearViewOutputDataPart(WindowWidth, WindowHeight);
            //ClearViewInputPart(WindowWidth, WindowHeight);

            // SetInfo(infos, WindowWidth, WindowHeight);
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
                    while (WindowWidth < 130 || WindowHeight < 37)
                    {
                        ShowError();
                        WindowWidth = Console.WindowWidth;
                        WindowHeight = Console.WindowHeight;
                    }
                    Console.Clear();
                    RenderMainFrame(WindowWidth, WindowHeight);
                    //ShowMoviesList(WindowWidth, WindowHeight, movies);
                    SetInfo(infos, WindowWidth, WindowHeight);
                    // Tutaj ponownie uzupełnienie pól
                    Console.CursorVisible = false;
                }
                MakeChoice(adminStatisticsOptions, ref isOptionSelected, ref selectOption, WindowWidth, WindowHeight);
            }
            return selectOption;
        }
        public int RenderMoviesAdminView(List<Movie> movies)
        {
            return RenderMoviesView(infos, movies, adminMoviesMenuOptions);          
        }
        
        
        public int RenderMainAdminView()
        {
            return RenderMainAdminUserView(infos, adminMenuOptions);
        }
    }
}
