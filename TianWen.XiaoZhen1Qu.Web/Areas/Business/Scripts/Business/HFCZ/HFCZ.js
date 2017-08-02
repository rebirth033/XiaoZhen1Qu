$(document).ready(function () {
    $("#spanHFCZ").css("color", "#5bc0de");
    $("#spanHFCZ").css("font-weight", "700");
    $("#emHFCZ").css("background-color", "#5bc0de");
    $("#emHFCZ").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    $(".span_content_info_HF").bind("click", SelectHF);
    $(".span_content_info_LL").bind("click", SelectLL);
    $("#inputHFLJCZ").bind("click", HFCZ);
    $("#inputLLLJCZ").bind("click", LLCZ);
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
        $(this).css("color", "#5bc0de");
        $(this).css("font-weight", "700");
    });
    $(this).find("em").each(function () {
        $(this).css("height", "2px");
        $(this).css("background-color", "#5bc0de");
    });
    Load(this.id);
}

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

function SelectHF() {
    $(".span_content_info_HF").each(function () {
        $(this).css("background-color", "#fff");
        $(this).css("color", "#333");
    });
    $(this).css("background-color", "#5bc0de");
    $(this).css("color", "#fff");
    $("#inputGXZF").val(parseFloat(RTrim($(this).html(), "元")) * 0.999 + "元");
}

function SelectLL() {
    $(".span_content_info_LL").each(function () {
        $(this).css("background-color", "#fff");
        $(this).css("color", "#333");
    });
    $(this).css("background-color", "#5bc0de");
    $(this).css("color", "#fff");
    if ($(this).html() === "10M")
        $("#inputLLJG").val("2.85元");
    if ($(this).html() === "10M")
        $("#inputLLJG").val("2.85元");
    if ($(this).html() === "30M")
        $("#inputLLJG").val("4.75元");
    if ($(this).html() === "70M")
        $("#inputLLJG").val("7.5元");
    if ($(this).html() === "100M")
        $("#inputLLJG").val("10元");
    if ($(this).html() === "300M")
        $("#inputLLJG").val("15元");
    if ($(this).html() === "500M")
        $("#inputLLJG").val("28.5元");
    if ($(this).html() === "1G")
        $("#inputLLJG").val("48元");
    if ($(this).html() === "2G")
        $("#inputLLJG").val("94元");

}

//手机检查
function HFSJCheck() {
    if (!ValidateCellPhone($("#inputHFSJHM").val())) {
        $("#inputHFSJHM").css("border-color", "#F2272D");
        $("#span_conent_info_hfsj").css("color", "#F2272D");
        $("#span_conent_info_hfsj").html("手机号码格式不正确");
        return false;
    }
    else if ($("#inputHFSJHM").val().length === 0) {
        $("#inputHFSJHM").css("border-color", "#F2272D");
        $("#span_conent_info_hfsj").css("color", "#F2272D");
        $("#span_conent_info_hfsj").html("请输入手机号");
        return false;
    }
    else {
        $("#inputHFSJHM").css("border-color", "#999");
        $("#span_conent_info_hfsj").html('');
        return true;
    }
}

//手机检查
function LLSJCheck() {
    if (!ValidateCellPhone($("#inputLLSJHM").val())) {
        $("#inputLLSJHM").css("border-color", "#F2272D");
        $("#span_content_info_llsj").css("color", "#F2272D");
        $("#span_content_info_llsj").html("手机号码格式不正确");
        return false;
    }
    else if ($("#inputLLSJHM").val().length === 0) {
        $("#inputLLSJHM").css("border-color", "#F2272D");
        $("#span_content_info_llsj").css("color", "#F2272D");
        $("#span_content_info_llsj").html("请输入手机号");
        return false;
    }
    else {
        $("#inputLLSJHM").css("border-color", "#999");
        $("#span_content_info_llsj").html('');
        return true;
    }
    var isChinaMobile = /^134[0-8]\\d{7}$|^(?:13[5-9]|147|15[0-27-9]|178|18[2-478])\\d{8}$/; //移动方面最新答复
    var isChinaUnion = /^(?:13[0-2]|145|15[56]|176|18[56])\\d{8}$/; //向联通微博确认并未回复
    var isChinaTelcom = /^(?:133|153|177|18[019])\\d{8}$/; //1349号段 电信方面没给出答复，视作不存在
    var isOtherTelphone = /^170([059])\\d{7}$/;//其他运营商
}

function HFCZ() {
    if (!HFSJCheck()) return;
}

function LLCZ() {
    if (!LLSJCheck()) return;
}