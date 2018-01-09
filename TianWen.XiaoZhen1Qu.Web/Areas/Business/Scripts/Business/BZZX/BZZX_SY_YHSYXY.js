$(document).ready(function () {
    $(".span_body_nav").bind("click", GoToTip);
    $("#title").html("信息小镇_用户使用协议");
});

function GoToTip() {
    var len = document.getElementById("div_body_nav_title_" + this.id).offsetTop;//获取div层到页面顶部的高度 
    $("html,body").stop().animate({ scrollTop: len }, 300, "swing", function () { });
}