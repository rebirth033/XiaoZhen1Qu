$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择供求啦"); });
});
//验证所有
function ValidateAll() {
    if (ValidateRadio("GQ", "忘记选择供求啦")
        & ValidateSelect("LB", "LB", "忘记选择类别啦")
        //& ValidateYXQZ()
        & ValidateJG()
        & ValidateXXDZ()
        & ValidateCheck("PSFS", "忘记选择配送方式啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateCommonWithoutZP())
        return true;
    else
        return false;
}
//有效期限
function ValidateYXQZ() {
    if ($("#YXQZ").val() === "" || $("#YXQZ").val() === null) {
        $("#divYXQZTip").css("display", "block");
        $("#divYXQZTip").attr("class", "Warn");
        $("#divYXQZTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记选择有效期至啦');
        $("#YXQZ").css("border-color", "#F2272D");
        return false;
    } else {
        $("#divYXQZTip").css("display", "none");
        $("#YXQZ").css("border-color", "#cccccc");
        return true;
    }
}