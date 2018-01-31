$(document).ready(function () {
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $("#spanWCFB").css("color", "#bc6ba6");
    $("#emWCFB").css("background", "#bc6ba6");
    $("#btnGLXX").bind("click", ToHTGL);
    $("#btnCKXX").bind("click", OpenXXXX);
    $("#btnZFXX").bind("click", FBXX);
    $("#title").html("信息小镇_发布信息_发布成功");
    GenerateQRCode();
});
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