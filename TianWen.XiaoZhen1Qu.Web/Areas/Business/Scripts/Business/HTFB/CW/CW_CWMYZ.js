﻿$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", function () { ValidateRadio("GQ", "忘记选择供求啦"); });
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});

//验证所有
function ValidateAll() {
    if (ValidateRadio("GQ", "忘记选择供求啦")
        & ValidateSelect("CWMPZ", "PZ", "请选择品种")
        & ValidateJG()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateCommon())
        return true;
    else
        return false;
}