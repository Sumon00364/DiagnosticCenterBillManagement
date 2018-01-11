using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.Models
{
    public class BillReport
    {
        public int BillNo { get; set; }
        public string Mobile { get; set; }
        public string Patient { get; set; }
        public double BillAmount { get; set; }
    }
}