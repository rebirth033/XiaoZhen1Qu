$(document).ready(function () {
    $("#spanDKCZ").css("color", "#5bc0de");
    $("#spanDKCZ").css("font-weight", "700");
    $("#emDKCZ").css("background-color", "#5bc0de");
    $("#emDKCZ").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    $("#span_content_info_cxxz").bind("click", CCXZ);
    $("input[type='radio']").bind("click", MZXZ);
    $(".radio_content_info_right_mz").bind("click", CalSJ);
    Load("divDKCZ");
}); 
//标题切换
function HeadActive() {
    $(".divstep").each(function () {
        $(this).find("span").each(function () {
            $(this).css("color", "#cccccc");
            $(this).css("font-weight", "normal");
        });
        $(this).find("em").each(function () {
            $(this).css("height", "1px");
            $(this).css("background-color", "#cccccc");
        });
    });
    $(this).find("span").each(function () {
        $(this).css("color", "#5bc0de");
        $(this).css("font-weight", "700");
    });
    $(this).find("em").each(function () {
        $(this).css("height", "2px");
        $(this).css("background-color", "#5bc0de");
    });
    Load(this.id);
}
//加载页面
function Load(id) {
    if (id === "divDKCZ") {
        $("#div_content_dkcz").css("display", "block");
        $("#div_content_jbcz").css("display", "none");
        LoadYXBQ();
        LoadRMYX();
    } else {
        $("#div_content_dkcz").css("display", "none");
        $("#div_content_jbcz").css("display", "block");
    }
}
//加载游戏标签
function LoadYXBQ() {
    var arrayObj = new Array('RMYX','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        if(i === 0)
            html += '<div class="div_bqss_content_bq" id="div' + arrayObj[i] + '" style="width:94px;"><span class="span_bqss_content_bq" id="span' + arrayObj[i] + '">' + "热门游戏" + '</span><em class="em_bqss_content_bq" style="width:94px;" id="em' + arrayObj[i] + '"></em></div>';
        else
            html += '<div class="div_bqss_content_bq" id="div' + arrayObj[i] + '"><span class="span_bqss_content_bq" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="em_bqss_content_bq" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_bqss_body_bq").html(html);

    $(".div_bqss_content_bq").bind("mouseover", YXBQActive);
}
//游戏标签切换
function YXBQActive() {
    $("#div_bqss_body_bq").find("span").each(function () {
        $(this).css("color", "#cccccc");
        $(this).css("font-weight", "normal");
    });
    $("#div_bqss_body_bq").find("em").each(function () {
        $(this).css("height", "1px");
        $(this).css("background-color", "#cccccc");
    });
    $(this).find("span").each(function () {
        $(this).css("color", "#5bc0de");
        $(this).css("font-weight", "700");
    });
    $(this).find("em").each(function () {
        $(this).css("height", "2px");
        $(this).css("background-color", "#5bc0de");
    });
    LoadYXMC(this.id);
}
//加载游戏名称
function LoadYXMC(SZM) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/YXCZ/LoadYXJBXX",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID"),
            SZM: SZM.split("div")[1]
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_mc" onclick="YXCZ(\'' + xml.list[i].YXMC + '\')">' + xml.list[i].YXMC + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_mc">该字母下暂无数据</span>';
                $("#div_bqss_body_mc").html(html);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载热门游戏
function LoadRMYX() {
    $("#spanRMYX").css("color", "#5bc0de");
    $("#spanRMYX").css("font-weight", "700");
    $("#emRMYX").css("height", "2px");
    $("#emRMYX").css("background-color", "#5bc0de");
    LoadYXMC("divRMYX");
}
//重新选择
function CCXZ() {
    $("#div_content_yxcz").css("display", "none");
    $("#div_content_yxxz").css("display", "block");
}
//游戏充值
function YXCZ(yxmc) {
    $("#div_content_yxcz").css("display", "block");
    $("#div_content_yxxz").css("display", "none");
    $("#span_content_info_yxmc").html(yxmc);
}
//面值选择
function MZXZ() {
    $("input[type='radio']").each(function () {
        $(this).prop("checked", false);
    });
    $(this).prop("checked", true);
}
//获取售价
function CalSJ() {
    var obj = $(this).parent().find("span");
    $("#inputSJ").val(parseFloat(RTrim(obj[0].innerHTML, "元")) * 0.985 + "元");
}