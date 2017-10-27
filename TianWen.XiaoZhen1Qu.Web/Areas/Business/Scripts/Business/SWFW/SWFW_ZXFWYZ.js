$(document).ready(function () {

});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择类别啦")) return false;
    return true;
}
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
    if (ValidateLB()
        & ValidateYYSJ()
        & ValidateFWQY()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
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
        $("#div" + type + "Tip").css("border-color", "#fd634f");
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
            $("#" + id).css("border-color", "#fd634f");
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
        $("#div" + type + "Tip").css("border-color", "#fd634f");
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
            $("#" + id).css("border-color", "#fd634f");
            return false;
        }
    }
}