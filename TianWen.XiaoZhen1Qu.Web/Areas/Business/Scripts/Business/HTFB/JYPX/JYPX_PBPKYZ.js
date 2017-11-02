$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
    $("#divCD").find(".div_radio").bind("click", function () { ValidateRadio("CD", "忘记选择场地啦"); });
    $("#divPBRS").find(".div_radio").bind("click", function () { ValidateRadio("PBRS", "忘记选择拼班人数啦"); });
    $("#JGFW_Q").bind("blur", function () { ValidateSpanInput("JGFW_Q", "价格范围_起", "JGFW") });
    $("#JGFW_Q").bind("focus", function () { InfoSpanInput("JGFW_Q", "价格范围_起", "JGFW") });
    $("#JGFW_Z").bind("blur", function () { ValidateSpanInput("JGFW_Z", "价格范围_止", "JGFW") });
    $("#JGFW_Z").bind("focus", function () { InfoSpanInput("JGFW_Z", "价格范围_止", "JGFW") });
});
//类别
function ValidateJGFW() {
    if (!ValidateSpanInput("JGFW_Q", "价格范围_起", "JGFW")) return false;
    if (!ValidateSpanInput("JGFW_Z", "价格范围_止", "JGFW")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateRadio("CD", "忘记选择场地啦")
        & ValidateJGFW()
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