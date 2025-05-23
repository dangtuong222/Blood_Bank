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
    public partial class Donor : Form
    {
        private readonly DonorService _donorService;
        public Donor()
        {
            InitializeComponent();
            _donorService = new DonorService();
        }


        private void Donor_Load(object sender, EventArgs e)
        {
            
        }
        private void reset()
        {
            DNameTb.Text = "";
            DAgeTb.Text = "";
            DPhoneTb.Text = "";
            DGenCb.SelectedIndex = -1;
            DBGroupCb.SelectedIndex = -1;
            DAddressTb.Text = "";
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                _donorService.AddDonor(
                    DNameTb.Text,
                    DAgeTb.Text,
                    DGenCb.SelectedItem?.ToString(),
                    DPhoneTb.Text,
                    DAddressTb.Text,
                    DBGroupCb.SelectedItem?.ToString()
                );
                MessageBox.Show("Donor Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new View_Donors(), this);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new Patient(), this);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new View_Patient(), this);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new Blood_Stockcs(), this);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new Blood_Transfer(), this);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new Dashboard(), this);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new Login(), this);

        }
    }
}
