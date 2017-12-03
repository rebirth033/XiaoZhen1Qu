$(document).ready(function () {

});
//验证所有
function ValidateAll() {
    if (ValidateSelect("YMGJ", "GJ", "忘记选择国家啦")
        & ValidateCheck("YMLB", "忘记选择类别啦")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}