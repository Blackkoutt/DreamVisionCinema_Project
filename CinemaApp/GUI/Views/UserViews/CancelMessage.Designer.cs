namespace GUI.Views.UserViews
{
    partial class CancelMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelMessage));
            pictureBox1 = new PictureBox();
            delete_info = new Label();
            filmName = new Label();
            label1 = new Label();
            deleteMovieButton = new FontAwesome.Sharp.IconButton();
            cancelButton = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.movie_delete;
            pictureBox1.Location = new Point(285, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(247, 154);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 106;
            pictureBox1.TabStop = false;
            // 
            // delete_info
            // 
            delete_info.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            delete_info.ForeColor = SystemColors.Window;
            delete_info.Location = new Point(93, 169);
            delete_info.Name = "delete_info";
            delete_info.Size = new Size(621, 54);
            delete_info.TabIndex = 107;
            delete_info.Text = "Czy napewno chcesz anulować rezerwację na film:";
            delete_info.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // filmName
            // 
            filmName.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            filmName.ForeColor = SystemColors.Window;
            filmName.Location = new Point(38, 213);
            filmName.Name = "filmName";
            filmName.Size = new Size(727, 54);
            filmName.TabIndex = 108;
            filmName.Text = "Nazwa filmu";
            filmName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Montserrat", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(230, 50, 50);
            label1.Location = new Point(0, 267);
            label1.Name = "label1";
            label1.Size = new Size(800, 80);
            label1.TabIndex = 110;
            label1.Text = "[!] Jeśli anulujesz rezerwację bilet zostanie automatycznie usunięty, a środki zostaną zwrócone na konto.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            deleteMovieButton.Location = new Point(144, 367);
            deleteMovieButton.Margin = new Padding(3, 20, 3, 3);
            deleteMovieButton.Name = "deleteMovieButton";
            deleteMovieButton.Size = new Size(236, 51);
            deleteMovieButton.TabIndex = 111;
            deleteMovieButton.Text = "Anuluj rezerwację";
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
            cancelButton.Location = new Point(416, 367);
            cancelButton.Margin = new Padding(3, 20, 3, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(236, 51);
            cancelButton.TabIndex = 112;
            cancelButton.Text = "Cofnij";
            cancelButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // CancelMessage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(800, 466);
            Controls.Add(cancelButton);
            Controls.Add(deleteMovieButton);
            Controls.Add(label1);
            Controls.Add(filmName);
            Controls.Add(delete_info);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(818, 513);
            MinimumSize = new Size(818, 513);
            Name = "CancelMessage";
            Text = "CancelMessage";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label delete_info;
        private Label filmName;
        private Label label1;
        private FontAwesome.Sharp.IconButton deleteMovieButton;
        private FontAwesome.Sharp.IconButton cancelButton;
    }
}