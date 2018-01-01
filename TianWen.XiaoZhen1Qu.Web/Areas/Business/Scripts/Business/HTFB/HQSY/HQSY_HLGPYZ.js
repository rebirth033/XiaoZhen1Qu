$(document).ready(function () {
    $("#SYSRS").bind("blur", function () { ValidateSpanInput("SYSRS", "摄影师人数"); });
    $("#SYSRS").bind("focus", function () { InfoSpanInput("SYSRS", "忘记填写摄影师人数啦"); });
    $("#GPSJ").bind("blur", function () { ValidateSpanInput("GPSJ", "跟拍时间"); });
    $("#GPSJ").bind("focus", function () { InfoSpanInput("GPSJ", "忘记填写跟拍时间啦"); });
    $("#SLQC").bind("blur", function () { ValidateInput("SLQC", "摄录器材"); });
    $("#SLQC").bind("focus", function () { InfoInput("SLQC", "忘记填写摄录器材啦"); });
    $("#SLCP").bind("blur", function () { ValidateInput("SLCP", "摄录成品"); });
    $("#SLCP").bind("focus", function () { InfoInput("SLCP", "忘记填写摄录成品啦"); });
});
//验证所有
function ValidateAll() {
    if (ValidateSelect("HLGPGPLX", "GPLX", "忘记选择跟拍类型啦")
        & ValidateSpanInput("SYSRS", "摄影师人数")
        & ValidateSpanInput("GPSJ", "跟拍时间")
        & ValidateInput("SLQC", "摄录器材")
        & ValidateInput("SLCP", "摄录成品")
        & ValidateJG()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")

        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}