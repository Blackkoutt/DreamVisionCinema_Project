using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Control;

namespace GUI.Interfaces
{
    public interface IMovieReservationView
    {
        void Show();
        void Close();
        void BringToFront();
        public Label SeatsLabel { get; }
        event EventHandler Undo;
        event EventHandler BuyTicket;
        public Control.ControlCollection GetControls();
        public void AddSeatControl(Control control);
    }
}
