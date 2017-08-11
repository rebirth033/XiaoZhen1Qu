$(document).ready(function () {
    $("#spanDSFPTZF").css("color", "#31b0d5");
    $("#spanDSFPTZF").css("font-weight", "700");
    $("#emDSFPTZF").css("background-color", "#31b0d5");
    $("#emDSFPTZF").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    $("#span_main_info_body_bottom_xy").bind("click", ShowFWXY);
    $("#input_main_info_ljzf").bind("click", LJZF);
    LoadAll();
});

function HeadActive() {
    $(".divstep").each(function () {
        $(this).find("span").each(function () {
            $(this).css("color", "#cccccc");
            $(this).css("font-weight", "normal");
        });
        $(this).find("em").each(function () {
            $(this).css("height", "1px");
            $(this).css("background-color", "#cccccc");
        });
    });
    $(this).find("span").each(function () {
        $(this).css("color", "#31b0d5");
        $(this).css("font-weight", "700");
    });
    $(this).find("em").each(function () {
        $(this).css("height", "2px");
        $(this).css("background-color", "#31b0d5");
    });
    LoadDivInfo(this.id);
}

function LoadAll() {
    LoadDSFPTZF();
    LoadWYZF();
    LoadKJZF();
    LoadYHHK();
    LoadDivInfo("divDSFPTZF");
}

function LoadDSFPTZF() {
    var html = "";
    html += '<div class="div_main_info_zffs_dsfptzf" id="div_main_info_zffs_wxzf">';
    html += '<img class="img_radio" id="img_radio_wxzf" />';
    html += '<img class="img_zffs" id="img_zffs_wxzf" src="' + getRootPath() + "/Areas/Business/Css/images/WDZJ/wdxj_cz_wxzf.png" + '" />';
    html += '<img class="img_select" id="img_select_wxzf" />';
    html += '</div>';
    html += '<div class="div_main_info_zffs_dsfptzf" id="div_main_info_zffs_zfbzf">';
    html += '<img class="img_radio" id="img_radio_zfbzf" />';
    html += '<img class="img_zffs" id="img_zffs_zfbzf" src="' + getRootPath() + "/Areas/Business/Css/images/WDZJ/wdxj_cz_zfbzf.png" + '" />';
    html += '<img class="img_select" id="img_select_zfbzf" />';
    html += '</div>';
    $("#div_main_info_body_dsfptzf").html(html);
    $(".div_main_info_zffs_dsfptzf").bind("click", { zffs: "dsfptzf" }, SelectWYZF_YH);
}

function LoadWYZF() {
    var yharray = new Array("gsyh", "zsyh", "nyyh", "zgyh", "jsyh", "pfyh:right", "jtyh", "msyh", "payh:bottom", "gfyh:bottom", "gdyh:bottom", "bjyh:bottom right", "zxyh:bottom", "xyyh:bottom right");
    var html = '<div class="div_main_info_tip">请选择支付的银行卡<span class="span_main_info_tip">（请确保您的银行卡已开通网银）</span></div>';
    for (var i = 0; i < yharray.length; i++) {
        var values = yharray[i].split(':');
        html += '<div class="div_main_info_zffs_wyzf ' + values[1] + '" id="div_main_info_zffs_wyzf_' + values[0] + '">';
        html += '<img class="img_radio" id="img_radio_wyzf_' + values[0] + '"/>';
        html += '<img class="img_zffs" id="img_zffs_wxzf_gsyh" src="' + getRootPath() + "/Areas/Business/Css/images/WDZJ/wdxj_cz_" + values[0] + ".png" + '"/>';
        html += '<img class="img_select" id="img_select_wyzf_' + values[0] + '"/>';
        html += '</div>';
    }
    $("#div_main_info_body_wyzf").html(html);
    $(".div_main_info_zffs_wyzf").bind("click", { zffs: "wyzf" }, SelectWYZF_YH);
}

