using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.BusinessLogic;

namespace DiagnosticCenterBillManagementSystem.UserInterface
{
    public partial class TestRequestEntry : System.Web.UI.Page
    {
        TestSetupManager setupManager = new TestSetupManager();
        PatientInfoManager patientInfoManager = new PatientInfoManager();
        BillManager billManager = new BillManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDLBound();
                AddDefaultRecordGridView();
            }
            else
            {
                int ddlSortValue = int.Parse(testSelectDropDownList.SelectedValue);
                if (ddlSortValue == 0)
                {
                    testSelectDropDownList_SelectedIndexChanged(this, EventArgs.Empty);
                }
            }

        }
        protected void testSelectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = testSelectDropDownList.SelectedValue;
            if(id != "0")
            {
                feeTextBox.Text = setupManager.GetFee(id).ToString();
            }

        }

        protected void requestEntryAddButton_Click(object sender, EventArgs e)
        {
            if (testSelectDropDownList.SelectedIndex > 0)
            {
                LoadGridData();
                GetTotal();
                feeTextBox.Text = string.Empty;
            }
            else
            {
                return;
            }
        }
        protected void testEntryGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadGridData();
        }
        
        protected void saveButton_Click(object sender, EventArgs e)
        {
            string name = patientNameTextBox.Text;
            DateTime date = Convert.ToDateTime(dateOfBirthTextBox.Value);
            string mobile = mobileNoTextBox.Text;
            Patient patient = new Patient(name, date, mobile);
            if (CheckRequiredField())
            {
                if (patientInfoManager.IsPatientExist(patient))
                {
                    SavePatientTestInfo();
                    SaveBillAmount();
                }
                else
                {
                    patientInfoManager.SavePatient(patient);
                    SavePatientTestInfo();
                    SaveBillAmount();
                }
            }

            InvoiceReport();
        }
        protected void LoadGridData()
        {
            if (ViewState["TestsSetup"] != null)
            {
                DataTable currentTable = (DataTable)ViewState["TestsSetup"];
                DataRow currentRow = null;
                if (currentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= currentTable.Rows.Count; i++)
                    {
                        currentRow = currentTable.NewRow();
                        currentRow["Name"] = testSelectDropDownList.SelectedItem.Text;
                        currentRow["Fee"] = feeTextBox.Text;
                    }

                    if (currentTable.Rows[0][1].ToString() == string.Empty)
                    {
                        currentTable.Rows[0].Delete();
                        currentTable.AcceptChanges();
                    }

                    for (int i = 0; i < currentTable.Rows.Count; i++)
                    {
                        if (currentTable.Rows[i][1].ToString() == testSelectDropDownList.SelectedItem.Text)
                        {
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    currentTable.Rows.Add(currentRow);
                    ViewState["TestsSetup"] = currentTable;
                    testEntryGridView.DataSource = currentTable;
                    testEntryGridView.DataBind();

                }
            }

        }
        protected void AddDefaultRecordGridView()
        {
            DataTable dataTable = new DataTable("TestsSetup");
            DataRow dataRow = null;
            dataTable.Columns.Add(new DataColumn("SL"));
            dataTable.Columns.Add(new DataColumn("Name"));
            dataTable.Columns.Add(new DataColumn("Fee"));
            dataRow = dataTable.NewRow();
            dataTable.Rows.Add(dataRow);

            ViewState["TestsSetup"] = dataTable;

            testEntryGridView.DataSource = dataTable;
            testEntryGridView.DataBind();
        }
        protected void DDLBound()
        {
            List<TestsSetup> tests = setupManager.GetAllTestWithoutType();
            testSelectDropDownList.DataTextField = "Name";
            testSelectDropDownList.DataValueField = "Id";
            testSelectDropDownList.DataSource = tests;
            testSelectDropDownList.DataBind();
            testSelectDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
        }

        private void GetTotal()
        {
            double total = 0;
            string hiddenValue = keepHiddenValue.Text;
            if(hiddenValue != string.Empty)
            {
                total = Convert.ToDouble(hiddenValue);
            }
            string value = feeTextBox.Text;
            if(value != string.Empty)
            {
                total += Convert.ToDouble(value);
                feeTotal.Text = total.ToString();
                keepHiddenValue.Text = total.ToString();
            }
        }

        private bool CheckRequiredField()
        {
            string name = patientNameTextBox.Text;
            string date = dateOfBirthTextBox.Value;
            string mobile = mobileNoTextBox.Text;
            if(name != string.Empty && date != string.Empty && mobile != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SavePatient()
        {
            string name = patientNameTextBox.Text;
            DateTime date = Convert.ToDateTime(dateOfBirthTextBox.Value);
            string mobile = mobileNoTextBox.Text;
            Patient patient = new Patient(name, date, mobile);            
            if(CheckRequiredField())
            {
                patientInfoManager.SavePatient(patient);
            }
            else
            {
                messageLabel.Text = "Pateient info does not empty.";
                messageLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        private void SavePatientTestInfo()
        {
            TestsSetup testSet = new TestsSetup();
            PatientTest test = new PatientTest();

            if (ViewState["TestsSetup"] != null)
            {
                DataTable currentTable = (DataTable)ViewState["TestsSetup"];

                for (int i = 0; i < currentTable.Rows.Count; i++)
                {
                    testSet.Name = currentTable.Rows[i][1].ToString();
                    test.Mobile = mobileNoTextBox.Text;
                    patientInfoManager.SavePatientTest(test, testSet);
                }
            }
        }

        private void SaveBillAmount()
        {
            Payments payment = new Payments();
            payment.TotalFee = Convert.ToDouble(feeTotal.Text);
            payment.Mobile = mobileNoTextBox.Text;
            billManager.SaveTotalBill(payment);
        }

        private void InvoiceReport()
        {
            int lastInsertedBillNo = billManager.LastInsertedBillNo();
            string name = patientNameTextBox.Text;

            LoadGridData();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table width = '100%' cellspacing='0' cellpadding ='2'");
            stringBuilder.Append("<tr><td align = 'centre'>Bill No.</td>");
            stringBuilder.Append("<td>");
            stringBuilder.Append(lastInsertedBillNo);
            stringBuilder.Append("</td></tr>");
            stringBuilder.Append("<tr><td align = 'centre'>Patient</td>");
            stringBuilder.Append("<td>");
            stringBuilder.Append(name);
            stringBuilder.Append("</td></tr></table>");

            StringReader strReader = new StringReader(stringBuilder.ToString());

            PdfPTable pdfTable = new PdfPTable(testEntryGridView.HeaderRow.Cells.Count);

            foreach (TableCell headerCell in testEntryGridView.HeaderRow.Cells)
            {
                PdfPCell tableCell = new PdfPCell(new Phrase(headerCell.Text));
                pdfTable.AddCell(tableCell);
            }

            foreach (GridViewRow gridViewRow in testEntryGridView.Rows)
            {
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
                    pdfTable.AddCell(pdfCell);
                }
            }

            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            HTMLWorker htmlPerser = new HTMLWorker(pdfDocument);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            htmlPerser.Parse(strReader);
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=Test.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
    }
}