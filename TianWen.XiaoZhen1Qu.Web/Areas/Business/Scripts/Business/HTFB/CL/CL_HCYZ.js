$(document).ready(function () {
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
    $("#EDZZ").bind("blur", ValidateEDZZ);
    $("#EDZZ").bind("focus", InfoEDZZ);
    $("#XSLC").bind("blur", ValidateXSLC);
    $("#XSLC").bind("focus", InfoXSLC);
});
//验证出厂年份
function ValidateHCCCNF() {
    if (!ValidateSelect("HCCCNF", "CCNF", "请选择出厂年份")) return false;
    if (!ValidateSelect("HCCCNF", "CCYF", "请选择出厂月份")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateSelect("HCLB", "LB", "忘记选择车型啦")
           & ValidateSelect("HCPP", "PP", "忘记选择品牌啦")
           & ValidateHCCCNF()
           & ValidateEDZZ()
           & ValidateXSLC()
           & ValidateBCMS("BCMS", "忘记填写补充描述啦")
           & ValidateSZQY()
           & ValidateJG()
           & ValidateCommon())
        return true;
    else
        return false;
}
//验证额定载重
function ValidateEDZZ() {
    if ($("#EDZZ").val() === "" || $("#EDZZ").val() === null) {
        $("#divEDZZTip").css("display", "block");
        $("#divEDZZTip").attr("class", "Warn");
        $("#divEDZZTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写额定载重啦');
        $("#spanEDZZ").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateDecimal($("#EDZZ").val())) {
            $("#divEDZZTip").css("display", "none");
            $("#spanEDZZ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divEDZZTip").css("display", "block");
            $("#divEDZZTip").attr("class", "Warn");
            $("#divEDZZTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />额定载重请填写数字,可保留一到四位小数');
            $("#spanEDZZ").css("border-color", "#fd634f");
            return false;
        }
    }
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
//提示额定载重
function InfoEDZZ() {
    $("#divEDZZTip").css("display", "block");
    $("#divEDZZTip").attr("class", "Info");
    $("#divEDZZTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写数字');
    $("#spanEDZZ").css("border-color", "#5bc0de");
}
//提示行驶里程
function InfoXSLC() {
    $("#divXSLCTip").css("display", "block");
    $("#divXSLCTip").attr("class", "Info");
    $("#divXSLCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写数字');
    $("#spanXSLC").css("border-color", "#5bc0de");
}

