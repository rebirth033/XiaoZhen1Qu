$(document).ready(function () {
    $("#span_head_right_zc").bind("click", ToWBZC);
    $("#input_bottom_qx").bind("click", Back);
    $("#input_bottom_dl").bind("click", WBDL);
    $('#inputZH').bind("focus", { id: "inputZH" }, HideTip);
    $('#inputMM').bind("focus", { id: "inputMM" }, HideTip);
    BindToolTip();

});
//进入微博注册页面
function ToWBZC() {
    window.open("https://login.sina.com.cn/signup/signup?entry=homepage");
}
//返回
function Back() {
    window.location.href = getRootPath() + "/Business/ZHBD/ZHBD?YHID=" + getUrlParam("YHID");
}
//微博登录
function WBDL() {
    if (Validate() === false) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/GRZL/UpdateWB",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID"),
            WB: $('#inputZH').val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                alert("微博绑定成功");
                Back();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//账号检查
function ZHCheck() {
    if ($("#inputZH").val().length === 0) {
        $('#inputZH').tooltip('show');
        return false;
    }
    else {
        return true;
    }
}
//密码检查
function MMCheck() {
    if ($("#inputMM").val().length === 0) {
        $('#inputMM').tooltip('show');
        return false;
    }
    else {
        return true;
    }
}
//登录验证
function Validate() {
    if (!ZHCheck()) return false;
    if (!MMCheck()) return false;
    return true;
}
//绑定tooltip
function BindToolTip() {
    var ZHoptions = {
        title: "<li class='li_div_body'>请输入你的微博账号</li>",
        animation: true,
        html: true,
        placement: 'right',
        trigger: 'manual'
    }
    $("#inputZH").tooltip(ZHoptions);
    var MMoptions = {
        title: "<li class='li_div_body'>请输入你的密码</li>",
        animation: true,
        html: true,
        placement: 'right',
        trigger: 'manual'
    }
    $("#inputMM").tooltip(MMoptions);
}
//隐藏tooltip
function HideTip(obj) {
    $("#" + obj.data.id).tooltip('hide');
}