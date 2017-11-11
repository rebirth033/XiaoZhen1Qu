﻿$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    LoadDefault();
    GetHeadNav();
});
//获取头部导航
function GetHeadNav() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadSY_ML",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += ('<ul class="ul_nav">');
                html += ('<li class="li_nav_font">信息小镇</li>');
                html += ('<li class="li_nav_split">></li>');
                html += ('<li class="li_nav_font">' + xml.xzq + '房产</li>');
                html += ('<li class="li_nav_split">></li>');
                for (var i = 0; i < xml.list.length; i++) {
                    if (xml.list[i].LBID == getUrlParam("LBID")) {
                        html += ('<li class="li_nav_font">' + xml.xzq + xml.list[i].LBNAME + '</li>');
                        $("#li_body_head_first").html(xml.xzq + xml.list[i].LBNAME + "出租");
                    }
                }
                html += ('</ul>');
                $("#divNav").html(html);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载个人信息
function LoadGRXX(grxx) {
    var html = "";
    html += ('<div class="div_body_right_grxx">');
    html += ('<img class="img_div_body_right_grxx" src="http://localhost/infotownlet/Areas/Business/Photos/2718ced3-996d-427d-925d-a08e127cc0b8/GRZL/TX.jpg?j=0.3236891655295969" />');
    html += ('<p class="p_div_body_right_yhm">' + grxx.YHM + '</p>');
    html += ('<p class="p_div_body_right_zcsj">注册时间：' + grxx.SQRQ.ToString("yyyy年MM月dd日") + '</p>');
    html += ('<div class="div_div_body_right_yyzz">');
    html += ('<div class="div_div_div_body_right_yyzz"><i class="i_div_div_body_right_yyzz_sfz"></i><span>身份证</span></div>');
    html += ('<div class="div_div_div_body_right_yyzz"><i class="i_div_div_body_right_yyzz_yyzz"></i><span>营业执照</span></div>');
    html += ('<div class="div_div_div_body_right_yyzz"><i class="i_div_div_body_right_yyzz_zmxy"></i><span>芝麻信用</span></div>');
    html += ('</div>');
    html += ('<div class="div_div_body_right_ckxy">查看TA的信用记录</div>');
    html += ('</div>');
    $("#div_body_right").append(html);
}