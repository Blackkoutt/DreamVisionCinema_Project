using CinemaApp.Interfaces.IViews;

namespace CinemaApp.Views
{
    public class MainMenuView: MainView, IMainMenuView
    {
        protected readonly string[] menuOptions;
        private readonly string[] title = 
        {
            @"  _____                        __     _ _     _                ____ _                            
               |  _ \ _ __ ___  __ _ _ __ __\ \   / (_)___(_) ___  _ __    / ___(_)_ __   ___ _ __ ___   __ _ 
               | | | | '__/ _ \/ _` | '_ ` _ \ \ / /| / __| |/ _ \| '_ \  | |   | | '_ \ / _ \ '_ ` _ \ / _` |
               | |_| | | |  __/ (_| | | | | | \ V / | \__ \ | (_) | | | | | |___| | | | |  __/ | | | | | (_| |
               |____/|_|  \___|\__,_|_| |_| |_|\_/  |_|___/_|\___/|_| |_|  \____|_|_| |_|\___|_| |_| |_|\__,_|"
        };
        public MainMenuView()
        {
            menuOptions = new string[]
            {
                "Zaloguj się jako Administrator",
                "Zaloguj się jako Użytkownik",
                "Opcje",
                "Wyjdź"
            };
            Console.SetWindowSize(140, 40);
        }
        protected void DrawTitle(int WindowWidth, int WindowHeight)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string[] temp = title[0].Split('\n');
            int title_width = temp[0].Trim().Length;
            for(int i = 0; i < temp.Length; i++)
            {
                Console.SetCursorPosition(WindowWidth / 2 - ((title_width + 20) / 2), (WindowHeight / 8) + i);
                Console.WriteLine(temp[i].Trim());
            }
            Console.ResetColor();
        }
        
        protected void MakeMenuFrame(int WindowWidth, int WindowHeight)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            int longest_option = LongestMenuOption();
            Console.SetCursorPosition(WindowWidth / 2 - (longest_option / 2) - 3, WindowHeight / 2 - (menuOptions.Length / 2)-2);
            Console.Write("╔");
            for(int i = 0; i< longest_option + 8; i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            for(int i=0; i < (menuOptions.Length * 2) + 1; i++)
            {
                Console.SetCursorPosition(WindowWidth / 2 - (longest_option / 2) - 3, WindowHeight / 2 - (menuOptions.Length / 2) + i - 1);
                Console.Write("║");
                Console.SetCursorPosition(WindowWidth / 2 + (longest_option / 2) + 6, WindowHeight / 2 - (menuOptions.Length / 2) + i - 1);
                Console.Write("║");
            }
            Console.SetCursorPosition(WindowWidth / 2 - (longest_option / 2) - 3, WindowHeight / 2 + (menuOptions.Length * 2)-2);
            Console.Write("╚");
            for (int i = 0; i < longest_option+8; i++)
            {
                Console.Write("═");
            }
            Console.Write("╝");
            Console.ResetColor();
        }
        private int LongestMenuOption()
        {
            return menuOptions.Max(s => s.Length);
        }
        protected void MakeInfo(int WindowWidth, int WindowHeight, string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            int InfoWidth = 84;
            int InfoHeight = 5;
            Console.SetCursorPosition(WindowWidth / 2 - (InfoWidth / 2), WindowHeight / 2 + menuOptions.Length * 2);
            Console.Write("╔");
            for (int i = 0; i < InfoWidth+1; i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            for (int i = 0; i < InfoHeight; i++)
            {
                Console.SetCursorPosition(WindowWidth / 2 - (InfoWidth / 2), WindowHeight / 2 + (menuOptions.Length * 2) + 1 +i);
                Console.Write("║");
                Console.SetCursorPosition(WindowWidth / 2 + (InfoWidth / 2) + 2, WindowHeight / 2 + (menuOptions.Length * 2) + 1 + i);
                Console.Write("║");
            }
            Console.SetCursorPosition(WindowWidth / 2 - (InfoWidth / 2), WindowHeight / 2 + (menuOptions.Length * 2) + 1 + InfoHeight);
            Console.Write("╚");
            for (int i = 0; i < InfoWidth+1; i++)
            {
                Console.Write("═");
            }
            Console.Write("╝");

            Console.SetCursorPosition(WindowWidth / 2 - (InfoWidth / 2) + 2, WindowHeight / 2 + (menuOptions.Length * 2) + 2);
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(WindowWidth / 2 - (InfoWidth / 2) + 2, WindowHeight / 2 + (menuOptions.Length * 2) + 3);
            Console.WriteLine("[!] Po zmianie rozmiaru okna należy wcisnąć dowolny przycisk aby odświeżyć konsolę.");

            Console.ResetColor();
        }
        public int RenderMainMenu()
        {
            //Console.SetWindowSize(140, 40);
            //Console.OutputEncoding = Encoding.Unicode;
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            string message = "[?] Poruszaj się za pomocą strzałek. Aby wybrać opcję wystarczy wcisnąć ENTER.";

            Console.Clear();
            DrawTitle(WindowWidth, WindowHeight);
            MakeMenuFrame(WindowWidth, WindowHeight);
            MakeInfo(WindowWidth, WindowHeight, message);
            Console.CursorVisible = false;
            
            bool isOptionSelected = false;
            //string pointer = BLACK_FOREGROUND+ WHITE_BACKGROUND + ">";
            string pointer = ">";
            int selectOption = 1;
            ConsoleKeyInfo key;

            while (!isOptionSelected)
            {
                if(Console.WindowWidth != WindowWidth || Console.WindowHeight!= WindowHeight)
                {
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;
                    // Tutaj throw exception jeśli rozmiar jest zły w while aby wyrzucać non stop wyjątek jeśli rozmiar jest zły
                    while(WindowWidth<130 || WindowHeight < 40)
                    {
                        ShowError();
                        WindowWidth = Console.WindowWidth;
                        WindowHeight = Console.WindowHeight;
                    }
                    Console.Clear();
                    DrawTitle(WindowWidth, WindowHeight);
                    MakeMenuFrame(WindowWidth, WindowHeight);
                    MakeInfo(WindowWidth, WindowHeight, message);
                    Console.CursorVisible = false;
                }
                Console.ResetColor();
                for(int i = 0; i < menuOptions.Length; i++)
                {
                    Console.SetCursorPosition(WindowWidth / 2 - (menuOptions[i].Length/2), WindowHeight / 2 - (menuOptions.Length/2) + i*2);
                    if(selectOption == i + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"{pointer} {menuOptions[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {menuOptions[i]}");
                    }
                }

                key = Console.ReadKey();
                Console.SetCursorPosition(0, WindowHeight / 2 + (menuOptions.Length / 2)+3);
                Console.Write(" ");
                switch (key.Key) 
                {
                    case ConsoleKey.UpArrow:
                        selectOption = selectOption == 1 ? menuOptions.Length : selectOption - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selectOption = selectOption == menuOptions.Length ? 1 : selectOption + 1;
                        break;

                    case ConsoleKey.Enter:
                        isOptionSelected = true;
                        break;
                }
            }
            return selectOption;
        }
    }
}
