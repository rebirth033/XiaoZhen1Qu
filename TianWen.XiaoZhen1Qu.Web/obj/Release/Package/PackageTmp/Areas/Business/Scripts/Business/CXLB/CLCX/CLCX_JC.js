var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadCLCondition();
    ToggleCondition();
    LoadHot("CLXX_JC");
});
//加载条件
function LoadCLCondition() {
    LoadConditionByTypeNames("'轿车品牌','轿车价格','轿车车龄','轿车排量','轿车里程','轿车变速箱','轿车颜色'", "CODES_CL", "品牌,价格,车龄,排量,里程,变速箱,颜色", "PP,JG,CL,PL,LC,BSX,CLYS", "100,100,100,100,100,100,100");
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
                if (typenames.indexOf("轿车品牌") !== -1)
                    LoadCondition(xml.jclist, "品牌", "PP", 100);
                LoadURLCondition();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载URL查询条件
function LoadURLCondition() {
    if (getUrlParam("JG") !== null)
        SelectURLCondition(getUrlParam("JG"));
    else if (getUrlParam("PP") !== null) {
        SelectURLCondition(getUrlParam("PP"));
        LoadConditionByParentID(getUrlParam("PP"), "CODES_CL_JC", "车系", "CX");
    }
    else if (getUrlParam("QY") !== null)
        SelectURLCondition(getUrlParam("QY"));
    else
        LoadBody("CLXX_JC", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "品牌") {
        LoadConditionByParentID(obj.id, "CODES_CL_JC", "车系", "CX", 100);
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("CLXX_JC", currentIndex);
    ShowSelectCondition("CLXX_JC");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("CLXX_JC", currentIndex);
    ShowSelectCondition("CLXX_JC");
}
//展开收缩条件
function ToggleCondition() {
    if ($("#span_condition_toggle").html().indexOf("更多") !== -1) {
        $(".div_condition").css("height", "auto").css("overflow", "visible");
        $("#span_condition_toggle").html($("#span_condition_toggle").html().replace("更多", "精简"));
        $("#i_condition_tottle").css("background-image", "url(" + getRootPath() + "/areas/business/css/images/head_nav_up.png)");
    }
    else {
        $(".div_condition").css("height", "250px").css("overflow", "hidden");
        $("#span_condition_toggle").html($("#span_condition_toggle").html().replace("精简", "更多"));
        $("#i_condition_tottle").css("background-image", "url(" + getRootPath() + "/areas/business/css/images/head_nav_down.png)");
    }
}
//加载查询条件
function LoadCondition(array, name, id, length) {
    $("#ul_condition_body_" + id).remove();
    var html = "";
    html += '<ul id="ul_condition_body_' + id + '" class="ul_condition_body" style="height:auto;">';
    if (name === "类别" || name === "小类" || name === "品牌" || name === "车系")
        html += '<li id="li_condition_body_first_' + id + '" class="li_condition_body_first">' + name + '</li>';
    else
        html += '<li class="li_condition_body_first">' + name + '</li>';
    html += '<li id="0" class="li_condition_body li_condition_body_active" onclick="SelectCondition(this,\'' + name + '\')">全部</li>';
    for (var i = 0; i < (array.length > length ? length : array.length) ; i++) {
        html += '<li id="' + array[i].CODEID + '" class="li_condition_body" onclick="SelectCondition(this,\'' + name + '\')">' + array[i].CODENAME + '</li>';
    }
    html += '</ul>';
    $("#div_condition_body_" + id).append(html);
    if(name === "车系")
        $("#li_condition_body_first_" + id).css("height", (parseInt($("#div_condition_body_" + id).css("height")) - 0));
    else
        $("#li_condition_body_first_" + id).css("height", (parseInt($("#div_condition_body_" + id).css("height")) - 20));
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("PP,CX,JG,PL,LC,BSX,CLYS,SF");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/CLCX/LoadCLXX",
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
                    LoadCL_JCInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载车辆_轿车单条信息
function LoadCL_JCInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left" onclick="OpenXXXX(\'CLXX_JC\',\'' + obj.ID + '\')">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs font_size16">' + obj.SPNF + ' / ' + obj.XSLC + '万公里' + ' / ' + '2.0升' + ' / ' + '自动' + '</p>');
    html += ('<p class="p_li_body_left_center_dz font_size16">' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
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
    html += ('<li onclick="OpenXXXX(\'CLXX_JC\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.SPNF + ' / ' + '2.0升' + ' / ' + '自动' + '</p>');
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
    LoadBody("CLXX_JC", 1);
}