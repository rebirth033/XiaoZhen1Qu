var curIndex = 1; //当前index
var temp = 0;
$(document).ready(function () {
    $("#cnzz_stat_icon_1272914407").css("display", "none");
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_foot").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_hide_logo").css("margin-left", (document.documentElement.clientWidth - 1100) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#bc6ba6").css("color", "#ffffff");
    $("#span_hide_fbxx").bind("click", FBXX);
    $("body").bind("click", function () { CloseByClassID("div_select_dropdown"); });
    $(".li_head_nav_dropdown").bind("mouseover", function () { ShowMenu(this); });
    $(".li_head_nav_dropdown").bind("mouseleave", function () { HideMenu(this); });
    LoadDefault();
    LoadHeadSearch();
});
//显示菜单项
function ShowMenu(obj){
    $(obj).find(".i_head_nav").css("background-image","url(" + getRootPath() + "/Areas/Business/Css/images/head_nav_up.png)");
    $(obj).css("border-color","#bc6bca");
    $(obj).find(".div_head_nav_dropdown").css("display","block");
}
//隐藏菜单项
function HideMenu(obj){
    $(obj).find(".i_head_nav").css("background-image","url(" + getRootPath() + "/Areas/Business/Css/images/head_nav_down.png)");
    $(obj).css("border-color","#ffffff");
    $(obj).find(".div_head_nav_dropdown").css("display","none");
}
//首页获取title
function GetHeadNav() {
    document.title = "风铃网_首页";
}
//发布信息
function FBXX() {
    window.open(getRootPath() + "/LBXZ/LBXZ");
}
//加载默认
function LoadDefault() {
    LoadSY_ML();
    $("#img_div_bottom_wljbappxz").bind("click", function(){window.open("http://report.12377.cn:13225/toreportinputNormal_anis.do");});
    $("#img_div_bottom_wsyhxxjbzq").bind("click", function(){window.open("http://www.12377.cn/node_548446.htm?PGTID=0d100000-0013-0d7a-7a03-2802f15ed53d&ClickID=13");});
    $("#img_div_bottom_qyxyxx").bind("click", function(){window.open( getRootPath() + "/BZZX/BZZX_QYXY");});
}
//加载头部搜索栏关键字
function LoadHeadSearch() {
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'FCCX\',\'FCCX_ZZF\',\'13\')">租房子</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'CLCX\',\'CLCX_JC\',\'185\')">二手车</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'QZZPCX\',\'QZZPCX_JZZP\',\'90\')">兼职</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'ZXJCCX\',\'ZXJCCX_JZFW\',\'130\')">家装服务</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'LYJDCX\',\'LYJDCX_JDZSYD\',\'127\')">酒店住宿</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'SHFWCX\',\'SHFWCX_BJ\',\'172\')">居民搬家</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'HQSYCX\',\'HQSYCX_HQGS\',\'136\')">婚庆公司</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'XXYLCX\',\'XXYLCX_YDJS\',\'44\')">运动健身</span>');
}
//搜索栏备注导航
function OpenSS(DL, XL, ID) {
    window.open(getRootPath() + "/" + DL + "/" + XL + "?LBID=" + ID);
}
//打开详细页面
function OpenXXXX(LBID, JCXXID) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/SY/LoadLBByJCXX",
        dataType: "json",
        data:
        {
            LBID: LBID,
            JCXXID: JCXXID
        },
        success: function (xml) {
            if (xml.Result === 1) {
                if (LBID === 19) {
                    window.open(getRootPath() + "/FCXX/FCXX_ZZF?ID=" + xml.id);
                }
                if (LBID === 1902) {
                    window.open(getRootPath() + "/FCXX/FCXX_HZF?ID=" + xml.id);
                }
                if (LBID === 20) {
                    window.open(getRootPath() + "/FCXX/FCXX_SP?ID=" + xml.id);
                }
                if (LBID === 21) {
                    window.open(getRootPath() + "/FCXX/FCXX_ESF?ID=" + xml.id);
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
        url: getRootPath() + "/SY/LoadSY_ML",
        dataType: "json",
        data: {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                //LoadSY_MLInfo(xml.list, xml.xzq, "FC");
                //LoadSY_MLInfo(xml.list, xml.xzq, "CL");
                //LoadSY_ML_CWInfo(xml.list, xml.xzq, "CW");
                //LoadSY_MLInfo(xml.list, xml.xzq, "ZP");
                //LoadSY_ML_WXLInfo(xml.list, xml.xzq, "ZSJM");
                //LoadSY_ML_SHFWInfo(xml.list, xml.xzq, "SHFW");
                //LoadSY_ML_WXLInfo(xml.list, xml.xzq, "JYPX");
                //LoadSY_ML_WXLInfo(xml.list, xml.xzq, "PFCG");
                //LoadSY_ML_SHFWInfo(xml.list, xml.xzq, "SWFW");
                //LoadSY_MLInfo(xml.list, xml.xzq, "ES");
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
            html += ('<ul class="ul_body_middle_left_section" style="height: ' + GetHeight(list, list[i].ID, typename) + 'px;">');
            for (var j = 0; j < list.length; j++) {
                if (list[j].PARENTID === list[i].ID) {
                    if (list[j].ISHOT === "是")
                        html += ('<li class="li_body_middle_left_section purple" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                    else
                        html += ('<li class="li_body_middle_left_section" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                }
            }
            html += ('</ul>');
        }
    }
    $("#div_body_middle_left_" + typename).append(html);
}
//加载首页_目录详细信息（有小类_生活服务）
function LoadSY_ML_SHFWInfo(list, xzq, typename) {
    var html = "";
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "DL" && list[i].TYPENAME === typename)
            html += ('<p id="p_body_middle_left_title_' + typename + '" class="p_body_middle_left_title">' + list[i].LBNAME + '</p>');
    }
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "XL" && list[i].TYPENAME === typename) {
            html += ('<span class="span_body_middle_left_title_small_shfw">' + list[i].LBNAME + '</span>');
            html += ('<ul class="ul_body_middle_left_section_shfw" style="height: ' + GetHeight(list, list[i].ID, typename) + 'px;">');
            for (var j = 0; j < list.length; j++) {
                if (list[j].PARENTID === list[i].ID) {
                    if (list[j].ISHOT === "是")
                        html += ('<li class="li_body_middle_left_section_shfw purple" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                    else
                        html += ('<li class="li_body_middle_left_section_shfw" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                }
            }
            html += ('</ul>');
        }
    }
    $("#div_body_middle_left_" + typename).append(html);
}
//加载首页_目录详细信息（有小类_宠物）
function LoadSY_ML_CWInfo(list, xzq, typename) {
    var html = "";
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "DL" && list[i].TYPENAME === typename)
            html += ('<p id="p_body_middle_left_title_' + typename + '" class="p_body_middle_left_title">' + list[i].LBNAME + '</p>');
    }
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "XL" && list[i].TYPENAME === typename) {
            html += ('<span class="span_body_middle_left_title_small_cw">' + list[i].LBNAME + '</span>');
            html += ('<ul class="ul_body_middle_left_section_cw" style="height: ' + GetHeight(list, list[i].ID, typename) + 'px;">');
            for (var j = 0; j < list.length; j++) {
                if (list[j].PARENTID === list[i].ID) {
                    if (list[j].ISHOT === "是")
                        html += ('<li class="li_body_middle_left_section_cw purple" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                    else
                        html += ('<li class="li_body_middle_left_section_cw" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
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
            html += ('<p id="p_body_middle_left_title_' + typename + '" class="p_body_middle_left_title">' + list[i].LBNAME + '</p>');
            html += ('<ul class="ul_body_middle_left_section" style="height: ' + GetHeight(list, list[i].ID, typename) + 'px;">');
            for (var j = 0; j < list.length; j++) {
                if (list[j].PARENTID === list[i].ID) {
                    if (list[j].ISHOT === "是")
                        html += ('<li style="width:90px;" class="li_body_middle_left_section orange" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                    else
                        html += ('<li style="width:90px;" class="li_body_middle_left_section" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                }
            }
            html += ('</ul>');
        }
    }
    $("#div_body_middle_left_" + typename).append(html);
}
//获取高度
function GetHeight(list, parentid, typename) {
    var count = 0, height = 0;
    for (var i = 0; i < list.length; i++) {
        if (list[i].PARENTID === parentid) {
            count++;
        }
    }
    if (typename === "FC" || typename === "CL" || typename === "ZP" || typename === "ES") {
        height = parseInt((count / 7)) * 30;
        if (count % 7 !== 0) height += 30;
    }
    else if (typename === "SHFW" || typename === "SWFW") {
        height = parseInt((count / 6)) * 30;
        if (count % 6 !== 0) height += 30;
    }
    else {
        height = parseInt((count / 3)) * 30;
        if (count % 3 !== 0) height += 30;
    }
    return height;
}
//打开查询列表
function OpenCXLB(lbid, lburl, condition) {
    if (condition !== "null" && condition !== null)
        window.open(getRootPath() + "" + lburl + "?LBID=" + lbid + "&" + condition);
    else
        window.open(getRootPath() + "" + lburl + "?LBID=" + lbid);
    $("#LBID").val('');
}
//打开二级首页
function ToEJSY(type) {
    window.open(getRootPath() + "/SY/" + type);
}
//拖动滚动条或滚动鼠标轮
window.onscroll = function () {
    if (document.body.scrollTop || document.documentElement.scrollTop > 100) {
        $("#divHideHead").css("display", "block");
    } else {
        $("#divHideHead").css("display", "none");
    }
}