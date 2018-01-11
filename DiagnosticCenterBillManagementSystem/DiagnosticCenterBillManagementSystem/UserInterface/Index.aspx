<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UserInterface.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Diagnostic Center Bill Management System</title>
    <link href="../Content/css/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="heading">
            <h1>Diagnostic Center Bill Management System</h1>
        </div>
        <div id="menu">
            <div class="entryMenu">
                <legend>Entry</legend>
                <ul>
                    <li>
                    <asp:HyperLink runat="server" NavigateUrl="~/UserInterface/TestTypeSetup.aspx" Text="Test Type Setup" ToolTip="To set what type of test"></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink runat="server" NavigateUrl="~/UserInterface/TestSetup.aspx" Text="Test Setup"></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink runat="server" NavigateUrl="~/UserInterface/TestRequestEntry.aspx" Text="Test Request Entry"></asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink runat="server" NavigateUrl="~/UserInterface/Payment.aspx" Text="Paymet"></asp:HyperLink>
                </li>
                </ul>
            </div>
            <div class="reportMenu">
                <legend>Report</legend>
                <ul>
                
                    <li>
                        <asp:HyperLink runat="server" NavigateUrl="~/UserInterface/TestWiseReport.aspx" Text="Test Wise Report"></asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink runat="server" NavigateUrl="~/UserInterface/TypeWiseReport.aspx" Text="Type Wise Report"></asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink runat="server" NavigateUrl="~/UserInterface/UnpaidBillReport.aspx" Text="Unpaid Bill Report"></asp:HyperLink>
                    </li>
                </ul>
            </div>
            <div class="clearFix"></div>
        </div>
    </div>
    </form>
</body>
</html>
