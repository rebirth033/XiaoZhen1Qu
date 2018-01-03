$(document).ready(function () {
    $("#ZPRS").bind("blur", function () { ValidateSpanInput("ZPRS", "招聘人数"); });
    $("#ZPRS").bind("focus", function () { InfoSpanInput("ZPRS", "招聘人数请填写整数，不能是0", "ZPRS"); });
    $("#GSMC").bind("blur", function () { ValidateInput("GSMC", "公司名称"); });
    $("#GSMC").bind("focus", function () { InfoInput("GSMC", "公司名称字数不超过100"); });
});
//验证所有
function ValidateAll() {
    if (ValidateSelect("ZWMC", "ZWMC", "忘记选择职位名称啦")
        & ValidateSpanInput("ZPRS", "招聘人数")
        & ValidateInput("GSMC", "公司名称")
        & ValidateSelect("ZPMYXZ", "MYXZ", "忘记选择每月薪资啦")
        & ValidateSelect("ZPXLYQ", "XLYQ", "忘记选择学历要求啦")
        & ValidateSelect("ZPGZNX", "GZNX", "忘记选择工作年限啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateCommonWithoutZP())
        return true;
    else
        return false;
}