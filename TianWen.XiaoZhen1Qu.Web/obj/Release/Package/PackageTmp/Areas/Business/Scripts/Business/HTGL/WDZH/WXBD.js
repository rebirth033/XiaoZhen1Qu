$(document).ready(function () {
    GenerateQRCode();
});

//生成二维码
function GenerateQRCode() {
    var qrdata = "风铃网";
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Areas/Business/Ashx/GenerateQRCode.ashx",
        data:
        {
            qrdata: qrdata
        },
        success: function (filename) {
            $("#span_body_info").css("background-image", "url(" + getRootPath() + "/Areas/Business/QRCode/" + filename + ")");
            $("#span_body_info").css("background-repeat", "no-repeat");
            $("#span_body_info").css("background-size", "100%");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}