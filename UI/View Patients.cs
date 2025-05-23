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
    public partial class View_Patient : Form
    {
        private readonly ViewPatientsService _service;  
        private int key = 0;
        public View_Patient()
        {
            InitializeComponent();
            _service = new ViewPatientsService();
            populate();
        }

        

        private void populate()
        {
            DataTable dt = _service.GetAllPatients();
            PatientDGV.DataSource = dt;
        }

        private void View_Patient_Load(object sender, EventArgs e)
        {

        }

        private void reset()
        {
            PNameTb.Text = "";
            PAgeTb.Text = "";
            PPhoneTb.Text = "";
            PGenCb.SelectedIndex = -1;
            PBGroupCb.SelectedIndex = -1;
            PAddressTb.Text = "";
        }

        private void PatientDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PNameTb.Text = PatientDGV.SelectedRows[0].Cells[1].Value.ToString();
            PAgeTb.Text = PatientDGV.SelectedRows[0].Cells[2].Value.ToString();
            PPhoneTb.Text = PatientDGV.SelectedRows[0].Cells[3].Value.ToString();
            PGenCb.SelectedItem = PatientDGV.SelectedRows[0].Cells[4].Value.ToString();
            PBGroupCb.SelectedItem = PatientDGV.SelectedRows[0].Cells[5].Value.ToString();
            PAddressTb.Text = PatientDGV.SelectedRows[0].Cells[6].Value.ToString();

            if (int.TryParse(PatientDGV.SelectedRows[0].Cells[0].Value.ToString(), out int result))
            {
                key = result;
            }
            else
            {
                key = 0;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                _service.DeletePatientData(key);
                MessageBox.Show("Patient Deleted Successfully");
                reset();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                _service.UpdatePatient(key, PNameTb.Text, Convert.ToInt32(PAgeTb.Text), PPhoneTb.Text, PGenCb.SelectedItem.ToString(), PBGroupCb.SelectedItem.ToString(), PAddressTb.Text);
                MessageBox.Show("Patient Updated Successfully");
                reset();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new Donor(), this);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new View_Donors(), this);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FormNavigator.NavigateTo(new Patient(), this);
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
