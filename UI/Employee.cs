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

namespace Blood_Bank.UI
{
    public partial class Employee : Form
    {
        private readonly EmployeeService _service;
        public Employee()
        {
            InitializeComponent();
            _service = new EmployeeService();
            populate();
        }
        
        private void reset()
        {
            EmpNameTb.Text = "";
            EmpPassTb.Text = "";
        }

        private void populate()
        {
            try
            {
                DataTable dt = _service.GetEmployees();
                EmpDGV.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                _service.AddEmployee(EmpNameTb.Text, EmpPassTb.Text);
                MessageBox.Show("Employee Successfully Saved");
                reset();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }
    }
}
