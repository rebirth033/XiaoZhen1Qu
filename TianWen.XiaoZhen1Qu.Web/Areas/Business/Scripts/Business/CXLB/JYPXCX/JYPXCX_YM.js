var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadJYPXCondition();
    LoadHot("JYPXXX_YM");
    LoadGJ();
});
//加载条件
function LoadJYPXCondition() {
    LoadConditionByTypeNames("'留学国家','移民类别'", "CODES_JYPX", "留学国家,移民类别", "GJ,YMLB", "100,100");
    LoadBody("JYPXXX_YM", currentIndex);
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
        LoadBody("JYPXXX_YM", currentIndex);
}
function LoadCondition(array, name, id, length) {
    $("#ul_condition_body_" + id).remove();
    var html = "";
    html += '<ul id="ul_condition_body_' + id + '" class="ul_condition_body" style="height:auto;">';
    if (name === "留学国家")
        html += '<li id="li_condition_body_first_' + id + '" class="li_condition_body_first">' + name + '</li>';
    else
        html += '<li class="li_condition_body_first">' + name + '</li>';
    html += '<li id="0" class="li_condition_body li_condition_body_active" onclick="SelectCondition(this,\'' + name + '\')">全部</li>';
    for (var i = 0; i < (array.length > length ? length : array.length) ; i++) {
        html += '<li id="' + array[i].CODEID + '" class="li_condition_body" onclick="SelectCondition(this,\'' + name + '\')">' + array[i].CODENAME + '</li>';
    }
    if (name === "留学国家")
        html += '<li id="li_condition_body_more" class="li_condition_body" onclick="MoreGJ()" style="color:#2274e0;">全部国家<img id="span_select_arrow_blue" class="span_select_arrow_blue" /></li>';
    html += '</ul>';
    $("#div_condition_body_" + id).append(html);
    if(name === "留学国家")
        $("#span_select_arrow_blue").attr("src", getRootPath() + "/Areas/Business/Css/images/arrow_down_blue.png");

    $("#li_condition_body_first_" + id).css("height", (parseInt($("#div_condition_body_" + id).css("height")) - 10));
}
//更多国家
function MoreGJ() {
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
//加载国家
function LoadGJ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "留学国家",
            TBName: "CODES_JYPX"
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
                            html += '<li id="' + xml.list[j].CODEID + '" onclick="SelectGJCondition(this)" class="li_row_right_jcpp_first_right_value">' + xml.list[j].CODENAME + '</li>';
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
//选择条件
function SelectCondition(obj, name) {
    if (name === "类别" && (obj.innerHTML !== "干锅" && obj.innerHTML !== "中餐" && obj.innerHTML !== "粥店")) {
        LoadConditionByParentID(obj.id, "CODES_JYPX", "小类", "XL",100);
    }
    if (name === "类别" && (obj.innerHTML === "干锅" || obj.innerHTML === "中餐" || obj.innerHTML === "粥店")) {
        $("#ul_condition_body_XL").remove();
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("JYPXXX_YM", currentIndex);
    ShowSelectCondition("JYPXXX_YM");
}
//选择品种条件
function SelectGJCondition(obj) {

    $("#ul_condition_body_GJ").find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(".li_condition_body_more").remove();
    $("#li_condition_body_more").remove();

    var hasPP = 0;
    $("#ul_condition_body_GJ").find(".li_condition_body").each(function () {
        if (this.id == obj.id) {
            hasPP = 1;
        }
    });
    if (hasPP === 0)
        $("#ul_condition_body_GJ").append('<li class="li_condition_body li_condition_body_more" id="' + obj.id + '" onclick="SelectCondition(this,\'国家\')">' + obj.innerHTML + '</li>');
    $("#ul_condition_body_GJ").append('<li id="li_condition_body_more" class="li_condition_body" onclick="MoreGJ()" style="color:#2274e0;">全部国家<img id="span_select_arrow_blue" class="span_select_arrow_blue" /></li>');

    $("#" + obj.id).addClass("li_condition_body_active");
    $("#span_select_arrow_blue").attr("src", getRootPath() + "/Areas/Business/Css/images/arrow_up_blue.png");
    LoadBody("JYPXXX_YM", currentIndex);
    ShowSelectCondition("JYPXXX_YM");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("JYPXXX_YM", currentIndex);
    ShowSelectCondition("JYPXXX_YM");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("GJ,YMLB,QY");
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
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'JYPXXX_YM\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'JYPXXX_YM\',\'' + obj.ID + '\')">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_nr">' + obj.BCMSString.replace(/<\/?.+?>/g, "") + '</p>');
    html += ('<p class="p_li_body_left_center_dz">' + ValidateNull(obj.QY) + ' - ' + ValidateNull(obj.DD) + '</p>');
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
    html += ('<li onclick="OpenXXXX(\'JYPXCX_JYPX\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + ValidateNull(obj.QY) + ' - ' + ValidateNull(obj.DD) + '</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}