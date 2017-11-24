﻿$(document).ready(function () {

});
//加载默认
function LoadDefault() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFWXX/LoadSWFWXX",
        dataType: "json",
        data:
        {
            TYPE: "SWFWXX_QMFSSM",
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadJBXX(xml.list[0]);
                LoadXQ(xml.list[0], xml.BCMSString);
                LoadCNXH("SWFWXX_QMFSSM");
                LoadGRXX(xml.grxxlist[0]);
                LoadJJRTJFY("SWFWXX_QMFSSM");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载基本信息
function LoadJBXX(obj) {
    var html = "";
    html += ('<div class="div_body_left_head">');
    html += ('<p class="p_div_body_left_head_bt">' + TruncStr(obj.BT, 35) + '</p>');
    html += ('<p class="p_div_body_left_head_ll">11月5日 22:36 3次浏览 </p>');
    html += ('</div>');
    html += ('<div class="div_body_left_body">');
    html += ('<div class="div_body_left_body_left">');
    html += ('<img id="img_body_left_body_left_show" class="img_body_left_body_left_show" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<span onclick="LeftImg()" class="div_body_left_body_left_list_an" style="margin-right: 10px;"><</span>');
    html += ('<div class="div_body_left_body_left_list">');
    html += ('<ul id="ul_body_left_body_left_list" class="ul_body_left_body_left_list">');
    for (var i = 0; i < obj.PHOTOS.length; i++) {
        html += ('<li class="li_body_left_body_left_list_tp">');
        html += ('<img class="img_body_left_body_left_list_tp" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[i].PHOTONAME + "?j=" + Math.random() + '" />');
        html += ('<div class="div_img_body_left_body_left_list_tp"></div>');
        html += ('</li>');
    }
    html += ('</ul>');
    html += ('</div>');
    html += ('<span onclick="RightImg(' + obj.PHOTOS.length + ')" class="div_body_left_body_left_list_an">></span>');
    html += ('</div>');
    html += ('<div class="div_body_left_body_right">');
    html += ('<p class="p_body_left_body_right_first">');
    html += ('<span class="span_body_left_body_right_zj">' + obj.JG + '</span><span class="span_body_left_body_right_zjdw">元</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">类别：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.LB + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">小类：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.XL + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">新旧程度：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.XJ + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">区域：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.QY + '-' + obj.DD + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right_lxdh">');
    html += ('<img class="img_body_left_body_right_lxdh" src="' + getRootPath() + '/Areas/Business/Css/images/lxdh.png" />' + obj.LXDH);
    html += ('</p>');
    html += ('</div>');
    html += ('</div>');
    $("#div_body_left").append(html);
    HandlerTPXX();
}
//处理图片信息
function HandlerTPXX() {
    $(".div_img_body_left_body_left_list_tp:eq(0)").each(function () { $(this).css("background-color", "rgba(0,0,0,0)") });
    $(".li_body_left_body_left_list_tp").bind("click", function () {
        $("#img_body_left_body_left_show").attr("src", $(this).find("img")[0].src);
        $(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0.5)");
        $(this).find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0)");
    });
}
var right = 0;
//图片左侧切换
function LeftImg() {
    if (right > 0) {
        right -= 1;
        $("#ul_body_left_body_left_list").css("transform", "translate3d(-" + right * 100 + "px, 0px, 0px)").css("transition-duration", "500ms");
        $("#ul_body_left_body_left_list").find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0.5)");
        $("#ul_body_left_body_left_list").find(".li_body_left_body_left_list_tp:eq(" + right + ")").find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0)");
        $("#img_body_left_body_left_show").attr("src", $("#ul_body_left_body_left_list").find(".li_body_left_body_left_list_tp:eq(" + right + ")").find("img")[0].src);
    }
}
//图片右侧切换
function RightImg(length) {
    if (right < length - 1) {
        right += 1;
        $("#ul_body_left_body_left_list").css("transform", "translate3d(-" + right * 100 + "px, 0px, 0px)").css("transition-duration", "500ms");
        $("#ul_body_left_body_left_list").find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0.5)");
        $("#ul_body_left_body_left_list").find(".li_body_left_body_left_list_tp:eq(" + right + ")").find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0)");
        $("#img_body_left_body_left_show").attr("src", $("#ul_body_left_body_left_list").find(".li_body_left_body_left_list_tp:eq(" + right + ")").find("img")[0].src);
    }
}
//加载宠物详情
function LoadXQ(obj, BCMSString) {
    var html = "";
    html += ('<div class="div_body_left_body_xq">');
    html += ('<p class="p_body_left_body_xq">宠物详情</p>');

    html += ('<div class="div_body_left_body_xq_xx">');
    html += ('<div class="div_body_left_body_xq_xx_left">宠物描述</div>');
    html += ('<div class="div_body_left_body_xq_xx_right fyms" style="padding-left:32px;">');
    html += (BCMSString);
    html += ('</div>');
    html += ('</div>');
    html += ('<div id="div_body_left_body_xq_xx" class="div_body_left_body_xq_xx" style="overflow:hidden;">');
    html += ('<ul class="ul_body_left_body_xq_xx">');
    for (var i = 0; i < obj.PHOTOS.length; i++) {
        html += ('<li class="li_body_left_body_xq_xx">');
        html += ('<img class="img_body_left_body_xq_xx" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[i].PHOTONAME + "?j=" + Math.random() + '" />');
        html += ('</li>');
    }
    html += ('</ul>');
    html += ('</div>');

    html += ('<div id="div_body_left_body_xq_zk" onclick="ToggleImg(' + obj.PHOTOS.length + ')" class="div_body_left_body_xq_zk">展开更多图片 共（' + obj.PHOTOS.length + '）张</div>');
    html += ('</div>');
    $("#div_body_left").append(html);
    if (obj.PHOTOS.length > 4) {
        $("#div_body_left_body_xq_xx").css("height", "530px");
        $("#div_body_left_body_xq_zk").css("display", "block");
    }
}
//伸缩图片
function ToggleImg(length) {
    if ($("#div_body_left_body_xq_zk").html().indexOf("展开") !== -1) {
        $("#div_body_left_body_xq_xx").css("overflow", "visible").css("height", "auto");
        $("#div_body_left_body_xq_zk").html("收起更多图片 共（" + length + "）张");
    } else {
        $("#div_body_left_body_xq_xx").css("overflow", "hidden").css("height", "530px");
        $("#div_body_left_body_xq_zk").html("展开更多图片 共（" + length + "）张");
    }
}
//加载猜你喜欢
function LoadCNXH(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFWCX/LoadSWFWXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1",
            PageSize: 4,
            PageIndex: 1
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += ('<div class="div_body_left_body_cnxh">');
                html += ('<p class="p_body_left_body_cnxh">猜你喜欢</p>');
                html += ('<ul id="ul_body_left_body_cnxh" class="ul_body_left_body_cnxh">');
                for (var i = 0; i < xml.list.length; i++) {
                    html += LoadCNXHInfo(xml.list[i]);
                }
                html += ('</ul>');
                html += ('</div>');
                $("#div_body_left").append(html);
                LoadJPTJ("CW");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载猜你喜欢单条信息
function LoadCNXHInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'SWFWXX\',\'' + obj.ID + '\')" class="li_body_left_body_cnxh">');
    html += ('<img class="img_li_body_left_body_cnxh" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_left_body_cnxh_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_body_cnxh_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('<p class="p_li_body_left_body_cnxh_jg">' + obj.JG + '元</p>');
    html += ('</li>');
    return html;
}
//加载精品推荐
function LoadJPTJ(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFWCX/LoadSWFWXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1",
            PageSize: 4,
            PageIndex: 1
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += ('<div class="div_body_left_body_jptj">');
                html += ('<p class="p_body_left_body_jptj">精品推荐</p>');
                html += ('<ul id="ul_body_left_body_jptj" class="ul_body_left_body_jptj">');
                for (var i = 0; i < xml.list.length; i++) {
                    html += LoadJPTJInfo(xml.list[i]);
                }
                html += ('</ul>');
                html += ('</div>');
                $("#div_body_left").append(html);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载精品推荐单条信息
function LoadJPTJInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'SWFWXX\',\'' + obj.ID + '\')" class="li_body_left_body_jptj">');
    html += ('<img class="img_li_body_left_body_jptj" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_left_body_jptj_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_body_jptj_cs">' + obj.QY + '-' + obj.DD + '平</p>');
    html += ('<p class="p_li_body_left_body_jptj_jg">' + obj.JG + '元</p>');
    html += ('</li>');
    return html;
}
//加载该经纪人推荐房源
function LoadJJRTJFY(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFWCX/LoadSWFWXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1",
            PageSize: 5,
            PageIndex: 1
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += ('<div class="div_body_right_jjrtj">');
                html += ('<p class="p_body_right_jjrtj">该经纪人推荐房源</p>');
                html += ('<ul id="ul_body_right_jjrtj" class="ul_body_right_jjrtj">');
                for (var i = 0; i < xml.list.length; i++) {
                    html += LoadJJRTJFYInfo(xml.list[i]);
                }
                html += ('</ul>');
                html += ('</div>');
                $("#div_body_right").append(html);
                $(".li_body_right_jjrtj").bind("mouseover", function () { $(this).find(".p_li_body_right_jjrtj_xq").css("color", "#5bc0de"); });
                $(".li_body_right_jjrtj").bind("mouseleave", function () { $(this).find(".p_li_body_right_jjrtj_xq").css("color", "#333333"); });
                LoadXGLM();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载该经纪人推荐房源单条信息
function LoadJJRTJFYInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'SWFWXX\',\'' + obj.ID + '\')" class="li_body_right_jjrtj">');
    html += ('<img class="img_li_body_right_jjrtj" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_li_body_right_jjrtj">');
    html += ('<p class="p_li_body_right_jjrtj_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_jjrtj_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('<p class="p_li_body_right_jjrtj_jg">' + obj.JG + '元</p>');
    html += ('</div>');
    html += ('</li>');
    return html;
}
//加载相关类目
function LoadXGLM() {
    var list = "福州日租/短租,福州二手房出售,福州新房出售,福州租房/出租,福州找室友,福州写字楼出租".split(",");
    var html = "";
    html += ('<div class="div_body_right_xglm">');
    html += ('<p class="p_body_right_xglm">相关类目</p>');
    html += ('<ul id="ul_body_right_xglm" class="ul_body_right_xglm">');
    for (var i = 0; i < list.length; i++) {
        html += '<li class="li_body_right_xglm">' + list[i] + '</li>';
    }
    html += ('<em class="em_body_right_xglm"></em>');
    html += ('</ul>');
    list = "福州酒店宾馆,福州医药保健,福州电子通讯,福州服饰鞋包,福州汽修美容,福州家居建材".split(",");
    html += ('<ul id="ul_body_right_xglm" class="ul_body_right_xglm">');
    for (var i = 0; i < list.length; i++) {
        html += '<li class="li_body_right_xglm">' + list[i] + '</li>';
    }
    html += ('</ul>');
    html += ('</div>');
    $("#div_body_right").append(html);
}