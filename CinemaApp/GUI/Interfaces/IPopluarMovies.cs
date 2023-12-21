namespace GUI.Interfaces
{
    public interface IPopluarMovies
    {
        void Show();
        void Close();
        void BringToFront();
        event EventHandler BackFromPupularMovies;
    }
}
