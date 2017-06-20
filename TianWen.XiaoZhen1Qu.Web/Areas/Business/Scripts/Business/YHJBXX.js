$(document).ready(function () {
    $("#Reg").bind("click", Register);
    $("#Cancel").bind("click", Close);
    $("[data-toggle='tooltip']").tooltip();
    $("#YHM").bind("blur", YHMCheck);
    $("#YHM").bind("keydown", ColorChange);
    $("#MM").bind("blur", MMCheck);
    $("#MM").bind("keydown", ColorChange);
    $("#QRMM").bind("blur", QRMMCheck);
    $("#QRMM").bind("keydown", ColorChange);
    $("#SJ").bind("blur", SJCheck);
    $("#SJ").bind("keydown", ColorChange);
    $("#HQYZM").bind("click", GetCheckCode);
    BindToolTip();
    //DragValidate($(".dragEle"), $(".dragTipInner"));
});

function BindToolTip() {
    var YHMoptions = {
        title: "<li style='text-align:left;height:20px'>·5-15个字符,推荐使用中文</li><li style='text-align:left'>·请勿包含身份证银行卡等隐私信息,一旦设置成功无法修改</li>",
        animation: true,
        html: true,
        placement: 'right',
        trigger: 'focus'
    }
    var MMoptions = {
        title: "<li style='text-align:left;'>·6-20个字符,密码不能和用户名重复</li><li style='text-align:left;'>·只能包含字母、数字以及标点符号（除空格）</li><li style='text-align:left;'>·至少包含数字和字母</li>",
        animation: true,
        html: true,
        placement: 'right',
        trigger: 'focus'
    }
    var QRMMoptions = {
        title: "<li style='text-align:left;'>·请再次输入你的密码</li>",
        animation: true,
        html: true,
        placement: 'right',
        trigger: 'focus'
    }
    $("#YHM").tooltip(YHMoptions);
    $("#MM").tooltip(MMoptions);
    $("#QRMM").tooltip(QRMMoptions);
}

function YHMCheck() {
    ValidateYHM();
    if (($("#YHM").val().length < 5 && $("#YHM").val().length > 0) || $("#YHM").val().length > 15) {
        $("#YHM").css("border-color", "#F2272D");
        $("#YHMInfo").css("color", "#F2272D");
        $("#YHMInfo").html("会员名为5-15个字符，请修改");
        return false;
    }
    else if ($("#YHM").val().length === 0) {
        $("#YHM").css("border-color", "#999");
        $("#YHMInfo").html("");
        return false;
    }
    else {
        $("#YHM").css("border-color", "#999");
        $("#YHMInfo").html('<img src=' + getRootPath() + '/Areas/Business/Css/images/yes.png />');
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
        $("#MM").css("border-color", "#999");
        $("#MMInfo").html("");
        return false;
    }
    else {
        $("#MM").css("border-color", "#999");
        $("#MMInfo").html('<img src=' + getRootPath() + '/Areas/Business/Css/images/yes.png />');
    }
    if ($("#YHM").val() === $("#MM").val()) {
        $("#MM").css("border-color", "#F2272D");
        $("#MMInfo").css("color", "#F2272D");
        $("#MMInfo").html("密码不能和用户名相同，请修改");
        return false;
    }
    else {
        $("#MM").css("border-color", "#999");
        $("#MMInfo").html('<img src=' + getRootPath() + '/Areas/Business/Css/images/yes.png />');
    }
    if ($("#MM").val().split(' ').length > 1) {
        $("#MM").css("border-color", "#F2272D");
        $("#MMInfo").css("color", "#F2272D");
        $("#MMInfo").html("密码不能包含空格，请修改");
        return false;
    }
    else {
        $("#MM").css("border-color", "#999");
        $("#MMInfo").html('<img src=' + getRootPath() + '/Areas/Business/Css/images/yes.png />');
    }

    if (!/^(?![^a-zA-Z]+$)(?!\D+$)/.test($("#MM").val())) {
        $("#MM").css("border-color", "#F2272D");
        $("#MMInfo").css("color", "#F2272D");
        $("#MMInfo").html("密码至少包含数字和字母，请修改");
        return false;
    }
    else {
        $("#MM").css("border-color", "#999");
        $("#MMInfo").html('<img src=' + getRootPath() + '/Areas/Business/Css/images/yes.png />');
        return true;
    }
}

