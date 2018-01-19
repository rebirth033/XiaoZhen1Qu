$(document).ready(function () {
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_foot").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#bc6ba6").css("color", "#ffffff");
    $("#div_yhm").bind("click", ShowWDXX);
    //LoadSWFWTOP();
    //LoadDefault();
});
//打开查询列表
function OpenCXLB(lbid, lburl, condition) {
    if (condition !== "null" && condition !== null)
        window.open(getRootPath() + "/Business" + lburl + "?LBID=" + lbid + "&" + condition);
    else
        window.open(getRootPath() + "/Business" + lburl + "?LBID=" + lbid);
}
//打开详细页面
function OpenXXXX(TYPE, ID, LBID) {
    window.open(getRootPath() + "/Business/" + TYPE.split('_')[0] + "/" + TYPE + "?ID=" + ID + "&LBID=" + LBID + "&TYPE=" + TYPE);
}
//加载商务服务类别
function LoadSWFWTOP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadSWFWTOP",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += '<div class="div_body_top_left">';
                for (var i = 0; i < xml.shfwlb.length; i++) {
                    if (xml.shfwlb[i].PARENTID === 10) {
                        html += '<p class="p_body_top_left">' + xml.shfwlb[i].LBNAME + '</p>';
                        html += ' <ul class="ul_body_top_left">';
                        for (var j = 0; j < xml.shfwlb.length; j++) {
                            if (xml.shfwlb[j].PARENTID === xml.shfwlb[i].LBID) {
                                html += '<li class="li_body_top_left" onclick="OpenCXLB(' + xml.shfwlb[j].LBID + ', \'/' + xml.shfwlb[j].FBYM.split('_')[0] + 'CX/' + xml.shfwlb[j].FBYM.split('_')[0] + 'CX_' + xml.shfwlb[j].FBYM.split('_')[1] + '\',\'null\')">' + xml.shfwlb[j].LBNAME + '</li>';
                            }
                        }
                        html += '</ul>';
                    }
                }
                html += '</div>';
                html += '<div class="div_body_top_right">';
                for (var i = 0; i < xml.shfwlb.length; i++) {
                    if (xml.shfwlb[i].PARENTID !== 10 && xml.shfwlb[i].FBYM.indexOf("SWFW") !== -1 && xml.shfwlb[i].LBNAME !== "快递服务" && xml.shfwlb[i].LBNAME !== "卡片定制" && xml.shfwlb[i].LBNAME !== "庆典服务" && xml.shfwlb[i].LBNAME !== "律师服务" && xml.shfwlb[i].LBNAME !== "翻译服务" && xml.shfwlb[i].LBNAME !== "会计审计" && xml.shfwlb[i].LBNAME !== "担保贷款" && xml.shfwlb[i].LBNAME !== "租赁服务") {
                        html += '<p class="p_body_top_right">' + xml.shfwlb[i].LBNAME + '</p>';
                        html += '<ul class="ul_body_top_right">';
                        for (var j = 0; j < xml.shfwxl.length; j++) {
                            if (xml.shfwxl[j].TYPENAME.indexOf(xml.shfwlb[i].LBNAME) !== -1) {
                                html += '<li class="li_body_top_right" onclick="OpenCXLB(' + xml.shfwlb[i].LBID + ', \'/' + xml.shfwlb[i].FBYM.split('_')[0] + 'CX/' + xml.shfwlb[i].FBYM.split('_')[0] + 'CX_' + xml.shfwlb[i].FBYM.split('_')[1] + '\', \'LB=' + xml.shfwxl[j].CODEID + '\')">' + xml.shfwxl[j].CODENAME + '</li>'
                            }
                        }
                        html += '</ul>';
                    }
                }
                html += '</div>';

                $("#div_body_top").html(html);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载默认
function LoadDefault() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadSWFWSY",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadItem("工商注册", xml.gszcfws, xml.districts);
                LoadItem("商标专利", xml.sbzlfws, xml.districts);
                LoadItem("印刷包装", xml.ysbzfws, xml.districts);
                LoadItem("喷绘招牌", xml.phzpfws, xml.districts);
                LoadItem("设计策划", xml.sjchfws, xml.districts);
                LoadItem("广告传媒", xml.ggcmfws, xml.districts);
                LoadItem("展会服务", xml.zhfws, xml.districts);
                LoadItem("礼品定制", xml.lpdzfws, xml.districts);
                LoadItem("庆典服务", xml.qdfws, xml.districts);
                LoadItem("网络布线", xml.wlbxfws, xml.districts);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载模块
function LoadItem(title, list, districts) {
    var html = "";
    html += '<div class="div_body_middle_item">';
    html += '<div class="div_body_middle_item_left">';
    html += '<p class="p_body_middle_item_left">' + title + '</p>';
    html += '<ul class="ul_body_middle_item_left">';
    for (var i = 0; i < (districts.length > 14 ? 14 : districts.length) ; i++) {
        if (title === "工商注册")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SWFWCX/SWFWCX_GSZC" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "商标专利")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SWFWCX/SWFWCX_SBZL" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "印刷包装")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SWFWCX/SWFWCX_YSBZ" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "喷绘招牌")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SWFWCX/SWFWCX_PHZP" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "设计策划")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SWFWCX/SWFWCX_SJCH" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "广告传媒")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SWFWCX/SWFWCX_GGCM" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "展会服务")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SWFWCX/SWFWCX_ZHFW" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "礼品定制")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SWFWCX/SWFWCX_LPDZ" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "庆典服务")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SWFWCX/SWFWCX_QDFW" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "网络布线")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SWFWCX/SWFWCX_WLBX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
    }
    html += '</ul>';
    html += '</div>';

    html += '<div class="div_body_middle_item_right">';
    html += '<p class="p_body_middle_item_right">' + title + '</p>';
    html += '<ul class="ul_body_middle_item_right">';
    for (var i = 0; i < (list.length < 8 ? list.length : 8) ; i++) {
        if (title === "工商注册")
            html += LoadInfo(list[i], "SWFWXX_GSZC");
        if (title === "商标专利")
            html += LoadInfo(list[i], "SWFWXX_SBZL");
        if (title === "印刷包装")
            html += LoadInfo(list[i], "SWFWXX_YSBZ");
        if (title === "喷绘招牌")
            html += LoadInfo(list[i], "SWFWXX_PHZP");
        if (title === "设计策划")
            html += LoadInfo(list[i], "SWFWXX_SJCH");
        if (title === "广告传媒")
            html += LoadInfo(list[i], "SWFWXX_GGCM");
        if (title === "展会服务")
            html += LoadInfo(list[i], "SWFWXX_ZHFW");
        if (title === "礼品定制")
            html += LoadInfo(list[i], "SWFWXX_LPDZ");
        if (title === "庆典服务")
            html += LoadInfo(list[i], "SWFWXX_QDFW");
        if (title === "网络布线")
            html += LoadInfo(list[i], "SWFWXX_WLBX");
    }
    html += '</ul>';

    html += '</div>';

    html += '</div>';
    $("#div_body_middle").append(html);
}
//加载生活服务信息
function LoadInfo(obj, type) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'' + type + '\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq" style="height:40px">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.QY + ' - ' + obj.DD + '</p>');
    html += ('</li>');
    return html;
}