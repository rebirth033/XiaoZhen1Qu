var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadQZZPCondition();
    LoadHot("QZZPXX_QZZP");
});
//获取头部导航
function GetHeadNav() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/SY/LoadSY_ML",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "", title = "";
                html += ('<ul class="ul_nav">');
                html += ('<li class="li_nav_font">风铃网</li>');
                html += ('<li class="li_nav_split">></li>');
                title += "风铃网";
                for (var i = 0; i < xml.list.length; i++) {
                    if (xml.list[i].LBID === parseInt(getUrlParam("LBID"))) {
                        html += ('<li class="li_nav_font">' + xml.xzq + xml.list[i].TYPESHOWNAME + '</li>');
                        title += "_" + xml.xzq + xml.list[i].TYPESHOWNAME;
                        break;
                    }
                }
                html += ('<li class="li_nav_split">></li>');
                for (var i = 0; i < xml.list.length; i++) {
                    if (xml.list[i].LBID === parseInt(getUrlParam("LBID"))) {
                        html += ('<li class="li_nav_font">全职招聘</li>');
                        $("#li_body_head_first").html(xml.xzq + "全职招聘");
                        title += "_" + xml.xzq + "全职招聘";
                        break;
                    }
                }
                html += ('</ul>');
                $("#divNav").html(html);
                $("#title").html(title);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载条件
function LoadQZZPCondition() {
    LoadConditionByTypeNames("'" + (getUrlParam("ZWLB") === null ? "行业" : getUrlParam("ZWLB")) + "类别','每月薪资','职位福利'", "CODES_QZZP", "类别,薪资,福利", "ZWLB,MYXZ,ZWFL", "100,100,100");
}
//加载URL查询条件
function LoadURLCondition() {
    if (getUrlParam("ZWFL") !== null)
        SelectURLCondition(getUrlParam("ZWFL"));
    else if (getUrlParam("ZWMC") !== null)
        SelectURLCondition(getUrlParam("ZWMC"));
    else
        LoadBody("QZZPXX_QZZP", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("QZZPXX_QZZP", currentIndex);
    ShowSelectCondition("QZZPXX_QZZP");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("QZZPXX_QZZP", currentIndex);
    ShowSelectCondition("QZZPXX_QZZP");
}
//加载查询条件
function LoadCondition(array, name, id, length) {
    $("#ul_condition_body_" + id).remove();
    var html = "";
    html += '<ul id="ul_condition_body_' + id + '" class="ul_condition_body">';
    if (name === "类别")
        html += '<li id="li_condition_body_first_' + id + '" class="li_condition_body_first">' + name + '</li>';
    else
        html += '<li class="li_condition_body_first">' + name + '</li>';
    html += '<li id="0" class="li_condition_body li_condition_body_active" onclick="SelectCondition(this,\'' + name + '\')">全部</li>';
    for (var i = 0; i < (array.length > length ? length : array.length) ; i++) {
        html += '<li id="' + array[i].CODEID + '" class="li_condition_body" onclick="SelectCondition(this,\'' + name + '\')">' + array[i].CODENAME + '</li>';
    }
    html += '</ul>';
    $("#div_condition_body_" + id).append(html);
    $("#li_condition_body_first_" + id).css("height", (parseInt($("#div_condition_body_" + id).css("height")) - 15));
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("ZWMC,MYXZ,ZWFL,QY");
    condition += ",ZWLB:" + getUrlParam("ZWLB");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/QZZPCX/LoadQZZPXX",
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
    html += ('<span class="span_li_body_left_left_top" onclick="OpenXXXX(\'QZZPXX_QZZP\',\'' + obj.ID + '\')">' + obj.BT + '</span>');
    html += ('<span class="span_li_body_left_left_middle">' + obj.ZWMC + '</span><span class="span_li_body_left_left_middle">|</span><span class="span_li_body_left_left_middle">' + obj.XLYQ + '</span><span class="span_li_body_left_left_middle">|</span><span class="span_li_body_left_left_middle">' + obj.GZNX + '</span></div>');
    html += ('<div class="div_li_body_left_center">' + obj.GSMC + '</div>');
    html += ('<div class="div_li_body_left_right">' + obj.MYXZ + '</div>');
    //.ToString("MM月dd日")
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载热门推荐
function LoadHot(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/QZZPCX/LoadQZZPXX",
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
                    //LoadHotInfo(xml.list[i]);
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
    html += ('<li onclick="OpenXXXX(\'QZZPXX_QZZP\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + ValidateNull(obj.QY) + '-' + ValidateNull(obj.DD) + '</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}