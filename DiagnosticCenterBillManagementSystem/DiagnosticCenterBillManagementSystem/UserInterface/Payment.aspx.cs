using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.BusinessLogic;

namespace DiagnosticCenterBillManagementSystem.UserInterface
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        BillManager billManager = new BillManager();
        
        protected void serchButton_Click(object sender, EventArgs e)
        {
            LoadCompletedTest();
            BillInformation();
        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            if(searchTextBox.Text != string.Empty && amountTextBox.Text != string.Empty)
            { 
                Payments payments = new Payments();
                payments.BillNo = int.Parse(searchTextBox.Text);
                payments.PaidAmount = double.Parse(amountTextBox.Text);

                billManager.UpdateBill(payments);
                BillInformation();
            }
            else
            {
                return;
            }
        }

        private void LoadCompletedTest()
        {
            int billNo = Convert.ToInt32(searchTextBox.Text);
            List<TestsSetup> completeTest = billManager.CompletedTest(billNo);

            testSetupGridView.DataSource = completeTest;
            testSetupGridView.DataBind();
        }

        private void BillInformation()
        {
            int billNo = Convert.ToInt32(searchTextBox.Text);
         

            Payments payments = new Payments();
            payments = billManager.GetBillByBillNo(billNo);
            dateLabel.Text = payments.TestDate.ToString();
            totalFeeLabel.Text = payments.TotalFee.ToString();
            paidAmountLabel.Text = payments.PaidAmount.ToString();
            dueLabel.Text = payments.DueAmount.ToString();
        }
    }
}