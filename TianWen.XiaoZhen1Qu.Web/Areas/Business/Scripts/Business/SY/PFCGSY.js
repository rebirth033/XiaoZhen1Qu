$(document).ready(function () {
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_foot").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#bc6ba6").css("color", "#ffffff");
    $("#div_yhm").bind("click", ShowWDXX);
    LoadTOP();
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
//加载招商加盟类别
function LoadTOP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadPFCGTOP",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += '<div class="div_body_top_left">';
                html += '<p class="p_body_top_left">批发采购</p>';
                html += ' <ul class="ul_body_top_left">';
                for (var i = 0; i < xml.lb.length; i++) {
                    html += '<li class="li_body_top_left" onclick="OpenCXLB(' + xml.lb[i].LBID + ', \'/' + xml.lb[i].FBYM.split('_')[0] + 'CX/' + xml.lb[i].FBYM.split('_')[0] + 'CX_' + xml.lb[i].FBYM.split('_')[1] + '\',\'null\')">' + xml.lb[i].LBNAME + '</li>';
                }
                html += '</ul>';
                html += '</div>';
                html += '<div class="div_body_top_right">';
                for (var i = 0; i < xml.lb.length; i++) {
                    if (xml.lb[i].LBNAME !== "原材料/包装" && xml.lb[i].LBNAME !== "机械加工") {
                        html += '<p class="p_body_top_right">' + xml.lb[i].LBNAME + '</p>';
                        html += '<ul class="ul_body_top_right">';
                        for (var j = 0; j < xml.xl.length; j++) {
                            if (xml.xl[j].TYPENAME.indexOf(xml.lb[i].LBNAME) !== -1) {
                                html += '<li class="li_body_top_right" onclick="OpenCXLB(' + xml.lb[i].LBID + ', \'/' + xml.lb[i].FBYM.split('_')[0] + 'CX/' + xml.lb[i].FBYM.split('_')[0] + 'CX_' + xml.lb[i].FBYM.split('_')[1] + '\', \'LB=' + xml.xl[j].CODEID + '\')">' + xml.xl[j].CODENAME + '</li>'
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
        url: getRootPath() + "/Business/SY/LoadPFCGSY",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadItem("服装", xml.fzs, xml.districts);
                LoadItem("建材", xml.jcs, xml.districts);
                LoadItem("机械加工", xml.jxjgs, xml.districts);
                LoadItem("美容保健", xml.mrbjs, xml.districts);
                LoadItem("礼品饰品", xml.lpsps, xml.districts);
                LoadItem("家居", xml.jjs, xml.districts);
                LoadItem("教育培训", xml.jypxs, xml.districts);
                LoadItem("汽车服务", xml.qcfws, xml.districts);
                LoadItem("网络通讯", xml.wltxs, xml.districts);
                LoadItem("农业养殖", xml.nyyzs, xml.districts);
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
        if (title === "服装")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/PFCGCX/PFCGCX_FZXB" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "建材")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/PFCGCX/PFCGCX_JC" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "机械加工")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/PFCGCX/PFCGCX_JXJG" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "美容保健")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/PFCGCX/PFCGCX_MRBJ" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "礼品饰品")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/PFCGCX/PFCGCX_LPSP" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "家居")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/PFCGCX/PFCGCX_JJHB" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "教育培训")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/PFCGCX/PFCGCX_JYPX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "汽车服务")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/PFCGCX/PFCGCX_QCFW" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "网络通讯")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/PFCGCX/PFCGCX_WLFW" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "农业养殖")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/PFCGCX/PFCGCX_NY" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
    }
    html += '</ul>';
    html += '</div>';

    html += '<div class="div_body_middle_item_right">';
    html += '<p class="p_body_middle_item_right">' + title + '</p>';
    html += '<ul class="ul_body_middle_item_right">';
    for (var i = 0; i < (list.length < 8 ? list.length : 8) ; i++) {
        if (title === "服装")
            html += LoadInfo(list[i], "PFCGXX_FZXB");
        if (title === "建材")
            html += LoadInfo(list[i], "PFCGXX_JC");
        if (title === "机械加工")
            html += LoadInfo(list[i], "PFCGXX_JXJG");
        if (title === "美容保健")
            html += LoadInfo(list[i], "PFCGXX_MRBJ");
        if (title === "礼品饰品")
            html += LoadInfo(list[i], "PFCGXX_LPSP");
        if (title === "家居")
            html += LoadInfo(list[i], "PFCGXX_JJHB");
        if (title === "教育培训")
            html += LoadInfo(list[i], "PFCGXX_JYPX");
        if (title === "汽车服务")
            html += LoadInfo(list[i], "PFCGXX_QCFW");
        if (title === "网络通讯")
            html += LoadInfo(list[i], "PFCGXX_WLFW");
        if (title === "农业养殖")
            html += LoadInfo(list[i], "PFCGXX_NY");
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
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.LB + '</p>');
    html += ('</li>');
    return html;
}