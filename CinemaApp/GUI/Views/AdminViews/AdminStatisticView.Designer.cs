
namespace GUI.Views.AdminViews
{
    partial class AdminStatisticView
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
            SuspendLayout();
            // 
            // popularChart
            // 
            popularChart.BackColor = Color.FromArgb(50, 52, 102);
            popularChart.ForeColor = SystemColors.Window;
            popularChart.Location = new Point(39, 131);
            popularChart.Name = "popularChart";
            popularChart.PanCursor = Cursors.Hand;
            popularChart.Size = new Size(1191, 612);
            popularChart.TabIndex = 0;
            popularChart.Text = "plotView1";
            popularChart.ZoomHorizontalCursor = Cursors.SizeWE;
            popularChart.ZoomRectangleCursor = Cursors.SizeNWSE;
            popularChart.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // AdminStatisticView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 35, 68);
            ClientSize = new Size(1438, 841);
            Controls.Add(popularChart);
            Name = "AdminStatisticView";
            Text = "AdminStatisticView";
            ResumeLayout(false);
        }

        #endregion

        private OxyPlot.WindowsForms.PlotView popularChart;
    }
}