﻿$(document).ready(function () {

});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择类别啦")) return false;
    //if ($("#spanLB").html() !== "酒店管理" && $("#spanLB").html() !== "工程管理" && $("#spanLB").html() !== "素质拓展") {
    //    if (!ValidateCheck("XL", "忘记选择小类啦")) return false;
    //}
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateCheck("CD", "忘记选择场地啦")
        & ValidateCheck("FWFW", "忘记选择服务范围啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}