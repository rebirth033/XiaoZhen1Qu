$(document).ready(function () {

});
//营业时间
function ValidateYYSJ() {
    if (!ValidateSJ_H("YYSJ", "YYKSSJ_H", $("#YYKSSJ_H").val())) return false;
    if (!ValidateSJ_M("YYSJ", "YYKSSJ_M", $("#YYKSSJ_M").val())) return false;
    if (!ValidateSJ_H("YYSJ", "YYJSSJ_H", $("#YYJSSJ_H").val())) return false;
    if (!ValidateSJ_M("YYSJ", "YYJSSJ_M", $("#YYJSSJ_M").val())) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateCheck("LB", "忘记选择类别啦")
        & ValidateYYSJ()
        & ValidateBCMS("BCMS", "忘记填写服务介绍啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证时间_时
function ValidateSJ_H(type, id, value) {
    if (value === "" || value === null) {
        $("#div" + type + "Tip").css("display", "block");
        $("#div" + type + "Tip").attr("class", "Warn");
        $("#div" + type + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写小时啦');
        $("#div" + type + "Tip").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber(value)) {
            $("#div" + type + "Tip").css("display", "none");
            $("#" + id).css("border-color", "#cccccc");
            return true;
        } else {
            $("#div" + type + "Tip").css("display", "block");
            $("#div" + type + "Tip").attr("class", "Warn");
            $("#div" + type + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />小时请填写整数');
            $("#" + id).css("border-color", "#F2272D");
            return false;
        }
    }
}
//验证时间_分
function ValidateSJ_M(type, id, value) {
    if (value === "" || value === null) {
        $("#div" + type + "Tip").css("display", "block");
        $("#div" + type + "Tip").attr("class", "Warn");
        $("#div" + type + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写分钟啦');
        $("#div" + type + "Tip").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber(value)) {
            $("#div" + type + "Tip").css("display", "none");
            $("#" + id).css("border-color", "#cccccc");
            return true;
        } else {
            $("#div" + type + "Tip").css("display", "block");
            $("#div" + type + "Tip").attr("class", "Warn");
            $("#div" + type + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />分钟请填写整数');
            $("#" + id).css("border-color", "#F2272D");
            return false;
        }
    }
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