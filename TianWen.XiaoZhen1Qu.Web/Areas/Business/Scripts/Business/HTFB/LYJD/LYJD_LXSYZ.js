$(document).ready(function () {

});
//验证所有
function ValidateAll() {
    if (ValidateCheck("FWFW", "忘记选择服务范围啦") 
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}