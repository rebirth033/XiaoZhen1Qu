$(document).ready(function () {
    $("#spanSCXX").css("color", "#5bc0de");
    $("#spanSCXX").css("font-weight", "700");
    $("#emSCXX").css("background-color", "#5bc0de");
    $("#emSCXX").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    LoadDefault("divSCXX");
});

function HeadActive() {
    $(".divstep").each(function () {
        $(this).find("span").each(function () {
            $(this).css("color", "#cccccc");
            $(this).css("font-weight", "normal");
        });
        $(this).find("em").each(function () {
            $(this).css("background-color", "#cccccc");
            $(this).css("height", "1px");
        });
    });
    $(this).find("span").each(function () {
        $(this).css("color", "#5bc0de");
        $(this).css("font-weight", "700");
    });
    $(this).find("em").each(function () {
        $(this).css("background-color", "#5bc0de");
        $(this).css("height", "2px");
    });
    LoadDefault($(this)[0].id);
}

function LoadDefault(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/WDSC/LoadSCXX",
        dataType: "json",
        data:
        {
            YHID: "2718ced3-996d-427d-925d-a08e127cc0b8"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_main_info").html('');
                for (var i = 0; i < xml.list.length; i++) {
                    LoadInfo(xml.list[i]);
                }
                if (xml.list.length === 0)
                    NoInfo(TYPE);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            
        }
    });
}

function LoadInfo(obj) {
    var html = "";
    html += ('<ul class="ul_new_info">');
    html += ('<li class="li_new_info">');
    html += ('<div class="div_new_info">');
    html += ('<div class="div_new_info_head">');
    html += ('<span class="span_new_info_head"></span>');
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
    if (obj.STATUS === 1) {
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_status">显示中</span>');
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_read">浏览:' + obj.LLCS + '</span>');
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_tip">进行置顶或精准推广会让你的信息成交更快哦。</span>');
    }
    else
        html += ('<span class="span_new_info_body_middle">个人删除</span>');
    html += ('</div>');
    html += ('<div class="div_new_info_body_right">');
    html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_common_button span_new_info_body_middle_delete"  onclick="Delete(\'' + obj.JCXXID + '\')">删除</span>');
    html += ('</div>');
    html += ('</div>');
    html += ('</div>');
    html += ('</li>');
    html += ('</ul>');
    $("#div_main_info").append(html);
}

function NoInfo(TYPE) {
    if (TYPE === "divSCXX") {
        $("#div_main_info").html('<div class="div_no_info">您没有收藏的信息</div>');
    }
    if (TYPE === "divLLGXX") {
        $("#div_main_info").html('<div class="div_no_info">您没有浏览过的信息</div>');
    }
    if (TYPE === "divGZDP") {
        $("#div_main_info").html('<div class="div_no_info">您没有关注的店铺</div>');
    }
}

function Delete(JCXXID) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/WDSC/DeleteYHSCXX",
        dataType: "json",
        data:
        {
            YHID: "2718ced3-996d-427d-925d-a08e127cc0b8",
            JCXXID: JCXXID
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadByActive();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            _masker.CloseMasker(false, errorThrown);
        }
    });
}

function LoadByActive() {
    $(".spanstep").each(function (i) {
        if ($("#" + this.id).css("color") === "rgb(91, 192, 222)")
            LoadDefault($("#" + this.id).parent()[0].id);
    });
}