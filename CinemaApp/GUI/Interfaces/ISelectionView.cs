namespace GUI.Interfaces
{
    public interface ISelectionView
    {
        void Show();
        void Close();
        void Hide();
        void BringToFront();
        event EventHandler ShowAuthenticationView;
        event EventHandler ShowMainUserView;
        void StartFailure(string msg);
    }
}
