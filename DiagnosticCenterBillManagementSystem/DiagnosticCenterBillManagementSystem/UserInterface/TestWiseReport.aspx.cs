using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BusinessLogic;
using DiagnosticCenterBillManagementSystem.Models;
using System.Data;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace DiagnosticCenterBillManagementSystem.UserInterface
{
    public partial class TestWiseReport : System.Web.UI.Page
    {
        TestReportManager testReportManager = new TestReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            if (fromDateTextBox.Text != string.Empty && toDateTextBox.Text != string.Empty)
            {
                LoadTypeWiseReport();
                GetTotal();
            }
            else
            {
                return;
            }
        }

        protected void pdfId_Click(object sender, EventArgs e)
        {
            PdfGenerator();
        }

        private void LoadTypeWiseReport()
        {
            DateTime fromDate = Convert.ToDateTime(fromDateTextBox.Text);
            DateTime toDate = Convert.ToDateTime(toDateTextBox.Text);
            List<TestReport> testWiseReportsList = testReportManager.GetTypeWiseReport(fromDate, toDate);

            testWiseReportGridView.DataSource = testWiseReportsList;
            testWiseReportGridView.DataBind();
        }

        private void GetTotal()
        {
            double total = 0;
            for (int i = 0; i < testWiseReportGridView.Rows.Count; i++)
            {
                string amount = (testWiseReportGridView.Rows[i].FindControl("totalAmountLabel") as Label).Text;
                total += Convert.ToDouble(amount);
            }

            totalTextBox.Text = total.ToString();
        }

        private void DoPDF()
        {
            PdfPTable pdfTable = new PdfPTable(testWiseReportGridView.HeaderRow.Cells.Count);
            foreach (TableCell headerCell in testWiseReportGridView.HeaderRow.Cells)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text));
                pdfTable.AddCell(pdfCell);
            }

            foreach (GridViewRow gridViewRow in testWiseReportGridView.Rows)
            {
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
                    pdfTable.AddCell(pdfCell);
                }
            }

            
            
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=TestWiseReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }

        private void PdfGenerator()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table width = '100%' cellspacing='0' cellpadding ='2'>");
            stringBuilder.Append("<tr><td align = 'centre'>Test Wise Report</td></tr></table>");
            stringBuilder.Append("</br>");

            stringBuilder.Append("<table border='1'>");
            stringBuilder.Append("<tr>");
            //PdfPTable pdfTable = new PdfPTable(testWiseReportGridView.HeaderRow.Cells.Count);
            foreach (TableCell header in testWiseReportGridView.HeaderRow.Cells)
            {
                stringBuilder.Append("<th style= 'background-color: green'>");
                stringBuilder.Append(header.Text);
                stringBuilder.Append("</th>");
            }
            stringBuilder.Append("</tr>");

            foreach (GridViewRow row in testWiseReportGridView.Rows)
            {
                stringBuilder.Append("<tr>");
                foreach (TableCell column in row.Cells)
                {
                    stringBuilder.Append("<td>");
                    stringBuilder.Append(column.Text);
                    stringBuilder.Append("</td>");
                }
                stringBuilder.Append("</tr>");
            }
            stringBuilder.Append("</table>");

            StringReader strReader = new StringReader(stringBuilder.ToString());
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            HTMLWorker htmlPerser = new HTMLWorker(pdfDocument);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            htmlPerser.Parse(strReader);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=TestWiseReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }

    }
}