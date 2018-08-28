$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证品种
function ValidateCWYPSPLB() {
    if (!ValidateCheck("LB", "请填写类别")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateCWYPSPLB()
        & ValidateSelect("XJCD", "XJ", "请填写新旧")
        & ValidateJG()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
            return true;
        else
            return false;
}