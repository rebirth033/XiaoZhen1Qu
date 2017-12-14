$(document).ready(function () {
    $("#divGCCLB").find(".div_radio").bind("click", function () { ValidateRadio("GCCLB", ""); });
    $("#DW").bind("blur", ValidateDW);
    $("#DW").bind("focus", InfoDW);
    $("#XSS").bind("blur", ValidateXSS);
    $("#XSS").bind("focus", InfoXSS);
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证出厂年份
function ValidateGCCCCNF() {
    if (!ValidateSelect("GCCCCNF", "CCNF", "请选择出厂年份")) return false;
    if (!ValidateSelect("GCCCCNF", "CCYF", "请选择出厂月份")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if ($("#spanCX").html() === "挖掘机") {
        if (ValidateRadio("GCCLB", "忘记选择类别啦")
            & ValidateSelect("GCCCX", "CX", "忘记选择车型啦")
            & ValidateSelect("GCCPP", "PP", "忘记选择品牌啦")
            & ValidateGCCCCNF()
            & ValidateDW()
            & ValidateXSS()
            & ValidateBCMS("BCMS", "忘记填写补充描述啦")
            & ValidateSZQY()
            & ValidateJG()
            & ValidateCommon())
            return true;
        else
            return false;
    }
    else {
        if (ValidateRadio("GCCLB", "忘记选择类别啦")
            & ValidateSelect("GCCCX", "CX", "忘记选择车型啦")
            & ValidateGCCCCNF()
            & ValidateDW()
            & ValidateXSS()
            & ValidateBCMS("BCMS", "忘记填写补充描述啦")
            & ValidateSZQY()
            & ValidateJG()
            & ValidateCommon())
            return true;
        else
            return false;
    }
}
//验证吨位
function ValidateDW() {
    if ($("#DW").val() === "" || $("#DW").val() === null) {
        $("#divDWTip").css("display", "block");
        $("#divDWTip").attr("class", "Warn");
        $("#divDWTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写吨位啦');
        $("#spanDW").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateDecimal($("#DW").val())) {
            $("#divDWTip").css("display", "none");
            $("#spanDW").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divDWTip").css("display", "block");
            $("#divDWTip").attr("class", "Warn");
            $("#divDWTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />吨位请填写数字');
            $("#spanDW").css("border-color", "#F2272D");
            return false;
        }
    }
}
//验证小时数
function ValidateXSS() {
    if ($("#XSS").val() === "" || $("#XSS").val() === null) {
        $("#divXSSTip").css("display", "block");
        $("#divXSSTip").attr("class", "Warn");
        $("#divXSSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写小时数啦');
        $("#spanXSS").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateDecimal($("#XSS").val())) {
            $("#divXSSTip").css("display", "none");
            $("#spanXSS").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divXSSTip").css("display", "block");
            $("#divXSSTip").attr("class", "Warn");
            $("#divXSSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />小时数请填写数字');
            $("#spanXSS").css("border-color", "#F2272D");
            return false;
        }
    }
}
//提示吨位
function InfoDW() {
    $("#divDWTip").css("display", "block");
    $("#divDWTip").attr("class", "Info");
    $("#divDWTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写数字');
    $("#spanDW").css("border-color", "#bc6ba6");
}
//提示小时数
function InfoXSS() {
    $("#divXSSTip").css("display", "block");
    $("#divXSSTip").attr("class", "Info");
    $("#divXSSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写数字');
    $("#spanXSS").css("border-color", "#bc6ba6");
}