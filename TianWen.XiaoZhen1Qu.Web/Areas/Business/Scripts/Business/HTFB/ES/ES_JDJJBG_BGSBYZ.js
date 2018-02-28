$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
});
//验证办公用品/设备类别
function ValidateBGSBLB() {
    if (!ValidateSelect("BGSBLB", "LB", "请选择类别")) return false;
    //if (!ValidateSelect("BGSBLB", "XL", "请选择小类")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateBGSBLB()
        //& ValidateSelect("XJCD", "XJ", "请选择新旧")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateJG()
        & ValidateCommon())
        return true;
    else
        return false;
}