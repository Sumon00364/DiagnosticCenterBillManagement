using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.DataAccess;

namespace DiagnosticCenterBillManagementSystem.BusinessLogic
{
    public class TypeReportManager
    {
        TypeReportGetway typeReportGetway = new TypeReportGetway();
        public List<TypeReport> GetTypeWiseReport(DateTime firstDate, DateTime secondDate)
        {
            return typeReportGetway.TypeWiseReport(firstDate, secondDate);
        }
    }
}