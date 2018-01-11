using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.DataAccess;

namespace DiagnosticCenterBillManagementSystem.BusinessLogic
{
    public class ReportManager
    {
        TestRepotGetway testReportGetway = new TestRepotGetway();
        public List<TestReport> GetTypeWiseReport(DateTime firstDate, DateTime secondDate)
        {
            return testReportGetway.TestWiseReport(firstDate, secondDate);
        }

        public List<TestReport> GetTypeWiseReport(DateTime firstDate, DateTime secondDate)
        {
            return testReportGetway.TypeWiseReport(firstDate, secondDate);
        }
    }
}