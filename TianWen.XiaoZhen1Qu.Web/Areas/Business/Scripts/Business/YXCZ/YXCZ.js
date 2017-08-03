$(document).ready(function () {
    $("#spanDKCZ").css("color", "#5bc0de");
    $("#spanDKCZ").css("font-weight", "700");
    $("#emDKCZ").css("background-color", "#5bc0de");
    $("#emDKCZ").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
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
        $(this).css("color", "#5bc0de");
        $(this).css("font-weight", "700");
    });
    $(this).find("em").each(function () {
        $(this).css("height", "2px");
        $(this).css("background-color", "#5bc0de");
    });
    Load(this.id);
}