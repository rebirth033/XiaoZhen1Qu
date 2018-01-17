$(document).ready(function () {
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_foot").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#bc6ba6").css("color", "#ffffff");
    $("#div_yhm").bind("click", ShowWDXX);
    //LoadSHFWTOP();
    LoadDefault();
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
//加载行业类别
function LoadSHFWTOP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadSHFWTOP",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += '<div class="div_body_top_left">';
                for (var i = 0; i < xml.shfwlb.length; i++) {
                    if (xml.shfwlb[i].PARENTID === 9) {
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
                    if (xml.shfwlb[i].PARENTID !== 9 && xml.shfwlb[i].FBYM.indexOf("SHFW") !== -1 && xml.shfwlb[i].LBNAME !== "手机维修" && xml.shfwlb[i].LBNAME !== "开锁修锁" && xml.shfwlb[i].LBNAME !== "白事服务") {
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
        url: getRootPath() + "/Business/SY/LoadSHFWSY",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadItem("搬家服务", xml.bjfws, xml.districts);
                LoadItem("保姆月嫂", xml.bmysfws, xml.districts);
                LoadItem("保洁清洗", xml.bjqxfws, xml.districts);
                LoadItem("管道疏通/清理", xml.gdstqlfws, xml.districts);
                LoadItem("生活配送", xml.shpsfws, xml.districts);
                LoadItem("家电维修", xml.jdwxfws, xml.districts);
                LoadItem("电脑维修", xml.dnwxfws, xml.districts);
                LoadItem("房屋维修", xml.fwwxfws, xml.districts);
                LoadItem("家具维修", xml.jjwxfws, xml.districts);
                LoadItem("数码维修", xml.smwxfws, xml.districts);
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
        if (title === "搬家服务")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SHFWCX/SHFWCX_BJ" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "保姆月嫂")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SHFWCX/SHFWCX_BMYS" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "保洁清洗")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SHFWCX/SHFWCX_BJQX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "管道疏通/清理")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SHFWCX/SHFWCX_GDSTQL" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "生活配送")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SHFWCX/SHFWCX_SHPS" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "家电维修")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SHFWCX/SHFWCX_JDWX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "电脑维修")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SHFWCX/SHFWCX_DNWX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "房屋维修")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SHFWCX/SHFWCX_FWWX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "家具维修")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SHFWCX/SHFWCX_JJWX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "数码维修")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/SHFWCX/SHFWCX_SMWX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
    }
    html += '</ul>';
    html += '</div>';

    html += '<div class="div_body_middle_item_right">';
    html += '<p class="p_body_middle_item_right">' + title + '</p>';
    html += '<ul class="ul_body_middle_item_right">';
    for (var i = 0; i < (list.length < 8 ? list.length : 8) ; i++) {
        //if (title === "搬家服务")
            html += LoadInfo(list[i]);

    }
    html += '</ul>';

    html += '</div>';

    html += '</div>';
    $("#div_body_middle").append(html);
}
//加载生活服务信息
function LoadInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'SHFWXX_BJ\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq" style="height:40px">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.QY + ' - ' + obj.DD + '</p>');
    html += ('</li>');
    return html;
}