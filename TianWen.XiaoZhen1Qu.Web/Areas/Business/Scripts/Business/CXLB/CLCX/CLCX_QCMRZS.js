﻿var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadCLCondition();
    LoadHot("CLXX_QCMRZS");
});
//加载条件
function LoadCLCondition() {
    LoadConditionByTypeName("汽车美容/装饰", "CODES_CL", "类别", "LB");
    LoadDistrict("福州", "350100", "QY");
    LoadBody("CLXX_QCMRZS", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "类别" && obj.innerHTML === "洗车") {
        LoadConditionByTypeName("洗车方式", "CODES_CL", "方式", "XCFS");
        LoadConditionByTypeName("洗车地点", "CODES_CL", "地点", "XCDD");
        $("#ul_condition_body_PP").remove();
        $("#ul_condition_body_PZ").remove();
        $("#ul_condition_body_TMFW").remove();
    }
    if (name === "类别" && obj.innerHTML === "打蜡") {
        LoadConditionByTypeName("打蜡品种", "CODES_CL", "品种", "PZ");
        LoadConditionByTypeName("打蜡品牌", "CODES_CL", "品牌", "PP");
        $("#ul_condition_body_XCFS").remove();
        $("#ul_condition_body_XCDD").remove();
        $("#ul_condition_body_TMFW").remove();
    }
    if (name === "类别" && obj.innerHTML === "镀膜") {
        LoadConditionByTypeName("镀膜品牌", "CODES_CL", "品牌", "PP",15);
        $("#ul_condition_body_XCFS").remove();
        $("#ul_condition_body_XCDD").remove();
        $("#ul_condition_body_PZ").remove();
        $("#ul_condition_body_TMFW").remove();
    }
    if (name === "类别" && obj.innerHTML === "封釉") {
        LoadConditionByTypeName("封釉品牌", "CODES_CL", "品牌", "PP", 15);
        $("#ul_condition_body_XCFS").remove();
        $("#ul_condition_body_XCDD").remove();
        $("#ul_condition_body_PZ").remove();
        $("#ul_condition_body_TMFW").remove();
    }
    if (name === "类别" && obj.innerHTML === "玻璃贴膜") {
        LoadConditionByTypeName("玻璃贴膜品牌", "CODES_CL", "品牌", "PP");
        LoadConditionByTypeName("贴膜范围", "CODES_CL", "贴膜范围", "TMFW");
        $("#ul_condition_body_XCFS").remove();
        $("#ul_condition_body_XCDD").remove();
        $("#ul_condition_body_PZ").remove();
    }
    if (name === "类别" && (obj.innerHTML !== "玻璃贴膜" && obj.innerHTML !== "洗车" && obj.innerHTML !== "打蜡" && obj.innerHTML !== "镀膜" && obj.innerHTML !== "封釉")) {
        $("#ul_condition_body_XCFS").remove();
        $("#ul_condition_body_XCDD").remove();
        $("#ul_condition_body_PP").remove();
        $("#ul_condition_body_PZ").remove();
        $("#ul_condition_body_TMFW").remove();
    }

    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("CLXX_QCMRZS", currentIndex);
    ShowSelectCondition("CLXX_QCMRZS");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);var condition = GetAllCondition("LB,PP,CX,JG,QY");
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
                    LoadCL_JCInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载车辆_摩托车单条信息
function LoadCL_JCInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'CLXX_QCMRZS\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'CLXX_QCMRZS\',\'' + obj.ID + '\')">' + TruncStr(obj.BT, 35) + '</p>');
    html += ('<p class="p_li_body_left_center_cs font_size16">' + obj.CX + ' / ' + obj.CCNF + '年 / ' + obj.XSS + '小时' + ' / ' + obj.QY + '-' + obj.DD + '</p>');
    html += ('<p class="p_li_body_left_center_dz font_size16">' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
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
    html += ('<li onclick="OpenXXXX(\'CLXX_QCMRZS\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.QY + ' / ' + obj.DD  + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.LB + '</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.JG + '元</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}