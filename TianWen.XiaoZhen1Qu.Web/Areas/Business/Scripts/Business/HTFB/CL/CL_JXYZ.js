$(document).ready(function () {
    $("#divOUTLB").find(".div_radio").bind("click", function () { ValidateRadio("OUTLB", "忘记选择类别啦"); });
});
//类别
function ValidateLB() {
    if (!ValidateRadio("OUTLB", "忘记选择类别啦")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateCheck("JZ", "忘记选择驾照啦")
        & ValidateCheck("BB", "忘记选择班别啦")
        & ValidateFWQY()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}