using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood_Bank.Data
{
    public class DonateBloodRepository
    {
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BloodBankDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;MultiSubnetFailover=False";

        public DataTable GetDonors()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM DonorTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

        public DataTable GetBloodStock()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM BloodTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

        public int GetStockByGroup(string bloodGroup)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT BStock FROM BloodTbl WHERE BGroup = @BGroup";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BGroup", bloodGroup);
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    con.Close();

                    if (result != null && int.TryParse(result.ToString(), out int stock))
                        return stock;
                    else
                        return 0;
                }
            }
        }

        public void UpdateStock(string bloodGroup, int newStock)
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
    }
}
