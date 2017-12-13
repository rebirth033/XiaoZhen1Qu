$(document).ready(function () {
    $("#PPMC").bind("blur", ValidatePPMC);
    $("#PPMC").bind("focus", InfoPPMC);
});
//验证所有
function ValidateAll() {
    if (ValidateSelect("LPXSPLB", "LB", "忘记选择类别啦")
        & ValidateCheck("XL", "忘记选择小类啦")
        & ValidatePPMC()
        & ValidateSelect("LPXSPTZJE", "TZJE", "忘记选择投资金额啦")
        & ValidateCheck("ZSDQ", "忘记选择招商地区啦")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
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
//提示品牌名称
function InfoPPMC() {
    $("#divPPMCTip").css("display", "block");
    $("#divPPMCTip").attr("class", "Info");
    $("#divPPMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />不超过30字，不能填写电话、QQ、邮箱等联系方式或特殊符号');
    $("#PPMC").css("border-color", "#ad5b97");
}