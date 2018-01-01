$(document).ready(function () {
    $("#divHZLX").find(".div_radio").bind("click", function () { ValidateRadio("HZLX", ""); });
    $("#divHZXL").find(".div_radio").bind("click", function () { ValidateRadio("HZXL", ""); });
    $("#divFWXS").find(".div_radio").bind("click", function () { ValidateRadio("FWXS", ""); });
});
//验证所有
function ValidateAll() {
    if (ValidateRadio("HZLX", "忘记选择化妆类型啦")
        & ValidateRadio("HZXL", "忘记选择化妆小类啦")
        & ValidateRadio("FWXS", "忘记选择服务形式啦")
        & ValidateJG()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")

        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}