<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSetup.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UserInterface.TestSetup" %>

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
            <legend>Test Setup</legend>
                <div>
                <table>
                    <tr>
                        <td style="text-align:left">Test Name </td>
                        <td>&nbsp; <asp:TextBox ID="testNameTextBox" runat="server"></asp:TextBox> </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align:left">Fee</td>
                        <td>&nbsp; <asp:TextBox ID="testFeeTextBox" runat="server"></asp:TextBox>&nbsp; </td>
                        <td style="text-align:right;font-family:'Segoe Print';">BDT</td>
                    </tr>
                    <tr>
                        <td style="text-align:left">Test Type</td>
                        <td>&nbsp; <asp:DropDownList ID="testTypeDropDownList" runat="server"></asp:DropDownList> </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="float:right"><asp:Button ID="testSetupSaveButton" runat="server" Text="Save" OnClick="testSetupSaveButton_Click"/></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="3"><asp:Label ID="messageLabel" runat ="server"></asp:Label></td>
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
                            <asp:TemplateField HeaderText="Test Name">
                                <ItemTemplate>
                                    <%#Eval("Name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fee">
                                <ItemTemplate>
                                    <%#Eval("Fee") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type">
                                <ItemTemplate>
                                    <%#Eval("Type") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:HyperLink Text="Back to Home" NavigateUrl="~/UserInterface/Index.aspx" runat="server" style="float:right"></asp:HyperLink>
                </div>
        </fieldset>
        </div>
    </div>
    </form>
</body>
</html>
