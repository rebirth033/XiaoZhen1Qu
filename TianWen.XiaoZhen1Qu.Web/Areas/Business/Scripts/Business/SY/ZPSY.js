$(document).ready(function () {
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_foot").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#bc6ba6").css("color", "#ffffff");
    $("#div_yhm").bind("click", ShowWDXX);
    //LoadRZZW();
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
//加载热招职位
function LoadRZZW() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadZPSY",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadZWItem(xml.rzzws);
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
        url: getRootPath() + "/Business/SY/LoadZPSY",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadItem("销售", xml.xss, xml.xszw);
                LoadItem("司机", xml.sjs, xml.sjzw);
                LoadItem("餐饮", xml.cys, xml.cyzw);
                LoadItem("金融", xml.jrs, xml.jrzw);
                LoadItem("管理", xml.gls, xml.glzw);
                LoadItem("汽车", xml.qcs, xml.qczw);
                LoadItem("物流", xml.wls, xml.wlzw);
                LoadItem("广告", xml.ggs, xml.ggzw);
                LoadItem("房产", xml.fcs, xml.fczw);
                LoadItem("建筑", xml.jzs, xml.jzzw);
                LoadItem("装修", xml.zxs, xml.zxzw);
                LoadItem("网络", xml.wls, xml.wlzw);
                LoadItem("通讯", xml.txs, xml.txzw);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载职位
function LoadZWItem(rzzws) {
    var html = "";
    for (var i = 0; i < rzzws.length; i++) {
        html += "<li class=\"li_body_top_right\" onclick=\"OpenCXLB(89, '/QZZPCX/QZZPCX_QZZP', 'ZWLB=" + rzzws[i].TYPENAME.replace("类别",'') + "&ZWMC=" + rzzws[i].CODEID + "')\">" + rzzws[i].CODENAME + "</li>";
    }
    $("#ul_body_top_right_rzzw").html(html);
}
//加载模块
function LoadItem(title, list, districts) {
    var html = "";
    html += '<div class="div_body_middle_item">';
    html += '<div class="div_body_middle_item_left">';
    html += '<p class="p_body_middle_item_left">' + title + '</p>';
    html += '<ul class="ul_body_middle_item_left">';
    for (var i = 0; i < (districts.length > 14 ? 14 : districts.length) ; i++) {
        if (title === "销售")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(89, \'' + "/QZZPCX/QZZPCX_QZZP" + '\', \'ZWMC=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "司机")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(89, \'' + "/QZZPCX/QZZPCX_QZZP" + '\', \'ZWMC=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "餐饮")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(89, \'' + "/QZZPCX/QZZPCX_QZZP" + '\', \'ZWMC=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "金融")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(89, \'' + "/QZZPCX/QZZPCX_QZZP" + '\', \'ZWMC=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "管理")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(89, \'' + "/QZZPCX/QZZPCX_QZZP" + '\', \'ZWMC=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "汽车")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(89, \'' + "/QZZPCX/QZZPCX_QZZP" + '\', \'ZWMC=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "物流")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(89, \'' + "/QZZPCX/QZZPCX_QZZP" + '\', \'ZWMC=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "广告")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(89, \'' + "/QZZPCX/QZZPCX_QZZP" + '\', \'ZWMC=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "房产")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(89, \'' + "/QZZPCX/QZZPCX_QZZP" + '\', \'ZWMC=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "建筑")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(89, \'' + "/QZZPCX/QZZPCX_QZZP" + '\', \'ZWMC=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "装修")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(89, \'' + "/QZZPCX/QZZPCX_QZZP" + '\', \'ZWMC=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "网络")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(89, \'' + "/QZZPCX/QZZPCX_QZZP" + '\', \'ZWMC=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "通讯")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(89, \'' + "/QZZPCX/QZZPCX_QZZP" + '\', \'ZWMC=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
    }
    html += '</ul>';
    html += '</div>';

    html += '<div class="div_body_middle_item_right">';

    html += '<ul class="ul_body_middle_item_right">';
    for (var i = 0; i < (list.length < 8 ? list.length : 8) ; i++) {
        if (title === "销售")
            html += LoadXSInfo(list[i])
        if (title === "司机")
            html += LoadInfo(list[i])
        if (title === "餐饮")
            html += LoadInfo(list[i])
        if (title === "金融")
            html += LoadInfo(list[i])
        if (title === "管理")
            html += LoadInfo(list[i])
        if (title === "汽车")
            html += LoadInfo(list[i])
        if (title === "物流")
            html += LoadInfo(list[i])
        if (title === "广告")
            html += LoadInfo(list[i])
        if (title === "房产")
            html += LoadInfo(list[i])
        if (title === "建筑")
            html += LoadInfo(list[i])
        if (title === "装修")
            html += LoadInfo(list[i])
        if (title === "网络")
            html += LoadInfo(list[i])
        if (title === "通讯")
            html += LoadInfo(list[i])
    }
    html += '</ul>';

    html += '</div>';

    html += '</div>';
    $("#div_body_middle").append(html);
}
//加载二手设备信息
function LoadInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'QZZPXX_QZZP\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}