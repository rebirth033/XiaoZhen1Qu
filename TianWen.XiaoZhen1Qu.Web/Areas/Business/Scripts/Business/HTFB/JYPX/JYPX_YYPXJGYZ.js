﻿$(document).ready(function () {

});

//验证所有
function ValidateAll() {
    if (ValidateSelect("YYPXYZ", "YZ", "忘记选择语种啦")
        //& ValidateCheck("XL", "忘记选择小类啦")
        & ValidateCheck("FWFW", "忘记选择服务范围啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}