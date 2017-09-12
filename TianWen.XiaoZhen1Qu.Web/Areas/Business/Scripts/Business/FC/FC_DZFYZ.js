$(document).ready(function () {
    $("#XQMC").bind("blur", ValidateXQMC);
    $("#XQMC").bind("blur", HideXQMCList);
    $("#XQMC").bind("focus", InfoXQMC);
    $("#ZDZQ").bind("blur", ValidateZDZQ);
    $("#ZDZQ").bind("focus", InfoZDZQ);
    $("#YZRS").bind("blur", ValidateYZRS);
    $("#YZRS").bind("focus", InfoYZRS);
    $("#ZJ").bind("blur", ValidateZJ);
    $("#ZJ").bind("focus", InfoZJ);
    $("#MJ").bind("blur", ValidateMJ);
    $("#MJ").bind("focus", InfoMJ);
    $("#BT").bind("blur", ValidateBT);
    $("#BT").bind("focus", InfoBT);
    $("#LXR").bind("blur", ValidateLXR);
    $("#LXR").bind("focus", InfoLXR);
    $("#LXDH").bind("blur", ValidateLXDH);
    $("#LXDH").bind("focus", InfoLXDH);
});

function ValidateXQMC() {
    if ($("#XQMC").val() === "" || $("#XQMC").val() === null) {
        $("#divXQMCTip").css("display", "block");
        $("#divXQMCTip").attr("class", "Warn");
        $("#divXQMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写小区名称啦');
        $("#XQMC").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divXQMCTip").css("display", "none");
        $("#XQMC").css("border-color", "#cccccc");
        return true;
    }
}
//验证租金
function ValidateZJ() {
    if ($("#ZJ").val() === "" || $("#ZJ").val() === null) {
        $("#divZJTip").css("display", "block");
        $("#divZJTip").attr("class", "Warn");
        $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写租金啦');
        $("#spanZJ").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#ZJ").val())) {
            $("#divZJTip").css("display", "none");
            $("#spanZJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divZJTip").css("display", "block");
            $("#divZJTip").attr("class", "Warn");
            $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />租金请填写整数，面议则填0');
            $("#spanZJ").css("border-color", "#fd634f");
            return false;
        }
    }
}
//验证面积
function ValidateMJ() {
    if ($("#MJ").val() === "" || $("#MJ").val() === null) {
        $("#divMJTip").css("display", "inline-block");
        $("#divMJTip").attr("class", "Warn");
        $("#divMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写面积啦');
        $("#spanMJ").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#ZJ").val())) {
            $("#divMJTip").css("display", "none");
            $("#spanMJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divMJTip").css("display", "inline-block");
            $("#divMJTip").attr("class", "Warn");
            $("#divMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />面积请填写整数');
            $("#spanMJ").css("border-color", "#fd634f");
            return false;
        }
    }
}
//验证最短租期
function ValidateZDZQ() {
    if ($("#ZDZQ").val() === "" || $("#ZDZQ").val() === null) {
        $("#divZDZQTip").css("display", "block");
        $("#divZDZQTip").attr("class", "Warn");
        $("#divZDZQTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写最短租期啦');
        $("#spanZDZQ").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#ZDZQ").val()) && $("#ZDZQ").val() !== "0") {
            $("#divZDZQTip").css("display", "none");
            $("#spanZDZQ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divZDZQTip").css("display", "block");
            $("#divZDZQTip").attr("class", "Warn");
            $("#divZDZQTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />租期请填写整数');
            $("#spanZDZQ").css("border-color", "#fd634f");
            return false;
        }
    }
}
//宜租人数
function ValidateYZRS() {
    if ($("#YZRS").val() === "" || $("#YZRS").val() === null) {
        $("#divYZRSTip").css("display", "inline-block");
        $("#divYZRSTip").attr("class", "Warn");
        $("#divYZRSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写宜租人数啦');
        $("#spanYZRS").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#YZRS").val()) && $("#YZRS").val() !== "0") {
            $("#divYZRSTip").css("display", "none");
            $("#spanYZRS").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divYZRSTip").css("display", "inline-block");
            $("#divYZRSTip").attr("class", "Warn");
            $("#divYZRSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />宜租人数请填写整数');
            $("#spanYZRS").css("border-color", "#fd634f");
            return false;
        }
    }
}
//验证标题
function ValidateBT() {
    if ($("#BT").val() === "" || $("#BT").val() === null) {
        $("#divBTTip").css("display", "block");
        $("#divBTTip").attr("class", "Warn");
        $("#divBTTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写标题啦');
        $("#BT").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divBTTip").css("display", "none");
        $("#BT").css("border-color", "#cccccc");
        return true;
    }
}

function ValidateFWZP() {
    if ($("#divImgs1").find("img").length === 0) {
        $("#divFWZPTip").css("display", "block");
        $("#divFWZPTip").attr("class", "Warn");
        $("#divFWZPTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记选择照片啦');
        return false;
    } else {
        $("#divFWZPTip").css("display", "none");
        return true;
    }
}

function ValidateLXR() {
    if ($("#LXR").val() === "" || $("#LXR").val() === null) {
        $("#divLXRTip").css("display", "block");
        $("#divLXRTip").attr("class", "Warn");
        $("#divLXRTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写联系人啦');
        $("#LXR").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divLXRTip").css("display", "none");
        $("#LXR").css("border-color", "#cccccc");
        return true;
    }
}

function ValidateLXDH() {
    if ($("#LXDH").val() === "" || $("#LXDH").val() === null) {
        $("#divLXDHTip").css("display", "block");
        $("#divLXDHTip").attr("class", "Warn");
        $("#divLXDHTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写联系电话啦');
        $("#LXDH").css("border-color", "#fd634f");
        return false;
    } else {
        if ($("#LXDH").val().length !== 11) {
            $("#divLXDHTip").css("display", "block");
            $("#divLXDHTip").attr("class", "Warn");
            $("#divLXDHTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />手机号位数不对');
            $("#LXDH").css("border-color", "#fd634f");
            return false;

        } else {
            if (!ValidateCellPhone($("#LXDH").val())) {
                $("#divLXDHTip").css("display", "block");
                $("#divLXDHTip").attr("class", "Warn");
                $("#divLXDHTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />手机号格式不对');
                $("#LXDH").css("border-color", "#fd634f");
                return false;
            } else {
                $("#divLXDHTip").css("display", "none");
                $("#LXDH").css("border-color", "#cccccc");
                return true;
            }
        }
    }
}

function FWLXValidate() {
    if (!ValidateFWLX_S()) return false;
    if (!ValidateFWLX_T()) return false;
    if (!ValidateFWLX_W()) return false;
    if (!ValidateFWLX_PFM()) return false;
    return true;
}

function LCFBValidate() {
    if (!ValidateLCFB_C()) return false;
    if (!ValidateLCFB_GJC()) return false;
    return true;
}

function AllValidate() {
    if (ValidateXQMC() & ValidateZJ() & ValidateMJ() & ValidateZDZQ() & ValidateYZRS() & ValidateBT() & ValidateFWZP() & ValidateLXR() & ValidateLXDH())
        return true;
    else
        return false;
}

function InfoXQMC() {
    $("#divXQMCTip").css("display", "block");
    $("#divXQMCTip").attr("class", "Info");
    $("#divXQMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />不超过30字');
    $("#XQMC").css("border-color", "#5bc0de");
}

function InfoZJ() {
    $("#divZJTip").css("display", "block");
    $("#divZJTip").attr("class", "Info");
    $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，面议则填0');
}

function InfoZDZQ() {
    $("#divZDZQTip").css("display", "block");
    $("#divZDZQTip").attr("class", "Info");
    $("#divZDZQTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数');
}

function InfoYZRS() {
    $("#divYZRSTip").css("display", "inline-block");
    $("#divYZRSTip").attr("class", "Info");
    $("#divYZRSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数');
}

function InfoMJ() {
    $("#divMJTip").css("display", "inline-block");
    $("#divMJTip").attr("class", "Info");
    $("#divMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数');
}

function InfoBT() {
    $("#divBTTip").css("display", "block");
    $("#divBTTip").attr("class", "Info");
    $("#divBTTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />标题不超过50字');
    $("#BT").css("border-color", "#5bc0de");
}

function InfoLXR() {
    $("#divLXRTip").css("display", "block");
    $("#divLXRTip").attr("class", "Info");
    $("#divLXRTip").html('');
    $("#LXR").css("border-color", "#5bc0de");
}

function InfoLXDH() {
    $("#divLXDHTip").css("display", "block");
    $("#divLXDHTip").attr("class", "Info");
    $("#divLXDHTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请输入手机号');
    $("#LXDH").css("border-color", "#5bc0de");
}

function HideXQMCList() {
    if (isleave)
        $("#divXQMClist").css("display", "none");
}