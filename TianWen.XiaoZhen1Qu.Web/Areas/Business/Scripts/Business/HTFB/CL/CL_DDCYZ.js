﻿$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择供求啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
    $("#SYNX").bind("blur", ValidateSYNX);
    $("#SYNX").bind("focus", InfoSYNX);
});
//验证所有
function ValidateAll() {
    if (ValidateRadio("GQ", "忘记选择供求啦")
        & ValidateSelect("DDCPP", "PP", "请选择品牌")
        & ValidateSelect("DDCDCDY", "DCDY", "请选择电池电压")
        & ValidateSelect("DDCDCRL", "DCRL", "请选择电池容量")
        & ValidateSelect("XJCD", "XJ", "请选择新旧")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateSYNX()
        & ValidateSZQY()
        & ValidateJG()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证使用年限
function ValidateSYNX() {
    if ($("#SYNX").val() === "" || $("#SYNX").val() === null) {
        $("#divSYNXTip").css("display", "block");
        $("#divSYNXTip").attr("class", "Warn");
        $("#divSYNXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写使用年限啦');
        $("#spanSYNX").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#SYNX").val())) {
            $("#divSYNXTip").css("display", "none");
            $("#spanSYNX").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divSYNXTip").css("display", "block");
            $("#divSYNXTip").attr("class", "Warn");
            $("#divSYNXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />使用年限请填写整数');
            $("#spanSYNX").css("border-color", "#fd634f");
            return false;
        }
    }
} 
//提示使用年限
function InfoSYNX() {
    $("#divSYNXTip").css("display", "block");
    $("#divSYNXTip").attr("class", "Info");
    $("#divSYNXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数');
    $("#spanSYNX").css("border-color", "#ad5b97");
}
