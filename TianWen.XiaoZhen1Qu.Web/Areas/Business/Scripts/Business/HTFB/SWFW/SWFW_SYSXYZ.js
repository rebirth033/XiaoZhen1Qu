$(document).ready(function () {
    $("#divYLGZS").find(".div_radio").bind("click", function () { ValidateRadio("YLGZS", ""); });
    $("#divXZLX").find(".div_radio").bind("click", function () { ValidateRadio("XZLX", ""); });
    $("#divPSDD").find(".div_radio").bind("click", function () { ValidateRadio("PSDD", ""); });
    $("#divFZPSSF").find(".div_radio").bind("click", function () { ValidateRadio("FZPSSF", ""); });
    $("#divJXKPZS").find(".div_radio").bind("click", function () { ValidateRadio("JXKPZS", ""); });
    $("#divDPZS").find(".div_radio").bind("click", function () { ValidateRadio("DPZS", ""); });
    $("#divJPSF").find(".div_radio").bind("click", function () { ValidateRadio("JPSF", ""); });
    $("#divJDSF").find(".div_radio").bind("click", function () { ValidateRadio("JDSF", ""); });

    $("#divSYLX").find(".div_radio").bind("click", function () { ValidateRadio("SYLX", ""); });
    $("#divSLLX").find(".div_radio").bind("click", function () { ValidateRadio("SLLX", ""); });

    $("#FZTS").bind("blur", function () { ValidateNumber("FZTS", "服装套数"); });
    $("#FZTS").bind("focus", function () { InfoNumber("FZTS"); });
    $("#TXDPS").bind("blur", function () { ValidateNumber("TXDPS", "套系底片数"); });
    $("#TXDPS").bind("focus", function () { InfoNumber("TXDPS"); });
    $("#TXJXJRCS").bind("blur", function () { ValidateNumber("TXJXJRCS", "套系精修及入册数"); });
    $("#TXJXJRCS").bind("focus", function () { InfoNumber("TXJXJRCS"); });
    $("#TXXCSL").bind("blur", function () { ValidateNumber("TXXCSL", "套系相册数量"); });
    $("#TXXCSL").bind("focus", function () { InfoNumber("TXXCSL"); });
    $("#TXBJSL").bind("blur", function () { ValidateNumber("TXBJSL", "套系摆件数量"); });
    $("#TXBJSL").bind("focus", function () { InfoNumber("TXBJSL"); });
});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择类别啦")) return false;
    if ($("#spanLB").html() === "写真/艺术照") {
        if (ValidateRadio("YLGZS", "忘记选择影楼/工作室啦")
            & ValidateRadio("XZLX", "忘记选择写真类型啦")
            & ValidateRadio("PSDD", "忘记选择拍摄地点啦")
            & ValidateSelect("SYSXPSFG", "PSFG", "忘记选择拍摄风格啦")
            & ValidateNumber("FZTS", "服装套数")
            & ValidateRadio("FZPSSF", "忘记选择服装配饰收费啦")
            & ValidateNumber("TXDPS", "套系底片数")
            & ValidateNumber("TXJXJRCS", "套系精修及入册数")
            & ValidateRadio("JXKPZS", "忘记选择精修刻盘赠送啦")
            & ValidateRadio("DPZS", "忘记选择底片赠送啦")
            & ValidateRadio("JPSF", "忘记选择加片收费啦")
            & ValidateRadio("JDSF", "忘记选择加底收费啦")
            & ValidateNumber("TXXCSL", "套系相册数量")
            & ValidateNumber("TXBJSL", "套系摆件数量")) return true;
        else return false;
    }
    if ($("#spanLB").html() === "儿童摄影") {
        if (ValidateRadio("YLGZS", "忘记选择影楼/工作室啦")
            & ValidateSelect("SYSXNLD", "NLD", "忘记选择年龄段啦")
            & ValidateRadio("PSDD", "忘记选择拍摄地点啦")
            & ValidateNumber("FZTS", "服装套数")
            & ValidateRadio("FZPSSF", "忘记选择服装配饰收费啦")
            & ValidateNumber("TXDPS", "套系底片数")
            & ValidateNumber("TXJXJRCS", "套系精修及入册数")
            & ValidateRadio("JXKPZS", "忘记选择精修刻盘赠送啦")
            & ValidateRadio("DPZS", "忘记选择底片赠送啦")
            & ValidateRadio("JPSF", "忘记选择加片收费啦")
            & ValidateRadio("JDSF", "忘记选择加底收费啦")
            & ValidateNumber("TXXCSL", "套系相册数量")
            & ValidateNumber("TXBJSL", "套系摆件数量")) return true;
        else return false;
    }
    if ($("#spanLB").html() === "商业摄影") {
        if (ValidateRadio("SYLX", "忘记选择摄影类型啦")) return true;
        else return false;
    }
    if ($("#spanLB").html() === "摄像录像") {
        if (ValidateRadio("SLLX", "忘记选择摄录类型啦")) return true;
        else return false;
    }
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateJG()
        & ValidateFWFW()
        & ValidateBCMS("BCMS", "忘记填写服务介绍啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证数字输入框
function ValidateNumber(id, value) {
    if ($("#" + id).val() === "" || $("#" + +id).val() === null) {
        $("#div" + id + "Tip").css("display", "block");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写' + value + '啦');
        $("#span" + id).css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateDecimal($("#FZTS").val())) {
            $("#div" + id + "Tip").css("display", "none");
            $("#span" + id).css("border-color", "#cccccc");
            return true;
        } else {
            $("#div" + id + "Tip").css("display", "block");
            $("#div" + id + "Tip").attr("class", "Warn");
            $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />' + value + '请填写数字');
            $("#span" + id).css("border-color", "#F2272D");
            return false;
        }
    }
}
//提示数字输入框
function InfoNumber(id) {
    $("#div" + id + "Tip").css("display", "block");
    $("#div" + id + "Tip").attr("class", "Info");
    $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写数字');
    $("#" + id).css("border-color", "#bc6ba6");
}
//验证服务介绍
function ValidateBCMS(id, message) {
    if (ue.getContent() === "" || ue.getContent() === null) {
        $("#div" + id + "Tip").css("display", "block");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写服务介绍啦');
        $("#edui1").css("border-color", "#F2272D");
        return false;
    } else {
        $("#div" + id + "Tip").css("display", "none");
        return true;
    }
}
//提示服务介绍
function InfoBCMS(id, message) {
    $("#div" + id + "Tip").css("display", "block");
    $("#div" + id + "Tip").attr("class", "Info");
    $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写服务介绍');
    $("#edui1").css("border-color", "#bc6ba6");
}