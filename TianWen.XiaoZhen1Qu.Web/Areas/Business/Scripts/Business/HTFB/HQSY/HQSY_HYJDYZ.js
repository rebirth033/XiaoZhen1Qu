$(document).ready(function () {
    $("#divJDLX").find(".div_radio").bind("click", function () { ValidateRadio("JDLX", ""); });
    $("#RNZS").bind("blur", function () { ValidateSpanInput("RNZS", "容纳桌数"); });
    $("#RNZS").bind("focus", function () { InfoSpanInput("RNZS", "忘记填写容纳桌数啦"); });
});
//验证所有
function ValidateAll() {
    if (ValidateSelect("HYJDHLLX", "HLLX", "忘记选择婚礼类型啦")
        & ValidateRadio("JDLX", "忘记选择酒店类型啦")
        & ValidateSelect("HYJDJDXJ", "JDXJ", "忘记选择酒店星级啦")
        & ValidateSpanInput("RNZS", "容纳桌数 ")
        & ValidateJG()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")

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
        if ($(this).css("background-color") === "rgb(135, 181, 59)")
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
        if ($(this).css("background-color") === "rgb(135, 181, 59)")
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