$(document).ready(function () {
    $(".div_left_box_info").bind("mouseover", ShowRemark);
    $(".div_left_box_info").bind("mouseleave", HideRemark);
});

function ShowRemark() {
    $(this).find(".span_left_box_info_remark").each(function() {
        $(this).css("display", "block");
    });
}

function HideRemark() {
    $(this).find(".span_left_box_info_remark").each(function () {
        $(this).css("display", "none");
    });
}