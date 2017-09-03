$(document).ready(function () {
    $(".span_wtlx_inner_right").bind("click", SelectWTLX);
    $("#btnTJJY").bind("click", TJJY);
    $("#inputUpload").bind("change", Upload);
    bindHover();
    BindYJNR();
});
//选择问题类型
function SelectWTLX() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).css("background-color", "#ffffff").css("font-weight", "normal").css("color", "#333");
    });
    bindHover();
    $(this).css("background-color", "#ff6a00").css("font-weight", "700").css("color", "#fff");
    $(this).unbind("mouseleave");
    //showWTLX(this.id);
}
//绑定问题类型hover事件
function bindHover() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).bind("mouseover", function () {
            $(this).css("background-color", "#ff6a00").css("font-weight", "700").css("color", "#fff");
        })
        $(this).bind("mouseleave", function () {
            $(this).css("background-color", "#ffffff").css("font-weight", "normal").css("color", "#333");
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
//绑定意见内容
function BindYJNR() {
    $("#textarea_yjnr").bind("focus", YJNRFocus);
    $("#textarea_yjnr").bind("blur", YJNRBlur);
}
//意见内容鼠标键入
function YJNRFocus() {
    $("#textarea_yjnr").css("color", "#333333");
    if ($("#textarea_yjnr").val().indexOf("您可填写15-300字") !== -1)
        $("#textarea_yjnr").html("");
}
//问题描述框鼠标移除
function YJNRBlur() {
    $("#textarea_yjnr").css("color", "#999999");
    if ($("#textarea_yjnr").html() === "") {
        $("#textarea_yjnr").html("您可填写15-300字。\r\n您的意见若被采纳，会通过消息通知您，请关注消息更新记录");
    }
}
//类别检查
function CheckLB() {
    var hasSelect = false;
    $(".span_wtlx_inner_right").each(function () {
        if ($(this).css("color") !== "rgb(51, 51, 51)")
            hasSelect = true;
    });
    if (hasSelect)
        return true;
    else {
        alert("还未选择类别");
        return false;
    }
}
//意见内容检查
function CheckYJNR() {
    if ($("#textarea_yjnr").val().indexOf("您可填写15-300字") !== -1) {
        $("#textarea_yjnr").css("border-color", "#F2272D");
        $("#span_yjnrinfo").css("color", "#F2272D");
        $("#span_yjnrinfo").html("意见内容在15-300字之间，不可为空");
        return false;
    }
    else {
        $("#textarea_yjnr").css("border-color", "#DEDEDE");
        $("#span_yjnrinfo").html("");
        return true;
    }
}
//网站意见验证
function ValidateWZYJ() {
    if (CheckLB() & CheckYJNR())
        return true;
    else
        return false;
}
//类别获取
function GetLB() {
    var lb = "";
    $(".span_wtlx_inner_right").each(function (i) {
        if ($(this).css("color") === "rgb(255, 255, 255)")
            lb = i;
    });
    return lb;
}
//提交建议
function TJJY() {
    if (ValidateWZYJ() === false) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/WZYJ/SaveWZJY",
        dataType: "json",
        data:
        {
            LB: GetLB(),
            YJNR: $("#textarea_yjnr").html(),
            FWZP: GetPhotoUrls()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                alert(xml.Message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}