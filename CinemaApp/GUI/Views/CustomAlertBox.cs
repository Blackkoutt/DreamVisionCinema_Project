namespace GUI.Views
{
    public partial class CustomAlertBox : Form
    {
        private bool isTimerEnabled;
        public CustomAlertBox(bool isTimerEnabled)
        {
            InitializeComponent();
            this.isTimerEnabled = isTimerEnabled;
        }
        public enum enumAction
        {
            wait,
            start,
            close
        }
        public enum enmType
        {
            Success,
            Error,
            Info
        }
        private CustomAlertBox.enumAction action;
        private int x, y;
        public void ShowAlert(string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;
            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                CustomAlertBox frm = (CustomAlertBox)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i;
                    this.Location = new Point(x, y);
                    break;
                }
            }
            x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Success:
                    {
                        this.iconMessage.IconChar = FontAwesome.Sharp.IconChar.Check;
                        this.BackColor = Color.SeaGreen;
                        break;
                    }
                case enmType.Error:
                    {
                        this.iconMessage.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
                        this.BackColor = Color.DarkRed;
                        break;
                    }
                case enmType.Info:
                    {
                        this.iconMessage.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
                        this.BackColor = Color.RoyalBlue;
                        break;
                    }
            }

            this.Message.Text = msg;
            Show();
            if (isTimerEnabled)
            {
                this.action = enumAction.start;
                this.timer1.Interval = 1;
                timer1.Start();
                
            }
            else
            {
                this.Opacity = 1.0;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enumAction.close;
            if (!isTimerEnabled)
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enumAction.wait:
                    {
                        timer1.Interval = 5000;
                        action = enumAction.close;
                        break;
                    }
                case enumAction.start:
                    {
                        timer1.Interval = 1;
                        this.Opacity += 0.1;
                        if (this.x < this.Location.X)
                        {
                            this.Left--;
                        }
                        else
                        {
                            if (this.Opacity == 1.0)
                            {
                                action = enumAction.wait;
                            }
                        }
                        break;
                    }
                case enumAction.close:
                    {
                        timer1.Interval = 1;
                        this.Opacity -= 0.1;

                        this.Left -= 3;
                        if (base.Opacity == 0.0)
                        {
                            base.Close();
                        }
                        break;
                    }
            }
        }
    }
}
