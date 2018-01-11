using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.Models
{
    public class PatientTest
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Mobile { get; set; }
        public DateTime TestDate { get; set; }
    }
}