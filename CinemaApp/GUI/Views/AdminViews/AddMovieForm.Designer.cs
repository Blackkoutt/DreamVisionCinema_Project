using System.Windows.Forms;

namespace GUI.Views.AdminViews
{
    partial class AddMovieForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMovieForm));
            pictureBox1 = new PictureBox();
            titleTextView = new RichTextBox();
            infoLabel = new Label();
            titleLabel = new Label();
            dataLabel = new Label();
            priceLabel = new Label();
            durationLabel = new Label();
            roomLabel = new Label();
            submitAddButton = new FontAwesome.Sharp.IconButton();
            dateValue = new DateTimePicker();
            priceValue = new NumericUpDown();
            roomTextView = new NumericUpDown();
            durationTextView = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roomTextView).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.movie_png1;
            pictureBox1.Location = new Point(290, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(217, 121);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // titleTextView
            // 
            titleTextView.BackColor = SystemColors.Window;
            titleTextView.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            titleTextView.Location = new Point(240, 244);
            titleTextView.Name = "titleTextView";
            titleTextView.Size = new Size(325, 37);
            titleTextView.TabIndex = 6;
            titleTextView.Text = "";
            // 
            // infoLabel
            // 
            infoLabel.Font = new Font("Montserrat", 18F, FontStyle.Regular, GraphicsUnit.Point);
            infoLabel.ForeColor = SystemColors.Window;
            infoLabel.Location = new Point(0, 123);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(794, 54);
            infoLabel.TabIndex = 103;
            infoLabel.Text = "Dodaj nowy film";
            infoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            titleLabel.ForeColor = SystemColors.Window;
            titleLabel.Location = new Point(240, 207);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(78, 34);
            titleLabel.TabIndex = 104;
            titleLabel.Text = "Tytuł:";
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dataLabel
            // 
            dataLabel.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            dataLabel.ForeColor = SystemColors.Window;
            dataLabel.Location = new Point(240, 296);
            dataLabel.Name = "dataLabel";
            dataLabel.Size = new Size(78, 34);
            dataLabel.TabIndex = 105;
            dataLabel.Text = "Data:";
            dataLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // priceLabel
            // 
            priceLabel.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            priceLabel.ForeColor = SystemColors.Window;
            priceLabel.Location = new Point(240, 395);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(120, 34);
            priceLabel.TabIndex = 109;
            priceLabel.Text = "Cena ($):";
            priceLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // durationLabel
            // 
            durationLabel.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            durationLabel.ForeColor = SystemColors.Window;
            durationLabel.Location = new Point(240, 491);
            durationLabel.Name = "durationLabel";
            durationLabel.Size = new Size(210, 34);
            durationLabel.TabIndex = 111;
            durationLabel.Text = "Czas trwania (h):";
            durationLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // roomLabel
            // 
            roomLabel.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            roomLabel.ForeColor = SystemColors.Window;
            roomLabel.Location = new Point(240, 586);
            roomLabel.Name = "roomLabel";
            roomLabel.Size = new Size(169, 34);
            roomLabel.TabIndex = 113;
            roomLabel.Text = "Numer sali:";
            roomLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // submitAddButton
            // 
            submitAddButton.BackColor = Color.FromArgb(50, 168, 82);
            submitAddButton.Cursor = Cursors.Hand;
            submitAddButton.FlatAppearance.BorderSize = 0;
            submitAddButton.FlatStyle = FlatStyle.Flat;
            submitAddButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            submitAddButton.ForeColor = SystemColors.Window;
            submitAddButton.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            submitAddButton.IconColor = SystemColors.Window;
            submitAddButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            submitAddButton.IconSize = 34;
            submitAddButton.Location = new Point(313, 720);
            submitAddButton.Name = "submitAddButton";
            submitAddButton.Size = new Size(137, 51);
            submitAddButton.TabIndex = 115;
            submitAddButton.Text = "Dodaj";
            submitAddButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            submitAddButton.UseVisualStyleBackColor = false;
            // 
            // dateValue
            // 
            dateValue.CalendarFont = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            dateValue.CustomFormat = "dd/MM/yyyy HH:mm";
            dateValue.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            dateValue.Format = DateTimePickerFormat.Custom;
            dateValue.Location = new Point(240, 333);
            dateValue.Name = "dateValue";
            dateValue.ShowUpDown = true;
            dateValue.Size = new Size(325, 38);
            dateValue.TabIndex = 117;
            // 
            // priceValue
            // 
            priceValue.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            priceValue.Location = new Point(240, 432);
            priceValue.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            priceValue.Name = "priceValue";
            priceValue.Size = new Size(325, 38);
            priceValue.TabIndex = 118;
            // 
            // roomTextView
            // 
            roomTextView.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            roomTextView.Location = new Point(240, 623);
            roomTextView.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            roomTextView.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            roomTextView.Name = "roomTextView";
            roomTextView.Size = new Size(325, 38);
            roomTextView.TabIndex = 119;
            roomTextView.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // durationTextView
            // 
            durationTextView.CalendarFont = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            durationTextView.CustomFormat = "HH:mm";
            durationTextView.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            durationTextView.Format = DateTimePickerFormat.Custom;
            durationTextView.Location = new Point(240, 528);
            durationTextView.Name = "durationTextView";
            durationTextView.ShowUpDown = true;
            durationTextView.Size = new Size(325, 38);
            durationTextView.TabIndex = 120;
            // 
            // AddMovieForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(793, 816);
            Controls.Add(durationTextView);
            Controls.Add(roomTextView);
            Controls.Add(priceValue);
            Controls.Add(dateValue);
            Controls.Add(submitAddButton);
            Controls.Add(roomLabel);
            Controls.Add(durationLabel);
            Controls.Add(priceLabel);
            Controls.Add(dataLabel);
            Controls.Add(titleLabel);
            Controls.Add(infoLabel);
            Controls.Add(titleTextView);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(811, 863);
            MinimumSize = new Size(811, 863);
            Name = "AddMovieForm";
            Text = "Dodawanie nowego filmu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)roomTextView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private RichTextBox InfoTextBox;
        private RichTextBox titleTextView;
        private Label infoLabel;
        private Label titleLabel;
        private Label dataLabel;
        private MonthCalendar dateCalendar;
        private Label priceLabel;
        private Label durationLabel;
        private Label roomLabel;
        private FontAwesome.Sharp.IconButton submitAddButton;
        private DateTimePicker dateValue;
        private NumericUpDown priceValue;
        private NumericUpDown roomTextView;
        private DateTimePicker durationTextView;
    }
}