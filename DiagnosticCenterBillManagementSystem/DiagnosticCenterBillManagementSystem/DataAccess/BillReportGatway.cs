using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.DataAccess
{
    public class BillReportGatway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticeCenterDBConnection"].ConnectionString;

        public List<BillReport> UnpaidBillReport(DateTime firstDate, DateTime secondDate)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "spUnpaidBillReport '" + firstDate + "','" + secondDate + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<BillReport> testReport = new List<BillReport>();
            while (reader.Read())
            {
                BillReport report = new BillReport();
                report.BillNo = Convert.ToInt32(reader["BillNo"].ToString());
                report.Mobile = reader["MobileNo"].ToString();
                report.Patient = reader["Name"].ToString();
                report.BillAmount = double.Parse(reader["DueAmount"].ToString());

                testReport.Add(report);
            }
            reader.Close();
            connection.Close();

            return testReport;
        }
    }
}