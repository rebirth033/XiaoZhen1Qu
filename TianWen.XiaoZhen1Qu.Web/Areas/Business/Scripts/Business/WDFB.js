$(document).ready(function () {
    $(".divstep").bind("click", HeadActive);
    LoadDefault();
});

function LoadDefault() {
    $("#spanZJFBXX").css("color", "#5bc0de");
    $("#emZJFBXX").css("background-color", "#5bc0de");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/WDFB/LoadYHFBXX",
        dataType: "json",
        data:
        {
            YHID: "2718ced3-996d-427d-925d-a08e127cc0b8",
            TYPE: "ZJFBXX"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                for (var i = 0; i < xml.list.length; i++) {
                    LoadInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            _masker.CloseMasker(false, errorThrown);
        }
    });
}

function HeadActive() {
    $(".divstep").each(function () {
        $(this).find("span").each(function () {
            $(this).css("color", "#cccccc");
        });
        $(this).find("em").each(function () {
            $(this).css("background-color", "#cccccc");
        });
    });
    $(this).find("span").each(function () {
        $(this).css("color", "#5bc0de");
    });
    $(this).find("em").each(function () {
        $(this).css("background-color", "#5bc0de");
    });
}

function LoadInfo(obj) {
    var html = "";
    html += ('<ul class="ul_new_info">');
    html += ('<li class="li_new_info">');
    html += ('<div class="div_new_info">');
    html += ('<div class="div_new_info_head">');
    html += ('<span class="span_new_info_head">信息号: ' + obj.JCXXID + '</span>');
    html += ('</div>');
    html += ('<div class="div_new_info_body">');
    html += ('<div class="div_new_info_body_left">');
    html += ('<div class="div_new_info_body_left_inner">');
    html += ('<div class="div_new_info_body_left_inner_img">');
    if (obj.PHOTOS.length > 0)
        html += ('<img class="img_new_info_body_left" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    else
        html += ('<img class="img_new_info_body_left" />');
    html += ('</div>');
    html += ('<div class="div_new_info_body_left_inner_info">');
    html += ('<span class="span_new_info_body_left_bt">' + obj.BT + '</span>');
    html += ('<span class="span_new_info_body_left_rq">' + obj.CJSJ.ToString("yyyy-MM-dd hh:mm:ss") + '</span>');
    html += ('<span class="span_new_info_body_left_dh">' + obj.DH + '</span>');
    html += ('</div>');
    html += ('</div>');
    html += ('</div>');
    html += ('<div class="div_new_info_body_middle">');
    if (obj.STATUS === 1)
        html += ('<span class="span_new_info_body_middle active">个人删除</span>');
    else
        html += ('<span class="span_new_info_body_middle">个人删除</span>');
    html += ('</div>');
    html += ('<div class="div_new_info_body_right">');
    if (obj.STATUS === 0)
        html += ('<span class="span_new_info_body_right active">恢复</span>');
    else
        html += ('<span class="span_new_info_body_right">恢复</span>');
    html += ('</div>');
    html += ('</div>');
    html += ('</div>');
    html += ('</li>');
    html += ('</ul>');
    $("#div_main_info").append(html);
}