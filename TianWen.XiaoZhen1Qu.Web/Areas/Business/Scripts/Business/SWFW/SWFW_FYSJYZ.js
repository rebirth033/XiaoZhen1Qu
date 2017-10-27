$(document).ready(function () {

});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择服务项目啦")) return false;
    if ($("#spanLB").html() === "口译" || $("#spanLB").html() === "本地化" || $("#spanLB").html() === "速记") {
        if (!ValidateCheck("XL", "忘记选择类型啦")) return false;
    }
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateSelect("FYSJYZ", "YZ", "忘记选择语种啦")
        & ValidateFWQY()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}