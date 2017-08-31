$(document).ready(function () {
    $(".span_wtlx_inner_right").bind("click", SelectWTLX);
    $("#span_wtlx_inner_right_xxbsc").bind("click", showXXBSC);
    $("#btnCKBSCYY").bind("click", CKBSCYY);
    bindHover();
});

function SelectWTLX() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).css("background-color", "#eBeBeB").css("font-weight", "normal").css("color", "#000");
    });
    bindHover();
    $(this).css("background-color", "#ff6a00").css("font-weight", "700").css("color", "#fff");
    $(this).unbind("mouseleave");
}

function showXXBSC() {
    $("#span_step_text_second").html("请输入您的信息编号:")
}

function bindHover() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).bind("mouseover", function () {
            $(this).css("background-color", "#ff6a00").css("font-weight", "700").css("color", "#fff");
        })
        $(this).bind("mouseleave", function () {
            $(this).css("background-color", "#eBeBeB").css("font-weight", "normal").css("color", "#000");
        })
    });
}

function CKBSCYY() {
    if (!XXBHCheck()) return;

}

//用户名检查
function XXBHCheck() {
    if ($("#inputXXBH").val().length === 0) {
        $("#inputXXBH").css("border-color", "#F2272D");
        $("#td_xxbhinfo").html("<span id=\"XXBHInfo\" style=\"padding-left:12px;color:#F2272D\">请输入信息编号</span>");
        return false;
    }
    else {
        $("#inputXXBH").css("border-color", "#999");
        $("#td_xxbhinfo").html("<div class=\"div_bscyy\"></div>");
        return true;
    }
}