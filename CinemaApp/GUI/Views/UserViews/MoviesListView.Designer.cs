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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            InfoTextBox = new RichTextBox();
            reserveationButton = new FontAwesome.Sharp.IconButton();
            searchButton = new FontAwesome.Sharp.IconButton();
            searchValue = new TextBox();
            label2 = new Label();
            dscButton = new FontAwesome.Sharp.IconButton();
            ascButton = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            sortCriteria = new ComboBox();
            clearButton = new FontAwesome.Sharp.IconButton();
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(43, 42, 99);
            dataGridViewCellStyle1.Font = new Font("Montserrat", 14.999999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(49, 48, 115);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(50, 49, 117);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(77, 75, 179);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(222, 222, 224);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(188, 223);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(43, 42, 99);
            dataGridViewCellStyle3.Font = new Font("Montserrat", 14.999999F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(77, 75, 179);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(230, 230, 230);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(838, 678);
            dataGridView1.TabIndex = 1;
            // 
            // InfoTextBox
            // 
            InfoTextBox.BackColor = Color.FromArgb(34, 35, 68);
            InfoTextBox.BorderStyle = BorderStyle.None;
            InfoTextBox.Font = new Font("Montserrat", 13.15F, FontStyle.Regular, GraphicsUnit.Point);
            InfoTextBox.ForeColor = SystemColors.Window;
            InfoTextBox.Location = new Point(135, 25);
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
            reserveationButton.Location = new Point(856, 83);
            reserveationButton.Name = "reserveationButton";
            reserveationButton.Size = new Size(192, 48);
            reserveationButton.TabIndex = 5;
            reserveationButton.Text = "Rezerwuj";
            reserveationButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            reserveationButton.UseVisualStyleBackColor = false;
            // 
            // searchButton
            // 
            searchButton.BackColor = Color.FromArgb(78, 81, 217);
            searchButton.Cursor = Cursors.Hand;
            searchButton.FlatAppearance.BorderSize = 0;
            searchButton.FlatStyle = FlatStyle.Flat;
            searchButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            searchButton.ForeColor = SystemColors.Window;
            searchButton.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            searchButton.IconColor = SystemColors.Window;
            searchButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            searchButton.IconSize = 32;
            searchButton.Location = new Point(550, 150);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(240, 42);
            searchButton.TabIndex = 16;
            searchButton.Text = "Szukaj";
            searchButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            searchButton.UseVisualStyleBackColor = false;
            // 
            // searchValue
            // 
            searchValue.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            searchValue.Location = new Point(317, 151);
            searchValue.Name = "searchValue";
            searchValue.Size = new Size(217, 38);
            searchValue.TabIndex = 15;
            // 
            // label2
            // 
            label2.Font = new Font("Montserrat", 13.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Window;
            label2.Location = new Point(188, 151);
            label2.Name = "label2";
            label2.Size = new Size(130, 39);
            label2.TabIndex = 14;
            label2.Text = "Wyszukaj:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dscButton
            // 
            dscButton.BackColor = Color.FromArgb(78, 81, 217);
            dscButton.Cursor = Cursors.Hand;
            dscButton.FlatAppearance.BorderSize = 0;
            dscButton.FlatStyle = FlatStyle.Flat;
            dscButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            dscButton.ForeColor = SystemColors.Window;
            dscButton.IconChar = FontAwesome.Sharp.IconChar.SortDesc;
            dscButton.IconColor = SystemColors.Window;
            dscButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            dscButton.IconSize = 32;
            dscButton.Location = new Point(688, 88);
            dscButton.Name = "dscButton";
            dscButton.Size = new Size(102, 43);
            dscButton.TabIndex = 13;
            dscButton.Text = "DSC";
            dscButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            dscButton.UseVisualStyleBackColor = false;
            // 
            // ascButton
            // 
            ascButton.BackColor = Color.FromArgb(78, 81, 217);
            ascButton.Cursor = Cursors.Hand;
            ascButton.FlatAppearance.BorderSize = 0;
            ascButton.FlatStyle = FlatStyle.Flat;
            ascButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            ascButton.ForeColor = SystemColors.Window;
            ascButton.IconChar = FontAwesome.Sharp.IconChar.SortUp;
            ascButton.IconColor = SystemColors.Window;
            ascButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ascButton.IconSize = 32;
            ascButton.Location = new Point(550, 88);
            ascButton.Name = "ascButton";
            ascButton.Size = new Size(102, 43);
            ascButton.TabIndex = 12;
            ascButton.Text = "ASC";
            ascButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            ascButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Font = new Font("Montserrat", 13.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(135, 88);
            label1.Name = "label1";
            label1.Size = new Size(183, 41);
            label1.TabIndex = 11;
            label1.Text = "Sortuj według:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sortCriteria
            // 
            sortCriteria.AutoCompleteCustomSource.AddRange(new string[] { "ID" });
            sortCriteria.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            sortCriteria.FormattingEnabled = true;
            sortCriteria.Items.AddRange(new object[] { "ID", "Tytuł", "Data", "Cena", "Długość", "Sala" });
            sortCriteria.Location = new Point(317, 90);
            sortCriteria.Name = "sortCriteria";
            sortCriteria.Size = new Size(217, 39);
            sortCriteria.TabIndex = 10;
            // 
            // clearButton
            // 
            clearButton.BackColor = Color.FromArgb(7, 146, 232);
            clearButton.Cursor = Cursors.Hand;
            clearButton.FlatAppearance.BorderSize = 0;
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            clearButton.ForeColor = SystemColors.Window;
            clearButton.IconChar = FontAwesome.Sharp.IconChar.FilterCircleXmark;
            clearButton.IconColor = SystemColors.Window;
            clearButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            clearButton.IconSize = 34;
            clearButton.Location = new Point(856, 145);
            clearButton.Margin = new Padding(3, 20, 3, 3);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(192, 51);
            clearButton.TabIndex = 17;
            clearButton.Text = "Wyczyść filtry";
            clearButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            clearButton.UseVisualStyleBackColor = false;
            // 
            // MoviesListView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(1222, 913);
            Controls.Add(clearButton);
            Controls.Add(searchButton);
            Controls.Add(searchValue);
            Controls.Add(label2);
            Controls.Add(dscButton);
            Controls.Add(ascButton);
            Controls.Add(label1);
            Controls.Add(sortCriteria);
            Controls.Add(reserveationButton);
            Controls.Add(InfoTextBox);
            Controls.Add(dataGridView1);
            Name = "MoviesListView";
            Text = "Lista filmów";
            Load += MoviesListView_Load;
            Resize += MoviesListView_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private RichTextBox InfoTextBox;
        private FontAwesome.Sharp.IconButton reserveationButton;
        private FontAwesome.Sharp.IconButton searchButton;
        private TextBox searchValue;
        private Label label2;
        private FontAwesome.Sharp.IconButton dscButton;
        private FontAwesome.Sharp.IconButton ascButton;
        private Label label1;
        private ComboBox sortCriteria;
        private FontAwesome.Sharp.IconButton clearButton;
    }
}