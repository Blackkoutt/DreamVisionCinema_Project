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
        public AdminStatisticView(IReservationRepository reservationRepository)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            Dictionary<string, int> data = reservationRepository.GetMostPopularMovies();
            data = data.Take(10).ToDictionary(pair => pair.Key, pair => pair.Value);
            data = new Dictionary<string, int> { { "", 0 } }.Concat(data).ToDictionary(pair => pair.Key, pair => pair.Value);

            PrepareChart(data);


        }
        public void PrepareChart(Dictionary<string, int> data)
        {
            // Utwórz model i osie
            var model = new PlotModel
            {
                Title = "Najpopularniejsze filmy",
                TextColor = OxyColors.White,
                PlotAreaBorderColor = OxyColors.White
            };
            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                Minimum = 0,
                Title = "Tytuł filmu",
                TitleFontWeight = FontWeights.Bold,
                TitleFontSize = 16,
                FontSize = 14,
                TicklineColor = OxyColors.White,
                TextColor = OxyColors.White,

            };
            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                TicklineColor = OxyColors.White,
                FontSize = 14,
                TextColor = OxyColors.White,
                Title = "Ilość zarezerwowanych miejsc",
                TitleFontWeight = FontWeights.Bold,
                TitleFontSize = 16,
                MajorGridlineStyle = LineStyle.Dash, // Opcjonalnie, ustaw styl linii siatki
                MajorGridlineColor = OxyColors.White
            };


            // Dodaj dane do serii słupków
            var barSeries = new BarSeries
            {
                FillColor = OxyColor.FromRgb(7, 146, 232)
            };
            foreach (var item in data)
            {
                categoryAxis.Labels.Add(item.Key);
                barSeries.Items.Add(new BarItem(item.Value));
            }

            // Dodaj osie i serię do modelu
            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);
            model.Series.Add(barSeries);

            // Dodaj model do kontrolki OxyPlot.WindowsForms.PlotView
            popularChart.Model = model;
        }

    }
}
