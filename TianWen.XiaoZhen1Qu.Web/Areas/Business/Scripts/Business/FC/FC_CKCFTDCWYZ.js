$(document).ready(function () {
    $("#LPMC").bind("blur", ValidateLPMC);
    $("#LPMC").bind("focus", InfoLPMC);
    $("#DD").bind("blur", ValidateDD);
    $("#DD").bind("focus", InfoDD);
    $("#ZJ").bind("blur", ValidateZJ);
    $("#ZJ").bind("focus", InfoZJ);
    $("#SJ").bind("blur", ValidateSJ);
    $("#SJ").bind("focus", InfoSJ);
    $("#MJ").bind("blur", ValidateMJ);
    $("#MJ").bind("focus", InfoMJ);
    $("#BT").bind("blur", ValidateBT);
    $("#BT").bind("focus", InfoBT);
    $("#LXR").bind("blur", ValidateLXR);
    $("#LXR").bind("focus", InfoLXR);
    $("#LXDH").bind("blur", ValidateLXDH);
    $("#LXDH").bind("focus", InfoLXDH);
});
//验证楼盘名称
function ValidateLPMC() {
    if ($("#LPMC").val() === "" || $("#LPMC").val() === null) {
        $("#divLPMCTip").css("display", "block");
        $("#divLPMCTip").attr("class", "Warn");
        $("#divLPMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写楼盘名称啦');
        $("#spanLPMC").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divLPMCTip").css("display", "none");
        $("#spanLPMC").css("border-color", "#cccccc");
        return true;
    }
}
//验证地段
function ValidateDD() {
    if ($("#DD").val() === "" || $("#DD").val() === null) {
        $("#divDDTip").css("display", "block");
        $("#divDDTip").attr("class", "Warn");
        $("#divDDTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写地段啦');
        $("#spanDD").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divDDTip").css("display", "none");
        $("#spanDD").css("border-color", "#cccccc");
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
        if (ValidateNumber($("#ZJ").val()) && $("#ZJ").val() !== "0") {
            $("#divZJTip").css("display", "none");
            $("#spanZJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divZJTip").css("display", "block");
            $("#divZJTip").attr("class", "Warn");
            $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />租金请填写整数');
            $("#spanZJ").css("border-color", "#fd634f");
            return false;
        }
    }
}
//验证售价
function ValidateSJ() {
    if ($("#SJ").val() === "" || $("#SJ").val() === null) {
        $("#divSJTip").css("display", "block");
        $("#divSJTip").attr("class", "Warn");
        $("#divSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写售价啦');
        $("#spanSJ").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#SJ").val()) && $("#SJ").val() !== "0") {
            $("#divSJTip").css("display", "none");
            $("#spanSJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divSJTip").css("display", "block");
            $("#divSJTip").attr("class", "Warn");
            $("#divSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />售价请填写整数');
            $("#spanSJ").css("border-color", "#fd634f");
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
        if (ValidateNumber($("#ZJ").val()) && $("#ZJ").val() !== "0") {
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
//验证照片
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
//验证联系人
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
//验证联系电话
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
//验证所有
function AllValidate() {
    if ($("#imgCZ").attr("src").indexOf("blue") !== -1) {
        if (ValidateLPMC() & ValidateDD() & ValidateZJ() & ValidateMJ() & ValidateBT() & ValidateFWZP() & ValidateLXR() & ValidateLXDH())
            return true;
        else
            return false;
    } else {
        if (ValidateLPMC() & ValidateDD() & ValidateSJ() & ValidateMJ() & ValidateBT() & ValidateFWZP() & ValidateLXR() & ValidateLXDH())
            return true;
        else
            return false;
    }
}
//提示楼盘名称
function InfoLPMC() {
    $("#divLPMCTip").css("display", "block");
    $("#divLPMCTip").attr("class", "Info");
    $("#divLPMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />不超过30字，不能填写电话、QQ、邮箱等联系方式或特殊符号');
    $("#LPMC").css("border-color", "#5bc0de");
}
//提示地段
function InfoDD() {
    $("#divDDTip").css("display", "block");
    $("#divDDTip").attr("class", "Info");
    $("#divDDTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />不超过30字，不能填写电话、QQ、邮箱等联系方式或特殊符号');
    $("#DD").css("border-color", "#5bc0de");
}
//提示租金
function InfoZJ() {
    $("#divZJTip").css("display", "block");
    $("#divZJTip").attr("class", "Info");
    $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，面议则填0');
}
//提示租金
function InfoSJ() {
    $("#divSJTip").css("display", "block");
    $("#divSJTip").attr("class", "Info");
    $("#divSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，面议则填0');
}
//提示面积
function InfoMJ() {
    $("#divMJTip").css("display", "inline-block");
    $("#divMJTip").attr("class", "Info");
    $("#divMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数');
}
//提示标题
function InfoBT() {
    $("#divBTTip").css("display", "block");
    $("#divBTTip").attr("class", "Info");
    $("#divBTTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />标题不超过50字');
    $("#BT").css("border-color", "#5bc0de");
}
//提示联系人
function InfoLXR() {
    $("#divLXRTip").css("display", "block");
    $("#divLXRTip").attr("class", "Info");
    $("#divLXRTip").html('');
    $("#LXR").css("border-color", "#5bc0de");
}
//提示联系电话
function InfoLXDH() {
    $("#divLXDHTip").css("display", "block");
    $("#divLXDHTip").attr("class", "Info");
    $("#divLXDHTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请输入手机号');
    $("#LXDH").css("border-color", "#5bc0de");
}