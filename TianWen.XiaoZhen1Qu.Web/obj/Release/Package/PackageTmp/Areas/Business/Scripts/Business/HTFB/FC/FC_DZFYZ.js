$(document).ready(function () {
    //sfbz.addListener("focus", function (type, event) { InfoBCMS("SFBZ", "请填写收费标准"); });
    //sfbz.addListener("blur", function (type, event) { ValidateBCMS("SFBZ", "忘记填写收费标准啦"); });
    $("#ZJ").bind("blur", ValidateZJ);
    $("#ZJ").bind("focus", InfoZJ);
});
//验证所有
function ValidateAll() {
    if (ValidateSelect("FWLX", "FWLX", "请选择房屋类型")
        & ValidateBCMS("BCMS", "忘记填写房源描述啦")
	& ValidateCheck("FKFS", "忘记选择付款方式啦")
	& ValidateZJ() 
        & ValidateXXDZ() 
        & ValidateCommon())
        return true;
    else
        return false;
}
//验证租金
function ValidateZJ() {
    if ($("#ZJ").val() === "" || $("#ZJ").val() === null) {
        $("#divZJTip").css("display", "block");
        $("#divZJTip").attr("class", "Warn");
        $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写租金啦');
        $("#spanZJ").css("border-color", "#F2272D");
        return false;
    } else {
        if (ValidateDecimal($("#ZJ").val())) {
            $("#divZJTip").css("display", "none");
            $("#spanZJ").css("border-color", "#cccccc");
            return true;
        } else {
            $("#divZJTip").css("display", "block");
            $("#divZJTip").attr("class", "Warn");
            $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />租金请填写数字，最多两位小数，默认为面议');
            $("#spanZJ").css("border-color", "#F2272D");
            return false;
        }
    }
}
//提示租金
function InfoZJ() {
    $("#divZJTip").css("display", "block");
    $("#divZJTip").attr("class", "Info");
    $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info_purple.png" class="imgTip" />请填写整数，默认为面议');
    $("#spanZJ").css("border-color", "#bc6ba6");
}