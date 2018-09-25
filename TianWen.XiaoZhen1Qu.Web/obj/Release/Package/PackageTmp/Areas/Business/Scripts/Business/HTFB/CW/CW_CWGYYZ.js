$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择供求啦"); });
});
//验证所有
function ValidateAll() {
    if (ValidateRadio("GQ", "忘记选择供求啦")
        & ValidateXXDZ()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateCommon())
        return true;
    else
        return false;
}