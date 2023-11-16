namespace GUI.UserForms
{
    partial class ReservationListView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            reservationListView = new ListView();
            reservationID = new ColumnHeader();
            movieTitle = new ColumnHeader();
            movieDate = new ColumnHeader();
            movieRoom = new ColumnHeader();
            reservationPrice = new ColumnHeader();
            reservationSeats = new ColumnHeader();
            SuspendLayout();
            // 
            // reservationListView
            // 
            reservationListView.BackColor = Color.FromArgb(30, 32, 60);
            reservationListView.Columns.AddRange(new ColumnHeader[] { reservationID, movieTitle, movieDate, movieRoom, reservationPrice, reservationSeats });
            reservationListView.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            reservationListView.GridLines = true;
            reservationListView.Location = new Point(76, 76);
            reservationListView.Name = "reservationListView";
            reservationListView.Size = new Size(631, 274);
            reservationListView.TabIndex = 0;
            reservationListView.UseCompatibleStateImageBehavior = false;
            reservationListView.View = View.Details;
            // 
            // reservationID
            // 
            reservationID.Text = "ID";
            reservationID.Width = 40;
            // 
            // movieTitle
            // 
            movieTitle.Text = "Tytuł filmu";
            movieTitle.Width = 150;
            // 
            // movieDate
            // 
            movieDate.Text = "Data";
            movieDate.Width = 100;
            // 
            // movieRoom
            // 
            movieRoom.Text = "Sala";
            // 
            // reservationPrice
            // 
            reservationPrice.Text = "Cena";
            reservationPrice.Width = 80;
            // 
            // reservationSeats
            // 
            reservationSeats.Text = "Miejsca";
            reservationSeats.Width = 150;
            // 
            // ReservationListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(800, 450);
            Controls.Add(reservationListView);
            Name = "ReservationListForm";
            Text = "Lista rezerwacji";
            ResumeLayout(false);
        }

        #endregion

        private ListView reservationListView;
        private ColumnHeader reservationID;
        private ColumnHeader movieTitle;
        private ColumnHeader movieDate;
        private ColumnHeader movieRoom;
        private ColumnHeader reservationPrice;
        private ColumnHeader reservationSeats;
    }
}