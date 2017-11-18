var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadESCondition();
    LoadHot("ESXX_PWKQ_YCMP");
});
//加载条件
function LoadESCondition() {
    LoadConditionByTypeName("演出门票", "CODES_ES_PWKQ", "类别", "LB");
    LoadConditionByTypeName("卡券价格", "CODES_ES_PWKQ", "价格", "JG");
    LoadDistrict("福州", "350100", "QY");
    LoadBody("ESXX_PWKQ_YCMP", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("ESXX_PWKQ_YCMP", currentIndex);
    ShowSelectCondition("ESXX_PWKQ_YCMP");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("LB,XL,JG,QY");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ESCX/LoadESXX",
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
                    LoadESInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载二手单条信息
function LoadESInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left">');
    html += ('<div class="div_li_body_left_left">');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt" onclick="OpenXXXX(\'ESCX_PWKQ_YCMP\',\'' + obj.ID + '\')">' + TruncStr(obj.BT,35) + '</p>');
    html += (TruncStr(obj.BCMSString, 35));
    html += ('<p class="p_li_body_left_center_dz font_size14">' + obj.QY + ' - ' + obj.DD + '<label>/</label>' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_zj">' + obj.JG + '</span>元</p>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}