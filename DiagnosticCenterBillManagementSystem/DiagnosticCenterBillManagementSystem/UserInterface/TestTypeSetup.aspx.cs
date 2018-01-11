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
    public partial class TestTypeSetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        TestTypeManager typeManager = new TestTypeManager();
        protected void typeSaveButton_Click(object sender, EventArgs e)
        {
            TestType testType = new TestType();
            testType.Name = typeNameTextBox.Text;
            if (CheckRequeredField())
            {
                if (typeManager.IsTestTypeExists(testType))
                {
                    messageLabel.Text = "Test Type already exists.";
                    messageLabel.ForeColor = System.Drawing.Color.Red;
                    typeNameTextBox.Focus();
                    return;
                }

                int rowAffected = typeManager.SaveTestType(testType);

                if (rowAffected > 0)
                {
                    messageLabel.Text = "Saved Successfully!";
                    messageLabel.ForeColor = System.Drawing.Color.ForestGreen;
                    LoadAllTestType();
                }
                else
                {
                    messageLabel.Text = "Invalid insert.";
                    messageLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                messageLabel.Text = "Please, Enter a Test Type";
                messageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            
        }

        private void LoadAllTestType()
        {
            List<TestType> testsType = typeManager.GetAllTestType();

            testTypeGridView.DataSource = testsType;
            testTypeGridView.DataBind();
        }

        private bool CheckRequeredField()
        {
            if(typeNameTextBox.Text != string.Empty)
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