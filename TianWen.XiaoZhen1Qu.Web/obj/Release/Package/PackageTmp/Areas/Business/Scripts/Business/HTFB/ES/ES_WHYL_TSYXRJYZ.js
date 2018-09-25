$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
});

//验证图书/音像/软件类别
function ValidateTSYXRJLB() {
    if (!ValidateSelect("TSYXRJLB", "LB", "请选择类别")) return false;
    //if (!ValidateSelect("TSYXRJLB", "XL", "请选择小类")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateTSYXRJLB()
        & ValidateSelect("XJCD", "XJ", "请选择新旧")
        & ValidateCheck("PSFS", "忘记选择配送方式啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateJG()
        & ValidateCommon())
        return true;
    else
        return false;
}