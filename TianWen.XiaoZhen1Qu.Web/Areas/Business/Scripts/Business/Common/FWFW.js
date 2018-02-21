$(document).ready(function () {
    $("#FWFW").bind("click", LoadFWFW);
});
//加载服务区域
function LoadFWFW() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/GetAllDistrictByXZQDM",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += '<div class="div_row_right_FWFW_top">';
                html += '<div class="div_row_right_FWFW_top_qs"><img onclick="SelectFWFW(this)" class="img_row_right_FWFW_top_qs" src="' + getRootPath() + '/Areas/Business/Css/images/check_gray.png">全市</div>';
                html += '<img class="img_row_right_FWFW_top_close" onclick="CloseFWFW()" src="' + getRootPath() + '/Areas/Business/Css/images/close.png">';
                html += '</div>';
                html += '<div class="div_row_right_FWFW_left">';
                html += '<ul class="ul_row_right_FWFW_left">';
                for (var i = 0; i < xml.qylist.length; i++) {
                    html += '<li class="li_row_right_FWFW_left" onclick="TabFWFW(this,\'' + xml.qylist[i].CODEID + '\')"><img onclick="SelectFWFW(this)" class="img_row_right_FWFW_left" src="' + getRootPath() + '/Areas/Business/Css/images/check_gray.png">' + xml.qylist[i].CODENAME + '</li>';
                }
                html += '</ul>';
                html += '</div>';
                for (var i = 0; i < xml.qylist.length; i++) {
                    html += '<div id="' + xml.qylist[i].CODEID + '" class="div_row_right_FWFW_right">';
                    html += '<ul class="ul_row_right_FWFW_right">';
                    for (var j = 0; j < xml.ddlist.length; j++) {
                        if (xml.ddlist[j].PARENTID === xml.qylist[i].CODEID)
                            html += '<li onclick="SelectFWDD(this,\'' + xml.ddlist[j].CODENAME + '\')" class="li_row_right_FWFW_right"><img class="img_row_right_FWFW_right" src="' + getRootPath() + '/Areas/Business/Css/images/check_gray.png">' + xml.ddlist[j].CODENAME + '</li>';
                    }
                    html += '</ul>';
                    html += '</div>';
                }

                $("#div_row_right_FWFW").html(html);
                $("#div_row_right_FWFW").css("display", "block");
                $(".li_row_right_FWFW_left:eq(0)").css("background-color", "#ffffff");
                $(".div_row_right_FWFW_right:eq(0)").css("display", "inline-block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//切换服务区域
function TabFWFW(obj, codeid) {
    $(".li_row_right_FWFW_left").css("background-color", "#eeeff1");
    $(obj).css("background-color", "#ffffff");
    $(".div_row_right_FWFW_right").css("display", "none");
    $("#" + codeid).css("display", "inline-block");
}
//选择服务区域
function SelectFWFW(obj) {
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
    $("#FWFW").val(codename);
}
//关闭服务区域
function CloseFWFW() {
    $("#div_row_right_FWFW").css("display", "none");
}