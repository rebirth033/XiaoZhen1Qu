$(document).ready(function () {
    $(".div_left_box_info").bind("mouseover", ShowRemark);
    $(".div_left_box_info").bind("mouseleave", HideRemark);
    
    $("#div_left_box_info_zdjs").bind("click", OpenZDJS);
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

function OpenZDJS() {
    window.open(getRootPath() + "/Business/BZZX/BZZX_SY_ZDJS?YHID=" + getUrlParam("YHID"));
}