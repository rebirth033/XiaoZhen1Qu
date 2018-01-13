$(document).ready(function () {
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_foot").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#bc6ba6").css("color", "#ffffff");
    $("#div_yhm").bind("click", ShowWDXX);
    LoadDefault();
});

//打开查询列表
function OpenCXLB(lbid, lburl, condition) {
    if (condition !== "null" && condition !== null)
        window.open(getRootPath() + "/Business" + lburl + "?LBID=" + lbid + "&" + condition);
    else
        window.open(getRootPath() + "/Business" + lburl + "?LBID=" + lbid);
}
//加载默认
function LoadDefault() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadFCSY",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadItem("整套出租", xml.zzfs, xml.districts);
                LoadItem("单间出租", xml.hzfs, xml.districts);
                LoadItem("日租短租", xml.dzfs, xml.districts);
                LoadItem("二手房出售", xml.esfs, xml.districts);
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
    for (var i = 0; i < districts.length; i++)
        html += '<li class="li_body_middle_item_left">' + districts[i].CODENAME + '</li>';
    html += '</ul>';
    html += '</div>';

    html += '<div class="div_body_middle_item_right">';

    html += '<ul class="ul_body_middle_item_right">';
    for (var i = 0; i < (list.length < 8 ? list.length : 8) ; i++) {
        if (title === "整套出租")
            html += LoadZZFInfo(list[i])
        if (title === "单间出租")
            html += LoadHZFInfo(list[i])
        if (title === "日租短租")
            html += LoadDZFInfo(list[i])
        if (title === "二手房出售")
            html += LoadESFInfo(list[i])
    }
    html += '</ul>';

    html += '</div>';

    html += '</div>';
    $("#div_body_middle").append(html);
}
//加载整租房信息
function LoadZZFInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'FCXX_ZZF\',\'' + obj.ID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.XQMC + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.S + '室 / ' + obj.PFM + '平米 / ' + obj.ZXQK + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + obj.ZJ + '元/月</p>');
    html += ('</li>');
    return html;
}
//加载合租房信息
function LoadHZFInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'FCXX_HZF\',\'' + obj.ID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.XQMC + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.S + '室 / ' + obj.PFM + '平米 / ' + obj.ZXQK + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + obj.ZJ + '元/月</p>');
    html += ('</li>');
    return html;
}
//加载短租房信息
function LoadDZFInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'FCXX_DZF\',\'' + obj.ID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq" style="height:40px;">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('</li>');
    return html;
}
//加载二手房信息
function LoadESFInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'FCXX_ESF\',\'' + obj.ID + '\')" class="li_body_middle_item_right">');
    html += ('<img class="img_li_body_middle_item_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_middle_item_right_xq">' + obj.XQMC + '</p>');
    html += ('<p class="p_li_body_middle_item_right_cs">' + obj.S + '室 / ' + obj.PFM + '平米 / ' + obj.ZXQK + '</p>');
    html += ('<p class="p_li_body_middle_item_right_jg">' + obj.SJ + '万元</p>');
    html += ('</li>');
    return html;
}