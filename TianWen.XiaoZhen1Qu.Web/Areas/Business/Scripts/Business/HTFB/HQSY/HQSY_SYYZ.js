$(document).ready(function () {
    $("#divSYXB").find(".div_radio").bind("click", function () { ValidateRadio("SYXB", ""); });
    $("#divZCFG").find(".div_radio").bind("click", function () { ValidateRadio("ZCFG", ""); });
    $("#divCYSJ").find(".div_radio").bind("click", function () { ValidateRadio("CYSJ", ""); });
});
//验证所有
function ValidateAll() {
    if (ValidateRadio("SYXB", "忘记选择司仪性别 啦")
        & ValidateRadio("ZCFG", "忘记选择主持风格啦")
        & ValidateRadio("CYSJ", "忘记选择从业时间啦")
        & ValidateJG()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateFWFW()
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}