$(document).ready(function () {
    $("#divCYFS").find(".div_radio").bind("click", function () { ValidateRadio("CYFS", ""); });
    $("#JG_CR").bind("blur", function () { ValidateSpanInput("JG_CR", "价格_成人", "JG"); });
    $("#JG_CR").bind("focus", function () { InfoSpanInput("JG_CR", "请填写价格_成人", "JG"); });
    $("#JG_ET").bind("blur", function () { ValidateSpanInput("JG_ET", "价格_儿童", "JG"); });
    $("#JG_ET").bind("focus", function () { InfoSpanInput("JG_ET", "请填写价格_儿童", "JG"); });
});
//验证往返交通
function ValidateWFJT() {
    if (!ValidateSelect("WFJT", "WFJT_Q", "请选择往返交通_去")) return false;
    if (!ValidateSelect("WFJT", "WFJT_H", "请选择往返交通_回")) return false;
    return true;
}
//验证行程天数
function ValidateXCTS() {
    if (!ValidateSelect("XCTS", "XCTS_R", "请选择行程天数_日")) return false;
    if (!ValidateSelect("XCTS", "XCTS_W", "请选择行程天数_晚")) return false;
    return true;
}
//验证价格
function ValidateJG() {
    if (!ValidateSpanInput("JG_CR", "价格_成人", "JG")) return false;
    if (!ValidateSpanInput("JG_ET", "价格_儿童", "JG")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("CYFS", "忘记选择出游方式啦")
        & ValidateWFJT()
        & ValidateXCTS()
        & ValidateJG()
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证费用包含
function ValidateFYBH(id, message) {
    if (fybh.getContent() === "" || fybh.getContent() === null) {
        $("#div" + id + "Tip").css("display", "block");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />' + message);
        return false;
    } else {
        $("#div" + id + "Tip").css("display", "none");
        return true;
    }
}
//验证自费项目
function ValidateZFXM(id, message) {
    if (zfxm.getContent() === "" || zfxm.getContent() === null) {
        $("#div" + id + "Tip").css("display", "block");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />' + message);
        return false;
    } else {
        $("#div" + id + "Tip").css("display", "none");
        return true;
    }
}