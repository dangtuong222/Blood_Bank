using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood_Bank.Data
{
    internal class LoginRepository
    {
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BloodBankDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;MultiSubnetFailover=False";

        public bool ValidateEmployeeCredentials(string empId, string empPass)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM EmployeeTbl WHERE EmpId = @EmpId AND EmpPass = @EmpPass";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmpId", empId);
                    cmd.Parameters.AddWithValue("@EmpPass", empPass);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count == 1;
                }
            }
        }
    }
}
