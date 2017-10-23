$(document).ready(function () {
    $("#XSLC").bind("blur", ValidateXSLC);
    $("#XSLC").bind("focus", InfoXSLC);
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证所有
function ValidateAll() {
    if (ValidateJG() & ValidateBT() & ValidateZP() & ValidateLXR() & ValidateLXDH())
        return true;
    else
        return false;
}
//验证售价
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

//行驶里程
function InfoXSLC() {
    $("#divXSLCTip").css("display", "block");
    $("#divXSLCTip").attr("class", "Info");
    $("#divXSLCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写行驶里程');
}

