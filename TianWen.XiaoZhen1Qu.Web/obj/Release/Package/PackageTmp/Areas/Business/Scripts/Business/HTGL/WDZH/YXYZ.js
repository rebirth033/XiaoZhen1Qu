$(document).ready(function () {
    $("#spanTXYX").css("color", "#bc6ba6");
    $("#spanTXYX").css("font-weight", "700");
    $("#emTXYX").css("background-color", "#bc6ba6");
    $("#btnFirst").bind("click", SendEmail);
    $("#span_yx").bind("click", ToQQYX);
});

function EmailValidate() {
    if (!EmailCheck()) return false;
    return true;
}
//邮箱验证
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
//发送邮件
function SendEmail() {
    if (EmailValidate() === false) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/GRZL/SendEmail",
        dataType: "json",
        data:
        {
            YX: $("#inputYX").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#spanTXYX").css("color", "#cccccc");
                $("#spanTXYX").css("font-weight", "normal");
                $("#emTXYX").css("background", "#cccccc");
                $("#spanCSYJ").css("color", "#bc6ba6");
                $("#spanCSYJ").css("font-weight", "700");
                $("#emCSYJ").css("background", "#bc6ba6");
                $("#divFirst").css("display", "none");
                $("#divSecond").css("display", "block");
                $("#span_yx").html($("#inputYX").val());
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            
        }
    });
}

function ToQQYX() {
    window.open("http://mail.qq.com");
}