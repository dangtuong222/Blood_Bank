using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blood_Bank.Data
{
    internal class ViewPatientsRepository
    {
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BloodBankDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;MultiSubnetFailover=False";

        public DataTable GetAllPatients()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM PatientTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

        public void DeletePatient(int key)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM PatientTbl WHERE PNum = @PNum";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PNum", key);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public int UpdatePatient(int pnum, string name, int age, string phone, string gender, string bloodGroup, string address)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE PatientTbl SET 
                                    PName = @PName, 
                                    PAge = @PAge, 
                                    PPhone = @PPhone, 
                                    PGender = @PGender, 
                                    PBGroup = @PBGroup, 
                                    PAddress = @PAddress 
                                 WHERE PNum = @PNum";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PName", name);
                    cmd.Parameters.AddWithValue("@PAge", age);
                    cmd.Parameters.AddWithValue("@PPhone", phone);
                    cmd.Parameters.AddWithValue("@PGender", gender);
                    cmd.Parameters.AddWithValue("@PBGroup", bloodGroup);
                    cmd.Parameters.AddWithValue("@PAddress", address);
                    cmd.Parameters.AddWithValue("@PNum", pnum);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
