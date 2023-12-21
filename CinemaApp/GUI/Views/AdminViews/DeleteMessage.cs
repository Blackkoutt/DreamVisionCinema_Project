using GUI.Interfaces;

namespace GUI.Views.AdminViews
{
    public partial class DeleteMessage : Form, IDeleteMessage
    {
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
            this.filmName.Text = $"\"{filmTitle}\"?";
            this.Text = $"Usuwanie filmu - \"{filmTitle}\"";
            deleteMovieButton.Click += delegate { submitDelete?.Invoke(this, new DeleteEventArgs(id)); };
            cancelButton.Click += delegate { cancelDelete?.Invoke(this, EventArgs.Empty); };
            this.FormClosed += delegate { deleteFormClosing?.Invoke(this, EventArgs.Empty); };
        }
        public string ID
        {
            get { return Id; }
        }

        public event EventHandler submitDelete;
        public event EventHandler cancelDelete;
        public event EventHandler deleteFormClosing;
    }
}
