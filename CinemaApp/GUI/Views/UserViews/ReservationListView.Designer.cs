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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(43, 42, 99);
            dataGridViewCellStyle1.Font = new Font("Montserrat", 14.999999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(49, 48, 115);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(50, 49, 117);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(77, 75, 179);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(222, 222, 224);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.Location = new Point(124, 131);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(43, 42, 99);
            dataGridViewCellStyle3.Font = new Font("Montserrat", 14.999999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(77, 75, 179);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.RowHeadersWidth = 75;
            dataGridView.RowTemplate.Height = 50;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(857, 569);
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
            deleteReservationButton.Location = new Point(721, 49);
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
            reservationListLabel.Location = new Point(124, 53);
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
            ClientSize = new Size(1124, 732);
            Controls.Add(reservationListLabel);
            Controls.Add(deleteReservationButton);
            Controls.Add(dataGridView);
            Name = "ReservationListView";
            Text = "Lista rezerwacji";
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