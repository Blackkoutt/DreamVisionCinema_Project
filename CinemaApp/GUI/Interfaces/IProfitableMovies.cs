namespace GUI.Interfaces
{
    public interface IProfitableMovies
    {
        void Show();
        void Close();
        void BringToFront();
        event EventHandler BackFromProfitableMovies;
    }
}
