$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择供求啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
    $("#CG").bind("blur", ValidateCG);
    $("#CG").bind("focus", InfoCG);
});
//验证所有
function ValidateAll() {
    if (ValidateRadio("GQ", "忘记选择供求啦")
        & ValidateSelect("YCMPLB","LB", "忘记选择类别啦")
        & ValidateCG()
        & ValidateSJ()
        & ValidateJG()
        & ValidateSZQY()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
         & ValidateInput("BT", "标题") & ValidateInput("LXR", "联系人") & ValidateInput("LXDH", "联系电话"))
        return true;
    else
        return false;
}
//验证场馆
function ValidateCG() {
    if ($("#CG").val() === "" || $("#CG").val() === null) {
        $("#divCGTip").css("display", "block");
        $("#divCGTip").attr("class", "Warn");
        $("#divCGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记选择场馆啦');
        $("#CG").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divCGTip").css("display", "none");
        $("#CG").css("border-color", "#cccccc");
        return true;
    }
}
//验证时间
function ValidateSJ() {
    if ($("#SJ").val() === "" || $("#SJ").val() === null) {
        $("#divSJTip").css("display", "block");
        $("#divSJTip").attr("class", "Warn");
        $("#divSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记选择时间啦');
        $("#SJ").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divSJTip").css("display", "none");
        $("#SJ").css("border-color", "#cccccc");
        return true;
    }
}
//提示场馆
function InfoCG() {
    $("#divCGTip").css("display", "block");
    $("#divCGTip").attr("class", "Info");
    $("#divCGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写场馆');
    $("#CG").css("border-color", "#ad5b97");
}