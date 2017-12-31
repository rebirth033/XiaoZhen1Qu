$(document).ready(function () {

});
//验证所有
function ValidateAll() {
    if (ValidateJG()
        & ValidateCheck("FWFW", "忘记选择服务范围啦")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateCommon())
        return true;
    else
        return false;
}