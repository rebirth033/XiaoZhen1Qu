$(document).ready(function () {
    $("#divXB").find(".div_radio").bind("click", function () { ValidateRadio("XB", ""); });
    $("#divDYLX").find(".div_radio").bind("click", function () { ValidateRadio("DYLX", ""); });
    $("#XM").bind("blur", function () { ValidateInput("XM", "姓名"); });
    $("#XM").bind("focus", function () { InfoInput("XM", "请填写姓名"); });
    $("#NL").bind("blur", function () { ValidateInput("NL", "年龄"); });
    $("#NL").bind("focus", function () { InfoInput("NL", "请填写年龄"); });
});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择类别啦")) return false;
    if ($("#spanLB").html() === "星级酒店") {
        if (!ValidateCheck("XL", "忘记选择小类啦")) return false;
    }
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateInput("XM", "姓名")
        & ValidateRadio("XB", "性别")
        & ValidateInput("NL", "年龄")
        & ValidateRadio("DYLX", "导游类型")
        & ValidateCheck("DYYZ", "导游语种")
        & ValidateSelect("DYDDRXL", "XL", "忘记选择学历啦")
        & ValidateSelect("DYDDRDTJY", "DTJY", "忘记选择带团经验啦")

        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}