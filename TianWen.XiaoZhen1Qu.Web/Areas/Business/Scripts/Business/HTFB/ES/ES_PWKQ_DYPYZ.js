$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择供求啦"); });
    $("#divKQLB").find(".div_radio").bind("click", function () { ValidateRadio("KQLB", "忘记选择类别啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
    $("#YXQZ").bind("blur", ValidateYXQZ);
    $("#YXQZ").bind("focus", InfoYXQZ);
});
//验证所有
function ValidateAll() {
    if (ValidateRadio("GQ", "忘记选择供求啦")
        & ValidateRadio("KQLB", "忘记选择类别啦")
        & ValidateYXQZ()
        & ValidateJG()
        & ValidateSZQY()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateInput("BT", "标题") & ValidateInput("LXR", "联系人") & ValidateInput("LXDH", "联系电话"))
        return true;
    else
        return false;
}
//验证有效期至
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

function InfoYXQZ() {
    $("#divYXQZTip").css("display", "none");
    $("#YXQZ").css("border-color", "#bc6ba6");
}