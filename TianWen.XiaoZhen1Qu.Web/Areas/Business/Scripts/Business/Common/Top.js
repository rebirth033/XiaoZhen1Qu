$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 1200) / 2);
    $("#span_dl").bind("click", OpenDL);
    $("#span_zc").bind("click", OpenZC);
    $("#span_grzx").bind("click", OpenGRZX);
    $("#span_bzzx").bind("click", OpenBZZX);
});
//登录
function OpenDL() {
    window.location.href = getRootPath() + "/Business/YHDL/YHDL";
}
//注册
function OpenZC() {
    window.location.href = getRootPath() + "/Business/YHJBXX/YHJBXX";
}
//个人中心
function OpenGRZX() {
    if ($("#input_yhm").val() !== "") {
        window.open(getRootPath() + "/Business/HTGL/HTGL");
    }
    else {
        window.open(getRootPath() + "/Business/YHDL/YHDL?To=HTGL");
    }
}
//帮助中心
function OpenBZZX() {
    window.open(getRootPath() + "/Business/BZZX/BZZX");
}