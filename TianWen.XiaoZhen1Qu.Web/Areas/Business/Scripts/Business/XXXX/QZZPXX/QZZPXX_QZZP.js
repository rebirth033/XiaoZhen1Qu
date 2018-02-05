var right = 0;
$(document).ready(function () {

});
//加载默认
function LoadDefault() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZPXX/LoadQZZPXX",
        dataType: "json",
        data:
        {
            TYPE: "QZZPXX_QZZP",
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadJBXX(xml.list[0]);
                LoadXQ(xml.list[0], xml.BCMSString);
                //LoadCNXH("QZZPXX_QZZP");
                LoadGRXX(xml.grxxlist[0]);
                //LoadJJRTJFY("QZZPXX_QZZP");
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
    html += ('<p class="p_div_body_left_head_bt">' + obj.BT + '</p>');
    html += ('<p class="p_div_body_left_head_ll">' + obj.ZXGXSJ.ToString('yyyy年MM月dd日') + '  ' + obj.LLCS + '次浏览 <span id="span_div_body_left_head_jb" class="span_div_body_left_head_jb">举报</span><span class="span_div_body_left_head_split">|</span><span id="span_div_body_left_head_sc" onclick="SCXX(\'' + obj.JCXXID + '\')" class="span_div_body_left_head_sc">收藏</span></p>');
    html += ('</div>');
    html += ('<div class="div_body_left_body">');
    html += ('<div class="div_body_left_body_right">');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">职位名称：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.ZWMC + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">每月薪资：</span>');
    html += ('<span class="span_body_left_body_right_right" style="color:#bc6ba6;">' + GetJG(obj.MYXZ.replace('元', ''), '元') + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">公司名称：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.LXR + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">学历要求：</span>');
    html += ('<span class="span_body_left_body_right_right">不限</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">工作年限：</span>');
    html += ('<span class="span_body_left_body_right_right">不限</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">招聘人数：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.ZPRS + '人</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">工作地址：</span>');
    html += ('<span class="span_body_left_body_right_right">' + '［' + obj.QY + ' - ' + obj.DD + '］' + obj.JTDZ + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">联系电话：</span>');
    html += ('<span class="span_body_left_body_right_right_lxdh">' + obj.LXDH.substr(0, 4) + '****' + '</span>');
    html += ('<span class="span_body_left_body_right_right_ckwzdh" onclick="ShowWZDH()">完整电话</span>');
    html += ('<span class="span_body_left_body_right_wzdh"><span class="span_body_left_body_right_wzdh_lxdh"><i class="i_body_left_body_right_wzdh_lxdh"></i>' + obj.LXDH + '</span><span class="span_body_left_body_right_wzdh_ts">联系时请一定说明在信息小镇上看到的哈，谢谢^_^</span><i class="i_body_left_body_right_wzdh_close" onclick="HideWZDH()">×</i></span>');
    html += ('</p>');
    html += ('</div>');
    html += ('</div>');
    $("#div_body_left").append(html);
    HandlerTPXX();
}
//加载详情
function LoadXQ(obj, BCMSString) {
    var html = "";
    html += ('<div class="div_body_left_body_xq">');
    html += ('<p class="p_body_left_body_xq">职位描述</p>');

    html += ('<div class="div_body_left_body_xq_xx">');
    html += ('<div id="div_body_left_body_xq_xx_bcms" class="div_body_left_body_xq_xx_right fyms div_body_left_body_xq_xx_bcms">');
    html += (BCMSString);
    html += ('</div>');
    html += ('</div>');

    html += ('<div id = "zk" class="div_body_left_body_xq_xx"></div>');

    html += ('</div>');

    $("#div_body_left").append(html);

    if (parseInt(RTrimStr($("#div_body_left_body_xq_xx_bcms").css("height"), "px")) > 300) {
        $("#div_body_left_body_xq_xx_bcms").css("height", "300px").css("overflow", "hidden");
        $("#zk").append('<div id="div_body_left_body_xq_zk_bcms" onclick="ToggleBCMS()" class="div_body_left_body_xq_zk_bcms">展开内容<i id="i_body_left_body_xq_zk_bcms" class="i_body_left_body_xq_zk_bcms"></i></div>');
    }
}
//加载猜你喜欢
function LoadCNXH(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZPCX/LoadQZZPXX",
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
                LoadJPTJ("QZZPXX_QZZP");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载猜你喜欢单条信息
function LoadCNXHInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'QZZPXX_QZZP\',\'' + obj.ID + '\')" class="li_body_left_body_cnxh">');
    html += ('<img class="img_li_body_left_body_cnxh" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_left_body_cnxh_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_body_cnxh_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('</li>');
    return html;
}
//加载精品推荐
function LoadJPTJ(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZPCX/LoadQZZPXX",
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
    html += ('<li onclick="OpenXXXX(\'QZZPXX_QZZP\',\'' + obj.ID + '\')" class="li_body_left_body_jptj">');
    html += ('<img class="img_li_body_left_body_jptj" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_left_body_jptj_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_body_jptj_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('<p class="p_li_body_left_body_jptj_jg">' + GetJG(obj.JG, '元') + '</p>');
    html += ('</li>');
    return html;
}
//加载该经纪人推荐
function LoadJJRTJFY(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZPCX/LoadQZZPXX",
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
                html += ('<p class="p_body_right_jjrtj">该经纪人推荐</p>');
                html += ('<ul id="ul_body_right_jjrtj" class="ul_body_right_jjrtj">');
                for (var i = 0; i < xml.list.length; i++) {
                    html += LoadJJRTJFYInfo(xml.list[i]);
                }
                html += ('</ul>');
                html += ('</div>');
                $("#div_body_right").append(html);
                $(".li_body_right_jjrtj").bind("mouseover", function () { $(this).find(".p_li_body_right_jjrtj_xq").css("color", "#bc6ba6"); });
                $(".li_body_right_jjrtj").bind("mouseleave", function () { $(this).find(".p_li_body_right_jjrtj_xq").css("color", "#333333"); });
                LoadXGLM();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载该经纪人推荐单条信息
function LoadJJRTJFYInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'QZZPXX_QZZP\',\'' + obj.ID + '\')" class="li_body_right_jjrtj">');
    html += ('<img class="img_li_body_right_jjrtj" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_li_body_right_jjrtj">');
    html += ('<p class="p_li_body_right_jjrtj_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_jjrtj_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('<p class="p_li_body_right_jjrtj_jg">' + GetJG(obj.JG, '元') + '</p>');
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