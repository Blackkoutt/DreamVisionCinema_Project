namespace GUI.Views.AdminViews
{
    partial class DeleteMessage
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
            delete_info = new Label();
            pictureBox1 = new PictureBox();
            filmName = new Label();
            deleteMovieButton = new FontAwesome.Sharp.IconButton();
            cancelButton = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // delete_info
            // 
            delete_info.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            delete_info.ForeColor = SystemColors.Window;
            delete_info.Location = new Point(188, 160);
            delete_info.Name = "delete_info";
            delete_info.Size = new Size(400, 54);
            delete_info.TabIndex = 104;
            delete_info.Text = "Czy napewno chcesz usunąć film";
            delete_info.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.movie_delete;
            pictureBox1.Location = new Point(266, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(247, 154);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 105;
            pictureBox1.TabStop = false;
            // 
            // filmName
            // 
            filmName.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            filmName.ForeColor = SystemColors.Window;
            filmName.Location = new Point(40, 214);
            filmName.Name = "filmName";
            filmName.Size = new Size(727, 54);
            filmName.TabIndex = 106;
            filmName.Text = "Nazwa filmu";
            filmName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // deleteMovieButton
            // 
            deleteMovieButton.BackColor = Color.FromArgb(168, 50, 50);
            deleteMovieButton.Cursor = Cursors.Hand;
            deleteMovieButton.FlatAppearance.BorderSize = 0;
            deleteMovieButton.FlatStyle = FlatStyle.Flat;
            deleteMovieButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            deleteMovieButton.ForeColor = SystemColors.Window;
            deleteMovieButton.IconChar = FontAwesome.Sharp.IconChar.Trash;
            deleteMovieButton.IconColor = SystemColors.Window;
            deleteMovieButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            deleteMovieButton.IconSize = 34;
            deleteMovieButton.Location = new Point(252, 378);
            deleteMovieButton.Margin = new Padding(3, 20, 3, 3);
            deleteMovieButton.Name = "deleteMovieButton";
            deleteMovieButton.Size = new Size(122, 51);
            deleteMovieButton.TabIndex = 107;
            deleteMovieButton.Text = "Usuń";
            deleteMovieButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            deleteMovieButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(7, 146, 232);
            cancelButton.Cursor = Cursors.Hand;
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cancelButton.ForeColor = SystemColors.Window;
            cancelButton.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            cancelButton.IconColor = SystemColors.Window;
            cancelButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            cancelButton.IconSize = 34;
            cancelButton.Location = new Point(422, 378);
            cancelButton.Margin = new Padding(3, 20, 3, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(122, 51);
            cancelButton.TabIndex = 108;
            cancelButton.Text = "Anuluj";
            cancelButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Font = new Font("Montserrat", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(230, 50, 50);
            label1.Location = new Point(-1, 278);
            label1.Name = "label1";
            label1.Size = new Size(800, 80);
            label1.TabIndex = 109;
            label1.Text = "[!] Jeśli film posiada rezerwacje to osoby, które zakupiły bilet otrzymają informację o odwołaniu rezerwacji. W tym wypadku konieczy będzie zwrot kosztów wszytskich biletów. ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DeleteMessage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(800, 466);
            Controls.Add(label1);
            Controls.Add(cancelButton);
            Controls.Add(deleteMovieButton);
            Controls.Add(filmName);
            Controls.Add(pictureBox1);
            Controls.Add(delete_info);
            Name = "DeleteMessage";
            Text = "Usuwanie filmu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label delete_info;
        private PictureBox pictureBox1;
        private Label filmName;
        private FontAwesome.Sharp.IconButton deleteMovieButton;
        private FontAwesome.Sharp.IconButton cancelButton;
        private Label label1;
    }
}