function LoadKJZF() {
    var yharray = new Array("gsyh", "zsyh", "nyyh", "zgyh", "jsyh", "pfyh:right", "jtyh", "msyh", "payh:bottom", "gfyh:bottom", "gdyh:bottom", "bjyh:bottom right", "zxyh:bottom", "xyyh:bottom right");
    var html = '<div class="div_main_info_tip">借记卡快捷<span class="span_main_info_tip">（需根据银行预留手机号确认）</span></div>';
    for (var i = 0; i < yharray.length; i++) {
        var values = yharray[i].split(':');
        html += '<div class="div_main_info_zffs_kjzf ' + values[1] + '" id="div_main_info_zffs_jjkkjzf_' + values[0] + '">';
        html += '<img class="img_radio" id="img_radio_jjkkjzf_' + values[0] + '"/>';
        html += '<img class="img_zffs" id="img_zffs_jjkkjzf_' + values[0] + '" src="' + getRootPath() + "/Areas/Business/Css/images/WDZJ/wdxj_cz_" + values[0] + ".png" + '"/>';
        html += '<img class="img_select" id="img_select_jjkkjzf_' + values[0] + '"/>';
        html += '</div>';
    }
    html += '<div class="div_main_info_tip">信用卡快捷<span class="span_main_info_tip">（需根据银行预留手机号确认）</span></div>';
    for (var i = 0; i < yharray.length; i++) {
        var values = yharray[i].split(':');
        html += '<div class="div_main_info_zffs_kjzf ' + values[1] + '" id="div_main_info_zffs_xykkjzf_' + values[0] + '">';
        html += '<img class="img_radio" id="img_radio_xykkjzf_' + values[0] + '"/>';
        html += '<img class="img_zffs" id="img_zffs_xykkjzf_' + values[0] + '" src="' + getRootPath() + "/Areas/Business/Css/images/WDZJ/wdxj_cz_" + values[0] + ".png" + '"/>';
        html += '<img class="img_select" id="img_select_xykkjzf_' + values[0] + '"/>';
        html += '</div>';
    }
    $("#div_main_info_body_kjzf").html(html);
    $(".div_main_info_zffs_kjzf").bind("click", { zffs: "kjzf" }, SelectWYZF_YH);
}

function LoadYHHK() {

}

function LoadDivInfo(id) {
    if (id === "divDSFPTZF") {
        var isDSFPTZFFirstLoad = true;
        $("#div_main_info_body_dsfptzf").find(".img_radio").each(function () {
            if ($(this).attr("src") === getRootPath() + "/Areas/Business/Css/images/radio_blue.png" && this.id.indexOf("wxzf") === -1)
                isDSFPTZFFirstLoad = false;
        });
        if (isDSFPTZFFirstLoad)
            FirstLoad("dsfptzf");
        $("#div_bottom").css("display", "block");
        $("#div_main_info_body_dsfptzf").css("display", "block");
        $("#div_main_info_body_zfbzf").css("display", "none");
        $("#div_main_info_body_wyzf").css("display", "none");
        $("#div_main_info_body_kjzf").css("display", "none");
        $("#div_main_info_body_yhhk").css("display", "none");
    }
    if (id === "divWYZF") {
        var isWYZFFirstLoad = true;
        $("#div_main_info_body_wyzf").find(".img_radio").each(function () {
            if ($(this).attr("src") === getRootPath() + "/Areas/Business/Css/images/radio_blue.png" && this.id.indexOf("img_radio_wyzf_gsyh") === -1)
                isWYZFFirstLoad = false;
        });
        if (isWYZFFirstLoad)
            FirstLoad("wyzf");
        $("#div_bottom").css("display", "block");
        $("#div_main_info_body_dsfptzf").css("display", "none");
        $("#div_main_info_body_zfbzf").css("display", "none");
        $("#div_main_info_body_wyzf").css("display", "block");
        $("#div_main_info_body_kjzf").css("display", "none");
        $("#div_main_info_body_yhhk").css("display", "none");
    }
    if (id === "divKJZF") {
        var isKJZFFirstLoad = true;
        $("#div_main_info_body_kjzf").find(".img_radio").each(function () {
            if ($(this).attr("src") === getRootPath() + "/Areas/Business/Css/images/radio_blue.png" && this.id.indexOf("img_radio_jjkkjzf_gsyh") === -1)
                isKJZFFirstLoad = false;
        });
        if (isKJZFFirstLoad)
        FirstLoad("kjzf");
        $("#div_bottom").css("display", "block");
        $("#div_main_info_body_dsfptzf").css("display", "none");
        $("#div_main_info_body_zfbzf").css("display", "none");
        $("#div_main_info_body_wyzf").css("display", "none");
        $("#div_main_info_body_kjzf").css("display", "block");
        $("#div_main_info_body_yhhk").css("display", "none");
    }
    if (id === "divYHHK") {
        $("#div_bottom").css("display", "none");
        $("#div_main_info_body_dsfptzf").css("display", "none");
        $("#div_main_info_body_zfbzf").css("display", "none");
        $("#div_main_info_body_wyzf").css("display", "none");
        $("#div_main_info_body_kjzf").css("display", "none");
        $("#div_main_info_body_yhhk").css("display", "block");
    }
}

