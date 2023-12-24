using FontAwesome.Sharp;
using GUI.Interfaces;

namespace GUI.Views.AdminViews
{
    public partial class AdminStatisticView : Form, IAdminStatisticsView
    {

        // Wartości odrazu są inicjowane ponieważ na początek wywołuje się metoda Resize jeszcze przez załadowaniem formularza
        private Rectangle orignialFormSize = new Rectangle(
            new Point(0, 0),
            new Size(1476, 908)
            );
        private Rectangle earningsSize = new Rectangle(
            new Point(134, 136),
            new Size(586, 239)
            );
        private Rectangle panelSize = new Rectangle(
            new Point(769, 136),
            new Size(586, 239)
            );
        private Rectangle popularButtonSize = new Rectangle(
           new Point(134, 426),
           new Size(586, 372)
           );
        private Rectangle profitableButtonSize = new Rectangle(
           new Point(769, 426),
           new Size(586, 372)
           );
        private Rectangle pictureBoxEarnings = new Rectangle(
           new Point(445, 52),
           new Size(135, 124)
           );
        private Rectangle earningsLabelSize = new Rectangle(
           new Point(17, 44),
           new Size(415, 50)
           );
        private Rectangle earningsLabelTextSize = new Rectangle(
           new Point(45, 93),
           new Size(359, 85)
           );
        private Rectangle progressBarSize = new Rectangle(
           new Point(20, 50),
           new Size(150, 150)
           );
        private Rectangle progressBarLabelSize = new Rectangle(
           new Point(190, 55),
           new Size(380, 43)
           );
        private Rectangle progressBarLabelTextSize = new Rectangle(
           new Point(190, 103),
           new Size(350, 75)
           );


        // Oryginalne rozmiary czcionek
        private float labelFont = 19f;
        private float labelTextFont = 27f;
        private int orginalMoneyIconSize = 142;

        public AdminStatisticView()
        {
            InitializeComponent();

            // Formularz znajduje się wewnątrz innego formularza
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            popularButton.Click += delegate { mostPopularClickEvent?.Invoke(this, EventArgs.Empty); };
            profitableButton.Click += delegate { mostProfitableClickEvent?.Invoke(this, EventArgs.Empty); };
        }


        public event EventHandler mostPopularClickEvent;
        public event EventHandler mostProfitableClickEvent;

        public Label Earings
        {
            get { return this.earningsLabelText; }
        }
        public Label Guideline
        {
            get { return this.guidelineLabel; }
        }
        public CircularProgressBar.CircularProgressBar Progress
        {
            get { return this.progressBar; }
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
            if (c is IconPictureBox)
            {
                int newIconSize = (int)(orginalMoneyIconSize * ratio);
                ((IconPictureBox)c).IconSize = newIconSize;
            }
            if (c is IconButton)
            {
                int newIconSize = (int)(orginalMoneyIconSize * ratio);
                ((IconButton)c).IconSize = newIconSize;
            }
        }


        // Metoda wywoływana automatycznie w przypadku zmiany rozmiaru okna 
        private void AdminStatisticView_Resize(object sender, EventArgs e)
        {
            resizeControl(earningsSize, this.earningsPanel, null);
            resizeControl(panelSize, this.panel1, null);
            resizeControl(popularButtonSize, this.popularButton, labelFont);
            resizeControl(profitableButtonSize, this.profitableButton, labelFont);
            resizeControl(pictureBoxEarnings, this.iconPictureBox1, null);
            resizeControl(earningsLabelSize, this.earnigsLabel, labelFont);
            resizeControl(earningsLabelTextSize, this.earningsLabelText, labelTextFont);
            resizeControl(progressBarSize, this.progressBar, null);
            resizeControl(progressBarLabelSize, this.label3, labelFont);
            resizeControl(progressBarLabelTextSize, this.guidelineLabel, labelTextFont);
        }
    }
}
