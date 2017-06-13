function ListBox_Move(listfrom,listto)
        {
            var size = $("#" + listfrom + " option").size();
            var selsize = $("#" + listfrom + " option:selected").size();
            if(size>0 && selsize>0)
            {
                $.each($("#"+listfrom+" option:selected"), function(i,own){
                    $(own).appendTo($("#" + listto));
                    $("#" + listfrom + "").children("option:first").attr("selected",true); 
                });
            }
        }

//ListBox 选中项移动    
function ListBox_Order(ListName,action)
{
    var size = $("#"+ListName+" option").size();
    var selsize = $("#"+ListName+" option:selected").size();
    if(size > 0 && selsize > 0)
    {
        $.each($("#"+ListName+" option:selected"),function(i,own){
            if(action == "up")
            {
                $(own).prev().insertAfter($(own));
            }
            else if(action == "down")//down时选中多个连靠则操作没效果
            {
                $(own).next().insertBefore($(own));
            }
        })
    }
}
