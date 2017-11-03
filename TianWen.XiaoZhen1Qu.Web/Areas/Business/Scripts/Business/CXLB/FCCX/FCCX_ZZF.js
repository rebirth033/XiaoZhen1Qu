var currentIndex = 1;
$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_condition").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_condition_select").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);

    $("#li_condition_head_qyzf").css("background-color", "#ffffff");
    $(".li_body_head:eq(0)").css("border-bottom", "2px solid #5bc0de").css("color", "#5bc0de").css("font-weight","700");
    BindConditionNav();
    BindBodyNav();
    LoadFCCX();
    LoadBody("CZ", currentIndex);;
});
//搬定查询条件导航
function BindConditionNav() {
    $(".li_condition_head").bind("click", function () {
        $(".li_condition_head").each(function() {
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

//加载查询条件
function LoadFCCX() {
    var dqs = "地区,不限,全福州,鼓楼,台江,晋安,仓山,闽侯,福清,马尾,长乐,连江,平潭,罗源,闽清,永泰,全福建,全中国".split(',');
    var zjs = "租金,不限,500-1000元,1000-1500元,1500-2000元,2000-3000元,3000-4000元,4000元以上".split(',');
    var zflx = "租房类型,不限,整套出租,单间出租,精品公寓,床位出租".split(',');
    LoadCondition(dqs);
    LoadCondition(zjs);
    LoadCondition(zflx);
}

function LoadCondition(array) {
    var html = "";
    html += '<div class="div_condigion_body">';
    html += '<ul class="ul_condigion_body">';
    for (var i = 0; i < array.length; i++) {
        if (i === 0)
            html += '<li class="li_condigion_body_first">' + array[i] + '</li>';
        else if (i === 1)
            html += '<li class="li_condigion_body active">' + array[i] + '</li>';
        else 
            html += '<li class="li_condigion_body">' + array[i] + '</li>';
    }
    html += '</ul>';
    html += '</div>';
    $("#divCondition").append(html);
}

function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCXX/LoadFCXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            PageSize: 4,
            PageIndex: PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_main_info").html('');
                LoadPage(xml.PageCount);
                $("#span_main_info_head_gjt").html(xml.TotalCount);
                for (var i = 0; i < xml.list.length; i++) {
                    LoadInfo(xml.list[i]);
                }
                if (xml.list.length === 0)
                    NoInfo(TYPE);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadInfo(obj) {
    var html = "";
    html += ('<ul class="ul_new_info">');
    html += ('<li class="li_new_info">');
    html += ('<div class="div_new_info">');
    html += ('<div class="div_new_info_head">');
    html += ('<span class="span_new_info_head">信息号: ' + obj.JCXXID + '</span>');
    html += ('</div>');
    html += ('<div class="div_new_info_body">');
    html += ('<div class="div_new_info_body_left">');
    html += ('<div class="div_new_info_body_left_inner">');
    html += ('<div class="div_new_info_body_left_inner_img">');
    if (obj.PHOTOS.length > 0)
        html += ('<img class="img_new_info_body_left" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    else
        html += ('<img class="img_new_info_body_left" />');
    html += ('</div>');
    html += ('<div class="div_new_info_body_left_inner_info">');
    html += ('<span class="span_new_info_body_left_bt">' + obj.BT + '</span>');
    html += ('<span class="span_new_info_body_left_rq">' + obj.CJSJ.ToString("yyyy-MM-dd hh:mm:ss") + '</span>');
    html += ('<span class="span_new_info_body_left_dh">' + obj.DH + '</span>');
    html += ('</div>');
    html += ('</div>');
    html += ('</div>');
    html += ('<div class="div_new_info_body_middle">');
    if (obj.STATUS === 1) {
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_status">显示中</span>');
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_read">浏览:' + obj.LLCS + '</span>');
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_tip">进行置顶或精准推广会让你的信息成交更快哦。</span>');
    }
    else
        html += ('<span class="span_new_info_body_middle">个人删除</span>');
    html += ('</div>');
    html += ('<div class="div_new_info_body_right">');
    if (obj.STATUS === 0)
        html += ('<span class="span_new_info_body_right active" onclick="Restore(\'' + obj.JCXXID + '\')">恢复</span>');
    else {
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_common_button span_new_info_body_middle_update" onclick="Update(\'' + obj.JCXXID + '\',\'' + obj.LBID + '\')">修改</span>');
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_common_button span_new_info_body_middle_refresh">刷新</span>');
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_common_button span_new_info_body_middle_top">置顶</span>');
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_common_button span_new_info_body_middle_delete"  onclick="Delete(\'' + obj.JCXXID + '\')">删除</span>');
    }
    html += ('</div>');
    html += ('</div>');
    html += ('</div>');
    html += ('</li>');
    html += ('</ul>');
    $("#div_main_info").append(html);
}

function LoadPage(PageCount) {
    var index = parseInt(currentIndex);
    $("#div_main_info_bottom_fy").html('');
    if (index > 1) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + 1 + '\')" class="a_main_info_bottom_fy">首页</a>');
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + (index - 1) + '\')" class="a_main_info_bottom_fy">上一页</a>');
    }
    if (index < 5) {
        for (var i = 1; i <= PageCount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i <= 9) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }
    if (index >= 5 && index < PageCount - 4) {
        for (var i = 1; i <= PageCount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i >= index - 4 && i <= index + 4) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }
    if (index >= PageCount - 4 && PageCount > 4) {
        for (var i = 1; i <= PageCount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i > PageCount - 9) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }

    if (index < PageCount) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + (index + 1) + '\')" class="a_main_info_bottom_fy">下一页</a>');
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + PageCount + '\')" class="a_main_info_bottom_fy">尾页</a>');
    }
}