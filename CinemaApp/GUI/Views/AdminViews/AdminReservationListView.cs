using GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Views.AdminViews
{
    public partial class AdminReservationListView : Form, IAdminReservationsView
    {
        public AdminReservationListView()
        {

            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }

        public void SetReservationListBindingSource(BindingSource reservationList)
        {
            dataGridView1.RowTemplate.Height = 45;
            dataGridView1.DataSource = reservationList;
        }
    }
}
