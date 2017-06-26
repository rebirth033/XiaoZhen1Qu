$(document).ready(function () {
    LoadDL();
});

function LoadDL() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LBXZ/LoadDL",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                alert("登录成功");
            } else {
                window.location.href = getRootPath() + "/Business/YHDLXX/YHDLXX";
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            _masker.CloseMasker(false, errorThrown);
        }
    });
    $("#tableDL").html();
}