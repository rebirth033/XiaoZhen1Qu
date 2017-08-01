var currentIndex = 1;
$(document).ready(function () {
    $("#span_main_info_head_fhsyj").bind("click", Back);
    $("#span_main_info_bottom_fhsyj").bind("click", Back);
    LoadDefault("divXTTZLB", currentIndex);
});

function LoadDefault(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/XXGL/LoadYHXXMX",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID"),
            YHXXID: getUrlParam("YHXXID")
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
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function Back() {
    window.location.href = getRootPath() + "/Business/XXGL/XXGL?YHID=" + getUrlParam("YHID");
}