var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadESCondition();
    LoadHot("QZZPXX_QZZP");
});
//加载条件
function LoadESCondition() {
    LoadConditionByTypeNames("'" + getUrlParam("HYLB") + "类别','每月薪资','职位福利'", "CODES_QZZP", "类别,薪资,福利", "ZWLB,MYXZ,ZWFL", "7,9,15");
    LoadBody("QZZPXX_QZZP", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "类别" && (obj.innerHTML !== "软件")) {
        LoadConditionByParentID(obj.id, "CODES_QZZP", "小类", "XL");
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
////根据TYPENAME获取字典表(私有)
//function LoadConditionByTypeNames(typenames, table, names, ids, lengths) {
//    $.ajax({
//        type: "POST",
//        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAMES",
//        dataType: "json",
//        data:
//        {
//            TYPENAMES: typenames,
//            TBName: table
//        },
//        success: function (xml) {
//            if (xml.Result === 1) {
//                LoadDistrictCondition(xml.districts, "QY");
//                var typelist = typenames.split(',');
//                var namelist = names.split(',');
//                for (var i = 0; i < typelist.length; i++) {
//                    for (var j = 0; j < namelist.length; j++) {
//                        if (typelist[i].indexOf(namelist[j]) !== -1) {
//                            LoadCondition(_.filter(xml.list, function (value) { return typelist[i].indexOf(value.TYPENAME) !== -1; }), namelist[j], ids.split(',')[j], lengths.split(',')[j]);
//                        }
//                    }
//                }
//                SetCondition("HYLB", getUrlParam("HYLB"));
//                LoadBody("QZZPXX_QZZP", currentIndex);
//            }
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

//        }
//    });
//}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("ZWLB,MYXZ,ZWFL,QY");
    condition += (condition === "" ? "HYLB:" : ",HYLB:") + getUrlParam("HYLB");
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
    html += ('<li class="li_body_left">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<p class="p_div_li_body_left_left_bt" onclick="OpenXXXX(\'QZZPXX_QZZP\',\'' + obj.ID + '\')">' + TruncStr(obj.BT, 15) + '</p>');
    html += ('<p class="p_div_li_body_left_left_xz"><span class="span_zj">' + obj.MYXZ + '</span>/月</p>');
    html += ('<p class="p_div_li_body_left_left_fl">' + obj.ZWFL + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_li_body_left_right">申请</span></p>');
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
    html += ('<li onclick="OpenXXXX(\'QZZPXX_QZZP\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.QY + '-' + obj.DD + '</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}