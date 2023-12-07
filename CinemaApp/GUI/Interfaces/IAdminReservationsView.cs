using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Interfaces
{
    public interface IAdminReservationsView
    {
        void Show();
        void Close();
        void BringToFront();
        void SetReservationListBindingSource(BindingSource reservationList);
    }
}
