﻿var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadFCCondition();
    LoadHot("FCXX_ESF");
    LoadHeadSearch();
});
//加载头部搜索栏关键字
function LoadHeadSearch() {
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'FWLD\',\'228\')">紧邻地铁</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'FWLD\',\'226\')">精装修</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'FWLD\',\'227\')">南北通透</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'ZZLX\',\'18\')">普通住宅</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'ZZLX\',\'19\')">商住两用</span>');
}
//加载房产查询条件
function LoadFCCondition() {
    LoadConditionByTypeNames("'二手房售价','二手房面积','厅室','朝向','住宅类型','装修情况','出售房屋亮点'", "CODES_FC", "售价,面积,厅室,朝向,住宅类型,装修情况,房屋亮点", "SJ,PFM,S,CX,ZZLX,ZXQK,FWLD", "100,100,100,100,15,15,15");
}
//根据TYPENAME获取字典表
function LoadConditionByTypeNames(typenames, table, names, ids, lengths) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAMES",
        dataType: "json",
        data:
        {
            TYPENAMES: typenames,
            TBName: table
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadDistrictCondition(xml.districts, "QY");
                var typelist = typenames.split(',');
                var namelist = names.split(',');
                for (var i = 0; i < typelist.length; i++) {
                    for (var j = 0; j < namelist.length; j++) {
                        if (typelist[i].indexOf(namelist[j]) !== -1) {
                            LoadCondition(_.filter(xml.list, function (value) { return typelist[i].indexOf(value.TYPENAME) !== -1; }), namelist[j], ids.split(',')[j], lengths.split(',')[j]);
                        }
                    }
                }
                LoadURLCondition();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载URL查询条件
function LoadURLCondition() {
    if (getUrlParam("FWLD") !== null)
        SelectURLCondition(getUrlParam("FWLD"));
    else if (getUrlParam("SJ") !== null)
        SelectURLCondition(getUrlParam("SJ"));
    else if (getUrlParam("ZZLX") !== null)
        SelectURLCondition(getUrlParam("ZZLX"));
    else if (getUrlParam("QY") !== null)
        SelectURLCondition(getUrlParam("QY"));
    else
        LoadBody("FCXX_ESF", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("FCXX_ESF", currentIndex);
    ShowSelectCondition("FCXX_ESF");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("FCXX_ESF", currentIndex);
    ShowSelectCondition("FCXX_ESF");
}
//加载主体部分
function LoadBody(TYPE, PageIndex, OrderColumn, OrderType) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("SJ,PFM,QY,S,CX,ZZLX,ZXQK,FWLD,SF");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/FCCX/LoadFCXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: condition,
            PageSize: 5,
            PageIndex: PageIndex,
            OrderColumn: OrderColumn,
            OrderType: OrderType
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#ul_body_left").html('');
                LoadPage(TYPE, xml.PageCount);
                for (var i = 0; i < xml.list.length; i++) {
                    LoadInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载单条信息
function LoadInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left" onclick="OpenXXXX(\'FCXX_ESF\',\'' + obj.ID + '\')">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs">' + obj.S + '室' + obj.T + '厅' + obj.W + '卫 / ' + obj.PFM + '平米 / ' + obj.ZXQK + ' / ' + obj.CX + ' / ' + obj.C + '层[共' + obj.GJC + '层]</p>');
    html += ('<p class="p_li_body_left_center_dz">' + obj.XQMC + obj.XQDZ + ' ' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_zj">' + obj.SJ + '</span>万元</p>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载热门推荐
function LoadHot(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/FCCX/LoadFCXX",
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
                $("#ul_body_right").html('');
                for (var i = 0; i < xml.list.length; i++) {
                    LoadHotInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载热门单条信息
function LoadHotInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'FCXX_ESF\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.S + '室 / ' + obj.PFM + '平米 / ' + obj.ZXQK + '</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.SJ + '万元</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}
//根据条件查询
function SearchByCondition(type) {
    $("#ul_condition_body_SF").find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    if (type === "GR")
        $("#ul_condition_body_SF").find(".li_condition_body:eq(1)").addClass("li_condition_body_active");
    if (type === "JJR")
        $("#ul_condition_body_SF").find(".li_condition_body:eq(2)").addClass("li_condition_body_active");
    LoadBody("FCXX_ESF", 1);
}
//根据条件排序
function OrderByCondition(type, obj) {
    ChangeCXItem(obj);
    var ordertype = "";
    if (type === "SJ") {
        $("#li_body_head_sort_item_SJ").find("i").each(function () {
            if ($(this).attr("class").indexOf("up") !== -1)
                ordertype = "ASC";
            else
                ordertype = "DESC";
        });
        LoadBody("FCXX_ESF", 1, "SJ", ordertype);
    }
    else {
        $("#li_body_head_sort_item_GXSJ").find("i").each(function () {
            if ($(this).attr("class").indexOf("up") !== -1)
                ordertype = "ASC";
            else
                ordertype = "DESC";
        });
        LoadBody("FCXX_ESF", 1, "ZXGXSJ", ordertype);
    }
}
//搜索栏备注导航
function OpenSS(TYPE, ID) {
    window.open(getRootPath() + "/FCCX/FCCX_ESF?LBID=13" + "&" + TYPE + "=" + ID);
}
