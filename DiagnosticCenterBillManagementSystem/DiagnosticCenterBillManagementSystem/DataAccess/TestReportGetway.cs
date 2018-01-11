using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.DataAccess
{
    public class TestReportGetway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticeCenterDBConnection"].ConnectionString;

        public List<TestReport> TestWiseReport(DateTime firstDate, DateTime secondDate)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "spTestWiseReport '" + firstDate + "','" + secondDate + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<TestReport> testReport = new List<TestReport>();
            while(reader.Read())
            {
                TestReport report = new TestReport();
                report.Name = reader["Name"].ToString();
                report.TotalNoTest = int.Parse(reader["TotalTest"].ToString());
                report.TotalAmount = double.Parse(reader["Total"].ToString());

                testReport.Add(report);
            }
            reader.Close();
            connection.Close();

            return testReport;
        }

    }
}