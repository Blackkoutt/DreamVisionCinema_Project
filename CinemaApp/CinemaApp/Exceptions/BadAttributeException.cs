using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Exceptions
{
    public class BadAttributeException:Exception
    {
        public BadAttributeException(string message) : base(message) { }
    }
}
