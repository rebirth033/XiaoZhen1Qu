$(document).ready(function () {
    $(".divstep").bind("click", HeadActive);
    LoadDefault();
});

function LoadDefault() {
    $("#spanZXXX").css("color", "#5bc0de");
    $("#emZXXX").css("background-color", "#5bc0de");
}

function HeadActive() {
    $(".divstep").each(function() {
        $(this).find("span").each(function () {
            $(this).css("color", "#cccccc");
        });
        $(this).find("em").each(function () {
            $(this).css("background-color", "#cccccc");
        });
    });
    $(this).find("span").each(function () {
        $(this).css("color", "#5bc0de");
    });
    $(this).find("em").each(function () {
        $(this).css("background-color", "#5bc0de");
    });
}
