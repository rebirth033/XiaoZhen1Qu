$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择供求啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证所有
function ValidateAll() {
    if (ValidateRadio("GQ", "忘记选择供求啦")
        & ValidateCheck("CX", "忘记选择车型啦")
        & ValidateCheck("PP", "忘记选择品牌啦")
        & ValidateSelect("XJCD", "XJ", "请选择新旧")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateJG()
        & ValidateCommon())
        return true;
    else
        return false;
}