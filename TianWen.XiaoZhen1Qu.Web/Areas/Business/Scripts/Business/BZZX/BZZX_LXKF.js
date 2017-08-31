$(document).ready(function () {
    $(".span_wtlx_inner_right").bind("click", SelectWTLX);
    $("#span_wtlx_inner_right_xxbsc").bind("click", showXXBSC);
});

function SelectWTLX() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).css("background-color", "#eBeBeB").css("font-weight", "normal").css("color", "#000");
    });
    $(this).css("background-color", "#ff6a00").css("font-weight", "700").css("color", "#fff");
}

function showXXBSC() {
    $("#span_step_text_second").html("请输入您的信息编号:")
}
