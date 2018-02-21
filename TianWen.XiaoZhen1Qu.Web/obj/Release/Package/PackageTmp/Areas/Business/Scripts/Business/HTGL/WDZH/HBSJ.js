var ysjcount = 60, xsjcount = 60;;
$(document).ready(function () {
    $("#spanJBSJ").css("color", "#bc6ba6");
    $("#spanJBSJ").css("font-weight", "700");
    $("#emJBSJ").css("background-color", "#bc6ba6");
    $("#btnHQYSJYZM").bind("click", { id: "inputYSJ" }, GetYSJCheckCode);
    $("#btnHQXSJYZM").bind("click", { id: "inputXSJ" }, GetXSJCheckCode);
    $("#inputYSJ").val(getUrlParam("SJ"));
    $("#btnFirst").bind("click", QRYSJYZH);
    $("#btnSecond").bind("click", QRXSJYZH);
    $("#btnThird").bind("click", ToGRZL);
});

function QRYSJYZH() {
    if (!YSJYZMCheck()) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ZHMM/YZMQR",
        dataType: "json",
        data:
        {
            YZM: $("#YSJYZM").val(),
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#spanJBSJ").css("color", "#cccccc");
                $("#emJBSJ").css("background", "#cccccc");
                $("#spanBDSJ").css("color", "#bc6ba6");
                $("#emBDSJ").css("background", "#bc6ba6");
                $("#divFirst").css("display", "none");
                $("#divSecond").css("display", "block");
            } else {
                if (xml.Type === 1) {
                    $("#YSJYZM").css("border-color", "#F2272D");
                    $("#YSJYZMInfo").css("color", "#F2272D");
                    $("#YSJYZMInfo").html(xml.Message);
                }
                if (xml.Type === 2) {
                    $("#inputYSJ").css("border-color", "#F2272D");
                    $("#YSJInfo").css("color", "#F2272D");
                    $("#YSJInfo").html(xml.Message);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            
        }
    });
}

function QRXSJYZH() {
    if (!BDSJValidate()) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ZHMM/YZMQR",
        dataType: "json",
        data:
        {
            YZM: $("#XSJYZM").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                UpdateSJ();
            } else {
                if (xml.Type === 1) {
                    $("#YSJYZM").css("border-color", "#F2272D");
                    $("#YSJYZMInfo").css("color", "#F2272D");
                    $("#YSJYZMInfo").html(xml.Message);
                }
                if (xml.Type === 2) {
                    $("#inputYSJ").css("border-color", "#F2272D");
                    $("#YSJInfo").css("color", "#F2272D");
                    $("#YSJInfo").html(xml.Message);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            
        }
    });
}

function UpdateSJ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/GRZL/UpdateSJ",
        dataType: "json",
        data:
        {
            SJ: $("#inputXSJ").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#spanBDSJ").css("color", "#cccccc");
                $("#emBDSJ").css("background", "#cccccc");
                $("#spanWC").css("color", "#bc6ba6");
                $("#emWC").css("background", "#bc6ba6");
                $("#divSecond").css("display", "none");
                $("#divThird").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            
        }
    });
}

function BDSJValidate() {
    if (!XSJCheck($("#inputXSJ").val())) return false;
    if (!XSJYZMCheck()) return false;
    return true;
}

function YSJCheck(SJ) {
    if (!ValidateCellPhone(SJ)) {
        $("#YSJ").css("border-color", "#F2272D");
        $("#YSJInfo").css("color", "#F2272D");
        $("#YSJInfo").html("手机号码格式不正确");
        return false;
    }
    else if (SJ.length === 0) {
        $("#YSJ").css("border-color", "#F2272D");
        $("#YSJInfo").css("color", "#F2272D");
        $("#YSJInfo").html("请输入手机号");
        return false;
    }
    else {
        $("#YSJ").css("border-color", "#999");
        $("#YSJInfo").html('');
        return true;
    }
}

