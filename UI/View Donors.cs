using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blood_Bank.Service;

namespace Blood_Bank
{
    public partial class View_Donors : Form
    {
        private readonly ViewDonorsService _service;
        public View_Donors()
        {
            InitializeComponent();
            _service = new ViewDonorsService();
            PopulateDonors();
        }

        private void PopulateDonors()
        {
            var dt = _service.GetDonors();
            DonorDGV.DataSource = dt;
        }

        private void View_Donors_Load(object sender, EventArgs e)
        {

        }
    }
}
