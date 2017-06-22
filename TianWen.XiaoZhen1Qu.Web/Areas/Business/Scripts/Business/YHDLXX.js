var count = 60;

$(document).ready(function () {
    $("#DL").bind("click", DL);
    $("#SJ").bind("blur", SJCheck);
    $("#SJ").bind("keydown", ColorChange);
    $("#btnHQYZM").bind("click", GetCheckCode);
    $("#YZM").bind("blur", ValidateCheckCode);
});

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
        $("#SJInfo").html('<img src=' + getRootPath() + '/Areas/Business/Css/images/yes.png />');
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
        $("#YZMInfo").html('<img src=' + getRootPath() + '/Areas/Business/Css/images/yes.png />');
        return true;
    }
}

function Validate() {
    if (!SJCheck()) return false;
    if (!ValidateCheckCode()) return false;
    return true;
}

function DL() {
    if (Validate() === false) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/YHDLXX/Login",
        dataType: "json",
        data:
        {
            YZM: $("#YZM").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                alert(xml.Message);
            } else {
                $("#YZM").css("border-color", "#F2272D");
                $("#YZMInfo").css("color", "#F2272D");
                $("#YZMInfo").html(xml.Message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            _masker.CloseMasker(false, errorThrown);
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
            url: getRootPath() + "/Business/YHJBXX/GetYZM",
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