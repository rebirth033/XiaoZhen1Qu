$(document).ready(function () {
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});

//验证所有
function ValidateAll() {
    if (ValidateSelect("CWFWLB", "LB", "请填写类别")
        & ValidateJG()
        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateCommon())
        return true;
    else
        return false;
}