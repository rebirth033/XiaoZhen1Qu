$(document).ready(function () {
    $("#BT").bind("blur", function () { ValidateInput("BT", "标题"); });
    $("#BT").bind("focus", function () { InfoInput("BT", "请填写标题"); });
    $("#LXR").bind("blur", function () { ValidateInput("LXR", "联系人"); });
    $("#LXR").bind("focus", function () { InfoInput("LXR", "请填写联系人"); });
    $("#LXDH").bind("blur", function () { ValidateInput("LXDH", "联系电话"); });
    $("#LXDH").bind("focus", function () { InfoInput("LXDH", "请填写联系电话"); });
    ue.addListener("focus", function (type, event) { InfoBCMS("BCMS", "请填写详情描述"); });
    ue.addListener("blur", function (type, event) { ValidateBCMS("BCMS", "忘记填写详情描述啦"); });
    $("#JTDZ").bind("blur", ValidateJTDZ);
    $("#JTDZ").bind("focus", InfoJTDZ);
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
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
//验证价格
function ValidateJG() {
    if ($("#JG").val() === "" || $("#JG").val() === null) {
        $("#divJGTip").css("display", "block");
        $("#divJGTip").attr("class", "Warn");
        $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写价格啦');
        $("#spanJG").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateDecimal($("#JG").val())) {
            $("#divJGTip").css("display", "none");
            $("#spanJG").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divJGTip").css("display", "block");
            $("#divJGTip").attr("class", "Warn");
            $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />价格请填写数字，最多保留两位小数，默认为面议');
            $("#spanJG").css("border-color", "#F2272D");
            return false;
        }
    }
}
//验证联系电话
function ValidateLXDH() {
    if ($("#LXDH").val() === "" || $("#LXDH").val() === null) {
        $("#divLXDHTip").css("display", "block");
        $("#divLXDHTip").attr("class", "Warn");
        $("#divLXDHTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写联系电话啦');
        $("#LXDH").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateCellPhone($("#LXDH").val()) || ValidateTelePhone($("#LXDH").val())) {
            $("#divLXDHTip").css("display", "none");
            $("#LXDH").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divLXDHTip").css("display", "block");
            $("#divLXDHTip").attr("class", "Warn");
            $("#divLXDHTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />电话号码格式不正确');
            $("#LXDH").css("border-color", "#F2272D");
            return false;
        }
    }
}
//验证详情描述
function ValidateBCMS(id, message) {
    if (ue.getContent() === "" || ue.getContent() === null) {
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
//验证具体地址
function ValidateJTDZ() {
    if ($("#JTDZ").val() === "" || $("#JTDZ").val() === null) {
        $("#divSZQYTip").css("display", "block");
        $("#divSZQYTip").attr("class", "Warn");
        $("#divSZQYTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写具体地址啦');
        $("#JTDZ").css("border-color", "#F2272D");
        return false;
    } else {
        $("#divSZQYTip").css("display", "none");
        $("#JTDZ").css("border-color", "#cccccc");
        return true;
    }
}
//验证span输入框
function ValidateSpanInput(id, value, outid) {
    if (outid === "" || outid === null || outid === undefined)
        outid = id;
    if ($("#" + id).val() === "" || $("#" + id).val() === null) {
        $("#div" + outid + "Tip").css("display", "block");
        $("#div" + outid + "Tip").attr("class", "Warn");
        $("#div" + outid + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写' + value + '啦');
        $("#span" + id).css("border-color", "#F2272D");
        return false;
    } else {
        $("#div" + outid + "Tip").css("display", "none");
        $("#span" + id).css("border-color", "#cccccc");
        return true;
    }
}
//验证输入框
function ValidateInput(id, value, outid) {
    if (outid === "" || outid === null || outid === undefined)
        outid = id;
    if ($("#" + id).val() === "" || $("#" + id).val() === null) {
        $("#div" + outid + "Tip").css("display", "block");
        $("#div" + outid + "Tip").attr("class", "Warn");
        $("#div" + outid + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写' + value + '啦');
        $("#" + id).css("border-color", "#F2272D");
        return false;
    } else {
        $("#div" + outid + "Tip").css("display", "none");
        $("#" + id).css("border-color", "#cccccc");
        return true;
    }
}
//验证单选框
function ValidateRadio(id, message) {
    var bool = false;
    $("#div" + id).find("img").each(function () {
        if ($(this).attr("src").indexOf("purple") !== -1) {
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
        if ($(this).attr("src").indexOf("purple") !== -1) {
            $("#div" + id + "Tip").css("display", "none");
            bool = true;
        }
    });
    if (!bool) {
        $("#div" + id + "Tip").css("display", "block");
        //$("#div" + id + "Tip").css("margin-top", "-10px");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />' + message + '');
    }
    return bool;
}
//验证下拉框
function ValidateSelect(idout, idin, message) {
    var bool = false;
    if ($("#span" + idin).html().indexOf("请选择") !== -1) {
        $("#div" + idin + "Text").css("border-color", "#F2272D");
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
//验证共有
function ValidateCommon() {
    if (ValidateInput("BT", "标题") & ValidateZP() & ValidateInput("LXR", "联系人") & ValidateLXDH())
        return true;
    else
        return false;
}
//验证共有不包括图片
function ValidateCommonWithoutZP() {
    if (ValidateInput("BT", "标题") & ValidateInput("LXR", "联系人") & ValidateLXDH())
        return true;
    else
        return false;
}
//验证所在区域
function ValidateSZQY() {
    //if (!ValidateSelect("SZQY", "QY", "请选择区域")) return false;
    //if (!ValidateSelect("SZQY", "DD", "请选择地段")) return false;
    return true;
}
//验证详细地址
function ValidateXXDZ() {
    //if (!ValidateSelect("SZQY", "QY", "请选择区域")) return false;
    //if (!ValidateSelect("SZQY", "DD", "请选择地段")) return false;
    if (!ValidateJTDZ()) return false;
    return true;
}
//提示价格
function InfoJG() {
    $("#divJGTip").css("display", "block");
    $("#divJGTip").attr("class", "Info");
    $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写数字,最多保留两位小数,默认为面议');
    $("#spanJG").css("border-color", "#bc6ba6");
}
//提示详情描述
function InfoBCMS(id, message) {
    $("#div" + id + "Tip").css("display", "block");
    $("#div" + id + "Tip").attr("class", "Info");
    $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />' + message);
    $("#edui1").css("border-color", "#bc6ba6");
}
//提示服务区域
function InfoFWFW() {
    $("#divFWFWTip").css("display", "block");
    $("#divFWFWTip").attr("class", "Info");
    $("#divFWFWTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />填写服务区域');
    $("#FWFW").css("border-color", "#bc6ba6");
}
//提示具体地址
function InfoJTDZ() {
    $("#divSZQYTip").css("display", "block");
    $("#divSZQYTip").attr("class", "Info");
    $("#divSZQYTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />填写具体地址，长度100字以内');
    $("#JTDZ").css("border-color", "#bc6ba6");
}
//提示span输入框
function InfoSpanInput(id, message, outid) {
    if (outid === "" || outid === null || outid === undefined)
        outid = id;
    $("#div" + outid + "Tip").css("display", "block");
    $("#div" + outid + "Tip").attr("class", "Info");
    $("#div" + outid + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />' + message);
    $("#span" + id).css("border-color", "#bc6ba6");
}
//提示输入框
function InfoInput(id, message, outid) {
    if (outid === "" || outid === null || outid === undefined)
        outid = id;
    $("#div" + outid + "Tip").css("display", "block");
    $("#div" + outid + "Tip").attr("class", "Info");
    $("#div" + outid + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />' + message);
    $("#" + id).css("border-color", "#bc6ba6");
}