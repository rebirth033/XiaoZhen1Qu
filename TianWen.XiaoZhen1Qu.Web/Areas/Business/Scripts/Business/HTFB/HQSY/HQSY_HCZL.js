$(document).ready(function () {
    LoadTCYS();
    LoadGCYS();
    LoadFWFW();
    $("#divTCPPText").bind("click", function () { LoadTCPP(); });
    $("#divGCPPText").bind("click", function () { LoadGCPP(); });
});
//加载头车颜色
function LoadTCYS() {
    var colors = new Array("black:黑", "white:白", "red:红", "rgb(255, 255, 0):黄", "rgb(51, 153, 255):蓝", "rgb(13, 207, 110):绿", "rgb(255, 102, 0):橙");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        $("#div_tcys_right").append('<div class="div_tcys"><span class="span_tcys_left" style="background-color: ' + obj[0] + '"></span><span class="span_tcys_right">' + obj[1] + '</span></div>');
    }
    colors = new Array("rgb(204, 51, 153):紫", "rgb(255, 204, 0):金", "rgb(230, 230, 230):银", "rgb(214, 214, 214):灰", "rgb(153, 102, 0):棕", "rgb(255, 192, 203):粉红", "其他");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        if (i === colors.length - 1)
            $("#div_tcys_right2").append('<div class="div_tcys"><span class="span_tcys_left" style="border:none;"></span><span class="span_tcys_right">' + obj[0] + '</span></div>');
        else
            $("#div_tcys_right2").append('<div class="div_tcys"><span class="span_tcys_left" style="background-color: ' + obj[0] + '"></span><span class="span_tcys_right">' + obj[1] + '</span></div>');
    }
    $(".div_tcys").bind("click", ActiveTCYS);
}
//获取头车颜色
function GetTCYS() {
    var value = "";
    $(".div_tcys").each(function () {
        if ($(this).css("background-color") === "rgb(188, 107, 166)")
            value = $(this).find(".span_tcys_right")[0].innerHTML;
    });
    return value;
}
//设置头车颜色
function SetTCYS(tcys) {
    $(".div_tcys").each(function () {
        if ($(this).find(".span_tcys_right")[0].innerHTML === tcys)
            $(this).css("border-color", "#bc6ba6").css("background-color", "#bc6ba6");
    });
}
//选择头车颜色
function ActiveTCYS() {
    $(".div_tcys").each(function () {
        $(this).css("border-color", "#cccccc").css("background-color", "#ffffff");;
    });
    $(this).css("border-color", "#bc6ba6").css("background-color", "#bc6ba6");
}
//加载跟车颜色
function LoadGCYS() {
    var colors = new Array("black:黑", "white:白", "red:红", "rgb(255, 255, 0):黄", "rgb(51, 153, 255):蓝", "rgb(13, 207, 110):绿", "rgb(255, 102, 0):橙");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        $("#div_gcys_right").append('<div class="div_gcys"><span class="span_gcys_left" style="background-color: ' + obj[0] + '"></span><span class="span_gcys_right">' + obj[1] + '</span></div>');
    }
    colors = new Array("rgb(204, 51, 153):紫", "rgb(255, 204, 0):金", "rgb(230, 230, 230):银", "rgb(214, 214, 214):灰", "rgb(153, 102, 0):棕", "rgb(255, 192, 203):粉红", "其他");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        if (i === colors.length - 1)
            $("#div_gcys_right2").append('<div class="div_gcys"><span class="span_gcys_left" style="border:none;"></span><span class="span_gcys_right">' + obj[0] + '</span></div>');
        else
            $("#div_gcys_right2").append('<div class="div_gcys"><span class="span_gcys_left" style="background-color: ' + obj[0] + '"></span><span class="span_gcys_right">' + obj[1] + '</span></div>');
    }
    $(".div_gcys").bind("click", ActiveGCYS);
}
//获取跟车颜色
function GetGCYS() {
    var value = "";
    $(".div_gcys").each(function () {
        if ($(this).css("background-color") === "rgb(188, 107, 166)")
            value = $(this).find(".span_gcys_right")[0].innerHTML;
    });
    return value;
}
//设置跟车颜色
function SetGCYS(tcys) {
    $(".div_gcys").each(function () {
        if ($(this).find(".span_gcys_right")[0].innerHTML === gcys)
            $(this).css("border-color", "#bc6ba6").css("background-color", "#bc6ba6");
    });
}
//选择跟车颜色
function ActiveGCYS() {
    $(".div_gcys").each(function () {
        $(this).css("border-color", "#cccccc").css("background-color", "#ffffff");;
    });
    $(this).css("border-color", "#bc6ba6").css("background-color", "#bc6ba6");
}
//加载品牌名称
function LoadTCPP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "轿车品牌",
            TBName: "CODES_CL_JC"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_row_right_jcpp_first").html('');
                var html = "";
                html += '<span class="p_row_right_jcpp">请选择品牌<span onclick="CloseTCPP()" class="span_row_right_jcpp">×</span></span>';
                html += '<div class="div_row_right_jcpp_first_left">';
                html += '<ul class="ul_row_right_jcpp_first_left">';
                for (var i = 0; i < BQArray.length; i++) {
                    var count = 0;
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            count++;
                    }
                    if (count !== 0)
                        html += '<li onclick="GoToBQ(\'' + BQArray[i] + '\')" class="li_row_right_jcpp_first_left">' + BQArray[i] + '</li>';
                }
                html += '</ul>';
                html += '</div>';

                html += '<div class="div_row_right_jcpp_first_right">';
                html += '<ul class="ul_row_right_jcpp_first_right">';
                for (var i = 0; i < BQArray.length; i++) {
                    var count = 0;
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            count++;
                    }
                    if (count !== 0)
                        html += '<li id="li_row_right_jcpp_first_right_tag_' + BQArray[i] + '" class="li_row_right_jcpp_first_right_tag">' + BQArray[i] + '</li>';
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            html += '<li onclick="SelectTCPP(\'' + xml.list[j].CODENAME + '\')" class="li_row_right_jcpp_first_right_value">' + xml.list[j].CODENAME + '</li>';
                    }
                }
                html += '</ul>';
                html += '</div>';

                $("#div_row_right_tcpp_first").append(html);
                $("#div_row_right_tcpp_first").css("display", "inline-block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//跳转到标签位置
function GoToBQ(tag) {
    var len = document.getElementById("li_row_right_jcpp_first_right_tag_" + tag).offsetTop - 75;//获取div层到页面顶部的高度 
    $(".ul_row_right_jcpp_first_right").stop().animate({ scrollTop: len }, 300, "swing", function () { });
}
//选择款式
function SelectTCPP(pp) {
    $("#spanTCPP").html(pp);
}
//关闭选择品牌框
function CloseTCPP() {
    $("#div_row_right_tcpp_first").css("display", "none");
}
//加载品牌名称
function LoadGCPP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "轿车品牌",
            TBName: "CODES_CL_JC"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_row_right_jcpp_first").html('');
                var html = "";
                html += '<span class="p_row_right_jcpp">请选择品牌<span onclick="CloseGCPP()" class="span_row_right_jcpp">×</span></span>';
                html += '<div class="div_row_right_jcpp_first_left">';
                html += '<ul class="ul_row_right_jcpp_first_left">';
                for (var i = 0; i < BQArray.length; i++) {
                    var count = 0;
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            count++;
                    }
                    if (count !== 0)
                        html += '<li onclick="GoToBQ(\'' + BQArray[i] + '\')" class="li_row_right_jcpp_first_left">' + BQArray[i] + '</li>';
                }
                html += '</ul>';
                html += '</div>';

                html += '<div class="div_row_right_jcpp_first_right">';
                html += '<ul class="ul_row_right_jcpp_first_right">';
                for (var i = 0; i < BQArray.length; i++) {
                    var count = 0;
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            count++;
                    }
                    if (count !== 0)
                        html += '<li id="li_row_right_jcpp_first_right_tag_' + BQArray[i] + '" class="li_row_right_jcpp_first_right_tag">' + BQArray[i] + '</li>';
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            html += '<li onclick="SelectGCPP(\'' + xml.list[j].CODENAME + '\')" class="li_row_right_jcpp_first_right_value">' + xml.list[j].CODENAME + '</li>';
                    }
                }
                html += '</ul>';
                html += '</div>';

                $("#div_row_right_gcpp_first").append(html);
                $("#div_row_right_gcpp_first").css("display", "inline-block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//跳转到标签位置
function GoToBQ(tag) {
    var len = document.getElementById("li_row_right_jcpp_first_right_tag_" + tag).offsetTop - 75;//获取div层到页面顶部的高度 
    $(".ul_row_right_jcpp_first_right").stop().animate({ scrollTop: len }, 300, "swing", function () { });
}
//选择款式
function SelectGCPP(pp) {
    $("#spanGCPP").html(pp);
}
//关闭选择品牌框
function CloseGCPP() {
    $("#div_row_right_gcpp_first").css("display", "none");
}
//加载婚庆摄影_婚车租赁基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY/LoadHQSY_HCZLJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.HQSY_HCZLJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.HQSY_HCZLJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanTCPP").html(xml.Value.HQSY_HCZLJBXX.TCPP);
                $("#spanGCPP").html(xml.Value.HQSY_HCZLJBXX.GCPP);
                $("#spanQY").html(xml.Value.HQSY_HCZLJBXX.QY);
                $("#spanDD").html(xml.Value.HQSY_HCZLJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.HQSY_HCZLJBXX.TCCZ !== null)
                    SetDX("TCCZ", xml.Value.HQSY_HCZLJBXX.TCCZ);
                if (xml.Value.HQSY_HCZLJBXX.MFTGCH !== null)
                    SetDX("MFTGCH", xml.Value.HQSY_HCZLJBXX.MFTGCH);
                if (xml.Value.HQSY_HCZLJBXX.tcys !== null)
                    Settcys("tcys", xml.Value.HQSY_HCZLJBXX.tcys);
                if (xml.Value.HQSY_HCZLJBXX.GCYS !== null)
                    SetGCYS("GCYS", xml.Value.HQSY_HCZLJBXX.GCYS);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//发布
function FB() {
    if (ValidateAll() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "TCPP", "'" + $("#spanTCPP").html() + "'");
    obj = jsonObj.AddJson(obj, "GCPP", "'" + $("#spanGCPP").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "TCCZ", "'" + GetDX("TCCZ") + "'");
    obj = jsonObj.AddJson(obj, "MFTGCH", "'" + GetDX("MFTGCH") + "'");
    obj = jsonObj.AddJson(obj, "tcys", "'" + Gettcys("tcys") + "'");
    obj = jsonObj.AddJson(obj, "GCYS", "'" + GetGCYS("GCYS") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY/FBHQSY_HCZLJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: ue.getContent(),
            FWZP: GetPhotoUrls()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/Business/FBCG/FBCG";
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}