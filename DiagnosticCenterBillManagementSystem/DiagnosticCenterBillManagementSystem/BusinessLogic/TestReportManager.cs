using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.DataAccess;

namespace DiagnosticCenterBillManagementSystem.BusinessLogic
{
    public class TestReportManager
    {
        TestReportGetway testReportGetway = new TestReportGetway();
        public List<TestReport> GetTypeWiseReport(DateTime firstDate, DateTime secondDate)
        {
            return testReportGetway.TestWiseReport(firstDate, secondDate);
        }
    }
}