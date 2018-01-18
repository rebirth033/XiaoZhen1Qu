$(document).ready(function () {

});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择类别啦")) return false;
    if ($("#spanLB").html().indexOf("空气净化") !== -1 || $("#spanLB").html().indexOf("开荒保洁") !== -1 || $("#spanLB").html().indexOf("物业保洁") !== -1 || $("#spanLB").html().indexOf("沙发清洗") !== -1 || $("#spanLB").html().indexOf("地毯清洗") !== -1 || $("#spanLB").html().indexOf("地板打蜡") !== -1 || $("#spanLB").html().indexOf("石材翻新/养护") !== -1 || $("#spanLB").html().indexOf("除虫除蚁") !== -1 || $("#spanLB").html().indexOf("高空清洗") !== -1) {
        if (!ValidateCheck("XL", "忘记选择小类啦")) return false; 
    }
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateCheck("LB", "忘记选择类别啦")
        & ValidateCheck("FWFW", "忘记选择服务范围啦")
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}