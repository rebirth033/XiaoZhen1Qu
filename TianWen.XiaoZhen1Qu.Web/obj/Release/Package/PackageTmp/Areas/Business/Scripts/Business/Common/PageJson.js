//获取页面上的input控件的column属性和控件值拼凑成json字串供后台解析成对应的类。
//如果有些字段使用的不是input对象，请使用隐藏域储存该字段的值
//控件column属性对应数据字段名

function JsonDB(containerID) {
    this.ContainerID = (typeof (containerID) != 'undefined' && containerID != "") ? ("#" + containerID + " ") : "";
}

JsonDB.prototype.GetJsonObject = function () {
    return this.ParseStringToJson(this.GetJsonString());
}

JsonDB.prototype.GetJsonString = function () {
    var json = "{";
    $(this.ContainerID + "[column]").each(function (i) {
        var columnValue = null;
        if ($(this).val() != undefined) {
            if ($(this).attr("type") == "checkbox") {
                columnValue = $(this).attr('checked') == "checked" ? 1 : 0;
            } else {
                columnValue = $(this).val();
            }
        }
        var columnName = $(this).attr("column");
        if (i == 0) {
            json += "'" + columnName + "':" + "'" + columnValue + "'";
        } else {
            json += ",'" + columnName + "':" + "'" + columnValue + "'";
        }
    });
    json += "}";
    return json;
}

JsonDB.prototype.Join = function (des, src, override){
    if(src instanceof Array){
        for (var i = 0, len = src.length; i < len; i++)
             this.Join(des, src[i], override);
    }
    for( var i in src){
        if(override || !(i in des)){
            des[i] = src[i];
        }
    } 
    return des;
}


//转换为json
JsonDB.prototype.ParseStringToJson = function (str) {
    try {
        eval("var _obj_=" + str);
        return _obj_;
    } catch (e) {
        return null;
    }
}

//数组转换为字符串
JsonDB.prototype.ArrayToJsonString = function(arr) {
    var separator = ","; //separator为分隔符
    for (var i = 0; i < arr.length; i++) {
        arr[i] = this.JsonToString(arr[i]);
    }
    return arr.join(separator);
}
//json转换为字符串
JsonDB.prototype.JsonToString = function (obj) {
    var isArray = obj instanceof Array;
    var r = [];
    for (var i in obj) {
        var value = obj[i];
        if (typeof value == 'string') {
            value = '"' + value + '"';
        } else if (value != null && typeof value == 'object') {
            value = this.JsonToString(value);
        }
        r.push((isArray ? '' : i + ':') + value);
    }
    if (isArray) {
        return '[' + r.join(',') + ']';
    } else {
        return '{' + r.join(',') + '}';
    }
}

JsonDB.prototype.AddJson = function (jsonname, element, attribute) {
    var jsonString = this.JsonToString(jsonname);
    var jsonString = jsonString.substring(0, jsonString.length - 1);
    var jsonArr = "," + element + ":" + attribute + "}";
    var jsonString = jsonString.concat(jsonArr);
    jsonname = this.ParseStringToJson(jsonString);
    return jsonname;
}

JsonDB.prototype.DisplayFromJson = function (containerID, json) {
    $("#" + containerID + " [column]").each(function (i) {
        var columnName = $(this).attr("column");
        var columnValue = eval('json.' + columnName);
        if (typeof (columnValue) != 'undefined' && columnValue != null) {

            if ($(this).attr('type') == "checkbox") {
                columnValue == "1" ? $(this).attr('checked', 'checked') : $(this).removeAttr('checked');
            }
            else {
                if ($(this).hasClass("Wdate")) {
                    $(this).val(ChangeDateFormat(columnValue));
                } else {
                    $(this).val(columnValue);
                }
            }

        }
    });
}