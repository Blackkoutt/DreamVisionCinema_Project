namespace GUI.Views
{
    partial class CustomAlertBox
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
            components = new System.ComponentModel.Container();
            Message = new Label();
            closeButton = new FontAwesome.Sharp.IconButton();
            iconMessage = new FontAwesome.Sharp.IconPictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)iconMessage).BeginInit();
            SuspendLayout();
            // 
            // Message
            // 
            Message.ForeColor = SystemColors.Window;
            Message.Location = new Point(95, 11);
            Message.Name = "Message";
            Message.Size = new Size(512, 56);
            Message.TabIndex = 0;
            Message.Text = "Message Text";
            Message.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // closeButton
            // 
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.ForeColor = SystemColors.Window;
            closeButton.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            closeButton.IconColor = SystemColors.Window;
            closeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            closeButton.Location = new Point(616, 15);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(48, 52);
            closeButton.TabIndex = 1;
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // iconMessage
            // 
            iconMessage.Anchor = AnchorStyles.None;
            iconMessage.BackColor = Color.Transparent;
            iconMessage.ForeColor = SystemColors.Window;
            iconMessage.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            iconMessage.IconColor = SystemColors.Window;
            iconMessage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMessage.IconSize = 66;
            iconMessage.Location = new Point(12, 5);
            iconMessage.Name = "iconMessage";
            iconMessage.Size = new Size(77, 66);
            iconMessage.SizeMode = PictureBoxSizeMode.Zoom;
            iconMessage.TabIndex = 2;
            iconMessage.TabStop = false;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // CustomAlertBox
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(676, 84);
            Controls.Add(iconMessage);
            Controls.Add(closeButton);
            Controls.Add(Message);
            Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomAlertBox";
            Text = "CustomAlertBox";
            ((System.ComponentModel.ISupportInitialize)iconMessage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label Message;
        private FontAwesome.Sharp.IconButton closeButton;
        private FontAwesome.Sharp.IconPictureBox iconMessage;
        private System.Windows.Forms.Timer timer1;
    }
}