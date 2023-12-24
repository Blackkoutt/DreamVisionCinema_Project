namespace GUI.Views.AdminViews
{
    partial class AdminMoviesListView
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
            sortCriteria = new ComboBox();
            label1 = new Label();
            ascButton = new FontAwesome.Sharp.IconButton();
            dscButton = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            searchValue = new TextBox();
            searchButton = new FontAwesome.Sharp.IconButton();
            addButton = new FontAwesome.Sharp.IconButton();
            deleteButton = new FontAwesome.Sharp.IconButton();
            modifyButton = new FontAwesome.Sharp.IconButton();
            clearButton = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.None;
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
            dataGridView1.Location = new Point(190, 200);
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
            dataGridView1.Size = new Size(884, 535);
            dataGridView1.TabIndex = 2;
            // 
            // sortCriteria
            // 
            sortCriteria.AutoCompleteCustomSource.AddRange(new string[] { "ID" });
            sortCriteria.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            sortCriteria.FormattingEnabled = true;
            sortCriteria.Items.AddRange(new object[] { "ID", "Tytuł", "Data", "Cena", "Długość", "Sala" });
            sortCriteria.Location = new Point(243, 62);
            sortCriteria.Name = "sortCriteria";
            sortCriteria.Size = new Size(217, 33);
            sortCriteria.TabIndex = 3;
            // 
            // label1
            // 
            label1.Font = new Font("Montserrat", 13.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(54, 56);
            label1.Name = "label1";
            label1.Size = new Size(183, 41);
            label1.TabIndex = 4;
            label1.Text = "Sortuj według:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
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
            ascButton.Location = new Point(480, 56);
            ascButton.Name = "ascButton";
            ascButton.Size = new Size(102, 43);
            ascButton.TabIndex = 5;
            ascButton.Text = "ASC";
            ascButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            ascButton.UseVisualStyleBackColor = false;
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
            dscButton.Location = new Point(618, 56);
            dscButton.Name = "dscButton";
            dscButton.Size = new Size(102, 43);
            dscButton.TabIndex = 6;
            dscButton.Text = "DSC";
            dscButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            dscButton.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.Font = new Font("Montserrat", 13.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Window;
            label2.Location = new Point(107, 130);
            label2.Name = "label2";
            label2.Size = new Size(130, 39);
            label2.TabIndex = 7;
            label2.Text = "Wyszukaj:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // searchValue
            // 
            searchValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            searchValue.Location = new Point(243, 137);
            searchValue.Name = "searchValue";
            searchValue.Size = new Size(217, 31);
            searchValue.TabIndex = 8;
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
            searchButton.Location = new Point(480, 130);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(240, 42);
            searchButton.TabIndex = 9;
            searchButton.Text = "Szukaj";
            searchButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            searchButton.UseVisualStyleBackColor = false;
            // 
            // addButton
            // 
            addButton.BackColor = Color.FromArgb(50, 168, 82);
            addButton.Cursor = Cursors.Hand;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            addButton.ForeColor = SystemColors.Window;
            addButton.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            addButton.IconColor = SystemColors.Window;
            addButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            addButton.IconSize = 34;
            addButton.Location = new Point(788, 51);
            addButton.Name = "addButton";
            addButton.Size = new Size(192, 51);
            addButton.TabIndex = 10;
            addButton.Text = "Dodaj nowy";
            addButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            addButton.UseVisualStyleBackColor = false;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = Color.FromArgb(168, 50, 50);
            deleteButton.Cursor = Cursors.Hand;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            deleteButton.ForeColor = SystemColors.Window;
            deleteButton.IconChar = FontAwesome.Sharp.IconChar.Trash;
            deleteButton.IconColor = SystemColors.Window;
            deleteButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            deleteButton.IconSize = 34;
            deleteButton.Location = new Point(1003, 125);
            deleteButton.Margin = new Padding(3, 20, 3, 3);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(192, 51);
            deleteButton.TabIndex = 11;
            deleteButton.Text = "Usuń";
            deleteButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            deleteButton.UseVisualStyleBackColor = false;
            // 
            // modifyButton
            // 
            modifyButton.BackColor = Color.FromArgb(219, 143, 2);
            modifyButton.Cursor = Cursors.Hand;
            modifyButton.FlatAppearance.BorderSize = 0;
            modifyButton.FlatStyle = FlatStyle.Flat;
            modifyButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            modifyButton.ForeColor = SystemColors.Window;
            modifyButton.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            modifyButton.IconColor = SystemColors.Window;
            modifyButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            modifyButton.IconSize = 34;
            modifyButton.Location = new Point(1003, 51);
            modifyButton.Margin = new Padding(20, 20, 20, 3);
            modifyButton.Name = "modifyButton";
            modifyButton.Size = new Size(192, 51);
            modifyButton.TabIndex = 13;
            modifyButton.Text = "Modyfikuj";
            modifyButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            modifyButton.UseVisualStyleBackColor = false;
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
            clearButton.Location = new Point(788, 125);
            clearButton.Margin = new Padding(3, 20, 3, 3);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(192, 51);
            clearButton.TabIndex = 14;
            clearButton.Text = "Wyczyść filtry";
            clearButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            clearButton.UseVisualStyleBackColor = false;
            // 
            // AdminMoviesListView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(1238, 801);
            Controls.Add(clearButton);
            Controls.Add(modifyButton);
            Controls.Add(deleteButton);
            Controls.Add(addButton);
            Controls.Add(searchButton);
            Controls.Add(searchValue);
            Controls.Add(label2);
            Controls.Add(dscButton);
            Controls.Add(ascButton);
            Controls.Add(label1);
            Controls.Add(sortCriteria);
            Controls.Add(dataGridView1);
            Name = "AdminMoviesListView";
            Text = "Lista filmów";
            Resize += AdminMoviesListView_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox sortCriteria;
        private Label label1;
        private FontAwesome.Sharp.IconButton ascButton;
        private FontAwesome.Sharp.IconButton dscButton;
        private Label label2;
        private TextBox searchValue;
        private FontAwesome.Sharp.IconButton searchButton;
        private FontAwesome.Sharp.IconButton addButton;
        private FontAwesome.Sharp.IconButton deleteButton;
        private FontAwesome.Sharp.IconButton modifyButton;
        private FontAwesome.Sharp.IconButton clearButton;
    }
}