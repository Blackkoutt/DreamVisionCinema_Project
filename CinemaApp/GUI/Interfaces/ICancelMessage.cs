namespace GUI.Interfaces
{
    public interface ICancelMessage
    {
        void Show();
        void Close();
        void BringToFront();
        public string ID { get; }
        event EventHandler submitCancel;
        event EventHandler cancelCancel;
        event EventHandler cancelFormClosing;
    }
}
