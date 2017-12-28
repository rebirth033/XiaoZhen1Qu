$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", ""); });
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择供求啦"); });
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
    if (GetGQ() === "出售") {
        if (ValidateRadio("GQ", "忘记选择供求啦")
            & ValidateRadio("SF", "忘记选择身份啦")
            & ValidateBCMS("BCMS", "忘记填写补充描述啦")
            & ValidateSZQY()
            & ValidateSJ()
            & ValidateMJ()
            & ValidateCommon())
            return true;
        else
            return false;
    }
    else {
        if (ValidateRadio("GQ", "忘记选择供求啦")
        & ValidateRadio("SF", "忘记选择身份啦")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateSZQY()
        & ValidateZJ()
        & ValidateMJ()
        & ValidateCommon())
            return true;
        else
            return false;
    }
}
//验证租金
function ValidateZJ() {
    if ($("#ZJ").val() === "" || $("#ZJ").val() === null) {
        $("#divZJTip").css("display", "block");
        $("#divZJTip").attr("class", "Warn");
        $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写租金啦');
        $("#spanZJ").css("border-color", "#F2272D");
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
            $("#spanZJ").css("border-color", "#F2272D");
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
        $("#spanSJ").css("border-color", "#F2272D");
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
            $("#spanSJ").css("border-color", "#F2272D");
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
        $("#spanMJ").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber($("#ZJ").val())) {
            $("#divMJTip").css("display", "none");
            $("#spanMJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divMJTip").css("display", "block");
            $("#divMJTip").attr("class", "Warn");
            $("#divMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />面积请填写整数，默认为面议');
            $("#spanMJ").css("border-color", "#F2272D");
            return false;
        }
    }
}
//提示租金
function InfoZJ() {
    $("#divZJTip").css("display", "block");
    $("#divZJTip").attr("class", "Info");
    $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanZJ").css("border-color", "#bc6ba6");
}
//提示售价
function InfoSJ() {
    $("#divSJTip").css("display", "block");
    $("#divSJTip").attr("class", "Info");
    $("#divSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanSJ").css("border-color", "#bc6ba6");
}
//提示面积
function InfoMJ() {
    $("#divMJTip").css("display", "block");
    $("#divMJTip").attr("class", "Info");
    $("#divMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数');
    $("#spanMJ").css("border-color", "#bc6ba6");
}
