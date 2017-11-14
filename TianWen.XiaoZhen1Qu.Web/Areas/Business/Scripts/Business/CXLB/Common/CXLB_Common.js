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
//类别选择
function OpenLBXZ() {
    window.open(getRootPath() + "/Business/LBXZ/LBXZ");
}
//加载分页
function LoadPage(typename,pagecount) {
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