function ShowFWXY() {
    $(window.parent.document).find("#shadow").each(function () {
        $(this).css("width", window.parent.document.body.clientWidth);
        $(this).css("height", window.parent.document.body.clientHeight);
        $(this).css("display", "block");
    });
    $(window.parent.document).find("#XJFWXYWindow").each(function () {
        $(this).css("display", "block");
        $(this).css("left", window.screen.availWidth / 2 - 462.5);
        $(this).css("top", window.screen.availHeight / 2 - 332);
    });
}

function CheckFWXY() {
    if ($("#input_main_info_body_bottom").prop("checked") === true) {
        return true;
    }
    else {
        alert("请仔细阅读《信息小镇现金服务协议》，并点击同意按钮");
        return false;
    }
}

function CheckCZJE() {
    if (!ValidateCZJE($("#inputCZJE").val())) {
        $("#inputCZJE").css("border-color", "#F2272D");
        $("#span_content_info_czje").css("color", "#F2272D");
        $("#span_content_info_czje").html("充值金额输入格式不正确");
        return false;
    }
    else if ($("#inputCZJE").val().length === 0) {
        $("#inputCZJE").css("border-color", "#F2272D");
        $("#span_content_info_czje").css("color", "#F2272D");
        $("#span_content_info_czje").html("请输入充值金额");
        return false;
    }
    else {
        $("#inputCZJE").css("border-color", "#999");
        $("#span_content_info_czje").html('');
        return true;
    }
}

function LJZFValidate() {
    if (!CheckCZJE()) return false;
    if (!CheckFWXY()) return false;
    return true;
}

function LJZF() {
    if (!LJZFValidate()) return;
    alert("支付成功");
}

function SelectWYZF_YH(obj) {
    $("#div_main_info_body_" + obj.data.zffs).find(".img_radio").each(function () {
        $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    });
    $("#div_main_info_body_" + obj.data.zffs).find(".img_select").each(function () {
        $(this).attr("src", "");
    });
    $("#div_main_info_body_" + obj.data.zffs).find(".div_main_info_zffs_" + obj.data.zffs).each(function () {
        $(this).css("border", "1px solid #cccccc");
    });
    $(this).find(".img_radio").each(function () {
        $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    });
    $(this).find(".img_select").each(function () {
        $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/WDZJ/wdxj_cz_zffs_select.png");
    });
    $(this).css("border", "1px solid #ef6100");
}

function FirstLoad(zffs) {
    if (zffs === "dsfptzf") {
        $("#div_main_info_body_dsfptzf").find(".img_radio").each(function () {
            $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        });
        $("#img_radio_wxzf").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#img_select_wxzf").attr("src", getRootPath() + "/Areas/Business/Css/images/WDZJ/wdxj_cz_zffs_select.png");
        $("#div_main_info_zffs_wxzf").css("border", "1px solid #ef6100");
    }
    if (zffs === "wyzf") {
        $("#div_main_info_body_wyzf").find(".img_radio").each(function () {
            $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        });
        $("#img_radio_wyzf_gsyh").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#img_select_wyzf_gsyh").attr("src", getRootPath() + "/Areas/Business/Css/images/WDZJ/wdxj_cz_zffs_select.png");
        $("#div_main_info_zffs_wyzf_gsyh").css("border", "1px solid #ef6100");
    }
    if (zffs === "kjzf") {
        $("#div_main_info_body_kjzf").find(".img_radio").each(function () {
            $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        });
        $("#img_radio_jjkkjzf_gsyh").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#img_select_jjkkjzf_gsyh").attr("src", getRootPath() + "/Areas/Business/Css/images/WDZJ/wdxj_cz_zffs_select.png");
        $("#div_main_info_zffs_jjkkjzf_gsyh").css("border", "1px solid #ef6100");
    }
}