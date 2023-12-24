using GUI.Interfaces;

namespace GUI.Views.AdminViews
{
    public partial class AddMovieForm : Form, IAddMovieView
    {
        public AddMovieForm()
        {
            InitializeComponent();
            this.durationTextView.Text = "01:00";
            submitAddButton.Click += delegate { submitAddForm?.Invoke(this, EventArgs.Empty); };
            this.FormClosed += delegate { addFormClosing?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler submitAddForm;
        public event EventHandler addFormClosing;

        public RichTextBox TitleValue
        {
            get { return this.titleTextView; }
        }

        public DateTimePicker DateValue
        {
            get { return this.dateValue; }
        }

        public NumericUpDown PriceValue
        {
            get { return this.priceValue; }
        }

        public DateTimePicker DurationValue
        {
            get { return this.durationTextView; }
        }

        public NumericUpDown RoomNumberValue
        {
            get { return this.roomTextView; }
        }

        public Control.ControlCollection GetControls()
        {
            return this.Controls;
        }
    }
}
