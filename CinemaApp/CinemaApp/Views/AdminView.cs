using CinemaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Views
{
    public class AdminView : MainView
    {
        private readonly string[] adminMenuOptions;
        private readonly string[] adminMoviesMenuOptions;
        private readonly string[] infos;
        private readonly string[] inputDataForAddMovie;
        private readonly string[] inputDataForModifyMovie;
        private readonly string[] infoForAddMovie;
        private readonly string[] infoForRemoveMovie;
        private readonly string[] inputDataForRemoveMovie;
        private readonly string[] infoForModifyMovie; 
        private readonly string[] adminStatisticsOptions;
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
        public AdminView() 
        {
            infos = new string[] {
                "[?] Poruszaj się za pomocą strzałek. Aby wybrać opcję wciśnij ENTER.",
                "[!] Wcisnij dowolny przycisk aby odświeżyć konsolę."
            };
            adminMenuOptions = new string[]
            {
                "Zarządzaj filmami",
                "Pobierz listę rezerwacji",
                "Przewiń listę do dołu v",
                "Przewiń listę do góry ^",
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
                "[?] Wprowadź dane dotyczące filmu. Przejdź do kolejnej linii wciskając ENTER.",
                "[?] Data powinna być podana w formacie: DD/MM/YYYY HH:MM",
                "[?] Cena powinna być podana w formacie: XX.YY",
                "[?] Czas trwania powinien być podany w formacie: H:MM"
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
                "[?] ID filmu powinno być liczbą całkowitą"
            };
            infoForModifyMovie = new string[]
            {
                "[?] Podaj ID filmu, który chcesz zmodyfikować. Zatwierdź klawiszem ENTER.",
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
        private void DrawASCIIArt(int WindowWidth, int WindowHeight, string[] art)
        {
            for (int i = 0; i < art.Length; i++)
            {
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, 41, i + 4);
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
            string message = "Całkowity dochód: ";
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, 2, 2);
            Console.Write(message);
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, message.Length+2, 2);
            Console.Write(income);
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

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, 2, 2);
            Console.Write("┌" + new string('─', longestTitle + 2) + "┬" + new string('─', reserved_seats.Length + 1) + "┐");

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, 2, 3);
            Console.Write("│");
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, (longestTitle / 2) - (title.Length / 2) + 2, 3);
            Console.Write($" {title.PadRight(longestTitle-5)}│ {reserved_seats}│");

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, 2, 4);
            Console.Write("├" + new string('─', longestTitle + 2) + "┼" + new string('─', reserved_seats.Length + 1) + "┤");

            int row = 5;
            int iter = 0;
            foreach (var item in movies)
            {
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, 2, row);
                Console.WriteLine($"│ {item.Key.PadRight(longestTitle)} │ {item.Value.ToString().PadLeft(reserved_seats.Length /2 +1)}    │");
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, 2, row + 1);
                Console.Write("├" + new string('─', longestTitle + 2) + "┼" + new string('─', reserved_seats.Length + 1) + "┤");
                row += 2;
                iter++;
                if (iter == 10)
                {
                    break;
                }
            }
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, 2, row - 1);
            Console.Write("└" + new string('─', longestTitle + 2) + "┴" + new string('─', reserved_seats.Length + 1) + "┘");

            DrawASCIIArt(WindowWidth, WindowHeight, topArt);
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

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, 2, 2);
            Console.Write("┌" + new string('─', longestTitle + 2) + "┬" + new string('─', movie_income.Length + 1) + "┐");

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, 2, 3);
            Console.Write("│");
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, (longestTitle / 2 ) - (title.Length/2)+ 2, 3);
            Console.Write($" {title.PadRight(longestTitle-5)}│ {movie_income}│");

            SetCursorInDataOutputPart(WindowWidth, WindowHeight, 2, 4);
            Console.Write("├" + new string('─', longestTitle + 2) + "┼" + new string('─', movie_income.Length + 1) + "┤");

            int row = 5;
            int iter = 0;
            foreach (var item in income)
            {
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, 2, row);
                Console.WriteLine($"│ {item.Key.PadRight(longestTitle)} │ {item.Value.ToString().PadLeft(movie_income.Length-2)}  │");
                SetCursorInDataOutputPart(WindowWidth, WindowHeight, 2, row+1);
                Console.Write("├" + new string('─', longestTitle + 2)+ "┼" + new string('─', movie_income.Length+1) + "┤");
                row+=2;
                iter++;
                if (iter == 10)
                {
                    break;
                }
            }
            SetCursorInDataOutputPart(WindowWidth, WindowHeight, 2, row - 1);
            Console.Write("└" + new string('─', longestTitle + 2) + "┴" + new string('─', movie_income.Length+ 1) + "┘");

            DrawASCIIArt(WindowWidth, WindowHeight, moneyArt);
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
