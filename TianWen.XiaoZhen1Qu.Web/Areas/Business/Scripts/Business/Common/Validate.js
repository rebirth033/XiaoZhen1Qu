$(document).ready(function () {
    $("#BT").bind("blur", ValidateBT);
    $("#BT").bind("focus", InfoBT);
    $("#LXR").bind("blur", ValidateLXR);
    $("#LXR").bind("focus", InfoLXR);
    $("#LXDH").bind("blur", ValidateLXDH);
    $("#LXDH").bind("focus", InfoLXDH);
});

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
function ValidateZP() {
    if ($("#divImgs1").find("img").length === 0) {
        $("#divTPTip").css("display", "block");
        $("#divTPTip").attr("class", "Warn");
        $("#divTPTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记上传照片啦');
        return false;
    } else {
        $("#divTPTip").css("display", "none");
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
    $("#divLXRTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请输入联系人');
    $("#LXR").css("border-color", "#5bc0de");
}
//提示联系电话
function InfoLXDH() {
    $("#divLXDHTip").css("display", "block");
    $("#divLXDHTip").attr("class", "Info");
    $("#divLXDHTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请输入手机号');
    $("#LXDH").css("border-color", "#5bc0de");
}
//验证单选框
function ValidateRadio(id, message) {
    var bool = false;
    $("#div" + id).find("img").each(function () {
        if ($(this).attr("src").indexOf("blue") !== -1) {
            $("#div" + id + "Tip").css("display", "none");
            bool = true;
        }
    });
    if (!bool) {
        $("#div" + id + "Tip").css("display", "block");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />' + message + '');
    }
    return bool;
}
//验证多选框
function ValidateCheck(id, message) {
    var bool = false;
    $("#div" + id).find("img").each(function () {
        if ($(this).attr("src").indexOf("blue") !== -1) {
            $("#div" + id + "Tip").css("display", "none");
            bool = true;
        }
    });
    if (!bool) {
        $("#div" + id + "Tip").css("display", "block");
        $("#div" + id + "Tip").css("margin-top", "-10px");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />' + message + '');
    }
    return bool;
}
//验证下拉框
function ValidateSelect(idout, idin, message) {
    var bool = false;
    if ($("#span" + idin).html().indexOf("请选择") !== -1) {
        $("#div" + idin + "Text").css("border-color", "#fd634f");
        $("#div" + idout + "Tip").css("display", "block");
        $("#div" + idout + "Tip").attr("class", "Warn");
        $("#div" + idout + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />' + message + '');
    }
    else {
        $("#div" + idin + "Text").css("border-color", "#cccccc");
        $("#div" + idout + "Tip").css("display", "none");
        bool = true;
    }
    return bool;
}
//验证补充描述
function ValidateBCMS(id, message) {
    if (ue.getContent() === "" || ue.getContent() === null) {
        $("#div" + id + "Tip").css("display", "block");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />' + message);
        return false;
    } else {
        $("#div" + id + "Tip").css("display", "none");
        return true;
    }
}
//验证共有
function ValidateCommon() {
    if (ValidateBT() & ValidateZP() & ValidateLXR() & ValidateLXDH())
        return true;
    else
        return false;
}