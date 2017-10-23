$(document).ready(function () {
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
    $("#EDZZ").bind("blur", ValidateEDZZ);
    $("#EDZZ").bind("focus", InfoEDZZ);
    $("#XSLC").bind("blur", ValidateXSLC);
    $("#XSLC").bind("focus", InfoXSLC);
});
//验证所有
function ValidateAll() {
    if (ValidateEDZZ() & ValidateXSLC() & ValidateJG() & ValidateBT() & ValidateZP() & ValidateLXR() & ValidateLXDH())
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
            $("#divEDZZTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />额定载重请填写数字');
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
//验证售价
function ValidateJG() {
    if ($("#JG").val() === "" || $("#JG").val() === null) {
        $("#divJGTip").css("display", "block");
        $("#divJGTip").attr("class", "Warn");
        $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写价格啦');
        $("#spanJG").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateDecimal($("#JG").val())) {
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
//提示额定载重
function InfoEDZZ() {
    $("#divEDZZTip").css("display", "inline-block");
    $("#divEDZZTip").attr("class", "Info");
    $("#divEDZZTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写数字');
}
//提示行驶里程
function InfoXSLC() {
    $("#divXSLCTip").css("display", "inline-block");
    $("#divXSLCTip").attr("class", "Info");
    $("#divXSLCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写数字');
}
//提示价格
function InfoJG() {
    $("#divJGTip").css("display", "block");
    $("#divJGTip").attr("class", "Info");
    $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，面议则填0');
}
