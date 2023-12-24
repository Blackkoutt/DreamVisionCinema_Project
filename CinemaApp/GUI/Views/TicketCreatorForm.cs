using GUI.Interfaces;

namespace GUI.Views
{
    public partial class TicketCreatorForm : Form, ITicketCreator
    {
        public TicketCreatorForm()
        {
            InitializeComponent();
        }
        public void SetBackColor()
        {
            this.BackColor = Color.FromArgb(34, 35, 68);
        }
        public Control.ControlCollection GetControls()
        {
            return this.Controls;
        }
    }
}