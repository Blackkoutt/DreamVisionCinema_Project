namespace GUI.Interfaces
{
    public interface IAuthenticationView
    {
        void Show();
        void Close();
        void BringToFront();
        void Hide();
        public TextBox Login { get; }
        public TextBox Password { get; }
        event EventHandler SignIn;
    }
}
