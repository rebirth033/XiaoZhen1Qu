$(document).ready(function () {

});
//类别
function ValidateLB() {
    if (!ValidateSelect("OUTLB", "LB", "忘记选择类别啦")) return false;
    if ($("#spanLB").html() === "灯箱/招牌") {
        if (ValidateCheck("XL", "忘记选择小类啦") & ValidateSelect("PHZPCZ", "CZ", "忘记选择材质啦") & ValidateSelect("PHZPGY", "GY", "忘记选择工艺啦") & ValidateSelect("PHZPSFFG", "SFFG", "忘记选择是否发光啦")) return true;
        else return false;
    }
    else if ($("#spanLB").html() === "标牌") {
        if (ValidateSelect("PHZPCZ", "CZ", "忘记选择材质啦") & ValidateSelect("PHZPYT", "YT", "忘记选择用途啦") & ValidateSelect("PHZPGN", "GN", "忘记选择功能啦")) return true;
        else return false;
    }
    else {
        if (ValidateCheck("XL", "忘记选择小类啦")) return true;
        else return false;
    }
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateLB()
        & ValidateFWQY()
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