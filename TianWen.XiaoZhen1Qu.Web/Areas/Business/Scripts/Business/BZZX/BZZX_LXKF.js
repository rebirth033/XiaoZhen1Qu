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
    showWTLX(this.id);
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

//信息编号检查
function XXBHCheck() {
    if ($("#inputXXBH").val().length === 0) {
        $("#inputXXBH").css("border-color", "#F2272D");
        $("#td_xxbhinfo").html("<span id=\"XXBHInfo\" style=\"padding-left:12px;color:#F2272D\">请输入信息编号</span>");
        return false;
    }
    else {
        $("#inputXXBH").css("border-color", "#999");
        $("#td_xxbhinfo").html("<textarea class=\"textarea_bscyy\"></textarea><span>以上信息没有解决您的问题？</span><input class=\"btn btn-info\" type=\"button\" style=\"margin-top: -3px; width: 140px;\" value=\"填表单，联系客服\" onclick=\"TBD()\" />");
        return true;
    }
}

function TBD() {
    $("#div_content_tjkf").css("display", "block");
}

function showWTLX(id) {
    $(".div_wtjj_inner").each(function () {
        $(this).css("display", "none");
    });
    if (id.indexOf("xxbsc") != -1)
        ShowXXBSC();
}

function ShowXXBSC() {
    $("#div_xxbsc").css("display", "block");
}