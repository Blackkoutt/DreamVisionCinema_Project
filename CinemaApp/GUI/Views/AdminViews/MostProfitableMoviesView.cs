using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using GUI.Interfaces;
using FontAwesome.Sharp;

namespace GUI.Views.AdminViews
{
    public partial class MostProfitableMoviesView : Form, IProfitableMovies
    {
        // Wartości odrazu są inicjowane ponieważ na początek wywołuje się metoda Resize jeszcze przez załadowaniem formularza
        private Rectangle orignialFormSize = new Rectangle(
            new Point(0, 0),
            new Size(1293, 790)
            );
        private Rectangle backButtonSize = new Rectangle(
            new Point(42, 49),
            new Size(119, 51)
            );
        private Rectangle headerMainSize = new Rectangle(
            new Point(164, 24),
            new Size(1036, 54)
            );
        private Rectangle SubtitleSize = new Rectangle(
            new Point(164, 78),
            new Size(1036, 36)
            );
        private Rectangle popularChartSize = new Rectangle(
            new Point(84, 157),
            new Size(1116, 555)
            );


        // Oryginalne rozmiary czcionek
        private int iconSize = 34;
        private float buttonFont = 12f;
        private float headerFont = 18f;

        public MostProfitableMoviesView(Dictionary<string, double> data)
        {
            // Formularz znajduje się wewnątrz innego formularza
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            InitializeComponent();

            backButton.Click += delegate { BackFromProfitableMovies?.Invoke(this, EventArgs.Empty); };

            PrepareChart(data);
        }

        public event EventHandler BackFromProfitableMovies;


        // Metoda przygotowująca wykres
        public void PrepareChart(Dictionary<string, double> data)
        {
            // Utwórz model i osie
            var model = new PlotModel
            {
                Title = "Najbardziej dochodowe filmy",
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
                Title = "Dochód ($)",
                TitleFontWeight = FontWeights.Bold,
                TitleFontSize = 16,
                MajorGridlineStyle = LineStyle.Dash,
                MajorGridlineColor = OxyColors.White
            };
            var barSeries = new BarSeries
            {
                FillColor = OxyColor.FromRgb(7, 146, 232)
            };

            // Dodaj dane do serii słupków
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
            profitableChart.Model = model;
        }


        // Metoda zmieniająca rozmiar kontrolki i jej czcionki
        private void resizeControl(Rectangle r, Control c, float? originalFontSize)
        {
            float xRatio = (float)(this.Width) / (float)(orignialFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(orignialFormSize.Height);

            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);

            c.Size = new Size(newWidth, newHeight);
            float ratio = xRatio;
            if (xRatio >= yRatio)
            {
                ratio = yRatio;
            }
            if (originalFontSize != null)
            {
                float newFontSize = (float)(originalFontSize * ratio);
                if (newFontSize > 0 && newFontSize != float.NegativeInfinity && newFontSize != float.PositiveInfinity)
                {
                    Font newFont = new Font(c.Font.FontFamily, newFontSize);
                    if (c is IconButton)
                    {
                        newFont = new Font(c.Font.FontFamily, newFontSize, FontStyle.Bold);
                    }

                    c.Font = newFont;
                }
            }
            if (c is IconButton)
            {
                int newIconSize = (int)(iconSize * ratio);
                ((IconButton)c).IconSize = newIconSize;
            }
        }


        // Metoda wywoływana automatycznie w przypadku zmiany rozmiaru okna 
        private void MostProfitableMoviesView_Resize(object sender, EventArgs e)
        {
            resizeControl(backButtonSize, this.backButton, buttonFont);
            resizeControl(headerMainSize, this.headerMain, headerFont);
            resizeControl(SubtitleSize, this.label1, buttonFont);
            resizeControl(popularChartSize, this.profitableChart, null);
        }
    }
}
