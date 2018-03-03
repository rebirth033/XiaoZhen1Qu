$(document).ready(function () {
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $("#spanWCFB").css("color", "#bc6ba6");
    $("#emWCFB").css("background", "#bc6ba6");
    $("#btnGLXX").bind("click", ToHTGL);
    $("#btnZDXX").bind("click", ShowZDTG);
    $("#btnCKXX").bind("click", OpenXXXX);
    $("#btnZFXX").bind("click", FBXX);
    $("#input_main_info_ljzf").bind("click", LJZD);
    $(".div_radio").bind("click", RadioSelect);
    $(".img_radio").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $(".div_main_info_zffs_dsfptzf").bind("click", { zffs: "dsfptzf" }, SelectWYZF_YH);
    $("#span_main_info_body_bottom_xy").bind("click", function() { window.open(getRootPath() + "/BZZX/BZZX_SY_KSDH_ZHDJYXY"); });
    document.title = "信息小镇_发布信息_发布成功";
    
    LoadDefault();
    GenerateQRCode();
});
//加载默认
function LoadDefault() {
    $("#img_radio_1").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_purple.png");
    $("#span_row_right_zj").html("15元");
    $("#div_main_info_zffs_zfbzf").css("border", "1px solid #bc6ba6");
    $("#img_radio_zfbzf").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_purple.png");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/SY/LoadJCXXByJCXXID",
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
    window.location.href = getRootPath() + "/HTGL/HTGL";
}
//预览信息
function OpenXXXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/SY/LoadXXLBByLBID",
        data:
        {
            LBID: getUrlParam("LBID")
        },
        success: function (xml) {
            window.open(getRootPath() + "/" + xml.list[0].FBYM.split('_')[0] + "XX" + "/" + xml.list[0].FBYM.split('_')[0] + "XX_" + xml.list[0].FBYM.split('_')[1] + "?ID=" + getUrlParam("ID") + "&LBID=" + getUrlParam("LBID"));
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//发布信息
function FBXX() {
    window.open(getRootPath() + "/LBXZ/LBXZ");
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
//选择支付方式
function SelectWYZF_YH(obj) {
    $("#div_main_info_body_" + obj.data.zffs).find(".img_radio").each(function () {
        $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    });
    $("#div_main_info_body_" + obj.data.zffs).find(".img_select").each(function () {
        $(this).css("background-image", "");
    });
    $("#div_main_info_body_" + obj.data.zffs).find(".div_main_info_zffs_" + obj.data.zffs).each(function () {
        $(this).css("border", "1px solid #cccccc");
    });
    $(this).find(".img_radio").each(function () {
        $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_purple.png");
    });
    $(this).find(".img_select").each(function () {
        $(this).css("background-image", 'url(' + getRootPath() + '/Areas/Business/Css/images/WDZJ/wdxj_cz_zffs_select.png)');
    });
    $(this).css("border", "1px solid #bc6ba6");
}
//显示置顶推广
function ShowZDTG() {
    $(".div_zdtg").css("display", "block");
}
//立即置顶
function LJZD() {
    if ($("#input_main_info_body_bottom")[0].checked === false) {
        window.wxc.xcConfirm("还未阅读并同意协议", window.wxc.xcConfirm.typeEnum.info);
    }
}