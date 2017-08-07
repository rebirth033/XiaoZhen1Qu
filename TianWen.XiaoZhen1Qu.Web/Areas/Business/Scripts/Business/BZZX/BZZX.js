$(document).ready(function () {
    $("#span_head_nav_info_sy").bind("click", ToSY);
    $("#span_head_nav_info_cjwt").bind("click", ToCJWT);
    $("#span_head_nav_info_lxkf").bind("click", ToLXKF);
    $("#span_head_nav_info_wzjy").bind("click", ToWZJY);
    ToSY();
});

//帮助中心_首页
function ToSY() {
    $("#iframeright").attr("src", getRootPath() + "/Business/BZZX/BZZX_SY?YHID=" + getUrlParam("YHID"));
}

//帮助中心_常见问题
function ToCJWT() {
    $("#iframeright").attr("src", getRootPath() + "/Business/BZZX/BZZX_CJWT?YHID=" + getUrlParam("YHID"));
}

//帮助中心_联系客服
function ToLXKF() {
    $("#iframeright").attr("src", getRootPath() + "/Business/BZZX/BZZX_LXKF?YHID=" + getUrlParam("YHID"));
}

//帮助中心_网站建议
function ToWZJY() {
    $("#iframeright").attr("src", getRootPath() + "/Business/BZZX/BZZX_WZJY?YHID=" + getUrlParam("YHID"));
}