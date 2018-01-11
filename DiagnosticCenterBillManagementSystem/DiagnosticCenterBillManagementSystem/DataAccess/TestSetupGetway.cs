using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.DataAccess
{
    public class TestSetupGetway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticeCenterDBConnection"].ConnectionString;

        public int SaveTestSetup(TestsSetup test)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "insert BillManagement.TestSetup(Name, Fee, TypeId) values ('" + test.Name + "','" + test.Fee + "','" + test.TestTypeId + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }

        public List<TestsSetup> GetAllTests()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from  BillManagement.TestSetup";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<TestsSetup> tests = new List<TestsSetup>();
            while(reader.Read())
            {
                TestsSetup test = new TestsSetup();
                test.Id = int.Parse(reader["Id"].ToString());
                test.Name = reader["Name"].ToString();
                test.Fee = double.Parse(reader["Fee"].ToString());

                tests.Add(test);
            }
            reader.Close();
            connection.Close();
            return tests;
        }

        public double GetFee(string id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from  BillManagement.TestSetup where Id = '" + id + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            double fee = 0;
            while (reader.Read())
            {
                fee = double.Parse(reader["Fee"].ToString());
            }
            reader.Close();
            connection.Close();
            return fee;
        }
        public List<TestTypeSetupView> GetAllTestSetup()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from  BillManagement.TestTypeSetupVW";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<TestTypeSetupView> tests = new List<TestTypeSetupView>();

            while(reader.Read())
            {
                TestTypeSetupView test = new TestTypeSetupView();
                test.Name = reader["Name"].ToString();
                test.Fee = double.Parse(reader["Fee"].ToString());
                test.Type = reader["Type"].ToString();

                tests.Add(test);
            }

            reader.Close();
            connection.Close();

            return tests;
        }

        public int GetTestSetupByName(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select COUNT(Name) as [count] from  BillManagement.TestSetup where Name = '"+name+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            int count = 0;
            while(reader.Read())
            {
                count = int.Parse(reader["count"].ToString());
            }

            reader.Close();
            connection.Close();

            return count;
        }
    }
}