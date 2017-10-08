//选择多选
function SelectDuoX(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取多选
function GetDuoX(type) {
    var value = "";
    $(".li" + type).each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            value += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(value, ',');
}
//设置多选
function SetDuoX(type, lbs) {
    var lbarray = lbs.split(',');
    for (var i = 0; i < lbarray.length; i++) {
        $(".li" + type).each(function () {
            if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
        });
    }
}