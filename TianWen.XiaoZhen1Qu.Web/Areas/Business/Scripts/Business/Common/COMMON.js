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
    if (str.charAt(str.length - 1) == ",")
        return str.substring(0, str.length - 1);
    else
        return str;
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
    format = format.replace("hh", dateTime.getHours());
    format = format.replace("mm", dateTime.getMinutes());
    format = format.replace("ss", dateTime.getSeconds());
    format = format.replace("ms", dateTime.getMilliseconds());
    return format;
};