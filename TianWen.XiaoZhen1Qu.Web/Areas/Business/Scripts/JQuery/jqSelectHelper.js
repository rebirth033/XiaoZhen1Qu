﻿ //得到select项的个数   
jQuery.fn.sizeA = function(){   
    return jQuery(this).get(0).options.length;   
}   

//获得选中项的索引   
jQuery.fn.getSelectedIndex = function(){   
    return jQuery(this).get(0).selectedIndex;   
}   

//获得当前选中项的文本   
jQuery.fn.getSelectedText = function(){   
    if(jQuery(this).sizeA() == 0) return "";   
    else{   
        var index = jQuery(this).getSelectedIndex();         
        return jQuery(this).get(0).options[index].text;   
    }   
}   

//获得当前选中项的值   
jQuery.fn.getSelectedValue = function(){   
    if(jQuery(this).sizeA() == 0)    
        return "";   
       
    else 
        return jQuery(this).val();   
}   

//设置select中值为value的项为选中   
jQuery.fn.setSelectedValue = function(value){
    $(this).find("option[value='" + value + "']").attr("selected", true);
}

//获取所有项目的value,用逗号区隔
jQuery.fn.getSelectAll = function (connectorText,connectorValue) {
    var obj = { Values: "", Texts: "" };
    var count = jQuery(this).sizeA();
    for (var i = 0; i < count; i++) {
        obj.Values = obj.Values + jQuery(this).get(0).options[i].value + connectorValue;
        obj.Texts = obj.Texts + jQuery(this).get(0).options[i].text + connectorText;
    }
    obj.Values = obj.Values.substr(0, obj.Values.length - 1);
    obj.Texts = obj.Texts.substr(0, obj.Texts.length - 1);
    return obj;
}


//设置select中文本为text的第一项被选中   
jQuery.fn.setSelectedText = function(text)   
{   
    var isExist = false;   
    var count = jQuery(this).sizeA();   
    for(var i=0;i<count;i++)   
    {   
        if(jQuery(this).get(0).options[i].text == text)   
        {   
            jQuery(this).get(0).options[i].selected = true;   
            isExist = true;   
            break;   
        }   
    }   
    if(!isExist)   
    {   
        alert("下拉框中不存在该项");   
    }   
}   
//设置选中指定索引项   
jQuery.fn.setSelectedIndex = function(index)   
{   
    var count = jQuery(this).sizeA();       
    if(index >= count || index < 0)   
    {   
        alert("选中项索引超出范围");   
    }   
    else 
    {   
        jQuery(this).get(0).selectedIndex = index;   
    }   
}   
//判断select项中是否存在值为value的项   
jQuery.fn.isExistItem = function(value)   
{   
    var isExist = false;   
    var count = jQuery(this).sizeA();   
    for(var i=0;i<count;i++)   
    {   
        if(jQuery(this).get(0).options[i].value == value)   
        {   
            isExist = true;   
            break;   
        }   
    }   
    return isExist;   
}   
//向select中添加一项，显示内容为text，值为value,如果该项值已存在，则提示   
jQuery.fn.addOption = function(text,value)   
{   
    if(jQuery(this).isExistItem(value))   
    {   
        alert("待添加项的值已存在");   
    }   
    else 
    {   
        jQuery(this).get(0).options.add(new Option(text,value));   
    }   
}   
//删除select中值为value的项，如果该项不存在，则提示   
jQuery.fn.removeItem = function(value)   
{       
    if(jQuery(this).isExistItem(value))   
    {   
        var count = jQuery(this).sizeA();           
        for(var i=0;i<count;i++)   
        {   
            if(jQuery(this).get(0).options[i].value == value)   
            {   
                jQuery(this).get(0).remove(i);   
                break;   
            }   
        }           
    }   
    else 
    {   
        alert("待删除的项不存在!");   
    }   
}   
//删除select中指定索引的项   
jQuery.fn.removeIndex = function(index)   
{   
    var count = jQuery(this).sizeA();   
    if(index >= count || index < 0)   
    {   
        alert("待删除项索引超出范围");   
    }   
    else 
    {   
        jQuery(this).get(0).remove(index);   
    }   
}   
//删除select中选定的项   
jQuery.fn.removeSelected = function()   
{   
    var index = jQuery(this).getSelectedIndex();   
    jQuery(this).removeIndex(index);   
}   
//清除select中的所有项   
jQuery.fn.clearAll = function()   
{   
    jQuery(this).get(0).options.length = 0;   
} 