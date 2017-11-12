var currentIndex = 1;
$(document).ready(function () {
    BindConditionNav();
    BindBodyNav();
    LoadFCCXCondition();
    LoadHot("FCXX_DZF");
    LoadBody("FCXX_DZF", currentIndex);
});
//搬定查询条件导航
function BindConditionNav() {
    $(".li_condition_head").bind("click", function () {
        $(".li_condition_head").each(function () {
            $(this).css("background-color", "#eeeff1");
        });
        $(this).css("background-color", "#ffffff");
    });
}
//搬定主体列表导航
function BindBodyNav() {
    $(".li_body_head").bind("click", function () {
        $(".li_body_head").each(function () {
            $(this).css("border-bottom", "1px solid #cccccc").css("color", "#999999").css("font-weight", "normal");
        });
        $(this).css("border-bottom", "2px solid #5bc0de").css("color", "#5bc0de").css("font-weight", "700");
    });
}
//加载房产查询条件
function LoadFCCXCondition() {
    var dqs = "地区,不限,鼓楼,台江,晋安,仓山,闽侯,福清,马尾,长乐,连江,平潭,罗源,闽清,永泰".split(',');
    var zjs = "租金,不限,100元以下,100-200元,200-300元,300元以上".split(',');
    var fwlx = "类型,不限,家庭旅馆,酒店式公寓,经济型酒店,宾馆招待所,特色客栈,星级酒店,青年旅社".split(',');
    LoadCondition(dqs, "DQ");
    LoadCondition(zjs, "ZJ");
    $("#ul_condition_body_ZJ").append("<li><input id='input_zj_q' class='input_zj' type='text' /><span class='span_zj'></span> - <input class='input_zj' id='input_zj_z' type='text' /><span class='span_zj'>元/天</span></li>");
    LoadCondition(fwlx, "FWLX");
    $("#ul_condition_body_DQ").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_ZJ").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_FWLX").find(".li_condition_body").bind("click", SelectCondition);
}
//选择条件
function SelectCondition() {
    $(this).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(this).addClass("li_condition_body_active");
    $(".div_condition_select").css("display", "block");
    $("#ul_condition_select").html('<li class="li_condition_select_first">筛选条件</li>');
    $(".li_condition_body").each(function () {
        if ($(this).css("color") === "rgb(91, 192, 222)" && $(this).html() !== "不限") {
            $("#ul_condition_select").append('<li onclick="DeleteSelect(this)" class="li_condition_select"><span>' + $(this).html() + '</span><em>x</em></li>');
        }
    });
    LoadBody("FCXX_DZF", currentIndex);
}
//绑定选择条件删除事件
function DeleteSelect(obj) {
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
    LoadBody("FC", currentIndex);
}
//加载查询条件
function LoadCondition(array, type) {
    var html = "";
    html += '<div class="div_condition_body">';
    html += '<ul id="ul_condition_body_' + type + '" class="ul_condition_body">';
    for (var i = 0; i < array.length; i++) {
        if (i === 0)
            html += '<li class="li_condition_body_first">' + array[i] + '</li>';
        else if (i === 1)
            html += '<li class="li_condition_body li_condition_body_active">' + array[i] + '</li>';
        else
            html += '<li class="li_condition_body">' + array[i] + '</li>';
    }
    html += '</ul>';
    html += '</div>';
    $("#divCondition").append(html);
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
//是否有条件
function HasCondition() {
    var condition = "";
    $(".li_condition_body").each(function () {
        if ($(this).html() !== "不限" && $(this).css("color") === "rgb(91, 192, 222)")
            condition += $(this).html();
    });
    return condition;
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = "DQ:" + GetCondition("DQ") + ",ZJ:" + GetCondition("ZJ") + ",FWLX:" + GetCondition("FWLX");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCCX/LoadFCXX",
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
                LoadPage(xml.PageCount);
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
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'FCXX_DZF\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'FCXX_DZF\',\'' + obj.ID + '\')">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs">' + obj.MJ + '平米' + '</p>');
    html += ('<p class="p_li_body_left_center_dz">' + obj.XQMC + ' [' + obj.XQDZ + '] ' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_zj">' + obj.ZJ + '</span>元/月</p>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载分页
function LoadPage(PageCount) {
    var index = parseInt(currentIndex);
    $("#div_main_info_bottom_fy").html('');
    if (index > 1) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + "FC" + '\',\'' + 1 + '\')" class="a_main_info_bottom_fy">首页</a>');
        $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + "FC" + '\',\'' + (index - 1) + '\')" class="a_main_info_bottom_fy">上一页</a>');
    }
    if (index < 5) {
        for (var i = 1; i <= PageCount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + "FC" + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i <= 9) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + "FC" + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }
    if (index >= 5 && index < PageCount - 4) {
        for (var i = 1; i <= PageCount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + "FC" + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i >= index - 4 && i <= index + 4) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + "FC" + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }
    if (index >= PageCount - 4 && PageCount > 4) {
        for (var i = 1; i <= PageCount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + "FC" + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i > PageCount - 9) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + "FC" + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }
    if (index < PageCount) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + "FC" + '\',\'' + (index + 1) + '\')" class="a_main_info_bottom_fy">下一页</a>');
        $("#div_main_info_bottom_fy").append('<a onclick="LoadBody(\'' + "FC" + '\',\'' + PageCount + '\')" class="a_main_info_bottom_fy">尾页</a>');
    }
}
//加载热门推荐
function LoadHot(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCCX/LoadFCXX",
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
    html += ('<li onclick="OpenXXXX(\'FC_ZZF\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.XQDZ.split('-')[0] + ' / ' + obj.XQDZ.split('-')[1] + ' / ' + obj.XQMC + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.S + '室 ' + obj.PFM + '平</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.ZJ + '元/月</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}