$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_condition").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_condition_toggle").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_condition_select").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $("#li_condition_head_qyzf").css("background-color", "#ffffff");
    $("#span_fbxx").bind("click", FBXX);
    $("#span_condition_toggle").bind("click", ToggleCondition);
    $("#div_condition_body").html('');
    GetHeadNav();
});
//获取头部导航
function GetHeadNav() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadSY_ML",
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
                        html += ('<li class="li_nav_font">' + xml.xzq + xml.list[i].LBNAME + '</li>');
                        if ($("#li_body_head_first").html() !== "转让")
                            $("#li_body_head_first").html(xml.xzq + xml.list[i].LBNAME + "");
                        title += "_" + xml.xzq + xml.list[i].LBNAME;
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
//绑定主体列表导航
function BindBodyNav() {
    $(".li_body_head:eq(0)").css("background-color", "#bc6ba6").css("color", "#ffffff").css("border", "none");
    $(".li_body_head").mouseover(function () {
        if ($(this).css("background-color") === "transparent")
            $(this).css("background-color", "#eaeaea");
    }).mouseleave(function () {
        if ($(this).css("background-color") === "rgb(234, 234, 234)")
            $(this).css("background-color", "transparent");
    });

    $(".li_body_head").bind("click", function () {
        $(".li_body_head").each(function () {
            $(this).css("border-top", "1px solid #cccccc").css("background-color", "transparent").css("border-left", "1px solid #cccccc").css("border-right", "1px solid #cccccc").css("color", "#999999");
        });
        $(this).css("background-color", "#bc6ba6").css("color", "#ffffff").css("border", "none");
    });
}
//列表排序绑定事件
function ChangeCXItem(obj) {
    $(".li_body_head_sort_item").each(function () {
        $(this).css("color", "rgb(51, 51, 51)");
        $(this).find("i").each(function () {
            if ($(this).attr("class").indexOf("up") !== -1)
                $(this).attr("class", "i_body_left_sort_up_gray");
            else
                $(this).attr("class", "i_body_left_sort_down_gray");
        });
    });
    if ($(obj).css("color") === "rgb(51, 51, 51)") {
        $(obj).css("color", "rgb(188, 107, 166)");
        $(obj).find("i").each(function () {
            if ($(this).attr("class").indexOf("up") !== -1)
                $(this).attr("class", "i_body_left_sort_down_orange");
            else
                $(this).attr("class", "i_body_left_sort_up_orange");
        });
    }
}
//显示筛选条件
function ShowSelectCondition(tbname) {
    $(".div_condition_select").css("display", "block");
    $("#ul_condition_select").html('<li class="li_condition_select_first">条件</li>');
    $(".li_condition_body").each(function () {
        if ($(this).css("color") === "rgb(188, 107, 166)" && $(this).html() !== "全部") {
            $("#ul_condition_select").append('<li onclick="DeleteSelect(this,\'' + tbname + '\')" class="li_condition_select"><span>' + $(this).html() + '</span><em>×</em></li>');
        }
    });
}
//绑定选择条件删除事件
function DeleteSelect(obj, tbname) {
    var select = obj.innerHTML;
    $(obj).css("display", "none");
    $(".li_condition_body").each(function () {
        if (select.indexOf($(this).html()) !== -1)
            $(this).parent().find(".li_condition_body").each(function (index) {
                if (index === 0) $(this).addClass("li_condition_body_active");
                else $(this).removeClass("li_condition_body_active");
            });
    });
    if (HasCondition() === "")
        $("#divConditionSelect").css("display", "none");
    LoadBody(tbname, currentIndex);
}
//获取查询条件
function GetCondition(type) {
    var value = "";
    $("#ul_condition_body_" + type).find(".li_condition_body").each(function () {
        if ($(this).css("color") === 'rgb(188, 107, 166)')
            value = $(this).html();
    });
    return value;
}
//获取所有查询条件
function GetAllCondition(conditions) {
    var array = conditions.split(',');
    var condition = "";
    for (var i = 0; i < array.length; i++) {
        if (GetCondition(array[i]) !== "")
            condition += array[i] + ":" + GetCondition(array[i]) + ",";
    }
    return RTrim(condition, ',');
}
//获取导航查询条件
function GetNavCondition() {
    var value = "";
    $(".li_condition_head").each(function () {
        if ($(this).css("background-color") === 'rgb(255, 255, 255)')
            value = $(this).html();
    });
    return value;
}
//是否有条件
function HasCondition() {
    var condition = "";
    $(".li_condition_body").each(function () {
        if (($(this).html() !== "不限" && $(this).html() !== "全部") && $(this).css("color") === "rgb(188, 107, 166)")
            condition += $(this).html();
    });
    return condition;
}
//展开收缩条件
function ToggleCondition() {
    if ($("#span_condition_toggle").html().indexOf("更多") !== -1) {
        $(".div_condition").css("height", "auto").css("overflow", "visible");
        $("#span_condition_toggle").html($("#span_condition_toggle").html().replace("更多", "精简"));
        $("#i_condition_tottle").css("background-image", "url(" + getRootPath() + "/areas/business/css/images/head_nav_up.png)");
    }
    else {
        $(".div_condition").css("height", "170px").css("overflow", "hidden");
        $("#span_condition_toggle").html($("#span_condition_toggle").html().replace("精简", "更多"));
        $("#i_condition_tottle").css("background-image", "url(" + getRootPath() + "/areas/business/css/images/head_nav_down1.png)");
    }
}
//加载分页
function LoadPage(typename, pagecount) {
    var index = parseInt(currentIndex);
    $("#div_main_info_bottom_fy").html('');
    if (index > 1) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + typename + '\',\'' + 1 + '\')" class="a_main_info_bottom_fy">首页</a>');
        $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + typename + '\',\'' + (index - 1) + '\')" class="a_main_info_bottom_fy">上一页</a>');
    }
    if (index < 5) {
        for (var i = 1; i <= pagecount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + typename + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i <= 9) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + typename + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }
    if (index >= 5 && index < pagecount - 4) {
        for (var i = 1; i <= pagecount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + typename + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i >= index - 4 && i <= index + 4) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + typename + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }
    if (index >= pagecount - 4 && pagecount > 4) {
        for (var i = 1; i <= pagecount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + typename + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i > pagecount - 9) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + typename + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }
    if (index < pagecount) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + typename + '\',\'' + (index + 1) + '\')" class="a_main_info_bottom_fy">下一页</a>');
        $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + typename + '\',\'' + pagecount + '\')" class="a_main_info_bottom_fy">尾页</a>');
    }
}
//根据TYPENAME获取字典表
function LoadConditionByTypeNames(typenames, table, names, ids, lengths) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAMES",
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
//根据PARENTID获取字典表
function LoadConditionByParentID(parentid, table, name, id, length) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: parentid,
            TBName: table
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#ul_condition_body_" + id).remove();
                if (parentid !== "0")
                    LoadCondition(xml.list, name, id, length);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载查询条件
