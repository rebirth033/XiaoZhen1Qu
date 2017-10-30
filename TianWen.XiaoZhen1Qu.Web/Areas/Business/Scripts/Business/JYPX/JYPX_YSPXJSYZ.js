$(document).ready(function () {
    $("#divXB").find(".div_radio").bind("click", function () { ValidateRadio("XB", ""); });
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", ""); });
    $("#divJJJY").find(".div_radio").bind("click", function () { ValidateRadio("JJJY", ""); });
    $("#XM").bind("blur", function () { ValidateInput("XM", "姓名"); });
    $("#XM").bind("focus", function () { InfoInput("XM", "请填写姓名"); });
    $("#JL").bind("blur", function () { ValidateInput("JL", "教龄"); });
    $("#JL").bind("focus", function () { InfoInput("JL", "请填写教龄"); });
    $("#JBSP").bind("blur", function () { ValidateInput("JBSP", "级别水平"); });
    $("#JBSP").bind("focus", function () { InfoInput("JBSP", "请填写级别水平"); });
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
        & ValidateRadio("SF", "忘记选择身份啦")
        & ValidateInput("JL", "教龄")
        & ValidateSelect("YSPXJSBYYX", "BYYX", "忘记选择毕业院校啦")
        & ValidateSelect("YSPXJSJXKM", "JXKM", "忘记选择教学科目啦")
        & ValidateInput("JBSP", "级别水平")
        & ValidateRadio("JJJY", "忘记选择家教经验啦")
        & ValidateQWSX()
        & ValidateFWQY()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}