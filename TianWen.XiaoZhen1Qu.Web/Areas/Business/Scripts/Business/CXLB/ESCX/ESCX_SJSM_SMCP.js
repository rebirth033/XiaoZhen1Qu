﻿var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadESCondition();
    LoadHot("ESXX_SJSM_SMCP");
});
//加载条件
function LoadESCondition() {
    LoadConditionByTypeNames("'数码产品类别','手机价格'", "CODES_ES_SJSM", "类别,价格", "LB,JG", "15,15");
    LoadBody("ESXX_SJSM_SMCP", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "类别" && obj.innerHTML !== "数码摄像机" && obj.innerHTML !== "耳机耳麦" && obj.innerHTML !== "电子书/kindle" && obj.innerHTML !== "数码回收") {
        LoadConditionByParentID(obj.id, "CODES_ES_SJSM", "小类", "XL");
    }
    if (name === "类别" && (obj.innerHTML === "数码摄像机" || obj.innerHTML === "耳机耳麦" || obj.innerHTML === "电子书/kindle" || obj.innerHTML === "数码回收")) {
        $("#ul_condition_body_XL").remove(); 
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("ESXX_SJSM_SMCP", currentIndex);
    ShowSelectCondition("ESXX_SJSM_SMCP");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("LB,XL,JG,QY");
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
    html += ('<li class="li_body_left" onclick="OpenXXXX(\'ESXX_SJSM_SMCP\',\'' + obj.ID + '\')">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt">' + TruncStr(obj.BT,35) + '</p>');
    html += (TruncStr(obj.BCMSString, 35));
    html += ('<p class="p_li_body_left_center_dz font_size14">' + obj.QY + ' - ' + obj.DD + '<label>/</label>' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_zj">' + obj.JG + '</span>元</p>');
    html += ('</div>');
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
    html += ('<li onclick="OpenXXXX(\'ESXX_SJSM_SMCP\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + TruncStr(obj.BT,23) + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.JG + '元</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}