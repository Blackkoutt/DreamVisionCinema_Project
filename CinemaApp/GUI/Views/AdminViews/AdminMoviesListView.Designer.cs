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
            comboBox1 = new ComboBox();
            label1 = new Label();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            textBox1 = new TextBox();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            iconButton5 = new FontAwesome.Sharp.IconButton();
            iconButton6 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
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
            dataGridView1.Location = new Point(134, 142);
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
            dataGridView1.Size = new Size(893, 566);
            dataGridView1.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteCustomSource.AddRange(new string[] { "ID" });
            comboBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "ID", "Tytuł", "Data", "Cena", "Długość", "Sala" });
            comboBox1.Location = new Point(182, 63);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 33);
            comboBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.Font = new Font("Montserrat", 13.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(12, 63);
            label1.Name = "label1";
            label1.Size = new Size(181, 28);
            label1.TabIndex = 4;
            label1.Text = "Sortuj według:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.FromArgb(78, 81, 217);
            iconButton1.Cursor = Cursors.Hand;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton1.ForeColor = SystemColors.Window;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.SortUp;
            iconButton1.IconColor = SystemColors.Window;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 32;
            iconButton1.Location = new Point(358, 60);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(99, 37);
            iconButton1.TabIndex = 5;
            iconButton1.Text = "ASC";
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = false;
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.FromArgb(78, 81, 217);
            iconButton2.Cursor = Cursors.Hand;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton2.ForeColor = SystemColors.Window;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.SortDesc;
            iconButton2.IconColor = SystemColors.Window;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 32;
            iconButton2.Location = new Point(484, 60);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(110, 37);
            iconButton2.TabIndex = 6;
            iconButton2.Text = "DSC";
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.Font = new Font("Montserrat", 13.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Window;
            label2.Location = new Point(12, 124);
            label2.Name = "label2";
            label2.Size = new Size(125, 28);
            label2.TabIndex = 7;
            label2.Text = "Wyszukaj:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(143, 124);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(204, 31);
            textBox1.TabIndex = 8;
            // 
            // iconButton3
            // 
            iconButton3.BackColor = Color.FromArgb(78, 81, 217);
            iconButton3.Cursor = Cursors.Hand;
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton3.ForeColor = SystemColors.Window;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            iconButton3.IconColor = SystemColors.Window;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.IconSize = 32;
            iconButton3.Location = new Point(387, 121);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(164, 37);
            iconButton3.TabIndex = 9;
            iconButton3.Text = "Szukaj";
            iconButton3.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton3.UseVisualStyleBackColor = false;
            // 
            // iconButton4
            // 
            iconButton4.BackColor = Color.FromArgb(78, 81, 217);
            iconButton4.Cursor = Cursors.Hand;
            iconButton4.FlatAppearance.BorderSize = 0;
            iconButton4.FlatStyle = FlatStyle.Flat;
            iconButton4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton4.ForeColor = SystemColors.Window;
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            iconButton4.IconColor = SystemColors.Window;
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton4.IconSize = 32;
            iconButton4.Location = new Point(948, 142);
            iconButton4.Name = "iconButton4";
            iconButton4.Size = new Size(164, 37);
            iconButton4.TabIndex = 10;
            iconButton4.Text = "Dodaj nowy";
            iconButton4.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton4.UseVisualStyleBackColor = false;
            // 
            // iconButton5
            // 
            iconButton5.BackColor = Color.FromArgb(78, 81, 217);
            iconButton5.Cursor = Cursors.Hand;
            iconButton5.FlatAppearance.BorderSize = 0;
            iconButton5.FlatStyle = FlatStyle.Flat;
            iconButton5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton5.ForeColor = SystemColors.Window;
            iconButton5.IconChar = FontAwesome.Sharp.IconChar.Trash;
            iconButton5.IconColor = SystemColors.Window;
            iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton5.IconSize = 32;
            iconButton5.Location = new Point(948, 201);
            iconButton5.Name = "iconButton5";
            iconButton5.Size = new Size(164, 37);
            iconButton5.TabIndex = 11;
            iconButton5.Text = "Usuń";
            iconButton5.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton5.UseVisualStyleBackColor = false;
            // 
            // iconButton6
            // 
            iconButton6.BackColor = Color.FromArgb(78, 81, 217);
            iconButton6.Cursor = Cursors.Hand;
            iconButton6.FlatAppearance.BorderSize = 0;
            iconButton6.FlatStyle = FlatStyle.Flat;
            iconButton6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton6.ForeColor = SystemColors.Window;
            iconButton6.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            iconButton6.IconColor = SystemColors.Window;
            iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton6.IconSize = 32;
            iconButton6.Location = new Point(948, 260);
            iconButton6.Name = "iconButton6";
            iconButton6.Size = new Size(164, 37);
            iconButton6.TabIndex = 12;
            iconButton6.Text = "Modyfikuj";
            iconButton6.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton6.UseVisualStyleBackColor = false;
            // 
            // AdminMoviesListView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(1124, 732);
            Controls.Add(iconButton6);
            Controls.Add(iconButton5);
            Controls.Add(iconButton4);
            Controls.Add(iconButton3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(iconButton2);
            Controls.Add(iconButton1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Name = "AdminMoviesListView";
            Text = "Lista filmów";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Label label1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private Label label2;
        private TextBox textBox1;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton4;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton iconButton6;
    }
}