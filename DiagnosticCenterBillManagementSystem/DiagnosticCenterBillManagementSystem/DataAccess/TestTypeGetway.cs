using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenterBillManagementSystem.Models;
using System.Data.SqlClient;

namespace DiagnosticCenterBillManagementSystem.DataAccess
{
    public class TestTypeGetway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticeCenterDBConnection"].ConnectionString;

        public int SaveTestType(TestType testType)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "insert BillManagement.TestType(Name) values ('" + testType.Name + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }

        public List<TestType> GetAllTestType()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "Select * from BillManagement.TestType";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<TestType> tests = new List<TestType>();
            while(reader.Read())
            {
                TestType test = new TestType();
                test.Id = int.Parse(reader["Id"].ToString());
                test.Name = reader["Name"].ToString();

                tests.Add(test);
            }

            reader.Close();
            connection.Close();

            return tests;
        }

        public int GetTestTypeByName(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "Select COUNT(Name) as [count] from BillManagement.TestType where Name = '"+name+"'";

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