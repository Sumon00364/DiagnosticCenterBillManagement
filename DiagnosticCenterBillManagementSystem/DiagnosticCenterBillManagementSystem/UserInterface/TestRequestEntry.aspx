<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRequestEntry.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UserInterface.TestRequestEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/css/jquery-ui.css" rel="stylesheet" />
    <script src="../Content/js/jquery-1.10.2.js"></script>
    <script src="../Content/js/jquery-ui.js"></script>
    <script src="../Content/js/jquery-1.4.2.min.js"></script>
    <link href="../Content/css/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="heading">
            <h1>Diagnostic Center Bill Management System</h1>
        </div>
        <div  id="inputFieldset">
            <fieldset style="margin-bottom:10px;">
                <legend>Test Request Entry</legend>
                <table>
                    <tr>
                        <td style="text-align:left">Name of the Patient </td>
                        <td colspan="3">&nbsp; <asp:TextBox ID="patientNameTextBox" runat="server"></asp:TextBox> </td>
                    </tr>
                   <%-- <tr>
                        <td style="text-align:left">Date of Birth</td>
                        <td colspan="3">&nbsp; <asp:TextBox ID="dateOfBirthTextBox" runat="server"></asp:TextBox> </td>
                    </tr>--%>
                    <tr>
                        <td style="text-align:left">Date of Birth</td>
                        <td colspan="3">&nbsp;
                            <input  type="date" id="dateOfBirthTextBox" name="dateOfBirthTextBox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left">Mobile</td>
                        <td colspan="3">&nbsp; <asp:TextBox ID="mobileNoTextBox" runat="server"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td style="text-align:left">Select Test</td>
                        <td colspan="3">&nbsp; <asp:DropDownList ID="testSelectDropDownList" runat="server" ViewStateMode="Enabled" Width="148px" AutoPostBack="true"
                             OnSelectedIndexChanged="testSelectDropDownList_SelectedIndexChanged">
                                               </asp:DropDownList> </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td style="text-align:right">Fee</td>
                        <td style="float:right"><asp:TextBox ID="feeTextBox" runat="server" ReadOnly="true" Width="70px"></asp:TextBox> </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="messageLabel" runat="server"></asp:Label></td>
                        <td></td>
                        <td></td>
                        <td style="float:right"><asp:Button ID="requestEntryAddButton" OnClientClick="calculateFee" Text="Add" runat="server" OnClick="requestEntryAddButton_Click" /></td>                       
                    </tr>
                </table>
            </fieldset>

            
            <asp:GridView Width="340px" ID="testEntryGridView" runat="server" ViewStateMode="Enabled" AllowPaging="true"
                OnPageIndexChanging="testEntryGridView_PageIndexChanging" AutoGenerateColumns="false" HeaderStyle-ForeColor="WhiteSmoke" HeaderStyle-BackColor="ForestGreen">
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
                            <asp:Label CssClass="testFee" ID="feeLabel" class="calculate" onchange="calculate()" runat="server" Text='<%#Eval("Fee") %>'></asp:Label>                                        
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                   
            <table>
                <tr>
                    <td></td>
                    <td>Total :</td>
                    <td><asp:TextBox ID="feeTotal" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:TextBox ID="keepHiddenValue" Visible="false" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button style="float:right" ID="saveButton" Text="Save" runat="server" OnClick="saveButton_Click"/>
                    </td>
                </tr>
                <tr>
                    <td><asp:HyperLink Text="Back to Home" NavigateUrl="~/UserInterface/Index.aspx" runat="server" style="float:left"></asp:HyperLink></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </div>
    </form>
    <script src="../Content/script/RequestEntry.js"></script>
</body>
</html>
