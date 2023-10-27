using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Exceptions
{
    public class ReservationListIsEmptyException:Exception
    {
        public ReservationListIsEmptyException(string message) : base(message) { }
    }
}
