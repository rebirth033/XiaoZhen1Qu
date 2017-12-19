var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadSWFWCondition();
    LoadHot("SWFWXX_PHZP");
});
//加载条件
function LoadSWFWCondition() {
    LoadConditionByTypeNames("'喷绘招牌类别'", "CODES_SWFW", "类别", "LB", "15");
    LoadBody("SWFWXX_PHZP", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "类别" && (obj.innerHTML !== "标牌" && obj.innerHTML !== "LED显示屏" && obj.innerHTML !== "条幅/锦旗/奖牌")) {
        LoadConditionByParentID(obj.id, "CODES_SWFW", "小类", "XL", 15);
        if (obj.innerHTML === "灯箱/招牌") {
            LoadConditionByTypeNames("'灯箱/招牌材质','灯箱/招牌工艺','是否发光'", "CODES_SWFW", "材质,工艺,是否发光", "CZ,GY,SFFG", "15,15,15");
        }
        else {
            $("#ul_condition_body_CZ").remove();
            $("#ul_condition_body_YT").remove();
            $("#ul_condition_body_GN").remove();
            $("#ul_condition_body_GY").remove();
            $("#ul_condition_body_SFFG").remove();
        }
    }
    if (name === "类别" && (obj.innerHTML === "标牌" || obj.innerHTML === "LED显示屏" || obj.innerHTML === "条幅/锦旗/奖牌")) {
        $("#ul_condition_body_XL").remove();
        if (obj.innerHTML === "标牌") {
            LoadConditionByTypeNames("'标牌用途','标牌功能','标牌材质'", "CODES_SWFW", "用途,功能,材质", "YT,GN,CZ", "15,15,15");
        }
        else {
            $("#ul_condition_body_CZ").remove();
            $("#ul_condition_body_YT").remove();
            $("#ul_condition_body_GN").remove();
            $("#ul_condition_body_GY").remove();
            $("#ul_condition_body_SFFG").remove();
        }
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("SWFWXX_PHZP", currentIndex);
    ShowSelectCondition("SWFWXX_PHZP");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("LB,XL,CZ,GY,SFFG,QY");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFWCX/LoadSWFWXX",
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
//加载单条信息
function LoadInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left" onclick="OpenXXXX(\'SWFWXX_PHZP\',\'' + obj.ID + '\')">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_nr">' + obj.BCMSString.replace(/<\/?.+?>/g, "") + '</p>');
    html += ('<p class="p_li_body_left_center_dz">' + obj.QY + '-' + obj.DD + '</p>');
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
        url: getRootPath() + "/Business/SWFWCX/LoadSWFWXX",
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
    html += ('<li onclick="OpenXXXX(\'SWFWCX_SWFW\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}