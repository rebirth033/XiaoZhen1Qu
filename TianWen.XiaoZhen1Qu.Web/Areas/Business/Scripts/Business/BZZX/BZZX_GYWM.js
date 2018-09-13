$(document).ready(function () {
    $("#span_head_nav_info_sy").css("background-color", "rgba(101,101,101,0.9)");
    $("#span_head_nav_info_sy").bind("click", ToSY);
    $("#span_head_nav_info_gsjj").bind("click", ToGSJJ);
    $("#span_head_nav_info_qywh").bind("click", ToQYWH);
    $("#span_head_nav_info_hzgy").bind("click", ToHZGY);
    $("#span_head_nav_info_rczp").bind("click", ToRCZP);
});

//帮助中心_首页
function ToSY() {
    $(".span_head_nav_info").css("background-color", "rgba(51,51,51,0.9)");
    $("#span_head_nav_info_sy").css("background-color", "rgba(101,101,101,0.9)");
    $("#iframeright").attr("src", getRootPath() + "/BZZX/BZZX_GYWM_SY");
}

//帮助中心_公司简介
function ToGSJJ() {
    $(".span_head_nav_info").css("background-color", "rgba(51,51,51,0.9)");
    $("#span_head_nav_info_gsjj").css("background-color", "rgba(101,101,101,0.9)");
    $("#iframeright").attr("src", getRootPath() + "/BZZX/BZZX_GYWM_GSJJ");
}

//帮助中心_企业文化
function ToQYWH() {
    $(".span_head_nav_info").css("background-color", "rgba(51,51,51,0.9)");
    $("#span_head_nav_info_qywh").css("background-color", "rgba(101,101,101,0.9)");
    $("#iframeright").attr("src", getRootPath() + "/BZZX/BZZX_GYWM_QYWH");
}

//帮助中心_合作共赢
function ToHZGY() {
    $(".span_head_nav_info").css("background-color", "rgba(51,51,51,0.9)");
    $("#span_head_nav_info_hzgy").css("background-color", "rgba(101,101,101,0.9)");
    $("#iframeright").attr("src", getRootPath() + "/BZZX/BZZX_GYWM_HZGY");
}

//帮助中心_人才招聘
function ToRCZP() {
    $(".span_head_nav_info").css("background-color", "rgba(51,51,51,0.9)");
    $("#span_head_nav_info_rczp").css("background-color", "rgba(101,101,101,0.9)");
    $("#iframeright").attr("src", getRootPath() + "/BZZX/BZZX_GYWM_RCZP");
}