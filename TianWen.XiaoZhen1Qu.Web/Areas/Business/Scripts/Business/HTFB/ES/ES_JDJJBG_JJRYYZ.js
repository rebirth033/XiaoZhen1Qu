﻿$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
});
//验证家具/日用品类别
function ValidateJJRYLB() {
    if (!ValidateSelect("JJRYLB", "LB", "请选择类别")) return false;
    //if (!ValidateSelect("JJRYLB", "XL", "请选择小类")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateJJRYLB()
        //& ValidateSelect("XJCD", "XJ", "请选择新旧")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateJG()
        & ValidateCommon())
        return true;
    else
        return false;
}