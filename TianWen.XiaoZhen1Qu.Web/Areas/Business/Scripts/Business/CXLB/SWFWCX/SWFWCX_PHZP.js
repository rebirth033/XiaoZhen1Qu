var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadSWFWCondition();
    LoadHot("SWFWXX_PHZP");
});
//加载条件
function LoadSWFWCondition() {
    LoadConditionByTypeName("喷绘招牌", "CODES_SWFW", "类别", "LB", 15);
    LoadDistrict("福州", "350100", "QY");
    LoadBody("SWFWXX_PHZP", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "类别" && (obj.innerHTML !== "标牌" && obj.innerHTML !== "LED显示屏" && obj.innerHTML !== "条幅/锦旗/奖牌")) {
        LoadConditionByParentID(obj.id, "CODES_SWFW", "小类", "XL", 15);
        if (obj.innerHTML === "灯箱/招牌") {
            LoadConditionByTypeName("灯箱/招牌材质", "CODES_SWFW", "材质", "CZ");
            LoadConditionByTypeName("灯箱/招牌工艺", "CODES_SWFW", "工艺", "GY");
            LoadConditionByTypeName("是否发光", "CODES_SWFW", "是否发光", "SFFG");
        }
        else {
            $("#ul_condition_body_CZ").remove();
            $("#ul_condition_body_YT").remove();
            $("#ul_condition_body_GN").remove();
            $("#ul_condition_body_GY").remove();
            $("#ul_condition_body_SFFG").remove();
        }
    }
    if (name === "类别" && (obj.innerHTML === "标牌" || obj.innerHTML === "LED显示屏" || obj.innerHTML === "条幅/锦旗/奖牌")) {
        $("#ul_condition_body_XL").remove();
        if (obj.innerHTML === "标牌") {
            LoadConditionByTypeName("标牌用途", "CODES_SWFW", "用途", "YT");
            LoadConditionByTypeName("标牌功能", "CODES_SWFW", "功能", "GN");
            LoadConditionByTypeName("标牌材质", "CODES_SWFW", "材质", "CZ");
        }
        else {
            $("#ul_condition_body_CZ").remove();
            $("#ul_condition_body_YT").remove();
            $("#ul_condition_body_GN").remove();
            $("#ul_condition_body_GY").remove();
            $("#ul_condition_body_SFFG").remove();
        }
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("SWFWXX_PHZP", currentIndex);
    ShowSelectCondition("SWFWXX_PHZP");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("LB,XL,CZ,GY,SFFG,QY");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFWCX/LoadSWFWXX",
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
//加载求职招聘单条信息
function LoadQZZPInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'SWFWXX_PHZP\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'SWFWXX_PHZP\',\'' + obj.ID + '\')">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs">' + obj.MJ + '平米' + '</p>');
    html += ('<p class="p_li_body_left_center_dz">' + obj.XQMC + ' [' + obj.XQDZ + '] ' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
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
        url: getRootPath() + "/Business/SWFWCX/LoadSWFWXX",
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
    html += ('<li onclick="OpenXXXX(\'SWFWCX_SWFW\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + "服务项目:" + obj.LB + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.JG + '元</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}