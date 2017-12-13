$(document).ready(function() {
    $("#divZPJZYXQ").find(".div_radio").bind("click", function() { ValidateRadio("ZPJZYXQ", "忘记选择兼职有效期啦"); });
    $("#DQJZKSSJ").bind("change", function () { ValidateZPDQJZSJ(); });
    $("#DQJZJSSJ").bind("change", function () { ValidateZPDQJZSJ(); });
    $("#ZPRS").bind("blur", ValidateZPRS);
    $("#ZPRS").bind("focus", InfoZPRS);
    $("#XZ").bind("blur", ValidateXZSP);
    $("#XZ").bind("focus", InfoXZ);
});
//验证短期兼职时间
function ValidateZPDQJZSJ() {
    if (!ValidateDQJZKSSJ()) return false;
    if (!ValidateDQJZJSSJ()) return false;
    return true;
}
//验证薪资水平
function ValidateXZSP() {
    if (!ValidateXZ()) return false;
    if (!ValidateSelect("ZPXZSP", "XZDW", "忘记选择薪资单位啦")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if (ValidateSelect("ZPJZLB", "JZLB", "忘记选择兼职类别啦")
        & ValidateZPRS()
        & ValidateRadio("ZPJZYXQ", "忘记选择兼职有效期啦")
        & ValidateZPDQJZSJ()
        & ValidateXZSP()
        & ValidateSelect("ZPXZJS", "XZJS", "忘记选择薪资结算啦")
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateInput("BT", "标题") & ValidateInput("LXR", "联系人") & ValidateInput("LXDH", "联系电话"))
        return true;
    else
        return false;
}
//验证招聘人数
function ValidateZPRS() {
    if ($("#ZPRS").val() === "" || $("#ZPRS").val() === null) {
        $("#divZPRSTip").css("display", "block");
        $("#divZPRSTip").attr("class", "Warn");
        $("#divZPRSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写招聘人数啦');
        $("#spanZPRS").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divZPRSTip").css("display", "none");
        $("#spanZPRS").css("border-color", "#cccccc");
        return true;
    }
}
//验证短期兼职开始时间
function ValidateDQJZKSSJ() {
    if ($("#DQJZKSSJ").val() === "" || $("#DQJZKSSJ").val() === null) {
        $("#divZPDQJZSJTip").css("display", "block");
        $("#divZPDQJZSJTip").attr("class", "Warn");
        $("#divZPDQJZSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写短期兼职开始时间啦');
        $("#DQJZKSSJ").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divDQJZSJTip").css("display", "none");
        $("#DQJZKSSJ").css("border-color", "#cccccc");
        return true;
    }
}
//验证短期兼职结束时间
function ValidateDQJZJSSJ() {
    if ($("#DQJZJSSJ").val() === "" || $("#DQJZJSSJ").val() === null) {
        $("#divZPDQJZSJTip").css("display", "block");
        $("#divZPDQJZSJTip").attr("class", "Warn");
        $("#divZPDQJZSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写短期兼职结束时间啦');
        $("#DQJZJSSJ").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divZPDQJZSJTip").css("display", "none");
        $("#DQJZJSSJ").css("border-color", "#cccccc");
        return true;
    }
}
//验证薪资
function ValidateXZ() {
    if ($("#XZ").val() === "" || $("#XZ").val() === null) {
        $("#divZPXZSPTip").css("display", "block");
        $("#divZPXZSPTip").attr("class", "Warn");
        $("#divZPXZSPTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写薪资啦');
        $("#XZ").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divZPXZSPTip").css("display", "none");
        $("#XZ").css("border-color", "#cccccc");
        return true;
    }
}
//提示招聘人数
function InfoZPRS() {
    $("#divZPRSTip").css("display", "block");
    $("#divZPRSTip").attr("class", "Info");
    $("#divZPRSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写招聘人数');
    $("#spanZPRS").css("border-color", "#ad5b97");
}
//提示薪资
function InfoXZ() {
    $("#divZPXZSPTip").css("display", "block");
    $("#divZPXZSPTip").attr("class", "Info");
    $("#divZPXZSPTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，默认为面议');
    $("#XZ").css("border-color", "#ad5b97");
}