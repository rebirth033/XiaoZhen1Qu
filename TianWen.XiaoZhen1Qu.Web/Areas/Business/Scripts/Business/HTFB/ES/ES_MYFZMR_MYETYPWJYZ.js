﻿$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
});
//验证母婴/儿童用品/玩具类别
function ValidateMYETYPWJLB() {
    if (!ValidateSelect("MYETYPWJLB", "LB", "请选择类别")) return false;
    //if (!ValidateSelect("MYETYPWJLB", "XL", "请选择小类")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateMYETYPWJLB()
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