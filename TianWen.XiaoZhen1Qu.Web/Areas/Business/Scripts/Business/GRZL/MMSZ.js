$(document).ready(function () {
    LoadGRZL();
    $("#input_bottom_wcxg").bind("click", WCXG);
});

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
            $("#inputYHM").val(xml.YHJBXX.YHM);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function WCXG() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/GRZL/MMCZ",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID")
        },
        success: function (xml) {
            
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}