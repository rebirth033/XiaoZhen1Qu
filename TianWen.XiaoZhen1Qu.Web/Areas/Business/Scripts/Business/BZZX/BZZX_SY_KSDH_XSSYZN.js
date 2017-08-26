$(document).ready(function () {
    $(".span_body_nav").bind("click", GoToTip);
    $(".div_fhdb").bind("click", GoToTop);
    $(".div_fhdb").bind("mouseover", ActiveFHDB);
    $(".div_fhdb").bind("mouseleave", UnActiveFHDB);
});

function GoToTip() {
    var len = document.getElementById("div_body_nav_title_" + this.id).offsetTop;//获取div层到页面顶部的高度 
    $("html,body").stop().animate({ scrollTop: len }, 300, "swing", function () { });
}

function GoToTop() {
    $("html,body").stop().animate({ scrollTop: "0" }, 300, "swing", function () { });
}

function ActiveFHDB() {
    $(this).find("span").each(function () {
        if ($(this).attr("class") === "span_fhdb_img") {
            $(this).css("background-image", "url(" + getRootPath() + "/Areas/Business/Css/images/BZZX/bzzx_sy_xxbsc_fhdb_hover.png)");
        }
        if ($(this).attr("class") === "span_fhdb") {
            $(this).css("color", "#ef6100");
        }
    });
}

function UnActiveFHDB() {
    $(this).find("span").each(function () {
        if ($(this).attr("class") === "span_fhdb_img") {
            $(this).css("background-image", "url(" + getRootPath() + "/Areas/Business/Css/images/BZZX/bzzx_sy_xxbsc_fhdb.png)");
        }
        if ($(this).attr("class") === "span_fhdb") {
            $(this).css("color", "#31b0d5");
        }
    });
}
