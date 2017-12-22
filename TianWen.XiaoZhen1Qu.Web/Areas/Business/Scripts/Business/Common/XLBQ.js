$(document).ready(function () {

});
//加载小类标签
function LoadXLBQ(tableName) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: $("#LBID").val(),
            TBName: tableName
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += '<div class="div_row_right_xlbq_top">';
                html += '<div class="div_row_right_xlbq_top_qs"></div>';
                html += '<img class="img_row_right_xlbq_top_close" onclick="CloseXLBQ()" src="' + getRootPath() + '/Areas/Business/Css/images/close.png">';
                html += '</div>';

                html += '<div class="div_row_right_xlbq_left">';
                html += '<ul class="ul_row_right_xlbq_left">';
                for (var i = 0; i < BQArray.length; i++) {
                    var count = 0;
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            count++;
                    }
                    if (count !== 0)
                        html += '<li class="li_row_right_xlbq_left" onmouseover="TabXLBQ(this,\'' + BQArray[i] + '\')">' + BQArray[i] + '</li>';
                }
                html += '</ul>';
                html += '</div>';

                for (var i = 0; i < BQArray.length; i++) {
                    html += '<div id="' + BQArray[i] + '" class="div_row_right_xlbq_right">';
                    html += '<ul class="ul_row_right_xlbq_right">';
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            html += '<li onclick="SelectXLBQ(this,\'' + xml.list[j].CODENAME + '\',\'' + xml.list[j].CODEID + '\')" class="li_row_right_xlbq_right"><img class="img_row_right_xlbq_right" src="' + getRootPath() + '/Areas/Business/Css/images/check_gray.png">' + xml.list[j].CODENAME + '</li>';
                    }
                    html += '</ul>';
                    html += '</div>';
                }
                $("#div_row_right_xlbq").html(html);
                if (xml.list.length > 0) {
                    $("#div_row_right_xlbq").css("display", "block");
                    $(".li_row_right_xlbq_left:eq(0)").css("background-color", "#ffffff");
                    $(".div_row_right_xlbq_right:eq(0)").css("display", "inline-block");

                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//切换小类标签
function TabXLBQ(obj, BQ) {
    $(".li_row_right_xlbq_left").css("background-color", "#eeeff1");
    $(obj).css("background-color", "#ffffff");
    $(".div_row_right_xlbq_right").css("display", "none");
    $("#" + BQ).css("display", "inline-block");
}
//选择小类标签
function SelectXLBQ(obj, codename, codeid) {
    if ($(obj).find("img").attr("src").indexOf("purple") !== -1) {
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
        $("#" + codeid).remove();
    }
    else {
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_purple.png");
        if ($("#spanXLBQ").find(".div_XLBQ").length !== 4) {
            if ($("#spanXLBQ").html() === "请选择小类,最多可选4项")
                $("#spanXLBQ").html('');
            $("#spanXLBQ").append('<div id="' + codeid + '" class="div_XLBQ">' + codename + '</div>');
        }
        else
            alert("最多只选择4项");
    }
}
//关闭小类标签
function CloseXLBQ() {
    $("#div_row_right_xlbq").css("display", "none");
}