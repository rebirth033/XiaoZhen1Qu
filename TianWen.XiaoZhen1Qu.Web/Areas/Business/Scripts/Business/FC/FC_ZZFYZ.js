$(document).ready(function () {
    $("#divCZFS").find(".div_radio").bind("click", function () { ValidateRadio("CZFS", "忘记填写出租方式啦"); });
    $("#XQMC").bind("blur", ValidateXQMC);
    $("#XQMC").bind("blur", HideXQMCList);
    $("#XQMC").bind("focus", InfoXQMC);
    $("#S").bind("blur", ValidateFWLX_S);
    $("#S").bind("focus", InfoFWLX_S);
    $("#T").bind("blur", ValidateFWLX_T);
    $("#T").bind("focus", InfoFWLX_T);
    $("#W").bind("blur", ValidateFWLX_W);
    $("#W").bind("focus", InfoFWLX_W);
    $("#PFM").bind("blur", ValidateFWLX_PFM);
    $("#PFM").bind("focus", InfoFWLX_PFM);
    $("#C").bind("blur", ValidateLCFB_C);
    $("#C").bind("focus", InfoLCFB_C);
    $("#GJC").bind("blur", ValidateLCFB_GJC);
    $("#GJC").bind("focus", InfoLCFB_GJC);
    $("#ZJ").bind("blur", ValidateZJ);
    $("#ZJ").bind("focus", InfoZJ);
});

function FWLXValidate() {
    if (!ValidateFWLX_S()) return false;
    if (!ValidateFWLX_T()) return false;
    if (!ValidateFWLX_W()) return false;
    if (!ValidateFWLX_PFM()) return false;
    return true;
}

function LCFBValidate() {
    if (!ValidateLCFB_C()) return false;
    if (!ValidateLCFB_GJC()) return false;
    return true;
}

function FWQKValidate() {
    if (!ValidateSelect("FWQK", "FWCX", "请选择房屋朝向")) return false;
    if (!ValidateSelect("FWQK", "ZXQK", "请选择装修情况")) return false;
    if (!ValidateSelect("FWQK", "ZZLX", "请选择住宅类型")) return false;
    return true;
}

function AllValidate() {
    if (ValidateRadio("CZFS", "忘记填写出租方式啦")
        & FWQKValidate() 
        & ValidateXQMC() & FWLXValidate() & LCFBValidate() & ValidateZJ() & ValidateBT() & ValidateFWZP() & ValidateLXR() & ValidateLXDH())
        return true;
    else
        return false;
}

function ValidateXQMC() {
    if ($("#XQMC").val() === "" || $("#XQMC").val() === null) {
        $("#divXQMCTip").css("display", "block");
        $("#divXQMCTip").attr("class", "Warn");
        $("#divXQMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写小区名称啦');
        $("#XQMC").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divXQMCTip").css("display", "none");
        $("#XQMC").css("border-color", "#cccccc");
        return true;
    }
}

function ValidateFWLX_S() {
    if ($("#S").val() === "" || $("#S").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写室啦');
        $("#spanS").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#S").val()) && $("#S").val() !== "0") {
            $("#divFWLXTip").css("display", "none");
            $("#S").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divFWLXTip").css("display", "block");
            $("#divFWLXTip").attr("class", "Warn");
            $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />室请填写整数，不能是0');
            $("#spanS").css("border-color", "#fd634f");
            return false;
        }
    }
}

function ValidateFWLX_T() {
    if ($("#T").val() === "" || $("#T").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写厅啦');
        $("#spanT").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#T").val())) {
            $("#divFWLXTip").css("display", "none");
            $("#T").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divFWLXTip").css("display", "block");
            $("#divFWLXTip").attr("class", "Warn");
            $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />厅请填写整数，面议则填0');
            $("#spanT").css("border-color", "#fd634f");
            return false;
        }
    }
}

function ValidateFWLX_W() {
    if ($("#W").val() === "" || $("#W").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写卫啦');
        $("#spanW").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#W").val())) {
            $("#divFWLXTip").css("display", "none");
            $("#W").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divFWLXTip").css("display", "block");
            $("#divFWLXTip").attr("class", "Warn");
            $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />卫请填写整数，面议则填0');
            $("#spanW").css("border-color", "#fd634f");
            return false;
        }
    }
}

