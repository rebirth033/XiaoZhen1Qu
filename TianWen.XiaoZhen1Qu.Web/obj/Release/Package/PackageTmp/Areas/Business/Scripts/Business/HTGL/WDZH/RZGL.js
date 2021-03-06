﻿$(document).ready(function () {
    $("#spanGRLRZ").css("color", "#bc6ba6");
    $("#spanGRLRZ").css("font-weight", "700");
    $("#emGRLRZ").css("background-color", "#bc6ba6");
    $("#emGRLRZ").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
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
        $(this).css("color", "#bc6ba6");
        $(this).css("font-weight", "700");
    });
    $(this).find("em").each(function () {
        $(this).css("height", "2px");
        $(this).css("background-color", "#bc6ba6");
    });
    Load(this.id);
}

function Load(id) {
    if (id === "divGRLRZ") {
        $("#div_GRLRZ").css("display", "block");
        $("#div_QYLRZ").css("display", "none");
        $("#div_QTRZ").css("display", "none");
    }
    if (id === "divQYLRZ") {
        $("#div_GRLRZ").css("display", "none");
        $("#div_QYLRZ").css("display", "block");
        $("#div_QTRZ").css("display", "none");
    }
    if (id === "divQTRZ") {
        $("#div_GRLRZ").css("display", "none");
        $("#div_QYLRZ").css("display", "none");
        $("#div_QTRZ").css("display", "block");
    }
}
