using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Exceptions
{
    public class CannotFindMatchingMovieException : Exception
    {
        public CannotFindMatchingMovieException(string message) : base(message) { }
    }
}
