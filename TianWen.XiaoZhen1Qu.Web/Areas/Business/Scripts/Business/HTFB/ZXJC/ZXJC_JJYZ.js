﻿$(document).ready(function () {

});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择类别啦")) return false;
    if ($("#spanLB").html() !== "床" && $("#spanLB").html() !== "床垫" && $("#spanLB").html() !== "沙发") {
        if (!ValidateSelect("OUTLB", "XL", "忘记选择小类啦")) return false;
    }
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateFWQY()
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}