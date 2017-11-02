$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择供求啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});

//验证图书/音像/软件类别
function ValidateTSYXRJLB() {
    if (!ValidateSelect("TSYXRJLB", "LB", "请选择类别")) return false;
    if (!ValidateSelect("TSYXRJLB", "XL", "请选择小类")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("GQ", "忘记选择供求啦")
        & ValidateTSYXRJLB()
        & ValidateSelect("XJCD", "XJ", "请选择新旧")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateSZQY()
        & ValidateJG()
        & ValidateCommon())
        return true;
    else
        return false;
}