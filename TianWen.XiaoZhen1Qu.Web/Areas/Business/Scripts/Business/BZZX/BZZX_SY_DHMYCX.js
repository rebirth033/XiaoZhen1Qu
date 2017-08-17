$(document).ready(function () {
    $("#imgTXYZM").bind("click", QHTXYZM);
    $("#span_content_info_inner_yzm").bind("click", QHTXYZM);
    $("#input_content_info_cx").bind("click", SJCX);
    $("#input_content_info_qd").bind("click", YZZH);
    $("#span_content_info_sjyzm_tip_inner").bind("click", ToSJHSR);
});
//切换图形验证码
function QHTXYZM() {
    $("#imgTXYZM").attr("src", getRootPath() + '/Areas/Business/Aspx/png.aspx?' + Math.random());
}
//手机检查
function SJCheck() {
    if (!ValidateCellPhone($("#input_sjhm").val())) {
        $("#input_sjhm").css("border-color", "#F2272D");
        $("#span_sjhm_info").css("color", "#F2272D");
        $("#span_sjhm_info").html("手机号码格式不正确");
        return false;
    }
    else if ($("#input_sjhm").val().length === 0) {
        $("#input_sjhm").css("border-color", "#F2272D");
        $("#span_sjhm_info").css("color", "#F2272D");
        $("#span_sjhm_info").html("请输入手机号");
        return false;
    }
    else {
        $("#input_sjhm").css("border-color", "#999");
        $("#span_sjhm_info").html('');
        return true;
    }
}
//图形验证检查
function TXYZMCheck() {
    if ($("#input_txyzm").val().length === 0) {
        $("#input_txyzm").css("border-color", "#F2272D");
        $("#span_txyzm_info").css("color", "#F2272D");
        $("#span_txyzm_info").html("请输入图形验证码");
        return false;
    }
    if (!/^[0-9]{4}$/.test($("#input_txyzm").val())) {
        $("#input_txyzm").css("border-color", "#F2272D");
        $("#span_txyzm_info").css("color", "#F2272D");
        $("#span_txyzm_info").html("图形验证码输入格式有误");
        return false;
    }
    else {
        $("#input_txyzm").css("border-color", "#999");
        $("#span_txyzm_info").html('');
        return true;
    }
}
//手机查询前检查
function SJCXValidate() {
    if (!SJCheck()) return false;
    if (!TXYZMCheck()) return false;
    return true;
}
//手机查询
function SJCX() {
    if (!SJCXValidate()) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/BZZX/SJCX",
        dataType: "json",
        data:
        {
            SJ:$("#input_sjhm").val(),
            TXYZM: $("#input_txyzm").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                GetCheckCode();
                
            } else {
                if (xml.Type === 1) {
                    $("#input_sjhm").css("border-color", "#F2272D");
                    $("#span_sjhm_info").css("color", "#F2272D");
                    $("#span_sjhm_info").html(xml.Message);
                }
                if (xml.Type === 2) {
                    $("#input_txyzm").css("border-color", "#F2272D");
                    $("#span_txyzm_info").css("color", "#F2272D");
                    $("#span_txyzm_info").html(xml.Message);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//手机号输入
function ToSJHSR() {
    $("#div_sjhsr").css("display", "block");
    $("#div_htyzm").css("display", "none");
}
//回填验证码
function ToHYTZM() {
    $("#div_sjhsr").css("display", "none");
    $("#div_htyzm").css("display", "block");
}
//获取手机验证码
function GetCheckCode() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: getRootPath() + "/Business/YHJBXX/GetYZM",
        data: {
            SJ: $("#input_sjhm").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                ToHYTZM();
            }
            else {
                alert("验证码发送失败");
            }
        }
    });
}
//验证账户前检查
function YZZHValidate() {
    if (!YZMCheck()) return false;
    return true;
}
//验证码检查
function YZMCheck() {
    if ($("#input_sjyzm").val().length === 0) {
        $("#input_sjyzm").css("border-color", "#F2272D");
        $("#span_sjyzm_info").css("color", "#F2272D");
        $("#span_sjyzm_info").html("请输入手机验证码");
        return false;
    }
    if (!/^[0-9]{6}$/.test($("#input_sjyzm").val())) {
        $("#input_sjyzm").css("border-color", "#F2272D");
        $("#span_sjyzm_info").css("color", "#F2272D");
        $("#span_sjyzm_info").html("手机验证码输入格式有误");
        return false;
    }
    else {
        $("#input_sjyzm").css("border-color", "#999");
        $("#span_sjyzm_info").html('');
        return true;
    }
}
//验证账户
function YZZH() {
    if (!YZZHValidate()) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/BZZX/YZZH",
        dataType: "json",
        data:
        {
            SJ: $("#input_sjhm").val(),
            YZM: $("#input_sjyzm").val(),
        },
        success: function (xml) {
            if (xml.Result === 1) {
                
            } else {
                if (xml.Type === 1) {
                    $("#input_sjyzm").css("border-color", "#F2272D");
                    $("#span_sjyzm_info").css("color", "#F2272D");
                    $("#span_sjyzm_info").html(xml.Message);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}