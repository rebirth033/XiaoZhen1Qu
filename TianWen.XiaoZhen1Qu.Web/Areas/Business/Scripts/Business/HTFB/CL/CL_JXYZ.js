$(document).ready(function () {

});

//验证所有
function ValidateAll() {
    if (ValidateInput("JXMC", "驾校名称")
        & ValidateCheck("JZ", "忘记选择驾照啦")
        & ValidateCheck("BB", "忘记选择班别啦")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}