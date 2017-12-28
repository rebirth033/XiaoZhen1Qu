$(document).ready(function () {

});
//类别
function ValidateLB() {
    if (!ValidateCheck("OUTLB", "忘记选择类别啦")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateJG()
        & ValidateFWFW()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateCommonWithoutZP())
        return true;
    else
        return false;
}