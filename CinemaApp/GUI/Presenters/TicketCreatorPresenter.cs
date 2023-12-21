using CinemaApp.Exceptions;
using CinemaApp.Interfaces;
using CinemaApp.Model;
using GUI.Interfaces;
using GUI.Views;
using QRCoder;
using System.Drawing.Imaging;

namespace GUI.Presenters
{
    public class TicketCreatorPresenter
    {
        private Control.ControlCollection controls;
        private IReservationRepository reservationRepository;
        public TicketCreatorPresenter(IReservationRepository reservationRepository, ITicketCreator ticketCreator)
        {
            this.reservationRepository = reservationRepository;
            //List<Reservation> res = reservationRepository.GetReservationsList(); //exceptions
            controls = ticketCreator.GetControls();
            //PrepareTickets(res);

        }
        public void UpdateTicket(Reservation res)
        {
            Font smallFont = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            Font bigFont = new Font("Montserrat", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point);
            Font mediumFont = new Font("Montserrat", 16.2F, FontStyle.Regular, GraphicsUnit.Point);


            PictureBox ticket_template = CreateTicket(controls);
            Control.ControlCollection tt_controls = ticket_template.Controls;
            List<Label> labels = new List<Label>();
            string fileName = res.Ticket.Id + "_" + res.Movie.Title + ".jpg";

            string price = res.Ticket.CalculatePrice(res.Movie.Price, res.Seats.Count).ToString();
            Label labelInPictureBox = CreateTicketLabel(tt_controls, bigFont, new Point(258, 234), "movie_title", new Size(482, 62), 114, res.Movie.Title);
            labels.Add(labelInPictureBox);
            labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(203, 329), "movie_date", new Size(254, 49), 115, res.Movie.Date.ToString("dd/MM/yyyy HH:mm"));
            labels.Add(labelInPictureBox);
            labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(295, 392), "ticket_price", new Size(161, 35), 116, $"{price}$");
            labels.Add(labelInPictureBox);
            labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(248, 439), "ticket_seats", new Size(517, 46), 117, string.Join(", ", res.Seats.Select(s => s.Number)));
            labels.Add(labelInPictureBox);
            labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(535, 385), "movie_room", new Size(236, 42), 118, res.Movie.Room.Number.ToString());
            labels.Add(labelInPictureBox);
            labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(648, 332), "movie_duration", new Size(118, 35), 119, $"{res.Movie.Duration}H");
            labels.Add(labelInPictureBox);
            labelInPictureBox = CreateTicketLabel(tt_controls, bigFont, new Point(875, 76), "ticket_id", new Size(157, 53), 120, res.Ticket.Id.ToString());
            labels.Add(labelInPictureBox);

            PictureBox qrCode = CreateQRCode(res.Ticket.Id.ToString(), res.Movie.Title);

            SaveTicketToJPGFile(ticket_template, labels, fileName, qrCode);
            labels.Clear();
            tt_controls.Clear();
        }
        public void PrepareTickets()
        {
            List<Reservation> reservations = reservationRepository.GetReservationsList(); // exceptions
            Font smallFont = new Font("Montserrat", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            Font bigFont = new Font("Montserrat", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point);
            Font mediumFont = new Font("Montserrat", 16.2F, FontStyle.Regular, GraphicsUnit.Point);


            PictureBox ticket_template = CreateTicket(controls);
            Control.ControlCollection tt_controls = ticket_template.Controls;
            List<Label> labels = new List<Label>();

            foreach (Reservation res in reservations)
            {
                string fileName = res.Ticket.Id + "_" + res.Movie.Title + ".jpg";
                
                

                string price = res.Ticket.CalculatePrice(res.Movie.Price, res.Seats.Count).ToString();
                Label labelInPictureBox = CreateTicketLabel(tt_controls, bigFont, new Point(258, 234), "movie_title", new Size(482, 62), 114, res.Movie.Title);
                labels.Add(labelInPictureBox);
                labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(203, 329), "movie_date", new Size(254, 49), 115, res.Movie.Date.ToString("dd/MM/yyyy HH:mm"));
                labels.Add(labelInPictureBox);
                labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(295, 392), "ticket_price", new Size(161, 35), 116, $"{price}$");
                labels.Add(labelInPictureBox);
                labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(248, 439), "ticket_seats", new Size(517, 46), 117, string.Join(", ", res.Seats.Select(s => s.Number)));
                labels.Add(labelInPictureBox);
                labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(535, 385), "movie_room", new Size(236, 42), 118, res.Movie.Room.Number.ToString());
                labels.Add(labelInPictureBox);
                labelInPictureBox = CreateTicketLabel(tt_controls, smallFont, new Point(648, 332), "movie_duration", new Size(118, 35), 119, $"{res.Movie.Duration}H");
                labels.Add(labelInPictureBox);
                labelInPictureBox = CreateTicketLabel(tt_controls, bigFont, new Point(875, 76), "ticket_id", new Size(157, 53), 120, res.Ticket.Id.ToString());
                labels.Add(labelInPictureBox);

                PictureBox qrCode = CreateQRCode(res.Ticket.Id.ToString(), res.Movie.Title);

                SaveTicketToJPGFile(ticket_template, labels, fileName, qrCode);
                labels.Clear();
                tt_controls.Clear();
            }
                    
        }
        private PictureBox CreateQRCode(string ticket_id, string movie_title)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode($"{ticket_id}_{movie_title}", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            PictureBox qrCodePicture = new PictureBox();
            qrCodePicture.Image = qrCode.GetGraphic(20);
            qrCodePicture.Location = new Point(825, 150);
            qrCodePicture.Name = "qrCodePicture";
            qrCodePicture.Size = new Size(260, 260);
            qrCodePicture.SizeMode = PictureBoxSizeMode.Zoom;

            return qrCodePicture;
        }
        private void SaveTicketToJPGFile(PictureBox ticket_template, List<Label> labels, string fileName, PictureBox qrCode)
        {
            Bitmap bitmap = new Bitmap(ticket_template.Width, ticket_template.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                ticket_template.DrawToBitmap(bitmap, new Rectangle(0, 0, ticket_template.Width, ticket_template.Height));

                foreach (Label lbl in labels)
                {
                    lbl.DrawToBitmap(bitmap, new Rectangle(lbl.Left, lbl.Top, lbl.Width, lbl.Height));
                }
                qrCode.DrawToBitmap(bitmap, new Rectangle(qrCode.Left, qrCode.Top, qrCode.Width, qrCode.Height));

            }
            string directoryPath = "TicketsJPG";
            string filePath = Path.Combine(directoryPath, fileName);
            bitmap.Save(filePath, ImageFormat.Jpeg);
        }
        private Label CreateTicketLabel(Control.ControlCollection controls, Font font, Point location, string name, Size size, int tab_index, string text)
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

        private PictureBox CreateTicket(Control.ControlCollection controls)
        {
            PictureBox ticket_template = new PictureBox();
            ticket_template.Image = Properties.Resources.ticket_template_2;
            ticket_template.Location = new Point(135, 116);
            ticket_template.Name = "ticket_template";
            ticket_template.Size = new Size(1162, 537);
            ticket_template.SizeMode = PictureBoxSizeMode.Zoom;
            ticket_template.TabIndex = 113;
            ticket_template.TabStop = false;

            controls.Add(ticket_template);
            return ticket_template;
        }
    }
}
