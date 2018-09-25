$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
    $("#divQCQK").find(".div_radio").bind("click", function () { ValidateRadio("QCQK", "忘记选择驱虫情况啦"); });
    $("#NL").bind("blur", ValidateNL);
    $("#NL").bind("focus", function () { InfoInput("NL", "年龄请填写整数，不能是0", "CWGNL"); });
    $("#ZSZS").bind("blur", ValidateZSZS);
    $("#ZSZS").bind("focus", function () { InfoSpanInput("ZSZS", "在售只数请填写整数，不能是0", "ZSZS"); });
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
    //if (!ValidateSelect("CWGYMQK", "YMZL", "请选择疫苗种类")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateSelect("CWGPZ", "PZ", "请选择品种")
        & ValidateJG()
        & ValidateZSZS()
        & ValidateCWGNL()
        & ValidateSelect("CWGXB", "XB", "请选择性别")
        & ValidateCWGYMQK()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateRadio("QCQK", "忘记选择驱虫情况啦")
        & ValidateXXDZ()
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
        $("#NL").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateDecimal($("#NL").val())) {
            $("#divCWGNLTip").css("display", "none");
            $("#NL").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divCWGNLTip").css("display", "block");
            $("#divCWGNLTip").attr("class", "Warn");
            $("#divCWGNLTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />年龄请填写整数');
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
            $("#divZSZSTip").css("display", "none");
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