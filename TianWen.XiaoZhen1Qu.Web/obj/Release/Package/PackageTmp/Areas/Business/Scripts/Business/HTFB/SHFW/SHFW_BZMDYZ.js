﻿$(document).ready(function () {

});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择类别啦")) return false;
    if ($("#spanLB").html().indexOf("殡仪馆/殡葬服务") !== -1 || $("#spanLB").html().indexOf("殡葬用品") !== -1) {
        if (!ValidateCheck("XL", "忘记选择小类啦")) return false;
    }
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateCheck("LB", "忘记选择类别啦")
        & ValidateCheck("FWFW", "忘记选择服务范围啦")
        & ValidateRadio("SFSM", "忘记选择是否上门啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}