function LoadCondition(array, name, id, length) {
    $("#ul_condition_body_" + id).remove();
    var html = "";
    html += '<ul id="ul_condition_body_' + id + '" class="ul_condition_body" style="height:auto;">';
    if (name === "类别" || name === "小类" || name === "品牌" || name === "车系" || name === "车型" || name === "驾照" || name === "品种" || name === "型号" || name === "语种" || name === "用途" || name === "婚车品牌")
        html += '<li id="li_condition_body_first_' + id + '" class="li_condition_body_first">' + name + '</li>';
    else
        html += '<li class="li_condition_body_first">' + name + '</li>';
    html += '<li id="0" class="li_condition_body li_condition_body_active" onclick="SelectCondition(this,\'' + name + '\')">全部</li>';
    for (var i = 0; i < (array.length > length ? length : array.length) ; i++) {
        html += '<li id="' + array[i].CODEID + '" class="li_condition_body" onclick="SelectCondition(this,\'' + name + '\')">' + array[i].CODENAME + '</li>';
    }
    html += '</ul>';
    $("#div_condition_body_" + id).append(html);
    $("#li_condition_body_first_" + id).css("height", (parseInt($("#div_condition_body_" + id).css("height")) - 20));
}
//设置条件
function SetCondition(type, value) {
    if (value !== null && value !== "") {
        $("#ul_condition_body_" + type).find(".li_condition_body").each(function () {
            $(this).removeClass("li_condition_body_active");
        });
        $("#ul_condition_body_" + type).find(".li_condition_body").each(function () {
            if ($(this).html() === value)
                $(this).addClass("li_condition_body_active");
        });
    }
}
//根据TYPENAME获取字典表
function LoadDistrict(name, code, type) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/GetDistrictBySuperCode",
        dataType: "json",
        data:
        {
            SuperCode: code
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadDistrictCondition(xml.list, type);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载查询条件
function LoadDistrictCondition(array, type) {
    $("#div_condition_body_" + type).html('');
    var html = "";
    html += '<ul id="ul_condition_body_' + type + '" class="ul_condition_body">';
    html += '<li id="li_condition_body_first_QY" class="li_condition_body_first">区域</li>';
    html += '<li class="li_condition_body li_condition_body_active" onclick="SelectCondition(this)">全部</li>';
    for (var i = 0; i < array.length; i++) {
        html += '<li id="' + array[i].CODEID + '" class="li_condition_body" onclick="SelectCondition(this)">' + array[i].CODENAME + '</li>';
    }
    html += '</ul>';
    $("#div_condition_body_" + type).append(html);
}
//发布信息
function FBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LBXZ/LoadLBByID",
        dataType: "json",
        data:
        {
            LBID: getUrlParam("LBID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.open(getRootPath() + "/Business/" + xml.list[0].FBYM.split('_')[0] + "/" + xml.list[0].FBYM + "?CLICKID=" + getUrlParam("LBID"));
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//删除查询条件
function RemoveCondition(list) {
    var conditions = list.split(',');
    for (var i = 0; i < conditions.length; i++)
        $("#ul_condition_body_" + conditions[i]).remove();
}
//加载价格
function GetJG(jg, dw) {
    if (jg === "面议")
        return '<span class="span_zj">面议</span>';
    else
        return '<span class="span_zj">' + jg + '</span>' + dw;
}
//打开详细页面
function OpenXXXX(TYPE, ID) {
    window.open(getRootPath() + "/Business/" + TYPE.split('_')[0] + "/" + TYPE + "?ID=" + ID + "&LBID=" + getUrlParam("LBID") + "&TYPE=" + TYPE);
}