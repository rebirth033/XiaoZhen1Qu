$(document).ready(function () {
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_foot").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $("#li_head_sy").css("background", "#bc6ba6").css("color", "#ffffff");
    $("#div_yhm").bind("click", ShowWDXX);
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
//加载默认
function LoadDefault() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadCLSY",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadItem("轿车", xml.jcs, xml.jcpp);
                LoadItem("电动车", xml.ddcs, xml.ddcpp);
                LoadItem("摩托车", xml.mtcs, xml.mtcpp);
                LoadItem("货车", xml.hcs, xml.hcpp);
                LoadItem("客车", xml.kcs, xml.kcpp);
                LoadItem("工程车", xml.gccs, xml.gcccx);
                LoadItem("自行车", xml.zxcs, xml.zxcpp);
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
        if (title === "轿车")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(185, \'' + "/CLCX/CLCX_JC" + '\', \'PP=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "电动车")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(186, \'' + "/CLCX/CLCX_DDC" + '\', \'PP=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "摩托车")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(187, \'' + "/CLCX/CLCX_MTC" + '\', \'PP=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "货车")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(190, \'' + "/CLCX/CLCX_HC" + '\', \'PP=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "客车")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(192, \'' + "/CLCX/CLCX_KC" + '\', \'PP=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "工程车")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(191, \'' + "/CLCX/CLCX_GCC" + '\', \'CX=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "自行车")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(188, \'' + "/CLCX/CLCX_ZXC" + '\', \'PP=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
    }
    html += '</ul>';
    html += '</div>';

    html += '<div class="div_body_middle_item_right">';

    html += '<ul class="ul_body_middle_item_right">';
    for (var i = 0; i < (list.length < 8 ? list.length : 8) ; i++) {
        if (title === "轿车")
            html += LoadJCInfo(list[i]);
        if (title === "电动车")
            html += LoadDDCInfo(list[i]);
        if (title === "摩托车")
            html += LoadMTCInfo(list[i]);
        if (title === "货车")
            html += LoadHCInfo(list[i]);
        if (title === "客车")
            html += LoadKCInfo(list[i]);
        if (title === "工程车")
            html += LoadGCCInfo(list[i]);
        if (title === "自行车")
            html += LoadZXCInfo(list[i]);
    }
    html += '</ul>';

    html += '</div>';

    html += '</div>';
    $("#div_body_middle").append(html);
}
//加载轿车信息
function LoadJCInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CLXX_JC\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.SPNF + ' / ' + '2.0升' + ' / ' + '自动' + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载电动车信息
function LoadDDCInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CLXX_DDC\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.CX + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '元') + '</p>');
    html += ('</li>');
    return html;
}
//加载摩托车信息
function LoadMTCInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CLXX_MTC\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.CX + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '元') + '</p>');
    html += ('</li>');
    return html;
}
//加载货车信息
function LoadHCInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CLXX_HC\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.LB + ' / ' + obj.CCNF + ' / ' + obj.EDZZ + '吨</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载客车信息
function LoadKCInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CLXX_KC\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.SPNF + ' / ' + obj.CLYS + ' / ' + obj.CX + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载工程车信息
function LoadGCCInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CLXX_GCC\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.CX + ' / ' + obj.CCNF + ' / ' + obj.XSS + '小时' + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载自行车信息
function LoadZXCInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CLXX_ZXC\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.PP + ' / ' + obj.XJ + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}