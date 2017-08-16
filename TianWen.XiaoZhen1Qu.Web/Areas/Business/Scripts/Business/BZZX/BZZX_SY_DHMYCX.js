$(document).ready(function () {
    $("#imgTXYZM").bind("click", QHTXYZM);
    $("#span_content_info_inner_yzm").bind("click", QHTXYZM);
    $("#input_content_info_cx").bind("click", SJCX);
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
                ToHYTZM();
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