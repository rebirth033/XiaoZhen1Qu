﻿$(document).ready(function () {

});
//类别
function ValidateLB() {
    if (!ValidateCheck("TGFW", "忘记选择类别啦")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateCheck("FWFW", "忘记选择服务范围啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}