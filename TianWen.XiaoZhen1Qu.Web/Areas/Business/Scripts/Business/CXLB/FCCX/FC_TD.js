var currentIndex = 1;
$(document).ready(function () {
    BindConditionNav();
    $(".li_condition_head:eq(0)").each(function () { $(this).css("background-color", "#ffffff"); });
    BindBodyNav();
    LoadFCCX_SPCZCondition();
    LoadHot("FC_TD");
    LoadBody("FC_TD", currentIndex);
});
//搬定查询条件导航
function BindConditionNav() {
    $(".li_condition_head").bind("click", function () {
        $(".li_condition_head").each(function (i) {
            $(this).css("background-color", "#eeeff1");
        });
        $(this).css("background-color", "#ffffff");
        if ($(this).html() === "出租") {
            LoadFCCX_SPCZCondition();
            LoadBody("FC_TD", currentIndex);
        } else {
            LoadFCCX_SPCSCondition();
            LoadBody("FC_TD", currentIndex);
        }
    });
}
//绑定主体列表导航
function BindBodyNav() {
    $(".li_body_head").bind("click", function () {
        $(".li_body_head").each(function () {
            $(this).css("border-bottom", "1px solid #cccccc").css("color", "#999999").css("font-weight", "normal");
        });
        $(this).css("border-bottom", "2px solid #5bc0de").css("color", "#5bc0de").css("font-weight", "700");
    });
}
//加载房产查询_商铺出租条件
function LoadFCCX_SPCZCondition() {
    $("#div_condition_body").html('');
    var dq = "地区,不限,鼓楼,台江,晋安,仓山,闽侯,福清,马尾,长乐,连江,平潭,罗源,闽清,永泰".split(',');
    var fl = "类型,不限,写字楼,商务中心".split(',');
    var zj = "租金,不限,2000元/月以下,2000-6000元/月,6000-16000元/月,16000元/月以上".split(',');
    var mj = "面积,不限,100平米以下,100-200平米,200-300平米,300-500平米,500-800平米,800-1000平米,1000-2000平米,2000平米以上".split(',');
    LoadCondition(dq, "DQ");
    LoadCondition(zj, "ZJ");
    $("#ul_condition_body_ZJ").append("<li><input id='input_zj_q' class='input_zj' type='text' /><span class='span_zj'>元</span> - <input class='input_zj' id='input_zj_z' type='text' /><span class='span_zj'>元</span></li>");
    LoadCondition(mj, "MJ");
    LoadCondition(fl, "FL");
    $("#ul_condition_body_DQ").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_FL").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_ZJ").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_MJ").find(".li_condition_body").bind("click", SelectCondition);
}
//加载房产查询_商铺出售条件
function LoadFCCX_SPCSCondition() {
    $("#div_condition_body").html('');
    var dq = "地区,不限,鼓楼,台江,晋安,仓山,闽侯,福清,马尾,长乐,连江,平潭,罗源,闽清,永泰".split(',');
    var fl = "类型,不限,写字楼,商务中心".split(',');
    var sj = "售价,不限,200万元以下,200-300万元,300-500万元,500-800万元,800-1200万元,1200-2000万元,2000万元以上".split(',');
    var mj = "面积,不限,100平米以下,100-200平米,200-300平米,300-500平米,500-800平米,800-1000平米,1000-2000平米,2000平米以上".split(',');
    LoadCondition(dq, "DQ");
    LoadCondition(sj, "SJ");
    $("#ul_condition_body_SJ").append("<li><input id='input_zj_q' class='input_zj' type='text' /><span class='span_zj'>元</span> - <input class='input_zj' id='input_zj_z' type='text' /><span class='span_zj'>元</span></li>");
    LoadCondition(mj, "MJ");
    LoadCondition(fl, "FL");
    $("#ul_condition_body_DQ").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_FL").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_SJ").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_MJ").find(".li_condition_body").bind("click", SelectCondition);
}
//选择条件
function SelectCondition() {
    $(this).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(this).addClass("li_condition_body_active");
    $(".div_condition_select").css("display", "block");
    $("#ul_condition_select").html('<li class="li_condition_select_first">筛选条件</li>');
    $(".li_condition_body").each(function () {
        if ($(this).css("color") === "rgb(91, 192, 222)" && $(this).html() !== "不限") {
            $("#ul_condition_select").append('<li onclick="DeleteSelect(this)" class="li_condition_select"><span>' + $(this).html() + '</span><em>x</em></li>');
        }
    });
    LoadBody("FC_TD", currentIndex);
}
//绑定选择条件删除事件
function DeleteSelect(obj) {
    var select = obj.innerHTML;
    $(obj).css("display", "none");
    $(".li_condition_body").each(function () {
        if (select.indexOf($(this).html()) !== -1)
            $(this).parent().find(".li_condition_body").each(function (index) {
                if (index === 0) $(this).addClass("li_condition_body_active");
                else $(this).removeClass("li_condition_body_active");
            });
    });
    if (HasCondition() === "")
        $("#divConditionSelect").css("display", "none");
    LoadBody("FC_TD", currentIndex);
}
//加载查询条件
function LoadCondition(array, type) {
    var html = "";
    html += '<ul id="ul_condition_body_' + type + '" class="ul_condition_body">';
    for (var i = 0; i < array.length; i++) {
        if (i === 0)
            html += '<li class="li_condition_body_first">' + array[i] + '</li>';
        else if (i === 1)
            html += '<li class="li_condition_body li_condition_body_active">' + array[i] + '</li>';
        else
            html += '<li class="li_condition_body">' + array[i] + '</li>';
    }
    html += '</ul>';
    $("#div_condition_body").append(html);
}
//获取查询条件
function GetCondition(type) {
    var value = "";
    $("#ul_condition_body_" + type).find(".li_condition_body").each(function () {
        if ($(this).css("color") === 'rgb(91, 192, 222)')
            value = $(this).html();
    });
    return value;
}
//获取导航查询条件
function GetNavCondition() {
    var value = "";
    $(".li_condition_head").each(function () {
        if ($(this).css("background-color") === 'rgb(255, 255, 255)')
            value = $(this).html();
    });
    return value;
}
//是否有条件
function HasCondition() {
    var condition = "";
    $(".li_condition_body").each(function () {
        if ($(this).html() !== "不限" && $(this).css("color") === "rgb(91, 192, 222)")
            condition += $(this).html();
    });
    return condition;
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = "DQ:" + GetCondition("DQ") + ",FL:" + GetCondition("FL") + ",MJ:" + GetCondition("MJ") + ",GQ:" + GetNavCondition();
    if (GetNavCondition() === "出租")
        condition +=  ",ZJ:" + GetCondition("ZJ");
    else
        condition +=  ",SJ:" + GetCondition("SJ");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCCX/LoadFCXX",
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
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'FC_TD\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'FC_TD\',\'' + obj.ID + '\')">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs font_size16">' + obj.MJ + '平米</p>');
    html += ('<p class="p_li_body_left_center_dz font_size16">' + '[' + obj.QY + '-' + obj.DD + '-' + obj.JTDZ + '] ' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_zj">' + obj.ZJ + '</span>元/月</p>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载出售单条信息
function LoadCSInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'FC_TD\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'FC_TD\',\'' + obj.ID + '\')">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs font_size16">' + obj.MJ + '平米</p>');
    html += ('<p class="p_li_body_left_center_dz font_size16">' + '[' + obj.QY + '-' + obj.DD + '-' + obj.JTDZ + '] ' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_zj">' + obj.SJ + '</span>万元</p>');
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
    html += ('<li onclick="OpenXXXX(\'FC_TD\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.QY + ' / ' + obj.DD + ' / ' + obj.JTDZ + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.MJ + '平</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.ZJ + '元/月</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}