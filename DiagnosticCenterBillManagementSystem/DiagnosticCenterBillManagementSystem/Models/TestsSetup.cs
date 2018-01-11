using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.Models
{
    public class TestsSetup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Fee { get; set; }
        public int TestTypeId { get; set; }
    }
}