namespace GUI.Views.UserViews
{
    partial class MovieReservationView
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
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            seatsLabel = new Label();
            undoButton = new FontAwesome.Sharp.IconButton();
            buyTicketButton = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(104, 105, 104);
            panel1.Location = new Point(46, 116);
            panel1.Name = "panel1";
            panel1.Size = new Size(1286, 36);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.Font = new Font("Montserrat", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(398, 9);
            label1.Name = "label1";
            label1.Size = new Size(626, 54);
            label1.TabIndex = 102;
            label1.Text = "Wybierz interesujące cię miejsca w sali";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Montserrat", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Window;
            label2.Location = new Point(301, 59);
            label2.Name = "label2";
            label2.Size = new Size(91, 54);
            label2.TabIndex = 103;
            label2.Text = "Kolorem";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Font = new Font("Montserrat", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(189, 2, 2);
            label3.Location = new Point(383, 59);
            label3.Name = "label3";
            label3.Size = new Size(119, 54);
            label3.TabIndex = 104;
            label3.Text = "czerwonym";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Font = new Font("Montserrat", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Window;
            label4.Location = new Point(497, 59);
            label4.Name = "label4";
            label4.Size = new Size(316, 54);
            label4.TabIndex = 105;
            label4.Text = "zostały oznaczone miejsca zajęte.";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Font = new Font("Montserrat", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.Window;
            label5.Location = new Point(809, 59);
            label5.Name = "label5";
            label5.Size = new Size(91, 54);
            label5.TabIndex = 106;
            label5.Text = "Kolorem";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Font = new Font("Montserrat", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.FromArgb(9, 133, 20);
            label6.Location = new Point(893, 59);
            label6.Name = "label6";
            label6.Size = new Size(104, 54);
            label6.TabIndex = 107;
            label6.Text = "zielonym";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Font = new Font("Montserrat", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Window;
            label7.Location = new Point(984, 59);
            label7.Name = "label7";
            label7.Size = new Size(147, 54);
            label7.TabIndex = 108;
            label7.Text = "miejsca wolne.";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Font = new Font("Montserrat", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.Window;
            label8.Location = new Point(13, 683);
            label8.Name = "label8";
            label8.Size = new Size(281, 54);
            label8.TabIndex = 109;
            label8.Text = "Wybrane miejsca:";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // seatsLabel
            // 
            seatsLabel.Font = new Font("Montserrat", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            seatsLabel.ForeColor = SystemColors.Window;
            seatsLabel.Location = new Point(277, 683);
            seatsLabel.Name = "seatsLabel";
            seatsLabel.Size = new Size(670, 54);
            seatsLabel.TabIndex = 110;
            seatsLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // undoButton
            // 
            undoButton.BackColor = Color.FromArgb(217, 145, 2);
            undoButton.FlatAppearance.BorderSize = 0;
            undoButton.FlatStyle = FlatStyle.Flat;
            undoButton.Font = new Font("Montserrat", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            undoButton.ForeColor = SystemColors.Window;
            undoButton.IconChar = FontAwesome.Sharp.IconChar.ArrowLeftLong;
            undoButton.IconColor = SystemColors.Window;
            undoButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            undoButton.IconSize = 38;
            undoButton.Location = new Point(993, 681);
            undoButton.Name = "undoButton";
            undoButton.Size = new Size(165, 56);
            undoButton.TabIndex = 111;
            undoButton.Text = "Cofnij wybór";
            undoButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            undoButton.UseVisualStyleBackColor = false;
            // 
            // buyTicketButton
            // 
            buyTicketButton.BackColor = Color.FromArgb(145, 52, 237);
            buyTicketButton.FlatAppearance.BorderSize = 0;
            buyTicketButton.FlatStyle = FlatStyle.Flat;
            buyTicketButton.Font = new Font("Montserrat", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buyTicketButton.ForeColor = SystemColors.Window;
            buyTicketButton.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            buyTicketButton.IconColor = SystemColors.Window;
            buyTicketButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buyTicketButton.IconSize = 38;
            buyTicketButton.Location = new Point(1201, 681);
            buyTicketButton.Name = "buyTicketButton";
            buyTicketButton.Size = new Size(165, 56);
            buyTicketButton.TabIndex = 112;
            buyTicketButton.Text = "Kup bilet";
            buyTicketButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            buyTicketButton.UseVisualStyleBackColor = false;
            // 
            // MovieReservationView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(1421, 770);
            Controls.Add(buyTicketButton);
            Controls.Add(undoButton);
            Controls.Add(seatsLabel);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            MaximumSize = new Size(1439, 817);
            MinimumSize = new Size(1439, 817);
            Name = "MovieReservationView";
            Text = "Wybór miejsca";
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label seatsLabel;
        private FontAwesome.Sharp.IconButton undoButton;
        private FontAwesome.Sharp.IconButton buyTicketButton;
    }
}