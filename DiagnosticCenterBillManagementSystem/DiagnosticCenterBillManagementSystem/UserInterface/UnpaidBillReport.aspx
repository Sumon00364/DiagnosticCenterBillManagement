<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnpaidBillReport.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UserInterface.UnpaidBillReport" %>

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
            <legend>Unpaid Bill Report</legend>
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
            <asp:GridView ID="unpaidBillGridView" runat="server" AutoGenerateColumns="false" HeaderStyle-ForeColor="WhiteSmoke" HeaderStyle-BackColor="ForestGreen">
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate>
                                    <span><%#Container.DataItemIndex + 1%></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bill Number">
                                <ItemTemplate>
                                    <%#Eval("BillNo") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact No">
                                <ItemTemplate>
                                    <%#Eval("Mobile") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Patient Name">
                                <ItemTemplate>
                                    <%#Eval("Patient") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bill Amount">
                                <ItemTemplate>
                                    <asp:Label ID="billAmountLabel" runat="server" Text='<%#Eval("BillAmount") %>'></asp:Label>                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
            <table>
                <tr>
                    <td><asp:Button ID="pdfId" runat="server" Text="PDF" OnClick="pdfId_Click"/></td>
                    <td><asp:Label runat="server" Text="Total"></asp:Label></td>
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
