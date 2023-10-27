using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Exceptions
{
    public class CannotConvertException:Exception
    {
        public CannotConvertException(string message) : base(message) { }
    }
}