function XSJCheck(SJ) {
    if (!ValidateCellPhone(SJ)) {
        $("#XSJ").css("border-color", "#F2272D");
        $("#XSJInfo").css("color", "#F2272D");
        $("#XSJInfo").html("手机号码格式不正确");
        return false;
    }
    else if (SJ.length === 0) {
        $("#XSJ").css("border-color", "#F2272D");
        $("#XSJInfo").css("color", "#F2272D");
        $("#XSJInfo").html("请输入手机号");
        return false;
    }
    else {
        $("#XSJ").css("border-color", "#999");
        $("#XSJInfo").html('');
        return true;
    }
}

function YSJYZMCheck() {
    if ($("#YSJYZM").val().length === 0) {
        $("#YSJYZM").css("border-color", "#F2272D");
        $("#YSJYZMInfo").css("color", "#F2272D");
        $("#YSJYZMInfo").html("请输入手机验证码");
        return false;
    }
    if (!/^[0-9]{6}$/.test($("#YSJYZM").val())) {
        $("#YSJYZM").css("border-color", "#F2272D");
        $("#YSJYZMInfo").css("color", "#F2272D");
        $("#YSJYZMInfo").html("手机验证码输入格式有误");
        return false;
    }
    else {
        $("#YSJYZM").css("border-color", "#999");
        $("#YSJYZMInfo").html('');
        return true;
    }
}

function XSJYZMCheck() {
    if ($("#XSJYZM").val().length === 0) {
        $("#XSJYZM").css("border-color", "#F2272D");
        $("#XSJYZMInfo").css("color", "#F2272D");
        $("#XSJYZMInfo").html("请输入手机验证码");
        return false;
    }
    if (!/^[0-9]{6}$/.test($("#XSJYZM").val())) {
        $("#XSJYZM").css("border-color", "#F2272D");
        $("#XSJYZMInfo").css("color", "#F2272D");
        $("#XSJYZMInfo").html("手机验证码输入格式有误");
        return false;
    }
    else {
        $("#XSJYZM").css("border-color", "#999");
        $("#XSJYZMInfo").html('');
        return true;
    }
}

function GetYSJCheckCode(obj) {
    if (YSJCheck($("#" + obj.data.id).val())) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: getRootPath() + "/YHJBXX/GetYZM",
            data: {
                SJ: $("#" + obj.data.id).val()
            },
            success: function (xml) {
                if (xml.Result === 1) {
                    GetYSJNumber();
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

function GetXSJCheckCode(obj) {
    if (XSJCheck($("#" + obj.data.id).val())) {
        $.ajax({
            type: "POST",
            dataType: "json",
            url: getRootPath() + "/YHJBXX/GetYZM",
            data: {
                SJ: $("#" + obj.data.id).val()
            },
            success: function (xml) {
                if (xml.Result === 1) {
                    GetXSJNumber();
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

function GetYSJNumber() {
    $("#btnHQYSJYZM").attr("disabled", "disabled");
    $("#btnHQYSJYZM").val(ysjcount + "S后重新获取");
    ysjcount--;
    if (ysjcount > 0) {
        setTimeout(GetYSJNumber, 1000);
    }
    else {
        $("#btnHQYSJYZM").val("获取验证码");
        $("#btnHQYSJYZM").removeAttr("disabled");
        ysjcount = 60;
    }
}

function GetXSJNumber() {
    $("#btnHQXSJYZM").attr("disabled", "disabled");
    $("#btnHQXSJYZM").val(xsjcount + "S后重新获取");
    xsjcount--;
    if (xsjcount > 0) {
        setTimeout(GetXSJNumber, 1000);
    }
    else {
        $("#btnHQXSJYZM").val("获取验证码");
        $("#btnHQXSJYZM").removeAttr("disabled");
        xsjcount = 60;
    }
}

function ToGRZL() {
    window.location.href = getRootPath() + "/GRZL/GRZL";
}