using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Model
{
    public class Login
    {
        // login
        // haslo
        // Bez sensu jest trzymać login i hasło w pamięci ...

        // Pole bool LoginSuccesful

        // Metoda do sprawdzenia podanego hasła i loginu prawdopodobnie statyczna
        public static bool SignIn(string login, string password) 
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Konwertuj wprowadzone hasło na tablicę bajtów
                byte[] enteredLoginBytes = Encoding.UTF8.GetBytes(login);
                byte[] enteredPasswordBytes = Encoding.UTF8.GetBytes(password);

                // Oblicz hasz wprowadzonego hasła
                byte[] enteredHashBytesLogin = sha256.ComputeHash(enteredLoginBytes);
                byte[] enteredHashBytesPassword = sha256.ComputeHash(enteredPasswordBytes);

                // Konwertuj hasz na ciąg szesnastkowy
                string enteredHashStringLogin = BitConverter.ToString(enteredHashBytesLogin).Replace("-", "").ToLower();
                string enteredHashStringPassword = BitConverter.ToString(enteredHashBytesPassword).Replace("-", "").ToLower();

                StreamReader sr = new StreamReader("password.txt"); //Exception
                string hashedLogin  = sr.ReadLine();
                string hashedPassword = sr.ReadLine();
                sr.Close();
                if (enteredHashStringLogin ==  hashedLogin && enteredHashStringPassword == hashedPassword)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void HashPassword() 
        {
            string login = "admin";
            string password = "admin123";
            using (SHA256 sha256 = SHA256.Create())
            {
                // Konwertowanie hasła na tablicę bajtów
                byte[] loginBytes = Encoding.UTF8.GetBytes(login);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Obliczanie hasza
                byte[] hashBytesLogin = sha256.ComputeHash(loginBytes);
                byte[] hashBytesPassword = sha256.ComputeHash(passwordBytes);

                // Konwertowanie hasza na ciąg szesnastkowy
                string hashStringLogin = BitConverter.ToString(hashBytesLogin).Replace("-", "").ToLower();
                string hashStringPassword = BitConverter.ToString(hashBytesPassword).Replace("-", "").ToLower();


                // Zapisywanie hasza do pliku
                StreamWriter sw = new StreamWriter("password.txt");
                sw.WriteLine(hashStringLogin);
                sw.WriteLine(hashStringPassword);
                sw.Close();
            }
        }

    }
}
