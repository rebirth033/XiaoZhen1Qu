$(document).ready(function() {
    $("#Reg").bind("click", Save);
    $("#Cancel").bind("click", Close);
});

function Save() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/YHJBXX/Register",
        dataType: "json",
        data:
        {
            //RightSEC: RightSEC,
            //Perm: Perm,
            //Method: "CreateBasic", //新增
            //Json: jsonObj.JsonToString(obj)
        },
        success: function (xml) {
            if (xml.Result === "1") {
                alert("保存成功");
            } else {
                alert("保存失败");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            _masker.CloseMasker(false, errorThrown);
        }
    });
}

function Close() {
    
}