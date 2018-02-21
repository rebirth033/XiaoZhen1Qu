$(document).ready(function () {
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_foot").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#bc6ba6").css("color", "#ffffff");
    $("#div_yhm").bind("click", ShowWDXX);
    //LoadDefault();
});
//打开查询列表
function OpenCXLB(lbid, lburl, condition) {
    if (condition !== "null" && condition !== null)
        window.open(getRootPath() + "/" + lburl + "?LBID=" + lbid + "&" + condition);
    else
        window.open(getRootPath() + "/" + lburl + "?LBID=" + lbid);
}
//打开详细页面
function OpenXXXX(TYPE, ID, LBID) {
    window.open(getRootPath() + "/" + TYPE.split('_')[0] + "/" + TYPE + "?ID=" + ID + "&LBID=" + LBID + "&TYPE=" + TYPE);
}
//加载默认
function LoadDefault() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/SY/LoadCWSY",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadItem("宠物狗", xml.cwgs, xml.cwgpz);
                LoadItem("宠物猫", xml.cwms, xml.cwmpz);
                LoadItem("花鸟鱼虫", xml.hnycs, xml.hnyclb);
                LoadItem("宠物服务", xml.cwfws, xml.cwfwlb);
                LoadItem("宠物用品", xml.cwyps, xml.cwyplb);
                LoadItem("宠物公益", xml.cwgys, xml.cwgylb);
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
        if (title === "宠物狗")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(31, \'' + "/CWCX/CWCX_CWG" + '\', \'PZ=' + districts[i].CODENAME + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "宠物猫")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(32, \'' + "/CWCX/CWCX_CWM" + '\', \'PZ=' + districts[i].CODENAME + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "花鸟鱼虫")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(33, \'' + "/CWCX/CWCX_HNYC" + '\', \'LB=' + districts[i].CODENAME + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "宠物服务")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(34, \'' + "/CWCX/CWCX_CWFW" + '\', \'LB=' + districts[i].CODENAME + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "宠物用品")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(35, \'' + "/CWCX/CWCX_CWYPSP" + '\', \'LB=' + districts[i].CODENAME + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "宠物公益")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(36, \'' + "/CWCX/CWCX_CWGY" + '\', \'LB=' + districts[i].CODENAME + '\')">' + districts[i].CODENAME + '</li>';
    }
    html += '</ul>';
    html += '</div>';

    html += '<div class="div_body_middle_item_right">';

    html += '<ul class="ul_body_middle_item_right">';
    for (var i = 0; i < (list.length < 8 ? list.length : 8) ; i++) {
        if (title === "宠物狗")
            html += LoadCWGInfo(list[i])
        if (title === "宠物猫")
            html += LoadCWMInfo(list[i])
        if (title === "花鸟鱼虫")
            html += LoadHNYCInfo(list[i])
        if (title === "宠物服务")
            html += LoadCWFWInfo(list[i])
        if (title === "宠物用品")
            html += LoadCWYPInfo(list[i])
        if (title === "宠物公益")
            html += LoadCWGYInfo(list[i])
    }
    html += '</ul>';

    html += '</div>';

    html += '</div>';
    $("#div_body_middle").append(html);
}
//加载宠物狗信息
function LoadCWGInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CWXX_CWG\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.NL + obj.NLDW + ' / ' + obj.YMQK + '疫苗</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '元') + '</p>');
    html += ('</li>');
    return html;
}
//加载宠物猫信息
function LoadCWMInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CWXX_CWM\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.PZ + ' / ' + obj.NL + obj.NLDW + ' / ' + obj.ZSZS + '只在售</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '元') + '</p>');
    html += ('</li>');
    return html;
}
//加载花鸟鱼虫信息
function LoadHNYCInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CWXX_HNYC\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '元') + '</p>');
    html += ('</li>');
    return html;
}
//加载宠物服务信息
function LoadCWFWInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CWXX_CWFW\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载宠物用品信息
function LoadCWYPInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CWXX_CWYP\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载宠物公益信息
function LoadCWGYInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CWXX_CWGY\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}