using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Interfaces
{
    public interface IEditMovieView
    {
        event EventHandler submitEditForm;
        event EventHandler editFormClosing;
        void Show();
        void Close();
        void BringToFront();
        public DateTimePicker DateValueEdit { get; }
        public NumericUpDown PriceValueEdit { get; }
        public NumericUpDown RoomNumberValueEdit { get; }

        public string OldPrice { get; }
        public string OldDate { get; }
        public string OldRoomNumber { get; }
        public string ID { get; }
    }
}
