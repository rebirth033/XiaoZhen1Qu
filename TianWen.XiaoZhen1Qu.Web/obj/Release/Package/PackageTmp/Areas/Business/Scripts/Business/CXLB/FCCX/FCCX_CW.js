﻿var currentIndex = 1;
$(document).ready(function () {
    $(".li_condition_head:eq(0)").each(function () { $(this).css("background-color", "#ffffff").css("color", "#bc6ba6"); });
    BindConditionNav();
    BindBodyNav();
    LoadCZCondition();
});
//绑定查询条件导航
function BindConditionNav() {
    $(".li_condition_head").bind("click", function () {
        $(".li_condition_head").each(function (i) {
            $(this).css("background-color", "#eeeff1").css("color", "#999999");
        });
        $(this).css("background-color", "#ffffff").css("color", "#bc6ba6");
        if ($(this).html() === "出租") {
            LoadCZCondition();
        } else {
            LoadCSCondition();
        }
    });
}
//加载出租查询条件
function LoadCZCondition() {
    RemoveCondition("QY,ZJ,SJ,MJ");
    LoadConditionByTypeNames("'车位租金','车位面积'", "CODES_FC", "租金,面积", "ZJ,MJ", "100,100");
}
//加载出售查询条件
function LoadCSCondition() {
    RemoveCondition("QY,ZJ,SJ,MJ");
    LoadConditionByTypeNames("'车位售价','车位面积'", "CODES_FC", "售价,面积", "SJ,MJ", "100,100");
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
    if (getUrlParam("MJ") !== null)
        SelectURLCondition(getUrlParam("MJ"));
    else {
        LoadBody("FCXX_CW", currentIndex);
    }
    LoadHot("FCXX_CW");
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "QY") {
        LoadConditionByParentID(obj.id, "CODES_DISTRICT", "地段", "DD");
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("FCXX_CW", currentIndex);
    ShowSelectCondition("FCXX_CW");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("FCXX_CW", currentIndex);
    ShowSelectCondition("FCXX_CW");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("MJ,QY,DD,SF");
    if (GetNavCondition() === "出租") {
        condition += ",GQ:出租";
        if (GetCondition("ZJ") !== "")
            condition += ",ZJ:" + GetCondition("ZJ");
    }
    if (GetNavCondition() === "出售") {
        condition += ",GQ:出售";
        if (GetCondition("SJ") !== "")
            condition += ",SJ:" + GetCondition("SJ");
    }
    $.ajax({
        type: "POST",
        url: getRootPath() + "/FCCX/LoadFCXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: LTrim(condition, ','),
            PageSize: 100,
            PageIndex: PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#ul_body_left").html('');
                LoadPage(TYPE, xml.PageCount);
                for (var i = 0; i < xml.list.length; i++) {
                    if (GetNavCondition() === "出租")
                        LoadCZInfo(xml.list[i]);
                    else
                        LoadCSInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载出租单条信息
function LoadCZInfo(obj) {
    var html = ""; 
    html += ('<li class="li_body_left">');
    html += ('<div class="div_li_body_left_left">');
    if (obj.PHOTOS.length > 0) {
        html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'FCXX_CW\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
        html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    } else {
        html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'FCXX_CW\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Css/images/HTGL/no_image.png?j=" + Math.random() + '" />');
    }
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'FCXX_CW\',\'' + obj.ID + '\')">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs">' + obj.MJ + '平米</p>');
    html += ('<p class="p_li_body_left_center_dz">' + '[' + ValidateNull(obj.QY) + ' - ' + ValidateNull(obj.DD) + '] ' + obj.JTDZ + ' ' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right">' + GetJG(obj.ZJ, obj.ZJDW) + '</p>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载出售单条信息
function LoadCSInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left" onclick="OpenXXXX(\'FCXX_CW\',\'' + obj.ID + '\')">');
    html += ('<div class="div_li_body_left_left">');
    if (obj.PHOTOS.length > 0) {
        html += ('<img class="img_li_body_left" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
        html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    } else {
        html += ('<img class="img_li_body_left" src="' + getRootPath() + "/Areas/Business/Css/images/HTGL/no_image.png?j=" + Math.random() + '" />');
    }
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs">' + obj.MJ + '平米</p>');
    html += ('<p class="p_li_body_left_center_dz">' + '[' + ValidateNull(obj.QY) + ' - ' + ValidateNull(obj.DD) + '] ' + obj.JTDZ + ' ' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right">' + GetJG(obj.SJ, obj.ZJDW) + '</p>');
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
            Condition: "STATUS:1,ISHOT:1,GQ:" + GetNavCondition(),
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
    html += ('<li onclick="OpenXXXX(\'FCXX_CW\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT+ '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.MJ + '平米</p>');
    html += ('<p class="p_li_body_right_jg">' + (GetNavCondition() === "出租" ? GetJG(obj.ZJ, obj.ZJDW) : GetJG(obj.SJ, obj.ZJDW)) + '</p>');
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
    LoadBody("FCXX_CW", 1);
}