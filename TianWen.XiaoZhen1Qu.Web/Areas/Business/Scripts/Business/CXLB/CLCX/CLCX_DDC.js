var currentIndex = 1;
$(document).ready(function () {
    $(".li_condition_head:eq(0)").each(function () { $(this).css("background-color", "#ffffff"); });
    BindBodyNav();
    LoadCL_HCCondition();
    LoadHot("CLXX_DDC");
    LoadBody("CLXX_DDC", currentIndex);
});
//绑定主体列表导航
function BindBodyNav() {
    $(".li_body_head").bind("click", function () {
        $(".li_body_head").each(function () {
            $(this).css("border-bottom", "1px solid #cccccc").css("color", "#999999").css("font-weight", "normal");
        });
        $(this).css("border-bottom", "2px solid #5bc0de").css("color", "#5bc0de").css("font-weight", "700");
    });
}
//加载条件
function LoadCL_HCCondition() {
    $("#div_condition_body").html('');
    var cx = "车型,不限,电动自行车,电动摩托车,折叠电动车,迷你电动车,助动车,电动观光车,平衡车".split(',');
    var pp = "品牌,不限,本田,雅马哈,铃木,嘉陵,豪爵,川崎,宗申,哈雷,建设,轻骑,钱江,阿普利亚,力帆,宝马,光阳,比亚乔,隆鑫,金城,春风,新大洲".split(',');
    var jg = "价格,不限,300元以下,300-500元,500-1000元,1000-2000元,2000-3000元,3000-5000元,5000元以上".split(',');
    var dcdy = "电池电压,不限,36V,48V,60V,其它".split(',');
    var dcrl = "电池容量,不限,10-15AH,16-20AH,21-25AH,其它".split(',');
    var dq = "地区,不限,鼓楼,台江,晋安,仓山,闽侯,福清,马尾,长乐,连江,平潭,罗源,闽清,永泰".split(',');
    LoadCondition(cx, "CX");
    LoadCondition(pp, "PP");
    LoadCondition(jg, "JG");
    LoadCondition(dcdy, "DCDY");
    LoadCondition(dcrl, "DCRL");
    LoadCondition(dq, "DQ");
    $("#ul_condition_body_CX").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_PP").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_JG").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_JG").append("<li><input id='input_zj_q' class='input_zj' type='text' /><span class='span_zj'>元</span> - <input class='input_zj' id='input_zj_z' type='text' /><span class='span_zj'>元</span></li>");
    $("#ul_condition_body_DCDY").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_DCRL").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_DQ").find(".li_condition_body").bind("click", SelectCondition);
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
    LoadBody("CLXX_DDC", currentIndex);
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
    LoadBody("CLXX_DDC", currentIndex);
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
    var condition = "PP:" + GetCondition("PP") + ",CX:" + GetCondition("CX") + ",JG:" + GetCondition("JG") + ",DQ:" + GetCondition("DQ");
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
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'CLXX_DDC\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'CLXX_DDC\',\'' + obj.ID + '\')">' + TruncStr(obj.BT, 35) + '</p>');
    html += ('<p class="p_li_body_left_center_cs font_size16">' + obj.LB + ' / ' + obj.SYNX + '年 / ' + obj.XJ + ' / ' + obj.QY + '-' + obj.DD + '</p>');
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
    html += ('<li onclick="OpenXXXX(\'CLXX_DDC\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.QY + ' / ' + obj.DD  + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.LB + '</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.JG + '元</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}