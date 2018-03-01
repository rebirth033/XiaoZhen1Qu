$(document).ready(function() {
    $("#divZPJZYXQ").find(".div_radio").bind("click", function () { ValidateRadio("ZPJZYXQ", "忘记选择兼职有效期啦"); });
    $("#ZPRS").bind("blur", ValidateZPRS);
    $("#ZPRS").bind("focus", InfoZPRS);
    $("#XZ").bind("blur", ValidateXZSP);
    $("#XZ").bind("focus", InfoXZ);
});
//验证兼职时间
function ValidateJZSJ() {
    if (GetJZSJ() === "") {
        $("#divZPJZSJTip").css("display", "block");
        $("#divZPJZSJTip").attr("class", "Warn");
        $("#divZPJZSJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记选择兼职时间啦');
        return false;
    } else {
        $("#divZPJZSJTip").css("display", "none");
        return true;
    }
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
        & ValidateJZSJ() 
        & ValidateXZSP()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")
        & ValidateXXDZ()
        & ValidateInput("BT", "标题")& ValidateInput("LXDH", "联系电话"))
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
        $("#spanZPRS").css("border-color", "#F2272D");
        return false;
    } else {
        $("#divZPRSTip").css("display", "none");
        $("#spanZPRS").css("border-color", "#cccccc");
        return true;
    }
}
//验证薪资
function ValidateXZ() {
    if ($("#XZ").val() === "" || $("#XZ").val() === null) {
        $("#divZPXZSPTip").css("display", "block");
        $("#divZPXZSPTip").attr("class", "Warn");
        $("#divZPXZSPTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写薪资啦');
        $("#XZ").css("border-color", "#F2272D");
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
    $("#divZPRSTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写招聘人数');
    $("#spanZPRS").css("border-color", "#bc6ba6");
}
//提示薪资
function InfoXZ() {
    $("#divZPXZSPTip").css("display", "block");
    $("#divZPXZSPTip").attr("class", "Info");
    $("#divZPXZSPTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#XZ").css("border-color", "#bc6ba6");
}