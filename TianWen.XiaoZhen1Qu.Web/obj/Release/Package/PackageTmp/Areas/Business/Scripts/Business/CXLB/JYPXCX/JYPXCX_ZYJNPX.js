﻿var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadJYPXCondition();
    LoadHot("JYPXXX_ZYJNPX");
});
//加载条件
function LoadJYPXCondition() {
    LoadConditionByTypeNames("'职业技能培训类别','职业技能培训形式','职业技能培训周期'", "CODES_JYPX", "类别,形式,周期", "LB,XS,ZQ", "100,100,100");
}
//加载URL查询条件
function LoadURLCondition() {
    if (getUrlParam("LB") !== null) {
        SelectURLCondition(getUrlParam("LB"));
        LoadConditionByParentID(getUrlParam("LB"), "CODES_JYPX", "小类", "XL");
    }
    else if (getUrlParam("QY") !== null)
        SelectURLCondition(getUrlParam("QY"));
    else
        LoadBody("JYPXXX_ZYJNPX", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "类别" && (obj.innerHTML !== "公务员考试" && obj.innerHTML !== "司法考试")) {
        LoadConditionByParentID(obj.id, "CODES_JYPX", "小类", "XL", 100);
    }
    if (name === "类别" && (obj.innerHTML === "公务员考试" || obj.innerHTML === "司法考试")) {
        $("#ul_condition_body_XL").remove();
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("JYPXXX_ZYJNPX", currentIndex);
    ShowSelectCondition("JYPXXX_ZYJNPX");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("JYPXXX_ZYJNPX", currentIndex);
    ShowSelectCondition("JYPXXX_ZYJNPX");
}
//加载查询条件
function LoadCondition(array, name, id, length) {
    $("#ul_condition_body_" + id).remove();
    var html = "";
    html += '<ul id="ul_condition_body_' + id + '" class="ul_condition_body" style="height:auto;">';
    html += '<li id="li_condition_body_first_' + id + '" class="li_condition_body_first">' + name + '</li>';
    html += '<li id="0" class="li_condition_body li_condition_body_active" onclick="SelectCondition(this,\'' + name + '\')">全部</li>';
    for (var i = 0; i < (array.length > length ? length : array.length) ; i++) {
        html += '<li id="' + array[i].CODEID + '" class="li_condition_body" onclick="SelectCondition(this,\'' + name + '\')">' + array[i].CODENAME + '</li>';
    }
    html += '</ul>';
    $("#div_condition_body_" + id).append(html);
    if (name === "小类" || name === "类别")
        $("#li_condition_body_first_" + id).css("height", (parseInt($("#div_condition_body_" + id).css("height")) - 20));
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("LB,XL,XS,ZQ,QY");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/JYPXCX/LoadJYPXXX",
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
    html += ('<li class="li_body_left">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'JYPXXX_ZYJNPX\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'JYPXXX_ZYJNPX\',\'' + obj.ID + '\')">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_nr">' + obj.BCMSString.replace(/<\/?.+?>/g, "") + '</p>');
    html += ('<p class="p_li_body_left_center_dz">' + ValidateNull(obj.QY) + ' - ' + ValidateNull(obj.DD) + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_li_body_left_right" onclick="ShowLXDH(\''+obj.LXDH+'\')">联系商家</span></p>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载热门推荐
function LoadHot(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/JYPXCX/LoadJYPXXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1",
            PageSize: 100,
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
    html += ('<li onclick="OpenXXXX(\'JYPXXX_ZYJNPX\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + ValidateNull(obj.QY) + ' - ' + ValidateNull(obj.DD) + '</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}