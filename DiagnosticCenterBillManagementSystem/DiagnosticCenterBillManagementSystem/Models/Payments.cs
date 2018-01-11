using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.Models
{
    public class Payments
    {
        public int BillNo { get; set; }
        public double TotalFee { get; set; }
        public double PaidAmount { get; set; }
        public double DueAmount { get; set; }
        public string Mobile { get; set; }
        public DateTime TestDate { get; set; }
    }
}