using CinemaApp.Exceptions;
using CinemaApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Model
{
    public class Ticket
    {
        private int id;
        private int price;
        private string[] ticketTemplate =
        {
            @"              ╔════════════════════════════════════════════════════════════════════════════════════════════════╗
              ║------------------------------------------------------------------------------------------------║
              ║[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]║
              ║------------------------------------------------------------------------------------------------║
              ║ ____                        __     ___     _                ____ _                             ║
              ║|  _ \ _ __ ___  __ _ _ __ __\ \   / (_)___(_) ___  _ __    / ___(_)_ __   ___ _ __ ___   __ _  ║
              ║| | | | '__/ _ \/ _` | '_ ` _ \ \ / /| / __| |/ _ \| '_ \  | |   | | '_ \ / _ \ '_ ` _ \ / _` | ║
              ║| |_| | | |  __/ (_| | | | | | \ V / | \__ \ | (_) | | | | | |___| | | | |  __/ | | | | | (_| | ║
              ║|____/|_|  \___|\__,_|_| |_| |_|\_/  |_|___/_|\___/|_| |_|  \____|_|_| |_|\___|_| |_| |_|\__,_| ║
              ║------------------------------------------------------------------------------------------------║
              ║[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]║
              ║------------------------------------------------------------------------------------------------║
              ║            ticket id:             │                                                            ║
              ║                {0,-19}│                              ▓▒▓                           ║
              ║    │║█║││║█│█║║█│║█││█║│█║││█║    │                           ▒▓▒                              ║
              ║    │║█║││║█│█║║█│║█││█║│█║││█║    │                        ▓▒▓                                 ║
              ║                                   │                     ▓▒                                     ║
              ║      date:           duration:    │                    ▓░▓░▓░▓░▓░▓░▓░▓░                        ║
              ║ {1,-1}       {2,-1}      │                    ████████████████                        ║
              ║                                   │                    ████████████████                        ║
              ║  room: {3,-27}│                    ████████████████                        ║
              ║                                   │                    ████████████████                        ║
              ║ seats: {4,-27}│                                                            ║
              ║                                   │ Title: {6,-52}║
              ║ price: {5,-27}│                                                            ║
              ║                                   │                                                            ║
              ╚════════════════════════════════════════════════════════════════════════════════════════════════╝"
        };
        public Ticket(int id) 
        {
            this.id = id;   
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public double CalculatePrice(double price, int seatsCount)
        {
            return price * seatsCount;
        }
        // Wywoływana podczas modyfikacji biletu i przy tworzeniu biletu
        public void SaveTicketToFile(Movie movie, string seats)
        {
            string title = movie.Title.Replace(" ", "_");
            string fileName = id + "_" + title + ".txt"; 
            StreamWriter sw = new StreamWriter(fileName);
            double price = Math.Round(CalculatePrice(movie.Price, seats.Count(x => x == ',') + 1), 2);
            string finalPrice = "$"+ price.ToString();
            string duration = movie.Duration + "h";
            string date = movie.Date.ToString("dd/MM/yyyy HH:mm");
            string room = movie.Room.Number.ToString();

            string formattedTicket = string.Format(
                string.Join(Environment.NewLine, ticketTemplate),
                id,
                date,
                duration,
                room,
                seats,
                finalPrice,
                movie.Title
            );
            sw.WriteLine( formattedTicket );
            sw.Close();
        }
        // Show Ticket - uzupełnienie Ticketu danymi zwrócenie do View
        
        // Destroy Ticket - zniszczenie biletu po usunięciu danej rezeracji
        public void DestroyTicket(string title)
        {
            title = title.Replace(" ", "_");
            string fileName = id + "_" + title+".txt";
            try
            {
                File.Delete(fileName);
            }
            catch
            {
                // Tutaj może być jeszcze problem z tym że program nie może usunąc pliku
                throw new CannotDestroyTicketException($"Nie udało się usunąć pliku z biletem o nazwie {fileName}");
            }
        }

        // Tests
        public void RenderTemplate()
        {
            string title = "Kosmici w mojej szkole sdhhfgdfgsdgfhfghshgfhkdfhjjj";
            string date = "12/10/2023 10:00";
            string duration = "1:30";
            string room = "Room 4";
            string seats = "1, 2, 3, 2, 3, 2, 3, 2";
            string price = "$30.00";
            string ticketId = "1234";

            // Wstaw zmienne do odpowiednich miejsc w szablonie
            string formattedTicket = string.Format(
                string.Join(Environment.NewLine, ticketTemplate),
                ticketId,
                date,
                duration,
                room,
                seats,
                price,
                title
            );
            //StreamWriter sw = new StreamWriter("testtemplate.txt");
            //sw.WriteLine( formattedTicket );
            //sw.Close();
            Console.WriteLine(formattedTicket);
        }
        // Templatka ticketu
        

        // Obliczenie ceny ticketu

        // Zapis ticketu do pliku


        // Modyfikacja ticketu w pliku

        // Usunięcie pliku z ticketem po usunięciu filmu na który była rezerwacja
    }
}
