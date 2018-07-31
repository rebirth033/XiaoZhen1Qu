$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
});
//验证笔记本类别
function ValidateBJBLB() {
    if (!ValidateSelect("BJBLB", "LB", "请选择类别")) return false;
    //if (!ValidateSelect("BJBLB", "BJBPP", "请选择笔记本品牌")) return false;
    //if (!ValidateSelect("BJBLB", "BJBXH", "请选择笔记本型号")) return false;
    return true;
}
//验证笔记本配件类别
function ValidateBJBPJLB() {
    if (!ValidateSelect("BJBLB", "LB", "请选择类别")) return false;
    //if (!ValidateSelect("BJBLB", "XL", "请选择小类")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if ($("#spanLB").html() === "笔记本") {
        if (ValidateRadio("SF", "忘记选择身份啦")
            & ValidateBJBLB()
            & ValidateSelect("XJCD", "XJ", "请选择新旧")
            & ValidateCheck("PSFS", "忘记选择配送方式啦")
            & ValidateBCMS("BCMS", "忘记填写详情描述啦")
            & ValidateXXDZ()
            & ValidateJG()
            & ValidateCommon())
            return true;
        else
            return false;
    } else {
        if (ValidateRadio("SF", "忘记选择身份啦")
            & ValidateBJBPJLB()
            & ValidateSelect("XJCD", "XJ", "请选择新旧")
            & ValidateCheck("PSFS", "忘记选择配送方式啦")
            & ValidateBCMS("BCMS", "忘记填写详情描述啦")
            & ValidateXXDZ()
            & ValidateJG()
            & ValidateCommon())
            return true;
        else
            return false;
    }
}