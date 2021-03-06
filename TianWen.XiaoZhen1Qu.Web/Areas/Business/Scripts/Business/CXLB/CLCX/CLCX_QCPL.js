﻿var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadCLCondition();
    LoadHot("CLXX_QCPL");
});
//加载条件
function LoadCLCondition() {
    LoadConditionByTypeNames("'驾校类别'", "CODES_CL", ",类别", "LB", "15");
}
//加载URL查询条件
function LoadURLCondition() {
    if (getUrlParam("LB") !== null)
        SelectURLCondition(getUrlParam("LB"));
    else if (getUrlParam("QY") !== null)
        SelectURLCondition(getUrlParam("QY"));
    else
        LoadBody("CLXX_QCPL", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("CLXX_QCPL", currentIndex);
    ShowSelectCondition("CLXX_QCPL");
}
//加载查询条件
function LoadDistrictCondition(array, type) {
    type = "FWFW";
    $("#div_condition_body_" + type).html('');
    var html = "";
    html += '<ul id="ul_condition_body_' + type + '" class="ul_condition_body">';
    html += '<li class="li_condition_body_first">区域</li>';
    html += '<li class="li_condition_body li_condition_body_active" onclick="SelectCondition(this)">全部</li>';
    for (var i = 0; i < array.length; i++) {
        html += '<li class="li_condition_body" onclick="SelectCondition(this)">' + array[i].CODENAME + '</li>';
    }
    html += '</ul>';
    $("#div_condition_body_" + type).append(html);
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex); var condition = GetAllCondition("LB,PP,FWFW");
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
    if (obj.PHOTOS.length > 0) {
        html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'CLXX_QCPL\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
        html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    } else {
        html += ('<img class="img_li_body_left" src="' + getRootPath() + "/Areas/Business/Css/images/HTGL/no_image.png?j=" + Math.random() + '" />');
    }
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'CLXX_QCPL\',\'' + obj.ID + '\')">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_nr">' + obj.BCMSString.replace(/<\/?.+?>/g, "") + '</p>');
    html += ('<p class="p_li_body_left_center_dz">' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right">' + GetJG(obj.JG, "元") + '</p>');
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
    html += ('<li onclick="OpenXXXX(\'CLXX_QCPL\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT  + '</p>');
    html += ('<p class="p_li_body_right_jg">' + GetJG(obj.JG,'元')+'</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}