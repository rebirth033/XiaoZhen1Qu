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
////////////////////添加

////////////////////添加属性
//这是添加json元素的属性只适合这种格式的json var json={索引号:"蒋佳良",索引号:"蒋佳良"}可能会有用处因为我没看找到好得方法来添加属性，就是想了个笨方法，希望有人给予指点,其实就是把json转换为字符串来拼接。
//var addjson1={"901":{}};
JsonDB.prototype.AddJson = function (jsonname, element, attribute) {
    var jsonString = this.JsonToString(jsonname);
    var jsonString = jsonString.substring(0, jsonString.length - 1);
    var jsonArr = "," + element + ":" + attribute + "}";
    var jsonString = jsonString.concat(jsonArr);
    //alert(jsonString);
    jsonname = this.ParseStringToJson(jsonString);
    return jsonname;
    //alert(jsonname[element]);
}

JsonDB.prototype.DisplayFromJson = function (containerID, json) {
    //alert(containerID +","+ json);
    $("#" + containerID + " [column]").each(function (i) {
        var columnName = $(this).attr("column");
        var columnValue = eval('json.' + columnName);
        //alert(columnName +","+ columnValue)
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


//调用方法：大概有三种请注意
//addjson(addjson1,902,"'蒋佳良'");//一定要注意这个单引号哟！
//addjson(addjson1,903,"{name:'蒋佳良'}");//一定要注意这个单引号哟！
//addjson(addjson1,904,"[{name:'蒋佳良'},{name:'蒋佳良'}]");//一定要注意这个单引号哟！
////////////////////添加属性end

////////////////////////添加节点
//var addjson2=[{name:"蒋佳良"},{name:"蒋佳良"}];
///添加到指定节点
//splice(index,howmany,element1,.....,elementX)
//index 必需。规定从何处添加/删除元素。该参数是开始插入和（或）删除的数组元素的下标，必须是数字。
//howmany 必需。规定应该删除多少元素。必须是数字，但可以是 "0"。如果未规定此参数，则删除从 index 开始到原数组结尾的所有元素。
//element1 可选。规定要添加到数组的新元素。从 index 所指的下标处开始插入。 
//elementX 可选。可向数组添加若干元素。 
//addjson2.splice(2,0,{name:"你把我推进去，并排在第3个"});//这是重点
//alert(addjson2[2].name);
//添加到最后
//addjson2.push({name:"你把我推进去，但是排在最后面的"});//这是重点
//alert(addjson2[addjson2.length-1].name);
////////////////////////添加节点end
////////////////////添加end

//修改
//修改基本上我觉得没有什么特殊操作
//var uptatejson=[{name:"蒋佳良"},{name:"蒋佳良"}];
//uptatejson[0].name="你把我修改了";
//alert(uptatejson[0].name);
////修改end
//这是json删除指定的元素
//var json1={name:"蒋佳良"};
//alert(json1.name);
//delete json1.name;//删除指定的标识的
//alert(json1.name);
//根据上面的类推的话
//var json2=[{name:"蒋佳良"},{name:"蒋佳良"}];
//alert(json2[1].name);
//delete json2[1].name;//删除指定的标识的
//alert(json2[1].name);
