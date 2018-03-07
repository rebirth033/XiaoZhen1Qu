var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadSWFWCondition();
    LoadHot("SWFWXX_YSBZ");
});
//加载条件
function LoadSWFWCondition() {
    LoadConditionByTypeNames("'印刷包装类别'", "CODES_SWFW", "类别", "LB", "100");
}
//加载URL查询条件
function LoadURLCondition() {
    if (getUrlParam("LB") !== null) {
        SelectURLCondition(getUrlParam("LB"));
        LoadConditionByParentID(getUrlParam("LB"), "CODES_SWFW", "小类", "XL");
    }
    else if (getUrlParam("QY") !== null)
        SelectURLCondition(getUrlParam("QY"));
    else
        LoadBody("SWFWXX_YSBZ", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "类别" && (obj.innerHTML === "纸类印刷" || obj.innerHTML === "宣传资料印刷")) {
        LoadConditionByParentID(obj.id, "CODES_SWFW", "小类", "XL",100);
    }
    if (name === "类别" && (obj.innerHTML !== "纸类印刷" && obj.innerHTML !== "宣传资料印刷")) {
        $("#ul_condition_body_XL").remove();
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("SWFWXX_YSBZ", currentIndex);
    ShowSelectCondition("SWFWXX_YSBZ");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("SWFWXX_YSBZ", currentIndex);
    ShowSelectCondition("SWFWXX_YSBZ");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("LB,XL,TZJE,QY");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/SWFWCX/LoadSWFWXX",
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
    html += ('<li class="li_body_left" onclick="OpenXXXX(\'SWFWXX_YSBZ\',\'' + obj.ID + '\')">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_nr">' + obj.BCMSString.replace(/<\/?.+?>/g, "") + '</p>');
    html += ('<p class="p_li_body_left_center_dz">' + ValidateNull(obj.QY) + '-' + ValidateNull(obj.DD) + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_li_body_left_right">联系商家</span></p>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载热门推荐
function LoadHot(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/SWFWCX/LoadSWFWXX",
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
    html += ('<li onclick="OpenXXXX(\'SWFWXX_YSBZ\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + ValidateNull(obj.QY) + '-' + ValidateNull(obj.DD) + '</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}