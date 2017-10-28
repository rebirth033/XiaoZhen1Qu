$(document).ready(function () {

});
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateRadio("CD", "忘记选择场地啦")
        & ValidateCheck("FDJD", "忘记选择辅导阶段啦")
        & ValidateCheck("FDKM", "忘记选择辅导科目啦")
        & ValidateRadio("PBRS", "忘记选择拼班人数啦")
        & ValidateFWQY()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}