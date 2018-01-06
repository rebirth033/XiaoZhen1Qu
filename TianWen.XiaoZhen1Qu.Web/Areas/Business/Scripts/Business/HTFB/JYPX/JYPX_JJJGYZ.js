$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
});

//验证所有
function ValidateAll() {
    if (ValidateCheck("FDJD", "忘记选择辅导阶段啦")
        & ValidateCheck("FDKM", "忘记选择辅导科目啦")
        & ValidateCheck("SKXS", "忘记选择家教机构授课形式啦")
        & ValidateCheck("FWFW", "忘记选择服务范围啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}