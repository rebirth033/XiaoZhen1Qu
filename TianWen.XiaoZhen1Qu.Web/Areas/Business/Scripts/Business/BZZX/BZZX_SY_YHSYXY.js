$(document).ready(function () {
    $(".span_body_nav").bind("click", GoToTip);
    $("#title").html("信息小镇_用户使用协议");
    $("#div_rtop").bind("mouseover", TopShow);
    $("#div_rtop").bind("mouseleave", TopHide);
});

function GoToTip() {
    var len = document.getElementById("div_body_nav_title_" + this.id).offsetTop;//获取div层到页面顶部的高度 
    $("html,body").stop().animate({ scrollTop: len }, 300, "swing", function () { });
}

function GoToTip() {
    var len = document.getElementById("div_body_nav_title_" + this.id).offsetTop;//获取div层到页面顶部的高度 
    $("html,body").stop().animate({ scrollTop: len }, 300, "swing", function () { });
}

function GoToTop() {
    $("html,body").stop().animate({ scrollTop: "0" }, 300, "swing", function () { });
}

//拖动滚动条或滚动鼠标轮
window.onscroll = function () {
    if (document.body.scrollTop || document.documentElement.scrollTop > 0) {
        $("#div_rtop").css("display", "block");
    } else {
        $("#div_rtop").css("display", "none");
    }
}

function TopShow() {
    $("#div_rtop").css("background-image", "url(" + getRootPath() + "/Areas/Business/Css/images/BZZX/bzzx_fhdb_hz.png)");
}

function TopHide() {
    $("#div_rtop").css("background-image", "url(" + getRootPath() + "/Areas/Business/Css/images/BZZX/bzzx_fhdb.png)");
}