$(document).ready(function () {
    $("#ZPRS").bind("blur", function () { ValidateSpanInput("ZPRS", "招聘人数"); });
    $("#ZPRS").bind("focus", function () { InfoSpanInput("ZPRS", "招聘人数请填写整数，不能是0", "ZPRS"); });
});
//验证所有
function ValidateAll() {
    if (ValidateSelect("ZPZWLB", "ZWLB", "忘记选择职位类别啦")
        & ValidateSpanInput("ZPRS", "招聘人数")
        & ValidateSelect("ZPMYXZ", "MYXZ", "忘记选择每月薪资啦")
        & ValidateSelect("ZPXLYQ", "XLYQ", "忘记选择学历要求啦")
        & ValidateSelect("ZPGZNX", "GZNX", "忘记选择工作年限啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateInput("LXR", "联系人") & ValidateInput("LXDH", "联系电话"))
        return true;
    else
        return false;
}