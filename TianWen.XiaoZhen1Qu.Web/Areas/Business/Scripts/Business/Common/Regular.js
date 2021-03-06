﻿//手机号验证
function ValidateCellPhone(value) {
    var zz = /^1([358][0-9]|4[579]|66|7[0135678]|9[89])[0-9]{8}$/g;
    if (value.length > 0) {
        return zz.test(value);
    }
    return true;
}

//固话验证
function ValidateTelePhone(value) {
    var zz = /^(0\d{2}-\d{8}(-\d{1,4})?)|(0\d{3}-\d{7,8}(-\d{1,4})?)$/g;
    if (value.length > 0) {
        return zz.test(value);
    }
    return true;
}


//邮箱验证
function ValidateEmail(value) {
    var zz = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+$/g;
    if (value.length > 0) {
        return zz.test(value);
    }
    return true;
}

//汉字验证
function ValidateChinese(value) {
    var zz = /^[\u4E00-\u9FA5]+$/g;
    if (value.length > 0) {
        return zz.test(value);
    }
    return true;
}

//整数验证
function ValidateNumber(value) {
    if (value === "面议")
        return true;
    var zz = /^[\d]+$/g;
    if (value.length > 0) {
        return zz.test(value);
    }
    return true;
}

//一到两位小数的正实数验证
function ValidateDecimal(value) {
    if (value === "面议")
        return true;
    var zz = /^[0-9]+(.[0-9]{1,2})?$/g;
    if (value.length > 0) {
        return zz.test(value);
    }
    return true;
}

//一位小数的正实数验证
function ValidateDecimalOne(value) {
    if (value === "面议")
        return true;
    var zz = /^[0-9]+(.[0-9]{1})?$/g;
    if (value.length > 0) {
        return zz.test(value);
    }
    return true;
}

//车牌号验证
function ValidateCPH(value) {
    var zz = /^[京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领A-Z]{1}[A-Z]{1}[A-Z0-9]{4}[A-Z0-9挂学警港澳]{1}$/g;
    if (value.length > 0) {
        return zz.test(value);
    }
    return true;
}

//充值金额验证
function ValidateCZJE(value) {
    var zz = /^[\d]+$/g;
    if (value.length > 0) {
        return zz.test(value);
    }
    return true;
}