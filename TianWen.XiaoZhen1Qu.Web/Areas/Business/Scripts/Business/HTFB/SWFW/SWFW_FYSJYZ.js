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
        & ValidateFWFW()
        & ValidateBCMS("BCMS", "忘记填写服务介绍啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证服务介绍
function ValidateBCMS(id, message) {
    if (ue.getContent() === "" || ue.getContent() === null) {
        $("#div" + id + "Tip").css("display", "block");
        $("#div" + id + "Tip").attr("class", "Warn");
        $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写服务介绍啦');
        $("#edui1").css("border-color", "#F2272D");
        return false;
    } else {
        $("#div" + id + "Tip").css("display", "none");
        return true;
    }
}
//提示服务介绍
function InfoBCMS(id, message) {
    $("#div" + id + "Tip").css("display", "block");
    $("#div" + id + "Tip").attr("class", "Info");
    $("#div" + id + "Tip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写服务介绍');
    $("#edui1").css("border-color", "#bc6ba6");
}