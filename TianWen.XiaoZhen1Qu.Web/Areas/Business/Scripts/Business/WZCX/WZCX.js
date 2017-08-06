$(document).ready(function () {
    $("#span_content_info_qhcs").bind("click", LoadXZQByGrade);
    $("#divCPHText").bind("click", LoadSJXZQJC);
    $("#divCPHSZMText").bind("click", LoadCPHSZM);
    $("body").bind("click", CloseXZQ);
    $("#input_content_mfcx").bind("click", MFCX);
    $("#inputCPHHWW").bind("blur", CPHCheck);
    $("#inputCJH").bind("blur", CJHCheck);
    $("#inputFDJH").bind("blur", FDJHCheck);
});
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
//选择行政区
function SelectXZQ(NAME) {
    $("#span_content_info_xzq").html(NAME);
    $("#div_XZQ").css("display", "none");
}
//获取行政区简称
function SelectXZQJC(NAME) {
    $("#spanXZQJC").html(NAME);
    $("#div_XZQJC").css("display", "none");
}
//选择车牌号首字母
function SelectCPHSZM(SZM) {
    $("#spanCPHSZM").html(SZM);
    $("#div_CPHSZM").css("display", "none");
}
//关闭行政区
function CloseXZQ() {
    $("#div_XZQ").css("display", "none");
    $("#div_XZQJC").css("display", "none");
}
//加载省级行政区简称
function LoadSJXZQJC() {
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
                    html += '<span class="span_xzq" onclick="SelectXZQJC(\'' + xml.list[i].SHORTNAME + '\')">' + xml.list[i].SHORTNAME + '</span>';
                }
                $("#div_XZQJC").html(html);
                $("#div_XZQJC").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载车牌号首字母
function LoadCPHSZM() {
    var SZMs = new Array("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z");
    var html = "";
    for (var i = 0; i < SZMs.length; i++) {
        html += '<span class="span_xzq" onclick="SelectCPHSZM(\'' + SZMs[i] + '\')">' + SZMs[i] + '</span>';
    }
    $("#div_CPHSZM").html(html);
    $("#div_CPHSZM").css("display", "block");
}
//车牌号检查
function CPHCheck() {
    var CPH = $("#spanXZQJC").html() + $("#spanCPHSZM").html() + $("#inputCPHHWW").val();
    if (!ValidateCPH(CPH) && $("#inputCPHHWW").val().length !== 0) {
        $("#inputCPHHWW").css("border-color", "#F2272D");
        $("#span_CPHInfo").css("color", "#F2272D");
        $("#span_CPHInfo").html("车牌号输入错误");
        return false;
    }
    else if ($("#inputCPHHWW").val().length === 0) {
        $("#inputCPHHWW").css("border-color", "#F2272D");
        $("#span_contespan_CPHInfont_info_llsj").css("color", "#F2272D");
        $("#span_CPHInfo").html("请输入车牌号");
        return false;
    }
    else {
        $("#inputCPHHWW").css("border-color", "#ccc");
        $("#span_CPHInfo").html("");
        return true;
    }
}
//车架号检查
function CJHCheck() {
    if (!(/^\d{6}\b/.test($("#inputCJH").val())) && $("#inputCJH").val().length !== 0) {
        $("#inputCJH").css("border-color", "#F2272D");
        $("#span_CJHInfo").css("color", "#F2272D");
        $("#span_CJHInfo").html("车架号输入错误");
        return false;
    }
    else if ($("#inputCJH").val().length === 0) {
        $("#inputCJH").css("border-color", "#F2272D");
        $("#span_CJHInfo").css("color", "#F2272D");
        $("#span_CJHInfo").html("请输入车架号");
        return false;
    }
    else {
        $("#inputCJH").css("border-color", "#ccc");
        $("#span_CJHInfo").html("");
        return true;
    }
}
//发动机号检查
function FDJHCheck() {
    if (!(/^\d{6}\b/.test($("#inputFDJH").val())) && $("#inputFDJH").val().length !== 0) {
        $("#inputFDJH").css("border-color", "#F2272D");
        $("#span_FDJHInfo").css("color", "#F2272D");
        $("#span_FDJHInfo").html("发动机号输入错误");
        return false;
    }
    else if ($("#inputFDJH").val().length === 0) {
        $("#inputFDJH").css("border-color", "#F2272D");
        $("#span_FDJHInfo").css("color", "#F2272D");
        $("#span_FDJHInfo").html("请输入发动机号");
        return false;
    }
    else {
        $("#inputFDJH").css("border-color", "#ccc");
        $("#span_FDJHInfo").html("");
        return true;
    }
}
//免费查询验证
function MFCXValidate() {
    if (!CPHCheck()) return false;
    if (!CJHCheck()) return false;
    if (!FDJHCheck()) return false;
    return true;
}
//免费查询
function MFCX() {
    if (!MFCXValidate()) return;
}