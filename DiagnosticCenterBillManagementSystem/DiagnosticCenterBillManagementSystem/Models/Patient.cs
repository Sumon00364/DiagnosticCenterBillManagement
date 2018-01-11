using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.Models
{
    public class Patient
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mobile { get; set; }

        public Patient(string name, DateTime date, string mobile)
        {
            this.Name = name;
            this.DateOfBirth = date;
            this.Mobile = mobile;
        }
        public Patient() { }
    }
}