function QRMMCheck() {
    if (($("#QRMM").val().length < 6 && $("#QRMM").val().length > 0) || $("#QRMM").val().length > 20) {
        $("#QRMM").css("border-color", "#F2272D");
        $("#QRMMInfo").css("color", "#F2272D");
        $("#QRMMInfo").html("确认密码为6-20个字符，请修改");
        return false;
    }
    else if ($("#QRMM").val().length === 0) {
        $("#QRMM").css("border-color", "#999");
        $("#QRMMInfo").html("");
        return false;
    }
    else {
        $("#QRMM").css("border-color", "#999");
        $("#QRMMInfo").html('<img src=' + getRootPath() + '/Areas/Business/Css/images/yes.png />');
    }
    if ($("#QRMM").val() !== $("#MM").val()) {
        $("#QRMM").css("border-color", "#F2272D");
        $("#QRMMInfo").css("color", "#F2272D");
        $("#QRMMInfo").html("两次输入的密码不一致，请重新输入");
        return false;
    }
    else if ($("#QRMM").val().length === 0) {
        $("#QRMM").css("border-color", "#999");
        $("#QRMMInfo").html("");
        return false;
    }
    else {
        $("#QRMM").css("border-color", "#999");
        $("#QRMMInfo").html('<img src=' + getRootPath() + '/Areas/Business/Css/images/yes.png />');
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
        $("#SJ").css("border-color", "#999");
        $("#SJInfo").html("");
        return false;
    }
    else {
        $("#SJ").css("border-color", "#999");
        $("#SJInfo").html('<img src=' + getRootPath() + '/Areas/Business/Css/images/yes.png />');
        return true;
    }
}

function ColorChange() {
    $(this).css("border-color", "#999");
}

function Validate() {
    if (YHMCheck() && MMCheck() && QRMMCheck() && SJCheck())
        return true;
    else {
        if ($("#YHM").val().length === 0) {
            $("#YHM").css("border-color", "#F2272D");
            $("#YHMInfo").css("color", "#F2272D");
            $("#YHMInfo").html("请输入用户名");
        }
        if ($("#MM").val().length === 0) {
            $("#MM").css("border-color", "#F2272D");
            $("#MMInfo").css("color", "#F2272D");
            $("#MMInfo").html("请输入登录密码");
        }
        if ($("#QRMM").val().length === 0) {
            $("#QRMM").css("border-color", "#F2272D");
            $("#QRMMInfo").css("color", "#F2272D");
            $("#QRMMInfo").html("请再次输入登录密码");
        }
        if ($("#SJ").val().length === 0) {
            $("#SJ").css("border-color", "#F2272D");
            $("#SJInfo").css("color", "#F2272D");
            $("#SJInfo").html("请输入手机号");
        }
        return false;
    }
}

function Register() {
    if (Validate() === false) return;
    var jsonObj = new JsonDB("divReg");
    var obj = jsonObj.GetJsonObject();
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/YHJBXX/Register",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj)
        },
        success: function (xml) {
            if (xml.Result === 1) {
                alert("注册成功");
            } else {
                alert("注册失败:" + xml.Message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            _masker.CloseMasker(false, errorThrown);
        }
    });
}

function Close() {

}

function DragValidate(dargEle, msgEle) {
    var dragging = false;//滑块拖动标识
    var iX;
    dargEle.mousedown(function (e) {
        dragging = true;
        iX = e.clientX; //获取初始坐标
    });
    $(document).mousemove(function (e) {
        if (dragging) {
            var e = e || window.event;
            var oX = e.clientX - iX;
            if (oX < 40) {
                return false;
            };
            if (oX >= 260) {//容器宽度+10
                oX = 260;
                return false;
            };
            $(".dragEle").css("left", oX + "px");
            $(".dragTip").css("width", oX + "px");
            return false;
        };
    });
    $(document).mouseup(function (e) {
        var e = e || window.event;
        var oX = e.clientX - iX;
        if (oX < 260) {
            $(".dragEle").css("left", "0");
            $(".dragTip").css("width", "0");
            msgEle.text("拖动滑块到最右边,完成验证");
        } else {
            if ($(".dragTip").width() > 40) {
                dargEle.attr("validate", "true").unbind("mousedown");
                msgEle.text("验证成功!");
            }
        };
        dragging = false;
    });
};

function ValidateYHM() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/YHJBXX/ValidateYHM",
        dataType: "json",
        data:{
            YHM: $("#YHM").val()
        },
        success: function (xml) {
            if (xml.Result === 0) {
                $("#YHM").css("border-color", "#F2272D");
                $("#YHMInfo").css("color", "#F2272D");
                $("#YHMInfo").html("会员名已存在，请修改");
            }
            else {
                $("#YHM").css("border-color", "#999");
                $("#YHMInfo").html('<img src=' + getRootPath() + '/Areas/Business/Css/images/yes.png />');
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function GetCheckCode() {
    //if ($('#SJ').length === 11) {
        $.ajax({
            type: "get",
            dataType: "json",
            url: getRootPath() + "/Business/YHJBXX/GetYHM",
            data: {
                SJ: $("#SJ").val(),
                clienttime: new Date().getTime()
            },
            success: function (xml) {
                if (xml.result === 1) {
                    alert("验证码发送成功");
                    GetNumber();
                    return true;
                }
                else {
                    alert("验证码发送失败");
                    return false;
                }
            }
        });
   // }
}
var count = 5;
function GetNumber() {
    $("#btnCode").attr("disabled", "disabled");
    $("#btnCode").val(count + "秒之后点击获取");
    count--;
    if (count > 0) {
        setTimeout(GetNumber, 1000);
    }
    else {
        $("#btnCode").val("点击获取验证码");
        $("#btnCode").attr("disabled", "");
        count = 5;
    }
}

function ValidateCheckCode() {
    
}