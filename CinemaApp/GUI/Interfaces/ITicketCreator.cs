namespace GUI.Interfaces
{
    public interface ITicketCreator
    {
        public Control.ControlCollection GetControls();
        void Hide();
        void Close();
        void SetBackColor();
    }
}
