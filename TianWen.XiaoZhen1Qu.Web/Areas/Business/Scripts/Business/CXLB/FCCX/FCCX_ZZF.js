$(document).ready(function() {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_condition").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);

    $("#li_condition_head_qyzf").css("background-color", "#ffffff");
    BindConditionLi();
});

function BindConditionLi() {
    $(".li_condition_head").bind("click", function () {
        $(".li_condition_head").each(function() {
            $(this).css("background-color", "#eeeff1");
        });
        $(this).css("background-color", "#ffffff");
    });
}