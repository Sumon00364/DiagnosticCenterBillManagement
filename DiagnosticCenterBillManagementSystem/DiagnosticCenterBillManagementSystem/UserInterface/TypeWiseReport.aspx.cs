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
    public partial class TypeWiseReport : System.Web.UI.Page
    {
        TypeReportManager typeReportManager = new TypeReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            LoadTypeWiseReport();
            GetTotal();
        }

        protected void pdfId_Click(object sender, EventArgs e)
        {
            DoPDF();
        }

        private void LoadTypeWiseReport()
        {
            DateTime fromDate = Convert.ToDateTime(fromDateTextBox.Text);
            DateTime toDate = Convert.ToDateTime(toDateTextBox.Text);
            List<TypeReport> testWiseReportsList = typeReportManager.GetTypeWiseReport(fromDate, toDate);

            typeReportGridView.DataSource = testWiseReportsList;
            typeReportGridView.DataBind();
        }

        private void GetTotal()
        {
            double total = 0;
            for (int i = 0; i < typeReportGridView.Rows.Count; i++)
            {
                string amount = (typeReportGridView.Rows[i].FindControl("totalAmountLabel") as Label).Text;
                total += Convert.ToDouble(amount);
            }

            totalTextBox.Text = total.ToString();
        }

        private void DoPDF()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<table width = '100%' cellspacing='0' cellpadding ='2'>");
            stringBuilder.Append("<tr><td align = 'centre'>Type Wise Report</td></tr></table>");
            stringBuilder.Append("</br>");

            PdfPTable pdfTable = new PdfPTable(typeReportGridView.HeaderRow.Cells.Count);
            foreach (TableCell headerCell in typeReportGridView.HeaderRow.Cells)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text));
                pdfTable.AddCell(pdfCell);
            }

            foreach (GridViewRow gridViewRow in typeReportGridView.Rows)
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
            Response.AppendHeader("content-disposition", "attachment;filename=TypeWiseReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
    }
}