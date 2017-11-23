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
//加载默认
function LoadDefault() {
    LoadSY_ML();
    LoadZXFBXX();
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
                    window.open(getRootPath() + "/Business/FCXX/FC_ZZF?ID=" + xml.id);
                }
                if (LBID === 20) {
                    window.open(getRootPath() + "/Business/FCXX/FC_SP?ID=" + xml.id);
                }
                if (LBID === 21) {
                    window.open(getRootPath() + "/Business/FCXX/FC_ESF?ID=" + xml.id);
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
                LoadSY_ML_WXLInfo(xml.list, xml.xzq, "JZ");
                LoadSY_ML_WXLInfo(xml.list, xml.xzq, "PX");
                LoadSY_MLInfo(xml.list, xml.xzq, "SHFW");
                LoadSY_ML_WXLInfo(xml.list, xml.xzq, "JY");
                LoadSY_ML_WXLInfo(xml.list, xml.xzq, "PFCG");
                LoadSY_MLInfo(xml.list, xml.xzq, "SWFW");
                LoadSY_MLInfo(xml.list, xml.xzq, "ES");
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
            html += ('<p class="p_body_middle_left_title">' + xzq + list[i].LBNAME + '</p>');
    }
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "XL" && list[i].TYPENAME === typename) {
            html += ('<p class="p_body_middle_left_title_small">' + list[i].LBNAME + '</p>');
            html += ('<ul class="ul_body_middle_left_section" style="height: ' + GetHeight(list, list[i].ID) + 'px;">');
            for (var j = 0; j < list.length; j++) {
                if (list[j].PARENTID === list[i].ID) {
                    if (list[j].ISHOT === "是")
                        html += ('<li class="li_body_middle_left_section orange" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].TYPENAME + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                    else
                        html += ('<li class="li_body_middle_left_section" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].TYPENAME + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
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
            html += ('<p class="p_body_middle_left_title">' + xzq + list[i].LBNAME + '</p>');
            html += ('<ul class="ul_body_middle_left_section" style="height: ' + GetHeight(list, list[i].ID) + 'px;">');
            for (var j = 0; j < list.length; j++) {
                if (list[j].PARENTID === list[i].ID) {
                    if (list[j].ISHOT === "是")
                        html += ('<li class="li_body_middle_left_section orange" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].TYPENAME + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                    else
                        html += ('<li class="li_body_middle_left_section" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].TYPENAME + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
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
            html += ('<p class="p_body_middle_left_title">' + xzq + list[i].LBNAME + '</p>');
    }
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "XL" && list[i].TYPENAME === typename) {
            html += ('<div class="div_body_middle_left_section_fl">');
            html += ('<span class="span_body_middle_left_section_fl_left blue" onclick="OpenCXLB(' + list[i].LBID + ',\'' + list[i].TYPENAME + '\',\'' + list[i].CONDITION + '\')" style="height: ' + GetHeight(list, list[i].ID) + 'px;">' + list[i].LBNAME + '</span>');
            var count = 0;
            for (var j = 0; j < list.length; j++) {
                if (list[j].PARENTID === list[i].ID) {
                    count++;
                    if (list[j].ISHOT === "是")
                        html += ('<span class="span_body_middle_left_section_fl_right orange" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].TYPENAME + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</span>');
                    else
                        html += ('<span class="span_body_middle_left_section_fl_right" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].TYPENAME + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</span>');
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
function OpenCXLB(lbid, typename, condition) {
    //房产
    if (lbid === 19)
        window.open(getRootPath() + "/Business/FCCX/FCCX_ZZF?LBID=" + lbid + "&" + condition);
    if (lbid === 20)
        window.open(getRootPath() + "/Business/FCCX/FCCX_SP?LBID=" + lbid);
    if (lbid === 21)
        window.open(getRootPath() + "/Business/FCCX/FCCX_ESF?LBID=" + lbid);
    if (lbid === 328)
        window.open(getRootPath() + "/Business/FCCX/FCCX_DZF?LBID=" + lbid);
    if (lbid === 289)
        window.open(getRootPath() + "/Business/FCCX/FCCX_XZL?LBID=" + lbid);
    if (lbid === 2931)
        window.open(getRootPath() + "/Business/FCCX/FCCX_CF?LBID=" + lbid);
    if (lbid === 2932)
        window.open(getRootPath() + "/Business/FCCX/FCCX_CK?LBID=" + lbid);
    if (lbid === 2933)
        window.open(getRootPath() + "/Business/FCCX/FCCX_TD?LBID=" + lbid);
    if (lbid === 2934)
        window.open(getRootPath() + "/Business/FCCX/FCCX_CW?LBID=" + lbid);
    //车辆
    if (lbid === 61)
        window.open(getRootPath() + "/Business/CLCX/CLCX_JC?LBID=" + lbid);
    if (lbid === 68)
        window.open(getRootPath() + "/Business/CLCX/CLCX_HC?LBID=" + lbid);
    if (lbid === 69)
        window.open(getRootPath() + "/Business/CLCX/CLCX_KC?LBID=" + lbid);
    if (lbid === 65)
        window.open(getRootPath() + "/Business/CLCX/CLCX_MTC?LBID=" + lbid);
    if (lbid === 66)
        window.open(getRootPath() + "/Business/CLCX/CLCX_ZXC?LBID=" + lbid);
    if (lbid === 64)
        window.open(getRootPath() + "/Business/CLCX/CLCX_DDC?LBID=" + lbid);
    if (lbid === 63)
        window.open(getRootPath() + "/Business/CLCX/CLCX_SLC?LBID=" + lbid);
    if (lbid === 62)
        window.open(getRootPath() + "/Business/CLCX/CLCX_GCC?LBID=" + lbid);
    //宠物
    if (lbid === 73)
        window.open(getRootPath() + "/Business/CWCX/CWCX_CWG?LBID=" + lbid);
    if (lbid === 74)
        window.open(getRootPath() + "/Business/CWCX/CWCX_CWM?LBID=" + lbid);
    if (lbid === 75)
        window.open(getRootPath() + "/Business/CWCX/CWCX_HNYC?LBID=" + lbid);
    if (lbid === 80)
        window.open(getRootPath() + "/Business/CWCX/CWCX_CWFW?LBID=" + lbid);
    if (lbid === 79)
        window.open(getRootPath() + "/Business/CWCX/CWCX_CWYPSP?LBID=" + lbid);
    if (lbid === 78)
        window.open(getRootPath() + "/Business/CWCX/CWCX_CWGY?LBID=" + lbid);
    //二手
    if (lbid === 186)
        window.open(getRootPath() + "/Business/ESCX/ESCX_SJSM_ESSJ?LBID=" + lbid);
    if (lbid === 187)
        window.open(getRootPath() + "/Business/ESCX/ESCX_SJSM_BJBDN?LBID=" + lbid);
    if (lbid === 188)
        window.open(getRootPath() + "/Business/ESCX/ESCX_SJSM_PBDN?LBID=" + lbid);
    if (lbid === 189)
        window.open(getRootPath() + "/Business/ESCX/ESCX_SJSM_SMCP?LBID=" + lbid);
    if (lbid === 190)
        window.open(getRootPath() + "/Business/ESCX/ESCX_SJSM_TSJ?LBID=" + lbid);
    if (lbid === 191)
        window.open(getRootPath() + "/Business/ESCX/ESCX_JDJJBG_ESJD?LBID=" + lbid);
    if (lbid === 192)
        window.open(getRootPath() + "/Business/ESCX/ESCX_JDJJBG_ESJJ?LBID=" + lbid);
    if (lbid === 193)
        window.open(getRootPath() + "/Business/ESCX/ESCX_JDJJBG_JJRY?LBID=" + lbid);
    if (lbid === 194)
        window.open(getRootPath() + "/Business/ESCX/ESCX_JDJJBG_BGSB?LBID=" + lbid);
    if (lbid === 195)
        window.open(getRootPath() + "/Business/ESCX/ESCX_MYFZMR_MYETYPWJ?LBID=" + lbid);
    if (lbid === 196)
        window.open(getRootPath() + "/Business/ESCX/ESCX_MYFZMR_FZXMXB?LBID=" + lbid);
    if (lbid === 197)
        window.open(getRootPath() + "/Business/ESCX/ESCX_MYFZMR_MRBJ?LBID=" + lbid);
    if (lbid === 198)
        window.open(getRootPath() + "/Business/ESCX/ESCX_WHYL_YSPSCP?LBID=" + lbid);
    if (lbid === 199)
        window.open(getRootPath() + "/Business/ESCX/ESCX_WHYL_WTHWYQ?LBID=" + lbid);
    if (lbid === 200)
        window.open(getRootPath() + "/Business/ESCX/ESCX_WHYL_TSYXRJ?LBID=" + lbid);
    if (lbid === 201)
        window.open(getRootPath() + "/Business/ESCX/ESCX_WHYL_WYXNWP?LBID=" + lbid);
    if (lbid === 82)
        window.open(getRootPath() + "/Business/ESCX/ESCX_PWKQ_DYP?LBID=" + lbid);
    if (lbid === 83)
        window.open(getRootPath() + "/Business/ESCX/ESCX_PWKQ_XFKGWQ?LBID=" + lbid);
    if (lbid === 84)
        window.open(getRootPath() + "/Business/ESCX/ESCX_PWKQ_QTKQ?LBID=" + lbid);
    if (lbid === 85)
        window.open(getRootPath() + "/Business/ESCX/ESCX_PWKQ_YCMP?LBID=" + lbid);
    if (lbid === 86)
        window.open(getRootPath() + "/Business/ESCX/ESCX_PWKQ_YLYJDP?LBID=" + lbid);
    if (lbid === 202)
        window.open(getRootPath() + "/Business/ESCX/ESCX_QTES_ESSB?LBID=" + lbid);
    if (lbid === 204)
        window.open(getRootPath() + "/Business/ESCX/ESCX_QTES_CRYP?LBID=" + lbid);
    //求职招聘
    if (lbid === 205)
        window.open(getRootPath() + "/Business/QZZPCX/QZZPCX_QZZP?LBID=" + lbid + "&" + condition);
    if (lbid === 206)
        window.open(getRootPath() + "/Business/QZZPCX/QZZPCX_JZZP?LBID=" + lbid);
    //招商加盟
    if (lbid === 159)
        window.open(getRootPath() + "/Business/ZSJMCX/ZSJMCX_CY?LBID=" + lbid);
    if (lbid === 160)
        window.open(getRootPath() + "/Business/ZSJMCX/ZSJMCX_FZXB?LBID=" + lbid);
    if (lbid === 161)
        window.open(getRootPath() + "/Business/ZSJMCX/ZSJMCX_JC?LBID=" + lbid);
    if (lbid === 162)
        window.open(getRootPath() + "/Business/ZSJMCX/ZSJMCX_JX?LBID=" + lbid);
    if (lbid === 163)
        window.open(getRootPath() + "/Business/ZSJMCX/ZSJMCX_MRBJ?LBID=" + lbid);
    if (lbid === 164)
        window.open(getRootPath() + "/Business/ZSJMCX/ZSJMCX_LPSP?LBID=" + lbid);
    if (lbid === 165)
        window.open(getRootPath() + "/Business/ZSJMCX/ZSJMCX_JJHB?LBID=" + lbid);
    if (lbid === 166)
        window.open(getRootPath() + "/Business/ZSJMCX/ZSJMCX_JYPX?LBID=" + lbid);
    if (lbid === 167)
        window.open(getRootPath() + "/Business/ZSJMCX/ZSJMCX_QCFW?LBID=" + lbid);
    if (lbid === 168)
        window.open(getRootPath() + "/Business/ZSJMCX/ZSJMCX_WLFW?LBID=" + lbid);
    if (lbid === 169)
        window.open(getRootPath() + "/Business/ZSJMCX/ZSJMCX_NY?LBID=" + lbid);
    if (lbid === 170)
        window.open(getRootPath() + "/Business/ZSJMCX/ZSJMCX_TS?LBID=" + lbid);
    if (lbid === 171)
        window.open(getRootPath() + "/Business/ZSJMCX/ZSJMCX_SHFW?LBID=" + lbid);
    if (lbid === 172)
        window.open(getRootPath() + "/Business/ZSJMCX/ZSJMCX_MYET?LBID=" + lbid);
    //批发采购
    if (lbid === 224)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_SP?LBID=" + lbid);
    if (lbid === 225)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_LP?LBID=" + lbid);
    if (lbid === 226)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_FSXM?LBID=" + lbid);
    if (lbid === 227)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_XBSP?LBID=" + lbid);
    if (lbid === 228)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_SJSM?LBID=" + lbid);
    if (lbid === 229)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_MYWJ?LBID=" + lbid);
    if (lbid === 230)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_HWYD?LBID=" + lbid);
    if (lbid === 231)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_HZP?LBID=" + lbid);
    if (lbid === 232)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_AFSB?LBID=" + lbid);
    if (lbid === 233)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_FZBL?LBID=" + lbid);
    if (lbid === 234)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_SCSB?LBID=" + lbid);
    if (lbid === 235)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_HXP?LBID=" + lbid);
    if (lbid === 236)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_DGDL?LBID=" + lbid);
    if (lbid === 237)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_DZYQJ?LBID=" + lbid);
    if (lbid === 238)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_YBYQ?LBID=" + lbid);
    if (lbid === 239)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_DJZM?LBID=" + lbid);
    if (lbid === 240)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_YCL?LBID=" + lbid);
    if (lbid === 241)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_BZ?LBID=" + lbid);
    if (lbid === 242)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_YX?LBID=" + lbid);
    if (lbid === 243)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_TS?LBID=" + lbid);
    if (lbid === 244)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_KQ?LBID=" + lbid);
    if (lbid === 245)
        window.open(getRootPath() + "/Business/PFCGCX/PFCGCX_JXJG?LBID=" + lbid);
    //教育培训
    if (lbid === 259)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_ZXXFDB?LBID=" + lbid);
    if (lbid === 262)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_ZXXYDY?LBID=" + lbid);
    if (lbid === 261)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_JJJG?LBID=" + lbid);
    if (lbid === 260)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_JJGR?LBID=" + lbid);
    if (lbid === 263)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_YYPX?LBID=" + lbid);
    if (lbid === 264)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_YYPXJS?LBID=" + lbid);
    if (lbid === 267)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_YSPX?LBID=" + lbid);
    if (lbid === 275)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_YSPXJS?LBID=" + lbid);
    if (lbid === 265)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_ZYJNPX?LBID=" + lbid);
    if (lbid === 268)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_TYPX?LBID=" + lbid);
    if (lbid === 276)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_TYJL?LBID=" + lbid); 
    if (lbid === 266)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_XLJY?LBID=" + lbid);
    if (lbid === 269)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_ITPX?LBID=" + lbid);
    if (lbid === 270)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_SJPX?LBID=" + lbid);
    if (lbid === 271)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_GLPX?LBID=" + lbid);
    if (lbid === 272)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_YYEJY?LBID=" + lbid);
    if (lbid === 273)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_LX?LBID=" + lbid);
    if (lbid === 274)
        window.open(getRootPath() + "/Business/JYPXCX/JYPXCX_YM?LBID=" + lbid);
    //农林牧副渔
    if (lbid === 278)
        window.open(getRootPath() + "/Business/NLMFYCX/NLMFYCX_YLHH?LBID=" + lbid);
    if (lbid === 279)
        window.open(getRootPath() + "/Business/NLMFYCX/NLMFYCX_NZW?LBID=" + lbid);
    if (lbid === 280)
        window.open(getRootPath() + "/Business/NLMFYCX/NLMFYCX_DZWZM?LBID=" + lbid);
    if (lbid === 281)
        window.open(getRootPath() + "/Business/NLMFYCX/NLMFYCX_CQYZ?LBID=" + lbid);
    if (lbid === 282)
        window.open(getRootPath() + "/Business/NLMFYCX/NLMFYCX_SC?LBID=" + lbid);
    if (lbid === 283)
        window.open(getRootPath() + "/Business/NLMFYCX/NLMFYCX_FLNY?LBID=" + lbid);
    if (lbid === 284)
        window.open(getRootPath() + "/Business/NLMFYCX/NLMFYCX_SLSY?LBID=" + lbid);
    if (lbid === 285)
        window.open(getRootPath() + "/Business/NLMFYCX/NLMFYCX_NJJSB?LBID=" + lbid);
    if (lbid === 286)
        window.open(getRootPath() + "/Business/NLMFYCX/NLMFYCX_NCPJG?LBID=" + lbid);
    //商务服务
    if (lbid === 301)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_GSZC?LBID=" + lbid);
    if (lbid === 302)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_SBZL?LBID=" + lbid);
    if (lbid === 303)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_FLZX?LBID=" + lbid);
    if (lbid === 304)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_CWKJPG?LBID=" + lbid);
    if (lbid === 305)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_BX?LBID=" + lbid);
    if (lbid === 306)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_TZDB?LBID=" + lbid);
    if (lbid === 307)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_YSBZ?LBID=" + lbid);
    if (lbid === 308)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_PHZP?LBID=" + lbid);
    if (lbid === 309)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_SJCH?LBID=" + lbid);
    if (lbid === 310)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_GGCM?LBID=" + lbid);
    if (lbid === 311)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_ZHFW?LBID=" + lbid);
    if (lbid === 312)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_LPDZ?LBID=" + lbid);
    if (lbid === 313)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_ZK?LBID=" + lbid);
    if (lbid === 314)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_FYSJ?LBID=" + lbid);
    if (lbid === 315)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_WLBXWH?LBID=" + lbid);
    if (lbid === 316)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_WZJSTG?LBID=" + lbid);
    if (lbid === 317)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_ZXFW?LBID=" + lbid);
    if (lbid === 319)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_KD?LBID=" + lbid);
    if (lbid === 320)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_HYWL?LBID=" + lbid);
    if (lbid === 321)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_HYZX?LBID=" + lbid);
    if (lbid === 322)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_BGSBWX?LBID=" + lbid);
    if (lbid === 323)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_ZL?LBID=" + lbid);
    if (lbid === 324)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_DBQZQZ?LBID=" + lbid);
    if (lbid === 325)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_JZWX?LBID=" + lbid);
    if (lbid === 326)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_JXSBWX?LBID=" + lbid);
    if (lbid === 209)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_SYSX?LBID=" + lbid);
    if (lbid === 210)
        window.open(getRootPath() + "/Business/SWFWCX/SWFWCX_LYQD?LBID=" + lbid);
    //装修建材
    if (lbid === 253)
        window.open(getRootPath() + "/Business/ZXJCCX/ZXJCCX_JZFW?LBID=" + lbid);
    if (lbid === 254)
        window.open(getRootPath() + "/Business/ZXJCCX/ZXJCCX_GZFW?LBID=" + lbid);
    if (lbid === 255)
        window.open(getRootPath() + "/Business/ZXJCCX/ZXJCCX_FWGZ?LBID=" + lbid);
    if (lbid === 256)
        window.open(getRootPath() + "/Business/ZXJCCX/ZXJCCX_JC?LBID=" + lbid);
    if (lbid === 257)
        window.open(getRootPath() + "/Business/ZXJCCX/ZXJCCX_JJ?LBID=" + lbid);
    if (lbid === 258)
        window.open(getRootPath() + "/Business/ZXJCCX/ZXJCCX_JFJS?LBID=" + lbid);
    //婚庆摄影
    if (lbid === 208)
        window.open(getRootPath() + "/Business/HQSYCX/HQSYCX_HQGS?LBID=" + lbid);
    if (lbid === 331)
        window.open(getRootPath() + "/Business/HQSYCX/HQSYCX_HCZL?LBID=" + lbid);
    if (lbid === 332)
        window.open(getRootPath() + "/Business/HQSYCX/HQSYCX_HYJD?LBID=" + lbid);
    if (lbid === 333)
        window.open(getRootPath() + "/Business/HQSYCX/HQSYCX_CZZX?LBID=" + lbid);
    if (lbid === 334)
        window.open(getRootPath() + "/Business/HQSYCX/HQSYCX_HQYP?LBID=" + lbid);
    if (lbid === 335)
        window.open(getRootPath() + "/Business/HQSYCX/HQSYCX_SY?LBID=" + lbid);
    if (lbid === 336)
        window.open(getRootPath() + "/Business/HQSYCX/HQSYCX_HLGP?LBID=" + lbid);
    if (lbid === 337)
        window.open(getRootPath() + "/Business/HQSYCX/HQSYCX_HSLF?LBID=" + lbid);
    if (lbid === 338)
        window.open(getRootPath() + "/Business/HQSYCX/HQSYCX_ZBSS?LBID=" + lbid);
    if (lbid === 339)
        window.open(getRootPath() + "/Business/HQSYCX/HQSYCX_HSSY?LBID=" + lbid);
}