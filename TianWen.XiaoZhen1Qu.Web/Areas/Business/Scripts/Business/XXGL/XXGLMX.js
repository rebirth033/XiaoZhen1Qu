$(document).ready(function () {
    $("#span_main_info_head_fhsyj").bind("click", Back);
    $("#span_main_info_bottom_fhsyj").bind("click", Back);
    $("#span_main_info_head_syt").bind("click", Up);
    $("#span_main_info_head_xyt").bind("click", Down);
    $("#input_yhxxid").val(getUrlParam("YHXXID"));
    LoadDefault("divXTTZLB");
});
//加载默认
function LoadDefault(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/XXGL/LoadYHXXMX",
        dataType: "json",
        data:
        {
            YHXXID: $("#input_yhxxid").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#tbody_main_info_xttz").html('');
                $("#span_main_info_head_gjt").html(getUrlParam("GJT"));
                $("#span_main_info_head_wdjt").html(getUrlParam("WDJT"));
                $("#span_main_info_bottom_gjt").html(getUrlParam("GJT"));
                $("#span_main_info_bottom_wdjt").html(getUrlParam("WDJT"));
                $("#td_main_info_info_right_zt").html(xml.YHXX.XXNR);
                $("#td_main_info_info_right_sj").html(xml.YHXX.XXSJ.ToString("yyyy-MM-dd hh:mm:ss"));
                $("#td_main_info_info_right_fjr").html(xml.YHXX.FJR);
                $("#td_main_info_info_right_xxxx").html(HTMLDecode(xml.YHXX.XXXXSTR));
                $("#input_yhxxid").val(xml.YHXX.YHXXID);
                HandleUD(xml.HasUp, xml.HasDown);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//返回消息管理列表
function Back() {
    window.location.href = getRootPath() + "/Business/XXGL/XXGL";
}
//上一条消息明细
function Up() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/XXGL/LoadUpYHXXMX",
        dataType: "json",
        data:
        {
            YHXXID: $("#input_yhxxid").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#tbody_main_info_xttz").html('');
                $("#span_main_info_head_gjt").html(getUrlParam("GJT"));
                $("#span_main_info_head_wdjt").html(getUrlParam("WDJT"));
                $("#span_main_info_bottom_gjt").html(getUrlParam("GJT"));
                $("#span_main_info_bottom_wdjt").html(getUrlParam("WDJT"));
                $("#td_main_info_info_right_zt").html(xml.YHXX.XXNR);
                $("#td_main_info_info_right_sj").html(xml.YHXX.XXSJ.ToString("yyyy-MM-dd hh:mm:ss"));
                $("#td_main_info_info_right_fjr").html(xml.YHXX.FJR);
                $("#td_main_info_info_right_xxxx").html(HTMLDecode(xml.YHXX.XXXXSTR));
                $("#input_yhxxid").val(xml.YHXX.YHXXID);
                HandleUD(xml.HasUp, xml.HasDown);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//下一条消息明细
function Down()
{
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/XXGL/LoadDownYHXXMX",
        dataType: "json",
        data:
        {
            YHXXID: $("#input_yhxxid").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#tbody_main_info_xttz").html('');
                $("#span_main_info_head_gjt").html(getUrlParam("GJT"));
                $("#span_main_info_head_wdjt").html(getUrlParam("WDJT"));
                $("#span_main_info_bottom_gjt").html(getUrlParam("GJT"));
                $("#span_main_info_bottom_wdjt").html(getUrlParam("WDJT"));
                $("#td_main_info_info_right_zt").html(xml.YHXX.XXNR);
                $("#td_main_info_info_right_sj").html(xml.YHXX.XXSJ.ToString("yyyy-MM-dd hh:mm:ss"));
                $("#td_main_info_info_right_fjr").html(xml.YHXX.FJR);
                $("#td_main_info_info_right_xxxx").html(HTMLDecode(xml.YHXX.XXXXSTR));
                $("#input_yhxxid").val(xml.YHXX.YHXXID);
                HandleUD(xml.HasUp, xml.HasDown);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//上下翻处理
function HandleUD(HasUp, HasDown) {
    if (HasUp === 0){
        $("#span_main_info_head_syt").css("display", "none");
        $("#span_main_info_bottom_syt").css("display", "none");
    }
    else
        {
        $("#span_main_info_head_syt").css("display", "block");
        $("#span_main_info_bottom_syt").css("display", "block");
    }
    if (HasDown === 0){
        $("#span_main_info_head_xyt").css("display", "none");
        $("#span_main_info_bottom_xyt").css("display", "none");
    }
    else{
        $("#span_main_info_head_xyt").css("display", "block");
        $("#span_main_info_bottom_xyt").css("display", "block");
    }
}