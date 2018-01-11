using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.Models
{
    public class TypeReport
    {
        public string TestType { get; set; }
        public int TotalNoTest { get; set; }
        public double TotalAmount { get; set; }
    }
}