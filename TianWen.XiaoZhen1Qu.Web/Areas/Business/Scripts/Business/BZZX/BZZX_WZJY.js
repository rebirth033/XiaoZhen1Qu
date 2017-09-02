$(document).ready(function () {
    $(".span_wtlx_inner_right").bind("click", SelectWTLX);
    bindHover();
    BindWTMS();
});
//选择问题类型
function SelectWTLX() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).css("background-color", "#ffffff").css("font-weight", "normal").css("color", "#000");
    });
    bindHover();
    $(this).css("background-color", "#ff6a00").css("font-weight", "700").css("color", "#fff");
    $(this).unbind("mouseleave");
    showWTLX(this.id);
}
//绑定问题类型hover事件
function bindHover() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).bind("mouseover", function () {
            $(this).css("background-color", "#ff6a00").css("font-weight", "700").css("color", "#fff");
        })
        $(this).bind("mouseleave", function () {
            $(this).css("background-color", "#ffffff").css("font-weight", "normal").css("color", "#000");
        })
    });
}
//绑定具体问题hover事件
function bindJTWTHover() {
    $(".span_wtjj_inner").each(function () {
        $(this).bind("mouseover", function () {
            $(this).css("color", "#ff6a00");
        })
        $(this).bind("mouseleave", function () {
            $(this).css("color", "#0000cd");
        })
    });
}
//查询信息被删除原因
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
        $("#td_xxbhinfo").html("<textarea class=\"textarea_mswt\"></textarea><span>以上信息没有解决您的问题？</span><input class=\"btn btn-info\" type=\"button\" style=\"margin-top: -3px; width: 140px;\" value=\"填表单，联系客服\" onclick=\"TBD()\" />");
        return true;
    }
}
//绑定问题描述框
function BindWTMS() {
    $("#textarea_mswt").bind("focus", WTMSFocus);
    $("#textarea_mswt").bind("blur", WTMSBlur);
}
//问题描述框鼠标键入
function WTMSFocus() {
    $("#textarea_mswt").css("color", "#333333");
    $("#textarea_mswt").html("");
}
//问题描述框鼠标移除
function WTMSBlur() {
    $("#textarea_mswt").css("color", "#999999");
    if ($("#textarea_mswt").html() === "") {
        $("#textarea_mswt").html("请描述您的具体问题，字数在15至300之间");
    }
}