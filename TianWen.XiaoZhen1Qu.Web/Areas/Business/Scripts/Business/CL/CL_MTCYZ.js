$(document).ready(function () {
    $("#GLS").bind("blur", ValidateGLS);
    $("#GLS").bind("focus", InfoGLS);
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证公里数
function ValidateGLS() {
    if ($("#GLS").val() === "" || $("#GLS").val() === null) {
        $("#divGLSTip").css("display", "block");
        $("#divGLSTip").attr("class", "Warn");
        $("#divGLSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写公里数啦');
        $("#spanGLS").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#GLS").val())) {
            $("#divGLSTip").css("display", "none");
            $("#spanGLS").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divGLSTip").css("display", "block");
            $("#divGLSTip").attr("class", "Warn");
            $("#divGLSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />公里数填写整数，面议则填0');
            $("#spanGLS").css("border-color", "#fd634f");
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
        if (ValidateNumber($("#JG").val())) {
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
function ValidateAll() {
    if (ValidateJG() & ValidateBT() & ValidateZP() & ValidateLXR() & ValidateLXDH())
        return true;
    else
        return false;
}
//提示公里数
function InfoGLS() {
    $("#divGLSTip").css("display", "inline-block");
    $("#divGLSTip").attr("class", "Info");
    $("#divGLSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数');
}

