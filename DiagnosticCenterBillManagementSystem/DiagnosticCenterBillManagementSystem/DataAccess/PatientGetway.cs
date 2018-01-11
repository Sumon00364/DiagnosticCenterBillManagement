using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.DataAccess
{
    public class PatientGetway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticeCenterDBConnection"].ConnectionString;
        
        public int SavePatient(Patient patient)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "insert BillManagement.PatientInfo values ('" + patient.Name + "','" + patient.DateOfBirth + "','" + patient.Mobile + "')";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }
        
        public int GetPatientByMobile(string mobile)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select COUNT(Name) as [count] from  BillManagement.PatientInfo where MobileNo = '" + mobile + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count = int.Parse(reader["count"].ToString());
            }

            reader.Close();
            connection.Close();

            return count;
        }

        public int SavePatientTest(PatientTest test, TestsSetup set)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "exec spInsertPatientTest '" + set.Name + "','" + test.Mobile + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }

        public List<TestsSetup> CompleteTest(int billNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "exec spPatientTested '" + billNo + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<TestsSetup> tests = new List<TestsSetup>();

            while(reader.Read())
            {
                TestsSetup test = new TestsSetup();
                test.Name = reader["Name"].ToString();
                test.Fee = Convert.ToDouble(reader["Fee"].ToString());

                tests.Add(test);
            }
            reader.Close();
            connection.Close();

            return tests;
        }
    }
}