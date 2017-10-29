$(document).ready(function () {
    $("#divFG").find(".div_radio").bind("click", function () { ValidateRadio("FG", ""); });
    $("#divKS").find(".div_radio").bind("click", function () { ValidateRadio("KS", ""); });
    $("#DGZQ").bind("blur", function () { ValidateSpanInput("DGZQ", "摄影师人数"); });
    $("#DGZQ").bind("focus", function () { InfoSpanInput("DGZQ", "忘记填写摄影师人数啦"); });
});
//验证所有
function ValidateAll() {
    if (ValidateSelect("HSLFYS", "YS", "忘记选择颜色啦")
        & ValidateRadio("FG", "忘记选择风格啦")
        & ValidateSelect("HSLFLX", "LX", "忘记选择类型啦")
        & ValidateSpanInput("DGZQ", "订购周期")
        & ValidateSelect("HSLFCZ", "CZ", "忘记选择材质啦")
        & ValidateRadio("KS", "忘记选择款式啦")
        & ValidateJG()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateFWQY()
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}