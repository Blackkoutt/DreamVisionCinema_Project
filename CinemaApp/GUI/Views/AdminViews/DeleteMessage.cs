using GUI.Interfaces;

namespace GUI.Views.AdminViews
{
    public partial class DeleteMessage : Form, IDeleteMessage
    {
        // Klasa przechowująca argumenty eventu
        public class DeleteEventArgs : EventArgs
        {
            public string Id { get; }

            public DeleteEventArgs(string id)
            {
                Id = id;
            }
        }
        private string Id;
        public DeleteMessage(string filmTitle, string id)
        {
            InitializeComponent();
            Id = id;

            // Przypisanie odpowiednich wartości kontrolkom
            this.filmName.Text = $"\"{filmTitle}\"?";
            this.Text = $"Usuwanie filmu - \"{filmTitle}\"";
            deleteMovieButton.Click += delegate { submitDelete?.Invoke(this, new DeleteEventArgs(id)); };
            cancelButton.Click += delegate { cancelDelete?.Invoke(this, EventArgs.Empty); };
            this.FormClosed += delegate { deleteFormClosing?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler submitDelete;
        public event EventHandler cancelDelete;
        public event EventHandler deleteFormClosing;

        public string ID
        {
            get { return Id; }
        }
    }
}
