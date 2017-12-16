var currentIndex = 1;
$(document).ready(function () {
    $(".li_condition_head:eq(0)").each(function () { $(this).css("background-color", "#ffffff").css("color", "#bc6ba6"); });
    BindConditionNav("FCXX_CF");
    BindBodyNav();
    LoadCZCondition();
});
//加载出租查询条件
function LoadCZCondition() {
    RemoveCondition("QY,ZJ,SJ,MJ");
    LoadConditionByTypeNames("'土地租金','仓库面积'", "CODES_FC", "租金,面积", "ZJ,MJ", "15,15");
    LoadBody("FCXX_CF", currentIndex);
    LoadHot("FCXX_CF");
}
//加载出售查询条件
function LoadCSCondition() {
    RemoveCondition("QY,ZJ,SJ,MJ");
    LoadConditionByTypeNames("'土地售价','仓库面积'", "CODES_FC", "售价,面积", "ZJ,MJ", "15,15");
    LoadBody("FCXX_CF", currentIndex);
    LoadHot("FCXX_CF");
}
//绑定查询条件导航
function BindConditionNav(type) {
    $(".li_condition_head").bind("click", function () {
        $(".li_condition_head").each(function (i) {
            $(this).css("background-color", "#eeeff1").css("color", "#999999");
        });
        $(this).css("background-color", "#ffffff").css("color", "#bc6ba6");
        if ($(this).html() === "出租") {
            LoadCZCondition();
        } else {
            LoadCSCondition();
        }
    });
}
//选择条件
function SelectCondition(obj, name) {
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("FCXX_CF", currentIndex);
    ShowSelectCondition("FCXX_CF");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("MJ,QY");
    if (GetNavCondition() === "出租") {
        condition += ",GQ:出租";
        if (GetCondition("ZJ") !== "")
            condition += ",ZJ:" + GetCondition("ZJ");
    }
    if (GetNavCondition() === "出售") {
        condition += ",GQ:出售";
        if (GetCondition("SJ") !== "")
            condition += ",SJ:" + GetCondition("SJ");
    }
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCCX/LoadFCXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: LTrim(condition, ','),
            PageSize: 5,
            PageIndex: PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#ul_body_left").html('');
                LoadPage(TYPE, xml.PageCount);
                for (var i = 0; i < xml.list.length; i++) {
                    if (GetNavCondition() === "出租")
                        LoadCZInfo(xml.list[i]);
                    else
                        LoadCSInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载出租单条信息
function LoadCZInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'FCXX_CF\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'FCXX_CF\',\'' + obj.ID + '\')">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs font_size16">' + obj.MJ + '平米</p>');
    html += ('<p class="p_li_body_left_center_dz font_size16">' + '[' + obj.QY + '-' + obj.DD + '] ' + obj.JTDZ + ' ' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right">' + GetJG(obj.ZJ, obj.ZJDW) + '</p>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载出售单条信息
function LoadCSInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'FCXX_CF\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'FCXX_CF\',\'' + obj.ID + '\')">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs font_size16">' + obj.MJ + '平米</p>');
    html += ('<p class="p_li_body_left_center_dz font_size16">' + '[' + obj.QY + '-' + obj.DD + '] ' + obj.JTDZ + ' ' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right">' + GetJG(obj.SJ, "万元") + '</p>');
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
            Condition: "STATUS:1,GQ:" + GetNavCondition(),
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
    html += ('<li onclick="OpenXXXX(\'FCXX_CF\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + TruncStr((obj.QY + ' / ' + obj.DD + ' / ' + obj.JTDZ), 15) + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.MJ + '平米</p>');
    html += ('<p class="p_li_body_right_jg">' + (GetNavCondition() === "出租" ? GetJG(obj.ZJ, obj.ZJDW) : GetJG(obj.SJ, obj.ZJDW)) + '</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}