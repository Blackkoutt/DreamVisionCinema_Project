namespace GUI.Views.AdminViews
{
    partial class MostPopularMoviesView
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
            popularChart = new OxyPlot.WindowsForms.PlotView();
            filmEditlabel = new Label();
            label1 = new Label();
            backButton = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // popularChart
            // 
            popularChart.BackColor = Color.FromArgb(50, 52, 102);
            popularChart.ForeColor = SystemColors.Window;
            popularChart.Location = new Point(84, 157);
            popularChart.Name = "popularChart";
            popularChart.PanCursor = Cursors.Hand;
            popularChart.Size = new Size(1116, 555);
            popularChart.TabIndex = 1;
            popularChart.Text = "plotView1";
            popularChart.ZoomHorizontalCursor = Cursors.SizeWE;
            popularChart.ZoomRectangleCursor = Cursors.SizeNWSE;
            popularChart.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // filmEditlabel
            // 
            filmEditlabel.Font = new Font("Montserrat", 18F, FontStyle.Regular, GraphicsUnit.Point);
            filmEditlabel.ForeColor = SystemColors.Window;
            filmEditlabel.Location = new Point(164, 24);
            filmEditlabel.Name = "filmEditlabel";
            filmEditlabel.Size = new Size(1036, 54);
            filmEditlabel.TabIndex = 105;
            filmEditlabel.Text = "Poniżej przedstawiono 10 najpopularniejszych filmów";
            filmEditlabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Cyan;
            label1.Location = new Point(164, 78);
            label1.Name = "label1";
            label1.Size = new Size(1036, 36);
            label1.TabIndex = 106;
            label1.Text = "[?] Popularność jest mierzona poprzez ilość zajętych miejsc na dany film";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // backButton
            // 
            backButton.BackColor = Color.FromArgb(7, 146, 232);
            backButton.Cursor = Cursors.Hand;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            backButton.ForeColor = SystemColors.Window;
            backButton.IconChar = FontAwesome.Sharp.IconChar.LeftLong;
            backButton.IconColor = SystemColors.Window;
            backButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            backButton.IconSize = 34;
            backButton.Location = new Point(42, 49);
            backButton.Margin = new Padding(3, 20, 3, 3);
            backButton.Name = "backButton";
            backButton.Size = new Size(119, 51);
            backButton.TabIndex = 107;
            backButton.Text = "Wróć";
            backButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            backButton.UseVisualStyleBackColor = false;
            // 
            // MostPopularMoviesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(1275, 743);
            Controls.Add(backButton);
            Controls.Add(label1);
            Controls.Add(filmEditlabel);
            Controls.Add(popularChart);
            Name = "MostPopularMoviesView";
            Text = "MostPopularMoviesView";
            ResumeLayout(false);
        }

        #endregion

        private OxyPlot.WindowsForms.PlotView popularChart;
        private Label filmEditlabel;
        private Label label1;
        private FontAwesome.Sharp.IconButton backButton;
    }
}