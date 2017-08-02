$(document).ready(function () {
    $("#spanHFCZ").css("color", "#5bc0de");
    $("#spanHFCZ").css("font-weight", "700");
    $("#emHFCZ").css("background-color", "#5bc0de");
    $("#emHFCZ").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    $(".span_content_info").bind("click", SelectHF);
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
    $(".span_content_info").each(function() {
        $(this).css("background-color", "#fff");
        $(this).css("color", "#333");
    });
    $(this).css("background-color", "#5bc0de");
    $(this).css("color", "#fff");
    $("#inputGXZF").val(parseFloat(RTrim($(this).html(), "元")) * 0.999 + "元");
}