using GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public event EventHandler submitAddForm;
        public event EventHandler addFormClosing;

        public Control.ControlCollection GetControls()
        {
            return this.Controls;
        }
    }
}
