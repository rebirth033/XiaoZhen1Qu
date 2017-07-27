var sj = "", yx = "", qq = "", wb = "", wx = "";
$(document).ready(function () {
    $("#span_content_info_right_rzsj").bind("click", UpdateSJ);
    $("#span_content_info_right_yxbd").bind("click", UpdateYX);
    $("#span_content_info_right_qqbd").html("立即绑定");
    $("#span_content_info_right_xlwb").html("立即绑定");
    $("#span_content_info_right_wxbd").html("立即绑定");
    $("#span_content_info_right_qqbd").css("background-color", "#e16f28");
    $("#span_content_info_right_xlwb").css("background-color", "#e16f28");
    $("#span_content_info_right_wxbd").css("background-color", "#e16f28");
    LoadGRZL();
});

function UpdateSJ() {
    window.location.href = getRootPath() + "/Business/GRZL/HBSJ?SJ=" + sj + "&YHID=" + getUrlParam("YHID");
}

function UpdateYX() {
    window.location.href = getRootPath() + "/Business/GRZL/YXYZ?YX=" + yx + "&YHID=" + getUrlParam("YHID");
}

function LoadGRZL() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/GRZL/GetGRZL",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID")
        },
        success: function (xml) {
            sj = xml.YHJBXX.SJ;
            yx = xml.YHJBXX.DZYX;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}