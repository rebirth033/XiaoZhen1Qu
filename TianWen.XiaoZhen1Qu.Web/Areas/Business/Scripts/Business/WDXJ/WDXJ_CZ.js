$(document).ready(function () {
    $("#spanWXZF").css("color", "#31b0d5");
    $("#spanWXZF").css("font-weight", "700");
    $("#emWXZF").css("background-color", "#31b0d5");
    $("#emWXZF").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    $("#span_main_info_body_bottom_xy").bind("click", ShowFWXY);
    $("#input_main_info_ljzf").bind("click", LJZF);
    LoadDefault("divWXZF");
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

function LoadDefault(id) {
    LoadDivInfo(id);
}

function LoadDivInfo(id) {
    if (id === "divWXZF") {
        $("#img_radio_wxzf").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#div_main_info_body_wxfz").css("display", "block");
        $("#div_main_info_body_zfbfz").css("display", "none");
    }
    if (id === "divZFBZF") {
        $("#img_radio_zfbzf").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#div_main_info_body_wxfz").css("display", "none");
        $("#div_main_info_body_zfbfz").css("display", "block");
    }
    //else {
    //    $("#div_SZMX").css("display", "none");
    //    $("#div_DJJDJL").css("display", "block");
    //    LoadDJJDJL();
    //}
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