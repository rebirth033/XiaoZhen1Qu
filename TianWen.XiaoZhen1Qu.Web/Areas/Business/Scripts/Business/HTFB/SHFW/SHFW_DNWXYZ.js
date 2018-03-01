$(document).ready(function () {

});
//验证所有
function ValidateAll() {
    if (ValidateCheck("LB", "忘记选择类别啦")
        & ValidateCheck("FWFW", "忘记选择服务范围啦")
        & ValidateRadio("SFSM", "忘记选择是否上门啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}