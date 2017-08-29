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

    $("#span_left_box_bottom_right_cwczyh").bind("click", OpenXSSYZN);
    $("#span_left_box_bottom_right_rhfbxx").bind("click", OpenXSSYZN);
    $("#span_left_box_bottom_right_rhglxx").bind("click", OpenXSSYZN);
    $("#span_left_box_bottom_right_rhczxx").bind("click", OpenXSSYZN);
    $("#span_left_box_bottom_right_xxshgf").bind("click", OpenXSSYZN);
    $("#span_left_box_bottom_right_mjrm").bind("click", OpenXSSYZN);

    $("#span_left_box_bottom_right_yhmxg").bind("click", OpenYHZCYDL);
    $("#span_left_box_bottom_right_wfdl").bind("click", OpenYHZCYDL);

    $("#span_left_box_bottom_right_xxzlbbxs").bind("click", OpenXXFBYSC);
    $("#span_left_box_bottom_right_tsxxxshcf").bind("click", OpenXXFBYSC);
    $("#span_left_box_bottom_right_xxwffb").bind("click", OpenXXWFFB);
    $("#span_left_box_bottom_right_xxbsc").bind("click", OpenXXBSC);
    $("#span_left_box_bottom_right_rhxgscxx").bind("click", OpenXXFBYSC);

    $("#span_left_box_bottom_right_rzzx").bind("click", OpenRZSM);
    $("#span_left_box_bottom_right_rhrz").bind("click", OpenRZSM);
    $("#span_left_box_bottom_right_ghrz").bind("click", OpenRZSM);
    $("#span_left_box_bottom_right_sbdrzm").bind("click", OpenRZSM);
    $("#span_left_box_bottom_right_sbdrzyj").bind("click", OpenRZSM);
    $("#span_left_box_bottom_right_gdrzwt").bind("click", OpenRZSM);

    $("#span_left_box_bottom_right_smsxy").bind("click", OpenZHDJYXY);
    $("#span_left_box_bottom_right_xydzjyjs").bind("click", OpenZHDJYXY);
    $("#span_left_box_bottom_right_djyftl").bind("click", OpenZHDJYXY);
    $("#span_left_box_bottom_right_tytxxgxcs").bind("click", OpenZHDJYXY);

    $("#span_left_box_bottom_right_pcfp").bind("click", OpenWLFPCS);
    $("#span_left_box_bottom_right_wlzpfp").bind("click", OpenWLFPCS);
    $("#span_left_box_bottom_right_cwfp").bind("click", OpenWLFPCS);
    $("#span_left_box_bottom_right_esjyfp").bind("click", OpenWLFPCS);
    $("#span_left_box_bottom_right_fcfp").bind("click", OpenWLFPCS);
    $("#span_left_box_bottom_right_hcpfp").bind("click", OpenWLFPCS);
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

function OpenXSSYZN() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_XSSYZN?YHID=" + getUrlParam("YHID"));
}

function OpenYHZCYDL() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_YHZCYDL?YHID=" + getUrlParam("YHID"));
}

function OpenXXFBYSC() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_XXFBYSC?YHID=" + getUrlParam("YHID"));
}

function OpenZHDJYXY() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_ZHDJYXY?YHID=" + getUrlParam("YHID"));
}

function OpenWLFPCS() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_WLFPCS?YHID=" + getUrlParam("YHID"));
}