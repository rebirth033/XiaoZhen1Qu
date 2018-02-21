$(document).ready(function () {
    LoadGRZL();
    $("#input_bottom_wcxg").bind("click", WCXG);
    $("#span_head_wjmm").bind("click", ToZHMM);
});
//加载个人资料
function LoadGRZL() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/GRZL/GetGRZL",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID")
        },
        success: function (xml) {
            $("#inputYHM").val(xml.YHJBXX.YHM);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//完成修改
function WCXG() {
    if (Validate() === false) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/GRZL/MMCZ",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID"),
            JMM: $("#inputJMM").val(),
            XMM: $("#inputXMM").val()
        },
        success: function (xml) {
            if (xml.Result === 0 && xml.Type === 2) {
                $("#inputJMM").css("border-color", "#F2272D");
                $("#JMMInfo").css("color", "#F2272D");
                $("#JMMInfo").html(xml.Message);
            } else {
                window.wxc.xcConfirm("密码修改成功", window.wxc.xcConfirm.typeEnum.success, {
                    onOk: function (v) {
                        window.location.reload();
                    },
                    onClose: function (v) {
                        window.location.reload();
                    }
                });
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//密码修改验证
function Validate() {
    if (!JMMCheck()) return false;
    if (!XMMCheck()) return false
    if (!QRMMCheck()) return false;
    return true;
}
//旧密码检查
function JMMCheck() {
    if (($("#inputJMM").val().length < 6 && $("#inputJMM").val().length > 0) || $("#inputJMM").val().length > 20) {
        $("#inputJMM").css("border-color", "#F2272D");
        $("#JMMInfo").css("color", "#F2272D");
        $("#JMMInfo").html("旧密码为6-20个字符");
        return false;
    }
    if ($("#inputJMM").val().length === 0) {
        $("#inputJMM").css("border-color", "#F2272D");
        $("#JMMInfo").css("color", "#F2272D");
        $("#JMMInfo").html("请输入旧密码");
        return false;
    }
    if ($("#inputJMM").val().split(' ').length > 1) {
        $("#inputJMM").css("border-color", "#F2272D");
        $("#JMMInfo").css("color", "#F2272D");
        $("#JMMInfo").html("旧密码不能包含空格");
        return false;
    }
    if (!/^(?![^a-zA-Z]+$)(?!\D+$)/.test($("#inputJMM").val())) {
        $("#inputJMM").css("border-color", "#F2272D");
        $("#JMMInfo").css("color", "#F2272D");
        $("#JMMInfo").html("旧密码至少包含数字和字母");
        return false;
    }
    else {
        $("#inputJMM").css("border-color", "#999");
        $("#JMMInfo").html('');
        return true;
    }
}
//新密码检查
function XMMCheck() {
    if (($("#inputXMM").val().length < 6 && $("#inputXMM").val().length > 0) || $("#inputXMM").val().length > 20) {
        $("#inputXMM").css("border-color", "#F2272D");
        $("#XMMInfo").css("color", "#F2272D");
        $("#XMMInfo").html("新密码为6-20个字符");
        return false;
    }
    if ($("#inputXMM").val().length === 0) {
        $("#inputXMM").css("border-color", "#F2272D");
        $("#XMMInfo").css("color", "#F2272D");
        $("#XMMInfo").html("请输入新密码");
        return false;
    }
    if ($("#inputXMM").val().split(' ').length > 1) {
        $("#inputXMM").css("border-color", "#F2272D");
        $("#XMMInfo").css("color", "#F2272D");
        $("#XMMInfo").html("新密码不能包含空格");
        return false;
    }
    if (!/^(?![^a-zA-Z]+$)(?!\D+$)/.test($("#inputXMM").val())) {
        $("#inputXMM").css("border-color", "#F2272D");
        $("#XMMInfo").css("color", "#F2272D");
        $("#XMMInfo").html("新密码至少包含数字和字母");
        return false;
    }
    else {
        $("#inputXMM").css("border-color", "#999");
        $("#XMMInfo").html('');
        return true;
    }
}
//确认密码检查
function QRMMCheck() {
    if (($("#inputQRMM").val().length < 6 && $("#inputQRMM").val().length > 0) || $("#inputQRMM").val().length > 20) {
        $("#inputQRMM").css("border-color", "#F2272D");
        $("#QRMMInfo").css("color", "#F2272D");
        $("#QRMMInfo").html("确认密码为6-20个字符");
        return false;
    }
    if ($("#inputQRMM").val().length === 0) {
        $("#inputQRMM").css("border-color", "#F2272D");
        $("#QRMMInfo").css("color", "#F2272D");
        $("#QRMMInfo").html("请输入确认密码");
        return false;
    }
    if ($("#inputQRMM").val() !== $("#inputXMM").val()) {
        $("#inputQRMM").css("border-color", "#F2272D");
        $("#QRMMInfo").css("color", "#F2272D");
        $("#QRMMInfo").html("两次输入的密码不一致");
        return false;
    }
    else {
        $("#inputQRMM").css("border-color", "#999");
        $("#QRMMInfo").html('');
        return true;
    }
}
//调整到找回密码
function ToZHMM() {
    window.location.href = getRootPath() + "/ZHMM/ZHMM?YHID=" + getUrlParam("YHID");
}