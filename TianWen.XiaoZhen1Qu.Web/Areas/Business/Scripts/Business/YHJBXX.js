$(document).ready(function () {
    $("#Reg").bind("click", Save);
    $("#Cancel").bind("click", Close);
    $("[data-toggle='tooltip']").tooltip();
    $("#YHM").bind("blur", YHMCheck);
    $("#YHM").bind("keydown", ColorChange);
    BindToolTip();
});

function BindToolTip() {
    var YHMoptions = {
        title: "·5-15个字符 ·请勿包含身份证银行卡等隐私信息,一旦设置成功无法修改",
        animation: true,
        placement: 'right',
        trigger: 'focus'
    }
    var MMoptions = {
        title: "6-20个字符 只能包含字母、数字以及标点符号（除空格） 至少包含数字和字母",
        animation: true,
        placement: 'right',
        trigger: 'focus'
    }
    $("#YHM").tooltip(YHMoptions);
    $("#MM").tooltip(MMoptions);
}

function YHMCheck() {
    if ($("#YHM").val().length < 5) {
        $("#YHM").css("border-color", "#F2272D");
        $("#YHMInfo").css("color", "#F2272D");
        $("#YHMInfo").html("会员名为5-15个字符，请修改");
    }
    else {
        $("#YHM").css("border-color", "#999");
        $("#YHMInfo").html("");
    }
}

function ColorChange() {
    $("#YHM").css("border-color", "#999");
}

function Save() {
    if (ValidateMM() === false) return;
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
                alert("注册失败");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            _masker.CloseMasker(false, errorThrown);
        }
    });
}

function Close() {

}

//点击切换验证码
function f_refreshtype() {
    var Image1 = document.getElementById("img");
    if (Image1 != null) {
        Image1.src = Image1.src + "?";
    }
}

function ValidateCheckCode() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/YHJBXX/ValidateCheckCode",
        dataType: "json",
        data:
        {
            YZM: $("#YZM").val()
        },
        success: function (xml) {
            if (xml.Result === 1)
                Save();
            else
                alert("验证码有误");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            _masker.CloseMasker(false, errorThrown);
        }
    });
}

function ValidateMM() {
    if ($("#MM").val() !== $("#QRMM").val()) {
        alert("确认密码与密码不匹配");
        $("#QRMM").css("border-color", "#F2272D");
        $("#QRMM").focus();
        return false;
    } else {
        return true;
    }
}