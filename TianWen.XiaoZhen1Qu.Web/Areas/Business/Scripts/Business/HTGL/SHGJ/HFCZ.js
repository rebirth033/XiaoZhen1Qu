$(document).ready(function () {
    $("#spanHFCZ").css("color", "#bc6ba6");
    $("#spanHFCZ").css("font-weight", "700");
    $("#emHFCZ").css("background-color", "#bc6ba6");
    $("#emHFCZ").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    $(".span_content_info_HF").bind("click", SelectHF);
    $(".span_content_info_LL").bind("click", SelectLL);
    $("#inputHFLJCZ").bind("click", HFCZ);
    $("#inputLLLJCZ").bind("click", LLCZ);
    $("#inputHFSJHM").bind("blur", HFSJCheck);
    $("#inputHFSJHM").bind("keyup", HFSJKeyUp);
    $("#inputLLSJHM").bind("blur", LLSJCheck);
    $("#inputLLSJHM").bind("keyup", LLSJKeyUp);
    $("#span_content_info_left_zffs_zfb").bind("click", ToZFFS);
    $("#span_content_info_left_zffs_wx").bind("click", ToZFFS);
});
//标题切换
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
        $(this).css("color", "#bc6ba6");
        $(this).css("font-weight", "700");
    });
    $(this).find("em").each(function () {
        $(this).css("height", "2px");
        $(this).css("background-color", "#bc6ba6");
    });
    Load(this.id);
}
//话费、流量切换
function Load(id) {
    if (id === "divHFCZ") {
        $("#div_HFCZ").css("display", "block");
        $("#div_LLCZ").css("display", "none");
    }
    if (id === "divLLCZ") {
        $("#div_HFCZ").css("display", "none");
        $("#div_LLCZ").css("display", "block");
    }
}
//选择话费
function SelectHF() {
    $(".span_content_info_HF").each(function () {
        $(this).css("background-color", "#fff");
        $(this).css("color", "#333");
    });
    $(this).css("background-color", "#bc6ba6");
    $(this).css("color", "#fff");
    $("#spanGXZF").html(parseFloat(RTrim($(this).html(), "元")) * 0.999 + "元");
}
//选择流量
function SelectLL() {
    $(".span_content_info_LL").each(function () {
        $(this).css("background-color", "#fff");
        $(this).css("color", "#333");
    });
    $(this).css("background-color", "#bc6ba6");
    $(this).css("color", "#fff");
    if ($(this).html() === "10M")
        $("#spanLLJG").html("2.85元");
    if ($(this).html() === "10M")
        $("#spanLLJG").html("2.85元");
    if ($(this).html() === "30M")
        $("#spanLLJG").html("4.75元");
    if ($(this).html() === "70M")
        $("#spanLLJG").vhtmlal("7.5元");
    if ($(this).html() === "100M")
        $("#spanLLJG").html("10元");
    if ($(this).html() === "300M")
        $("#spanLLJG").html("15元");
    if ($(this).html() === "500M")
        $("#spanLLJG").html("28.5元");
    if ($(this).html() === "1G")
        $("#spanLLJG").html("48元");
    if ($(this).html() === "2G")
        $("#spanLLJG").html("94元");
}
//话费手机号码检查
function HFSJCheck() {
    if (!ValidateCellPhone($("#inputHFSJHM").val().replace(/\s/g, ""))) {
        $("#inputHFSJHM").css("border-color", "#F2272D");
        $("#span_content_info_hfsj").css("color", "#F2272D");
        $("#span_content_info_hfsj").html("手机号码格式不正确");
        return false;
    }
    else if ($("#inputHFSJHM").val().replace(/\s/g, "").length === 0) {
        $("#inputHFSJHM").css("border-color", "#F2272D");
        $("#span_content_info_hfsj").css("color", "#F2272D");
        $("#span_content_info_hfsj").html("请输入手机号");
        return false;
    }
    else {
        $("#inputHFSJHM").css("border-color", "#ccc");
        $("#span_content_info_hfsj").html("");
        HFSearchMobilePhoneGuiSuArea($("#inputHFSJHM").val().replace(/\s/g, ""));
        return true;
    }
}
//话费手机充值金额检查
function HFCheck() {
    var hasSelect = false;
    $(".span_content_info_HF").each(function () {
        if ($(this).css("color") !== "rgb(51, 51, 51)")
            hasSelect = true;
    });
    if (hasSelect)
        return true;
    else {
        alert("还未选择充值金额");
        return false;
    }
}
//流量手机检查
function LLSJCheck() {
    if (!ValidateCellPhone($("#inputLLSJHM").val().replace(/\s/g, ""))) {
        $("#inputLLSJHM").css("border-color", "#F2272D");
        $("#span_content_info_llsj").css("color", "#F2272D");
        $("#span_content_info_llsj").html("手机号码格式不正确");
        return false;
    }
    else if ($("#inputLLSJHM").val().replace(/\s/g, "").length === 0) {
        $("#inputLLSJHM").css("border-color", "#F2272D");
        $("#span_content_info_llsj").css("color", "#F2272D");
        $("#span_content_info_llsj").html("请输入手机号");
        return false;
    }
    else {
        $("#inputLLSJHM").css("border-color", "#ccc");
        $("#span_content_info_llsj").html("");
        LLSearchMobilePhoneGuiSuArea($("#inputLLSJHM").val().replace(/\s/g, ""));
        return true;
    }
}
//流量手机充值流量检查
function LLCheck() {
    var hasSelect = false;
    $(".span_content_info_LL").each(function () {
        if ($(this).css("color") !== "rgb(51, 51, 51)")
            hasSelect = true;
    });
    if (hasSelect)
        return true;
    else {
        alert("还未选择充值流量包");
        return false;
    }
}
//话费充值验证
function HFValidate() {
    if (!HFSJCheck()) return false;
    if (!HFCheck()) return false;
    return true;
}
//流量充值验证
function LLValidate() {
    if (!LLSJCheck()) return false;
    if (!LLCheck()) return false;
    return true;
}
//话费充值
function HFCZ() {
    if (!HFValidate()) return;
    ToZFFS($("#inputHFSJHM").val(), "HF", "30元");
}
//流量充值
function LLCZ() {
    if (!LLValidate()) return;
    ToZFFS($("#inputLLSJHM").val(), "LL", "10M");
}
//话费查询手机归属地 
function HFSearchMobilePhoneGuiSuArea(mobileNo) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/HFCZ/SearchMobilePhoneGuiSuArea",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID"),
            MobileNo: mobileNo
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#span_content_info_hfsj").html("<span style='color:#bc6ba6'>"+xml.Values[5] + "&nbsp;&nbsp;" + xml.Values[1] + "&nbsp;&nbsp;" + xml.Values[2] + "</span>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//流量查询手机归属地 
function LLSearchMobilePhoneGuiSuArea(mobileNo) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/HFCZ/SearchMobilePhoneGuiSuArea",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID"),
            MobileNo: mobileNo
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#span_content_info_llsj").html("<span style='color:#bc6ba6'>" + xml.Values[5] + "&nbsp;&nbsp;" + xml.Values[1] + "&nbsp;&nbsp;" + xml.Values[2] + "</span>");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//转到支付方式页面
function ToZFFS(mobileNo, type, standard) {
    window.location.href = getRootPath() + "/HFCZ/ZFFS?MobileNo=" + mobileNo + "&Type=" + type + "&Standard=" + standard;
}
//键入话费手机号触发
function HFSJKeyUp() {
    if (event.keyCode !== 8 && ($("#inputHFSJHM").val().replace(/\s/g, "").length === 3 || $("#inputHFSJHM").val().replace(/\s/g, "").length === 7))
        $("#inputHFSJHM").val($("#inputHFSJHM").val() + " ");
    if ($("#inputHFSJHM").val().replace(/\s/g, "").length === 11)
        HFSJCheck();
}
//键入流量手机号触发
function LLSJKeyUp() {
    if (event.keyCode !== 8 && ($("#inputLLSJHM").val().replace(/\s/g, "").length === 3 || $("#inputLLSJHM").val().replace(/\s/g, "").length === 7))
        $("#inputLLSJHM").val($("#inputLLSJHM").val() + " ");
    if ($("#inputLLSJHM").val().replace(/\s/g, "").length === 11)
        LLSJCheck();
}