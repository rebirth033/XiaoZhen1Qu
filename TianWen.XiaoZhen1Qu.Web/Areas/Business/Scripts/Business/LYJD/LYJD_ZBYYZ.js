$(document).ready(function () {
    $("#divCYFS").find(".div_radio").bind("click", function () { ValidateRadio("CYFS", "忘记选择出游方式啦"); });
    $("#divXCTS").find(".div_radio").bind("click", function () { ValidateRadio("XCTS", "忘记选择行程天数啦"); });
    $("#MSJ").bind("blur", function () { ValidateSpanInput("MSJ", "门市价"); });
    $("#MSJ").bind("focus", function () { InfoSpanInput("MSJ", "请填写门市价"); });
    $("#YHJ_CR").bind("blur", function () { ValidateSpanInput("YHJ_CR", "优惠价_成人", "YHJ"); });
    $("#YHJ_CR").bind("focus", function () { InfoSpanInput("YHJ_CR", "请填写优惠价_成人", "YHJ"); });
    $("#YHJ_ET").bind("blur", function () { ValidateSpanInput("YHJ_ET", "优惠价_儿童", "YHJ"); });
    $("#YHJ_ET").bind("focus", function () { InfoSpanInput("YHJ_ET", "请填写优惠价_儿童", "YHJ"); });
});
//验证优惠价
function ValidateYHJ() {
    if (!ValidateSpanInput("YHJ_CR", "优惠价_成人", "YHJ")) return false;
    if (!ValidateSpanInput("YHJ_ET", "优惠价_儿童", "YHJ")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("CYFS", "忘记选择出游方式啦")
        & ValidateCheck("YWXM", "忘记选择游玩项目啦")
        & ValidateCheck("SHRQ", "忘记选择适合人群啦")
        & ValidateRadio("XCTS", "忘记选择行程天数啦")
        & ValidateSpanInput("MSJ", "门市价")
        & ValidateYHJ()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}