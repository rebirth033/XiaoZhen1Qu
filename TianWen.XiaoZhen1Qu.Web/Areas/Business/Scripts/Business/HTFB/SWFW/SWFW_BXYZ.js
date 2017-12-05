$(document).ready(function () {

});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择类别啦")) return false;
    if ($("#spanLB").html() !== "签证保险" && $("#spanLB").html() !== "汽车保险") {
        if (!ValidateSelect("OUTLB", "XL", "忘记选择小类啦")) return false;
    }
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommonWithoutZP())
        return true;
    else
        return false;
}