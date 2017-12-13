$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择供求啦"); });
    $("#divQCQK").find(".div_radio").bind("click", function () { ValidateRadio("QCQK", "忘记选择驱虫情况啦"); });
    $("#NL").bind("blur", ValidateNL);
    $("#NL").bind("focus", InfoNL);
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证年龄
function ValidateCWGNL() {
    if (!ValidateNL()) return false;
    if (!ValidateSelect("CWGNL", "NLDW", "请选择年龄单位")) return false;
    return true;
}
//验证疫苗情况
function ValidateCWGYMQK() {
    if (!ValidateSelect("CWGYMQK", "YMQK", "请填写疫苗针数")) return false;
    if (!ValidateSelect("CWGYMQK", "YMZL", "请选择疫苗种类")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("GQ", "忘记选择供求啦")
        & ValidateSelect("CWGPZ", "PZ", "请选择品种")
        & ValidateJG()
        & ValidateCWGNL()
        & ValidateSelect("CWGXB", "XB", "请选择性别")
        & ValidateCWGYMQK()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateRadio("QCQK", "忘记选择驱虫情况啦")
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证年龄
function ValidateNL() {
    if ($("#NL").val() === "" || $("#NL").val() === null) {
        $("#divCWGNLTip").css("display", "block");
        $("#divCWGNLTip").attr("class", "Warn");
        $("#divCWGNLTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写年龄啦');
        $("#spanNL").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateDecimal($("#NL").val())) {
            $("#divCWGNLTip").css("display", "none");
            $("#spanNL").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divCWGNLTip").css("display", "block");
            $("#divCWGNLTip").attr("class", "Warn");
            $("#divCWGNLTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />年龄请填写整数');
            $("#spanNL").css("border-color", "#F2272D");
            return false;
        }
    }
}
//提示年龄
function InfoNL() {
    $("#divCWGNLTip").css("display", "block");
    $("#divCWGNLTip").attr("class", "Info");
    $("#divCWGNLTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数');
    $("#spanNL").css("border-color", "#ad5b97");
}

