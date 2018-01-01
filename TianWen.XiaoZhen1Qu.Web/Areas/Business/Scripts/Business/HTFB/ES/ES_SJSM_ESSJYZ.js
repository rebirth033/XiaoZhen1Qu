$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
    $("#divSYQK").find(".div_radio").bind("click", function () { ValidateRadio("SYQK", "忘记选择使用情况啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证手机品牌与型号
function ValidateSJPPYXH() {
    if (!ValidateSelect("SJPPYXH", "SJPP", "请选择手机品牌")) return false;
    if (!ValidateSelect("SJPPYXH", "SJXH", "请选择手机型号")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateRadio("SYQK", "忘记选择使用情况啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateSJPPYXH()
        & ValidateSZQY()
        & ValidateJG()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证售价
function ValidateJG() {
    if ($("#JG").val() === "" || $("#JG").val() === null) {
        $("#divJGTip").css("display", "block");
        $("#divJGTip").attr("class", "Warn");
        $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写价格啦');
        $("#spanJG").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber($("#JG").val())) {
            $("#divJGTip").css("display", "none");
            $("#spanJG").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divJGTip").css("display", "block");
            $("#divJGTip").attr("class", "Warn");
            $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />价格请填写整数，默认为面议');
            $("#spanJG").css("border-color", "#F2272D");
            return false;
        }
    }
}

