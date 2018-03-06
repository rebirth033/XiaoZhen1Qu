var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadESCondition();
    LoadHot("ESXX_SJSM_BJBDN");
});
//加载条件
function LoadESCondition() {
    LoadConditionByTypeNames("'笔记本类别','手机价格'", "CODES_ES_SJSM", "类别,价格", "LB,JG", "100,100");
}
//加载URL查询条件
function LoadURLCondition() {
    if (getUrlParam("JG") !== null)
        SelectURLCondition(getUrlParam("JG"));
    else if (getUrlParam("LB") !== null) {
        SelectURLCondition(getUrlParam("LB"));
        LoadConditionByParentID(getUrlParam("LB"), "CODES_ES_SJSM", "小类", "XL");
    }
    else if (getUrlParam("PP") !== null)
        SelectURLCondition(getUrlParam("PP"));
    else if (getUrlParam("QY") !== null)
        SelectURLCondition(getUrlParam("QY"));
    else
        LoadBody("ESXX_SJSM_BJBDN", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "类别" && obj.innerHTML === "笔记本配件") {
        $("#ul_condition_body_BJBPP").remove();
        LoadConditionByParentID(obj.id, "CODES_ES_SJSM", "小类", "XL");
    }
    if (name === "类别" && obj.innerHTML === "笔记本") {
        $("#ul_condition_body_XL").remove();
        LoadConditionByTypeNames("'笔记本品牌'", "CODES_ES_SJSM", "品牌", "BJBPP", "15");
    }
    if (name === "类别" && obj.innerHTML === "笔记本回收") {
        $("#ul_condition_body_BJBPP").remove();
        $("#ul_condition_body_XL").remove();
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("ESXX_SJSM_BJBDN", currentIndex);
    ShowSelectCondition("ESXX_SJSM_BJBDN");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("ESXX_SJSM_BJBDN", currentIndex);
    ShowSelectCondition("ESXX_SJSM_BJBDN");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("LB,XL,BJBPP,JG,QY,SF");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ESCX/LoadESXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: condition,
            PageSize: 100,
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
//加载二手单条信息
function LoadInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left" onclick="OpenXXXX(\'ESXX_SJSM_BJBDN\',\'' + obj.ID + '\')">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_nr">' + obj.BCMSString.replace(/<\/?.+?>/g, "") + '</p>');
    html += ('<p class="p_li_body_left_center_dz font_size16">' + obj.QY + ' - ' + obj.DD + '&nbsp;&nbsp;&nbsp;&nbsp;' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_zj">' + obj.JG + '</span>元</p>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载热门推荐
function LoadHot(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ESCX/LoadESXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1",
            PageSize: 100,
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
    html += ('<li onclick="OpenXXXX(\'ESXX_SJSM_BJBDN\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_jg">' + GetJG(obj.JG, '元') + '</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}
//根据条件查询
function SearchByCondition(type) {
    $("#ul_condition_body_SF").find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    if (type === "GR")
        $("#ul_condition_body_SF").find(".li_condition_body:eq(1)").addClass("li_condition_body_active");
    if (type === "SJ")
        $("#ul_condition_body_SF").find(".li_condition_body:eq(2)").addClass("li_condition_body_active");
    LoadBody("ESXX_SJSM_BJBDN", 1);
}