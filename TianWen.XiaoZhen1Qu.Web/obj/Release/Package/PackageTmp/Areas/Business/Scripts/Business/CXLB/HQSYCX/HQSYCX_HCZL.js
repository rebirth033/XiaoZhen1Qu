﻿var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadHQSYCondition();
    LoadHot("HQSYXX_HCZL");
    LoadJCPP();
});
//加载条件
function LoadHQSYCondition() {
    LoadConditionByTypeNames("'婚车租赁价格','婚车品牌','婚车颜色','婚车租赁套餐出租'", "CODES_HQSY", "价格,婚车品牌,婚车颜色.套餐出租", "JGFW,TCPP,HCYS,TCCZ", "100,100,100,100");
}
//加载URL查询条件
function LoadURLCondition() {
    if (getUrlParam("TCPP") !== null)
        SelectURLCondition(getUrlParam("TCPP"));
    else if (getUrlParam("QY") !== null)
        SelectURLCondition(getUrlParam("QY"));
    else
        LoadBody("HQSYXX_HCZL", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("HQSYXX_HCZL", currentIndex);
    ShowSelectCondition("HQSYXX_HCZL");
}
//选择品牌条件
function SelectPPCondition(obj) {

    $("#ul_condition_body_TCPP").find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(".li_condition_body_more").remove();
    $("#li_condition_body_more").remove();

    var hasPP = 0;
    $("#ul_condition_body_TCPP").find(".li_condition_body").each(function () {
        if (this.id == obj.id) {
            hasPP = 1;
        }
    });
    if (hasPP === 0)
        $("#ul_condition_body_TCPP").append('<li class="li_condition_body li_condition_body_more" id="' + obj.id + '" onclick="SelectCondition(this,\'品牌\')">' + obj.innerHTML + '</li>');
    $("#ul_condition_body_TCPP").append('<li id="li_condition_body_more" class="li_condition_body" onclick="MorePP()" style="color:#2274e0;">全部品牌<img id="span_select_arrow_blue" class="span_select_arrow_blue" /></li>');

    $("#" + obj.id).addClass("li_condition_body_active");
    $("#span_select_arrow_blue").attr("src", getRootPath() + "/Areas/Business/Css/images/arrow_up_blue.png");
    LoadBody("HQSYXX_HCZL", currentIndex);
    ShowSelectCondition("HQSYXX_HCZL");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("HQSYXX_HCZL", currentIndex);
    ShowSelectCondition("HQSYXX_HCZL");
}
//加载查询条件
function LoadCondition(array, name, id, length) {
    $("#ul_condition_body_" + id).remove();
    var html = "";
    html += '<ul id="ul_condition_body_' + id + '" class="ul_condition_body" style="height:auto;">';
    if (name === "婚车品牌" || name === "车系")
        html += '<li id="li_condition_body_first_' + id + '" class="li_condition_body_first">' + name + '</li>';
    else
        html += '<li class="li_condition_body_first">' + name + '</li>';
    html += '<li id="0" class="li_condition_body li_condition_body_active" onclick="SelectCondition(this,\'' + name + '\')">全部</li>';
    for (var i = 0; i < (array.length > length ? length : array.length) ; i++) {
        html += '<li id="' + array[i].CODEID + '" class="li_condition_body" onclick="SelectCondition(this,\'' + name + '\')">' + array[i].CODENAME + '</li>';
    }
    if (name === "婚车品牌")
        html += '<li id="li_condition_body_more" class="li_condition_body" onclick="MorePP()" style="color:#2274e0;">全部品牌<img id="span_select_arrow_blue" class="span_select_arrow_blue" /></li>';
    html += '</ul>';
    $("#div_condition_body_" + id).append(html);
    if(name === "婚车品牌")
        $("#span_select_arrow_blue").attr("src", getRootPath() + "/Areas/Business/Css/images/arrow_down_blue.png");

    $("#li_condition_body_first_" + id).css("height", (parseInt($("#div_condition_body_" + id).css("height")) - 10));
}
//更多品牌
function MorePP() {
    if ($("#span_select_arrow_blue").attr("src").indexOf('down') !== -1) {
        $("#span_select_arrow_blue").attr("src", getRootPath() + "/Areas/Business/Css/images/arrow_up_blue.png" + "?j=" + Math.random());
        $(".div_row_right_jcpp_item").css("display", "block");
    }
    else {
        $("#span_select_arrow_blue").attr("src", getRootPath() + "/Areas/Business/Css/images/arrow_down_blue.png" + "?j=" + Math.random());
        $(".div_row_right_jcpp_item").css("display", "none");
    }
    GoToBQ('A');
}
//加载品牌名称
function LoadJCPP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "婚车品牌",
            TBName: "CODES_HQSY"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_row_right_jcpp_first").html('');
                var html = "";
                html += '<div class="div_row_right_jcpp_first_left">';
                html += '<ul class="ul_row_right_jcpp_first_left">';
                for (var i = 0; i < BQArray.length; i++) {
                    var count = 0;
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            count++;
                    }
                    if (count !== 0)
                        html += '<li onmouseover="GoToBQ(\'' + BQArray[i] + '\')" class="li_row_right_jcpp_first_left">' + BQArray[i] + '</li>';
                }
                html += '</ul>';
                html += '</div>';

                html += '<div class="div_row_right_jcpp_first_right">';

                for (var i = 0; i < BQArray.length; i++) {
                    html += '<ul id="ul_row_right_jcpp_first_right_' + BQArray[i] + '" class="ul_row_right_jcpp_first_right">';
                    var count = 0;
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            count++;
                    }
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            html += '<li id="' + xml.list[j].CODEID + '" onclick="SelectPPCondition(this)" class="li_row_right_jcpp_first_right_value">' + xml.list[j].CODENAME + '</li>';
                    }
                    html += '</ul>';
                }

                html += '</div>';

                $("#div_row_right_jcpp_first").append(html);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//跳转到标签页
function GoToBQ(BQ) {
    $(".ul_row_right_jcpp_first_right").css("display", "none");
    $("#ul_row_right_jcpp_first_right_" + BQ).css("display", "block");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("JGFW,TCPP,HCYS,TCCZ,QY");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/HQSYCX/LoadHQSYXX",
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
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'HQSYXX_HCZL\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'HQSYXX_HCZL\',\'' + obj.ID + '\')">' + obj.BT + '</p>');
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
        url: getRootPath() + "/HQSYCX/LoadHQSYXX",
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
    html += ('<li onclick="OpenXXXX(\'HQSYXX_HQSY\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + ValidateNull(obj.QY) + ' - ' + ValidateNull(obj.DD) + '</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}