$(document).ready(function () {
    $("#XF").bind("blur", ValidateXF);
    $("#XF").bind("focus", InfoXF);
});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择类别啦")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateCheck("XL", "忘记选择小类啦")
        & ValidateXF()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证学费
function ValidateXF() {
    if ($("#XF").val() === "" || $("#XF").val() === null) {
        $("#divXFTip").css("display", "block");
        $("#divXFTip").attr("class", "Warn");
        $("#divXFTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写学费啦');
        $("#spanXF").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#XF").val())) {
            $("#divXFTip").css("display", "none");
            $("#spanXF").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divXFTip").css("display", "block");
            $("#divXFTip").attr("class", "Warn");
            $("#divXFTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />学费请填写整数，默认为面议');
            $("#spanXF").css("border-color", "#fd634f");
            return false;
        }
    }
}
//提示学费
function InfoXF() {
    $("#divXFTip").css("display", "block");
    $("#divXFTip").attr("class", "Info");
    $("#divXFTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanXF").css("border-color", "#ad5b97");
}