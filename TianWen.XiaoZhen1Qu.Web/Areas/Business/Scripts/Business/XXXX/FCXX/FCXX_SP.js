var right = 0;
$(document).ready(function () {

});
//加载默认
function LoadDefault() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCXX/LoadFCXX",
        dataType: "json",
        data:
        {
            TYPE: "FCXX_SP",
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadJBXX(xml.list[0]);
                LoadXQ(xml.list[0], xml.BCMSString);
                LoadCNXH("FCXX_SP", xml.list[0].GQ);
                LoadGRXX(xml.grxxlist[0]);
                LoadJJRTJFY("FCXX_SP", xml.list[0].GQ);
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
    html += ('<span class="span_body_left_body_right_zj">' + (obj.GQ === "出租" ? GetJG(obj.ZJ, obj.ZJDW) : GetJG(obj.SJ, obj.ZJDW)) + '</span>');
    html += ('</p>');
    if (obj.GQ === "出租") {
        html += ('<p class="p_body_left_body_right">');
        html += ('<span class="span_body_left_body_right_left">押付方式：</span>');
        html += ('<span class="span_body_left_body_right_right">' + obj.YFFS + '</span>');
        html += ('</p>');
    }
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">商铺类型：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.SPLX + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">经营行业：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.JYHY + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">经营状态：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.JYZT + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">面积：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.MJ + '平米</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">具体地址：</span>');
    html += ('<span class="span_body_left_body_right_right">' + '[' + obj.QY + '-' + obj.DD + '] ' + obj.JTDZ + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">联系电话：</span>');
    html += ('<span class="span_body_left_body_right_right span_body_left_body_right_right_lxdh">' + obj.LXDH.substr(0, 7) + '****' + '</span>');
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
    html += ('<p class="p_body_left_body_xq">商铺详情</p>');
    html += ('<div class="div_body_left_body_xq_xx">');
    html += ('<div class="div_body_left_body_xq_xx_left">详细信息</div>');
    html += ('<div class="div_body_left_body_xq_xx_right">');
    html += ('<p><span class="span_body_left_body_xq_xx_right">面宽：</span><span>' + (obj.MK === null ? "暂无数据" : obj.MK) + '米</span><span class="span_body_left_body_xq_xx_right">进深：</span><span>' + (obj.JS === null ? "暂无数据" : obj.JS) + '米</span></p>');
    html += ('<p><span class="span_body_left_body_xq_xx_right">层高：</span><span>' + (obj.CG === null ? "暂无数据" : obj.CG) + '米</span><span class="span_body_left_body_xq_xx_right">楼层：</span><span>' + (obj.C === null ? "暂无数据" : obj.C) + '</span></p>');
    html += ('<p><span class="span_body_left_body_xq_xx_right">电费：</span><span>' + (obj.DF === undefined ? "暂无数据" : obj.DF) + '元/度</span><span class="span_body_left_body_xq_xx_right">水费：</span><span>' + (obj.SF === undefined ? "暂无数据" : obj.SF) + '元/吨</span></p>');
    html += ('<p><span class="span_body_left_body_xq_xx_right">物业费：</span><span>' + (obj.WYF === undefined ? "暂无数据" : obj.WYF) + '元/平米/月</span></p>');
    html += ('</div>');
    html += ('</div>');
    html += ('<div class="div_body_left_body_xq_xx">');
    html += ('<div class="div_body_left_body_xq_xx_left">房源描述</div>');
    html += ('<div class="div_body_left_body_xq_xx_right fyms">');
    html += (BCMSString);
    html += ('</div>');
    html += ('</div>');
    html += ('<div id="div_body_left_body_xq_zk_bcms" onclick="ToggleBCMS()" class="div_body_left_body_xq_zk_bcms">展开内容<i id="i_body_left_body_xq_zk_bcms" class="i_body_left_body_xq_zk_bcms"></i></div>');
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
        $("#div_body_left_body_xq_xx").css("height", "710px");
        $("#div_body_left_body_xq_zk").css("display", "block");
    }
}
//加载猜你喜欢
function LoadCNXH(TYPE, GQ) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCCX/LoadFCXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1,GQ:" + GQ,
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
                    html += LoadCNXHInfo(xml.list[i], GQ);
                }
                html += ('</ul>');
                html += ('</div>');
                $("#div_body_left").append(html);
                LoadJPTJ("FCXX_SP", GQ);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载猜你喜欢单条信息
function LoadCNXHInfo(obj, GQ) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'FCXX_SP\',\'' + obj.ID + '\')" class="li_body_left_body_cnxh">');
    html += ('<img class="img_li_body_left_body_cnxh" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_left_body_cnxh_xq">' + TruncStr((obj.QY + ' / ' + obj.DD + ' / ' + obj.JTDZ), 15) + '</p>');
    html += ('<p class="p_li_body_left_body_cnxh_cs">' + obj.MJ + '平米</p>');
    html += ('<p class="p_li_body_left_body_cnxh_jg">' + (GQ === "出租" ? obj.ZJ : obj.SJ) + obj.ZJDW + '</p>');
    html += ('</li>');
    return html;
}
//加载精品推荐
function LoadJPTJ(TYPE, GQ) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCCX/LoadFCXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1,GQ:" + GQ,
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
                    html += LoadJPTJInfo(xml.list[i], GQ);
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
function LoadJPTJInfo(obj, GQ) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'FCXX_SP\',\'' + obj.ID + '\')" class="li_body_left_body_jptj">');
    html += ('<img class="img_li_body_left_body_jptj" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_left_body_jptj_xq">' + TruncStr((obj.QY + ' / ' + obj.DD + ' / ' + obj.JTDZ), 15) + '</p>');
    html += ('<p class="p_li_body_left_body_jptj_cs">' + obj.MJ + '平米</p>');
    html += ('<p class="p_li_body_left_body_jptj_jg">' + (GQ === "出租" ? obj.ZJ : obj.SJ) + obj.ZJDW + '</p>');
    html += ('</li>');
    return html;
}
//加载该经纪人推荐
function LoadJJRTJFY(TYPE, GQ) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCCX/LoadFCXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1,GQ:" + GQ,
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
                    html += LoadJJRTJFYInfo(xml.list[i], GQ);
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
function LoadJJRTJFYInfo(obj, GQ) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'FCXX_SP\',\'' + obj.ID + '\')" class="li_body_right_jjrtj">');
    html += ('<img class="img_li_body_right_jjrtj" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_li_body_right_jjrtj">');
    html += ('<p class="p_li_body_right_jjrtj_xq">' + TruncStr((obj.QY + ' / ' + obj.DD + ' / ' + obj.JTDZ), 15) + '</p>');
    html += ('<p class="p_li_body_right_jjrtj_cs">' + obj.MJ + '平米</p>');
    html += ('<p class="p_li_body_right_jjrtj_jg">' + (GQ === "出租" ? obj.ZJ : obj.SJ) + obj.ZJDW + '</p>');
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