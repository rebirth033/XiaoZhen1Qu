$(document).ready(function () {

});
//验证所有
function ValidateAll() {
    if (ValidateSelect("ZPZWLB", "ZWLB", "忘记选择职位类别啦")
        & ValidateSelect("ZPMYXZ", "MYXZ", "忘记选择每月薪资啦")
        & ValidateSelect("ZPXLYQ", "XLYQ", "忘记选择学历要求啦")
        & ValidateSelect("ZPGZNX", "GZNX", "忘记选择工作年限啦")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateCommon())
        return true;
    else
        return false;
}