//联系电话验证
function ValidateCellPhone(value) {
    var zz = /^((13[0-9])|(14[5|7])|(15([0-3]|[5-9]))|(18[0,5-9]))\d{8}$/g;
    if (value.length > 0) {
        return zz.test(value);
    }
    return true;
}

//小区名称验证
function ValidateChinese(value) {
    var zz = /^[\u4E00-\u9FA5]+$/g;
    if (value.length > 0) {
        return zz.test(value);
    }
    return true;
}