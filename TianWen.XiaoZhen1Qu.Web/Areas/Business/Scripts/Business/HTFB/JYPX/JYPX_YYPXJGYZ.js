$(document).ready(function () {

});

//验证所有
function ValidateAll() {
    if (ValidateSelect("YYPXYZ", "YZ", "忘记选择语种啦")
        & ValidateCheck("XL", "忘记选择小类啦")

        & ValidateBCMS("BCMS", "忘记填写补充描述啦")
        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}