$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", ""); });
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
    $("#ZJ").bind("blur", ValidateZJ);
    $("#ZJ").bind("focus", InfoZJ);
    $("#CZJMJ").bind("blur", ValidateCZJMJ);
    $("#CZJMJ").bind("focus", InfoCZJMJ);
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
function ValidateFWZJ() {
    if (!ValidateZJ()) return false;
    if (!ValidateSelect("ZJ", "YFFS", "请选择押付方式")) return false;
    return true;
}
//验证出租间
function ValidateCZJ() {
    if (!ValidateCZJMJ()) return false;
    if (!ValidateSelect("CZJ", "CZJLX", "请选择卧室")) return false;
    if (!ValidateSelect("CZJ", "CZJXB", "请选择性别")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
        & ValidateBCMS("BCMS", "忘记填写房源描述啦") 
        & ValidateFWQK()
        & ValidateXQMC()
        & ValidateFWLX()
        & ValidateLCFB()
        & ValidateCZJ()
        & ValidateFWZJ()
        & ValidateCommon())
        return true;
    else
        return false;
}

function ValidateXQMC() {
    if ($("#XQDZ").val() === "" || ($("#XQMC").val() !== $("#XQDZ").val())) $("#XQMC").val("");
    if ($("#XQMC").val() === "" || $("#XQMC").val() === null) {
        $("#divXQMCTip").css("display", "block");
        $("#divXQMCTip").attr("class", "Warn");
        $("#divXQMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写小区名称啦');
        $("#XQMC").css("border-color", "#F2272D");
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
        $("#spanS").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber($("#S").val()) && $("#S").val() !== "0") {
            $("#divFWLXTip").css("display", "none");
            $("#spanS").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divFWLXTip").css("display", "block");
            $("#divFWLXTip").attr("class", "Warn");
            $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />室请填写整数，不能是0');
            $("#spanS").css("border-color", "#F2272D");
            return false;
        }
    }
}

function ValidateFWLX_T() {
    if ($("#T").val() === "" || $("#T").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写厅啦');
        $("#spanT").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber($("#T").val())) {
            $("#divFWLXTip").css("display", "none");
            $("#spanT").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divFWLXTip").css("display", "block");
            $("#divFWLXTip").attr("class", "Warn");
            $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />厅请填写整数，默认为面议');
            $("#spanT").css("border-color", "#F2272D");
            return false;
        }
    }
}

function ValidateFWLX_W() {
    if ($("#W").val() === "" || $("#W").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写卫啦');
        $("#spanW").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber($("#W").val())) {
            $("#divFWLXTip").css("display", "none");
            $("#spanW").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divFWLXTip").css("display", "block");
            $("#divFWLXTip").attr("class", "Warn");
            $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />卫请填写整数，默认为面议');
            $("#spanW").css("border-color", "#F2272D");
            return false;
        }
    }
}

function ValidateFWLX_PFM() {
    if ($("#PFM").val() === "" || $("#PFM").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写面积啦');
        $("#spanPFM").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber($("#PFM").val()) && $("#PFM").val() !== "0") {
            $("#divFWLXTip").css("display", "none");
            $("#spanPFM").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divFWLXTip").css("display", "block");
            $("#divFWLXTip").attr("class", "Warn");
            $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />面积请填写整数，不能是0');
            $("#spanPFM").css("border-color", "#F2272D");
            return false;
        }
    }
}

function ValidateLCFB_C() {
    if ($("#C").val() === "" || $("#C").val() === null) {
        $("#divLCFBTip").css("display", "block");
        $("#divLCFBTip").attr("class", "Warn");
        $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写楼层啦');
        $("#spanC").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber($("#C").val()) && $("#C").val() !== "0") {
            $("#divLCFBTip").css("display", "none");
            $("#spanC").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divLCFBTip").css("display", "block");
            $("#divLCFBTip").attr("class", "Warn");
            $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />楼层请填写整数，不能是0');
            $("#spanC").css("border-color", "#F2272D");
            return false;
        }
    }
}

function ValidateLCFB_GJC() {
    if ($("#GJC").val() === "" || $("#GJC").val() === null) {
        $("#divLCFBTip").css("display", "block");
        $("#divLCFBTip").attr("class", "Warn");
        $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写总层数啦');
        $("#spanGJC").css("border-color", "#F2272D");
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
            $("#spanGJC").css("border-color", "#F2272D");
            return false;
        }
    }
}

function ValidateZJ() {
    if ($("#ZJ").val() === "" || $("#ZJ").val() === null) {
        $("#divZJTip").css("display", "block");
        $("#divZJTip").attr("class", "Warn");
        $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写租金啦');
        $("#spanZJ").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber($("#ZJ").val())) {
            $("#divZJTip").css("display", "none");
            $("#spanZJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divZJTip").css("display", "block");
            $("#divZJTip").attr("class", "Warn");
            $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />租金请填写整数，默认为面议');
            $("#spanZJ").css("border-color", "#F2272D");
            return false;
        }
    }
}

function ValidateCZJMJ() {
    if ($("#CZJMJ").val() === "" || $("#CZJMJ").val() === null) {
        $("#divCZJTip").css("display", "block");
        $("#divCZJTip").attr("class", "Warn");
        $("#divCZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写出租间面积啦');
        $("#spanCZJMJ").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber($("#CZJMJ").val()) && $("#CZJMJ").val() !== "0") {
            $("#divCZJTip").css("display", "none");
            $("#spanCZJMJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divCZJTip").css("display", "block");
            $("#divCZJTip").attr("class", "Warn");
            $("#divCZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />面积请填写整数，不能是0');
            $("#spanCZJMJ").css("border-color", "#F2272D");
            return false;
        }
    }
}

function InfoXQMC() {
    $("#divXQMCTip").css("display", "block");
    $("#divXQMCTip").attr("class", "Info");
    $("#divXQMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />不超过30字');
    $("#XQMC").css("border-color", "#bc6ba6");
}

function InfoFWLX_S() {
    $("#divFWLXTip").css("display", "block");
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />填写整数，不能是0');
    $("#spanS").css("border-color", "#bc6ba6");
}

function InfoFWLX_T() {
    $("#divFWLXTip").css("display", "block");
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />填写整数，没有请填0');
    $("#spanT").css("border-color", "#bc6ba6");
}

function InfoFWLX_W() {
    $("#divFWLXTip").css("display", "block");
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />填写整数，没有请填0');
    $("#spanW").css("border-color", "#bc6ba6");
}

function InfoFWLX_PFM() {
    $("#divFWLXTip").css("display", "block");
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />填写整数，不能是0');
    $("#spanPFM").css("border-color", "#bc6ba6");
}

function InfoLCFB_C() {
    $("#divLCFBTip").css("display", "block");
    $("#divLCFBTip").attr("class", "Info");
    $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />填写整数，地下室用负数填写，不能为0');
    $("#spanC").css("border-color", "#bc6ba6");
}

function InfoLCFB_GJC() {
    $("#divLCFBTip").css("display", "block");
    $("#divLCFBTip").attr("class", "Info");
    $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />填写整数，不能为0');
    $("#spanGJC").css("border-color", "#bc6ba6");
}

function InfoZJ() {
    $("#divZJTip").css("display", "block");
    $("#divZJTip").attr("class", "Info");
    $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanZJ").css("border-color", "#bc6ba6");
}

function InfoCZJMJ() {
    $("#divCZJTip").css("display", "block");
    $("#divCZJTip").attr("class", "Info");
    $("#divCZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanCZJMJ").css("border-color", "#bc6ba6");
}