using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Exceptions
{
    public class ListIsEmptyException :Exception
    {
        public ListIsEmptyException(string message) : base(message) { }
    }
}
