﻿$(document).ready(function () {
    $("#span_content_info_qhcs").bind("click", ToChangeCity);
    $("body").bind("click", function () { Close("_XZQ");});
    BindXZQClick("QY");
    BindXZQClick("DD");
});
//绑定下拉框
function BindXZQClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//根据级别获取行政区
function LoadXZQByGrade() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/GetDistrictByGrade",
        dataType: "json",
        data:
        {
            Grade: "省级"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    if (xml.list[i].CODENAME === "北京" || xml.list[i].CODENAME === "天津" || xml.list[i].CODENAME === "上海" || xml.list[i].CODENAME === "重庆")
                        html += '<span class="span_xzq" onclick="SelectXZQ(\'' + xml.list[i].CODENAME + '\',\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
                    else
                        html += '<span class="span_xzq" onclick="GetCitys(\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
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
        url: getRootPath() + "/Common/GetDistrictBySuperCode",
        dataType: "json",
        data:
        {
            SuperCode: CODE
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    var CityName = xml.list[i].CODENAME;
                    html += '<span class="span_xzq" onclick="SelectXZQ(\'' + CityName + '\',\'' + xml.list[i].CODEID + '\')">' + CityName + '</span>';
                }
                $("#div_XZQ").html(html);
                $("#div_XZQ").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择行政区
function SelectXZQ(NAME, CODE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/QHXZQ",
        dataType: "json",
        data:
        {
            XZQ: NAME,
            XZQDM: CODE
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#span_content_info_xzq").html(RTrim(NAME, '市'));
                $("#div_XZQ").css("display", "none");
                window.location.reload();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
        }
    });

}
//加载区域
function LoadQY() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadQY",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var height = 341;
                if (xml.list.length < 10)
                    height = parseInt(xml.list.length * 34) + 1;
                var html = "<ul class='ul_select' style='overflow-y: scroll; height:" + height + "px'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectQY(this,\"QY\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divQY").html(html);
                $("#divQY").css("display", "block");
                ActiveStyle("QY");
                Bind("SZQY", "QY", "");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载地段
function LoadDD() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadDD",
        dataType: "json",
        data:
        {
            QY: $("#QYCode").val()
        },
        success: function (xml) {
            if (xml.Result === 1 && xml.list.length>0) {
                var height = 341;
                if (xml.list.length < 10)
                    height = parseInt(xml.list.length * 34) + 1;
                var html = "<ul class='ul_select' style='overflow-y: scroll; height:" + height + "px'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDD(this,\"DD\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divDD").html(html);
                $("#divDD").css("display", "block");
                ActiveStyle("DD");
                Bind("SZQY", "DD", "");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择区域下拉框
function SelectQY(obj, type, code) {
    $("#QYCode").val(code);
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#spanDD").html("请选择地段");
    $("#divDD").css("display", "none");
    
}
//选择地段下拉框
function SelectDD(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//跳转切换行政区页面
function ToChangeCity() {
    window.location.href = getRootPath() + "/SY/ChangeCity";
}