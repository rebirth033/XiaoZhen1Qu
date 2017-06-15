$(document).ready(function() {
    $("#Reg").bind("click", Save);
    $("#Cancel").bind("click", Close);
    $("[data-toggle='tooltip']").tooltip();
});

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
        $("#QRMM").css("border-color", "#a94442");
        $("#QRMM").focus();
        return false;
    } else {
        return true;
    }
}