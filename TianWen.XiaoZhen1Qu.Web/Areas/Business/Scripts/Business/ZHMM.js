$(document).ready(function () {
    $("#btnFirst").bind("click", YZZH);
    $("#btnSecond").bind("click", CZMM);
    $("#spanQRZH").css("color", "#5bc0de");
    $("#emQRZH").css("background", "#5bc0de");
});

function YZZH() {
    $("#spanQRZH").css("color", "#cccccc");
    $("#emQRZH").css("background", "#cccccc");
    $("#spanYZZH").css("color", "#5bc0de");
    $("#emYZZH").css("background", "#5bc0de");
    $("#divFirst").css("display", "none");
    $("#divSecond").css("display", "block");
}

function CZMM() {
    $("#spanYZZH").css("color", "#cccccc");
    $("#emYZZH").css("background", "#cccccc");
    $("#spanCZMM").css("color", "#5bc0de");
    $("#emCZMM").css("background", "#5bc0de");
    $("#divSecond").css("display", "none");
    $("#divThird").css("display", "block");
}