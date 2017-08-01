$(document).ready(function () {
    $("#spanXTTZ").css("color", "#5bc0de");
    $("#spanXTTZ").css("font-weight", "700");
    $("#emXTTZ").css("background-color", "#5bc0de");
    $("#emXTTZ").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    LoadDefault("divXTTZLB");
});

function HeadActive() {
    $(".divstep").each(function () {
        $(this).find("span").each(function () {
            $(this).css("color", "#cccccc");
            $(this).css("font-weight", "normal");
        });
        $(this).find("em").each(function () {
            $(this).css("height", "1px");
            $(this).css("background-color", "#cccccc");
        });
    });
    $(this).find("span").each(function () {
        $(this).css("color", "#5bc0de");
        $(this).css("font-weight", "700");
    });
    $(this).find("em").each(function () {
        $(this).css("height", "2px");
        $(this).css("background-color", "#5bc0de");
    });
    LoadDefault($(this)[0].id);
}

function LoadDefault(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/XXGL/LoadYHXX",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID"),
            TYPE: TYPE
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#tbody_main_info_xttz").html('');
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
    html += ('<tr class="tr_main_info">');
    html += ('<td style="width:40px;"><input type="checkbox" value="" /></td>');
    html += ('<td style="width:120px;">' + obj.FJR + '</td>');
    html += ('<td style="width:400px;"><a class="a_main_info_xxnr">' + obj.XXNR + '</a>。</td>');
    html += ('<td style="width:120px;">' + obj.XXSJ.ToString("yyyy-MM-dd hh:mm:ss") + '</td>');
    html += ('<td style="width:80px;"><a class="a_main_info_cz">删除</a></td>');
    html += ('</tr>');
    $("#tbody_main_info_xttz").append(html);
}

function NoInfo(TYPE) {
    if (TYPE === "divXTTZLB") {
        $("#tbody_main_info_xttz").html('<div class="div_no_info">您暂时没有系统通知消息</div>');
    }
    if (TYPE === "divKHZXLB") {
        $("#div_main_info").html('<div class="div_no_info">您暂时没有咨询消息</div>');
    }
    if (TYPE === "divWDZXLB") {
        $("#div_main_info").html('<div class="div_no_info">您暂时没有咨询消息</div>');
    }
}