var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadFCCondition();
    LoadHot("FCXX_ZZF");
    LoadHeadSearch();
});
//加载头部搜索栏关键字
function LoadHeadSearch() {
    $(".div_head_right_ss").append('<span class="span_head_right_ss">独立阳台</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss">独立卫生间</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss">邻近地铁</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss">南北通透</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss">精装修</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss">支持月付</span>');
}
//加载房产查询条件
function LoadFCCondition() {
    LoadConditionByTypeNames("'整租房租金','厅室','朝向','装修情况','出租房屋亮点'", "CODES_FC", "租金,厅室,朝向,装修情况,房屋亮点", "ZJ,S,CX,ZXQK,FWLD", "15,15,15,15,15");
    LoadBody("FCXX_ZZF", currentIndex);
}
//加载URL查询条件
function LoadURLCondition() {
    if (getUrlParam("FWLD") !== null)
        SelectURLCondition(getUrlParam("FWLD"));
}
//选择条件
function SelectCondition(obj) {
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("FCXX_ZZF", currentIndex);
    ShowSelectCondition("FCXX_ZZF");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("FCXX_ZZF", currentIndex);
    ShowSelectCondition("FCXX_ZZF");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("QY,S,ZJ,CX,ZXQK,FWLD");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCCX/LoadFCXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: condition,
            PageSize: 10,
            PageIndex: PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#ul_body_left").html('');
                LoadPage(TYPE, xml.PageCount);
                for (var i = 0; i < xml.list.length; i++) {
                    LoadInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载单条信息
function LoadInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left" onclick="OpenXXXX(\'FCXX_ZZF\',\'' + obj.ID + '\')">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs">整套出租 / ' + obj.S + '室' + obj.T + '厅' + obj.W + '卫 / ' + obj.PFM + '平米 / ' + obj.ZXQK + ' / ' + obj.CX + ' / ' + obj.C + '层[共' + obj.GJC + '层]</p>');
    html += ('<p class="p_li_body_left_center_dz">' + obj.XQMC + obj.XQDZ + ' ' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_zj">' + obj.ZJ + '</span>元/月</p>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载热门推荐
function LoadHot(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCCX/LoadFCXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1",
            PageSize: 5,
            PageIndex: 1
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#ul_body_right").html('');
                for (var i = 0; i < xml.list.length; i++) {
                    LoadHotInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载热门单条信息
function LoadHotInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'FCXX_ZZF\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.XQMC + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.S + '室 / ' + obj.PFM + '平米 / ' + obj.ZXQK + '</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.ZJ + '元/月</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}