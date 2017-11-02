$(document).ready(function () {

});
//类别
function ValidateLB() {
    if (!ValidateCheck("JXSBWXLB", "忘记选择类别啦")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateFWQY()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}