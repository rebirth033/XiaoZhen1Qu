var curIndex = 1; //当前index
var temp = 0;
$(document).ready(function () {
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_foot").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#5bc0de").css("color", "#ffffff");
    
    LoadDefault();
});
//发布信息
function FBXX() {
    window.open(getRootPath() + "/Business/LBXZ/LBXZ");
}
//加载默认
function LoadDefault() {
    LoadSY_ML();
    //LoadZXFBXX();
}
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
    html += ('<li onclick="OpenXXXX(' + obj.LBID + ',\'' + obj.JCXXID + '\')" class="li_body_top_right_zxfb">');
    html += ('<img class="img_body_top_right_zxfb" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_body_top_right_zxfb">');
    html += ('<span class="span_body_top_right_zxfb">' + TruncStr(obj.BT, 45) + '</span>');
    html += ('<span class="span_body_top_right_zxfb_sj">' + obj.CJSJ.ToString("yyyy-MM-dd hh:mm:ss") + '</span>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_top_right_zxfb").append(html);
}
//打开详细页面
function OpenXXXX(LBID, JCXXID) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadLBByJCXX",
        dataType: "json",
        data:
        {
            LBID: LBID,
            JCXXID: JCXXID
        },
        success: function (xml) {
            if (xml.Result === 1) {
                if (LBID === 19) {
                    window.open(getRootPath() + "/Business/FCXX/FCXX_ZZF?ID=" + xml.id);
                }
                if (LBID === 1902) {
                    window.open(getRootPath() + "/Business/FCXX/FCXX_HZF?ID=" + xml.id);
                }
                if (LBID === 20) {
                    window.open(getRootPath() + "/Business/FCXX/FCXX_SP?ID=" + xml.id);
                }
                if (LBID === 21) {
                    window.open(getRootPath() + "/Business/FCXX/FCXX_ESF?ID=" + xml.id);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载首页_目录
function LoadSY_ML() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadSY_ML",
        dataType: "json",
        data: {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadSY_MLInfo(xml.list, xml.xzq, "FC");
                LoadSY_MLInfo(xml.list, xml.xzq, "CL");
                LoadSY_ML_CWInfo(xml.list, xml.xzq, "CW");
                LoadSY_MLInfo(xml.list, xml.xzq, "ZP");
                LoadSY_ML_WXLInfo(xml.list, xml.xzq, "ZSJM");
                LoadSY_ML_WXLInfo(xml.list, xml.xzq, "PX");
                LoadSY_MLInfo(xml.list, xml.xzq, "SHFW");
                LoadSY_ML_WXLInfo(xml.list, xml.xzq, "JY");
                LoadSY_ML_WXLInfo(xml.list, xml.xzq, "PFCG");
                LoadSY_MLInfo(xml.list, xml.xzq, "SWFW");
                LoadSY_MLInfo(xml.list, xml.xzq, "ES");
                $("#p_body_middle_left_title_FC").css("border-bottom", "2px solid #59d072");
                $("#p_body_middle_left_title_CL").css("border-bottom", "2px solid #bc6ba6");
                $("#p_body_middle_left_title_CW").css("border-bottom", "2px solid #9fa4ce");
                $("#p_body_middle_left_title_ZP").css("border-bottom", "2px solid #00bfe1");
                $("#p_body_middle_left_title_ZSJM").css("border-bottom", "2px solid #abc466");
                $("#p_body_middle_left_title_PX").css("border-bottom", "2px solid #c49966");
                $("#p_body_middle_left_title_SHFW").css("border-bottom", "2px solid #ce9fc8");
                $("#p_body_middle_left_title_JY").css("border-bottom", "2px solid #fda19d");
                $("#p_body_middle_left_title_PFCG").css("border-bottom", "2px solid #eb437e");
                $("#p_body_middle_left_title_SWFW").css("border-bottom", "2px solid #e5237e");
                $("#p_body_middle_left_title_ES").css("border-bottom", "2px solid #64f4de");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载首页_目录详细信息（有小类）
function LoadSY_MLInfo(list, xzq, typename) {
    var html = "";
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "DL" && list[i].TYPENAME === typename)
            html += ('<p id="p_body_middle_left_title_' + typename + '" class="p_body_middle_left_title">' + list[i].LBNAME + '</p>');
    }
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "XL" && list[i].TYPENAME === typename) {
            html += ('<p class="p_body_middle_left_title_small">' + list[i].LBNAME + '</p>');
            html += ('<ul class="ul_body_middle_left_section" style="height: ' + GetHeight(list, list[i].ID) + 'px;">');
            for (var j = 0; j < list.length; j++) {
                if (list[j].PARENTID === list[i].ID) {
                    if (list[j].ISHOT === "是")
                        html += ('<li class="li_body_middle_left_section orange" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                    else
                        html += ('<li class="li_body_middle_left_section" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                }
            }
            html += ('</ul>');
        }
    }
    $("#div_body_middle_left_" + typename).append(html);
}
//加载首页_目录详细信息（无小类）
function LoadSY_ML_WXLInfo(list, xzq, typename) {
    var html = "";
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "DL" && list[i].TYPENAME === typename) {
            html += ('<p class="p_body_middle_left_title">' + list[i].LBNAME + '</p>');
            html += ('<ul class="ul_body_middle_left_section" style="height: ' + GetHeight(list, list[i].ID) + 'px;">');
            for (var j = 0; j < list.length; j++) {
                if (list[j].PARENTID === list[i].ID) {
                    if (list[j].ISHOT === "是")
                        html += ('<li class="li_body_middle_left_section orange" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                    else
                        html += ('<li class="li_body_middle_left_section" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                }
            }
            html += ('</ul>');
        }
    }
    $("#div_body_middle_left_" + typename).append(html);
}
//加载首页_目录_宠物详细信息
function LoadSY_ML_CWInfo(list, xzq, typename) {
    var html = "";
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "DL" && list[i].TYPENAME === typename)
            html += ('<p id="p_body_middle_left_title_' + typename + '" class="p_body_middle_left_title">' + list[i].LBNAME + '</p>');
    }
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "XL" && list[i].TYPENAME === typename) {
            html += ('<div class="div_body_middle_left_section_fl">');
            html += ('<span class="span_body_middle_left_section_fl_left blue" onclick="OpenCXLB(' + list[i].LBID + ',\'' + list[i].LBURL + '\',\'' + list[i].CONDITION + '\')" style="height: ' + GetHeight(list, list[i].ID) + 'px;">' + list[i].LBNAME + '</span>');
            var count = 0;
            for (var j = 0; j < list.length; j++) {
                if (list[j].PARENTID === list[i].ID) {
                    count++;
                    if (list[j].ISHOT === "是")
                        html += ('<span class="span_body_middle_left_section_fl_right orange" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</span>');
                    else
                        html += ('<span class="span_body_middle_left_section_fl_right" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</span>');
                    if (count % 3 === 0)
                        html += ('<br />');
                    else
                        html += ('<em class="em_body_middle_left_section_fl_right">/</em>');
                }
            }
            html += ('</div>');
        }
    }
    $("#div_body_middle_left_" + typename).append(html);
}
//获取高度
function GetHeight(list, parentid) {
    var count = 0, height = 0;
    for (var i = 0; i < list.length; i++) {
        if (list[i].PARENTID === parentid) {
            count++;
        }
    }
    height = parseInt((count / 3)) * 30;
    if (count % 3 !== 0)
        height += 30;
    return height;
}
//打开查询列表
function OpenCXLB(lbid, lburl, condition) {
    if (condition !== "null" && condition !== null)
        window.open(getRootPath() + "/Business" + lburl + "?LBID=" + lbid + "&" + condition);
    else
        window.open(getRootPath() + "/Business" + lburl + "?LBID=" + lbid);
}