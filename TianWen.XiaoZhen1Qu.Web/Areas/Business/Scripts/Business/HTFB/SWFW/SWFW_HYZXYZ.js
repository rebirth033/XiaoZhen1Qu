$(document).ready(function () {
    $("#divYSFW").find(".div_radio").bind("click", function () { ValidateRadio("YSFW", "忘记选择运送范围啦"); });
    $("#divHYTD").find(".div_radio").bind("click", function () { ValidateRadio("HYTD", "忘记选择货运通道啦"); });
    $("#divSFWF").find(".div_radio").bind("click", function () { ValidateRadio("SFWF", "忘记选择是否往返啦"); });
    $("#divYWZZ").find(".div_radio").bind("click", function () { ValidateRadio("YWZZ", "忘记选择有无中转啦"); });
    $("#divBC").find(".div_radio").bind("click", function () { ValidateRadio("BC", "忘记选择班次啦"); });
    $("#DDD").bind("blur", ValidateDDD);
    $("#DDD").bind("focus", InfoDDD);
    $("#TZSJ").bind("blur", ValidateTZSJ);
    $("#TZSJ").bind("focus", InfoTZSJ);
    $("#YSJG").bind("blur", ValidateYSJG);
    $("#YSJG").bind("focus", InfoYSJG);
});
//运输价格
function ValidateYS() {
    if (!ValidateYSJG()) return false;
    if (!ValidateSelect("YSJG", "YSJGDW", "忘记选择单位啦")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("YSFW", "忘记选择运送范围啦")
        & ValidateSZQY()
        & ValidateDDD()
        & ValidateRadio("HYTD", "忘记选择货运通道啦")
        & ValidateRadio("SFWF", "忘记选择是否往返啦")
        & ValidateRadio("YWZZ", "忘记选择有无中转啦")
        & ValidateRadio("BC", "忘记选择班次啦")
        & ValidateTZSJ()
        & ValidateCheck("ZHFS", "忘记选择组货方式啦")
        & ValidateCheck("HWZL", "忘记选择货物种类啦")
        & ValidateCheck("FWYS", "忘记选择服务延伸啦")
        & ValidateYS()
        & ValidateFWQY()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证到达地
function ValidateDDD() {
    if ($("#DDD").val() === "" || $("#DDD").val() === null) {
        $("#divDDDTip").css("display", "block");
        $("#divDDDTip").attr("class", "Warn");
        $("#divDDDTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写到达地啦');
        $("#DDD").css("border-color", "#F2272D");
        return false;
    } else {
        $("#divDDDTip").css("display", "none");
        $("#DDD").css("border-color", "#cccccc");
        return true;
    }
}
//验证途中时间
function ValidateTZSJ() {
    if ($("#TZSJ").val() === "" || $("#TZSJ").val() === null) {
        $("#divTZSJTip").css("display", "block");
        $("#divTZSJTip").attr("class", "Warn");
        $("#divTZSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写途中时间啦');
        $("#TZSJ").css("border-color", "#F2272D");
        return false;
    } else {
        $("#divTZSJTip").css("display", "none");
        $("#TZSJ").css("border-color", "#cccccc");
        return true;
    }
}
//验证运输价格
function ValidateYSJG() {
    if ($("#YSJG").val() === "" || $("#YSJG").val() === null) {
        $("#divYSJGTip").css("display", "block");
        $("#divYSJGTip").attr("class", "Warn");
        $("#divYSJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写运输价格啦');
        $("#YSJG").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber($("#YSJG").val())) {
            $("#divYSJGTip").css("display", "none");
            $("#YSJG").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divYSJGTip").css("display", "block");
            $("#divYSJGTip").attr("class", "Warn");
            $("#divYSJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />运输价格请填写整数，默认为面议');
            $("#YSJG").css("border-color", "#F2272D");
            return false;
        }
    }
}
//提示到达地
function InfoDDD() {
    $("#divDDDTip").css("display", "block");
    $("#divDDDTip").attr("class", "Info");
    $("#divDDDTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写到达地');
    $("#DDD").css("border-color", "#bc6ba6");
}
//提示途中时间
function InfoTZSJ() {
    $("#divTZSJTip").css("display", "block");
    $("#divTZSJTip").attr("class", "Info");
    $("#divTZSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写途中时间');
    $("#TZSJ").css("border-color", "#bc6ba6");
}
//提示运输价格
function InfoYSJG() {
    $("#divYSJGTip").css("display", "block");
    $("#divYSJGTip").attr("class", "Info");
    $("#divYSJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#YSJG").css("border-color", "#bc6ba6");
}