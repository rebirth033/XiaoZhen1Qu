﻿$(document).ready(function () {
    $(".div_radio").bind("click", function () { ValidateRadio("SFSM", "忘记选择是否上门啦"); });
});
//类别
function ValidateLB() {
    if (!ValidateCheck("CWKJPGLB", "忘记选择类别啦")) return false;
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