$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证品种
function ValidateHNYCLB() {
    if (!ValidateSelect("HNYCLB", "LB", "请填写类别")) return false;
    if (!ValidateSelect("HNYCLB", "XL", "请选择小类")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateHNYCLB()
        & ValidateJG()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateCommon())
        return true;
    else
        return false;
}