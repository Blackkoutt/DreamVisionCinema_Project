using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Interfaces
{
    public interface IAddMovieView
    {
        event EventHandler submitAddForm;
        void Show();
        void Close();
        void BringToFront();
        public RichTextBox TitleValue { get; }
        public DateTimePicker DateValue { get; }
        public NumericUpDown PriceValue { get; }
        public DateTimePicker DurationValue { get; }
        public NumericUpDown RoomNumberValue { get; }
    }
}
