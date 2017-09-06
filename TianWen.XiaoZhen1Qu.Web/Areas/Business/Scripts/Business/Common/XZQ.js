//选择行政区
function SelectXZQ(NAME) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/QHXZQ",
        dataType: "json",
        data:
        {
            XZQ: NAME
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#span_content_info_xzq").html(RTrim(NAME, '市'));
                $("#div_XZQ").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
        }
    });
   
}
//根据级别获取行政区
function LoadXZQByGrade() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/GetDistrictByGrade",
        dataType: "json",
        data:
        {
            Grade: "省级"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    if (xml.list[i].NAME === "北京市" || xml.list[i].NAME === "天津市" || xml.list[i].NAME === "上海市" || xml.list[i].NAME === "重庆市")
                        html += '<span class="span_xzq" onclick="SelectXZQ(\'' + xml.list[i].NAME + '\')">' + xml.list[i].NAME + '</span>';
                    else
                        html += '<span class="span_xzq" onclick="GetCitys(\'' + xml.list[i].CODE + '\')">' + xml.list[i].NAME + '</span>';
                }
                $("#div_XZQ").html(html);
                $("#div_XZQ").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//获取市
function GetCitys(CODE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/GetDistrictBySuperCode",
        dataType: "json",
        data:
        {
            SupserCode: CODE
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    var CityName = xml.list[i].NAME.replace("市", "").replace("县", "").replace("地区", "").replace("林区", "");
                    html += '<span class="span_xzq" onclick="SelectXZQ(\'' + CityName + '\')">' + CityName + '</span>';
                }
                $("#div_XZQ").html(html);
                $("#div_XZQ").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//关闭行政区
function CloseXZQ() {
    $("#div_XZQ").css("display", "none");
}