<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UserInterface.Payment" %>

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
            <legend>Pay Bill</legend>
            <div>
                <table>
                    <tr>
                        <td>Bill No</td>
                        <td>&nbsp; <asp:TextBox ID="searchTextBox" runat="server"></asp:TextBox></td>
                        <td><asp:Button ID="serchButton" Text="Search" runat="server" OnClick="serchButton_Click"/></td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:GridView ID="testSetupGridView" runat="server" AutoGenerateColumns="false" HeaderStyle-ForeColor="WhiteSmoke" HeaderStyle-BackColor="ForestGreen">
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate>
                                    <span><%#Container.DataItemIndex + 1%></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Test">
                                <ItemTemplate>
                                    <%#Eval("Name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fee">
                                <ItemTemplate>
                                    <%#Eval("Fee") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                <table>
                    <tr>
                        <td>Bill Date</td>
                        <td><asp:Label ID="dateLabel" runat="server" Text="<Bill Amount>"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Total Fee</td>
                        <td><asp:Label ID="totalFeeLabel" runat="server" Text="<Amount>"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Paid Amount</td>
                        <td><asp:Label ID="paidAmountLabel" runat="server" Text="<Amount>"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Due Amount</td>
                        <td><asp:Label ID="dueLabel" runat="server" Text="<Amount>"></asp:Label></td>
                    </tr>
                    <tr></tr>
                    <tr>
                        <td>Amount</td>
                        <td><asp:TextBox ID="amountTextBox" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="float:right;"><asp:Button ID="payButton" runat="server" Text="Pay" OnClick="payButton_Click"></asp:Button></td>
                    </tr>
                </table>
                <asp:HyperLink Text="Back to Home" NavigateUrl="~/UserInterface/Index.aspx" runat="server" style="float:left"></asp:HyperLink>
            </div>
        </fieldset>
        </div>
    </div>
    </form>
</body>
</html>
