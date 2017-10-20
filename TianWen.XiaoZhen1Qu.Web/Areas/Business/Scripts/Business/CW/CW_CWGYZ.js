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
//验证售价
function ValidateJG() {
    if ($("#JG").val() === "" || $("#JG").val() === null) {
        $("#divJGTip").css("display", "block");
        $("#divJGTip").attr("class", "Warn");
        $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写价格啦');
        $("#spanJG").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateDecimal($("#JG").val())) {
            $("#divJGTip").css("display", "none");
            $("#spanJG").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divJGTip").css("display", "block");
            $("#divJGTip").attr("class", "Warn");
            $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />价格请填写整数，面议则填0');
            $("#spanJG").css("border-color", "#fd634f");
            return false;
        }
    }
}

//验证所有
function AllValidate() {
    if (ValidateJG() & ValidateBT() & ValidateFWZP() & ValidateLXR() & ValidateLXDH())
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
//提示价格
function InfoJG() {
    $("#divJGTip").css("display", "block");
    $("#divJGTip").attr("class", "Info");
    $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，面议则填0');
}
