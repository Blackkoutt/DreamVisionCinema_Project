using CinemaApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Extensions
{
    public class Conversions
    {
        public static int TryParseToInt(string value, string msg)
        {
            try
            {
                return int.Parse(value);
            }
            catch
            {
                throw new CannotConvertException(msg);
            }
        }
        public static DateTime TryParseToDateTime(string value, string msg)
        {
            try
            {
                string format = "dd/MM/yyyy HH:mm";
                return DateTime.ParseExact(value, format, null);
            }
            catch
            {
                throw new CannotConvertException(msg);
            }
        }
        public static double TryParseToDouble(string value, string msg)
        {
            value = value.Replace(".", ",");
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                throw new CannotConvertException(msg);
            }
        }
    }
}
