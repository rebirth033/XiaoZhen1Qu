$(document).ready(function () {
    $("#divCZFS").find(".div_radio").bind("click", function () { ValidateRadio("CZFS", "忘记填写出租方式啦"); });
    $("#XQMC").bind("blur", ValidateXQMC);
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
    $("#SJ").bind("blur", ValidateSJ);
    $("#SJ").bind("focus", InfoSJ);
});
//验证房屋类型
function ValidateFWLX() {
    if (!ValidateFWLX_S()) return false;
    if (!ValidateFWLX_T()) return false;
    if (!ValidateFWLX_W()) return false;
    if (!ValidateFWLX_PFM()) return false;
    return true;
}
//验证房屋情况
function ValidateFWQK() {
    if (!ValidateSelect("FWQK", "FWCX", "请选择房屋朝向")) return false;
    if (!ValidateSelect("FWQK", "ZXQK", "请选择装修情况")) return false;
    if (!ValidateSelect("FWQK", "ZZLX", "请选择住宅类型")) return false;
    return true;
}
//验证楼层分布
function ValidateLCFB() {
    if (!ValidateLCFB_C()) return false;
    if (!ValidateLCFB_GJC()) return false;
    return true;
}
//验证房屋租金
function ValidateFWSJ() {
    if (!ValidateSJ()) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateBCMS("BCMS", "忘记填写房源描述啦")
        & ValidateFWQK()
        & ValidateXQMC()
        & ValidateFWLX()
        & ValidateLCFB()
        & ValidateFWSJ()
        & ValidateCommon())
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
            $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />厅请填写整数，默认为面议');
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
            $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />卫请填写整数，默认为面议');
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
        if (ValidateDecimal($("#PFM").val()) && $("#PFM").val() !== "0") {
            $("#divFWLXTip").css("display", "none");
            $("#PFM").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divFWLXTip").css("display", "block");
            $("#divFWLXTip").attr("class", "Warn");
            $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />面积请填写数字，不能是0');
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

function ValidateSJ() {
    if ($("#SJ").val() === "" || $("#SJ").val() === null) {
        $("#divSJTip").css("display", "block");
        $("#divSJTip").attr("class", "Warn");
        $("#divSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写售价啦');
        $("#spanSJ").css("border-color", "#fd634f");
        return false;
    } else {
        if (ValidateNumber($("#SJ").val())) {
            $("#divSJTip").css("display", "none");
            $("#spanSJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divSJTip").css("display", "block");
            $("#divSJTip").attr("class", "Warn");
            $("#divSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />售价请填写整数，默认为面议');
            $("#spanSJ").css("border-color", "#fd634f");
            return false;
        }
    }
}

function InfoXQMC() {
    $("#divXQMCTip").css("display", "block");
    $("#divXQMCTip").attr("class", "Info");
    $("#divXQMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />不超过30字');
    $("#XQMC").css("border-color", "#ad5b97");
}

function InfoFWLX_S() {
    $("#divFWLXTip").css("display", "block");
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写整数，不能是0');
    $("#spanS").css("border-color", "#ad5b97");
}

function InfoFWLX_T() {
    $("#divFWLXTip").css("display", "block");
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写整数，没有请填0');
    $("#spanT").css("border-color", "#ad5b97");
}

function InfoFWLX_W() {
    $("#divFWLXTip").css("display", "block");
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写整数，没有请填0');
    $("#spanW").css("border-color", "#ad5b97");
}

function InfoFWLX_PFM() {
    $("#divFWLXTip").css("display", "block");
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写整数，不能是0');
    $("#spanPFM").css("border-color", "#ad5b97");
}

function InfoLCFB_C() {
    $("#divLCFBTip").css("display", "block");
    $("#divLCFBTip").attr("class", "Info");
    $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写整数，地下室用负数填写，不能为0');
    $("#spanC").css("border-color", "#ad5b97");
}

function InfoLCFB_GJC() {
    $("#divLCFBTip").css("display", "block");
    $("#divLCFBTip").attr("class", "Info");
    $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写整数，不能为0');
    $("#spanGJC").css("border-color", "#ad5b97");
}

function InfoSJ() {
    $("#divSJTip").css("display", "block");
    $("#divSJTip").attr("class", "Info");
    $("#divSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanSJ").css("border-color", "#ad5b97");
} 