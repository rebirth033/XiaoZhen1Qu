$(document).ready(function () {
    $("#divOUTLB").find(".div_radio").bind("click", function () { ValidateRadio("OUTLB", "忘记选择类别啦"); });
});
//类别
function ValidateOther() {
    if ($("#spanLB").html() === "洗车") {
        if (ValidateSelect("QCMRZSXCDD", "XCDD", "忘记选择洗车地点啦") & ValidateSelect("QCMRZSXCFS", "XCFS", "忘记选择洗车方式啦")) return true;
        return false;
    }
    else if ($("#spanLB").html() === "打蜡") {
        if (ValidateSelect("QCMRZSPP", "PP", "忘记选择品牌啦") & ValidateSelect("QCMRZSPZ", "PZ", "忘记选择品种啦")) return true;
        return false;
    }
    else if ($("#spanLB").html() === "玻璃贴膜") {
        if (ValidateSelect("QCMRZSPP", "PP", "忘记选择品牌啦") & ValidateSelect("QCMRZSTMFW", "TMFW", "忘记选择贴膜范围啦")) return true;
        return false;
    }
    else if ($("#spanLB").html() === "镀膜" || $("#spanLB").html() === "封釉" || $("#spanLB").html() === "座椅包真皮" || $("#spanLB").html() === "底盘装甲") {
        if (ValidateSelect("QCMRZSPP", "PP", "忘记选择品牌啦")) return true;
        return false;
    }
    else {
        return true;
    }
}
//验证所有
function ValidateAll() {
    if (ValidateSelect("OUTLB", "LB", "忘记选择类别啦")
        & ValidateOther()
        & ValidateJG()
        & ValidateFWQY()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}