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
using Blood_Bank.UI;

namespace Blood_Bank
{
    public partial class Login : Form
    {
        private readonly LoginService _service;

        public Login()
        {
            InitializeComponent();
            _service = new LoginService();
        }
        
        private void label5_Click(object sender, EventArgs e)
        {
            AdminLogin log = new AdminLogin();
            log.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool isValid = _service.AuthenticateEmployee(EmpIdTb.Text, EmpPassTb.Text);
                if (isValid)
                {
                    Mainform main = new Mainform();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                    EmpIdTb.Clear();
                    EmpPassTb.Clear();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message);
            }
        }
    }
}
