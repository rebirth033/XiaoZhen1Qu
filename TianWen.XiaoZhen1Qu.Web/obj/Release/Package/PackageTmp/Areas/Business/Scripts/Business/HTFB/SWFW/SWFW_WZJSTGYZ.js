﻿$(document).ready(function () {
    $(".div_radio").bind("click", function () { ValidateRadio("SFSM", "忘记选择是否上门啦"); });
});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择类别啦")) return false;
    if ($("#spanLB").html() !== "网站维护" && $("#spanLB").html() !== "域名注册" && $("#spanLB").html() !== "企业邮箱") {
        if (!ValidateCheck("XL", "忘记选择小类啦")) return false;
    }
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateRadio("SFSM", "忘记选择是否上门啦")

        & ValidateBCMS("BCMS", "忘记填写服务介绍啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
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