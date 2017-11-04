$(document).ready(function () {
    $("#spanWCFB").css("color", "#5bc0de");
    $("#emWCFB").css("background", "#5bc0de");
    $("#btnGLXX").bind("click", ToYHGL);
    GenerateQRCode();
});

function GenerateQRCode() {
    var qrdata = "君临天华B区5号楼单身公寓一套";
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Areas/Business/Ashx/GenerateQRCode.ashx",
        data:
        {
            //FWCZID: getUrlParam("FWCZID"),
            qrdata: qrdata
        },
        success: function (filename) {
            $("#fbcg_share_img").attr("src", getRootPath() + "/Areas/Business/QRCode/" + filename);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function ToYHGL() {
    window.location.href = getRootPath() + "/Business/HTGL/HTGL?YHID=" + getUrlParam("YHID");
}