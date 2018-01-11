<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWiseReport.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UserInterface.TestWiseReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/css/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="heading">
            <h1>Diagnostic Center Bill Management System</h1>
        </div>
        <div>
        <fieldset id="inputFieldset">
            <legend>Test Wise Report</legend>
            <table>
                <tr>
                    <td style="float:left;">From Date</td>
                    <td style="float:right;"><asp:TextBox ID="fromDateTextBox" runat="server"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="float:left;">To Date</td>
                    <td style="float:right;"><asp:TextBox ID="toDateTextBox" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="showButton" Text="Show" runat="server" OnClick="showButton_Click" /></td>
                </tr>
            </table>
            <asp:GridView runat="server" ID="testWiseReportGridView" AutoGenerateColumns="false"
                HeaderStyle-ForeColor="WhiteSmoke" HeaderStyle-BackColor="ForestGreen">
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate>
                                    <span><%#Container.DataItemIndex + 1%></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Test Name">
                                <ItemTemplate>
                                    <%#Eval("Name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Test">
                                <ItemTemplate>
                                    <%#Eval("TotalNoTest") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Amount">
                                <ItemTemplate>
                                    <asp:Label ID="totalAmountLabel" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label> 
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
            <table id="totalTable" name="totalTable">
                <tr>
                    <td><asp:Button ID="pdfId" runat="server" Text="PDF" OnClick="pdfId_Click"/></td>
                    <td><asp:Label ID="totalLabel" runat="server" Text="Total"></asp:Label></td>
                    <td><asp:TextBox ID="totalTextBox" runat="server" ReadOnly="true"></asp:TextBox></td>
                </tr>
            </table>
            <asp:HyperLink Text="Back to Home" NavigateUrl="~/UserInterface/Index.aspx" runat="server" style="float:left"></asp:HyperLink>
        </fieldset>
        </div>
    </div>
    </form>
</body>
</html>
