$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择供求啦"); });
    $("#divXSQK").find(".div_radio").bind("click", function () { ValidateRadio("XSQK", "忘记选择行驶情况啦"); });
    $("#GLS").bind("blur", ValidateGLS);
    $("#GLS").bind("focus", InfoGLS);
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证所有
function ValidateAll() {
    if (GetXSQK() !== "已行使") {
        if (ValidateRadio("GQ", "忘记选择供求啦")
            & ValidateSelect("MTCLB", "LB", "忘记选择车型啦")
            & ValidateSelect("MTCPP", "PP", "忘记选择品牌啦")
            & ValidateRadio("XSQK", "忘记选择行驶情况啦")
            & ValidateBCMS("BCMS", "忘记填写补充描述啦")
            & ValidateSZQY()
            & ValidateJG()
            & ValidateCommon())
            return true;
        else
            return false;
    } else {
        if (ValidateRadio("GQ", "忘记选择供求啦")
            & ValidateSelect("MTCLB", "LB", "忘记选择车型啦")
            & ValidateSelect("MTCPP", "PP", "忘记选择品牌啦")
            & ValidateRadio("XSQK", "忘记选择行驶情况啦")
            & ValidateSelect("MTCGCSJ", "GCSJ", "忘记选择购车时间啦")
            & ValidateBCMS("BCMS", "忘记填写补充描述啦")
            & ValidateSZQY()
            & ValidateJG()
            & ValidateGLS()
            & ValidateCommon())
            return true;
        else
            return false;
    }
}
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
            $("#divGLSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />公里数填写整数，默认为面议');
            $("#spanGLS").css("border-color", "#fd634f");
            return false;
        }
    }
}
//提示公里数
function InfoGLS() {
    $("#divGLSTip").css("display", "block");
    $("#divGLSTip").attr("class", "Info");
    $("#divGLSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数');
    $("#spanGLS").css("border-color", "#5bc0de");
}

