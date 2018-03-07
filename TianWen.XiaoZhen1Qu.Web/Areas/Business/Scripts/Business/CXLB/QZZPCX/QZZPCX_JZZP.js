var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadJZZPCondition();
    LoadHot("QZZPXX_JZZP");
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
                html += ('<li class="li_nav_font">信息小镇</li>');
                html += ('<li class="li_nav_split">></li>');
                title += "信息小镇";
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
                        html += ('<li class="li_nav_font">兼职招聘</li>');
                        $("#li_body_head_first").html(xml.xzq + "兼职招聘");
                        title += "_" + xml.xzq + "兼职招聘";
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
function LoadJZZPCondition() {
    LoadConditionByTypeNames("'兼职类别'", "CODES_QZZP", "类别", "JZLB", "100");
}
//加载URL查询条件
function LoadURLCondition() {
    if (getUrlParam("JZLB") !== null)
        SelectURLCondition(getUrlParam("JZLB"));
    else
        LoadBody("QZZPXX_JZZP", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("QZZPXX_JZZP", currentIndex);
    ShowSelectCondition("QZZPXX_JZZP");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("QZZPXX_JZZP", currentIndex);
    ShowSelectCondition("QZZPXX_JZZP");
}
//根据TYPENAME获取字典表(私有)
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
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("JZLB,QY");
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
    html += ('<li class="li_body_left" onclick="OpenXXXX(\'QZZPXX_JZZP\',\'' + obj.ID + '\')">');
    html += ('<div class="div_li_body_left_left">' + obj.XZ + obj.XZDW  + ' </div>');
    html += ('<div class="div_li_body_left_center">' + obj.BT + '</div>');
    html += ('<div class="div_li_body_left_right">' + obj.ZXGXSJ.ToString("yyyy年MM月dd日") + '</div>');
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
    html += ('<li onclick="OpenXXXX(\'QZZPXX_JZZP\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + "服务项目:" + obj.LB + '</p>');
    html += ('<p class="p_li_body_right_cs">' + ValidateNull(obj.QY) + '-' + ValidateNull(obj.DD) + '</p>');
    html += ('<p class="p_li_body_right_jg">' + GetJG(obj.JG, '元') + '</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}