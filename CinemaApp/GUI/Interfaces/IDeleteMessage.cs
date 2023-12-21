namespace GUI.Interfaces
{
    public interface IDeleteMessage
    {
        void Show();
        void Close();
        void BringToFront();
        public string ID { get; }

        event EventHandler submitDelete;
        event EventHandler cancelDelete;
        event EventHandler deleteFormClosing;
    }
}
