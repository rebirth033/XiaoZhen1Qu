﻿$(document).ready(function () {
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});

//验证所有
function ValidateAll() {
    if (ValidateCheck("LB", "忘记选择类别啦")
        & ValidateCheck("FWFW", "忘记选择服务范围啦")
        & ValidateJG()
        & ValidateXXDZ()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateCommon())
        return true;
    else
        return false;
}