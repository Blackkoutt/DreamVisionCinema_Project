namespace GUI.Views
{
    partial class ModeSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModeSelectionForm));
            bigLogo = new PictureBox();
            filmEditlabel = new Label();
            label1 = new Label();
            adminButton = new FontAwesome.Sharp.IconButton();
            userButton = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)bigLogo).BeginInit();
            SuspendLayout();
            // 
            // bigLogo
            // 
            bigLogo.Anchor = AnchorStyles.None;
            bigLogo.Image = Properties.Resources.logo;
            bigLogo.Location = new Point(215, 12);
            bigLogo.Name = "bigLogo";
            bigLogo.Size = new Size(416, 203);
            bigLogo.SizeMode = PictureBoxSizeMode.Zoom;
            bigLogo.TabIndex = 2;
            bigLogo.TabStop = false;
            // 
            // filmEditlabel
            // 
            filmEditlabel.Font = new Font("Montserrat", 18F, FontStyle.Regular, GraphicsUnit.Point);
            filmEditlabel.ForeColor = SystemColors.Window;
            filmEditlabel.Location = new Point(180, 218);
            filmEditlabel.Name = "filmEditlabel";
            filmEditlabel.Size = new Size(464, 54);
            filmEditlabel.TabIndex = 106;
            filmEditlabel.Text = "Witaj w DreamVisionCinema";
            filmEditlabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Cyan;
            label1.Location = new Point(180, 284);
            label1.Name = "label1";
            label1.Size = new Size(464, 54);
            label1.TabIndex = 107;
            label1.Text = "Wybierz tryb działania aplikacji";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // adminButton
            // 
            adminButton.BackColor = Color.FromArgb(58, 56, 128);
            adminButton.FlatAppearance.BorderSize = 0;
            adminButton.FlatStyle = FlatStyle.Flat;
            adminButton.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            adminButton.ForeColor = SystemColors.Window;
            adminButton.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            adminButton.IconColor = SystemColors.Window;
            adminButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            adminButton.IconSize = 68;
            adminButton.Location = new Point(59, 375);
            adminButton.Name = "adminButton";
            adminButton.Size = new Size(333, 179);
            adminButton.TabIndex = 108;
            adminButton.Text = "Zaloguj się jako Administrator";
            adminButton.TextImageRelation = TextImageRelation.ImageAboveText;
            adminButton.UseVisualStyleBackColor = false;
            // 
            // userButton
            // 
            userButton.BackColor = Color.FromArgb(58, 56, 128);
            userButton.FlatAppearance.BorderSize = 0;
            userButton.FlatStyle = FlatStyle.Flat;
            userButton.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            userButton.ForeColor = SystemColors.Window;
            userButton.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            userButton.IconColor = SystemColors.Window;
            userButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            userButton.IconSize = 68;
            userButton.Location = new Point(449, 375);
            userButton.Name = "userButton";
            userButton.Size = new Size(333, 179);
            userButton.TabIndex = 109;
            userButton.Text = "Zaloguj się jako Użytkownik";
            userButton.TextImageRelation = TextImageRelation.ImageAboveText;
            userButton.UseVisualStyleBackColor = false;
            // 
            // ModeSelectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(842, 604);
            Controls.Add(userButton);
            Controls.Add(adminButton);
            Controls.Add(label1);
            Controls.Add(filmEditlabel);
            Controls.Add(bigLogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ModeSelectionForm";
            Text = "DreamVisionCinema";
            ((System.ComponentModel.ISupportInitialize)bigLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox bigLogo;
        private Label filmEditlabel;
        private Label label1;
        private FontAwesome.Sharp.IconButton adminButton;
        private FontAwesome.Sharp.IconButton userButton;
    }
}