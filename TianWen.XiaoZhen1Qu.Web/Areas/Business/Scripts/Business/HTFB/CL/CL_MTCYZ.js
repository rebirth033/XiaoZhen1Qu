$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
    $("#divXSQK").find(".div_radio").bind("click", function () { ValidateRadio("XSQK", "忘记选择行驶情况啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证所有
function ValidateAll() {
    if (ValidateRadio("SF", "忘记选择身份啦")
            & ValidateCheck("CX", "忘记选择车型啦")
            & ValidateCheck("PP", "忘记选择品牌啦")
            & ValidateSelect("XJCD", "XJ", "忘记选择新旧啦")
            & ValidateBCMS("BCMS", "忘记填写详情描述啦")
            & ValidateXXDZ()
            & ValidateJG()
            & ValidateCommon())
        return true;
    else
        return false;
}