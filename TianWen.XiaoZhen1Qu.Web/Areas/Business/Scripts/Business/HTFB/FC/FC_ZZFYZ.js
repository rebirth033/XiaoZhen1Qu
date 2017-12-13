$(document).ready(function () {
    $("#XQMC").bind("blur", ValidateXQMC);
    $("#XQMC").bind("focus", function () { InfoInput("XQMC", "小区名称不超过30字"); });
    $("#S").bind("blur", ValidateFWLX_S);
    $("#S").bind("focus", function () { InfoSpanInput("S", "室请填写整数，不能是0", "FWLX"); });
    $("#T").bind("blur", ValidateFWLX_T);
    $("#T").bind("focus", function () { InfoSpanInput("T", "厅请填写整数，不能是0", "FWLX"); });
    $("#W").bind("blur", ValidateFWLX_W);
    $("#W").bind("focus", function () { InfoSpanInput("W", "卫请填写整数，不能是0", "FWLX"); });
    $("#PFM").bind("blur", ValidateFWLX_PFM);
    $("#PFM").bind("focus", function () { InfoSpanInput("PFM", "面积请填写整数，不能是0", "FWLX"); });
    $("#C").bind("blur", ValidateLCFB_C);
    $("#C").bind("focus", function () { InfoSpanInput("C", "楼层请填写整数，地下室用负数填写，不能为0", "LCFB"); });
    $("#GJC").bind("blur", ValidateLCFB_GJC);
    $("#GJC").bind("focus", function () { InfoSpanInput("GJC", "总层数请填写整数，不能是0", "LCFB"); });
    $("#ZJ").bind("blur", ValidateZJ);
    $("#ZJ").bind("focus", function () { InfoSpanInput("ZJ", "租金请填写整数，默认为面议"); });
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
//验证所有
function ValidateAll() {
    if (ValidateBCMS("BCMS", "忘记填写房源描述啦")
        & ValidateFWQK()
        & ValidateXQMC()
        & ValidateFWLX()
        & ValidateLCFB()
        & ValidateFWZJ()
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
            $("#PFM").css("border-color", "#cccccc");
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