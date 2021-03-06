﻿var count = 60;
$(document).ready(function () {
    $(".div_head").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".em_head_split").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $("#SJDL").bind("click", SJDL);
    $("#MMDL").bind("click", MMDL);
    $("#YHM").bind("blur", YHMCheck);
    $("#YHM").bind("keydown", ColorChange);
    $("#MM").bind("blur", MMCheck);
    $("#MM").bind("keydown", ColorChange);
    $("#SJ").bind("blur", SJCheck);
    $("#SJ").bind("keydown", ColorChange);
    $("#btnHQYZM").bind("click", GetCheckCode);
    $("#YZM").bind("blur", ValidateCheckCode);
    $("#liSJDL").bind("click", Showcellphone);
    $("#liMMDL").bind("click", Showusername);
    $("#aWJMM").attr("href", getRootPath() + "/ZHMM/ZHMM");
    $("#aYHJBXX1").attr("href", getRootPath() + "/YHZC/YHZC");
    $("#aYHJBXX2").attr("href", getRootPath() + "/YHZC/YHZC");
    $("#username input").keydown(function (e) {
        var curKey = e.which;
        if (curKey === 13) MMDL();
    });
    $("#cellphone input").keydown(function (e) {
        var curKey = e.which;
        if (curKey === 13) SJDL();
    });
    $("body").css("height", document.documentElement.clientHeight);
    document.title = "风铃网_登录页";
});

function Showcellphone() {
    $("#cellphone").css("display", "block");
    $("#username").css("display", "none");
}

function Showusername() {
    $("#username").css("display", "block");
    $("#cellphone").css("display", "none");
}

function YHMCheck() {
    if (($("#YHM").val().length < 5 && $("#YHM").val().length > 0) || $("#YHM").val().length > 15) {
        $("#YHM").css("border-color", "#F2272D");
        $("#YHMInfo").css("color", "#F2272D");
        $("#YHMInfo").html("会员名为5-15个字符，请修改");
        return false;
    }
    else if ($("#YHM").val().length === 0) {
        $("#YHM").css("border-color", "#F2272D");
        $("#YHMInfo").css("color", "#F2272D");
        $("#YHMInfo").html("请输入用户名");
        return false;
    }
    else {
        $("#YHM").css("border-color", "#999");
        $("#YHMInfo").html("");

        return true;
    }
}

function MMCheck() {
    if (($("#MM").val().length < 6 && $("#MM").val().length > 0) || $("#MM").val().length > 20) {
        $("#MM").css("border-color", "#F2272D");
        $("#MMInfo").css("color", "#F2272D");
        $("#MMInfo").html("密码为6-20个字符，请修改");
        return false;
    }
    else if ($("#MM").val().length === 0) {
        $("#MM").css("border-color", "#F2272D");
        $("#MMInfo").css("color", "#F2272D");
        $("#MMInfo").html("请输入登录密码");
        return false;
    }
    else {
        $("#MM").css("border-color", "#999");
        $("#MMInfo").html("");
    }
    if ($("#YHM").val() === $("#MM").val()) {
        $("#MM").css("border-color", "#F2272D");
        $("#MMInfo").css("color", "#F2272D");
        $("#MMInfo").html("密码不能和用户名相同，请修改");
        return false;
    }
    else {
        $("#MM").css("border-color", "#999");
    }
    if ($("#MM").val().split(' ').length > 1) {
        $("#MM").css("border-color", "#F2272D");
        $("#MMInfo").css("color", "#F2272D");
        $("#MMInfo").html("密码不能包含空格，请修改");
        return false;
    }
    else {
        $("#MM").css("border-color", "#999");
        $("#MMInfo").html("");
    }

    if (!/^(?![^a-zA-Z]+$)(?!\D+$)/.test($("#MM").val())) {
        $("#MM").css("border-color", "#F2272D");
        $("#MMInfo").css("color", "#F2272D");
        $("#MMInfo").html("密码至少包含数字和字母，请修改");
        return false;
    }
    else {
        $("#MM").css("border-color", "#999");
        $("#MMInfo").html("");
        return true;
    }
}

