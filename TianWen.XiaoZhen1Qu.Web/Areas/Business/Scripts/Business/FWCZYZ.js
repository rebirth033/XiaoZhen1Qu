$(document).ready(function () {
    $("#XQMC").bind("blur", ValidateXQMC);
    $("#XQMC").bind("blur", HideXQMCList);
    $("#XQMC").bind("focus", InfoXQMC);
    $("#S").bind("blur", ValidateFWLX);
});

function ValidateXQMC() {
    if ($("#XQMC").val() === "" || $("#XQMC").val() === null) {
        $("#divXQMCTip").css("display", "block");
        $("#divXQMCTip").attr("class", "Warn");
        $("#divXQMCTip").html('<img src="http://10.0.1.165/XiaoZhen1Qu/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写小区名称啦');
        $("#XQMC").css("border-color", "#fd634f");
    } else {
        $("#divXQMCTip").css("display", "none");
        $("#XQMC").css("border-color", "#cccccc");
    }
}

function InfoXQMC() {
    $("#divXQMCTip").attr("class", "Info");
    $("#divXQMCTip").html('<img src="http://10.0.1.165/XiaoZhen1Qu/Areas/Business/Css/images/info.png" class="imgTip" />2-20个汉字,不能填写电话、特殊符号');
    $("#XQMC").css("border-color", "#5bc0de");
}

function HideXQMCList() {
    $("#divXQMClist").css("display", "none");
}


function ValidateFWLX() {
    if ($("#S").val() === "" || $("#S").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divXQMCTip").html('<img src="http://10.0.1.165/XiaoZhen1Qu/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写小区名称啦');
        $("#XQMC").css("border-color", "#fd634f");
    } else {
        $("#divXQMCTip").css("display", "none");
        $("#XQMC").css("border-color", "#cccccc");
    }
}

function InfoFWLX() {
    $("#divXQMCTip").attr("class", "Info");
    $("#divXQMCTip").html('<img src="http://10.0.1.165/XiaoZhen1Qu/Areas/Business/Css/images/info.png" class="imgTip" />2-20个汉字,不能填写电话、特殊符号');
    $("#XQMC").css("border-color", "#5bc0de");
}
