$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证网游/虚拟物品类别
function ValidateWYXNWPLB() {
    if (!ValidateSelect("WYXNWPLB", "LB", "请选择类别")) return false;
    if (!ValidateSelect("WYXNWPLB", "XL", "请选择小类")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateWYXNWPLB()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateSZQY()
        & ValidateJG()
        & ValidateCommon())
        return true;
    else
        return false;
}