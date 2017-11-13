var currentIndex = 1;
$(document).ready(function () {
    $(".li_condition_head:eq(0)").each(function () { $(this).css("background-color", "#ffffff"); });
    BindBodyNav();
    LoadCL_HCCondition();
    LoadHot("CLXX_KC");
    LoadBody("CLXX_KC", currentIndex);
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
    var pp = "品牌,不限,金龙,丰田,申龙,四川现代,中通,开瑞,众泰,依维柯,宇通,海格,大宇客车,安凯,福田客车,黄海客车,中大,长安客车,恒通,西沃客车".split(',');
    var cx = "车系,不限,V20,厦门金龙,YZ6120D160DR,康恩迪,苏州金龙,丰田考斯特,中通汽车,都灵V,宝迪".split(',');
    var jg = "价格,不限,1万元以内,1-2万,2-3万,3-5万,5-8万,8-12万,12-18万,18-24万,24-40万,40万以上".split(',');
    var cl = "车龄,不限,1年以内,1-3年,3-5年,5-8年,8-10年,10年以上".split(',');
    LoadCondition(pp, "PP");
    LoadCondition(cx, "CX");
    LoadCondition(jg, "JG");
    LoadCondition(cl, "CL");
    $("#ul_condition_body_PP").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_CX").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_JG").find(".li_condition_body").bind("click", SelectCondition);
    $("#ul_condition_body_JG").append("<li><input id='input_zj_q' class='input_zj' type='text' /><span class='span_zj'>元</span> - <input class='input_zj' id='input_zj_z' type='text' /><span class='span_zj'>元</span></li>");
    $("#ul_condition_body_CL").find(".li_condition_body").bind("click", SelectCondition);
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
    LoadBody("CLXX_KC", currentIndex);
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
    LoadBody("CLXX_KC", currentIndex);
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
    var condition = "PP:" + GetCondition("PP") + ",CX:" + GetCondition("CX") + ",JG:" + GetCondition("JG");
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
//加载车辆_客车单条信息
function LoadCL_JCInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" onclick="OpenXXXX(\'CLXX_KC\',\'' + obj.ID + '\')" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'CLXX_KC\',\'' + obj.ID + '\')">' + (obj.BT.length > 30 ? (obj.BT.substr(0, 35)+ '...') : obj.BT)  + '</p>');
    html += ('<p class="p_li_body_left_center_cs font_size16">' + obj.SPNF + obj.SPYF + ' / ' + obj.XSLC + '万公里' + ' / ' + obj.CLYS + ' / ' + obj.CX + '</p>');
    html += ('<p class="p_li_body_left_center_dz font_size16">' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_zj">' + obj.JG + '</span>万元</p>');
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
    html += ('<li onclick="OpenXXXX(\'CLXX_KC\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.QY + ' / ' + obj.DD + ' / ' + obj.JTDZ + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.MJ + '平</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.JG + '万元</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}