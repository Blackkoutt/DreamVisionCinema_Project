using CinemaApp.Interfaces;
using GUI.Interfaces;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot.WindowsForms;

namespace GUI.Views.AdminViews
{
    public partial class AdminStatisticView : Form, IAdminStatisticsView
    {
        public AdminStatisticView()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            popularButton.Click += delegate { mostPopularClickEvent?.Invoke(this, EventArgs.Empty); };
            profitableButton.Click += delegate { mostProfitableClickEvent?.Invoke(this, EventArgs.Empty); };

        }
        public Label Earings
        {
            get { return this.earningsLabel; }
        }
        public Label Guideline
        {
            get { return this.guidelineLabel; }
        }
        public CircularProgressBar.CircularProgressBar Progress
        {
            get { return this.progressBar; }
        }

        public event EventHandler mostPopularClickEvent;
        public event EventHandler mostProfitableClickEvent;
    }
}
