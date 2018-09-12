$(document).ready(function () {
    $(".div_left_box_info").bind("mouseover", ShowRemark);
    $(".div_left_box_info").bind("mouseleave", HideRemark);

    //用户注册与登录
    $("#span_left_box_bottom_right_rhzczh").bind("click", function(){OpenYHZCYDL(1)});
    $("#span_left_box_bottom_right_rhdlzh").bind("click", function(){OpenYHZCYDL(2)});
    $("#span_left_box_bottom_right_rhxgyhmhmm").bind("click", function(){OpenYHZCYDL(3)});
    $("#span_left_box_bottom_right_rhghbddsjh").bind("click", function(){OpenYHZCYDL(4)});
    $("#span_left_box_bottom_right_zhdshbdlzmb").bind("click", function(){OpenYHZCYDL(5)});

    //信息发布与管理
    $("#span_left_box_bottom_right_rhfbxx").bind("click", function(){OpenXXFBYGL(1)});
    $("#span_left_box_bottom_right_rhcxyfbxx").bind("click", function(){OpenXXFBYGL(2)});
    $("#span_left_box_bottom_right_rhxghscyfbxxx").bind("click", function(){OpenXXFBYGL(3)});
    $("#span_left_box_bottom_right_fbxxstscfzmb").bind("click", function(){OpenXXFBYGL(4)});
    $("#span_left_box_bottom_right_xxmfsxcs").bind("click", function(){OpenXXFBYGL(5)});
    $("#span_left_box_bottom_right_xxshgf").bind("click", function(){OpenXXFBYGL(6)});

    //认证相关问题
    $("#span_left_box_bottom_right_rhjxrz").bind("click", function(){OpenRZXGWT(1)});
    $("#span_left_box_bottom_right_yyzzrzxz").bind("click", function(){OpenRZXGWT(2)});
    $("#span_left_box_bottom_right_yyzzrzynxhc").bind("click", function(){OpenRZXGWT(3)});
    $("#span_left_box_bottom_right_grsfrzxz").bind("click", function(){OpenRZXGWT(4)});
    $("#span_left_box_bottom_right_grsfrzynxhc").bind("click", function(){OpenRZXGWT(5)});
    $("#span_left_box_bottom_right_gdrzwt").bind("click", function(){OpenRZXGWT('')});

    //账户等级与信用
    $("#span_left_box_bottom_right_smsxy").bind("click", function(){OpenZHDJYXY(1)});
    $("#span_left_box_bottom_right_xysrhxsd").bind("click", function(){OpenZHDJYXY(2)});
    $("#span_left_box_bottom_right_rhzjxy").bind("click", function(){OpenZHDJYXY(3)});
    $("#span_left_box_bottom_right_xywsmhjs").bind("click", function(){OpenZHDJYXY(4)});
    $("#span_left_box_bottom_right_xjfwxy").bind("click", function(){OpenZHDJYXY(5)});

    //防骗提示与案例
    $("#span_left_box_bottom_right_qzfpts").bind("click", function(){OpenFPTSYAL(2)});
    $("#span_left_box_bottom_right_zffpts").bind("click", function(){OpenFPTSYAL(5)});
    $("#span_left_box_bottom_right_pcfpts").bind("click", function(){OpenFPTSYAL(1)});
    $("#span_left_box_bottom_right_cwfpts").bind("click", function(){OpenFPTSYAL(3)});
    $("#span_left_box_bottom_right_esjyfpts").bind("click", function(){OpenFPTSYAL(4)});
    $("#span_left_box_bottom_right_kssbxjxx").bind("click", function(){OpenFPTSYAL(6)});

    //如何举报与申诉
    $("#span_left_box_bottom_right_rhcxxxbh").bind("click", function(){OpenRHJBYSS(1)});
    $("#span_left_box_bottom_right_rhjbxx").bind("click", function(){OpenRHJBYSS(2)});
    $("#span_left_box_bottom_right_xxbscrhss").bind("click", function(){OpenRHJBYSS(3)});
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

function OpenYHZCYDL(id) {
    window.open(getRootPath() + "/BZZX/BZZX_SY_KSDH_YHZCYDL?id="+id);
}

function OpenXXFBYGL(id) {
    window.open(getRootPath() + "/BZZX/BZZX_SY_KSDH_XXFBYGL?id="+id);
}

function OpenRZXGWT(id) {
    if(id !== '')
        window.open(getRootPath() + "/BZZX/BZZX_SY_KSDH_RZXGWT?id="+id);
    else
        window.open(getRootPath() + "/BZZX/BZZX_SY_KSDH_RZXGWT");
}

function OpenZHDJYXY(id) {
    window.open(getRootPath() + "/BZZX/BZZX_SY_KSDH_ZHDJYXY?id="+id);
}

function OpenFPTSYAL(id) {
    window.open(getRootPath() + "/BZZX/BZZX_SY_KSDH_FPTSYAL?id="+id);
}

function OpenRHJBYSS(id) {
    window.open(getRootPath() + "/BZZX/BZZX_SY_KSDH_JBYSS?id="+id);
}