﻿$(document).ready(function () {

});
//验证所有
function ValidateAll() {
    if (ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateCheck("FWFW", "忘记选择服务范围啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}