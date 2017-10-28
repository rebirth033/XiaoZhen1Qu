$(document).ready(function () {
    $("#divFTRQ").find(".div_radio").bind("click", function () { ValidateRadio("FTRQ", ""); });
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
//验证优惠价
function ValidateYHJ() {
    if (!ValidateSpanInput("YHJ_CR", "优惠价_成人", "YHJ")) return false;
    if (!ValidateSpanInput("YHJ_ET", "优惠价_儿童", "YHJ")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateXLTS("XLTS", "忘记填写线路特色啦")
        & ValidateSelect("GNYCYFS", "CYFS", "忘记选择出游方式啦")
        & ValidateRadio("FTRQ", "忘记选择发团日期啦")
        & ValidateWFJT()
        & ValidateXCTS()
        & ValidateXCAP("XCAP", "忘记填写行程安排啦")
        & ValidateYDXZ("YDXZ", "忘记填写预定须知啦")
        & ValidateSpanInput("MSJ", "忘记填写门市价啦")
        & ValidateYHJ()
        & ValidateFYBH("FYBH", "忘记填写费用包含啦")
        & ValidateZFXM("ZFXM", "忘记填写自费项目啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证线路特色
function ValidateXLTS(id, message) {
    if (xlts.getContent() === "" || xlts.getContent() === null) {
        $("#div" + id + "Tip").css("display", "block");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />' + message);
        return false;
    } else {
        $("#div" + id + "Tip").css("display", "none");
        return true;
    }
}
//验证行程安排
function ValidateXCAP(id, message) {
    if (xcap.getContent() === "" || xcap.getContent() === null) {
        $("#div" + id + "Tip").css("display", "block");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />' + message);
        return false;
    } else {
        $("#div" + id + "Tip").css("display", "none");
        return true;
    }
}
//验证预定须知
function ValidateYDXZ(id, message) {
    if (ydxz.getContent() === "" || ydxz.getContent() === null) {
        $("#div" + id + "Tip").css("display", "block");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />' + message);
        return false;
    } else {
        $("#div" + id + "Tip").css("display", "none");
        return true;
    }
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