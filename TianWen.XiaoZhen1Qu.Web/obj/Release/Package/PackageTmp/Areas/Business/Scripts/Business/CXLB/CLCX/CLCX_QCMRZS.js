var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadCLCondition();
    LoadHot("CLXX_QCMRZS");
});
//加载条件
function LoadCLCondition() {
    LoadConditionByTypeNames("'汽车美容/装饰类别'", "CODES_CL", "类别", "LB", "100");
}
//加载URL查询条件
function LoadURLCondition() {
    if (getUrlParam("LB") !== null)
        SelectURLCondition(getUrlParam("LB"));
    else if (getUrlParam("QY") !== null)
        SelectURLCondition(getUrlParam("QY"));
    else
        LoadBody("CLXX_QCMRZS", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    //if (name === "类别" && obj.innerHTML === "洗车") {
    //    LoadConditionByTypeNames("'洗车方式','洗车地点'", "CODES_CL", "方式,地点", "XCFS,XCDD", "100,100");
    //    $("#ul_condition_body_PP").remove();
    //    $("#ul_condition_body_PZ").remove();
    //    $("#ul_condition_body_TMFW").remove();
    //}
    //if (name === "类别" && obj.innerHTML === "打蜡") {
    //    LoadConditionByTypeNames("'打蜡品种','打蜡品牌'", "CODES_CL", "品种,品牌", "PZ,PP", "100,100");
    //    $("#ul_condition_body_XCFS").remove();
    //    $("#ul_condition_body_XCDD").remove();
    //    $("#ul_condition_body_TMFW").remove();
    //}
    //if (name === "类别" && obj.innerHTML === "镀膜") {
    //    LoadConditionByTypeNames("'镀膜品牌'", "CODES_CL", "品牌", "PP", "15");
    //    $("#ul_condition_body_XCFS").remove();
    //    $("#ul_condition_body_XCDD").remove();
    //    $("#ul_condition_body_PZ").remove();
    //    $("#ul_condition_body_TMFW").remove();
    //}
    //if (name === "类别" && obj.innerHTML === "封釉") {
    //    LoadConditionByTypeNames("'封釉品牌'", "CODES_CL", "品牌", "PP", "15");
    //    $("#ul_condition_body_XCFS").remove();
    //    $("#ul_condition_body_XCDD").remove();
    //    $("#ul_condition_body_PZ").remove();
    //    $("#ul_condition_body_TMFW").remove();
    //}
    //if (name === "类别" && obj.innerHTML === "玻璃贴膜") {
    //    LoadConditionByTypeNames("'玻璃贴膜品牌','贴膜范围'", "CODES_CL", "品牌,贴膜范围", "PP,TMFW", "100,100");
    //    $("#ul_condition_body_XCFS").remove();
    //    $("#ul_condition_body_XCDD").remove();
    //    $("#ul_condition_body_PZ").remove();
    //}
    //if (name === "类别" && (obj.innerHTML !== "玻璃贴膜" && obj.innerHTML !== "洗车" && obj.innerHTML !== "打蜡" && obj.innerHTML !== "镀膜" && obj.innerHTML !== "封釉")) {
    //    $("#ul_condition_body_XCFS").remove();
    //    $("#ul_condition_body_XCDD").remove();
    //    $("#ul_condition_body_PP").remove();
    //    $("#ul_condition_body_PZ").remove();
    //    $("#ul_condition_body_TMFW").remove();
    //}

    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("CLXX_QCMRZS", currentIndex);
    ShowSelectCondition("CLXX_QCMRZS");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("CLXX_QCMRZS", currentIndex);
    ShowSelectCondition("CLXX_QCMRZS");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("LB,PP,CX,JG,QY");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CLCX/LoadCLXX",
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
    html += ('<li class="li_body_left" onclick="OpenXXXX(\'CLXX_QCMRZS\',\'' + obj.ID + '\')">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_nr">' + obj.BCMSString.replace(/<\/?.+?>/g, "") + '</p>');
    html += ('<p class="p_li_body_left_center_dz font_size16">' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_li_body_left_right">联系商家</span></p>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载热门推荐
function LoadHot(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CLCX/LoadCLXX",
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
    html += ('<li onclick="OpenXXXX(\'CLXX_QCMRZS\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}