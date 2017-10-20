$(document).ready(function () {
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
    $("#SYNX").bind("blur", ValidateSYNX);
    $("#SYNX").bind("focus", InfoSYNX);
});
//验证售价
function ValidateJG() {
    if ($("#JG").val() === "" || $("#JG").val() === null) {
        $("#divJGTip").css("display", "block");
        $("#divJGTip").attr("class", "Warn");
        $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写价格啦');
        $("#spanJG").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#JG").val())) {
            $("#divJGTip").css("display", "none");
            $("#spanJG").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divJGTip").css("display", "block");
            $("#divJGTip").attr("class", "Warn");
            $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />价格请填写整数，面议则填0');
            $("#spanJG").css("border-color", "#fd634f");
            return false;
        }
    }
}
//验证使用年限
function ValidateSYNX() {
    if ($("#SYNX").val() === "" || $("#SYNX").val() === null) {
        $("#divSYNXTip").css("display", "block");
        $("#divSYNXTip").attr("class", "Warn");
        $("#divSYNXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写使用年限啦');
        $("#spanSYNX").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#SYNX").val())) {
            $("#divSYNXTip").css("display", "none");
            $("#spanSYNX").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divSYNXTip").css("display", "block");
            $("#divSYNXTip").attr("class", "Warn");
            $("#divSYNXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />使用年限请填写整数');
            $("#spanSYNX").css("border-color", "#fd634f");
            return false;
        }
    }
} 

//验证所有
function AllValidate() {
    if (ValidateJG() & ValidateBT() & ValidateFWZP() & ValidateLXR() & ValidateLXDH())
        return true;
    else
        return false;
}
//提示价格
function InfoJG() {
    $("#divJGTip").css("display", "inline-block");
    $("#divJGTip").attr("class", "Info");
    $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，面议则填0');
}
//提示使用年限
function InfoSYNX() {
    $("#divSYNXTip").css("display", "inline-block");
    $("#divSYNXTip").attr("class", "Info");
    $("#divSYNXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数');
}
