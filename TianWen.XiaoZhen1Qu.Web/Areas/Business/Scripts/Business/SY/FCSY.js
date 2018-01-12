$(document).ready(function () {
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_foot").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#bc6ba6").css("color", "#ffffff");
    $("#div_yhm").bind("click", ShowWDXX);
    //LoadDefault();
});

//打开查询列表
function OpenCXLB(lbid, lburl, condition) {
    if (condition !== "null" && condition !== null)
        window.open(getRootPath() + "/Business" + lburl + "?LBID=" + lbid + "&" + condition);
    else
        window.open(getRootPath() + "/Business" + lburl + "?LBID=" + lbid);
}