using GUI.Interfaces;

namespace GUI.Views.UserViews
{
    public partial class CancelMessage : Form, ICancelMessage
    {
        // Klasa przechowująca argumenty Eventu
        public class CancelEventArgs : EventArgs
        {
            public string Id { get; }

            public CancelEventArgs(string id)
            {
                Id = id;
            }
        }
        private string Id;
        public CancelMessage(string id, string filmTitle, string date)
        {
            InitializeComponent();
            Id = id;

            // Przypisanie otrzymanych danych do kontrolek widoku
            this.delete_info.Text = $"Czy napewno chcesz anulować rezerwację nr {id} na film:";
            this.filmName.Text = $"\"{filmTitle}\" w dniu {date}?";
            this.Text = $"Anulowanie rezerwacji nr {id} - \"{filmTitle}\" {date}";

            // Delegowane obsługi eventów
            deleteMovieButton.Click += delegate { submitCancel?.Invoke(this, new CancelEventArgs(id)); };
            cancelButton.Click += delegate { cancelCancel?.Invoke(this, EventArgs.Empty); };
            this.FormClosed += delegate { cancelFormClosing?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler submitCancel;
        public event EventHandler cancelCancel;
        public event EventHandler cancelFormClosing;

        public string ID
        {
            get { return Id; }
        }
    }
}
