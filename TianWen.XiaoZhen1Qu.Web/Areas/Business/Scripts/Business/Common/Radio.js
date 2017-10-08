//选择单选
function RadioSelect() {
    $(this).parent().find("img").each(function () {
        $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    });
    $(this).find("img").each(function () {
        $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    });
}
//获取单选
function GetDX(type) {
    var value = "";
    $("#div" + type).find("img").each(function () {
        if ($(this).attr("src").indexOf("blue") !== -1)
            value = $(this).parent().find("label")[0].innerHTML;
    });
    return value;
}
//设置单选
function SetDX(type, value) {
    $("#div" + type).find("label").each(function () {
        if ($(this)[0].innerHTML === value)
            $(this).parent().find("img").each(function () {
                $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
            });
    });
}