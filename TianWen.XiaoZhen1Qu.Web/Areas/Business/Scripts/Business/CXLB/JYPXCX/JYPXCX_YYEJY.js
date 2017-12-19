var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadJYPXCondition();
    LoadHot("JYPXXX_YYEJY");
});
//加载条件
function LoadJYPXCondition() {
    LoadConditionByTypeNames("'婴幼儿教育类别','服务类型','婴幼儿教育办学性质'", "CODES_JYPX", "类别,服务类型,办学性质", "LB,FWLX,BXXZ", "15,15,15");
    LoadBody("JYPXXX_YYEJY", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "类别" && (obj.innerHTML !== "干锅" && obj.innerHTML !== "中餐" && obj.innerHTML !== "粥店")) {
        LoadConditionByParentID(obj.id, "CODES_JYPX", "小类", "XL",15);
    }
    if (name === "类别" && (obj.innerHTML === "干锅" || obj.innerHTML === "中餐" || obj.innerHTML === "粥店")) {
        $("#ul_condition_body_XL").remove();
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("JYPXXX_YYEJY", currentIndex);
    ShowSelectCondition("JYPXXX_YYEJY");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("LB,FWLX,BXXZ,QY");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/JYPXCX/LoadJYPXXX",
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
    html += ('<li class="li_body_left" onclick="OpenXXXX(\'JYPXXX_YYEJY\',\'' + obj.ID + '\')">');
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
        url: getRootPath() + "/Business/JYPXCX/LoadJYPXXX",
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
    html += ('<li onclick="OpenXXXX(\'JYPXCX_JYPX\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}