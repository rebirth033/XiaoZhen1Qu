$(document).ready(function () {
    $("#divFL").find(".div_radio").bind("click", function () { ValidateRadio("FL", ""); });
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", ""); });
    $("#divJYZT").find(".div_radio").bind("click", function () { ValidateRadio("JYZT", ""); });
    $("#LSJY").bind("blur", ValidateLSJY);
    $("#LSJY").bind("focus", InfoLSJY);
    $("#DD").bind("blur", ValidateDD);
    $("#DD").bind("focus", InfoDD);
    $("#ZJ").bind("blur", ValidateZJ);
    $("#ZJ").bind("focus", InfoZJ);
    $("#SJ").bind("blur", ValidateSJ);
    $("#SJ").bind("focus", InfoSJ);
    $("#MJ").bind("blur", ValidateMJ);
    $("#MJ").bind("focus", InfoMJ);
});
//验证所有
function ValidateAll() {
    if (GetGQ() !== "出售") {
        if (ValidateRadio("FL", "忘记选择分类啦")
            & ValidateRadio("GQ", "忘记选择供求啦")
            & ValidateRadio("JYZT", "忘记选择经营状态啦")
            & ValidateSelect("LX", "SPLX", "请选择商铺类型")
            & ValidateSelect("SPJYHY", "JYHY", "请选择经营行业")
            & ValidateBCMS("BCMS", "忘记填写补充描述啦")
            & ValidateXXDZ()
            & ValidateZJ()
            & ValidateMJ()
            & ValidateCommon())
            return true;
        else
            return false;
    } else {
        if (ValidateRadio("FL", "忘记选择分类啦")
            & ValidateRadio("GQ", "忘记选择供求啦")
            & ValidateSelect("LX", "SPLX", "请选择商铺类型")
            & ValidateBCMS("BCMS", "忘记填写补充描述啦")
            & ValidateXXDZ()
            & ValidateSJ()
            & ValidateMJ()
            & ValidateCommon())
            return true;
        else
            return false;
    }
}
//验证历史经营
function ValidateLSJY() {
    if ($("#LSJY").val() === "" || $("#LSJY").val() === null) {
        $("#divLSJYTip").css("display", "block");
        $("#divLSJYTip").attr("class", "Warn");
        $("#divLSJYTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写历史经营啦');
        $("#spanLSJY").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divLSJYTip").css("display", "none");
        $("#spanLSJY").css("border-color", "#cccccc");
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
        if (ValidateNumber($("#ZJ").val())) {
            $("#divZJTip").css("display", "none");
            $("#spanZJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divZJTip").css("display", "block");
            $("#divZJTip").attr("class", "Warn");
            $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />租金请填写整数，默认为面议');
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
        if (ValidateNumber($("#SJ").val())) {
            $("#divSJTip").css("display", "none");
            $("#spanSJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divSJTip").css("display", "block");
            $("#divSJTip").attr("class", "Warn");
            $("#divSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />售价请填写整数，默认为面议');
            $("#spanSJ").css("border-color", "#fd634f");
            return false;
        }
    }
}
//验证面积
function ValidateMJ() {
    if ($("#MJ").val() === "" || $("#MJ").val() === null) {
        $("#divMJTip").css("display", "block");
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
            $("#divMJTip").css("display", "block");
            $("#divMJTip").attr("class", "Warn");
            $("#divMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />面积请填写整数，默认为面议');
            $("#spanMJ").css("border-color", "#fd634f");
            return false;
        }
    }
}
//提示历史经营
function InfoLSJY() {
    $("#divLSJYTip").css("display", "block");
    $("#divLSJYTip").attr("class", "Info");
    $("#divLSJYTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />不超过30字，不能填写电话、QQ、邮箱等联系方式或特殊符号');
    $("#spanLSJY").css("border-color", "#5bc0de");
}
//提示地段
function InfoDD() {
    $("#divDDTip").css("display", "block");
    $("#divDDTip").attr("class", "Info");
    $("#divDDTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />不超过30字，不能填写电话、QQ、邮箱等联系方式或特殊符号');
    $("#spanDD").css("border-color", "#5bc0de");
}
//提示租金
function InfoZJ() {
    $("#divZJTip").css("display", "block");
    $("#divZJTip").attr("class", "Info");
    $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanZJ").css("border-color", "#5bc0de");
}
//提示售价
function InfoSJ() {
    $("#divSJTip").css("display", "block");
    $("#divSJTip").attr("class", "Info");
    $("#divSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanSJ").css("border-color", "#5bc0de");
}
//提示面积
function InfoMJ() {
    $("#divMJTip").css("display", "block");
    $("#divMJTip").attr("class", "Info");
    $("#divMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanMJ").css("border-color", "#5bc0de");
}
