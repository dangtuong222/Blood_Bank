using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood_Bank.Data
{
    internal class BloodTransferRepository
    {
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BloodBankDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;MultiSubnetFailover=False";

        // Lấy danh sách bệnh nhân
        public DataTable GetPatients()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT PNum FROM PatientTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

        // Lấy thông tin bệnh nhân theo ID
        public DataTable GetPatientById(string patientId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM PatientTbl WHERE PNum = @PNum";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PNum", patientId);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
        }


        // Lấy số lượng máu theo nhóm máu
        public int GetBloodStockByGroup(string bloodGroup)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT BStock FROM BloodTbl WHERE BGroup = @BGroup";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BGroup", bloodGroup);
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        // Cập nhật số lượng máu sau khi chuyển máu
        public void UpdateBloodStock(string bloodGroup, int newStock)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE BloodTbl SET BStock = @BStock WHERE BGroup = @BGroup";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BStock", newStock);
                    cmd.Parameters.AddWithValue("@BGroup", bloodGroup);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        // Chèn thông tin chuyển máu vào bảng TransferTbl
        public void InsertBloodTransfer(string patientName, string bloodGroup)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO TransferTbl (PName, PBGroup) VALUES (@PName, @PBGroup)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PName", patientName);
                    cmd.Parameters.AddWithValue("@PBGroup", bloodGroup);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
