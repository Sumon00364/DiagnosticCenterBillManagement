/// <reference path="D:\Study\SEIP\Project\DiagnosticCenterBillManagementSystem\DiagnosticCenterBillManagementSystem\Service/WebService.asmx" />
var checkDate = new Date();
$("#dateOfBirthTextBox").datepicker({
    maxDate: new Date()
});

//function Confirm() {
//    var confirm_value = document.createElement("INPUT");
//    confirm_value.type = "hidden";
//    confirm_value.name = "confirm_value";
//    if (confirm("Do you want to service confinue?")) {
//        confirm_value.value = "Yes";
//    } else {
//        confirm_value.value = "No";
//    }
//    document.forms[0].appendChild(confirm_value);
//}


//$(document).ready(function () {
//    $("#testSelectDropDownList").change(function () {
//        var selectedVal = $(this).val();

//        //console.log(id);
//        //return false;
//        $.ajax({
//            url: 'TestRequestEntry.aspx/GetFeeAgainstId',
//            data: { id: selectedVal },
//            method: 'get',
//            success: function (data) {
//                console.log(data);
//                var jqueryXml = $(data);
//                $('#feeTextBox').val(jqueryXml.find('Fee').text());
//            },
//            error: function (err) {
//                console.log(err);
//            }
//        });
//    });
//});

//function calculate() {
//    var txtTotal = 0.00;
//    //var passed = false;
//    //var id = 0;

//    $(".calculate").each(function (index, value) {
//        var val = value.value;
//        val = val.replace(",", ".");
//        txtTotal = MathRound(parseFloat(txtTotal) + parseFloat(val));
//    });

//    document.getElementById("<%=totalTextBox.ClientID %>").value = txtTotal.toFixed(2);
//}

//function MathRound(number) {
//    return Math.round(number * 100) / 100;
//}