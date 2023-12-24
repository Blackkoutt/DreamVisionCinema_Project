using FontAwesome.Sharp;

namespace GUI.Interfaces
{
    public interface IMainUserForm
    {
        event EventHandler ShowReservationsView;
        event EventHandler ShowMoviesView;
        event EventHandler LoadDefault;
        event EventHandler GoBack;
        event EventHandler MainUserFormCloseEvent;
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
