namespace GUI.Views
{
    partial class AdminAuthenticationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminAuthenticationForm));
            bigLogo = new PictureBox();
            filmEditlabel = new Label();
            loginLabel = new Label();
            loginTextView = new RichTextBox();
            passwordLabel = new Label();
            passwordTextView = new RichTextBox();
            signInButton = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)bigLogo).BeginInit();
            SuspendLayout();
            // 
            // bigLogo
            // 
            bigLogo.Anchor = AnchorStyles.None;
            bigLogo.Image = Properties.Resources.logo;
            bigLogo.Location = new Point(209, 7);
            bigLogo.Name = "bigLogo";
            bigLogo.Size = new Size(416, 203);
            bigLogo.SizeMode = PictureBoxSizeMode.Zoom;
            bigLogo.TabIndex = 3;
            bigLogo.TabStop = false;
            // 
            // filmEditlabel
            // 
            filmEditlabel.Font = new Font("Montserrat", 18F, FontStyle.Regular, GraphicsUnit.Point);
            filmEditlabel.ForeColor = SystemColors.Window;
            filmEditlabel.Location = new Point(168, 218);
            filmEditlabel.Name = "filmEditlabel";
            filmEditlabel.Size = new Size(464, 54);
            filmEditlabel.TabIndex = 107;
            filmEditlabel.Text = "Podaj dane logowania:";
            filmEditlabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // loginLabel
            // 
            loginLabel.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            loginLabel.ForeColor = SystemColors.Window;
            loginLabel.Location = new Point(205, 300);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(90, 34);
            loginLabel.TabIndex = 108;
            loginLabel.Text = "Login:";
            loginLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // loginTextView
            // 
            loginTextView.BackColor = SystemColors.Window;
            loginTextView.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            loginTextView.Location = new Point(205, 337);
            loginTextView.Name = "loginTextView";
            loginTextView.Size = new Size(416, 37);
            loginTextView.TabIndex = 109;
            loginTextView.Text = "";
            // 
            // passwordLabel
            // 
            passwordLabel.Font = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            passwordLabel.ForeColor = SystemColors.Window;
            passwordLabel.Location = new Point(205, 396);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(90, 34);
            passwordLabel.TabIndex = 110;
            passwordLabel.Text = "Hasło:";
            passwordLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // passwordTextView
            // 
            passwordTextView.BackColor = SystemColors.Window;
            passwordTextView.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            passwordTextView.Location = new Point(205, 433);
            passwordTextView.Name = "passwordTextView";
            passwordTextView.Size = new Size(416, 37);
            passwordTextView.TabIndex = 111;
            passwordTextView.Text = "";
            // 
            // signInButton
            // 
            signInButton.BackColor = Color.FromArgb(50, 168, 82);
            signInButton.Cursor = Cursors.Hand;
            signInButton.FlatAppearance.BorderSize = 0;
            signInButton.FlatStyle = FlatStyle.Flat;
            signInButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            signInButton.ForeColor = SystemColors.Window;
            signInButton.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            signInButton.IconColor = SystemColors.Window;
            signInButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            signInButton.IconSize = 34;
            signInButton.Location = new Point(321, 525);
            signInButton.Name = "signInButton";
            signInButton.Size = new Size(163, 51);
            signInButton.TabIndex = 116;
            signInButton.Text = "Zaloguj się";
            signInButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            signInButton.UseVisualStyleBackColor = false;
            // 
            // AdminAuthenticationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(826, 617);
            Controls.Add(signInButton);
            Controls.Add(passwordTextView);
            Controls.Add(passwordLabel);
            Controls.Add(loginTextView);
            Controls.Add(loginLabel);
            Controls.Add(filmEditlabel);
            Controls.Add(bigLogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminAuthenticationForm";
            Text = "Logowanie";
            ((System.ComponentModel.ISupportInitialize)bigLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox bigLogo;
        private Label filmEditlabel;
        private Label loginLabel;
        private RichTextBox loginTextView;
        private Label passwordLabel;
        private RichTextBox passwordTextView;
        private FontAwesome.Sharp.IconButton signInButton;
    }
}