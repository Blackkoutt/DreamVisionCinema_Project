namespace GUI.Interfaces
{
    public interface IAddMovieView
    {
        event EventHandler submitAddForm;
        event EventHandler addFormClosing;
        void Show();
        void Close();
        void BringToFront();
        public RichTextBox TitleValue { get; }
        public DateTimePicker DateValue { get; }
        public NumericUpDown PriceValue { get; }
        public DateTimePicker DurationValue { get; }
        public NumericUpDown RoomNumberValue { get; }
    }
}
