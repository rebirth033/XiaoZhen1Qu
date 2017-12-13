$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择供求啦"); });
    $("#divXZLLX").find(".div_radio").bind("click", function () { ValidateRadio("XZLLX", "忘记选择类型啦"); });
    $("#divKZCGS").find(".div_radio").bind("click", function () { ValidateRadio("KZCGS", "忘记选择可注册公司啦"); });
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
});
//验证所有
function ValidateAll() {
    if (GetGQ() !== "出售") {
        if (ValidateRadio("GQ", "忘记选择供求啦")
            & ValidateRadio("XZLLX", "忘记选择类型啦")
            & ValidateRadio("KZCGS", "忘记选择可注册公司啦")
            & ValidateBCMS("BCMS", "忘记填写补充描述啦")
            & ValidateSZQY()
            & ValidateLPMC()
            & ValidateDD()
            & ValidateZJ()
            & ValidateMJ()
            & ValidateCommon())
            return true;
        else
            return false;
    } else {
        if (ValidateRadio("GQ", "忘记选择供求啦")
            & ValidateRadio("XZLLX", "忘记选择类型啦")
            & ValidateRadio("KZCGS", "忘记选择可注册公司啦")
            & ValidateBCMS("BCMS", "忘记填写补充描述啦")
            & ValidateSZQY()
            & ValidateLPMC()
            & ValidateDD()
            & ValidateSJ()
            & ValidateMJ()
            & ValidateCommon())
            return true;
        else
            return false;
    }
}
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
//提示楼盘名称
function InfoLPMC() {
    $("#divLPMCTip").css("display", "block");
    $("#divLPMCTip").attr("class", "Info");
    $("#divLPMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />不超过30字，不能填写电话、QQ、邮箱等联系方式或特殊符号');
    $("#LPMC").css("border-color", "#ad5b97");
}
//提示地段
function InfoDD() {
    $("#divDDTip").css("display", "block");
    $("#divDDTip").attr("class", "Info");
    $("#divDDTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />不超过30字，不能填写电话、QQ、邮箱等联系方式或特殊符号');
    $("#DD").css("border-color", "#ad5b97");
}
//提示租金
function InfoZJ() {
    $("#divZJTip").css("display", "block");
    $("#divZJTip").attr("class", "Info");
    $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanZJ").css("border-color", "#ad5b97");
}
//提示售价
function InfoSJ() {
    $("#divSJTip").css("display", "block");
    $("#divSJTip").attr("class", "Info");
    $("#divSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanSJ").css("border-color", "#ad5b97");
}
//提示面积
function InfoMJ() {
    $("#divMJTip").css("display", "block");
    $("#divMJTip").attr("class", "Info");
    $("#divMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanMJ").css("border-color", "#ad5b97");
}
