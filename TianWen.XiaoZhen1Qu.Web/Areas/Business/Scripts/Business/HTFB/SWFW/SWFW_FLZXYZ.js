﻿$(document).ready(function () {
    $(".div_radio").bind("click", function () { ValidateRadio("LY", "忘记选择来源啦"); });
});
//类别
function ValidateLB() {
    if (!ValidateCheck("FLZXLB", "忘记选择类别啦")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateRadio("LY", "忘记选择来源啦")
        & ValidateFWQY()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}