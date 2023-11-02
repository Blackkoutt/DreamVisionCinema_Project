using CinemaApp.Interfaces.IViews;

namespace CinemaApp.Views
{
    public class LoginView : MainMenuView, ILoginView
    {
        // Trzeba umożliwić użytkownikowi powrót 
        public LoginView() { }
        public void PrintError()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Login lub hasło są niepoprawne. Spróbuj ponownie.");
            Thread.Sleep(2000);
            Console.ResetColor();
        }
        // To powinno być w loginView
        public string[] ShowMissingPasswordFileError(string message)
        {
            string[] new_login_password = new string[2];
            string confirm_password = ".";
            while (new_login_password[1] != confirm_password)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] " + message);
                Console.WriteLine();
                Console.ResetColor();

                Console.Write("Login: ");
                new_login_password[0] = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Hasło: ");
                new_login_password[1] = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Potwierdź hasło: ");
                confirm_password = Console.ReadLine();
                Console.WriteLine();

                if (confirm_password == new_login_password[1])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[V] Login i hasło zostały zmienione i zapisane w pliku.");
                    Console.ResetColor();
                    // Thread.Sleep(1000);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[!] Podane hasła są różne. Spróbuj ponownie.");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                }
            }

            Console.ResetColor();

            return new_login_password;
        }

        public string?[] RenderLoginView()
        {
            //Console.SetWindowSize(120, 35);
            // Tutaj może setWindowSize
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            string message = "[?] Wpisz login a następnie hasło. Zmień pole po wypełnieniu wciskając ENTER.";
            Console.Clear();
            DrawTitle(WindowWidth, WindowHeight);
            MakeMenuFrame(WindowWidth, WindowHeight);
            MakeInfo(WindowWidth, WindowHeight, message); // to trzeba nadpisać raczej
            // Make info

            bool isLoginAndPasswordEntered = false;
            FillLoginFrame(WindowWidth, WindowHeight);
            string[] login_password = new string[2];
            ConsoleKeyInfo key;

            while (!isLoginAndPasswordEntered) 
            {
                if (Console.WindowWidth != WindowWidth || Console.WindowHeight != WindowHeight)
                {
                    WindowWidth = Console.WindowWidth;
                    WindowHeight = Console.WindowHeight;
                    // Tutaj throw exception jeśli rozmiar jest zły w while aby wyrzucać non stop wyjątek jeśli rozmiar jest zły
                    while (WindowWidth < 130 || WindowHeight < 35)
                    {
                        ShowError();
                        WindowWidth = Console.WindowWidth;
                        WindowHeight = Console.WindowHeight;
                    }
                    Console.Clear();
                    DrawTitle(WindowWidth, WindowHeight);
                    MakeMenuFrame(WindowWidth, WindowHeight);
                    FillLoginFrame(WindowWidth, WindowHeight);
                    MakeInfo(WindowWidth, WindowHeight, message);
                }
               /* for(int i = 0; i < login_password.Length; i++)
                {
                    StringBuilder inputBuilder = new StringBuilder();
                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false);

                        if (keyInfo.Key == ConsoleKey.Escape)
                        {
                            return null;
                            //break;
                        }
                        else if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            // Użytkownik nacisnął Enter, więc wprowadzenie danych zostaje zakończone
                            break;
                        }
                        else
                        {
                            inputBuilder.Append(keyInfo.KeyChar);
                        }
                    }
                }*/
                SetPointer(WindowWidth / 2 - 16, WindowHeight / 2 - 1);
                Console.SetCursorPosition(WindowWidth / 2 - 7, WindowHeight / 2 - 1);
                login_password[0] = Console.ReadLine();
                RemovePointer(WindowWidth / 2 - 16, WindowHeight / 2 - 1);

                SetPointer(WindowWidth / 2 - 16, WindowHeight / 2 + 1);
                Console.SetCursorPosition(WindowWidth / 2 - 7, WindowHeight / 2 + 1);
                login_password[1] = Console.ReadLine();
                RemovePointer(WindowWidth / 2 - 16, WindowHeight / 2 + 1);

                Console.CursorVisible = false;
                SetPointer(WindowWidth / 2 - 7, WindowHeight / 2 + 3);
                Console.SetCursorPosition(WindowWidth / 2 - 5, WindowHeight / 2 + 3);

                Console.BackgroundColor= ConsoleColor.White;
                Console.ForegroundColor= ConsoleColor.Black;
                Console.Write("Zaloguj się");
                Console.ResetColor();

                key = Console.ReadKey();
                Console.SetCursorPosition(WindowWidth / 2 + 6, WindowHeight / 2 + 3);
                Console.Write(" ");
                while (key.Key != ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(WindowWidth / 2 + 6, WindowHeight / 2 + 3);
                    key = Console.ReadKey();
                    Console.SetCursorPosition(WindowWidth / 2 + 6, WindowHeight / 2 + 3);
                    Console.Write(" ");
                }
                break;   
            }
            return login_password;  // Zwrócenie wyniku do kontrolera
        }
        private void FillLoginFrame(int WindowWidth, int WindowHeight)
        {
            Console.SetCursorPosition(WindowWidth / 2 -14 , WindowHeight / 2 -1);
            Console.Write("Login: ");
            Console.SetCursorPosition(WindowWidth / 2 -14 , WindowHeight / 2 + 1);
            Console.Write("Hasło: ");

            Console.SetCursorPosition(WindowWidth / 2 - 5, WindowHeight / 2 + 3);
            Console.Write("Zaloguj się");
        }
        
    }
}
