$(document).ready(function () {
    $("#RJXF").bind("blur", ValidateRJXF);
    $("#RJXF").bind("focus", InfoRJXF);
    $("#FWFW").bind("blur", ValidateFWFW);
    $("#FWFW").bind("focus", InfoFWFW);
});
//验证所有
function ValidateAll() {
    if (ValidateCheck("WMLB", "忘记选择类别啦")
        & ValidateRJXF()

        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
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
//验证服务区域 
function ValidateFWFW() {
    if ($("#FWFW").val() === "" || $("#FWFW").val() === null) {
        $("#divFWFWTip").css("display", "block");
        $("#divFWFWTip").attr("class", "Warn");
        $("#divFWFWTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写服务区域啦');
        $("#FWFW").css("border-color", "#F2272D");
        return false;
    } else {
        $("#divFWFWTip").css("display", "none");
        $("#FWFW").css("border-color", "#cccccc");
        return true;
    }
}
//提示人均消费
function InfoRJXF() {
    $("#divRJXFTip").css("display", "block");
    $("#divRJXFTip").attr("class", "Info");
    $("#divRJXFTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanRJXF").css("border-color", "#bc6ba6");
}
//提示服务区域
function InfoFWFW() {
    $("#divFWFWTip").css("display", "block");
    $("#divFWFWTip").attr("class", "Info");
    $("#divFWFWTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#FWFW").css("border-color", "#bc6ba6");
}
