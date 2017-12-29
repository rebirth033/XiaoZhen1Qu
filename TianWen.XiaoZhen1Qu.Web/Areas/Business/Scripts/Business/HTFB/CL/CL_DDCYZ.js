$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择身份啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
    $("#SYNX").bind("blur", ValidateSYNX);
    $("#SYNX").bind("focus", InfoSYNX);
});
//验证所有
function ValidateAll() {
    if (ValidateRadio("GQ", "忘记选择身份啦")
        & ValidateSelect("DDCCX", "CX", "忘记选择车型啦")
        & ValidateCheck("PP", "忘记选择品牌啦")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
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
        $("#spanSYNX").css("border-color", "#F2272D");
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
            $("#spanSYNX").css("border-color", "#F2272D");
            return false;
        }
    }
} 
//提示使用年限
function InfoSYNX() {
    $("#divSYNXTip").css("display", "block");
    $("#divSYNXTip").attr("class", "Info");
    $("#divSYNXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数');
    $("#spanSYNX").css("border-color", "#bc6ba6");
}
