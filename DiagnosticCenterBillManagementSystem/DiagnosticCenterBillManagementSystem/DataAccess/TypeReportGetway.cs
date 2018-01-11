using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.DataAccess
{
    public class TypeReportGetway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticeCenterDBConnection"].ConnectionString;

        public List<TypeReport> TypeWiseReport(DateTime firstDate, DateTime secondDate)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "spTypeWiseReport '" + firstDate + "','" + secondDate + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<TypeReport> testReport = new List<TypeReport>();
            while (reader.Read())
            {
                TypeReport report = new TypeReport();
                report.TestType = reader["Name"].ToString();
                report.TotalNoTest = int.Parse(reader["TotalCount"].ToString());
                report.TotalAmount = double.Parse(reader["Amount"].ToString());

                testReport.Add(report);
            }
            reader.Close();
            connection.Close();

            return testReport;
        }
    }
}