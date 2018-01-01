$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
    $(".div_clys").bind("click", function () { ValidateCLYS(); });
    $("#XSLC").bind("blur", ValidateXSLC);
    $("#XSLC").bind("focus", function () { InfoSpanInput("XSLC", "请填写行驶里程"); });
    $("#KCDZ").bind("blur", ValidateKCDZ);
    $("#KCDZ").bind("focus", function () { InfoInput("KCDZ", "请填写看车地址"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", function () { InfoSpanInput("JG", "价格请填写数字，默认为面议"); });
});
//验证客车品牌
function ValidateKCPP() {
    if (!ValidateSelect("KCPP", "PP", "请选择品牌")) return false;
    if (!ValidateSelect("KCPP", "CX", "请选择车型")) return false;
    return true;
}
//验证客车首次上牌时间
function ValidateSCSPSJ() {
    if (!ValidateSelect("SCSPSJ", "SPNF", "请选择上牌年份")) return false;
    if (!ValidateSelect("SCSPSJ", "SPYF", "请选择上牌月份")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateSelect("KCPP", "PP", "忘记选择品牌啦")
        & ValidateCLYS()
        & ValidateSCSPSJ()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXSLC()
        & ValidateKCDZ()
        & ValidateJG()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证行使里程
function ValidateXSLC() {
    if ($("#XSLC").val() === "" || $("#XSLC").val() === null) {
        $("#divXSLCTip").css("display", "block");
        $("#divXSLCTip").attr("class", "Warn");
        $("#divXSLCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写行驶里程啦');
        $("#spanXSLC").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateDecimal($("#XSLC").val())) {
            $("#divXSLCTip").css("display", "none");
            $("#spanXSLC").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divXSLCTip").css("display", "block");
            $("#divXSLCTip").attr("class", "Warn");
            $("#divXSLCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />行驶里程请填写数字');
            $("#spanXSLC").css("border-color", "#F2272D");
            return false;
        }
    }
}
//验证看车地址
function ValidateKCDZ() {
    if ($("#KCDZ").val() === "" || $("#KCDZ").val() === null) {
        $("#divKCDZTip").css("display", "block");
        $("#divKCDZTip").attr("class", "Warn");
        $("#divKCDZTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写看车地址啦');
        $("#KCDZ").css("border-color", "#F2272D");
        return false;
    } else {
        $("#divKCDZTip").css("display", "none");
        $("#KCDZ").css("border-color", "#cccccc");
        return true;
    }
}
//验证车辆颜色
function ValidateCLYS() {
    var value = "";
    $(".div_clys").each(function () {
        if ($(this).css("background-color") === "rgb(188, 107, 166)")
            value = $(this).find(".span_clys_right")[0].innerHTML;
    });
    if (value === "") {
        $("#divCLYSTip").css("display", "block");
        $("#divCLYSTip").attr("class", "Warn");
        $("#divCLYSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记选择车辆颜色啦');
        return false;
    } else {
        $("#divCLYSTip").css("display", "none");
        return true;
    }
}
