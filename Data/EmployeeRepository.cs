using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood_Bank.Data
{
    internal class EmployeeRepository
    {
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BloodBankDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;MultiSubnetFailover=False";

        public DataTable GetAllEmployees()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM EmployeeTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

        public void InsertEmployee(string empId, string empPass)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO EmployeeTbl (EmpId, EmpPass) VALUES (@EmpId, @EmpPass)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmpId", empId);
                    cmd.Parameters.AddWithValue("@EmpPass", empPass);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
