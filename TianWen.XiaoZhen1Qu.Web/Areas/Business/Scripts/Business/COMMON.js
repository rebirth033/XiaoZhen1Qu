//js获取网站根路径(站点及虚拟目录)，获得网站的根目录或虚拟目录的根地址     
function getRootPath() {
    var strFullPath = window.document.location.href;
    var strPath = window.document.location.pathname;

    var pos = strFullPath.indexOf(strPath);
    var prePath = strFullPath.substring(0, pos);
    var postPath = strPath.substring(0, strPath.substr(1).indexOf('/') + 1);

    return (prePath + postPath);
}

//js获取网站根路径(站点及虚拟目录)，获得网站的根目录或虚拟目录的根地址   
function getRootPath2() {
    var pathName = window.location.pathname.substring(1);
    var webName = pathName == "" ? "" : pathName.substring(0, pathName.indexOf('/'));
    return window.location.protocol + '//' + window.location.host + '/' + webName;
}

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
//颜色处理函数
var hexch = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"];
var hexStr = "0123456789ABCDEF";
function ToHex(n) {
    var h, l;
    n = Math.round(n);
    l = n % 16;
    h = Math.floor((n / 16)) % 16;
    return (hexch[h] + hexch[l]);
}
function RGB2Color(r, g, b) {
    return ('#' + ToHex(r) + ToHex(g) + ToHex(b));
}

function Color2RGB(strhex) {
    var r, g, b;
    r = hexStr.indexOf(strhex.charAt(1)) * 16 + hexStr.indexOf(strhex.charAt(2));
    g = hexStr.indexOf(strhex.charAt(3)) * 16 + hexStr.indexOf(strhex.charAt(4));
    b = hexStr.indexOf(strhex.charAt(5)) * 16 + hexStr.indexOf(strhex.charAt(6));
    return (r + "," + g + "," + b)
}
//********************************************

//动态提交FORM
function exportToExcel(url, data) {
    var openWindow = window.open("", "newwin", "height=250, width=250,toolbar=no ,scrollbars=" + scroll + ",menubar=no");
    openWindow.document.write("</div><form id='formCommon' target='_blank' action='" + url + "' method='post'>" +
        "<input type='hidden' name='hideData' value='" + data + "'></input>" +
        "</form><script>document.getElementById('formCommon').submit();</script>");
}

//************************************************************右键菜单******************************

//显示右键弹出菜单
function showMenu(id) {
    var x = 0;
    var y = 0;

    x = window.event.clientX;
    y = window.event.clientY;

    var o = document.getElementById(id);
    o.style.left = x;
    o.style.top = y;
    o.style.display = "block";
}
//隐藏右键菜单
function hideMenu(id) {
    var o = document.getElementById(id);
    o.style.display = "none";
}
//************************************************************右键菜单结束******************************   
//屏蔽页面F5刷新
function disableF5() {
    if (event.keyCode == 116) //屏蔽F5刷新键   
    {
        window.event.keyCode = 0;
        return false;
    }
    return true;
}
//通用为对象绑定事件
function addEvent(el, type, handler, flag) {
    if (el.attachEvent) {
        //ie
        el.attachEvent("on" + type, handler);
    }
    else if (el.addEventListener) {
        //firefox
        flag = flag == undefined ? false : flag;
        el.addEventListener(type, handler, flag);
    }
}
function removeEvent(el, type, handler, flag) {
    if (el.detachEvent) {
        //ie
        el.detachEvent("on" + type, handler);
    }
    else if (el.removeEventListener) {
        //ff
        flag = flag == undefined ? false : flag;
        el.removeEventListener(type, handler, flag);
    }
}

