var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadESCondition();
    LoadHot("QZZPXX_QZZP");
});
//加载条件
function LoadESCondition() {
    LoadConditionByTypeName(getUrlParam("ZWLB"), "CODES_QZZP", "类别", "ZWLB", 10);
    LoadConditionByTypeName("每月薪资", "CODES_QZZP", "薪资", "MYXZ");
    LoadConditionByTypeName("职位福利", "CODES_QZZP", "福利", "ZWFL");
    LoadDistrict("福州", "350100", "QY");
    LoadBody("QZZPXX_QZZP", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "类别" && (obj.innerHTML !== "软件")) {
        LoadConditionByParentID(obj.id, "CODES_ES_WHYL", "小类", "XL");
    }
    if (name === "类别" && (obj.innerHTML === "软件")) {
        $("#ul_condition_body_XL").remove();
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("QZZPXX_QZZP", currentIndex);
    ShowSelectCondition("QZZPXX_QZZP");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("ZWLB,MYXZ,ZWFL,QY");
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
                    LoadQZZPInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载单条信息
function LoadQZZPInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<p class="p_div_li_body_left_left_bt" onclick="OpenXXXX(\'QZZPCX_QZZP\',\'' + obj.ID + '\')">' + TruncStr(obj.BT, 15) + '</p>');
    html += ('<p class="p_div_li_body_left_left_xz"><span class="span_zj">' + obj.MYXZ + '</span>/月</p>');
    html += ('<p class="p_div_li_body_left_left_fl">' + obj.ZWFL + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('</div>');
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
    html += ('<li onclick="OpenXXXX(\'QZZPCX_QZZP\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + "服务项目:" + obj.LB + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.JG + '元</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}
//获取头部导航
function GetHeadNav() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadSY_ML",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += ('<ul class="ul_nav">');
                html += ('<li class="li_nav_font">信息小镇</li>');
                html += ('<li class="li_nav_split">></li>');
                for (var i = 0; i < xml.list.length; i++) {
                    if (xml.list[i].LBID === parseInt(getUrlParam("LBID"))) {
                        html += ('<li class="li_nav_font">' + xml.xzq + xml.list[i].TYPESHOWNAME + '</li>');
                        break;
                    }
                }
                html += ('<li class="li_nav_split">></li>');
                html += ('<li class="li_nav_font">' + xml.xzq + getUrlParam("ZWLB") + xml.list[i].TYPESHOWNAME + '</li>');
                $("#li_body_head_first").html(xml.xzq + xml.list[i].LBNAME + "");
                html += ('</ul>');
                $("#divNav").html(html);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}