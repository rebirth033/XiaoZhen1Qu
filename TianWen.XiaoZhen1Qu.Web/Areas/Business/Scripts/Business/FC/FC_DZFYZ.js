$(document).ready(function () {
    $("#divCZFS").find(".div_radio").bind("click", function () { ValidateRadio("CZFS", "忘记填写出租方式啦"); });
    $("#ZDZQ").bind("blur", ValidateZDZQ);
    $("#ZDZQ").bind("focus", InfoZDZQ);
    $("#YZRS").bind("blur", ValidateYZRS);
    $("#YZRS").bind("focus", InfoYZRS);
    $("#ZJ").bind("blur", ValidateZJ);
    $("#ZJ").bind("focus", InfoZJ);
    $("#MJ").bind("blur", ValidateMJ);
    $("#MJ").bind("focus", InfoMJ);
});
//验证所有
function ValidateAll() {
    if (ValidateRadio("CZFS", "忘记填写出租方式啦") 
        & ValidateSelect("FWLX", "FWLX", "请选择房屋类型")
        & ValidateBCMS("BCMS", "忘记填写房源描述啦") 
        & ValidateZJ()
        & ValidateMJ()
        & ValidateZDZQ()
        & ValidateYZRS()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证租金
function ValidateZJ() {
    if ($("#ZJ").val() === "" || $("#ZJ").val() === null) {
        $("#divZJTip").css("display", "block");
        $("#divZJTip").attr("class", "Warn");
        $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写租金啦');
        $("#spanZJ").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#ZJ").val())) {
            $("#divZJTip").css("display", "none");
            $("#spanZJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divZJTip").css("display", "block");
            $("#divZJTip").attr("class", "Warn");
            $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />租金请填写整数，面议则填0');
            $("#spanZJ").css("border-color", "#fd634f");
            return false;
        }
    }
}
//验证面积
function ValidateMJ() {
    if ($("#MJ").val() === "" || $("#MJ").val() === null) {
        $("#divMJTip").css("display", "block");
        $("#divMJTip").attr("class", "Warn");
        $("#divMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写面积啦');
        $("#spanMJ").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#ZJ").val())) {
            $("#divMJTip").css("display", "none");
            $("#spanMJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divMJTip").css("display", "block");
            $("#divMJTip").attr("class", "Warn");
            $("#divMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />面积请填写整数，面议则填0');
            $("#spanMJ").css("border-color", "#fd634f");
            return false;
        }
    }
}
//验证最短租期
function ValidateZDZQ() {
    if ($("#ZDZQ").val() === "" || $("#ZDZQ").val() === null) {
        $("#divZDZQTip").css("display", "block");
        $("#divZDZQTip").attr("class", "Warn");
        $("#divZDZQTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写最短租期啦');
        $("#spanZDZQ").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#ZDZQ").val()) && $("#ZDZQ").val() !== "0") {
            $("#divZDZQTip").css("display", "none");
            $("#spanZDZQ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divZDZQTip").css("display", "block");
            $("#divZDZQTip").attr("class", "Warn");
            $("#divZDZQTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />租期请填写整数，面议则填0');
            $("#spanZDZQ").css("border-color", "#fd634f");
            return false;
        }
    }
}
//宜租人数
function ValidateYZRS() {
    if ($("#YZRS").val() === "" || $("#YZRS").val() === null) {
        $("#divYZRSTip").css("display", "block");
        $("#divYZRSTip").attr("class", "Warn");
        $("#divYZRSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写宜租人数啦');
        $("#spanYZRS").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#YZRS").val()) && $("#YZRS").val() !== "0") {
            $("#divYZRSTip").css("display", "none");
            $("#spanYZRS").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divYZRSTip").css("display", "block");
            $("#divYZRSTip").attr("class", "Warn");
            $("#divYZRSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />宜租人数请填写整数，面议则填0');
            $("#spanYZRS").css("border-color", "#fd634f");
            return false;
        }
    }
}

function InfoZJ() {
    $("#divZJTip").css("display", "block");
    $("#divZJTip").attr("class", "Info");
    $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，面议则填0');
}

function InfoZDZQ() {
    $("#divZDZQTip").css("display", "block");
    $("#divZDZQTip").attr("class", "Info");
    $("#divZDZQTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，面议则填0');
}

function InfoYZRS() {
    $("#divYZRSTip").css("display", "inline-block");
    $("#divYZRSTip").attr("class", "Info");
    $("#divYZRSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，面议则填0');
}

function InfoMJ() {
    $("#divMJTip").css("display", "inline-block");
    $("#divMJTip").attr("class", "Info");
    $("#divMJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，面议则填0');
}