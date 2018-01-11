<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeSetup.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UserInterface.TestTypeSetup" %>

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
                <legend>Test Type Setup</legend>
                <div>
                    <table>
                        <tr>
                            <td><asp:Label Text="Type Name " runat="server" /></td>
                            <td>&nbsp; <asp:TextBox ID="typeNameTextBox" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="float:right"><asp:Button Text="Save" ID="typeSaveButton" runat="server" OnClick="typeSaveButton_Click" /></td>
                        </tr>
                        <tr>
                            <td colspan="2"><asp:Label ID="messageLabel" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </div>
                <div>
                    <asp:GridView ID="testTypeGridView" runat="server" AutoGenerateColumns="false" HeaderStyle-ForeColor="WhiteSmoke" HeaderStyle-BackColor="ForestGreen">
                        <Columns>
                            <asp:TemplateField HeaderText="SL" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <span><%#Container.DataItemIndex + 1%></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type Name" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%#Eval("Name") %>
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
