$(document).ready(function () {
    $("#YHM").bind("blur", YHMCheck);
    $("#TXYZM").bind("blur", ValidateCheckCode);
    $("#btnFirst").bind("click", QRZH);
    $("#btnSecond").bind("click", YZZH);
    $("#spanQRZH").css("color", "#5bc0de");
    $("#emQRZH").css("background", "#5bc0de");
});

function QRZH() {
    if (!QRZHValidate()) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ZHMM/QRZH",
        dataType: "json",
        data:
        {
            Value: $("#YHM").val(),
            TXYZM: $("#TXYZM").val(),
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#spanQRZH").css("color", "#cccccc");
                $("#emQRZH").css("background", "#cccccc");
                $("#spanYZZH").css("color", "#5bc0de");
                $("#emYZZH").css("background", "#5bc0de");
                $("#divFirst").css("display", "none");
                $("#divSecond").css("display", "block");
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
            _masker.CloseMasker(false, errorThrown);
        }

    });
}

function YZZH() {
    $("#spanYZZH").css("color", "#cccccc");
    $("#emYZZH").css("background", "#cccccc");
    $("#spanCZMM").css("color", "#5bc0de");
    $("#emCZMM").css("background", "#5bc0de");
    $("#divSecond").css("display", "none");
    $("#divThird").css("display", "block");
}

function QRZHValidate() {
    if (!YHMCheck()) return false;
    if (!ValidateCheckCode()) return false;
    return true;
}

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

function ValidateCheckCode() {
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