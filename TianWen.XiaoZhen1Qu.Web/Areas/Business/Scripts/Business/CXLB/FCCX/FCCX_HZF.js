var currentIndex = 1;
$(document).ready(function () {
    $(".li_condition_head:eq(0)").each(function () { $(this).css("background-color", "#ffffff"); });
    BindBodyNav();
    LoadFCCondition();
    LoadHot("FCXX_HZF");
    BindClick("CX");
    BindClick("ZXQK");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "CX") {
            LoadCODESByTYPENAME("朝向", "CX", "CODES_FC", Bind, "CX", "CX", "");
        }
        if (type === "ZXQK") {
            LoadCODESByTYPENAME("装修情况", "ZXQK", "CODES_FC", Bind, "ZXQK", "ZXQK", "");
        }
        if (type === "ZZLX") {
            LoadCODESByTYPENAME("住宅类型", "ZZLX", "CODES_FC", Bind, "FWQK", "ZZLX", "");
        }
    });
}
//加载房产查询条件
function LoadFCCondition() {
    LoadConditionByTypeNames("'整租房租金','出租间类型'", "CODES_FC", "租金,类型", "ZJ,CZJLX", "100,100");
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
    if (getUrlParam("FWLD") !== null)
        SelectURLCondition(getUrlParam("FWLD"));
    else if (getUrlParam("ZJ") !== null)
        SelectURLCondition(getUrlParam("ZJ"));
    else if (getUrlParam("QY") !== null)
        SelectURLCondition(getUrlParam("QY"));
    else
        LoadBody("FCXX_HZF", currentIndex);
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
    LoadBody("FCXX_HZF", currentIndex);
    ShowSelectCondition("FCXX_HZF");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("FCXX_HZF", currentIndex);
    ShowSelectCondition("FCXX_HZF");
}
//选择下拉框
function SelectDropdown(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadBody("FCXX_HZF", currentIndex);
    ShowSelectCondition("FCXX_HZF");
}
//加载主体部分
function LoadBody(TYPE, PageIndex, OrderColumn, OrderType) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("CZJLX,ZJ,QY,DD,CX,ZXQK,SF");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/FCCX/LoadFCXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: condition,
            PageSize: 100,
            PageIndex: PageIndex,
            OrderColumn: OrderColumn,
            OrderType: OrderType
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
    html += ('<li class="li_body_left" onclick="OpenXXXX(\'FCXX_HZF\',\'' + obj.ID + '\')">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs">单间出租 / ' + obj.S + '室' + obj.T + '厅' + obj.W + '卫 / ' + obj.PFM + '平米 / ' + obj.ZXQK + ' / ' + obj.CX + ' / ' + obj.C + '层[共' + obj.GJC + '层]</p>');
    html += ('<p class="p_li_body_left_center_dz">' + obj.XQMC + ' ' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_zj">' + obj.ZJ + '</span>元/月</p>');
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
            Condition: "STATUS:1,ISHOT:1",
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
    html += ('<li onclick="OpenXXXX(\'FCXX_HZF\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.XQMC + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.S + '室 / ' + obj.PFM + '平米 / ' + obj.ZXQK + '</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.ZJ + '元/月</p>');
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
    LoadBody("FCXX_HZF", 1);
}
//根据条件排序
function OrderByCondition(type, obj) {
    ChangeCXItem(obj);
    var ordertype = "";
    if (type === "ZJ") {
        $("#li_body_head_sort_item_ZJ").find("i").each(function () {
            if ($(this).attr("class").indexOf("up") !== -1)
                ordertype = "ASC";
            else
                ordertype = "DESC";
        });
        LoadBody("FCXX_HZF", 1, "ZJ", ordertype);
    }
    else {
        $("#li_body_head_sort_item_SJ").find("i").each(function () {
            if ($(this).attr("class").indexOf("up") !== -1)
                ordertype = "ASC";
            else
                ordertype = "DESC";
        });
        LoadBody("FCXX_HZF", 1, "ZXGXSJ", ordertype);
    }
}