function SJCheck() {
    if (!ValidateCellPhone($("#SJ").val())) {
        $("#SJ").css("border-color", "#F2272D");
        $("#SJInfo").css("color", "#F2272D");
        $("#SJInfo").html("手机号码格式不正确，请重新输入");
        return false;
    }
    else if ($("#SJ").val().length === 0) {
        $("#SJ").css("border-color", "#F2272D");
        $("#SJInfo").css("color", "#F2272D");
        $("#SJInfo").html("请输入手机号");
        return false;
    }
    else {
        $("#SJ").css("border-color", "#999");
        $("#SJInfo").html("");
        return true;
    }
}

function ValidateCheckCode() {
    if ($("#YZM").val().length === 0) {
        $("#YZM").css("border-color", "#F2272D");
        $("#YZMInfo").css("color", "#F2272D");
        $("#YZMInfo").html("请输入手机验证码");
        return false;
    }
    if (!/^[0-9]{6}$/.test($("#YZM").val())) {
        $("#YZM").css("border-color", "#F2272D");
        $("#YZMInfo").css("color", "#F2272D");
        $("#YZMInfo").html("请输入正确的手机验证码");
        return false;
    }
    else {
        $("#YZM").css("border-color", "#999");
        $("#YZMInfo").html("");
        return true;
    }
}

function SJDLValidate() {
    if (!SJCheck()) return false;
    if (!ValidateCheckCode()) return false;
    return true;
}

function MMDLValidate() {
    if (!YHMCheck()) return false;
    if (!MMCheck()) return false;
    return true;
}

function SJDL() {
    if (SJDLValidate() === false) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/YHDL/SJLogin",
        dataType: "json",
        data:
        {
            SJ: $("#SJ").val(),
            YZM: $("#YZM").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                DLCG();
            } else {
                $("#YZM").css("border-color", "#F2272D");
                $("#YZMInfo").css("color", "#F2272D");
                $("#YZMInfo").html(xml.Message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function MMDL() {
    if (MMDLValidate() === false) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/YHDL/MMLogin",
        dataType: "json",
        data:
        {
            YHM: $("#YHM").val(),
            MM: $("#MM").val(),
            SFZDDL: $("#checkMMSFZDDL")[0].checked
        },
        success: function (xml) {
            if (xml.Result === 1) {
                DLCG();
            } else {
                if (xml.Type === 1) {
                    $("#YHM").css("border-color", "#F2272D");
                    $("#YHMInfo").css("color", "#F2272D");
                    $("#YHMInfo").html(xml.Message);
                }
                if (xml.Type === 2) {
                    $("#MM").css("border-color", "#F2272D");
                    $("#MMInfo").css("color", "#F2272D");
                    $("#MMInfo").html(xml.Message);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function GetCheckCode() {
    if ($("#SJ").val().length === 0) {
        $("#SJ").css("border-color", "#F2272D");
        $("#SJInfo").css("color", "#F2272D");
        $("#SJInfo").html("请输入手机号");
        return;
    }
    if (SJCheck()) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: getRootPath() + "/YHJBXX/GetYZM",
            data: {
                SJ: $("#SJ").val()
            },
            success: function (xml) {
                if (xml.Result === 1) {
                    GetNumber();
                    return true;
                }
                else {
                    alert("验证码发送失败");
                    return false;
                }
            }
        });
    }
}

function GetNumber() {
    $("#btnHQYZM").attr("disabled", "disabled");
    $("#btnHQYZM").val(count + "S后重新获取");
    count--;
    if (count > 0) {
        setTimeout(GetNumber, 1000);
    }
    else {
        $("#btnHQYZM").val("获取验证码");
        $("#btnHQYZM").removeAttr("disabled");
        count = 60;
    }
}

function ColorChange() {
    $(this).css("border-color", "#999");
}

function DLCG() {
    if (getUrlParam("To") === "HTGL")
        window.location.href = getRootPath() + "/HTGL/HTGL";
    else if (getUrlParam("To") === "SY")
        window.location.href = getRootPath() + "/SY/SY";
    else
        window.location.href = window.location.href;
}