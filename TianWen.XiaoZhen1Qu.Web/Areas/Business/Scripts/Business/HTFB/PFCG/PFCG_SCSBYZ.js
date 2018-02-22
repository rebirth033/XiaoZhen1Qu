$(document).ready(function () {

});
//类别
function ValidateLB() {
    if (!ValidateCheck("OUTLB", "忘记选择商超设备啦")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateCheck("FWFW", "忘记选择服务范围啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}