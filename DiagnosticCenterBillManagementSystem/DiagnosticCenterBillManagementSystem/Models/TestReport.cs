using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.Models
{
    public class TestReport
    {
        public string Name { get; set; }
        public int TotalNoTest { get; set; }
        public double TotalAmount { get; set; }
    }
}