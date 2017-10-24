$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择供求啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证品种
function ValidateCWYPSPLB() {
    if (!ValidateSelect("CWYPSPLB", "LB", "请填写类别")) return false;
    if ($("#spanLB").html() === "狗用品" || $("#spanLB").html() === "猫用品") {
        if (!ValidateSelect("CWYPSPLB", "XL", "请选择小类")) return false;
    }
    return true;
}
//验证所有
function ValidateAll() {
        if (ValidateRadio("GQ", "忘记选择供求啦")
        & ValidateCWYPSPLB()
        & ValidateSelect("XJCD", "XJ", "请填写新旧")
        & ValidateJG()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateCommon())
            return true;
        else
            return false;
}