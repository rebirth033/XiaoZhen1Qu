﻿$(document).ready(function () {
    $("#spanWCFB").css("color", "#ad5b97");
    $("#emWCFB").css("background", "#ad5b97");
    $("#btnGLXX").bind("click", ToHTGL);
    $("#title").html("信息小镇_发布信息_发布成功");
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

function ToHTGL() {
    window.location.href = getRootPath() + "/Business/HTGL/HTGL";
}