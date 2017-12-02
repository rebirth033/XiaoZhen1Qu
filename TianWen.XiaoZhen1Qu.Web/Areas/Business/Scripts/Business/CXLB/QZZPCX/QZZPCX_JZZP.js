var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadESCondition();
    LoadHot("QZZPXX_JZZP");
});
//加载条件
function LoadESCondition() {
    LoadConditionByTypeNames("'兼职类别'", "CODES_QZZP", "类别", "JZLB", "13");
    LoadBody("QZZPXX_JZZP", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("QZZPXX_JZZP", currentIndex);
    ShowSelectCondition("QZZPXX_JZZP");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("JZLB,QY");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZPCX/LoadQZZPXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: condition,
            PageSize: 5,
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
    html += ('<li class="li_body_left">');
    html += ('<span class="span_li_body_left_bt" onclick="OpenXXXX(\'QZZPXX_JZZP\',\'' + obj.ID + '\')">' + TruncStr(obj.BT, 15) + '</span>');
    html += ('<span class="span_li_body_left_gs">北京闪送科技有限公司</span>');
    html += ('<span class="span_li_body_left_gz">' + obj.XZ + obj.XZDW +'&nbsp;'+ obj.XZJS + '</span>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载热门推荐
function LoadHot(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZPCX/LoadQZZPXX",
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
                    //LoadHotInfo(xml.list[i]);
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
    html += ('<li onclick="OpenXXXX(\'QZZPXX_JZZP\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + "服务项目:" + obj.LB + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.JG + '元</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}