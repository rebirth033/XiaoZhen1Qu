$(document).ready(function () {
    $("#spanSYWXTX").css("color", "#5bc0de");
    $("#spanSYWXTX").css("font-weight", "700");
    $("#emSYWXTX").css("background-color", "#5bc0de");
    $("#button_main_photo_bcwxtx").css("display", "block");
    $(".divstep").bind("click", HeadActive);
    $("#divBDSC").bind("click", ShowBDSC);
    //LoadDefault("divZJFBXX");
});

function HeadActive() {
    $(".divstep").each(function () {
        $(this).find("span").each(function () {
            $(this).css("color", "#cccccc");
            $(this).css("font-weight", "normal");
        });
        $(this).find("em").each(function () {
            $(this).css("background-color", "#cccccc");
        });
    });
    $(this).find("span").each(function () {
        $(this).css("color", "#5bc0de");
        $(this).css("font-weight", "700");
    });
    $(this).find("em").each(function () {
        $(this).css("background-color", "#5bc0de");
    });
    //LoadDefault($(this)[0].id);
}

function ShowBDSC() {

}