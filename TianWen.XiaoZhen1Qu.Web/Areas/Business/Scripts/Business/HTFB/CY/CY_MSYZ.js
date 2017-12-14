$(document).ready(function () {
    $("#RJXF").bind("blur", ValidateRJXF);
    $("#RJXF").bind("focus", InfoRJXF);
});
//验证所有
function ValidateAll() {
    if (ValidateCheck("MSLB", "忘记选择类别啦")
        & ValidateRJXF()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证人均消费
function ValidateRJXF() {
    if ($("#RJXF").val() === "" || $("#RJXF").val() === null) {
        $("#divRJXFTip").css("display", "block");
        $("#divRJXFTip").attr("class", "Warn");
        $("#divRJXFTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写人均消费啦');
        $("#spanRJXF").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateDecimal($("#RJXF").val())) {
            $("#divRJXFTip").css("display", "none");
            $("#spanRJXF").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divRJXFTip").css("display", "block");
            $("#divRJXFTip").attr("class", "Warn");
            $("#divRJXFTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />人均消费请填写整数，默认为面议');
            $("#spanRJXF").css("border-color", "#F2272D");
            return false;
        }
    }
}
//提示人均消费
function InfoRJXF() {
    $("#divRJXFTip").css("display", "block");
    $("#divRJXFTip").attr("class", "Info");
    $("#divRJXFTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanRJXF").css("border-color", "#bc6ba6");
}
