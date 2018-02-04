$(document).ready(function () {

});
//验证所有
function ValidateAll() {
    if (ValidateSelect("ZWMC", "ZWMC", "请选择留学国家") 
        & ValidateCheck("SQXL", "忘记选择申请学历啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}