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
        event EventHandler closeSelectionEvent;
        void StartFailure(string msg);
    }
}
