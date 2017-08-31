$(document).ready(function () {
    $(".span_wtlx_inner_right").bind("click", SelectWTLX);
});

function SelectWTLX() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).css("background-color", "#eBeBeB").css("font-weight", "normal").css("color", "#000");
    });
    $(this).css("background-color", "#ff6a00").css("font-weight", "700").css("color", "#fff");
}