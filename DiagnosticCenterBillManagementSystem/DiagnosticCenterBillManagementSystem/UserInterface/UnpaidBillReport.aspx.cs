using System;
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
using DiagnosticCenterBillManagementSystem.BusinessLogic;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.UserInterface
{
    public partial class UnpaidBillReport : System.Web.UI.Page
    {
        BillReportManager billReportManager = new BillReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            LoadUnpaidBillReport();
            GetTotal();
        }

        protected void pdfId_Click(object sender, EventArgs e)
        {
            DoPDF();
        }

        private void LoadUnpaidBillReport()
        {
            DateTime fromDate = Convert.ToDateTime(fromDateTextBox.Text);
            DateTime toDate = Convert.ToDateTime(toDateTextBox.Text);
            List<BillReport> unpaidBillReportsList = billReportManager.UnpaidBillReport(fromDate, toDate);

            unpaidBillGridView.DataSource = unpaidBillReportsList;
            unpaidBillGridView.DataBind();
        }

        private void GetTotal()
        {
            double total = 0;
            for (int i = 0; i < unpaidBillGridView.Rows.Count; i++)
            {
                string amount = (unpaidBillGridView.Rows[i].FindControl("billAmountLabel") as Label).Text;
                total += Convert.ToDouble(amount);
            }

            totalTextBox.Text = total.ToString();
        }

        private void DoPDF()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table width = '100%' cellspacing='0' cellpadding ='2'>");
            stringBuilder.Append("<tr><td align = 'centre'>Unpaid Bill Report</td></tr></table>");
            stringBuilder.Append("</br>");

            PdfPTable pdfTable = new PdfPTable(unpaidBillGridView.HeaderRow.Cells.Count);
            foreach (TableCell headerCell in unpaidBillGridView.HeaderRow.Cells)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text));
                pdfTable.AddCell(pdfCell);
            }

            foreach (GridViewRow gridViewRow in unpaidBillGridView.Rows)
            {
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
                    pdfTable.AddCell(pdfCell);
                }
            }


            StringReader strReader = new StringReader(stringBuilder.ToString());
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            HTMLWorker htmlPerser = new HTMLWorker(pdfDocument);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            htmlPerser.Parse(strReader);
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=UnpaidBillReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
    }
}