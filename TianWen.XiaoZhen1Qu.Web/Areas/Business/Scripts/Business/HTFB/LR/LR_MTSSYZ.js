$(document).ready(function () {

});
//验证所有
function ValidateAll() {
    if ($("#spanLB").html() === "减肥") {
        if (ValidateSelect("MTSSLB", "LB", "忘记选择类别啦")
            & ValidateSelect("JFFS", "FS", "忘记选择类别啦")
            & ValidateBCMS("BCMS", "忘记填写补充描述啦")
            & ValidateFWFW()
            & ValidateXXDZ()
            & ValidateCommon())
            return true;
        else
            return false;
    }
    else {
        if (ValidateSelect("MTSSLB", "LB", "忘记选择类别啦")
            & ValidateBCMS("BCMS", "忘记填写补充描述啦")
            & ValidateFWFW()
            & ValidateXXDZ()
            & ValidateCommon())
            return true;
        else
            return false;
    }
}