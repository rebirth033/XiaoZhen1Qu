$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
});
//验证手机品牌与型号
function ValidatePPYXH() {
    if (!ValidateSelect("PPYXH", "PP", "请选择手机品牌")) return false;
    if (!ValidateSelect("PPYXH", "XH", "请选择手机型号")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        //& ValidateSelect("XJCD", "XJ", "忘记选择新旧啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        //& ValidatePPYXH()
        & ValidateXXDZ()
        & ValidateJG()
        & ValidateCommon())
        return true;
    else
        return false;
}