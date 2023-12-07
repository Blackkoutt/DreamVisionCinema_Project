namespace GUI.Views.UserViews
{
    partial class MoviesListView
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
            dataGridView1 = new DataGridView();
            InfoTextBox = new RichTextBox();
            reserveationButton = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = Color.FromArgb(34, 33, 74);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(43, 42, 99);
            dataGridViewCellStyle4.Font = new Font("Montserrat", 14.999999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(49, 48, 115);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Cursor = Cursors.Hand;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(50, 49, 117);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(77, 75, 179);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(222, 222, 224);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(124, 113);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(43, 42, 99);
            dataGridViewCellStyle6.Font = new Font("Montserrat", 14.999999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.Window;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(77, 75, 179);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(857, 569);
            dataGridView1.TabIndex = 1;
            // 
            // InfoTextBox
            // 
            InfoTextBox.BackColor = Color.FromArgb(34, 35, 68);
            InfoTextBox.BorderStyle = BorderStyle.None;
            InfoTextBox.Font = new Font("Montserrat", 13.15F, FontStyle.Regular, GraphicsUnit.Point);
            InfoTextBox.ForeColor = SystemColors.Window;
            InfoTextBox.Location = new Point(124, 53);
            InfoTextBox.Name = "InfoTextBox";
            InfoTextBox.ReadOnly = true;
            InfoTextBox.ScrollBars = RichTextBoxScrollBars.None;
            InfoTextBox.Size = new Size(631, 44);
            InfoTextBox.TabIndex = 3;
            InfoTextBox.Text = "Wybierz film z listy, a następnie kliknij przycisk rezerwuj";
            // 
            // reserveationButton
            // 
            reserveationButton.BackColor = Color.FromArgb(78, 81, 217);
            reserveationButton.Cursor = Cursors.Hand;
            reserveationButton.FlatAppearance.BorderSize = 0;
            reserveationButton.FlatStyle = FlatStyle.Flat;
            reserveationButton.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            reserveationButton.ForeColor = SystemColors.Window;
            reserveationButton.IconChar = FontAwesome.Sharp.IconChar.Bookmark;
            reserveationButton.IconColor = Color.Orchid;
            reserveationButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            reserveationButton.IconSize = 38;
            reserveationButton.Location = new Point(820, 44);
            reserveationButton.Name = "reserveationButton";
            reserveationButton.Size = new Size(161, 48);
            reserveationButton.TabIndex = 5;
            reserveationButton.Text = "Rezerwuj";
            reserveationButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            reserveationButton.UseVisualStyleBackColor = false;
            // 
            // MoviesListView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(1124, 732);
            Controls.Add(reserveationButton);
            Controls.Add(InfoTextBox);
            Controls.Add(dataGridView1);
            Name = "MoviesListView";
            Text = "Lista filmów";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private RichTextBox InfoTextBox;
        private FontAwesome.Sharp.IconButton reserveationButton;
    }
}