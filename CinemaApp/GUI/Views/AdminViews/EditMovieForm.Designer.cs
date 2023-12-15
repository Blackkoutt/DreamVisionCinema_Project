namespace GUI.Views.AdminViews
{
    partial class EditMovieForm
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
            pictureBox1 = new PictureBox();
            filmEditlabel = new Label();
            filmNameLabel = new Label();
            dateValueEdit = new DateTimePicker();
            dataLabelEdit = new Label();
            priceValueEdit = new NumericUpDown();
            priceLabelEdit = new Label();
            roomTextViewEdit = new NumericUpDown();
            roomLabelEdit = new Label();
            submitEditButton = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceValueEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roomTextViewEdit).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.movie_png1;
            pictureBox1.Location = new Point(303, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(217, 121);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // filmEditlabel
            // 
            filmEditlabel.Font = new Font("Montserrat", 18F, FontStyle.Regular, GraphicsUnit.Point);
            filmEditlabel.ForeColor = SystemColors.Window;
            filmEditlabel.Location = new Point(276, 127);
            filmEditlabel.Name = "filmEditlabel";
            filmEditlabel.Size = new Size(269, 54);
            filmEditlabel.TabIndex = 104;
            filmEditlabel.Text = "Edycja filmu:";
            filmEditlabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // filmNameLabel
            // 
            filmNameLabel.Font = new Font("Montserrat", 18F, FontStyle.Regular, GraphicsUnit.Point);
            filmNameLabel.ForeColor = SystemColors.Window;
            filmNameLabel.Location = new Point(42, 181);
            filmNameLabel.Name = "filmNameLabel";
            filmNameLabel.Size = new Size(744, 54);
            filmNameLabel.TabIndex = 105;
            filmNameLabel.Text = "Tytuł filmu";
            filmNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateValueEdit
            // 
            dateValueEdit.CalendarFont = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            dateValueEdit.CustomFormat = "dd/MM/yyyy HH:mm";
            dateValueEdit.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            dateValueEdit.Format = DateTimePickerFormat.Custom;
            dateValueEdit.Location = new Point(251, 284);
            dateValueEdit.Name = "dateValueEdit";
            dateValueEdit.ShowUpDown = true;
            dateValueEdit.Size = new Size(325, 38);
            dateValueEdit.TabIndex = 118;
            // 
            // dataLabelEdit
            // 
            dataLabelEdit.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            dataLabelEdit.ForeColor = SystemColors.Window;
            dataLabelEdit.Location = new Point(251, 247);
            dataLabelEdit.Name = "dataLabelEdit";
            dataLabelEdit.Size = new Size(78, 34);
            dataLabelEdit.TabIndex = 119;
            dataLabelEdit.Text = "Data:";
            dataLabelEdit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // priceValueEdit
            // 
            priceValueEdit.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            priceValueEdit.Location = new Point(251, 382);
            priceValueEdit.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            priceValueEdit.Name = "priceValueEdit";
            priceValueEdit.Size = new Size(325, 38);
            priceValueEdit.TabIndex = 120;
            // 
            // priceLabelEdit
            // 
            priceLabelEdit.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            priceLabelEdit.ForeColor = SystemColors.Window;
            priceLabelEdit.Location = new Point(251, 345);
            priceLabelEdit.Name = "priceLabelEdit";
            priceLabelEdit.Size = new Size(120, 34);
            priceLabelEdit.TabIndex = 121;
            priceLabelEdit.Text = "Cena ($):";
            priceLabelEdit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // roomTextViewEdit
            // 
            roomTextViewEdit.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            roomTextViewEdit.Location = new Point(251, 480);
            roomTextViewEdit.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            roomTextViewEdit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            roomTextViewEdit.Name = "roomTextViewEdit";
            roomTextViewEdit.Size = new Size(325, 38);
            roomTextViewEdit.TabIndex = 122;
            roomTextViewEdit.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // roomLabelEdit
            // 
            roomLabelEdit.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            roomLabelEdit.ForeColor = SystemColors.Window;
            roomLabelEdit.Location = new Point(251, 443);
            roomLabelEdit.Name = "roomLabelEdit";
            roomLabelEdit.Size = new Size(169, 34);
            roomLabelEdit.TabIndex = 123;
            roomLabelEdit.Text = "Numer sali:";
            roomLabelEdit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // submitEditButton
            // 
            submitEditButton.BackColor = Color.FromArgb(50, 168, 82);
            submitEditButton.Cursor = Cursors.Hand;
            submitEditButton.FlatAppearance.BorderSize = 0;
            submitEditButton.FlatStyle = FlatStyle.Flat;
            submitEditButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            submitEditButton.ForeColor = SystemColors.Window;
            submitEditButton.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            submitEditButton.IconColor = SystemColors.Window;
            submitEditButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            submitEditButton.IconSize = 34;
            submitEditButton.Location = new Point(334, 549);
            submitEditButton.Name = "submitEditButton";
            submitEditButton.Size = new Size(137, 51);
            submitEditButton.TabIndex = 124;
            submitEditButton.Text = "Zapisz";
            submitEditButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            submitEditButton.UseVisualStyleBackColor = false;
            // 
            // EditMovieForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(826, 647);
            Controls.Add(submitEditButton);
            Controls.Add(roomLabelEdit);
            Controls.Add(roomTextViewEdit);
            Controls.Add(priceLabelEdit);
            Controls.Add(priceValueEdit);
            Controls.Add(dataLabelEdit);
            Controls.Add(dateValueEdit);
            Controls.Add(filmNameLabel);
            Controls.Add(filmEditlabel);
            Controls.Add(pictureBox1);
            Name = "EditMovieForm";
            Text = "EditMovieForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceValueEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)roomTextViewEdit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label filmEditlabel;
        private Label filmNameLabel;
        private DateTimePicker dateValueEdit;
        private Label dataLabelEdit;
        private NumericUpDown priceValueEdit;
        private Label priceLabelEdit;
        private NumericUpDown roomTextViewEdit;
        private Label roomLabelEdit;
        private FontAwesome.Sharp.IconButton submitEditButton;
    }
}