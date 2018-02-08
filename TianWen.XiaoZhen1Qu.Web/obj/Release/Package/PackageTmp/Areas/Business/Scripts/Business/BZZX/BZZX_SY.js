$(document).ready(function () {
    $(".div_left_box_info").bind("mouseover", ShowRemark);
    $(".div_left_box_info").bind("mouseleave", HideRemark);

    //用户注册与登录
    $("#span_left_box_bottom_right_rhzczh").bind("click", OpenYHZCYDL);
    $("#span_left_box_bottom_right_rhdlzh").bind("click", OpenYHZCYDL);
    $("#span_left_box_bottom_right_rhxgyhmhmm").bind("click", OpenYHZCYDL);
    $("#span_left_box_bottom_right_rhghbddsjh").bind("click", OpenYHZCYDL);
    $("#span_left_box_bottom_right_zhdshbdlzmb").bind("click", OpenYHZCYDL);

    //信息发布与管理
    $("#span_left_box_bottom_right_rhfbxx").bind("click", OpenXSSYZN);
    $("#span_left_box_bottom_right_rhcxyfbxx").bind("click", OpenXSSYZN);
    $("#span_left_box_bottom_right_rhxghscyfbxxx").bind("click", OpenXSSYZN);
    $("#span_left_box_bottom_right_fbxxstscfzmb").bind("click", OpenXSSYZN);
    $("#span_left_box_bottom_right_xxmfsxcs").bind("click", OpenXSSYZN);
    $("#span_left_box_bottom_right_xxshgf").bind("click", OpenXSSYZN);

    //认证相关问题
    $("#span_left_box_bottom_right_rhjxrz").bind("click", OpenRZSM);
    $("#span_left_box_bottom_right_yyzzrzxz").bind("click", OpenRZSM);
    $("#span_left_box_bottom_right_yyzzrzynxhc").bind("click", OpenRZSM);
    $("#span_left_box_bottom_right_grsfrzxz").bind("click", OpenRZSM);
    $("#span_left_box_bottom_right_grsfrzynxhc").bind("click", OpenRZSM);
    $("#span_left_box_bottom_right_gdrzwt").bind("click", OpenRZSM);

    //账户等级与信用
    $("#span_left_box_bottom_right_smsxy").bind("click", OpenZHDJYXY);
    $("#span_left_box_bottom_right_xysrhxsd").bind("click", OpenZHDJYXY);
    $("#span_left_box_bottom_right_rhzjxy").bind("click", OpenZHDJYXY);
    $("#span_left_box_bottom_right_xywsmhjs").bind("click", OpenZHDJYXY);

    //防骗提示与案例
    $("#span_left_box_bottom_right_qzfpts").bind("click", OpenWLFPCS);
    $("#span_left_box_bottom_right_zffpts").bind("click", OpenWLFPCS);
    $("#span_left_box_bottom_right_pcfpts").bind("click", OpenWLFPCS);
    $("#span_left_box_bottom_right_cwfpts").bind("click", OpenWLFPCS);
    $("#span_left_box_bottom_right_esjyfpts").bind("click", OpenWLFPCS);
    $("#span_left_box_bottom_right_kssbxjxx").bind("click", OpenWLFPCS);
    $("#span_left_box_bottom_right_gdfpts").bind("click", OpenWLFPCS);

    //如何举报与申诉
    $("#span_left_box_bottom_right_xxxzjbslyczbf").bind("click", OpenYYPJKD);
    $("#span_left_box_bottom_right_rhjbxx").bind("click", OpenYYPJKD);
    $("#span_left_box_bottom_right_xxbscrhss").bind("click", OpenYYPJKD);
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

function OpenYHZCYDL() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_YHZCYDL");
}

function OpenXSSYZN() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_XSSYZN");
}

function OpenRZSM() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_RZSM");
}

function OpenZHDJYXY() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_ZHDJYXY");
}

function OpenWLFPCS() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_WLFPCS");
}

function OpenYYPJKD() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_KSDH_JBYSS");
}