//将单引号替换成两个单引号
function replacequote(theform) {
    var a = theform.elements;
    for (var i = 0; i < a.length; i++) {
        if (a[i].type == "text" && a[i].value != "")
            a[i].value = a[i].value.replace(/\'/g, "\"");
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

/// <summary>获取界面的CheckBoxList的Value,各值间使用逗号区隔</summary>
/// <param name="chklID">CheckBoxList的ID</param>
/// <param name="delimeter"></param>
function getChklValue(chklID, addQuotes) {
    //在JS端调用CheckBoxList
    var chkObject = document.getElementById(chklID);
    var chkInput = chkObject.getElementsByTagName("INPUT");
    var arrListValue = chkObject.ListValue.split(',');
    var count = arrListValue.length;
    var strCheckChecked = "";
    var arrCheckChecked;
    var chkValue = "";

    //循环把所有Item的选中状态按0、1标志，存入一个变量，
    //最后再根据这个标志来决定checkboxlist中要取的值        
    for (var i = 0; i < chkInput.length; i++) {
        if (chkInput[i].checked) {
            strCheckChecked = strCheckChecked + "1" + ",";
        }
        else {
            strCheckChecked = strCheckChecked + "0" + ",";
        }
    }
    arrCheckChecked = RTrim(strCheckChecked).split(',');
    for (var j = 0; j < count; j++) {
        if (arrCheckChecked[j] == "1") {
            if (addQuotes == "Y") {
                chkValue += "'" + arrListValue[j] + "',";
            }
            else {
                chkValue += arrListValue[j] + ",";
            }
        }
    }
    chkValue = RTrim(chkValue);
    return chkValue;
    alert(chkValue);
}
//移除字串末尾的逗号
function RTrim(str) {
    if (str.charAt(str.length - 1) == ",")
        return str.substring(0, str.length - 1);
    else
        return str;
}
/// <summary>获取界面的RadioButtonList的Value,各值间使用逗号区隔</summary>
/// <param name="chklID">CheckBoxList的ID</param>
/// <param name="delimeter"></param>
function getRblValue(rblID, addQuotes) {
    //在JS端调用RadioButtonList
    var rblObject = document.getElementById(rblID);
    var radioInput = rblObject.getElementsByTagName("INPUT");
    var radioValue = '';

    //循环取每个radio的checked   
    for (var i = 0; i < radioInput.length; i++) {
        if (radioInput[i].checked) {
            if (addQuotes == "Y") {
                radioValue = "'" + radioInput[i].value + "'";
            }
            else {
                radioValue = radioInput[i].value;
            }
            break;
        }
    }
    return radioValue;
}

function getTextAreaValue(txtID, addQuotes) {
    var txtObject = document.getElementById(txtID);
    var txtValueString = txtObject.innerHTML;
    var arrayText = txtValueString.split("\r\n");
    var txtValue = "";

    for (var index = 0; index <= arrayText.length - 1; index++) {
        if (addQuotes == "Y") {
            txtValue += "'" + arrayText[index] + "',";
        }
        else {
            txtValue += arrayText[index] + ",";
        }
    }
    txtValue = RTrim(txtValue);
    return txtValue;
}

//获取系统当前时间,返回值的格式:  hh:mi:ss
function getNowTime(connector) {
    if (connector == null) {
        var connnector;
        connector = ":";
    }
    var t;
    //获得系统当前时间   
    t = new Date();
    var s;
    //获得时 
    s = t.getHours() + connector;
    //获得分   
    s += t.getMinutes() < 10 ? "0" + t.getMinutes() : t.getMinutes();
    s += connector;
    s += t.getSeconds() < 10 ? "0" + t.getSeconds() : t.getSeconds();
    return s;
}

//获取系统当前日期格式: yyyy-mm-dd
function getNowDate(connector) {
    var now = new Date();

    return now.getFullYear() + connector + (now.getMonth() + 1 > 9 ? (now.getMonth() + 1) : '0' + (now.getMonth() + 1)) + connector + (now.getDate().toString().length == 1 ? "0" + now.getDate() : now.getDate());
}

//取得对象的左侧位置
function GetElementLeftSubscribe(obj, positionNum) {

    var x = obj.offsetLeft;
    while (obj = obj.offsetParent) x += obj.offsetLeft;
    return x;
}
//取得对象的底部位置
function GetElementBottomSubscribe(obj, positionNum) {
    var y = obj.offsetTop;
    var theight = obj.offsetHeight;
    //    theight = 0;
    while (obj = obj.offsetParent) y += obj.offsetTop;
    if (document.all) {
        if (typeof (positionNum) != 'undefined') {
            return y + positionNum + theight;
        } else {
            return y + theight;
        }
    }
    else {
        if (typeof (positionNum) != 'undefined') {

            return (y + positionNum + theight);// + "px";
        } else {
            return (y + theight);// + "px";
        }
    }
}

//显示弹出层
function popShow(sourceId, popDivId) {

    var obj = document.getElementById(sourceId);
    var left = GetElementLeftSubscribe(obj, 0);
    var bottom = GetElementBottomSubscribe(obj, 0);


    var objHeight = $("#" + popDivId).css("height").replace(/px/g, '');
    var objWidth = $("#" + popDivId).css("width").replace(/px/g, '');

    if ((objHeight * 1 + bottom * 1 + 15) > document.body.clientHeight) {
        $("#" + popDivId).css("top", document.body.clientHeight - 15 - objHeight * 1);
    } else {
        $("#" + popDivId).css("top", bottom + 5);
    }

    if ((objWidth * 1 + left * 1 + 20) > document.body.clientWidth) {
        $("#" + popDivId).css("left", left - (objWidth * 1 + left * 1 + 20) + document.body.clientWidth);
    } else {
        $("#" + popDivId).css("left", left - 0);
    }

    $("#" + popDivId).show();

}

function popShowWorkBox(sourceId, popDivId) {

    var obj = document.getElementById(sourceId);
    var left = GetElementLeftSubscribe(obj, 0);
    var bottom = GetElementBottomSubscribe(obj, 0);



    $("#" + popDivId).css("top", bottom + 5);
    $("#" + popDivId).css("left", left - 0);
    $("#" + popDivId).show();

}
//隐藏弹出层
function popHide(popDivId) {
    $("#" + popDivId).hide();
}

function addPopDiv() {
    var divPop = document.getElementById("divPop");
    if (divPop == null) {
        divPop = document.createElement("div");
        divPop.id = "divPop";
        divPop.className = "teacherSet";
        divPop.innerHTML = "<div class=\"border\">" +
                "<div id=\"areaListSubscribe\" class=\"content\" style=\"height: 150px;\"></div>" +
                "<div class=\"btns\">" +
                        "<span class=\"btn\"><span>" +
                        "    <button id=\"Button2\" onclick=\"getGKAreaSubscribe(this)\">" +
                        "        确定</button></span></span> <span class=\"btn2\"><span>" +
                        "            <button id=\"Button3\" onclick=\"closeGKAreaPopSubscribe()\">" +
                        "                取消</button></span></span>" +
                    "</div>" +
                "</div>";
        divPop.style.display = "none";
        document.body.appendChild(divPop);
    }
}

//全选弹出层里面的checkboxlist
function popSelectAll(id) {
    checkAll(id);
}

//全选弹出层里面的checkboxlist
function popUnSelectAll(id) {
    UnCheckAll(id);
}

/// <summary>全选界面的CheckBoxList</summary>
/// <param name="chklID">CheckBoxList的ID</param>
function checkAll(chklID) {
    var chkObject = document.getElementById(chklID);
    var chkInput = chkObject.getElementsByTagName("INPUT");

    for (var i = 0; i < chkInput.length; i++) {
        chkInput[i].checked = true;
    }
}

/// <summary>全不选界面的CheckBoxList</summary>
/// <param name="chklID">CheckBoxList的ID</param>
function UnCheckAll(chklID) {
    var chkObject = document.getElementById(chklID);
    var chkInput = chkObject.getElementsByTagName("INPUT");

    for (var i = 0; i < chkInput.length; i++) {
        chkInput[i].checked = false;
    }
}

/// <summary>使用json填充下拉框</summary>
/// <param name="controlID">下拉框ID</param>
/// <param name="json">数据: 格式{rows:[{value:1,text:1},{value:2,text:2}]}</param>
/// <param name="dataTextField">text字段名</param>
/// <param name="dataValueField">value字段名</param>
/// <param name="isAppend">是否追加</param>
/// <param name="plusOption">是否将请选择加到第一个Option</param>
function fillSelectWithJson(controlID, json, dataTextField, dataValueField, isAppend, plusOption) {

    //检查页面是否存在该对象
    if ($("#" + controlID) == null) {
        $.messager.alert('提示', '没有找到id=' + controlID + "的下拉框!", 'error');
        return false;
    }
    //如果不是追加那么要先清空下拉框的内容
    if (isAppend == false) {
        document.getElementById(controlID).options.length = 0;
    }

    var controlTarget = document.getElementById(controlID);
    var tableName = "";
    var bindText = "";
    var bindValue = "";
    var index = 0;
    var values = [];
    var texts = [];

    for (var p in json) {
        tableName = p;
        break;
    }

    if (tableName == "") {
        return false;
    }
    var jsonTable = eval("json." + p);
    if (jsonTable == null) {
        return false;
    }
    //是否追加一个value="'的option
    if (plusOption != undefined && plusOption != null) {
        controlTarget.options.add(new Option(plusOption, ""));
    }

    for (var i = 0; i <= jsonTable.length - 1; i++) {
        bindText = eval("json." + p + "[" + index + "]." + dataTextField);
        bindValue = eval("json." + p + "[" + index + "]." + dataValueField);
        values[index] = bindValue;
        texts[index] = bindText;
        index++;
    }

    for (var i = 0; i <= values.length - 1; i++) {
        var option = new Option(texts[i], values[i]);
        controlTarget.options.add(option); //这个兼容IE与firefox
    }

}


//将服务器序列化后的日期转换为正常格式yyyy-MM-dd
function setServerDateToNormal(value) {
    var jsondate = value;
    value = eval("new " + jsondate.substr(1, jsondate.length - 2)).toLocaleDateString().toString().replace('年', '-').replace('月', '-').replace('日', '').replace(/\//g, '-');

    var arr = value.split('-');
    var year;
    var month;
    var day;
    year = arr[0];
    month = arr[1];
    day = arr[2];
    if (month.length == 1) {
        month = '0' + month;
    }
    if (day.length == 1) {
        day = '0' + day;
    }
    return year + '-' + month + '-' + day;
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

//重置钻进去的窗体的TOP值  -- easyui 页面有异常时专用
function resetWindowTop() {
    $(".panel").each(function () {
        if ($(this).css("top").replace('px', '') < 0) {
            $(this).css("top", "5");
        }
    });
}

//为指定的日期加上 年、月、日、天、时、分、秒,返回长日期(2012-09-24 14:02:01)
function addDate(type, numDay, dtDate) {
    var year = dtDate.substr(0, 4);
    var month = dtDate.substr(5, 2);
    var day = dtDate.substr(8, 2);
    var hour = dtDate.substr(11, 2);
    var minute = dtDate.substr(14, 2);
    var second = dtDate.substr(17, 2);

    var date = new Date(year, month - 1, day, hour, minute, second);
    type = parseInt(type); //类型  
    var lIntval = parseInt(numDay); //间隔 
    switch (type) {
        case 6: //年 
            date.setYear(date.getYear() + lIntval);
            break;
        case 7: //季度 
            date.setMonth(date.getMonth() + (lIntval * 3));
            break;
        case 5: //月 
            date.setMonth(date.getMonth() + lIntval);
            break;
        case 4: //天 
            date.setDate(date.getDate() + lIntval);
            break
        case 3: //时 
            date.setHours(date.getHours() + lIntval);
            break;
        case 2: //分 
            date.setMinutes(date.getMinutes() + lIntval);
            break;
        case 1: //秒 
            date.setSeconds(date.getSeconds() + lIntval);
            break;
        default:
    }

    return date.getFullYear() + '-' +
     ((date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1) : (date.getMonth() + 1)) + '-' +
     (date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate()) + ' ' +
     (date.getHours().toString().length == 1 ? '0' + date.getHours() : date.getHours()) + ':' +
     (date.getMinutes().toString().length == 1 ? '0' + date.getMinutes() : date.getMinutes()) + ':' +
     (date.getSeconds().toString().length == 1 ? '0' + date.getSeconds() : date.getSeconds());
}

//为指定的日期加上 年、月、日、天、时、分、秒,返回短日期(2012-09-24 14:02:01)
function addShortDate(type, numDay, dtDate) {
    var year = dtDate.substr(0, 4);
    var month = dtDate.substr(5, 2);
    var day = dtDate.substr(8, 2);

    var date = new Date(year, month - 1, day);
    type = parseInt(type);  //类型  
    var lIntval = parseInt(numDay); //间隔 

    switch (type) {
        case 6: //年 
            date.setYear(date.getYear() + lIntval)
            break;
        case 7: //季度 
            date.setMonth(date.getMonth() + (lIntval * 3));
            break;
        case 5: //月 
            date.setMonth(date.getMonth() + lIntval);
            break;
        case 4: //天 
            date.setDate(date.getDate() + lIntval);
            //date = new Date(date.getTime()+lIntval*24*60*60*1000);
            //date  =   new   Date(Date.parse(date)   +   (86400000   *   parseInt(NumDay)));
            break;
        case 3: //时 
            date.setHours(date.getHours() + lIntval);
            break;
        case 2: //分 
            date.setMinutes(date.getMinutes() + lIntval);
            break;
        case 1: //秒 
            date.setSeconds(date.getSeconds() + lIntval);
            break;
        default:

    }

    var mStr = new String(date.getMonth() + 1);
    var dStr = new String(date.getDate());
    if (mStr.length == 1) {
        mStr = "0" + mStr;
    }
    if (dStr.length == 1) {
        dStr = "0" + dStr;
    }
    return date.getFullYear() + "-" + mStr + "-" + dStr;

}

/* 
*  方法:Array.remove(dx) 
*  功能:删除数组元素. 
*  参数:dx删除元素的下标. 
*  返回:在原数组上修改数组 
*/
Array.prototype.remove = function (dx) {
    if (isNaN(dx) || dx > this.length) { return false; }
    for (var i = 0, n = 0; i < this.length; i++) {
        if (this[i] != this[dx]) {
            this[n++] = this[i]
        }
    }
    this.length -= 1
}
//  a = ['1','2','3','4','5']; 
//  alert("elements: "+a+"\nLength: "+a.length); 
//  a.remove(0); //删除下标为0的元素 
//  alert("elements: "+a+"\nLength: "+a.length); 
/* 
*  方法:Array.baoremove(dx) 
*  功能:删除数组元素. 
*  参数:dx删除元素的下标. 
*  返回:在原数组上修改数组. 
*/
Array.prototype.baoremove = function (dx) {
    if (isNaN(dx) || dx > this.length) { return false; }
    this.splice(dx, 1);
}
//  b = ['1','2','3','4','5']; 
//  alert("elements: "+b+"\nLength: "+b.length); 
//  b.baoremove(1); //删除下标为1的元素 
//  alert("elements: "+b+"\nLength: "+b.length); 

/// <summary>
/// 将给定的日期加上一定数值的日、周、时、分、秒、月、年
/// </summary>
/// <param name="type">要累加的类型</param>
/// <param name="NumDay">累加的数量</param>
/// <param name="dtDate">开始日期</param>
/// <returns>累加后的日期yyyy-MM-dd</returns>
function DateAdd(type, NumDay, dtDate) {
    var dtTmp = new Date(dtDate);
    if (isNaN(dtTmp)) dtTmp = new Date();
    switch (type) {
        case "s":
            dtTmp = new Date(Date.parse(dtTmp) + (1000 * parseInt(NumDay)));
            break;
        case "n":
            dtTmp = new Date(Date.parse(dtTmp) + (60000 * parseInt(NumDay)));
            break;
        case "h":
            dtTmp = new Date(Date.parse(dtTmp) + (3600000 * parseInt(NumDay)));
            break;
        case "d":
            dtTmp = new Date(Date.parse(dtTmp) + (86400000 * parseInt(NumDay)));
            break;
        case "w":
            dtTmp = new Date(Date.parse(dtTmp) + ((86400000 * 7) * parseInt(NumDay)));
            break;
        case "m":
            dtTmp = new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + parseInt(NumDay), dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());
            break;
        case "y":
            dtTmp = new Date(dtTmp.getFullYear() + parseInt(NumDay), dtTmp.getMonth(), dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());
            break;
    }
    var mStr = new String(dtTmp.getMonth() + 1);
    var dStr = new String(dtTmp.getDate());
    if (mStr.length == 1) {
        mStr = "0" + mStr;
    }
    if (dStr.length == 1) {
        dStr = "0" + dStr;
    }
    return dtTmp.getFullYear() + "-" + mStr + "-" + dStr;
}

//在页面上显示执行结果的DIV，避免使用弹出消息框
function showTip(id, msg) {
    $("#" + id).html(msg);
    $("#" + id).fadeIn('fast');
    setTimeout("$('#" + id + "').fadeOut('slow')", 2000);
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

//如果datagrid的宽度为0则重设界面datagrid的宽度
//否则刷新datagrid里面的内容
//percent:百分比(1~100)
function resizeDatagrid(percent) {
    var id;
    var length;
    try {
        length = $(".datagrid-body").find("table[id!='']").length;
        if (length >= 1) {
            $(".datagrid-body").find("table[id!='']").each(
                function (i) {
                    id = $(this).attr("id");

                    if ($(".datagrid-view").eq(i).css("width") == '0px') {
                        if (i == 0 && length == 1) {
                            $('#' + id).datagrid({ width: document.body.clientWidth * percent * 0.01 });
                        } else if (i == 0 && length > 1) {
                            $('#' + id).datagrid({ width: document.body.clientWidth * 0.6 }); //左边占60%
                        } else {
                            $('#' + id).datagrid({ width: document.body.clientWidth * 0.4 }); //右边占40%
                        }
                    } else {
                        $('.pagination-load').eq(i).click();
                    }
                }
            );
        }
    }
    catch (e) {

    }

}

//创建居中的DIV显示进度  依赖css: .divCenter,.divBackGround
function createDivCenter(divId, html) {
    var divMask = document.createElement("div");
    divMask.id = "divMask";
    divMask.className = 'divBackGround';
    divMask.style.width = window.screen.width;
    divMask.style.height = window.screen.height;
    document.body.appendChild(divMask);

    var divCenter = document.createElement("div");
    divCenter.id = divId;
    divCenter.innerHTML = html;
    divCenter.className = "divCenter";
    document.body.appendChild(divCenter);

    divCenter.style.top = eval(document.compatMode && document.compatMode == 'CSS1Compat') ? document.documentElement.scrollTop + (document.documentElement.clientHeight - divCenter.offsetHeight) / 2 - 70 : document.body.scrollTop + (document.body.clientHeight - divCenter.clientHeight) / 2 - 70;
    divCenter.style.left = eval(document.compatMode && document.compatMode == 'CSS1Compat') ? document.documentElement.scrollLeft + (document.documentElement.clientWidth - divCenter.offsetWidth) / 2 : document.body.scrollLeft + (document.body.clientWidth - divCenter.clientWidth) / 2;

}
//移除进度DIV
function removeDivCenter(divId) {
    if (document.getElementById(divId) != null) {
        document.body.removeChild(document.getElementById(divId));
        document.body.removeChild(document.getElementById('divMask'));
    }
}


//动态提交FORM 
function commitForm(url, data, target) {
    document.write("</div><form id='formCommon' target='" + target + "' action='" + url + "' method='post'>" +
         "<input type='hidden' name='hideData' value='" + data + "'></input>" +
         "</form><script>document.getElementById('formCommon').submit();</script>");

}

function ChangeDateFormat(cellval) {
    if (cellval.toUpperCase().indexOf("/DATE(") >= 0) {
        var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();

        if (!(date > new Date(1900, 1, 1))) {
            return "";
        } else {
            return date.getFullYear() + "-" + month + "-" + currentDate;
        }
    } else {
        return cellval;
    }
}

//联系电话验证
function ValidateCellPhone(PhoneValue) {
    //联系电话的正则表达式
    var zz = /^(\d{11})$/g;
    if (PhoneValue.length > 0) {
        return zz.test(PhoneValue);
    }
    return true;
}