$(document).ready(function () {
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $("#spanWCFB").css("color", "#bc6ba6");
    $("#emWCFB").css("background", "#bc6ba6");
    $("#btnGLXX").bind("click", ToHTGL);
    $("#btnCKXX").bind("click", OpenXXXX);
    $("#btnZFXX").bind("click", FBXX);
    $(".div_radio").bind("click", RadioSelect);
    $(".img_radio").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#title").html("信息小镇_发布信息_发布成功");
    
    LoadDefault();
    GenerateQRCode();
});
//加载默认
function LoadDefault() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadJCXXByJCXXID",
        data:
        {
            JCXXID: getUrlParam("JCXXID")
        },
        success: function (xml) {
            $("#fbcg_info_navigation").html(xml.list[0].DH);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//生成二维码
function GenerateQRCode() {
    var qrdata = "君临天华B区5号楼单身公寓一套";
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Areas/Business/Ashx/GenerateQRCode.ashx",
        data:
        {
            qrdata: qrdata
        },
        success: function (filename) {
            $("#fbcg_share_img").attr("src", getRootPath() + "/Areas/Business/QRCode/" + filename);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//管理信息
function ToHTGL() {
    window.location.href = getRootPath() + "/Business/HTGL/HTGL";
}
//预览信息
function OpenXXXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadXXLBByLBID",
        data:
        {
            LBID: getUrlParam("LBID")
        },
        success: function (xml) {
            window.open(getRootPath() + "/Business/" + xml.list[0].FBYM.split('_')[0] + "XX" + "/" + xml.list[0].FBYM.split('_')[0] + "XX_" + xml.list[0].FBYM.split('_')[1] + "?ID=" + getUrlParam("ID") + "&LBID=" + getUrlParam("LBID"));
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//发布信息
function FBXX() {
    window.open(getRootPath() + "/Business/LBXZ/LBXZ");
}
//选择单选
function RadioSelect() {
    $(this).parent().find(".img_radio").each(function () {
        $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    });
    $(this).find(".img_radio").each(function () {
        $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_purple.png");
        if (this.id === "img_radio_1")
            $("#span_row_right_zj").html("15元");
        if (this.id === "img_radio_2")
            $("#span_row_right_zj").html("28元");
        if (this.id === "img_radio_3")
            $("#span_row_right_zj").html("39元");
        if (this.id === "img_radio_5")
            $("#span_row_right_zj").html("60元");
        if (this.id === "img_radio_7")
            $("#span_row_right_zj").html("77元");
    });
}