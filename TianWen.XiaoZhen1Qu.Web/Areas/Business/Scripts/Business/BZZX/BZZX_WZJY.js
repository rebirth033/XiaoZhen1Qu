$(document).ready(function () {
    $("#btnTJJY").bind("click", TJJY);
    BindYJNR();
    $("#textarea_yjnr").bind("onfocus", InitYJNR);
});
//初始化意见内容
function InitYJNR() {
    if ($("#textarea_yjnr").val().indexOf('意见内容在1000字以内') !== -1) {
        $("#textarea_yjnr").val('');
    }
}

//选择问题类型
function SelectWTLX() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).css("background-color", "#ffffff").css("font-weight", "normal").css("color", "#333");
    });
    bindHover();
    $(this).css("background-color", "#bc6ba6").css("font-weight", "700").css("color", "#fff");
    $(this).unbind("mouseleave");

}
//绑定意见内容
function BindYJNR() {
    $("#textarea_yjnr").bind("focus", YJNRFocus);
    $("#textarea_yjnr").bind("blur", YJNRBlur);
}
//意见内容鼠标键入
function YJNRFocus() {
    $("#textarea_yjnr").css("color", "#333333");
    if ($("#textarea_yjnr").val().indexOf("1000字以内") !== -1)
        $("#textarea_yjnr").html("");
}
//问题描述框鼠标移除
function YJNRBlur() {
    $("#textarea_yjnr").css("color", "#999999");
    if ($("#textarea_yjnr").html() === "") {
        $("#textarea_yjnr").html("意见内容在1000字以内。\r\n若您的意见被采纳，我们将会通过消息通知您，请关注消息更新记录，请留下您宝贵的意见！");
    }
}
//意见内容检查
function CheckYJNR() {
    if ($("#textarea_yjnr").val().indexOf("意见内容在1000字以内") !== -1) {
        $("#textarea_yjnr").css("border-color", "#F2272D");
        $("#span_yjnrinfo").css("color", "#F2272D");
        $("#span_yjnrinfo").html("意见内容在500字以内，不可为空");
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
    if (CheckYJNR())
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
        url: getRootPath() + "/Business/BZZX_WZJY/SaveWZJY",
        dataType: "json",
        data:
        {
            LB: "1",
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