$(document).ready(function () {
    $("#span_head_right_zc").bind("click", ToWBZC);
    $("#input_bottom_qx").bind("click", Back);
    $("#input_bottom_dl").bind("click", WBDL);
    $("[data-toggle='tooltip']").tooltip();
    var ZHoptions = {
        title: "<li style='text-align:left;'>请再次输入你的账号</li>",
        animation: true,
        html: true,
        placement: 'right',
        trigger: 'focus'
    }
    $("#inputZH").tooltip(ZHoptions);
});

function ToWBZC() {
    window.open("https://login.sina.com.cn/signup/signup?entry=homepage");
}

function Back() {
    window.location.href = getRootPath() + "/Business/ZHBD/ZHBD?YHID=" + getUrlParam("YHID");
}

function WBDL() {
    if (Validate() === false) return;
}

function ZHCheck() {
    if ($("#inputZH").val().length === 0) {
        $("#inputZH").css("border-color", "#F2272D");
        $("#ZHInfo").css("color", "#F2272D");
        $("#ZHInfo").html("请输入账号");
        return false;
    }
    else {
        $("#inputZH").css("border-color", "#999");
        $("#ZHInfo").html('<img src=' + getRootPath() + '/Areas/Business/Css/images/yes.png />');
        return true;
    }
}

function MMCheck() {
    if ($("#inputMM").val().length === 0) {
        $("#inputMM").css("border-color", "#F2272D");
        $("#MMInfo").css("color", "#F2272D");
        $("#MMInfo").html("请输入账号");
        return false;
    }
    else {
        $("#inputMM").css("border-color", "#999");
        $("#MMInfo").html('<img src=' + getRootPath() + '/Areas/Business/Css/images/yes.png />');
        return true;
    }
}

function Validate() {
    if (!ZHCheck()) return false;
    if (!MMCheck()) return false;
    return true;
}
