using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood_Bank.Data
{
    internal class DashboardRepository
    {
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BloodBankDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;MultiSubnetFailover=False";

        // Lấy số lượng donor
        public int GetDonorCount()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM DonorTbl";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Lấy số lượng chuyển máu
        public int GetTransferCount()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM TransferTbl";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Lấy số lượng nhân viên
        public int GetEmployeeCount()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM EmployeeTbl";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Lấy tổng số máu trong kho
        public int GetBloodStock()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(BStock) FROM BloodTbl";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Lấy số lượng máu theo nhóm
        public int GetBloodGroupCount(string bloodGroup)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM BloodTbl WHERE BGroup = @BGroup";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BGroup", bloodGroup);
                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
