using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DataAccess;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.BusinessLogic
{
    public class BillManager
    {
        BillPaymentGetway billPaymentGetway = new BillPaymentGetway();
        PatientGetway patientGetWay = new PatientGetway();

        public int SaveTotalBill(Payments payment)
        {
            return billPaymentGetway.SavePayment(payment);
        }
        
        public List<TestsSetup> CompletedTest(int billNo)
        {
            return patientGetWay.CompleteTest(billNo);
        }
        public Payments GetBillByBillNo(int billNo)
        {
            return billPaymentGetway.GetPaymentByBillNo(billNo);
        }

        public int UpdateBill(Payments payments)
        {
            return billPaymentGetway.UpdatePaidAmount(payments);
        }

        public int LastInsertedBillNo()
        {
            return billPaymentGetway.LastInsertedBillNo();
        }
    }
}

/*DESKTOP-R9OC6GI*/