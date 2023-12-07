using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Interfaces
{
    public interface IMoviesListView
    {
        //event EventHandler DeleteEvent;

        //void SetReservationListBindingSource(List<Reservation> res);
        event EventHandler ShowMovieRoom;
        void SetMoviesListBindingSource(BindingSource moviesList);
        void Show();
        void Close();
        void BringToFront();
        DataGridView dataGridView { get; }
    }
}
