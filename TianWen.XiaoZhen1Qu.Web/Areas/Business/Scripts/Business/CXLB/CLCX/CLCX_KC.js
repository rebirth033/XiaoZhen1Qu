﻿var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadCLCondition();
    LoadHot("CLXX_KC");
    LoadKCPP();
});
//加载条件
function LoadCLCondition() {
    LoadConditionByTypeNames("'客车品牌','客车价格'", "CODES_CL", "品牌,价格", "PP,JG", "100,100");
}
//加载URL查询条件
function LoadURLCondition() {
    if (getUrlParam("JG") !== null)
        SelectURLCondition(getUrlParam("JG"));
    else if (getUrlParam("PP") !== null){
        SelectURLCondition(getUrlParam("PP"));
        LoadConditionByParentID(getUrlParam("PP"), "CODES_CL", "车系", "CX");
    }
    else if (getUrlParam("QY") !== null)
        SelectURLCondition(getUrlParam("QY"));
    else
        LoadBody("CLXX_KC", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "品牌") {
        LoadConditionByParentID(obj.id, "CODES_CL", "车系", "CX");
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("CLXX_KC", currentIndex);
    ShowSelectCondition("CLXX_KC");
}
//选择品牌条件
function SelectPPCondition(obj) {

    LoadConditionByParentID(obj.id, "CODES_CL", "车系", "CX");

    $("#ul_condition_body_PP").find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(".li_condition_body_more").remove();
    $("#li_condition_body_more").remove();

    var hasPP = 0;
    $("#ul_condition_body_PP").find(".li_condition_body").each(function () {
        if (this.id == obj.id) {
            hasPP = 1;
        }
    });
    if (hasPP === 0)
        $("#ul_condition_body_PP").append('<li class="li_condition_body li_condition_body_more" id="' + obj.id + '" onclick="SelectCondition(this,\'品牌\')">' + obj.innerHTML + '</li>');
    $("#ul_condition_body_PP").append('<li id="li_condition_body_more" class="li_condition_body" onclick="MorePP()" style="color:#2274e0;">全部品牌<img id="span_select_arrow_blue" class="span_select_arrow_blue" /></li>');

    $("#" + obj.id).addClass("li_condition_body_active");
    $("#span_select_arrow_blue").attr("src", getRootPath() + "/Areas/Business/Css/images/arrow_up_blue.png");
    LoadBody("CLXX_KC", currentIndex);
    ShowSelectCondition("CLXX_KC");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("CLXX_KC", currentIndex);
    ShowSelectCondition("CLXX_KC");
}
//加载查询条件
function LoadCondition(array, name, id, length) {
    $("#ul_condition_body_" + id).remove();
    var html = "";
    html += '<ul id="ul_condition_body_' + id + '" class="ul_condition_body" style="height:auto;">';
    if (name === "类别" || name === "小类" || name === "品牌" || name === "车系" || name === "车型")
        html += '<li id="li_condition_body_first_' + id + '" class="li_condition_body_first">' + name + '</li>';
    else
        html += '<li class="li_condition_body_first">' + name + '</li>';
    html += '<li id="0" class="li_condition_body li_condition_body_active" onclick="SelectCondition(this,\'' + name + '\')">全部</li>';
    for (var i = 0; i < (array.length > length ? length : array.length) ; i++) {
        html += '<li id="' + array[i].CODEID + '" class="li_condition_body" onclick="SelectCondition(this,\'' + name + '\')">' + array[i].CODENAME + '</li>';
    }
    if (name === "品牌")
        html += '<li id="li_condition_body_more" class="li_condition_body" onclick="MorePP()" style="color:#2274e0;">全部品牌<img id="span_select_arrow_blue" class="span_select_arrow_blue" /></li>';
    html += '</ul>';
    $("#div_condition_body_" + id).append(html);
    if(name === "品牌")
        $("#span_select_arrow_blue").attr("src", getRootPath() + "/Areas/Business/Css/images/arrow_down_blue.png");
    $("#li_condition_body_first_" + id).css("height", (parseInt($("#div_condition_body_" + id).css("height")) - 20));
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
function LoadKCPP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "客车品牌",
            TBName: "CODES_CL"
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
    var condition = GetAllCondition("PP,CX,JG,QY,SF");
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
                    LoadCL_JCInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载单条信息
function LoadCL_JCInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'CLXX_KC\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'CLXX_KC\',\'' + obj.ID + '\')">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs">' + obj.PP.split(' ')[0] + ' / ' + obj.XSLC + '万公里' + ' / ' + obj.CLYS + ' / ' + obj.SPNF + obj.SPYF + '</p>');
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
    html += ('<li onclick="OpenXXXX(\'CLXX_KC\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.PP.split(' ')[0] + ' / ' + obj.CLYS + ' / ' + obj.SPNF + '</p>');
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
    LoadBody("CLXX_KC", 1);
}