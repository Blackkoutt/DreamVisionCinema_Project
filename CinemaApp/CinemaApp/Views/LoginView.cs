using CinemaApp.Interfaces.IViews;
using System.Text;

namespace CinemaApp.Views
{
    public class LoginView : MainMenuView, ILoginView
    {
        public LoginView() { }


        // Metoda wyświetlająca komunikat błędu logowania
        public void PrintError()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Login lub hasło są niepoprawne. Spróbuj ponownie.");
            Thread.Sleep(1100);
            Console.ResetColor();
        }


        // Metoda wyświetlająca błąd braku pliku z hasłami i pobierająca od użytkownika nowy login i hasło
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
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[!] Podane hasła są różne. Spróbuj ponownie.");
                    Console.ResetColor();
                    Thread.Sleep(1100);
                }
            }

            Console.ResetColor();

            return new_login_password;
        }


        // Metoda renderująca widok logowania
        public string?[] RenderLoginView()
        {
            int WindowWidth = Console.WindowWidth;
            int WindowHeight = Console.WindowHeight;

            string message = "[?] Wpisz login i hasło. Zmień pole wciskając ENTER. Wróć wciskając ESC.";
            Console.Clear();
            DrawTitle(WindowWidth, WindowHeight);
            MakeMenuFrame(WindowWidth, WindowHeight);
            MakeInfo(WindowWidth, WindowHeight, message);

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
                SetPointer(WindowWidth / 2 - 16, WindowHeight / 2 - 1);
                login_password[0] = InputBuilder(WindowWidth / 2 - 7, WindowHeight / 2 - 1);
                if (login_password[0] == null)
                {
                    return null;
                }
                RemovePointer(WindowWidth / 2 - 16, WindowHeight / 2 - 1);

                SetPointer(WindowWidth / 2 - 16, WindowHeight / 2 + 1);
                login_password[1] = InputBuilder(WindowWidth / 2 - 7, WindowHeight / 2 + 1);
                if (login_password[1] == null)
                {
                    return null;
                }
                RemovePointer(WindowWidth / 2 - 16, WindowHeight / 2 + 1);

                Console.CursorVisible = false;
                SetPointer(WindowWidth / 2 - 7, WindowHeight / 2 + 3);
                Console.SetCursorPosition(WindowWidth / 2 - 5, WindowHeight / 2 + 3);

                Console.BackgroundColor= ConsoleColor.White;
                Console.ForegroundColor= ConsoleColor.Black;
                Console.Write("Zaloguj się");
                Console.ResetColor();

                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    return null;
                }
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
            return login_password;
        }


        // Metoda służąca do wprowadzania danych w forumularzu logowania
        private string? InputBuilder(int x, int y)
        {
            Console.SetCursorPosition(x,y);
            int offset = x;
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
                                Console.SetCursorPosition(x, y);
                            }
                            else
                            {
                                inputBuilder.Remove(inputBuilder.Length - 1, 1);
                                Console.Write(" ");
                                Console.SetCursorPosition(offset - 1, y);
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


        // Metoda służąca do wyświetlenia formularza logowania
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