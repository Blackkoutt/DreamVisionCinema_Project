namespace CinemaApp.Interfaces.IViews
{
    public interface ILoginView
    {
        void PrintError();
        string?[] RenderLoginView();
        string[] ShowMissingPasswordFileError(string message);
    }
}