$(document).ready(function () {

});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择类别啦")) return false;
    //if ($("#spanLB").html() === "球类" || $("#spanLB").html() === "瑜伽" || $("#spanLB").html() === "武术" || $("#spanLB").html() === "棋类") {
    //    if (!ValidateCheck("XL", "忘记选择小类啦")) return false;
    //}
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateCheck("DX", "忘记选择对象啦")
        & ValidateCheck("FWFW", "忘记选择服务范围啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}