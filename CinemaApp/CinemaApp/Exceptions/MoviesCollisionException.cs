using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Exceptions
{
    public class MoviesCollisionException:Exception
    {
        public MoviesCollisionException(string message) : base(message) { }
    }
}
