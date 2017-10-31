var curIndex = 0; //当前index
$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_head").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#5bc0de").css("color", "#ffffff");
    setInterval(function () {
        if (curIndex < 20 - 1) {
            curIndex++;
        } else {
            curIndex = 0;
        }
        //调用变换处理函数
        changeTo(curIndex);
    }, 2500);
});

function changeTo(num) {
    $(".li_body_top_right_zxfb_" + num).animate({ left: "-" + 200 + "px" }, 500);
    $(".li_body_top_right_zxfb_" + num).animate({ left: "-" + 200 + "px" }, 500);
}
