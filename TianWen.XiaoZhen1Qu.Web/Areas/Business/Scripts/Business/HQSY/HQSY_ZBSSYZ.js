﻿$(document).ready(function () {

});
//验证所有
function ValidateAll() {
    if (ValidateSelect("ZBSSLB", "LB", "忘记选择类别啦")
        & ValidateJG()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateFWQY()
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}