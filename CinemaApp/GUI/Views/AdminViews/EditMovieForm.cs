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
using static GUI.Views.AdminViews.DeleteMessage;

namespace GUI.Views.AdminViews
{
    public partial class EditMovieForm : Form, IEditMovieView
    {
        public class EditEventArgs : EventArgs
        {
            public string Id { get; }
            public string Date { get; }
            public string Price { get; }
            public string RoomNumber { get; }

            public EditEventArgs(string id, string date, string price, string roomNumber)
            {
                Id = id;
                Date = date;
                Price = price;
                RoomNumber = roomNumber;
            }
        }
        private string Id;
        private string oldDate;
        private string oldPrice;
        private string oldRoomNumber;
        public EditMovieForm(string id, string title, string date, string price, string room_nr)
        {
            InitializeComponent();
            Id = id;
            oldDate = date;
            oldPrice = price;
            oldRoomNumber = room_nr;

            this.filmNameLabel.Text = $"\"{title}\"";
            this.dateValueEdit.Text = date;
            this.priceValueEdit.Text = price;
            this.roomTextViewEdit.Text = room_nr;
            submitEditButton.Click += delegate { submitEditForm?.Invoke(this, new EditEventArgs(
                id,
                this.dateValueEdit.Text,
                this.priceValueEdit.Text,
                this.roomTextViewEdit.Text
                ));
            };
            this.FormClosed += delegate { editFormClosing?.Invoke(this, EventArgs.Empty); };
        }
        public string ID
        {
            get { return Id; }
        }
        public string OldPrice{
            get { return oldPrice; }
        }
        public string OldDate
        {
            get { return oldDate; }
        }
        public string OldRoomNumber
        {
            get { return oldRoomNumber; }
        }

        public DateTimePicker DateValueEdit
        {
            get { return this.dateValueEdit; }
        }

        public NumericUpDown PriceValueEdit
        {
            get { return this.priceValueEdit; }
        }

        public NumericUpDown RoomNumberValueEdit
        {
            get { return this.roomTextViewEdit; }
        }

        public event EventHandler submitEditForm;
        public event EventHandler editFormClosing;
    }
}
