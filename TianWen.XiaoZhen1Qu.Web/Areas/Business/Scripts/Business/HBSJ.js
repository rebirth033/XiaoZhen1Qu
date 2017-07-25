var count = 60;

$(document).ready(function () {
    $("#spanJBSJ").css("color", "#5bc0de");
    $("#spanJBSJ").css("font-weight", "700");
    $("#emJBSJ").css("background-color", "#5bc0de");
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
        url: getRootPath() + "/Business/ZHMM/YZMQR",
        dataType: "json",
        data:
        {
            YZM: $("#YSJYZM").val(),
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#spanJBSJ").css("color", "#cccccc");
                $("#emJBSJ").css("background", "#cccccc");
                $("#spanBDSJ").css("color", "#5bc0de");
                $("#emBDSJ").css("background", "#5bc0de");
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
            _masker.CloseMasker(false, errorThrown);
        }
    });
}

function QRXSJYZH() {
    if (!BDSJValidate()) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ZHMM/YZMQR",
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
            _masker.CloseMasker(false, errorThrown);
        }
    });
}

function UpdateSJ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/GRZL/UpdateSJ",
        dataType: "json",
        data:
        {
            YHID:getUrlParam("YHID"),
            SJ: $("#inputXSJ").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#spanBDSJ").css("color", "#cccccc");
                $("#emBDSJ").css("background", "#cccccc");
                $("#spanWC").css("color", "#5bc0de");
                $("#emWC").css("background", "#5bc0de");
                $("#divSecond").css("display", "none");
                $("#divThird").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            _masker.CloseMasker(false, errorThrown);
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
            url: getRootPath() + "/Business/YHJBXX/GetYZM",
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
            url: getRootPath() + "/Business/YHJBXX/GetYZM",
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
    $("#btnHQYSJYZM").val(count + "S后重新获取");
    count--;
    if (count > 0) {
        setTimeout(GetYSJNumber, 1000);
    }
    else {
        $("#btnHQYSJYZM").val("获取验证码");
        $("#btnHQYSJYZM").removeAttr("disabled");
        count = 60;
    }
}

function GetXSJNumber() {
    $("#btnHQXSJYZM").attr("disabled", "disabled");
    $("#btnHQXSJYZM").val(count + "S后重新获取");
    count--;
    if (count > 0) {
        setTimeout(GetXSJNumber, 1000);
    }
    else {
        $("#btnHQXSJYZM").val("获取验证码");
        $("#btnHQXSJYZM").removeAttr("disabled");
        count = 60;
    }
}

function ToGRZL() {
    window.location.href = getRootPath() + "/Business/GRZL/GRZL?YHID=" + getUrlParam("YHID");
}