var sj = "", yx = "", qq = "", wb = "", wx = "";
$(document).ready(function () {
    $("#span_content_info_right_rzsj").bind("click", SJBD);
    LoadGRZL();
});

function SJBD() {
    window.location.href = getRootPath() + "/GRZL/HBSJ?SJ=" + sj + "&YHID=" + getUrlParam("YHID");
}

function YXBD() {
    window.location.href = getRootPath() + "/GRZL/YXYZ?YHID=" + getUrlParam("YHID");
}

function QQBD() {
    $(window.parent.document).find("#shadow").each(function() {
        $(this).css("width", window.parent.document.body.clientWidth);
        $(this).css("height", window.parent.document.body.clientHeight);
        $(this).css("display", "block");
    });
    $(window.parent.document).find("#editImgWindow").each(function () {
        $(this).css("left", window.screen.availWidth / 2 - 200);
        $(this).css("top", window.screen.availHeight / 2 - 210);
        $(this).css("display", "block");
    });
    $(window.parent.document).find("#span_body_qqtx").each(function () {
        $(this).css("background-image", "url(" + getRootPath() + "/Areas/Business/Css/images/qqtx.png" + ")");
        $(this).css("background-repeat", "no-repeat");
    });
    GenerateQRCode();
}

function WBBD() {
    window.location.href = getRootPath() + "/ZHBD/WBBD?YHID=" + getUrlParam("YHID");
}

function WXBD() {
    window.location.href = getRootPath() + "/ZHBD/WXBD?YHID=" + getUrlParam("YHID");
}

function LoadGRZL() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/GRZL/GetGRZL",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID")
        },
        success: function (xml) {
            sj = xml.YHJBXX.SJ;
            yx = xml.YHJBXX.DZYX;
            qq = xml.YHJBXX.QQ;
            wb = xml.YHJBXX.WB;
            wx = xml.YHJBXX.WX;
            HandleBD(yx, qq, wb, wx);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function HandleBD(yx, qq, wb, wx) {
    if (yx === "" || yx === null) {
        $("#span_content_info_right_yxbd").css("display", "block");
        $("#span_content_info_right_yxhd").css("display", "none");
        $("#span_content_info_right_yxbd").bind("click", YXBD);
    } else {
        $("#span_content_info_right_yxbd").css("display", "none");
        $("#span_content_info_right_yxhd").css("display", "block");
        $("#span_content_info_right_yxhd").bind("click", YXBD);
    }
    if (qq === "" || qq === null) {
        $("#span_content_info_right_qqbd").css("display", "block");
        $("#span_content_info_right_qqjb").css("display", "none");
        $("#span_content_info_right_qqbd").bind("click", QQBD);
    } else {
        $("#span_content_info_right_qqbd").css("display", "none");
        $("#span_content_info_right_qqjb").css("display", "block");
        $("#span_content_info_right_qqjb").bind("click", QQJB);
    }
    if (wb === "" || wb === null) {
        $("#span_content_info_right_wbbd").css("display", "block");
        $("#span_content_info_right_wbjb").css("display", "none");
        $("#span_content_info_right_wbbd").bind("click", WBBD);
    } else {
        $("#span_content_info_right_wbbd").css("display", "none");
        $("#span_content_info_right_wbjb").css("display", "block");
        $("#span_content_info_right_wbjb").bind("click", WBJB);
    }
    if (wx === "" || wx === null) {
        $("#span_content_info_right_wxbd").css("display", "block");
        $("#span_content_info_right_wxjb").css("display", "none");
        $("#span_content_info_right_wxbd").bind("click", WXBD);
    } else {
        $("#span_content_info_right_wxbd").css("display", "none");
        $("#span_content_info_right_wxjb").css("display", "block");
        $("#span_content_info_right_wxjb").bind("click", WXJB);
    }
}
//生成二维码
function GenerateQRCode() {
    var qrdata = "980381266";
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Areas/Business/Ashx/GenerateQRCode.ashx",
        data:
        {
            qrdata: qrdata
        },
        success: function (filename) {
            $(window.parent.document).find("#span_body_qrcode").each(function() {
                $(this).css("background-image", "url(" + getRootPath() + "/Areas/Business/QRCode/" + filename + ")");
                $(this).css("background-repeat", "no-repeat");
                $(this).css("background-size", "100%");
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//解绑QQ
function QQJB() {
    if (confirm("确定要解绑吗?")) {
        $.ajax({
            type: "POST",
            url: getRootPath() + "/GRZL/UpdateQQ",
            dataType: "json",
            data:
            {
                YHID: getUrlParam("YHID"),
                QQ: ""
            },
            success: function(xml) {
                if (xml.Result === 1) {
                    alert("QQ解绑成功");
                    window.location.reload();
                }
            },
            error: function(XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

            }
        });
    }
}
//解绑微博
function WBJB() {
    if (confirm("确定要解绑吗?")) {
        $.ajax({
            type: "POST",
            url: getRootPath() + "/GRZL/UpdateWB",
            dataType: "json",
            data:
            {
                YHID: getUrlParam("YHID"),
                WB: ""
            },
            success: function (xml) {
                if (xml.Result === 1) {
                    alert("微博解绑成功");
                    window.location.reload();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

            }
        });
    }
}
//微信解绑
function WXJB() {
    if (confirm("确定要解绑吗?")) {
        $.ajax({
            type: "POST",
            url: getRootPath() + "/GRZL/UpdateWX",
            dataType: "json",
            data:
            {
                YHID: getUrlParam("YHID"),
                WB: ""
            },
            success: function (xml) {
                if (xml.Result === 1) {
                    alert("微博解绑成功");
                    window.location.reload();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

            }
        });
    }
}