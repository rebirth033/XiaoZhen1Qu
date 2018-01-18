$(document).ready(function () {
    $("#span_content_info_left_zffs_zfb").bind("click", SelectZFB);
    $("#span_content_info_left_zffs_wx").bind("click", SelectWX);
    $("#inputHFLJCZ").bind("click", LJCZ);
    SelectZFB();
    GenerateQRCode("微信支付,用户名：980361288@qq.com", "span_content_info_qrcode");
});
//选择支付宝
function SelectZFB() {
    $("#span_content_info_left_zffs_zfb").css("border-color", "#bc6ba6");
    $("#span_content_info_left_zffs_wx").css("border-color", "#cccccc");
    $("#div_content_info_zfb").css("display", "block");
    $("#div_content_info_wx").css("display", "none");
}
//选择微信
function SelectWX() {
    $("#span_content_info_left_zffs_zfb").css("border-color", "#cccccc");
    $("#span_content_info_left_zffs_wx").css("border-color", "#bc6ba6");
    $("#div_content_info_zfb").css("display", "none");
    $("#div_content_info_wx").css("display", "block");
}
//生成二维码
function GenerateQRCode(qrdata, bindtag) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Areas/Business/Ashx/GenerateQRCode.ashx",
        data:
        {
            qrdata: qrdata
        },
        success: function (filename) {
            $("#" + bindtag).css("background-image", "url(" + getRootPath() + "/Areas/Business/QRCode/" + filename + ")");
            $("#" + bindtag).css("background-repeat", "no-repeat");
            $("#" + bindtag).css("background-size", "100%");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

//跳转支付宝支付页面
function LJCZ() {
    
}