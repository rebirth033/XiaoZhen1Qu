﻿var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadESCondition();
    LoadHot("ESXX_PWKQ_MPKQ");
});
//加载条件
function LoadESCondition() {
    LoadConditionByTypeNames("'门票卡券类别','卡券价格'", "CODES_ES_PWKQ", "类别,价格", "LB,JG", "14,15");
    LoadBody("ESXX_PWKQ_MPKQ", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("ESXX_PWKQ_MPKQ", currentIndex);
    ShowSelectCondition("ESXX_PWKQ_MPKQ");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("LB,XL,JG,QY,GQ");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ESCX/LoadESXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: condition,
            PageSize: 5,
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
//加载二手单条信息
function LoadInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left" onclick="OpenXXXX(\'ESXX_PWKQ_MPKQ\',\'' + obj.ID + '\')">');
    html += ('<div class="div_li_body_left_left">' + GetJG(obj.JG, '元') + '</div>');
    html += ('<div class="div_li_body_left_center">' + obj.BT + '</div>');
    html += ('<div class="div_li_body_left_right">' + obj.ZXGXSJ.ToString("MM月dd日") + '</div>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载热门推荐
function LoadHot(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ESCX/LoadESXX",
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
    html += ('<li onclick="OpenXXXX(\'ESXX_PWKQ_MPKQ\',\'' + obj.ID + '\')" class="li_body_right">');
    //html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('<p class="p_li_body_right_jg">' + GetJG(obj.JG, '元') + '</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}
//根据条件查询
function SearchByCondition(type) {
    $("#ul_condition_body_GQ").find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    if (type === "ZR")
        $("#ul_condition_body_GQ").find(".li_condition_body:eq(1)").addClass("li_condition_body_active");
    if (type === "QG")
        $("#ul_condition_body_GQ").find(".li_condition_body:eq(2)").addClass("li_condition_body_active");
    LoadBody("ESXX_PWKQ_MPKQ", 1);
}