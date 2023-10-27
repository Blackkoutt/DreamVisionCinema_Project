using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Model
{
    public class Seat
    {
        private int number;
        private int Row;
        private bool isAvailable;
        public Seat(int number, int Row) {
            this.number = number;
            this.Row = Row; 
            isAvailable = true;
        }
        public bool IsAvailable
        {
            get { return isAvailable; } 
            set { isAvailable = value; }
        }
        public int Number
        {
            get { return number; }
        }
        public override string ToString()
        {
            return $"{number}";
        }
    }
}
