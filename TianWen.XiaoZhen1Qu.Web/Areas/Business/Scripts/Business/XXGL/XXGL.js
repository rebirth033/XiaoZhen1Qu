$(document).ready(function () {
    $("#spanXTTZ").css("color", "#5bc0de");
    $("#spanXTTZ").css("font-weight", "700");
    $("#emXTTZ").css("background-color", "#5bc0de");
    $("#emXTTZ").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    //LoadDefault("divZJFBXX");
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
    //LoadDefault($(this)[0].id);
}