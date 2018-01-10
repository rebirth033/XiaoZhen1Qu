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

    $("#span_left_box_bottom_right_yypjbuy").bind("click", OpenYYPJKD);
    $("#span_left_box_bottom_right_yypjsell").bind("click", OpenYYPJKD);
    $("#span_left_box_bottom_right_pjss").bind("click", OpenYYPJKD);
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
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_ZDJS");
}

function OpenZHMM() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_ZHMM");
}

function OpenZHYECZ() {
    window.open(getRootPath() + "/Business/HTGL/HTGL?Show=WDZJ");
}

function OpenDHMYCX() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_DHMYCX");
}

function OpenYYYZM() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_YYYZM");
}

function OpenRZSM() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_RZSM");
}

function OpenXXWFFB() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_XXWFFB");
}

function OpenXXBSC() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_XXBSC");
}

function OpenFBGZLTZ() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_FBGZLTZ");
}

function OpenFTBG() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_FTBG");
}

function OpenXSSYZN() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_XSSYZN");
}

function OpenYHZCYDL() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_YHZCYDL");
}

function OpenXXFBYSC() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_XXFBYSC");
}

function OpenZHDJYXY() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_ZHDJYXY");
}

function OpenWLFPCS() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_WLFPCS");
}

function OpenYYPJKD() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_YYPJKD");
} 