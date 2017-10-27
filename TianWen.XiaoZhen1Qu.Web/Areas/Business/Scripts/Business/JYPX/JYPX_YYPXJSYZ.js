$(document).ready(function () {
    $("#divXB").find(".div_radio").bind("click", function () { ValidateRadio("XB", ""); });
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", ""); });
    $("#divJJJY").find(".div_radio").bind("click", function () { ValidateRadio("JJJY", ""); });
    $("#XM").bind("blur", function () { ValidateInput("XM", "姓名"); });
    $("#XM").bind("focus", function () { InfoSpanInput("XM", "请填写姓名"); });
    $("#QWSX_Q").bind("blur", function () { ValidateInput("QWSX_Q", "期望时薪_起", "QWSX"); });
    $("#QWSX_Q").bind("focus", function () { InfoSpanInput("QWSX_Q", "期望时薪_起", "QWSX"); });
    $("#QWSX_Z").bind("blur", function () { ValidateInput("QWSX_Z", "期望时薪_止", "QWSX"); });
    $("#QWSX_Z").bind("focus", function () { InfoSpanInput("QWSX_Z", "期望时薪_止", "QWSX"); });
});
//类别
function ValidateQWSX() {
    if (!ValidateInput("QWSX_Q", "期望时薪_起", "QWSX")) return false;
    if (!ValidateInput("QWSX_Z", "期望时薪_止", "QWSX")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateInput("XM", "姓名")
        & ValidateRadio("XB", "忘记选择性别啦")
        & ValidateRadio("SF", "忘记选择身份啦")
        & ValidateRadio("JJJY", "忘记选择家教经验啦")
        & ValidateCheck("FDJD", "忘记选择辅导阶段啦")
        & ValidateCheck("FDKM", "忘记选择辅导科目啦")
        & ValidateQWSX()
        & ValidateFWQY()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}