$(document).ready(function () {
    $("#CDMJ").bind("blur", ValidateCDMJ);
    $("#CDMJ").bind("focus", InfoCDMJ);
});
//验证所有
function ValidateAll() {
    if (ValidateSelect("HPGKRNRS", "KRNRS", "忘记选择可容纳人数啦")
        & ValidateCheck("SNSB", "忘记选择室内设备啦")
        & ValidateJG()
        & ValidateCDMJ()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateFWQY()
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证场地面积
function ValidateCDMJ() {
    if ($("#CDMJ").val() === "" || $("#CDMJ").val() === null) {
        $("#divCDMJTip").css("display", "block");
        $("#divCDMJTip").attr("class", "Warn");
        $("#divCDMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写场地面积啦');
        $("#spanCDMJ").css("border-color", "#F2272D");
        return false;
    } else {
        $("#divCDMJTip").css("display", "none");
        $("#spanCDMJ").css("border-color", "#cccccc");
        return true;
    }
}
//提示场地面积
function InfoCDMJ() {
    $("#divCDMJTip").css("display", "block");
    $("#divCDMJTip").attr("class", "Info");
    $("#divCDMJTip").html('');
    $("#divCDMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请输入场地面积');
    $("#spanCDMJ").css("border-color", "#bc6ba6");
}