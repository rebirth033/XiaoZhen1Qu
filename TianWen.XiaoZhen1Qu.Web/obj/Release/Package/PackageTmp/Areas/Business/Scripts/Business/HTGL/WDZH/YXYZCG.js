$(document).ready(function () {
    YHYZ(getUrlParam("para"));
});

function YHYZ(para) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/GRZL/YXYZYBC",
        dataType: "json",
        data:
        {
            para: para
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#img_content_tip").attr("src", getRootPath() + "/Areas/Business/Css/images/ok.png");
                $("#span_content_tip").html("恭喜您，邮箱认证成功！");
                $("#span_content_tip_right_yhm").html(xml.Value.YHM);
                $("#span_content_tip_right_yx").html(xml.Value.DZYX);
            } else {
                $("#img_content_tip").attr("src", getRootPath() + "/Areas/Business/Css/images/sorry.png");
                $("#span_content_tip").css("color", "red");
                $("#span_content_tip").html("对不起，邮箱验证失败！");
                $(".div_content_tip_info").each(function() {
                    $(this).css("display", "none");
                });
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}