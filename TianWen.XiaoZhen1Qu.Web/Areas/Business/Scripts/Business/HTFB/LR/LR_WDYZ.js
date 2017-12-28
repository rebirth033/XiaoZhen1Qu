$(document).ready(function () {

});
//验证所有
function ValidateAll() {
    if (ValidateCheck("WDLB", "忘记选择类别啦")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateFWFW()
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}