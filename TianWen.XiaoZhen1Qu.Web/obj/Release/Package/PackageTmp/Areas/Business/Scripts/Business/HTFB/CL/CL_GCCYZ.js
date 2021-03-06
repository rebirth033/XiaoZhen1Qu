﻿$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证出厂年份
function ValidateGCCCCNF() {
    if (!ValidateSelect("GCCCCNF", "CCNF", "请选择出厂年份")) return false;
    if (!ValidateSelect("GCCCCNF", "CCYF", "请选择出厂月份")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
           & ValidateSelect("GCCCX", "CX", "忘记选择车型啦")
           //& ValidateGCCCCNF()
           & ValidateBCMS("BCMS", "忘记填写详情描述啦")
           & ValidateJG()
           & ValidateCommon())
        return true;
    else
        return false;
}
//验证吨位
function ValidateDW() {
    if ($("#DW").val() === "" || $("#DW").val() === null) {
        $("#divDWTip").css("display", "block");
        $("#divDWTip").attr("class", "Warn");
        $("#divDWTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写吨位啦');
        $("#spanDW").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateDecimal($("#DW").val())) {
            $("#divDWTip").css("display", "none");
            $("#spanDW").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divDWTip").css("display", "block");
            $("#divDWTip").attr("class", "Warn");
            $("#divDWTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />吨位请填写数字');
            $("#spanDW").css("border-color", "#F2272D");
            return false;
        }
    }
}
//验证小时数
function ValidateXSS() {
    if ($("#XSS").val() === "" || $("#XSS").val() === null) {
        $("#divXSSTip").css("display", "block");
        $("#divXSSTip").attr("class", "Warn");
        $("#divXSSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写小时数啦');
        $("#spanXSS").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateDecimal($("#XSS").val())) {
            $("#divXSSTip").css("display", "none");
            $("#spanXSS").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divXSSTip").css("display", "block");
            $("#divXSSTip").attr("class", "Warn");
            $("#divXSSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />小时数请填写数字');
            $("#spanXSS").css("border-color", "#F2272D");
            return false;
        }
    }
}
//提示吨位
function InfoDW() {
    $("#divDWTip").css("display", "block");
    $("#divDWTip").attr("class", "Info");
    $("#divDWTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写数字');
    $("#spanDW").css("border-color", "#bc6ba6");
}
//提示小时数
function InfoXSS() {
    $("#divXSSTip").css("display", "block");
    $("#divXSSTip").attr("class", "Info");
    $("#divXSSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写数字');
    $("#spanXSS").css("border-color", "#bc6ba6");
}