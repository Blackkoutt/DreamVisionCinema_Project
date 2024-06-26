﻿namespace GUI.Views.AdminViews
{
    partial class MostProfitableMoviesView
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
            profitableChart = new OxyPlot.WindowsForms.PlotView();
            label1 = new Label();
            headerMain = new Label();
            backButton = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // profitableChart
            // 
            profitableChart.BackColor = Color.FromArgb(50, 52, 102);
            profitableChart.ForeColor = SystemColors.Window;
            profitableChart.Location = new Point(84, 157);
            profitableChart.Name = "profitableChart";
            profitableChart.PanCursor = Cursors.Hand;
            profitableChart.Size = new Size(1116, 555);
            profitableChart.TabIndex = 2;
            profitableChart.Text = "plotView1";
            profitableChart.ZoomHorizontalCursor = Cursors.SizeWE;
            profitableChart.ZoomRectangleCursor = Cursors.SizeNWSE;
            profitableChart.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // label1
            // 
            label1.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Cyan;
            label1.Location = new Point(164, 78);
            label1.Name = "label1";
            label1.Size = new Size(1036, 36);
            label1.TabIndex = 107;
            label1.Text = "[?] Dochody są zliczane na podstawie sumy cen sprzedanych biletów";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerMain
            // 
            headerMain.Font = new Font("Montserrat", 18F, FontStyle.Regular, GraphicsUnit.Point);
            headerMain.ForeColor = SystemColors.Window;
            headerMain.Location = new Point(164, 24);
            headerMain.Name = "headerMain";
            headerMain.Size = new Size(1036, 54);
            headerMain.TabIndex = 108;
            headerMain.Text = "Poniżej przedstawiono 10 najbardziej dochodowych filmów";
            headerMain.TextAlign = ContentAlignment.MiddleCenter;
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
            backButton.TabIndex = 109;
            backButton.Text = "Wróć";
            backButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            backButton.UseVisualStyleBackColor = false;
            // 
            // MostProfitableMoviesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(1275, 743);
            Controls.Add(backButton);
            Controls.Add(headerMain);
            Controls.Add(label1);
            Controls.Add(profitableChart);
            Name = "MostProfitableMoviesView";
            Text = "MostProfitableMoviesView";
            Resize += MostProfitableMoviesView_Resize;
            ResumeLayout(false);
        }

        #endregion

        private OxyPlot.WindowsForms.PlotView profitableChart;
        private Label label1;
        private Label headerMain;
        private FontAwesome.Sharp.IconButton backButton;
    }
}