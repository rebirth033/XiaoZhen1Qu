$(document).ready(function () {

});
//验证所有
function ValidateAll() {
    if (ValidateSelect("LXGJ", "GJ", "忘记选择国家啦")
        & ValidateCheck("SQXL", "忘记选择申请学历啦")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}