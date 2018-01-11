using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.DataAccess;

namespace DiagnosticCenterBillManagementSystem.BusinessLogic
{    
    public class BillReportManager
    {
        BillReportGatway billReportGatway = new BillReportGatway();

        public List<BillReport> UnpaidBillReport(DateTime firstDate, DateTime secondDate)
        {
            return billReportGatway.UnpaidBillReport(firstDate, secondDate);
        }
    }
}