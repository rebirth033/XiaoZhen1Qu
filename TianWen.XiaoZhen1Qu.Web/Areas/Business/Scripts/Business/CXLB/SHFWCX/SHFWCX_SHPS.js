var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadSHFWCondition();
    LoadHot("SHFWXX_SHPS");
});
//加载条件
function LoadSHFWCondition() {
    LoadConditionByTypeName("生活配送", "CODES_SHFW", "类别", "LB");
    LoadDistrict("福州", "350100", "QY");
    LoadBody("SHFWXX_SHPS", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "类别" && (obj.innerHTML === "跑腿服务")) {
        LoadConditionByParentID(obj.id, "CODES_SHFW", "小类", "XL", 15);
        $("#ul_condition_body_PP").remove();
    }
    if (name === "类别" && (obj.innerHTML === "桶装水")) {
        LoadConditionByTypeName("桶装水品牌", "CODES_SHFW", "品牌", "PP", 15);
        $("#ul_condition_body_XL").remove();
    }
    if (name === "类别" && (obj.innerHTML !== "跑腿服务" && obj.innerHTML !== "桶装水")) {
        $("#ul_condition_body_XL").remove();
        $("#ul_condition_body_PP").remove();
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("SHFWXX_SHPS", currentIndex);
    ShowSelectCondition("SHFWXX_SHPS");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("LB,XL,PP,QY");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFWCX/LoadSHFWXX",
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
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'SHFWXX_SHPS\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'SHFWXX_SHPS\',\'' + obj.ID + '\')">' + obj.BT + '</p>');
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
        url: getRootPath() + "/Business/SHFWCX/LoadSHFWXX",
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
    html += ('<li onclick="OpenXXXX(\'SHFWCX_SHFW\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + "服务项目:" + obj.LB + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.JG + '元</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}