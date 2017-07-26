﻿$(document).ready(function () {
    $("#spanTXYX").css("color", "#5bc0de");
    $("#spanTXYX").css("font-weight", "700");
    $("#emTXYX").css("background-color", "#5bc0de");
    $("#btnFirst").bind("click", SendEmail);
    $("#span_yx").bind("click", ToQQYX);
});

function EmailValidate() {
    if (!EmailCheck()) return false;
    return true;
}

function EmailCheck() {
    if (!ValidateEmail($("#inputYX").val())) {
        $("#inputYX").css("border-color", "#F2272D");
        $("#YXInfo").css("color", "#F2272D");
        $("#YXInfo").html("电子邮件格式不正确，请重新输入");
        return false;
    }
    else if ($("#inputYX").val().length === 0) {
        $("#inputYX").css("border-color", "#F2272D");
        $("#YXInfo").css("color", "#F2272D");
        $("#YXInfo").html("请输入您的邮箱");
        return false;
    }
    else {
        $("#inputYX").css("border-color", "#999");
        $("#YXInfo").html('<img src=' + getRootPath() + '/Areas/Business/Css/images/yes.png />');
        return true;
    }
}

function SendEmail() {
    if (EmailValidate() === false) return;
    $("#spanTXYX").css("color", "#cccccc");
    $("#spanTXYX").css("font-weight", "700");
    $("#emTXYX").css("background", "#cccccc");
    $("#divFirst").css("display", "none");
    $("#divSecond").css("display", "block");
}

function ToQQYX() {
    window.open("http://mail.qq.com");
}