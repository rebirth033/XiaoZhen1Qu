﻿$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", ""); });
    $(".div_clys").bind("click", function () { ValidateCLYS(); });
    $("#XSLC").bind("blur", ValidateXSLC);
    $("#XSLC").bind("focus", InfoXSLC);
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证轿车
function ValidateJCPP() {
    if (!ValidateSelect("JCPP", "PP", "请选择品牌")) return false;
    return true;
}
//验证轿车
function ValidateSCSPSJ() {
    if (!ValidateSelect("SCSPSJ", "SPNF", "请选择上牌年份")) return false;
    if (!ValidateSelect("SCSPSJ", "SPYF", "请选择上牌月份")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateJCPP() 
        & ValidateRadio("SF", "忘记选择身份啦") 
        & ValidateCLYS()
        & ValidateSCSPSJ()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXSLC()
        & ValidateXXDZ()
        & ValidateJG()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证行驶里程
function ValidateXSLC() {
    if ($("#XSLC").val() === "" || $("#XSLC").val() === null) {
        $("#divXSLCTip").css("display", "block");
        $("#divXSLCTip").attr("class", "Warn");
        $("#divXSLCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写行驶里程啦');
        $("#spanXSLC").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateDecimal($("#XSLC").val())) {
            $("#divXSLCTip").css("display", "none");
            $("#spanXSLC").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divXSLCTip").css("display", "block");
            $("#divXSLCTip").attr("class", "Warn");
            $("#divXSLCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />行驶里程请填写数字');
            $("#spanXSLC").css("border-color", "#F2272D");
            return false;
        }
    }
}
//验证车辆颜色
function ValidateCLYS() {
    var value = "";
    $(".div_clys").each(function () {
        if ($(this).css("background-color") === "rgb(188, 107, 166)")
            value = $(this).find(".span_clys_right")[0].innerHTML;
    });
    if (value === "") {
        $("#divCLYSTip").css("display", "block");
        $("#divCLYSTip").attr("class", "Warn");
        $("#divCLYSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记选择车辆颜色啦');
        return false;
    } else {
        $("#divCLYSTip").css("display", "none");
        return true;
    }
}
//行驶里程
function InfoXSLC() {
    $("#divXSLCTip").css("display", "block");
    $("#divXSLCTip").attr("class", "Info");
    $("#divXSLCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写行驶里程');
    $("#spanXSLC").css("border-color", "#bc6ba6");
}