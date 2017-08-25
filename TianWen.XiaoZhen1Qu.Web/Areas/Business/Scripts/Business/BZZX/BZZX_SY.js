$(document).ready(function () {
    $(".div_left_box_info").bind("mouseover", ShowRemark);
    $(".div_left_box_info").bind("mouseleave", HideRemark);
    $("#div_left_box_info_zdjs").bind("click", OpenZDJS);
    $("#div_left_box_info_zhmm").bind("click", OpenZHMM);
    $("#div_left_box_info_zhyecz").bind("click", OpenZHYECZ);
    $("#div_left_box_info_dhbmycx").bind("click", OpenDHMYCX);
    $("#div_left_box_info_sbddxyzm").bind("click", OpenYYYZM);
    $("#div_left_box_info_rzsm").bind("click", OpenRZSM);
    $("#div_left_box_info_xxwffb").bind("click", OpenXXWFFB);
    $("#div_left_box_info_xxbsc").bind("click", OpenXXBSC);
    $("#div_left_box_info_fbgzltz").bind("click", OpenFBGZLTZ);
    $("#div_left_box_info_ftbg").bind("click", OpenFTBG);
    $("#span_left_box_bottom_right_cwczyh").bind("click", OpenCWZCYH);
});

function ShowRemark() {
    $(this).find(".span_left_box_info_remark").each(function () {
        $(this).css("display", "block");
    });
}

function HideRemark() {
    $(this).find(".span_left_box_info_remark").each(function () {
        $(this).css("display", "none");
    });
}

function OpenZDJS() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_ZDJS?YHID=" + getUrlParam("YHID"));
}

function OpenZHMM() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_ZHMM?YHID=" + getUrlParam("YHID"));
}

function OpenZHYECZ() {
    window.open(getRootPath() + "/Business/YHGL/YHGL?YHID=" + getUrlParam("YHID") + "&Show=WDZJ");
}

function OpenDHMYCX() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_DHMYCX?YHID=" + getUrlParam("YHID"));
}

function OpenYYYZM() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_YYYZM?YHID=" + getUrlParam("YHID"));
}

function OpenRZSM() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_RZSM?YHID=" + getUrlParam("YHID"));
}

function OpenXXWFFB() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_XXWFFB?YHID=" + getUrlParam("YHID"));
}

function OpenXXBSC() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_XXBSC?YHID=" + getUrlParam("YHID"));
}

function OpenFBGZLTZ() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_FBGZLTZ?YHID=" + getUrlParam("YHID"));
}

function OpenFTBG() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_FTBG?YHID=" + getUrlParam("YHID"));
}

function OpenCWZCYH() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_XSSYZN?YHID=" + getUrlParam("YHID"));
}
