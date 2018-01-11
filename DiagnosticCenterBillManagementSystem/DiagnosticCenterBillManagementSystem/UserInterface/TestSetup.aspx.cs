using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BusinessLogic;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.UserInterface
{
    public partial class TestSetup : System.Web.UI.Page
    {
        TestTypeManager typeManager = new TestTypeManager();
        TestSetupManager setupManager = new TestSetupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<TestType> testsType = typeManager.GetAllTestType();
                testTypeDropDownList.DataTextField = "Name";
                testTypeDropDownList.DataValueField = "Id";
                testTypeDropDownList.DataSource = testsType;
                testTypeDropDownList.DataBind();
            }
        }

        protected void testSetupSaveButton_Click(object sender, EventArgs e)
        {
            string name = testNameTextBox.Text;
            string fee = testFeeTextBox.Text;
            string id = testTypeDropDownList.SelectedValue;
            

            if(CheckRequeredField())
            {
                TestsSetup test = new TestsSetup();
                test.Name = name;
                double number;
                if(Double.TryParse(fee, out number))
                {
                    if(number>=0)
                    {

                        test.Fee = Convert.ToDouble(number);
                    }
                    else
                    {
                        messageLabel.Text = "Fee doesn't support negative value.";
                        messageLabel.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                else
                {
                    messageLabel.Text = "Fee must be Numeric.";
                    messageLabel.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                test.TestTypeId = int.Parse(id);
                if(setupManager.IsTestsExists(test))
                {
                    messageLabel.Text = "Test Name already exists. Please, Enter a new name";
                    messageLabel.ForeColor = System.Drawing.Color.Red;
                    testNameTextBox.Focus();
                    return;
                }
                else
                {
                    int rowAffeted = setupManager.SaveTestSetup(test);
                    if(rowAffeted>0)
                    {
                        messageLabel.Text = "Saved Successfully.";
                        messageLabel.ForeColor = System.Drawing.Color.ForestGreen;
                        LoadAllTests();
                    }
                    else
                    {
                        messageLabel.Text = "Insertion Failed.";
                        messageLabel.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
            }
            else
            {
                messageLabel.Text = "Please, Fill all Fields";
                messageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        private void LoadAllTests()
        {
            List<TestTypeSetupView> tests = setupManager.GetAllTests();
            testSetupGridView.DataSource = tests;
            testSetupGridView.DataBind();

        }

        private bool CheckRequeredField()
        {
            if (testNameTextBox.Text != string.Empty && testFeeTextBox.Text != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}