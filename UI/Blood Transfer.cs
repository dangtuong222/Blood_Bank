using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blood_Bank.Service;

namespace Blood_Bank
{
    public partial class Blood_Transfer : Form
    {
        private  BloodTransferService _service;

        public Blood_Transfer()
        {
            InitializeComponent();
            FillPatientCb();
            _service = new BloodTransferService();

        }
       
        private void Blood_Transfer_Load(object sender, EventArgs e)
        {

        }

        private void FillPatientCb()
        {
            _service = new BloodTransferService();
            try
            {
                DataTable dt = _service.GetAllPatients();
                PatientIdCb.DataSource = dt;
                PatientIdCb.DisplayMember = "PNum";
                PatientIdCb.ValueMember = "PNum";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patients: " + ex.Message);
            }
        }
        
        private void GetData()
        {
            try
            {
                string selectedPatientId = PatientIdCb.SelectedValue.ToString();
                DataTable dt = _service.GetPatientDetails(selectedPatientId);
                if (dt.Rows.Count > 0)
                {
                    PatNameTb.Text = dt.Rows[0]["PName"].ToString();
                    BloodGroup.Text = dt.Rows[0]["PBGroup"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving patient data: " + ex.Message);
            }
        }

        private void GetStock(string BGroup)
        {
            try
            {
                bool isAvailable = _service.CheckStockAvailability(BGroup);
                if (isAvailable)
                {
                    TransferBtn.Enabled = true;
                    AvailableLbl.Text = "Available Stock";
                }
                else
                {
                    TransferBtn.Enabled = false;
                    AvailableLbl.Text = "Stock Not Available";
                }

                AvailableLbl.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking stock: " + ex.Message);
            }
        }
        private void PatientIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetData();
            string bloodGroup = BloodGroup.Text;
            if (!string.IsNullOrEmpty(bloodGroup))
            {
                GetStock(bloodGroup);
            }
            else
            {
                AvailableLbl.Visible = false;
            }
        }

        

        private void label4_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();
        }

        private void reset()
        {
            PatNameTb.Text = "";
            BloodGroup.Text = "";
            PatientIdCb.SelectedIndex = -1;
            AvailableLbl.Visible = false;
            TransferBtn.Visible = false;
        }
        private void TransferBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(PatNameTb.Text) || string.IsNullOrEmpty(BloodGroup.Text))
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    _service.RecordBloodTransfer(PatNameTb.Text, BloodGroup.Text);
                    _service.ProcessBloodTransfer(BloodGroup.Text);
                    MessageBox.Show("Blood Transfer Successful");
                    reset();
                    FillPatientCb();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during transfer: " + ex.Message);
            }
        }
    }
}
