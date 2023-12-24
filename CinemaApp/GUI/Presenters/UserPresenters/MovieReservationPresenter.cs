using CinemaApp.Enums;
using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Model;
using FontAwesome.Sharp;
using GUI.Interfaces;
using GUI.Views;
using System.Data;
using System.Drawing.Imaging;

namespace GUI.Presenters.UserPresenters
{
    public class MovieReservationPresenter
    {
        private IMovieReservationView _movieReservationView;

        private IReservationRepository _reservationRepository;
        private Movie movie;
        private Seat[] seats;
        private List<Seat> seatList;
        private List<IconButton> buttonsList;
        public MovieReservationPresenter(IMovieReservationView movieReservationView, IReservationRepository reservationRepository, Movie movie) 
        {
            seatList = new List<Seat>();
            buttonsList = new List<IconButton>();
            _movieReservationView = movieReservationView;
            _reservationRepository = reservationRepository;
            this.movie = movie;
            seats = movie.Room.Seats;

            // Dodanie obsługi wciśnięcia przycisków Kup bilet oraz cofnij
            _movieReservationView.Undo += Undo;
            _movieReservationView.BuyTicket += BuyTicket;

            // Utworzenie przycisków reprezentujących miejsca w sali kinowej
            CreateSeatsButtons();

            // Dodanie tytułu oraz podtytułu widoku
            SetTitleAndSubtitle();

            // Pokazanie widoku
            _movieReservationView.Show();
        }


        // Metoda ustawiająca tytuł i podtytuł widoku
        private void SetTitleAndSubtitle()
        {
            _movieReservationView.SubTitle = $"Wybierz interesujące cię miejsca w sali - film \"{movie.Title}\"";
            _movieReservationView.Title = $"Wybór miejsca - film \"{movie.Title}\"";
        }

        // Metoda tworząca powiadomienie (Success, Info, Error)
        private void MakeAlert(string msg, CustomAlertBox.enmType type)
        {
            CustomAlertBox customAlertBox = new CustomAlertBox(true);
            customAlertBox.ShowAlert(msg, type);
            customAlertBox.BringToFront();
        }

