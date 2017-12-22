//加载小类标签
function LoadXLBQ(tableName, typename) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: typename,
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
                            html += '<li onclick="SelectXLBQ(this,\'' + xml.list[j].CODENAME + '\')" class="li_row_right_xlbq_right"><img class="img_row_right_xlbq_right" src="' + getRootPath() + '/Areas/Business/Css/images/check_gray.png">' + xml.list[j].CODENAME + '</li>';
                    }
                    html += '</ul>';
                    html += '</div>';
                }
                $("#div_row_right_xlbq").html(html);
                if (xml.list.length > 0) {
                    $("#div_row_right_xlbq").css("display", "block");
                    $(".li_row_right_xlbq_left:eq(0)").css("background-color", "#ffffff");
                    $(".div_row_right_xlbq_right:eq(0)").css("display", "inline-block");

                    $("#spanXLBQ").find(".div_XLBQ").each(function () {
                        for (var i = 0; i < $(".li_row_right_xlbq_right").length; i++) {
                            if ($(".li_row_right_xlbq_right")[i].innerHTML.indexOf($(this).html()) !== -1) {
                                $(".li_row_right_xlbq_right:eq(" + i + ")").find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_purple.png");
                            }
                        }
                    });
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
function SelectXLBQ(obj, codename) {
    if ($(obj).find("img").attr("src").indexOf("purple") !== -1) {
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
        $("#" + codename).remove();
    }
    else {
        if ($("#spanXLBQ").find(".div_XLBQ").length !== 4) {
            if ($("#spanXLBQ").html().indexOf("请选择") !== -1) $("#spanXLBQ").html('');
            $("#spanXLBQ").append('<div id="' + codename + '" class="div_XLBQ">' + codename + '</div>');
            $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_purple.png");
        }
        else
            alert("最多只选择4项");
    }
}
//关闭小类标签
function CloseXLBQ() {
    $("#div_row_right_xlbq").css("display", "none");
}
//获取小类标签
function GetXLBQ() {
    var bqs = "";
    $("#spanXLBQ").find(".div_XLBQ").each(function () {
        bqs += $(this).html() + ",";
    });
    return RTrim(bqs, ',');
}
//设置小类标签
function SetXLBQ(bqs) {
    if ($("#spanXLBQ").html() === "请选择小类,最多可选4项")
        $("#spanXLBQ").html('');
    var bqarray = bqs.split(',');
    for (var i = 0; i < bqarray.length; i++)
        $("#spanXLBQ").append('<div class="div_XLBQ">' + bqarray[i] + '</div>');
    
    $("#divOUTXLBQ").css("display", "block");
}