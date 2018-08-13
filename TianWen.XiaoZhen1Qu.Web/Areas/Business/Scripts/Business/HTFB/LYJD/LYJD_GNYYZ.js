$(document).ready(function () {
    $("#divCYFS").find(".div_radio").bind("click", function () { ValidateRadio("CYFS", ""); });
    $("#JG_CR").bind("blur", function () { ValidateSpanInput("JG_CR", "价格_成人", "JG"); });
    $("#JG_CR").bind("focus", function () { InfoSpanInput("JG_CR", "请填写价格_成人", "JG"); });
    $("#JG_ET").bind("blur", function () { ValidateSpanInput("JG_ET", "价格_儿童", "JG"); });
    $("#JG_ET").bind("focus", function () { InfoSpanInput("JG_ET", "请填写价格_儿童", "JG"); });
    xcap.addListener("focus", function (type, event) { InfoXCAP("XCAP", "请填写行程安排"); });
    xcap.addListener("blur", function (type, event) { ValidateXCAP("XCAP", "忘记填写行程安排啦"); });
    fybh.addListener("focus", function (type, event) { InfoFYBH("FYBH", "请填写费用包含"); });
    fybh.addListener("blur", function (type, event) { ValidateFYBH("FYBH", "忘记填写费用包含啦"); });
    zfxm.addListener("focus", function (type, event) { InfoZFXM("ZFXM", "请填写自费项目"); });
    zfxm.addListener("blur", function (type, event) { ValidateZFXM("ZFXM", "忘记填写自费项目啦"); });
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
	& ValidateXCAP("XCAP", "忘记填写行程安排啦")
	& ValidateFYBH("FYBH", "忘记填写费用包含啦")
	& ValidateZFXM("ZFXM", "忘记填写自费项目啦")
        & ValidateJG()
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证行程安排
function ValidateXCAP(id, message) {
    if (xcap.getContent() === "" || xcap.getContent() === null) {
        $("#div" + id + "Tip").css("display", "block");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />' + message);
        $("#edui97").css("border-color", "#F2272D");
        return false;
    } else {
        $("#div" + id + "Tip").css("display", "none");
        $("#edui97").css("border-color", "#cccccc");
        return true;
    }
}
//验证费用包含
function ValidateFYBH(id, message) {
    if (fybh.getContent() === "" || fybh.getContent() === null) {
        $("#div" + id + "Tip").css("display", "block");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />' + message);
        $("#edui49").css("border-color", "#F2272D");
        return false;
    } else {
        $("#div" + id + "Tip").css("display", "none");
        $("#edui49").css("border-color", "#cccccc");
        return true;
    }
}
//验证自费项目
function ValidateZFXM(id, message) {
    if (zfxm.getContent() === "" || zfxm.getContent() === null) {
        $("#div" + id + "Tip").css("display", "block");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />' + message);
        $("#edui1").css("border-color", "#F2272D");
        return false;
    } else {
        $("#div" + id + "Tip").css("display", "none");
        $("#edui1").css("border-color", "#cccccc");
        return true;
    }
}
//提示行程安排
function InfoXCAP(id, message) {
    $("#div" + id + "Tip").css("display", "block");
    $("#div" + id + "Tip").attr("class", "Info");
    $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />' + message);
    $("#edui97").css("border-color", "#bc6ba6");
}
//提示费用包含
function InfoFYBH(id, message) {
    $("#div" + id + "Tip").css("display", "block");
    $("#div" + id + "Tip").attr("class", "Info");
    $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />' + message);
    $("#edui49").css("border-color", "#bc6ba6");
}
//提示自费项目
function InfoZFXM(id, message) {
    $("#div" + id + "Tip").css("display", "block");
    $("#div" + id + "Tip").attr("class", "Info");
    $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />' + message);
    $("#edui1").css("border-color", "#bc6ba6");
}