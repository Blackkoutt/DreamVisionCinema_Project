using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Interfaces
{
    public interface IMainUserForm
    {
        // Zadarzenia do obsługi nowych okien
        event EventHandler ShowReservationsView;
        event EventHandler ShowMoviesView;
        event EventHandler LoadDefault;
        event EventHandler GoBack;

        Panel PanelContainer { get; }
        public Label lblTitle { get; }
        public PictureBox MainLogo { get; }
        public IconPictureBox topIcon { get; }
        public Panel ButtonBorderLeft { get; }
        public PictureBox MainBigLogo { get; }
        void Show();
        void Close();
        void BringToFront();

        void DisableButton();
    }
}
