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
            passwordLabel = new Label();
            signInButton = new FontAwesome.Sharp.IconButton();
            passwordText = new TextBox();
            showPasswordCheckBox = new CheckBox();
            loginText = new TextBox();
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
            signInButton.Location = new Point(320, 534);
            signInButton.Name = "signInButton";
            signInButton.Size = new Size(163, 51);
            signInButton.TabIndex = 116;
            signInButton.Text = "Zaloguj się";
            signInButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            signInButton.UseVisualStyleBackColor = false;
            // 
            // passwordText
            // 
            passwordText.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            passwordText.Location = new Point(205, 433);
            passwordText.Name = "passwordText";
            passwordText.PasswordChar = '*';
            passwordText.Size = new Size(416, 38);
            passwordText.TabIndex = 117;
            // 
            // showPasswordCheckBox
            // 
            showPasswordCheckBox.AutoSize = true;
            showPasswordCheckBox.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            showPasswordCheckBox.ForeColor = SystemColors.Window;
            showPasswordCheckBox.Location = new Point(205, 477);
            showPasswordCheckBox.Name = "showPasswordCheckBox";
            showPasswordCheckBox.Size = new Size(128, 29);
            showPasswordCheckBox.TabIndex = 118;
            showPasswordCheckBox.Text = "Pokaż hasło";
            showPasswordCheckBox.UseVisualStyleBackColor = true;
            showPasswordCheckBox.CheckedChanged += showPasswordCheckBox_CheckedChanged;
            // 
            // loginText
            // 
            loginText.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            loginText.Location = new Point(205, 337);
            loginText.Name = "loginText";
            loginText.Size = new Size(416, 38);
            loginText.TabIndex = 119;
            // 
            // AdminAuthenticationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(826, 617);
            Controls.Add(loginText);
            Controls.Add(showPasswordCheckBox);
            Controls.Add(passwordText);
            Controls.Add(signInButton);
            Controls.Add(passwordLabel);
            Controls.Add(loginLabel);
            Controls.Add(filmEditlabel);
            Controls.Add(bigLogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminAuthenticationForm";
            Text = "Logowanie";
            ((System.ComponentModel.ISupportInitialize)bigLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox bigLogo;
        private Label filmEditlabel;
        private Label loginLabel;
        private Label passwordLabel;
        private RichTextBox passwordTextView;
        private FontAwesome.Sharp.IconButton signInButton;
        private TextBox passwordText;
        private CheckBox showPasswordCheckBox;
        private TextBox loginText;
    }
}