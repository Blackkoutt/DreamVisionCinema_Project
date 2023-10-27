using CinemaApp.Enums;
using CinemaApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Extensions
{
    public class Validation
    {
        //Dokończyć pisać 
        public static void IsDurationCorrect(string duration)
        {
            if (!duration.Contains(":"))
            {
                throw new IncorrectParametrException("Czas trwania powinien być podany w formacie: H:MM lub HH:MM");
            }

            for (int i = 0; i < duration.Length; i++)
            {
                if (duration[i] != ':' && !char.IsDigit(duration[i]))
                {
                    throw new IncorrectParametrException("Czas trwania powinien być podany w formacie: H:MM lub HH:MM.");
                }
            }
        }
        public static bool IsValidRoomNumber(int? number)
        {
            if(number>0 || number <= (int)Rooms.COUNT)
            {
                return true;
            }
            return false;   
        }
    }
}
