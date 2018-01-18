$(document).ready(function () {
    $("#divTCCZ").find(".div_radio").bind("click", function () { ValidateRadio("TCCZ", ""); });
    $("#divMFTGCH").find(".div_radio").bind("click", function () { ValidateRadio("MFTGCH", ""); });
    $(".div_tcys").bind("click", function () { ValidateTCYS(); });
    $(".div_gcys").bind("click", function () { ValidateGCYS(); });
    $("#GCSL").bind("blur", function () { ValidateSpanInput("GCSL", "跟车数量"); });
    $("#GCSL").bind("focus", function () { InfoSpanInput("GCSL", "忘记填写跟车数量啦"); });
    $("#JNSJ").bind("blur", function () { ValidateSpanInput("JNSJ", "价内时间"); });
    $("#JNSJ").bind("focus", function () { InfoSpanInput("JNSJ", "忘记填写价内时间啦"); });
    $("#JNGLS").bind("blur", function () { ValidateSpanInput("JNGLS", "价内公里数"); });
    $("#JNGLS").bind("focus", function () { InfoSpanInput("JNGLS", "忘记填写价内公里数啦"); });
});
//验证所有
function ValidateAll() {
    if (ValidateRadio("TCCZ", "忘记选择套餐出租啦")
        & ValidateSelect("HCZLTCPP", "TCPP", "忘记选择头车品牌啦")
        & ValidateTCYS()
        & ValidateSpanInput("GCSL", "跟车数量")
        & ValidateSelect("HCZLGCPP", "GCPP", "忘记选择跟车品牌啦")
        & ValidateGCYS()
        & ValidateRadio("MFTGCH", "忘记选择免费提供车花啦")
        & ValidateSpanInput("JNSJ", "价内时间")
        & ValidateSpanInput("JNGLS", "价内公里数 ")
        & ValidateJG()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateCheck("FWFW", "忘记选择服务范围啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证头车颜色
function ValidateTCYS() {
    var value = "";
    $(".div_tcys").each(function () {
        if ($(this).css("background-color") === "rgb(188, 107, 166)")
            value = $(this).find(".span_tcys_right")[0].innerHTML;
    });
    if (value === "") {
        $("#divTCYSTip").css("display", "block");
        $("#divTCYSTip").attr("class", "Warn");
        $("#divTCYSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记选择头车颜色啦');
        return false;
    } else {
        $("#divTCYSTip").css("display", "none");
        return true;
    }
}
//验证跟车颜色
function ValidateGCYS() {
    var value = "";
    $(".div_gcys").each(function () {
        if ($(this).css("background-color") === "rgb(188, 107, 166)")
            value = $(this).find(".span_gcys_right")[0].innerHTML;
    });
    if (value === "") {
        $("#divGCYSTip").css("display", "block");
        $("#divGCYSTip").attr("class", "Warn");
        $("#divGCYSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记选择跟车颜色啦');
        return false;
    } else {
        $("#divGCYSTip").css("display", "none");
        return true;
    }
}