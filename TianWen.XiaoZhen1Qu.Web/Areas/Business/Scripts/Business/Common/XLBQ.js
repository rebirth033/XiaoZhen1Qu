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
                html += '<div class="div_row_right_xlbq_top_qs"><img onclick="Selectxlbq(this)" class="img_row_right_xlbq_top_qs" src="' + getRootPath() + '/Areas/Business/Css/images/check_gray.png">全选</div>';
                html += '<img class="img_row_right_xlbq_top_close" onclick="Closexlbq()" src="' + getRootPath() + '/Areas/Business/Css/images/close.png">';
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
                        html += '<li class="li_row_right_xlbq_left" onclick="TabXLBQ(this,\'' + BQArray[i] + '\')">' + BQArray[i] + '</li>';
                }
                html += '</ul>';
                html += '</div>';

                for (var i = 0; i < BQArray.length; i++) {
                    html += '<div id="' + BQArray[i] + '" class="div_row_right_xlbq_right">';
                    html += '<ul class="ul_row_right_xlbq_right">';
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            html += '<li onclick="SelectFWDD(this,\'' + xml.list[j].CODENAME + '\')" class="li_row_right_xlbq_right"><img class="img_row_right_xlbq_right" src="' + getRootPath() + '/Areas/Business/Css/images/check_gray.png">' + xml.list[j].CODENAME + '</li>';
                    }
                    html += '</ul>';
                    html += '</div>';
                }

                $("#div_row_right_xlbq").html(html);
                $("#div_row_right_xlbq").css("display", "block");
                $(".li_row_right_xlbq_left:eq(0)").css("background-color", "#ffffff");
                $(".div_row_right_xlbq_right:eq(0)").css("display", "inline-block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//切换服务区域
function TabXLBQ(obj, BQ) {
    $(".li_row_right_xlbq_left").css("background-color", "#eeeff1");
    $(obj).css("background-color", "#ffffff");
    $(".div_row_right_xlbq_right").css("display", "none");
    $("#" + BQ).css("display", "inline-block");
}
//选择服务区域
function Selectxlbq(obj) {
    if ($(obj).attr("src").indexOf("purple") !== -1)
        $(obj).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).attr("src", getRootPath() + "/Areas/Business/Css/images/check_purple.png");
}
//选择服务区域
function SelectFWDD(obj, codename) {
    if ($(obj).find("img").attr("src").indexOf("purple") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_purple.png");
    $("#xlbq").val(codename);
}
//关闭服务区域
function Closexlbq() {
    $("#div_row_right_xlbq").css("display", "none");
}