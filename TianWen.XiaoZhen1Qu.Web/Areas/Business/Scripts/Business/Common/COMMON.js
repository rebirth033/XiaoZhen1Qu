//js获取网站根路径(站点及虚拟目录)，获得网站的根目录或虚拟目录的根地址     
function getRootPath() {
    var strFullPath = window.document.location.href;
    var strPath = window.document.location.pathname;

    var pos = strFullPath.indexOf(strPath);
    var prePath = strFullPath.substring(0, pos);
    var postPath = strPath.substring(0, strPath.substr(1).indexOf('/') + 1);

    return (prePath + postPath);
}

//获取对象的文件路径
function getFilePath(obj) { //参数obj为input file对象
    if (obj) {
        if (window.navigator.userAgent.indexOf("MSIE") >= 1) {
            obj.select();
            return document.selection.createRange().text;
        } else if (window.navigator.userAgent.indexOf("Firefox") >= 1) {
            if (obj.files) {
                return obj.files.item(0).getAsDataURL();
            }
            return obj.value;
        }
        return obj.value;
    }
}

//获得窗体宽度
function pageWidth() {
    return window.innerWidth != null ? window.innerWidth : document.documentElement && document.documentElement.clientWidth ? document.documentElement.clientWidth : document.body != null ? document.body.clientWidth : null;
}
//获得窗体高度
function pageHeight() {
    return window.innerHeight != null ? window.innerHeight : document.documentElement && document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body != null ? document.body.clientHeight : null;
}

//移除字串末尾的逗号
function RTrim(str) {
    if (str.charAt(str.length - 1) === ',')
        return str.substring(0, str.length - 1);
    else
        return str;
}

//移除字串末尾指定字符
function RTrim(str, char) {
    if (str.charAt(str.length - 1) === char)
        return str.substring(0, str.length - 1);
    else
        return str;
}

//移除字串末尾指定字符
function LTrim(str, char) {
    if (str.charAt(0) === char)
        return str.substring(1, str.length);
    else
        return str;
}

//移除字串末尾指定字符串
function RTrimStr(str, strchar) {
    var arr = strchar.split(',');
    var value = str;
    for (var i = 0; i < arr.length; i++) {
        if (str.indexOf(arr[i]) !== -1) {
            value = str.substring(0, str.length - arr[i].length);
            break;
        }
    }
    return value;
}

//将字符串内容倒序输出
function reverseStr(olds) {
    var ss = "";
    for (var i = olds.length - 1; i >= 0; i--) {
        ss = ss + olds.substring(i, i + 1);
    }
    return ss;
}

//获取查询字符串
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null)
        return unescape(r[2]);
    return null;
}

//方法:Array.remove(dx) 功能:删除数组元素. 参数:dx删除元素的下标. 返回:在原数组上修改数组 
Array.prototype.remove = function (dx) {
    if (isNaN(dx) || dx > this.length) { return false; }
    for (var i = 0, n = 0; i < this.length; i++) {
        if (this[i] != this[dx]) {
            this[n++] = this[i];
        }
    }
    this.length -= 1;
}

//判断数组是否包含某元素
Array.prototype.contains = function (needle) {
    for (i in this) {
        if (this[i] == needle) return true;
    }
    return false;
}

//查找指定数值在数组中的下标
function findIndexInArray(value, arr) {
    for (var i = 0; i <= arr.length - 1; i++) {
        if (arr[i] == value) {
            return i;
        }
    }
    return -1;
}

//获取url中的参数
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}

//往往json传过来的时间都是"/Date(1405056837780)/",转换需要的方法
String.prototype.ToString = function (format) {
    var dateTime = new Date(parseInt(this.substring(6, this.length - 2)));
    format = format.replace("yyyy", dateTime.getFullYear());
    format = format.replace("yy", dateTime.getFullYear().toString().substr(2));
    format = format.replace("MM", dateTime.getMonth() + 1);
    format = format.replace("dd", dateTime.getDate());
    format = format.replace("hh", p(dateTime.getHours()));
    format = format.replace("mm", p(dateTime.getMinutes()));
    format = format.replace("ss", p(dateTime.getSeconds()));
    format = format.replace("ms", dateTime.getMilliseconds());
    return format;
};

//创建补0函数
function p(s) {
    return s < 10 ? '0' + s : s;
}

function HTMLEncode(str) {
    var s = "";
    if (str.length === 0) return "";
    s = str.replace(/&/g, "&");
    s = s.replace(/</g, "<");
    s = s.replace(/>/g, ">");
    s = s.replace(/ /g, " ");
    s = s.replace(/\'/g, "'");
    s = s.replace(/\"/g, "\"");
    return s;
}

function HTMLDecode(str) {
    var s = "";
    if (str.length === 0) return "";
    s = str.replace(/&/g, "&");
    s = s.replace(/</g, "<");
    s = s.replace(/>/g, ">");
    s = s.replace(/ /g, " ");
    s = s.replace(/'/g, "\'");
    s = s.replace(/"/g, "\"");
    return s;
}
//获取当前日期，到天
function getNowFormatDate(date) {
    var seperator1 = "-";
    var year = date.getFullYear();
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = year + seperator1 + month + seperator1 + strDate;
    return currentdate;
}

function GetPhotoUrls() {
    var photourls = "";
    $(".ulImgs").find("img").each(function () {
        var src = $(this).attr("src");
        if (src.indexOf('?') !== -1)
            photourls += src.substr(0, src.indexOf('?')) + ",";
        else
            photourls += src + ",";
    });
    return RTrim(photourls, ",");
}

//显示用户菜单
function ShowYHCD() {
    $("#div_top_right_dropdown_yhm").css("display", "block");
    $("#span_top_right_yhm_img").css("background-image", 'url(' + getRootPath() + "/Areas/Business/Css/images/arrow_up.png" + ')');
}
//隐藏用户菜单
function HideYHCD() {
    $("#div_top_right_dropdown_yhm").css("display", "none");
    $("#span_top_right_yhm_img").css("background-image", 'url(' + getRootPath() + "/Areas/Business/Css/images/arrow_down.png" + ')');
}
//重选类别
function CXLB() {
    window.location.href = getRootPath() + "/Business/LBXZ/LBXZ";
}
//关闭
function Close(id) {
    $("#div" + id).css("display", "none");
    LeaveStyle(id);
}
//Transition结束监听事件
function whichTransitionEvent() {
    var t;
    var el = document.createElement('fakeelement');
    var transitions = {
        'transition': 'transitionend',
        'OTransition': 'oTransitionEnd',
        'MozTransition': 'transitionend',
        'WebkitTransition': 'webkitTransitionEnd',
        'MsTransition': 'msTransitionEnd'
    }

    for (t in transitions) {
        if (el.style[t] !== undefined) {
            return transitions[t];
        }
    }
}

//打开详细页面
function OpenXXXX(TYPE, ID) {
    window.open(getRootPath() + "/Business/" + TYPE.split('_')[0] + "/" + TYPE + "?ID=" + ID);
}

//字符串截断
function TruncStr(value, length) {
    return value.length > length ? (value.substr(0, length) + '...') : value;
}