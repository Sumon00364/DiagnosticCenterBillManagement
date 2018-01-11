using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.DataAccess
{
    public class BillPaymentGetway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticeCenterDBConnection"].ConnectionString;
        
        public int SavePayment(Payments payment)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "Insert BillManagement.BillPayment (TotalFee, MobileNo) values ('" + payment.TotalFee + "','" + payment.Mobile + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public Payments GetPaymentByBillNo(int billNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from BillManagement.BillPayment where BillNo = '" + billNo + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Payments payments = null;
            while(reader.Read())
            {
                payments = new Payments();
                payments.TestDate = Convert.ToDateTime(reader["BillDate"].ToString());
                payments.TotalFee = Convert.ToDouble(reader["TotalFee"].ToString());
                payments.PaidAmount = Convert.ToDouble(reader["PaidAmount"].ToString());
                payments.DueAmount = Convert.ToDouble(reader["DueAmount"].ToString());
            }

            reader.Close();
            connection.Close();

            return payments;
        }

        public int UpdatePaidAmount(Payments payments)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "Update BillManagement.BillPayment set PaidAmount = '"+payments.PaidAmount+"' where BillNo = '"+payments.BillNo+"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public int LastInsertedBillNo()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select top 1 BillNo from BillManagement.BillPayment order by BillNo desc";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            int insertedBillNo = 0;

            while(reader.Read())
            {
                Payments payments = new Payments();
                payments.BillNo = int.Parse(reader["BillNo"].ToString());
                insertedBillNo = payments.BillNo;
            }
            reader.Close();
            connection.Close();

            return insertedBillNo;
        }
    }
}