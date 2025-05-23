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
using Blood_Bank.Helpers;
using Blood_Bank.Service;

namespace Blood_Bank
{
    public partial class Blood_Stockcs : Form
    {
        private readonly BloodStockService _service;
        public Blood_Stockcs()
        {
            InitializeComponent();
            _service = new BloodStockService();
            LoadBloodStock();


        }
        
        private void LoadBloodStock()
        {
            try
            {
                DataTable dt = _service.GetBloodStock();
                BloodStockDGV.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading blood stock: " + ex.Message);
            }
        }
        private void Blood_Stockcs_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new Donor(), this);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new View_Donors(), this);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new Dashboard(), this);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new Blood_Transfer(), this);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new View_Patient(), this);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new Patient(), this);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new Login(), this);
        }
    }
}
