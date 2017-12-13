$(document).ready(function () {
    $(".div_clys").bind("click", function () { ValidateCLYS(); });
    $("#XSLC").bind("blur", ValidateXSLC);
    $("#XSLC").bind("focus", InfoXSLC);
    $("#KCDZ").bind("blur", ValidateKCDZ);
    $("#KCDZ").bind("focus", InfoKCDZ);
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证轿车
function ValidateJCPP() {
    if (!ValidateSelect("JCPP", "PP", "请选择品牌")) return false;
    if (!ValidateSelect("JCPP", "CX", "请选择车型")) return false;
    return true;
}
//验证轿车
function ValidateSCSPSJ() {
    if (!ValidateSelect("SCSPSJ", "SPNF", "请选择上牌年份")) return false;
    if (!ValidateSelect("SCSPSJ", "SPYF", "请选择上牌月份")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateJCPP()
        & ValidateCLYS()
        & ValidateSCSPSJ()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXSLC()
        & ValidateKCDZ()
        & ValidateJG()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证行驶里程
function ValidateXSLC() {
    if ($("#XSLC").val() === "" || $("#XSLC").val() === null) {
        $("#divXSLCTip").css("display", "block");
        $("#divXSLCTip").attr("class", "Warn");
        $("#divXSLCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写行驶里程啦');
        $("#spanXSLC").css("border-color", "#fd634f");
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
            $("#spanXSLC").css("border-color", "#fd634f");
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
        $("#KCDZ").css("border-color", "#fd634f");
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
        if ($(this).css("background-color") === "rgb(135, 181, 59)")
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
//行驶里程
function InfoXSLC() {
    $("#divXSLCTip").css("display", "block");
    $("#divXSLCTip").attr("class", "Info");
    $("#divXSLCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写行驶里程');
    $("#spanXSLC").css("border-color", "#ad5b97");
}
//看车地址
function InfoKCDZ() {
    $("#divKCDZTip").css("display", "block");
    $("#divKCDZTip").attr("class", "Info");
    $("#divKCDZTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写看车地址');
    $("#KCDZ").css("border-color", "#ad5b97");
}

