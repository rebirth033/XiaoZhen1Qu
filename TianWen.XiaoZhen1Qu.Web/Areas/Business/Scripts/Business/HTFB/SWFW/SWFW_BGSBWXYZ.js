﻿$(document).ready(function () {
    $(".div_radio").bind("click", function () { ValidateRadio("SFSM", "忘记选择是否上门啦"); });
});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择类别啦")) return false;
    if ($("#spanLB").html() === "打印机" || $("#spanLB").html() === "复印机" || $("#spanLB").html() === "传真机" || $("#spanLB").html() === "一体机") {
        if (!ValidateSelect("OUTLB", "XL", "忘记选择小类啦")) return false;
    }
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateRadio("SFSM", "忘记选择是否上门啦")
        & ValidateFWQY()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}