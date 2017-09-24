$(document).ready(function () {
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
    $("#BT").bind("blur", ValidateBT);
    $("#BT").bind("focus", InfoBT);
    $("#LXR").bind("blur", ValidateLXR);
    $("#LXR").bind("focus", InfoLXR);
    $("#LXDH").bind("blur", ValidateLXDH);
    $("#LXDH").bind("focus", InfoLXDH);
});

//验证售价
function ValidateJG() {
    if ($("#JG").val() === "" || $("#JG").val() === null) {
        $("#divJGTip").css("display", "block");
        $("#divJGTip").attr("class", "Warn");
        $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写价格啦');
        $("#spanJG").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#JG").val())) {
            $("#divJGTip").css("display", "none");
            $("#spanJG").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divJGTip").css("display", "block");
            $("#divJGTip").attr("class", "Warn");
            $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />价格请填写整数，面议则填0');
            $("#spanJG").css("border-color", "#fd634f");
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
    if (ValidateJG() & ValidateBT() & ValidateLXR() & ValidateLXDH())
        return true;
    else
        return false;
}
//提示价格
function InfoJG() {
    $("#divJGTip").css("display", "inline-block");
    $("#divJGTip").attr("class", "Info");
    $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，面议则填0');
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