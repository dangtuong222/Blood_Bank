using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blood_Bank.Helpers;

namespace Blood_Bank
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
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
