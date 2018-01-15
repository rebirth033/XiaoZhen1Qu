$(document).ready(function () {
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_foot").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#bc6ba6").css("color", "#ffffff");
    $("#div_yhm").bind("click", ShowWDXX);
    LoadRZZW();
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
        url: getRootPath() + "/Business/SY/LoadESSY",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadItem("手机", xml.sjs, xml.sjpp);
                LoadItem("笔记本电脑", xml.bjbdns, xml.bjbdnpp);
                LoadItem("平板电脑", xml.pbdns, xml.pbdnpp);
                LoadItem("数码产品", xml.smcps, xml.smcplb);
                LoadItem("台式机/配件", xml.tsjs, xml.tsjlb);
                LoadItem("家用家电", xml.jyjds, xml.jyjdlb);
                LoadItem("家用家具", xml.jyjjs, xml.jyjjlb);
                LoadItem("家居日用", xml.jjrys, xml.jjrylb);
                LoadItem("办公用品", xml.bgyps, xml.bgyplb);
                LoadItem("母婴儿童", xml.myets, xml.myetlb);
                LoadItem("服饰箱包", xml.fsxbs, xml.fsxblb);
                LoadItem("美容保健", xml.mrbjs, xml.mrbjlb);
                LoadItem("二手设备", xml.essbs, xml.essblb);
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
        html += "<li class=\"li_body_top_right\" onclick=\"OpenCXLB(89, '/ZPCX/ZP CX_QZZP', 'ZWLB=" + rzzws[i].PARENTID + "&ZW=" + rzzws[i].CODEID + "')\">" + rzzws[i].CODENAME + "</li>";
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
        if (title === "手机")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(154, \'' + "/ESCX/ESCX_SJSM_ESSJ" + '\', \'PP=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "笔记本电脑")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(155, \'' + "/ESCX/ESCX_SJSM_BJBDN" + '\', \'PP=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "平板电脑")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(156, \'' + "/ESCX/ESCX_SJSM_PBDN" + '\', \'PP=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "数码产品")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(157, \'' + "/ESCX/ESCX_SJSM_SMCP" + '\', \'LB=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "台式机/配件")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(158, \'' + "/ESCX/ESCX_SJSM_TSJ" + '\', \'LB=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "家用家电")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(159, \'' + "/ESCX/ESCX_JDJJBG_ESJD" + '\', \'LB=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "家用家具")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(160, \'' + "/ESCX/ESCX_JDJJBG_ESJJ" + '\', \'LB=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "家居日用")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(161, \'' + "/ESCX/ESCX_JDJJBG_JJRY" + '\', \'LB=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "办公用品")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(162, \'' + "/ESCX/ESCX_JDJJBG_BGSB" + '\', \'LB=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "母婴儿童")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(163, \'' + "/ESCX/ESCX_MYFZMR_MYETYPWJ" + '\', \'LB=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "服饰箱包")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(164, \'' + "/ESCX/ESCX_MYFZMR_FZXMXB" + '\', \'LB=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "美容保健")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(165, \'' + "/ESCX/ESCX_MYFZMR_MRBJ" + '\', \'LB=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "二手设备")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(170, \'' + "/ESCX/ESCX_QTES_ESSB" + '\', \'LB=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
    }
    html += '</ul>';
    html += '</div>';

    html += '<div class="div_body_middle_item_right">';

    html += '<ul class="ul_body_middle_item_right">';
    for (var i = 0; i < (list.length < 8 ? list.length : 8) ; i++) {
        if (title === "手机")
            html += LoadSJInfo(list[i])
        if (title === "笔记本电脑")
            html += LoadBJBDNInfo(list[i])
        if (title === "平板电脑")
            html += LoadPBDNInfo(list[i])
        if (title === "数码产品")
            html += LoadSMCPInfo(list[i])
        if (title === "台式机/配件")
            html += LoadTSJInfo(list[i])
        if (title === "家用家电")
            html += LoadJYJDInfo(list[i])
        if (title === "家用家具")
            html += LoadJYJJInfo(list[i])
        if (title === "家居日用")
            html += LoadJJRYInfo(list[i])
        if (title === "办公用品")
            html += LoadBGYPInfo(list[i])
        if (title === "母婴儿童")
            html += LoadMYETInfo(list[i])
        if (title === "服饰箱包")
            html += LoadFSXBInfo(list[i])
        if (title === "美容保健")
            html += LoadMRBJInfo(list[i])
        if (title === "二手设备")
            html += LoadESSBInfo(list[i])
    }
    html += '</ul>';

    html += '</div>';

    html += '</div>';
    $("#div_body_middle").append(html);
}
//加载手机信息
function LoadSJInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'ESXX_SJSM_ESSJ\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '元') + '</p>');
    html += ('</li>');
    return html;
}
//加载笔记本电脑信息
function LoadBJBDNInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'ESXX_SJSM_BJBDN\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '元') + '</p>');
    html += ('</li>');
    return html;
}
//加载平板电脑信息
function LoadPBDNInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'ESXX_SJSM_PBDN\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '元') + '</p>');
    html += ('</li>');
    return html;
}
//加载数码产品信息
function LoadSMCPInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'ESXX_SJSM_SMCP\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载台式机/配件信息
function LoadTSJInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'ESXX_SJSM_TSJ\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载家用家电信息
function LoadJYJDInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'ESXX_JDJJBG_ESJD\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载家用家具信息
function LoadJYJJInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'ESXX_JDJJBG_ESJJ\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载家居日用信息
function LoadJJRYInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'ESXX_JDJJBG_JJRY\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载办公用品信息
function LoadBGYPInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'ESXX_JDJJBG_BGYP\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载母婴儿童信息
function LoadMYETInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'ESXX_MYFZMR_MYETYPWJ\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载服装鞋帽信息
function LoadFSXBInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'ESXX_MYFZMR_FZXMXB\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载美容保健信息
function LoadMRBJInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'ESXX_MYFZMR_MRBJ\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}
//加载二手设备信息
function LoadESSBInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'ESXX_QTES_ESSB\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + GetJG(obj.JG, '万元') + '</p>');
    html += ('</li>');
    return html;
}