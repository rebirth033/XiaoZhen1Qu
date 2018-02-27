$(document).ready(function () {
    $("#divSF").find(".div_radio").bind("click", function () { ValidateRadio("SF", "忘记选择身份啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});
//验证笔记本类别
function ValidateBJBLB() {
    if (!ValidateSelect("BJBLB", "LB", "请选择类别")) return false;
    if (!ValidateSelect("BJBLB", "BJBPP", "请选择笔记本品牌")) return false;
    if (!ValidateSelect("BJBLB", "BJBXH", "请选择笔记本型号")) return false;
    return true;
}
//验证笔记本配件类别
function ValidateBJBPJLB() {
    if (!ValidateSelect("BJBLB", "LB", "请选择类别")) return false;
    if (!ValidateSelect("BJBLB", "XL", "请选择小类")) return false;
    return true;
}
//验证所有
function ValidateAll() {
    if ($("#spanLB").html() === "笔记本") {
        if (ValidateRadio("SF", "忘记选择身份啦")
            & ValidateBJBLB()
            & ValidateSelect("XJCD", "XJ", "请选择新旧")
            & ValidateBCMS("BCMS", "忘记填写详情描述啦")
            & ValidateXXDZ()
            & ValidateJG()
            & ValidateCommon())
            return true;
        else
            return false;
    } else {
        if (ValidateRadio("SF", "忘记选择身份啦")
            & ValidateBJBPJLB()
            & ValidateSelect("XJCD", "XJ", "请选择新旧")
            & ValidateBCMS("BCMS", "忘记填写详情描述啦")
            & ValidateXXDZ()
            & ValidateJG()
            & ValidateCommon())
            return true;
        else
            return false;
    }
}
//验证售价
function ValidateJG() {
    if ($("#JG").val() === "" || $("#JG").val() === null) {
        $("#divJGTip").css("display", "block");
        $("#divJGTip").attr("class", "Warn");
        $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写价格啦');
        $("#spanJG").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateNumber($("#JG").val())) {
            $("#divJGTip").css("display", "none");
            $("#spanJG").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divJGTip").css("display", "block");
            $("#divJGTip").attr("class", "Warn");
            $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />价格请填写整数，默认为面议');
            $("#spanJG").css("border-color", "#F2272D");
            return false;
        }
    }
}
//提示价格
function InfoJG() {
    $("#divJGTip").css("display", "block");
    $("#divJGTip").attr("class", "Info");
    $("#divJGTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanJG").css("border-color", "#bc6ba6");
}
