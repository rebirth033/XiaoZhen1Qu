﻿$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择供求啦"); });
    $("#LPMC").bind("blur", ValidateLPMC);
    $("#LPMC").bind("focus", InfoLPMC);
    $("#DD").bind("blur", ValidateDD);
    $("#DD").bind("focus", InfoDD);
    $("#ZJ").bind("blur", ValidateZJ);
    $("#ZJ").bind("focus", function () { InfoSpanInput("ZJ", "租金请填写整数，默认为面议"); });
    $("#SJ").bind("blur", ValidateSJ);
    $("#SJ").bind("focus", function () { InfoSpanInput("SJ", "售价请填写整数，默认为面议"); });
    $("#MJ").bind("blur", ValidateMJ);
    $("#ZJ").bind("focus", function () { InfoSpanInput("MJ", "面积请填写整数"); });
});
//验证所有
function ValidateAll() {
    if (GetGQ() === "出售") {
        if (ValidateRadio("GQ", "忘记选择供求啦")
            & ValidateBCMS("BCMS", "忘记填写补充描述啦")
            & ValidateSZQY()
            & ValidateSJ()
            & ValidateMJ()
            & ValidateCommonWithoutZP())
            return true;
        else
            return false;
    }
    else {
        if (ValidateRadio("GQ", "忘记选择供求啦")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateSZQY()
        & ValidateZJ()
        & ValidateMJ()
        & ValidateCommonWithoutZP())
            return true;
        else
            return false;
    }
}
//验证租金
function ValidateZJ() {
    if ($("#ZJ").val() === "" || $("#ZJ").val() === null) {
        $("#divZJTip").css("display", "block");
        $("#divZJTip").attr("class", "Warn");
        $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写租金啦');
        $("#spanZJ").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber($("#ZJ").val())) {
            $("#divZJTip").css("display", "none");
            $("#spanZJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divZJTip").css("display", "block");
            $("#divZJTip").attr("class", "Warn");
            $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />租金请填写整数，默认为面议');
            $("#spanZJ").css("border-color", "#F2272D");
            return false;
        }
    }
}
//验证售价
function ValidateSJ() {
    if ($("#SJ").val() === "" || $("#SJ").val() === null) {
        $("#divSJTip").css("display", "block");
        $("#divSJTip").attr("class", "Warn");
        $("#divSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写售价啦');
        $("#spanSJ").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber($("#SJ").val())) {
            $("#divSJTip").css("display", "none");
            $("#spanSJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divSJTip").css("display", "block");
            $("#divSJTip").attr("class", "Warn");
            $("#divSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />售价请填写整数，默认为面议');
            $("#spanSJ").css("border-color", "#F2272D");
            return false;
        }
    }
}
//验证面积
function ValidateMJ() {
    if ($("#MJ").val() === "" || $("#MJ").val() === null) {
        $("#divMJTip").css("display", "block");
        $("#divMJTip").attr("class", "Warn");
        $("#divMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写面积啦');
        $("#spanMJ").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber($("#ZJ").val())) {
            $("#divMJTip").css("display", "none");
            $("#spanMJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divMJTip").css("display", "block");
            $("#divMJTip").attr("class", "Warn");
            $("#divMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />面积请填写整数，默认为面议');
            $("#spanMJ").css("border-color", "#F2272D");
            return false;
        }
    }
}