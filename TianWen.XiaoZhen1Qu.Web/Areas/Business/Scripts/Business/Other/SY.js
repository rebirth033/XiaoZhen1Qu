var curIndex = 1; //当前index
var temp = 0;
$(document).ready(function () {
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_foot").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#5bc0de").css("color", "#ffffff");
    $("#span_fbxx").bind("click", OpenLBXZ);
    $("#li_fwcz").bind("click", OpenFWCZ);

    LoadZXFBXX();
});
//最新发布列表
function ZXFBLB() {
    var e = $("#ul_body_top_right_zxfb")[0];
    var transitionEvent = whichTransitionEvent();
    transitionEvent && e.addEventListener(transitionEvent, function () {
        if (temp === 10) {
            $("#ul_body_top_right_zxfb").css("transform", "translate3d(0px, 0px, 0px)").css("transition-duration", "0ms");
        }
    });
    setInterval(function () {
        if (curIndex < 10) {
            changeTo(curIndex);
            curIndex++;
        } else {
            changeTo(curIndex);
            curIndex = 1;
        }
    }, 2500);
}
//消息切换
function changeTo(num) {
    var height = parseInt(num) * 60;
    temp = num;
    $("#ul_body_top_right_zxfb").css("transform", "translate3d(0px, -" + height + "px, 0px)").css("transition-duration", "500ms");
}
//加载最新发布信息
function LoadZXFBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadZXFBXX",
        dataType: "json",
        data: {
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_main_info").html('');
                for (var i = 0; i < 10; i++) {
                    LoadInfo(xml.list[i]);
                }
                LoadInfo(xml.list[0]);
                ZXFBLB();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载最新发布信息单条
function LoadInfo(obj) {
    var html = "";
    html += ('<li class="li_body_top_right_zxfb">');
    html += ('<img class="img_body_top_right_zxfb" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_body_top_right_zxfb">');
    html += ('<span class="span_body_top_right_zxfb">' + obj.BT + '</span>');
    html += ('<span class="span_body_top_right_zxfb_sj">' + obj.CJSJ.ToString("yyyy-MM-dd hh:mm:ss") + '</span>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_top_right_zxfb").append(html);
}
//类别选择
function OpenLBXZ() {
    window.open(getRootPath() + "/Business/LBXZ/LBXZ");
}
//打开房屋出租
function OpenFWCZ() {
    window.open(getRootPath() + "/Business/FCCX/FCCX_ZZF");
}