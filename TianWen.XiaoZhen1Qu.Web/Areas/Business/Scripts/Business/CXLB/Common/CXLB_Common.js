$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_condition").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_condition_select").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $("#li_condition_head_qyzf").css("background-color", "#ffffff");
    $(".li_body_head:eq(0)").css("border-bottom", "2px solid #5bc0de").css("color", "#5bc0de").css("font-weight", "700");
    $("#span_fbxx").bind("click", OpenLBXZ);
    GetHeadNav();
    $("#div_condition_body").html('');
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
                var html = "";
                html += ('<ul class="ul_nav">');
                html += ('<li class="li_nav_font">信息小镇</li>');
                html += ('<li class="li_nav_split">></li>');
                html += ('<li class="li_nav_font">' + xml.xzq + '房产</li>');
                html += ('<li class="li_nav_split">></li>');
                for (var i = 0; i < xml.list.length; i++) {
                    if (xml.list[i].LBID === parseInt(getUrlParam("LBID")) && xml.list[i].CONDITION === null) {
                        html += ('<li class="li_nav_font">' + xml.xzq + xml.list[i].LBNAME + '</li>');
                        $("#li_body_head_first").html(xml.xzq + xml.list[i].LBNAME + "");
                    }
                }
                html += ('</ul>');
                $("#divNav").html(html);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//绑定查询条件导航
function BindConditionNav(type) {
    $(".li_condition_head").bind("click", function () {
        $(".li_condition_head").each(function (i) {
            $(this).css("background-color", "#eeeff1");
        });
        $(this).css("background-color", "#ffffff");
        if ($(this).html() === "出租") {
            LoadFCCondition();
            LoadBody(type, currentIndex);
        } else {
            LoadFCCondition();
            LoadBody(type, currentIndex);
        }
    });
}
//绑定主体列表导航
function BindBodyNav() {
    $(".li_body_head").bind("click", function () {
        $(".li_body_head").each(function () {
            $(this).css("border-bottom", "1px solid #cccccc").css("color", "#999999").css("font-weight", "normal");
        });
        $(this).css("border-bottom", "2px solid #5bc0de").css("color", "#5bc0de").css("font-weight", "700");
    });
}
//显示筛选条件
function ShowSelectCondition(tbname) {
    $(".div_condition_select").css("display", "block");
    $("#ul_condition_select").html('<li class="li_condition_select_first">筛选条件</li>');
    $(".li_condition_body").each(function () {
        if ($(this).css("color") === "rgb(91, 192, 222)" && $(this).html() !== "不限") {
            $("#ul_condition_select").append('<li onclick="DeleteSelect(this,\'' + tbname + '\')" class="li_condition_select"><span>' + $(this).html() + '</span><em>x</em></li>');
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
        if ($(this).css("color") === 'rgb(91, 192, 222)')
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
        if ($(this).html() !== "不限" && $(this).css("color") === "rgb(91, 192, 222)")
            condition += $(this).html();
    });
    return condition;
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
function LoadConditionByTypeName(typename, table, name, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: typename,
            TBName: table
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#ul_condition_body_" + id).remove();
                LoadCondition(xml.list, name, id);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//根据PARENTID获取字典表
function LoadConditionByParentID(parentid, table, name, id) {
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
                    LoadCondition(xml.list, name, id);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载查询条件
function LoadCondition(array, name, id) {
    var html = "";
    html += '<ul id="ul_condition_body_' + id + '" class="ul_condition_body">';
    html += '<li class="li_condition_body_first">' + name + '</li>';
    html += '<li id="0" class="li_condition_body li_condition_body_active" onclick="SelectCondition(this,\'' + name + '\')">不限</li>';
    for (var i = 0; i < (array.length > 15 ? 15 : array.length) ; i++) {
        html += '<li id="' + array[i].CODEID + '" class="li_condition_body" onclick="SelectCondition(this,\'' + name + '\')">' + array[i].CODENAME + '</li>';
    }
    html += '</ul>';
    $("#div_condition_body_" + id).append(html);

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
                LoadDistrictCondition(xml.list, type, name);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载查询条件
function LoadDistrictCondition(array, type, name) {
    var html = "";
    html += '<ul id="ul_condition_body_' + type + '" class="ul_condition_body">';
    html += '<li class="li_condition_body_first">' + name + '</li>';
    html += '<li class="li_condition_body li_condition_body_active" onclick="SelectCondition(this)">不限</li>';
    for (var i = 0; i < array.length; i++) {
        html += '<li class="li_condition_body" onclick="SelectCondition(this)">' + RTrimStr(RTrimStr(RTrimStr(array[i].NAME, '区'), '县'), '市') + '</li>';
    }
    html += '</ul>';
    $("#div_condition_body_QY").append(html);
}
//类别选择
function OpenLBXZ() {
    window.open(getRootPath() + "/Business/LBXZ/LBXZ");
}