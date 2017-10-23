$(document).ready(function () {
    $("#NL").bind("blur", ValidateNL);
    $("#NL").bind("focus", InfoNL);
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证年龄
function ValidateNL() {
    if ($("#NL").val() === "" || $("#NL").val() === null) {
        $("#divNLTip").css("display", "block");
        $("#divNLTip").attr("class", "Warn");
        $("#divNLTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写年龄啦');
        $("#spanNL").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateDecimal($("#NL").val())) {
            $("#divNLTip").css("display", "none");
            $("#spanNL").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divNLTip").css("display", "block");
            $("#divNLTip").attr("class", "Warn");
            $("#divNLTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />年龄请填写整数');
            $("#spanNL").css("border-color", "#fd634f");
            return false;
        }
    }
}


//验证所有
function ValidateAll() {
    if (ValidateJG() & ValidateBT() & ValidateZP() & ValidateLXR() & ValidateLXDH())
        return true;
    else
        return false;
}
//提示年龄
function InfoNL() {
    $("#divNLTip").css("display", "block");
    $("#divNLTip").attr("class", "Info");
    $("#divNLTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数');
}

