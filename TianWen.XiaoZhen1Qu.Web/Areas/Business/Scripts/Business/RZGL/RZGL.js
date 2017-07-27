$(document).ready(function() {
    $("#spanGRLRZ").css("color", "#5bc0de");
    $("#spanGRLRZ").css("font-weight", "700");
    $("#emGRLRZ").css("background-color", "#5bc0de");
    $(".divstep").bind("click", HeadActive);
});

function HeadActive() {
    //Load(this.id.substr(3, this.id.length - this.id.indexOf('div')));
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
}