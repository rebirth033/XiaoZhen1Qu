$(document).ready(function () {

});
//类别
function ValidateLB() {
    if (!ValidateCheck("LB", "忘记选择类别啦")) return false;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}