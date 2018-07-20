﻿var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadCLCondition();
    LoadHot("CLXX_GCC");
});
//加载条件
function LoadCLCondition() {
    LoadConditionByTypeNames("'工程车车型','客车价格'", "CODES_CL", "车型,价格", "CX,JG", "100,100");
}
//加载URL查询条件
function LoadURLCondition() {
    if (getUrlParam("JG") !== null)
        SelectURLCondition(getUrlParam("JG"));
    else if (getUrlParam("CX") !== null)
        SelectURLCondition(getUrlParam("CX"));
    else if (getUrlParam("QY") !== null)
        SelectURLCondition(getUrlParam("QY"));
    else
        LoadBody("CLXX_GCC", currentIndex);
}
//加载查询条件
function LoadCondition(array, name, id, length) {
    $("#ul_condition_body_" + id).remove();
    var html = ""; var SZM = "";
    html += '<ul id="ul_condition_body_' + id + '" class="ul_condition_body" style="height:auto;">';
    if (name === "地段" || name === "类别" || name === "小类" || name === "品牌" || name === "车系" || name === "车型" || name === "驾照" || name === "品种" || name === "型号" || name === "语种" || name === "用途" || name === "婚车品牌" || name === "国家" || name === "留学国家")
        html += '<li id="li_condition_body_first_' + id + '" class="li_condition_body_first">' + name + '</li>';
    else
        html += '<li class="li_condition_body_first">' + name + '</li>';
    html += '<li id="0" class="li_condition_body li_condition_body_active" onclick="SelectCondition(this,\'' + name + '\')">全部</li>';
    for (var i = 0; i < (array.length > length ? length : array.length) ; i++) {
        if (name === "车型") {
            if (SZM == "" || SZM !== array[i].CODEVALUE) {
                SZM = array[i].CODEVALUE;
                html += '<li class="li_condition_body_szm" style="font-weight:bold;">' + SZM + '</li>';
            }
            html += '<li id="' + array[i].CODEID + '" class="li_condition_body" onclick="SelectCondition(this,\'' + name + '\')">' + array[i].CODENAME + '</li>';
        }
        else{
            html += '<li id="' + array[i].CODEID + '" class="li_condition_body" onclick="SelectCondition(this,\'' + name + '\')">' + array[i].CODENAME + '</li>';
        }
    }
    html += '</ul>';
    $("#div_condition_body_" + id).append(html);
    if (name === "车型")
        $("#li_condition_body_first_" + id).css("height", (parseInt($("#div_condition_body_" + id).css("height")) - 10));
    else
        $("#li_condition_body_first_" + id).css("height", (parseInt($("#div_condition_body_" + id).css("height")) - 20));
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "车型" && obj.innerHTML === "挖掘机") {
        LoadConditionByTypeNames("'挖掘机品牌'", "CODES_CL", "品牌", "PP", "100");
    }
    if (name === "车型" && obj.innerHTML !== "挖掘机") {
        $("#ul_condition_body_PP").remove();
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("CLXX_GCC", currentIndex);
    ShowSelectCondition("CLXX_GCC");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("CLXX_GCC", currentIndex);
    ShowSelectCondition("CLXX_GCC");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);var condition = GetAllCondition("CX,PP,JG,QY,SF");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/CLCX/LoadCLXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: condition,
            PageSize: 100,
            PageIndex: PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#ul_body_left").html('');
                LoadPage(TYPE, xml.PageCount);
                for (var i = 0; i < xml.list.length; i++) {
                    LoadCL_GCCInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载单条信息
function LoadCL_GCCInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'CLXX_GCC\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'CLXX_GCC\',\'' + obj.ID + '\')">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs">' + obj.CX + ' / ' + obj.CCNF + ' / ' + obj.XSS + '小时' + '</p>');
    html += ('<p class="p_li_body_left_center_dz">' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_zj">' + obj.JG + '</span>万元</p>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载热门推荐
function LoadHot(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/CLCX/LoadCLXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1",
            PageSize: 10,
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
    html += ('<li onclick="OpenXXXX(\'CLXX_GCC\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.CX + ' / ' + obj.CCNF + ' / ' + obj.XSS + '小时' + '</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.JG + '万元</p>');
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
    if (type === "SJ")
        $("#ul_condition_body_SF").find(".li_condition_body:eq(2)").addClass("li_condition_body_active");
    LoadBody("CLXX_GCC", 1);
}