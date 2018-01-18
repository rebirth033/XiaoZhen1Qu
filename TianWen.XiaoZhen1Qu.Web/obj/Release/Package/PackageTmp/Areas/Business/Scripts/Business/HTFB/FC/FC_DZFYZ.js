$(document).ready(function () {
    //sfbz.addListener("focus", function (type, event) { InfoBCMS("SFBZ", "请填写收费标准"); });
    //sfbz.addListener("blur", function (type, event) { ValidateBCMS("SFBZ", "忘记填写收费标准啦"); });
});
//验证所有
function ValidateAll() {
    if (ValidateSelect("FWLX", "FWLX", "请选择房屋类型")
        & ValidateBCMS("BCMS", "忘记填写房源描述啦")
        & ValidateCommon())
        return true;
    else
        return false;
}