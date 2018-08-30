$(document).ready(function () {

});
//验证所有
function ValidateAll() {
    if (ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}