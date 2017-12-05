$(document).ready(function () {
    $("#divGRTT").find(".div_radio").bind("click", function () { ValidateRadio("GRTT", "忘记选择个人团体啦"); });
});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择类别啦")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateRadio("GRTT", "忘记选择个人团体啦")
        & ValidateSelect("DBQZQZGJ", "GJ", "忘记选择国家啦")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}