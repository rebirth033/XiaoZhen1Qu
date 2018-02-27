$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
});
//验证平板类别
function ValidatePBLB() {
    if (!ValidateSelect("PBLB", "LB", "请选择类别")) return false;
    //if (!ValidateSelect("PBLB", "PBPP", "请选择平板品牌")) return false;
    //if (!ValidateSelect("PBLB", "PBXH", "请选择平板型号")) return false;
    return true;
}
//验证平板类别
function ValidatePBPJLB() {
    if (!ValidateSelect("PBLB", "LB", "请选择类别")) return false;
    //if (!ValidateSelect("PBLB", "XL", "请选择小类")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if ($("#spanLB").html() === "平板电脑") {
        if (ValidateRadio("SF", "忘记选择身份啦")
            & ValidatePBLB()
            //& ValidateSelect("XJCD", "XJ", "请选择新旧")
            & ValidateBCMS("BCMS", "忘记填写详情描述啦")
            & ValidateXXDZ()
            & ValidateJG()
            & ValidateCommon())
            return true;
        else
            return false;
    }
    else {
        if (ValidateRadio("SF", "忘记选择身份啦")
            & ValidatePBPJLB()
            //& ValidateSelect("XJCD", "XJ", "请选择新旧")
            & ValidateBCMS("BCMS", "忘记填写详情描述啦")
            & ValidateXXDZ()
            & ValidateJG()
            & ValidateCommon())
            return true;
        else
            return false;
    }
}