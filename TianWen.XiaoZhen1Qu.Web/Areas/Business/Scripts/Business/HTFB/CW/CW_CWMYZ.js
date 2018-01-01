$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
    $("#NL").bind("blur", ValidateNL);
    $("#NL").bind("focus", function () { InfoInput("NL", "年龄请填写整数，不能是0", "CWMNL"); });
    $("#ZSZS").bind("blur", ValidateZSZS);
    $("#ZSZS").bind("focus", function () { InfoSpanInput("ZSZS", "在售只数请填写整数，不能是0", "ZSZS"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证年龄
function ValidateCWMNL() {
    if (!ValidateNL()) return false;
    if (!ValidateSelect("CWMNL", "NLDW", "请选择年龄单位")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateSelect("CWMPZ", "PZ", "请选择品种")
        & ValidateJG()
        & ValidateZSZS()
        & ValidateCWMNL()
        & ValidateSelect("CWMXB", "XB", "请选择性别")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证年龄
function ValidateNL() {
    if ($("#NL").val() === "" || $("#NL").val() === null) {
        $("#divCWMNLTip").css("display", "block");
        $("#divCWMNLTip").attr("class", "Warn");
        $("#divCWMNLTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写年龄啦');
        $("#NL").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateDecimal($("#NL").val())) {
            $("#divCWMNLTip").css("display", "none");
            $("#NL").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divCWMNLTip").css("display", "block");
            $("#divCWMNLTip").attr("class", "Warn");
            $("#divCWMNLTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />年龄请填写整数');
            $("#NL").css("border-color", "#F2272D");
            return false;
        }
    }
}
//验证在售只数
function ValidateZSZS() {
    if ($("#ZSZS").val() === "" || $("#ZSZS").val() === null) {
        $("#divZSZSTip").css("display", "block");
        $("#divZSZSTip").attr("class", "Warn");
        $("#divZSZSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写在售只数啦');
        $("#spanZSZS").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateDecimal($("#ZSZS").val())) {
            $("#divCWMNLTip").css("display", "none");
            $("#spanZSZS").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divZSZSTip").css("display", "block");
            $("#divZSZSTip").attr("class", "Warn");
            $("#divZSZSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />在售只数请填写整数');
            $("#spanZSZS").css("border-color", "#F2272D");
            return false;
        }
    }
}