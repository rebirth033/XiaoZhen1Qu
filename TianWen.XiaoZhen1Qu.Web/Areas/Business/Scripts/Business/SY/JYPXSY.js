$(document).ready(function () {
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_foot").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#bc6ba6").css("color", "#ffffff");
    $("#div_yhm").bind("click", ShowWDXX);
    //LoadTOP();
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
//加载教育培训类别
function LoadTOP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadJYPXTOP",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += '<div class="div_body_top_left">';
                html += '<p class="p_body_top_left">教育培训</p>';
                html += ' <ul class="ul_body_top_left">';
                for (var i = 0; i < xml.lb.length; i++) {
                    html += '<li class="li_body_top_left" onclick="OpenCXLB(' + xml.lb[i].LBID + ', \'/' + xml.lb[i].FBYM.split('_')[0] + 'CX/' + xml.lb[i].FBYM.split('_')[0] + 'CX_' + xml.lb[i].FBYM.split('_')[1] + '\',\'null\')">' + xml.lb[i].LBNAME + '</li>';
                }
                html += '</ul>';
                html += '</div>';
                html += '<div class="div_body_top_right">';
                for (var i = 0; i < xml.lb.length; i++) {
                    if (xml.lb[i].LBNAME !== "家教机构" && xml.lb[i].LBNAME !== "语言培训" && xml.lb[i].LBNAME !== "早教培训") {
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
        url: getRootPath() + "/Business/SY/LoadJYPXSY",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadItem("家教机构", xml.jjjgs, xml.districts);
                LoadItem("语言培训", xml.yypxs, xml.districts);
                LoadItem("艺术培训", xml.yspxs, xml.districts);
                LoadItem("职业技能培训", xml.zyjnpxs, xml.districts);
                LoadItem("体育培训", xml.typxs, xml.districts);
                LoadItem("学历教育", xml.xljys, xml.districts);
                LoadItem("IT培训", xml.itpxs, xml.districts);
                LoadItem("设计培训", xml.sjpxs, xml.districts);
                LoadItem("管理培训", xml.glpxs, xml.districts);
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
        if (title === "家教机构")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/JYPXCX/JYPXCX_JJJG" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "语言培训")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/JYPXCX/JYPXCX_YYPX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "艺术培训")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/JYPXCX/JYPXCX_YSPX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "职业技能培训")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/JYPXCX/JYPXCX_ZYJNPX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "体育培训")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/JYPXCX/JYPXCX_TYPX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "学历教育")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/JYPXCX/JYPXCX_XLJY" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "IT培训")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/JYPXCX/JYPXCX_ITPX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "设计培训")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/JYPXCX/JYPXCX_SJPX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
        if (title === "管理培训")
            html += '<li class="li_body_middle_item_left" onclick="OpenCXLB(' + list[0].LBID + ', \'' + "/JYPXCX/JYPXCX_GLPX" + '\', \'QY=' + districts[i].CODEID + '\')">' + districts[i].CODENAME + '</li>';
    }
    html += '</ul>';
    html += '</div>';

    html += '<div class="div_body_middle_item_right">';
    html += '<p class="p_body_middle_item_right">' + title + '</p>';
    html += '<ul class="ul_body_middle_item_right">';
    for (var i = 0; i < (list.length < 8 ? list.length : 8) ; i++) {
        if (title === "家教机构")
            html += LoadInfo(list[i], "JYPXXX_JJJG");
        if (title === "语言培训")
            html += LoadInfo(list[i], "JYPXXX_YYPX");
        if (title === "艺术培训")
            html += LoadInfo(list[i], "JYPXXX_YSPX");
        if (title === "职业技能培训")
            html += LoadInfo(list[i], "JYPXXX_ZYJNPX");
        if (title === "体育培训")
            html += LoadInfo(list[i], "JYPXXX_TYPX");
        if (title === "学历教育")
            html += LoadInfo(list[i], "JYPXXX_XLJY");
        if (title === "IT培训")
            html += LoadInfo(list[i], "JYPXXX_ITPX");
        if (title === "设计培训")
            html += LoadInfo(list[i], "JYPXXX_SJPX");
        if (title === "管理培训")
            html += LoadInfo(list[i], "JYPXXX_GLPX");
    }
    html += '</ul>';

    html += '</div>';

    html += '</div>';
    $("#div_body_middle").append(html);
}
//加载教育培训信息
function LoadInfo(obj, type) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'' + type + '\',\'' + obj.ID + '\',\'' + obj.LBID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq" style="height:40px">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.LB + '</p>');
    html += ('</li>');
    return html;
}