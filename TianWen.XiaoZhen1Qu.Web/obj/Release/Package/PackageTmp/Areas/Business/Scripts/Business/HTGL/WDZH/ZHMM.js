var count = 60;
var dqyhm = "";
$(document).ready(function () {
    //$("#YHM").bind("blur", YHMCheck);
    //$("#TXYZM").bind("blur", TXYZMCheck);
    $(".div_head_inner").css("margin-left", (document.documentElement.clientWidth - 600) / 2);
    $(".div_content").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $(".div_content").css("height", (document.documentElement.clientHeight - 230));
    $("#imgTXYZM").bind("click", QHTXYZM);
    $("#TXYZM").bind("focus", TXYZMTip);
    $("#btnHQYZM").bind("click", GetCheckCode);
    $("#btnFirst").bind("click", QRZH);
    $("#btnSecond").bind("click", YZZH);
    $("#btnThird").bind("click", CZMM);
    $("#spanQRZH").css("color", "#bc6ba6");
    $("#emQRZH").css("background", "#bc6ba6");
    document.title = "风铃网_找回密码";
});
//确认账户
function QRZH() {
    if (!QRZHValidate()) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ZHMM/QRZH",
        dataType: "json",
        data:
        {
            Value: $("#YHM").val(),
            TXYZM: $("#TXYZM").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#spanQRZH").css("color", "#cccccc");
                $("#emQRZH").css("background", "#cccccc");
                $("#spanYZZH").css("color", "#bc6ba6");
                $("#emYZZH").css("background", "#bc6ba6");
                $("#divFirst").css("display", "none");
                $("#divSecond").css("display", "block");
                dqyhm = $("#YHM").val();
            } else {
                if (xml.Type === 1) {
                    $("#TXYZM").css("border-color", "#F2272D");
                    $("#TXYZMInfo").css("color", "#F2272D");
                    $("#TXYZMInfo").html(xml.Message);
                }
                if (xml.Type === 2) {
                    $("#YHM").css("border-color", "#F2272D");
                    $("#YHMInfo").css("color", "#F2272D");
                    $("#YHMInfo").html(xml.Message);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//验证账户
function YZZH() {
    if (!YZZHValidate()) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ZHMM/YZZH",
        dataType: "json",
        data:
        {
            DQYHM: dqyhm,
            SJ: $("#SJ").val(),
            YZM: $("#YZM").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#spanYZZH").css("color", "#cccccc");
                $("#emYZZH").css("background", "#cccccc");
                $("#spanCZMM").css("color", "#bc6ba6");
                $("#emCZMM").css("background", "#bc6ba6");
                $("#divSecond").css("display", "none");
                $("#divThird").css("display", "block");
            } else {
                if (xml.Type === 1) {
                    $("#YZM").css("border-color", "#F2272D");
                    $("#YZMInfo").css("color", "#F2272D");
                    $("#YZMInfo").html(xml.Message);
                }
                if (xml.Type === 2) {
                    $("#SJ").css("border-color", "#F2272D");
                    $("#SJInfo").css("color", "#F2272D");
                    $("#SJInfo").html(xml.Message);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//重置密码
function CZMM() {
    if (!CZMMValidate()) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ZHMM/CZMM",
        dataType: "json",
        data:
        {
            MM: $("#MM").val(),
            QRMM: $("#QRMM").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.wxc.xcConfirm(xml.Message, window.wxc.xcConfirm.typeEnum.success, {
                    onOk: function (v) {
                        ToYHDL();
                    },
                    onClose: function (v) {
                        ToYHDL();
                    }
                });
            } else {
                window.wxc.xcConfirm(xml.Message, window.wxc.xcConfirm.typeEnum.error, {
                    onOk: function (v) {
                        //ToMMSZ();
                    },
                    onClose: function (v) {
                        //ToMMSZ();
                    }
                });
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//确认账户前检查
function QRZHValidate() {
    if (!YHMCheck()) return false;
    if (!TXYZMCheck()) return false;
    return true;
}
//验证账户前检查
function YZZHValidate() {
    if (!SJCheck()) return false;
    if (!YZMCheck()) return false;
    return true;
}
//重置密码前检查
function CZMMValidate() {
    if (!MMCheck()) return false;
    if (!QRMMCheck()) return false;
    return true;
}
//用户名检查
function YHMCheck() {
    if ($("#YHM").val().length === 0) {
        $("#YHM").css("border-color", "#F2272D");
        $("#YHMInfo").css("color", "#F2272D");
        $("#YHMInfo").html("请输入用户名或手机号");
        return false;
    }
    else {
        $("#YHM").css("border-color", "#999");
        $("#YHMInfo").html('');
        return true;
    }
}
//图形验证检查
function TXYZMCheck() {
    if ($("#TXYZM").val().length === 0) {
        $("#TXYZM").css("border-color", "#F2272D");
        $("#TXYZMInfo").css("color", "#F2272D");
        $("#TXYZMInfo").html("请输入图形验证码");
        return false;
    }
    if (!/^[0-9]{4}$/.test($("#TXYZM").val())) {
        $("#TXYZM").css("border-color", "#F2272D");
        $("#TXYZMInfo").css("color", "#F2272D");
        $("#TXYZMInfo").html("图形验证码输入格式有误");
        return false;
    }
    else {
        $("#TXYZM").css("border-color", "#999");
        $("#TXYZMInfo").html('');
        return true;
    }
}
//手机检查
function SJCheck() {
    if (!ValidateCellPhone($("#SJ").val())) {
        $("#SJ").css("border-color", "#F2272D");
        $("#SJInfo").css("color", "#F2272D");
        $("#SJInfo").html("手机号码格式不正确");
        return false;
    }
    else if ($("#SJ").val().length === 0) {
        $("#SJ").css("border-color", "#F2272D");
        $("#SJInfo").css("color", "#F2272D");
        $("#SJInfo").html("请输入手机号");
        return false;
    }
    else {
        $.ajax({
            type: "POST",
            url: getRootPath() + "/ZHMM/YZSJ",
            dataType: "json",
            data:
            {
                DQYHM: dqyhm,
                SJ: $("#SJ").val()
            },
            success: function (xml) {
                if (xml.Result === 1) {
                    $("#SJ").css("border-color", "#999");
                    $("#SJInfo").html('');
                    return true;
                } else {
                    $("#SJ").css("border-color", "#F2272D");
                    $("#SJInfo").css("color", "#F2272D");
                    $("#SJInfo").html(xml.Message);
                    return false;
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

            }
        });
    }
}
//验证码检查
function YZMCheck() {
    if ($("#YZM").val().length === 0) {
        $("#YZM").css("border-color", "#F2272D");
        $("#YZMInfo").css("color", "#F2272D");
        $("#YZMInfo").html("请输入手机验证码");
        return false;
    }
    if (!/^[0-9]{6}$/.test($("#YZM").val())) {
        $("#YZM").css("border-color", "#F2272D");
        $("#YZMInfo").css("color", "#F2272D");
        $("#YZMInfo").html("手机验证码输入格式有误");
        return false;
    }
    else {
        $("#YZM").css("border-color", "#999");
        $("#YZMInfo").html('');
        return true;
    }
}
//密码检查
function MMCheck() {
    if (($("#MM").val().length < 6 && $("#MM").val().length > 0) || $("#MM").val().length > 20) {
        $("#MM").css("border-color", "#F2272D");
        $("#MMInfo").css("color", "#F2272D");
        $("#MMInfo").html("密码为6-20个字符");
        return false;
    }
    if ($("#MM").val().length === 0) {
        $("#MM").css("border-color", "#F2272D");
        $("#MMInfo").css("color", "#F2272D");
        $("#MMInfo").html("请输入密码");
        return false;
    }
    if ($("#MM").val().split(' ').length > 1) {
        $("#MM").css("border-color", "#F2272D");
        $("#MMInfo").css("color", "#F2272D");
        $("#MMInfo").html("密码不能包含空格");
        return false;
    }
    if (!/^(?![^a-zA-Z]+$)(?!\D+$)/.test($("#MM").val())) {
        $("#MM").css("border-color", "#F2272D");
        $("#MMInfo").css("color", "#F2272D");
        $("#MMInfo").html("密码至少包含数字和字母");
        return false;
    }
    else {
        $("#MM").css("border-color", "#999");
        $("#MMInfo").html('');
        return true;
    }
}
//确认密码检查
function QRMMCheck() {
    if (($("#QRMM").val().length < 6 && $("#QRMM").val().length > 0) || $("#QRMM").val().length > 20) {
        $("#QRMM").css("border-color", "#F2272D");
        $("#QRMMInfo").css("color", "#F2272D");
        $("#QRMMInfo").html("确认密码为6-20个字符");
        return false;
    }
    if ($("#QRMM").val().length === 0) {
        $("#QRMM").css("border-color", "#F2272D");
        $("#QRMMInfo").css("color", "#F2272D");
        $("#QRMMInfo").html("请再次输入密码");
        return false;
    }
    if ($("#QRMM").val() !== $("#MM").val()) {
        $("#QRMM").css("border-color", "#F2272D");
        $("#QRMMInfo").css("color", "#F2272D");
        $("#QRMMInfo").html("两次输入的密码不一致");
        return false;
    }
    else {
        $("#QRMM").css("border-color", "#999");
        $("#QRMMInfo").html('');
        return true;
    }
}
//获取验证码
function GetCheckCode() {
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
//获取秒数
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
//图形验证提示
function TXYZMTip() {
    $("#TXYZM").css("border-color", "#999");
    $("#TXYZMInfo").css("color", "#999");
    $("#TXYZMInfo").html('验证码看不清?<span onclick="QHTXYZM()" style="cursor:pointer;text-decoration:none;color:#bc6ba6">换一下?</span>');
}
//切换图形验证码
function QHTXYZM() {
    $("#imgTXYZM")[0].src = getRootPath() + '/Areas/Business/Aspx/png.aspx?' + Math.random();
}