$(document).ready(function () {
    $("#span_content_info_qhcs").bind("click", LoadXZQByGrade);
});

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
                $("#div_xzq").html(html);
                $("#div_xzq").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

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
                $("#div_xzq").html(html);
                $("#div_xzq").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function SelectXZQ(NAME) {
    $("#span_content_info_xzq").html(NAME);
    $("#div_xzq").css("display", "none");
}