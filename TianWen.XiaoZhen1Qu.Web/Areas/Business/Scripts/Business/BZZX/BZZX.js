$(document).ready(function () {
    $("#span_head_nav_info_sy").bind("click", ToSY);
    $("#span_head_nav_info_lxkf").bind("click", ToLXKF);
    $("#span_head_nav_info_wzjy").bind("click", ToWZJY);
    ToWZJY();
});

//帮助中心_首页
function ToSY() {
    $(".div_body").css("height", "690px");
    $("#iframeright").attr("src", getRootPath() + "/Business/BZZX/BZZX_SY?YHID=" + getUrlParam("YHID"));
}

//帮助中心_联系客服
function ToLXKF() {
    $(".div_body").css("height", "760px");
    $("#iframeright").attr("src", getRootPath() + "/Business/BZZX/BZZX_LXKF?YHID=" + getUrlParam("YHID"));
}

//帮助中心_网站建议
function ToWZJY() {
    $(".div_body").css("height", "430px");
    $("#iframeright").attr("src", getRootPath() + "/Business/BZZX/BZZX_WZJY?YHID=" + getUrlParam("YHID"));
}