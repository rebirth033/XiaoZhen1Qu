$(document).ready(function () {
    $(".div_left_box_info").bind("mouseover", ShowRemark);
    $(".div_left_box_info").bind("mouseleave", HideRemark);
    $("#div_left_box_info_zdjs").bind("click", OpenZDJS);
    $("#div_left_box_info_zhmm").bind("click", OpenZHMM);
    $("#div_left_box_info_zhyecz").bind("click", OpenZHYECZ);
    $("#div_left_box_info_dhbmycx").bind("click", OpenDHMYCX);
    $("#div_left_box_info_sbddxyzm").bind("click", OpenYYYZM);
    $("#div_left_box_info_rzsm").bind("click", OpenRZSM);
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