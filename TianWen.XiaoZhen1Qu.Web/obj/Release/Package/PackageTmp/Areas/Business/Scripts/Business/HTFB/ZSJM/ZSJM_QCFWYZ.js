$(document).ready(function () {
    $("#PPMC").bind("blur", function () { ValidatePPMC() });
    $("#PPMC").bind("focus", function () { InfoInput("PPMC", "品牌名称"); });
    $("#GSMC").bind("blur", function () { ValidateGSMC() });
    $("#GSMC").bind("focus", function () { InfoInput("GSMC", "公司名称"); });
});
//验证所有
function ValidateAll() {
    if (ValidateSelect("QCFWLB", "LB", "忘记选择类别啦")
        & ValidatePPMC()
        & ValidateGSMC()
        & ValidateSelect("QCFWTZJE", "TZJE", "忘记选择投资金额啦")
        & ValidateCheck("FWFW", "忘记选择服务范围啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证品牌名称
function ValidatePPMC() {
    if ($("#PPMC").val() === "" || $("#PPMC").val() === null) {
        $("#divPPMCTip").css("display", "block");
        $("#divPPMCTip").attr("class", "Warn");
        $("#divPPMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写品牌名称啦');
        $("#PPMC").css("border-color", "#F2272D");
        return false;
    } else {
        $("#divPPMCTip").css("display", "none");
        $("#PPMC").css("border-color", "#cccccc");
        return true;
    }
}
//验证公司名称
function ValidateGSMC() {
    if ($("#GSMC").val() === "" || $("#GSMC").val() === null) {
        $("#divGSMCTip").css("display", "block");
        $("#divGSMCTip").attr("class", "Warn");
        $("#divGSMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写公司名称啦');
        $("#GSMC").css("border-color", "#F2272D");
        return false;
    } else {
        $("#divGSMCTip").css("display", "none");
        $("#GSMC").css("border-color", "#cccccc");
        return true;
    }
}