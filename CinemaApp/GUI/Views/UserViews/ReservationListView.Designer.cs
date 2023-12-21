using System.Windows.Forms;

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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dataGridView = new DataGridView();
            deleteReservationButton = new FontAwesome.Sharp.IconButton();
            reservationListLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.BackgroundColor = Color.FromArgb(34, 33, 74);
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(43, 42, 99);
            dataGridViewCellStyle4.Font = new Font("Montserrat", 14.999999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(49, 48, 115);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Cursor = Cursors.Hand;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(50, 49, 117);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(77, 75, 179);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(222, 222, 224);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.Location = new Point(182, 129);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(43, 42, 99);
            dataGridViewCellStyle6.Font = new Font("Montserrat", 14.999999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.Window;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(77, 75, 179);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView.RowHeadersWidth = 75;
            dataGridView.RowTemplate.Height = 50;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(833, 554);
            dataGridView.TabIndex = 1;
            // 
            // deleteReservationButton
            // 
            deleteReservationButton.BackColor = Color.FromArgb(78, 81, 217);
            deleteReservationButton.Cursor = Cursors.Hand;
            deleteReservationButton.FlatAppearance.BorderSize = 0;
            deleteReservationButton.FlatStyle = FlatStyle.Flat;
            deleteReservationButton.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            deleteReservationButton.ForeColor = SystemColors.Window;
            deleteReservationButton.IconChar = FontAwesome.Sharp.IconChar.Trash;
            deleteReservationButton.IconColor = Color.Crimson;
            deleteReservationButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            deleteReservationButton.IconSize = 38;
            deleteReservationButton.Location = new Point(781, 49);
            deleteReservationButton.Name = "deleteReservationButton";
            deleteReservationButton.Size = new Size(260, 48);
            deleteReservationButton.TabIndex = 3;
            deleteReservationButton.Text = "Anuluj rezerwację";
            deleteReservationButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            deleteReservationButton.UseVisualStyleBackColor = false;
            // 
            // reservationListLabel
            // 
            reservationListLabel.Font = new Font("Montserrat", 14.999999F, FontStyle.Regular, GraphicsUnit.Point);
            reservationListLabel.ForeColor = SystemColors.Window;
            reservationListLabel.Location = new Point(182, 53);
            reservationListLabel.Name = "reservationListLabel";
            reservationListLabel.Size = new Size(559, 44);
            reservationListLabel.TabIndex = 4;
            reservationListLabel.Text = "Lista twoich rezerwacji:";
            reservationListLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ReservationListView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(1222, 732);
            Controls.Add(reservationListLabel);
            Controls.Add(deleteReservationButton);
            Controls.Add(dataGridView);
            Name = "ReservationListView";
            Text = "Lista rezerwacji";
            Load += ReservationListView_Load;
            Resize += ReservationListView_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton deleteReservationButton;
        private Label reservationListLabel;
    }
}