        // Metoda obsługująca wciśnięcie przycisku "Kup bilet"
        private async void BuyTicket(object? sender, EventArgs e)
        {
            // Metoda wywoła się jeśli wybrano jakiekolwiek miejsce w sali
            if (seatList.Any())
            {
                // Pobranie listy wybranych miejsc
                List<string> seatStringList = seatList.Select(seat => seat.Number.ToString()).ToList();

                try
                {
                    // Utworzenie rezerwacji na danych film na wybrane miejsca
                    _reservationRepository.MakeReservation(null, movie.Id.ToString(), seatStringList);
                }
                catch (CannotConvertException CCE)
                {
                    MakeAlert(CCE.Message, CustomAlertBox.enmType.Error);
                    return;
                }
                catch(NoMovieWithGivenIdException NMWGIE)
                {
                    MakeAlert(NMWGIE.Message, CustomAlertBox.enmType.Error);
                    return;
                }
                catch(NoSeatWithGivenNumberException NSWGNE)
                {
                    MakeAlert(NSWGNE.Message, CustomAlertBox.enmType.Error);
                    return;
                }
                catch(SeatIsNotAvailableException SINAE)
                {
                    MakeAlert(SINAE.Message, CustomAlertBox.enmType.Error);
                    return;
                }
                catch(Exception ex)
                {
                    MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                    return;
                }


                // Wyczyszczenie widoku reprezentacji sali kinowej
                Control.ControlCollection controls = _movieReservationView.GetControls();
                controls.Clear();

                Form buyTicketForm = (Form)_movieReservationView;

                buyTicketForm.Text = "Drukowanie biletu";   // Dodanie nowej nazwy formularza

                PictureBox pictureBox = createPrinterPictureBox();  // Utworzenie obrazka GIF z drukarką

                Label label = createLabel();    // Utworzenie tytułu (labela)

                // Dodanie kontrolek
                controls.Add(pictureBox);
                controls.Add(label);

                await Task.Delay(5000); // Oczekiwanie 5 sekund przed dalszym wykonaniem funkcji

                
                controls.Clear();   // Ponowne wyczyszczenie widoku
                buyTicketForm.Text = "Twój bilet";  // Ponowna zmiana nazwy formularza

                // Fonty
                Font smallFont = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
                Font bigFont = new Font("Montserrat", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point);
                Font mediumFont = new Font("Montserrat", 16.2F, FontStyle.Regular, GraphicsUnit.Point);

                PictureBox ticket_template = CreateTicket(controls);    // Utworzenie templatki biletu
                Control.ControlCollection tt_controls = ticket_template.Controls;   // Pobranie kontrolek z templatki

                // Pobranie ostatniej rezerwacji (tej właśnie dokonanej)
                Reservation res;
                try
                {
                    res = _reservationRepository.GetLastReservation();
                }
                catch(ReservationListIsEmptyException RLIEE)
                {
                    MakeAlert(RLIEE.Message, CustomAlertBox.enmType.Error);
                    return;
                }
                catch(Exception ex)
                {
                    MakeAlert(ex.Message, CustomAlertBox.enmType.Error);
                    return;
                }
                
                // Przygotowanie odpowiednich labeli informacyjnych
                string info_header = "Oto twój bilet na film";
                string fileName = res.Ticket.Id + "_" + movie.Title + ".jpg";
                string info_subtitle = $"Bilet został zapisany w: GUI\\bin\\Debug\\net7.0-windows\\TicketsJPG\\{fileName}";
                CreateTicketLabel(controls, mediumFont, new Point(398, 29), "ticket_info_header", new Size(626, 54), 121, info_header);
                CreateTicketLabel(controls, smallFont, new Point(13, 683), "ticket_info_subtitle", new Size(1413, 54), 122, info_subtitle);

                // Przygotowanie labeli do uzupełnienia templatki biletu
                List<Label> labels = new List<Label>();
                string price = res.Ticket.CalculatePrice(movie.Price, seatList.Count).ToString();
                Label labelInPictureBox = CreateTicketLabel(tt_controls, bigFont, new Point(258, 234), "movie_title", new Size(482, 62), 114, movie.Title);
                labels.Add(labelInPictureBox);
                labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(203, 329), "movie_date", new Size(254, 49), 115, movie.Date.ToString("dd/MM/yyyy HH:mm"));
                labels.Add(labelInPictureBox);
                labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(295, 392), "ticket_price", new Size(161, 35), 116, $"{price}$");
                labels.Add(labelInPictureBox);
                labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(248, 439), "ticket_seats", new Size(517, 46), 117, string.Join(", ", seatList.Select(s => s.Number)));
                labels.Add(labelInPictureBox);
                labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(535, 385), "movie_room", new Size(236, 42), 118, movie.Room.Number.ToString());
                labels.Add(labelInPictureBox);
                labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(648, 332), "movie_duration", new Size(118, 35), 119, $"{movie.Duration}H");
                labels.Add(labelInPictureBox);
                labelInPictureBox = CreateTicketLabel(tt_controls, bigFont, new Point(875, 76), "ticket_id", new Size(157, 53), 120, res.Ticket.Id.ToString());
                labels.Add(labelInPictureBox);

                // Zapisanie biletu do pliku w formacie JPG
                SaveTicketToJPGFile(ticket_template, labels, fileName);
                MakeAlert("Rezerwacja przebiegła pomyślnie!", CustomAlertBox.enmType.Success);
            }
        }


        // Metoda realizująca zapisywanie biletu do pliku w formacie JPG
        private void SaveTicketToJPGFile(PictureBox ticket_template, List<Label> labels, string fileName)
        {
            Bitmap bitmap = new Bitmap(ticket_template.Width, ticket_template.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                ticket_template.DrawToBitmap(bitmap, new Rectangle(0, 0, ticket_template.Width, ticket_template.Height));

                foreach (Label lbl in labels)
                {
                    lbl.DrawToBitmap(bitmap, new Rectangle(lbl.Left, lbl.Top, lbl.Width, lbl.Height));
                }

            }
            string directoryPath = "TicketsJPG";
            string filePath = Path.Combine(directoryPath, fileName);
            bitmap.Save(filePath, ImageFormat.Jpeg);
        }

        // Metoda tworząca labele uzupełniające bilet odpowiednimi informacjami
        private Label CreateTicketLabel(Control.ControlCollection controls, Font font, Point location, string name, Size size, int tab_index,string text)
        {
            Label label = new Label();
            if (name == "ticket_id")
            {
                label.BackColor = Color.White;
                label.ForeColor = Color.FromArgb(36, 30, 32);
                label.TextAlign = ContentAlignment.MiddleCenter;

            }
            else if (name == "ticket_info_header" || name == "ticket_info_subtitle")
            {
                label.BackColor = Color.FromArgb(34, 35, 68);
                label.ForeColor = SystemColors.Window;
                label.TextAlign = ContentAlignment.MiddleCenter;
            }
            else
            {
                label.BackColor = Color.FromArgb(36, 30, 32);
                label.ForeColor = SystemColors.Window;
                label.TextAlign = ContentAlignment.MiddleLeft;

            }         
            label.Font = font;           
            label.Location = location;
            label.Name = name;
            label.Size = size;
            label.TabIndex = tab_index;
            label.Text = text;

            controls.Add(label);
            return label;
        }


        // Metoda tworząca templatkę biletu
        private PictureBox CreateTicket(Control.ControlCollection controls)
        {
            PictureBox ticket_template = new PictureBox();
            ticket_template.Image = Properties.Resources.ticket_template;
            ticket_template.Location = new Point(135, 116);
            ticket_template.Name = "ticket_template";
            ticket_template.Size = new Size(1162, 537);
            ticket_template.SizeMode = PictureBoxSizeMode.Zoom;
            ticket_template.TabIndex = 113;
            ticket_template.TabStop = false;

            controls.Add(ticket_template);
            return ticket_template;
        }

        // Metoda tworząca obrazek GIF drukarki
        private PictureBox createPrinterPictureBox()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Location = new Point(466, 130);
            pictureBox.Name = "printerPictureBox";
            pictureBox.Image = Properties.Resources.printer2;
            pictureBox.Size = new Size(400, 400);
            return pictureBox;
        }

        // Metoda tworząca konkretny label podczas drukowania biletu
        private Label createLabel()
        {
            Label label = new Label();
            label.Font = new Font("Montserrat", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label.ForeColor = SystemColors.Window;
            label.Location = new Point(398, 80);
            label.Name = "label1";
            label.Size = new Size(626, 54);
            label.TabIndex = 102;
            label.Text = "Trwa drukowanie biletu. Proszę czekać...";
            label.TextAlign = ContentAlignment.MiddleCenter;
            return label;
        }

        // Metoda tworząca wszytskie 100 przeycisków reprezentujących miejsca w sali kinowej
        public void CreateSeatsButtons()
        {
            int DefaultX = 46;  // Podstawowa współrzędna X przycisku
            int x = DefaultX;
            int y = 189;    // Początkowa współrzędna Y przycisku\

            // Przesunięcia kolejnych przycisków
            int deltaX = 77;
            int deltaY = 81;
            int lastRowOffset = 50; // offset ostatniego wiersza

            for (int i = 0; i < (int)Rooms.NUMBER_OF_SEATS; i++)
            {
                // Utworzenie przycisku względem podanych współrzędnych i numeru siedzenia oraz dodanie go do widoku
                _movieReservationView.AddSeatControl(CreateSeatButton(x, y, i));
                x += deltaX;    // Przesunięcie przycisku na współrzędnej X o deltaX

                // W jednym wierszu tylko 17 miejsc 
                if (i != 0 && (i + 1) % 17 == 0)
                {
                    x = DefaultX;   // Ustawienie defaultowego offsetu względem X
                    y += deltaY;    // Przejście do następnego wiersza
                }
                // Jeśli jest to ostatni wiersz
                if (i + 1 == 85)
                {
                    x += lastRowOffset; // współrzędna X jest przesunięta o zdefiniowane przesunięcie ostatniego wiersza
                }
            }
        }

        // Metoda tworząca przyciski reprezentujące miejsca w sali
        public IconButton CreateSeatButton(int x, int y, int seatNr)
        {
            IconButton button = new IconButton();
            if (seats[seatNr].IsAvailable)
            {
                button.BackColor = Color.FromArgb(9, 133, 20);
                button.Cursor = Cursors.Hand;
                button.Enabled = true;
            }
            else
            {
                button.BackColor = Color.FromArgb(168, 2, 2);
                button.Cursor = Cursors.Default;
                button.Enabled = false;
            }
                     
            button.FlatAppearance.BorderColor = Color.FromArgb(34, 35, 68);
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Montserrat", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button.ForeColor = SystemColors.Window;
            button.IconChar = FontAwesome.Sharp.IconChar.Couch;
            button.IconColor = SystemColors.Window;
            button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            button.IconSize = 35;
            button.Location = new Point(x, y);
            button.Margin = new Padding(20, 3, 3, 20);
            button.Name = "iconButton1";
            button.Size = new Size(54, 58);
            button.TabIndex = 0;
            button.Text = (seatNr+1).ToString();
            button.TextAlign = ContentAlignment.BottomCenter;
            button.TextImageRelation = TextImageRelation.ImageAboveText;
            button.UseVisualStyleBackColor = false;

            button.Click += SeatButton_Click;   // Każdy przycisk posiada event Click

            buttonsList.Add(button);

            return button;
        }


        // Metoda obsługująca event kliknięcia na przycisk reprezentujący miejsce w sali
        private void SeatButton_Click(object? sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;

            // Pobranie tekstu przycisku (numeru miejsca, które on reprezentuje)
            int seat_number = int.Parse(button.Text);

            // Dodanie numeru miejsca do listy
            seatList.Add(seats.FirstOrDefault(s => s.Number == seat_number));
            button.Enabled = false; // Ustawienie kliknięciego przycisku jako nieaktywny

            _movieReservationView.SeatsLabel.Text = string.Join(", ", seatList.Select(s => s.Number));  // Update widoku (listy wybranych miejsc)
        }

        // Metoda obsługująca event kliknięcia przycisku "Cofnij"
        private void Undo(object? sender, EventArgs e)
        {
            // Jeżeli lista miejsc zawiera cokolwiek
            if (seatList.Any())
            {
                // Znajdz przycisk z odpowiednim numerem i ustaw go jako aktywny
                FindButtonAndSetEnabled(seatList[seatList.Count - 1].Number);
                seatList.RemoveAt(seatList.Count - 1);  // Usuń numer miejsca z listy
                // Zaktualizuj widok listy
                _movieReservationView.SeatsLabel.Text = string.Join(", ", seatList.Select(s => s.Number));
            }
        }


        // Metoda wyszukująca dany przycisk względem numeru i ustawiająca go jako aktywny (możliwy do kliknięcia)
        private void FindButtonAndSetEnabled(int number)
        {
            foreach(IconButton button in buttonsList)
            {
                if(button.Text == number.ToString())
                {
                    button.Enabled = true;
                }
            }
        }

        
    }
}
