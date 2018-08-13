$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
});
//验证网游/虚拟物品类别
function ValidateWYXNWPLB() {
    if (!ValidateSelect("WYXNWPLB", "LB", "请选择类别")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateSelect("YX", "YX", "请选择游戏")
        & ValidateWYXNWPLB()
        & ValidateCheck("PSFS", "忘记选择配送方式啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateJG()
        & ValidateCommon())
        return true;
    else
        return false;
}