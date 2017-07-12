$(document).ready(function () {
    $("#XQMC").bind("blur", ValidateXQMC);
    $("#XQMC").bind("blur", HideXQMCList);
    $("#XQMC").bind("focus", InfoXQMC);
    $("#S").bind("blur", ValidateFWLX_S);
    $("#S").bind("focus", InfoFWLX_S);
    $("#T").bind("blur", ValidateFWLX_T);
    $("#T").bind("focus", InfoFWLX_T);
    $("#W").bind("blur", ValidateFWLX_W);
    $("#W").bind("focus", InfoFWLX_W);
    $("#PFM").bind("blur", ValidateFWLX_PFM);
    $("#PFM").bind("focus", InfoFWLX_PFM);
    $("#C").bind("blur", ValidateLCFB_C);
    $("#C").bind("focus", InfoLCFB_C);
    
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

function ValidateFWLX_S() {
    if ($("#S").val() === "" || $("#S").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="http://10.0.1.165/XiaoZhen1Qu/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写室啦');
        $("#S").css("border-color", "#fd634f");
    } else {
        $("#divFWLXTip").css("display", "none");
        $("#S").css("border-color", "#cccccc");
    }
}

function InfoFWLX_S() {
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="http://10.0.1.165/XiaoZhen1Qu/Areas/Business/Css/images/info.png" class="imgTip" />填写1、2、3等数字，不能是0');
    $("#S").css("border-color", "#5bc0de");
}

function ValidateFWLX_T() {
    if ($("#T").val() === "" || $("#T").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="http://10.0.1.165/XiaoZhen1Qu/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写厅啦');
        $("#T").css("border-color", "#fd634f");
    } else {
        $("#divFWLXTip").css("display", "none");
        $("#T").css("border-color", "#cccccc");
    }
}

function InfoFWLX_T() {
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="http://10.0.1.165/XiaoZhen1Qu/Areas/Business/Css/images/info.png" class="imgTip" />填写1、2、3等数字，没有请填0');
    $("#T").css("border-color", "#5bc0de");
}

function ValidateFWLX_W() {
    if ($("#W").val() === "" || $("#W").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="http://10.0.1.165/XiaoZhen1Qu/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写卫啦');
        $("#W").css("border-color", "#fd634f");
    } else {
        $("#divFWLXTip").css("display", "none");
        $("#W").css("border-color", "#cccccc");
    }
}

function InfoFWLX_W() {
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="http://10.0.1.165/XiaoZhen1Qu/Areas/Business/Css/images/info.png" class="imgTip" />填写1、2、3等数字，没有请填0');
    $("#W").css("border-color", "#5bc0de");
}

function ValidateFWLX_PFM() {
    if ($("#PFM").val() === "" || $("#PFM").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="http://10.0.1.165/XiaoZhen1Qu/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写面积啦');
        $("#PFM").css("border-color", "#fd634f");
    } else {
        $("#divFWLXTip").css("display", "none");
        $("#PFM").css("border-color", "#cccccc");
    }
}

function InfoFWLX_PFM() {
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="http://10.0.1.165/XiaoZhen1Qu/Areas/Business/Css/images/info.png" class="imgTip" />填写1、2、3等数字，不能是0');
    $("#PFM").css("border-color", "#5bc0de");
}

function ValidateLCFB_C() {
    if ($("#C").val() === "" || $("#C").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="http://10.0.1.165/XiaoZhen1Qu/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写楼层啦');
        $("#C").css("border-color", "#fd634f");
    } else {
        $("#divFWLXTip").css("display", "none");
        $("#C").css("border-color", "#cccccc");
    }
}

function InfoLCFB_C() {
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="http://10.0.1.165/XiaoZhen1Qu/Areas/Business/Css/images/info.png" class="imgTip" />填写数字，地下室用负数填写，最多可填写两位数喔');
    $("#C").css("border-color", "#5bc0de");
}