function ValidateFWLX_PFM() {
    if ($("#PFM").val() === "" || $("#PFM").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写面积啦');
        $("#spanPFM").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#PFM").val()) && $("#PFM").val() !== "0") {
            $("#divFWLXTip").css("display", "none");
            $("#PFM").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divFWLXTip").css("display", "block");
            $("#divFWLXTip").attr("class", "Warn");
            $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />面积请填写整数，不能是0');
            $("#spanPFM").css("border-color", "#fd634f");
            return false;
        }
    }
}

function ValidateLCFB_C() {
    if ($("#C").val() === "" || $("#C").val() === null) {
        $("#divLCFBTip").css("display", "block");
        $("#divLCFBTip").attr("class", "Warn");
        $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写楼层啦');
        $("#spanC").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#C").val()) && $("#C").val() !== "0") {
            $("#divLCFBTip").css("display", "none");
            $("#C").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divLCFBTip").css("display", "block");
            $("#divLCFBTip").attr("class", "Warn");
            $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />楼层请填写整数，不能是0');
            $("#spanC").css("border-color", "#fd634f");
            return false;
        }
    }
}

function ValidateLCFB_GJC() {
    if ($("#GJC").val() === "" || $("#GJC").val() === null) {
        $("#divLCFBTip").css("display", "block");
        $("#divLCFBTip").attr("class", "Warn");
        $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写总层数啦');
        $("#spanGJC").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#GJC").val()) && $("#GJC").val() !== "0") {
            $("#divLCFBTip").css("display", "none");
            $("#spanGJC").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divLCFBTip").css("display", "block");
            $("#divLCFBTip").attr("class", "Warn");
            $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />总层数请填写整数，不能是0');
            $("#spanGJC").css("border-color", "#fd634f");
            return false;
        }
    }
}

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

function InfoXQMC() {
    $("#divXQMCTip").css("display", "block");
    $("#divXQMCTip").attr("class", "Info");
    $("#divXQMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />不超过30字');
    $("#XQMC").css("border-color", "#5bc0de");
}

function InfoFWLX_S() {
    $("#divFWLXTip").css("display", "block");
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写整数，不能是0');
    $("#spanS").css("border-color", "#5bc0de");
}

function InfoFWLX_T() {
    $("#divFWLXTip").css("display", "block");
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写整数，没有请填0');
    $("#spanT").css("border-color", "#5bc0de");
}

function InfoFWLX_W() {
    $("#divFWLXTip").css("display", "block");
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写整数，没有请填0');
    $("#spanW").css("border-color", "#5bc0de");
}

function InfoFWLX_PFM() {
    $("#divFWLXTip").css("display", "block");
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写整数，不能是0');
    $("#spanPFM").css("border-color", "#5bc0de");
}

function InfoLCFB_C() {
    $("#divLCFBTip").css("display", "block");
    $("#divLCFBTip").attr("class", "Info");
    $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写整数，地下室用负数填写，不能为0');
    $("#spanC").css("border-color", "#5bc0de");
}

function InfoLCFB_GJC() {
    $("#divLCFBTip").css("display", "block");
    $("#divLCFBTip").attr("class", "Info");
    $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写整数，不能为0');
    $("#spanGJC").css("border-color", "#5bc0de");
}

function InfoZJ() {
    $("#divZJTip").css("display", "block");
    $("#divZJTip").attr("class", "Info");
    $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，面议则填0');
}

function InfoBT() {
    $("#divBTTip").css("display", "block");
    $("#divBTTip").attr("class", "Info");
    $("#divBTTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />标题不超过50字');
    $("#BT").css("border-color", "#5bc0de");
}

function InfoLXR() {
    $("#divLXRTip").css("display", "block");
    $("#divLXRTip").attr("class", "Info");
    $("#divLXRTip").html('');
    $("#LXR").css("border-color", "#5bc0de");
}

function InfoLXDH() {
    $("#divLXDHTip").css("display", "block");
    $("#divLXDHTip").attr("class", "Info");
    $("#divLXDHTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请输入手机号');
    $("#LXDH").css("border-color", "#5bc0de");
}

function HideXQMCList() {
    if (isleave)
        $("#divXQMClist").css("display", "none");
}