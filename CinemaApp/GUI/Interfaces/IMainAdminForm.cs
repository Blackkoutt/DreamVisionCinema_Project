using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Interfaces
{
    public interface IMainAdminForm
    {
        event EventHandler ShowAdminReservationsView;
        event EventHandler ShowAdminMoviesView;
        event EventHandler ShowAdminStatisticsView;
        event EventHandler AdminLoadDefault;
        event EventHandler goBackEvent;
        event EventHandler closeEvent;
        void Show();
        void Close();
        void BringToFront();

        public PictureBox MainBigLogo { get; }
        Panel PanelContainer { get; }
    }
}
