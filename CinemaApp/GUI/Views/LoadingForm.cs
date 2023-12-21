using System.Runtime.InteropServices;

namespace GUI.Views
{
    public partial class LoadingForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int RightRect, int nBottomRect, int nWidthEllipse, int nRightEllipse);
        private int value;
        public LoadingForm()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            this.LoadingProgressBar.Value = 0;
            value = 0;
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            value += 1;

            if (value % 3 == 0)
            {
                this.LoadingProgressBar.Value = value;
            }
            this.LoadingProgressBar.Text = value + "%";

            //LoadingProgressBar.Invalidate();

            if (value == 100)
            {
                timer1.Stop();

                timer1.Interval = 600;
                timer1.Tick -= timer1_Tick;
                timer1.Tick += DelayTimer_Tick;
                timer1.Start();
            }
        }

        private void DelayTimer_Tick(object? sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }
    }
}
