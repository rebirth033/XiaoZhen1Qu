var curIndex = 1; //当前index
var temp = 0;
$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_head").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#5bc0de").css("color", "#ffffff");


    var e = $("#ul_body_top_right_zxfb")[0];
    var transitionEvent = whichTransitionEvent();
    transitionEvent && e.addEventListener(transitionEvent, function () {
        if (temp === 3) {
            $("#ul_body_top_right_zxfb").css("transform", "translate3d(0px, 0px, 0px)").css("transition-duration", "0ms");
        }
    });

    setInterval(function () {
        if (curIndex < 3) {
            changeTo(curIndex);
            curIndex++;
        } else {
            changeTo(curIndex);
            curIndex = 1;
        }
        //changeTo(curIndex);
    }, 2500);
});

function changeTo(num) {
    var height = parseInt(num) * 60;
    temp = num;
    $("#ul_body_top_right_zxfb").css("transform", "translate3d(0px, -" + height + "px, 0px)").css("transition-duration", "500ms");
}

function whichTransitionEvent() {
    var t;
    var el = document.createElement('fakeelement');
    var transitions = {
        'transition': 'transitionend',
        'OTransition': 'oTransitionEnd',
        'MozTransition': 'transitionend',
        'WebkitTransition': 'webkitTransitionEnd',
        'MsTransition': 'msTransitionEnd'
    }

    for (t in transitions) {
        if (el.style[t] !== undefined) {
            return transitions[t];
        }
    }
}
