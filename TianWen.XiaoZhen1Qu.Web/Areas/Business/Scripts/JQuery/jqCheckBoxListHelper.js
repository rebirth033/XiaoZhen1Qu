//全选 
function CheckBoxListSelectAll(id){
    $("#" + id + " input[type='checkbox']").each(function() { 
                $(this).attr("checked", true);  
     }); 
 }
     
//全不选 

function CheckBoxListUnSelectAll(id){
    $("#" + id + " input[type='checkbox']").each(function() { 
                $(this).attr("checked", false);  
     });
}
//反选

function CheckBoxListReverse(id){
     $("#" + id + " input[type='checkbox']").each(function() { 
                        if($(this).attr("checked")) 
                        { 
                                $(this).attr("checked", false); 
                        } 
                        else 
                        { 
                                $(this).attr("checked", true); 
                        } 
                }); 
}

//取得所有选中项的value,用,连接
function GetCheckBoxListSelectedValues(id) {
    var returnValue = "";

    $("#" + id + " input[type='checkbox']").each(function () {

        if ($(this).attr("checked")) {
            returnValue += $(this).val() + ",";
        }
    });
    
    return returnValue.substr(0, returnValue.length - 1);
}

//设置value指定值项选中
function SetCheckBoxListSelectedByValue(id,value) {
    $("#" + id + " input[type='checkbox']").each(function () {
        if ($(this).val() == value) {
            $(this).attr("checked", "true");
        }
    });
}