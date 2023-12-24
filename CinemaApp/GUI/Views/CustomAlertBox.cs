namespace GUI.Views
{
    public partial class CustomAlertBox : Form
    {
        // Flaga informująca czy timer powinien działać (czy powiadomienie powinno znikać po danym upływie czasu)
        private bool isTimerEnabled;
        public CustomAlertBox(bool isTimerEnabled)
        {
            InitializeComponent();
            this.isTimerEnabled = isTimerEnabled;
        }

        // Enum dla określenia akcji wykonywanej przez timer
        public enum enumAction
        {
            wait,
            start,
            close
        }

        // Enum dla określenia typu powiadomienia
        public enum enmType
        {
            Success,
            Error,
            Info
        }
        private CustomAlertBox.enumAction action;
        private int x, y;

        

        // Metoda wyświetlająca Alert 
        public void ShowAlert(string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;
            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                CustomAlertBox frm = (CustomAlertBox)Application.OpenForms[fname];

                // Ustalenie punktu w którym ma pojawić się powiadomienie
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


            // Ustawienie właściwości formularza zależnie od typu powiadomienia
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

            // Jeśli timer jest włączony rozpocznij odliczanie do schowania się powiadomienia
            if (isTimerEnabled)
            {
                this.action = enumAction.start;
                this.timer1.Interval = 1;
                timer1.Start();

            }

            // W przeciwnym wypadku tylko wyśweitl powiadomienie
            else
            {
                this.Opacity = 1.0;
            }
        }

        // Metoda obsługująca zamknięcie powiadomienia
        private void closeButton_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enumAction.close;
            if (!isTimerEnabled)
            {
                timer1.Start();
            }
        }


        // Metoda wywoływana w każdym cyklu timera
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                // Zaczekaj 5 sekund po pokazaniu powiadomienia
                case enumAction.wait:
                    {
                        timer1.Interval = 5000;
                        action = enumAction.close;
                        break;
                    }

                // Pokaż powiadomienie
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

                // Ukryj powiadomienie
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