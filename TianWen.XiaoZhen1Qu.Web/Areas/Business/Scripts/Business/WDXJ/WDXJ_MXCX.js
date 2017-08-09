var currentIndex = 1;
$(document).ready(function () {
    $("#spanSZMX").css("color", "#31b0d5");
    $("#spanSZMX").css("font-weight", "700");
    $("#emSZMX").css("background-color", "#31b0d5");
    $("#emSZMX").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    $("#div_main_info_head_lx").find(".span_main_info_right").bind("click", { id: "lx", PageIndex: currentIndex }, SpanActive);
    $("#div_main_info_head_zjlx").find(".span_main_info_right").bind("click", { id: "zjlx", PageIndex: currentIndex }, SpanActive);
    $("#div_main_info_head_sj").find(".span_main_info_right").bind("click", { id: "sj", PageIndex: currentIndex }, SpanActive);
    $("#input_kssj").datepicker({ minDate: 0 });
    $("#input_jssj").datepicker({ minDate: 0 });
    LoadDefault(currentIndex);
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
    LoadInfo($(this)[0].id);
}

function SpanActive(obj) {
    var id = this.id;
    $("#div_main_info_head_" + obj.data.id).find(".span_main_info_right").each(function () {
        $(this).css("background-color", "#ffffff");
        $(this).css("color", "#31b0d5");
        $(this).off('mouseenter').unbind('mouseleave');
        if (this.id !== id)
            $(this).hover(function () {
                $(this).css("background-color", "#f0f8fa");
                $(this).css("color", "#ff6100");
            }, function () {
                $(this).css("background-color", "#ffffff");
                $(this).css("color", "#31b0d5");
            });
    });
    $(this).css("background-color", "#31b0d5");
    $(this).css("color", "#ffffff");
    LoadSZMX(obj.data.PageIndex);
}

function LoadDefault(PageIndex) {
    $("#span_main_info_right_lxqb").css("background-color", "#31b0d5").css("color", "#fff");
    $("#span_main_info_right_zjlxqb").css("background-color", "#31b0d5").css("color", "#fff");
    LoadSZMX(PageIndex);
}

function LoadInfo(id) {
    if (id === "SZMX") {

    }
}

function LoadSZMX(PageIndex) {
    var LX = "", ZJLX = "";
    $("#div_main_info_head_lx").find(".span_main_info_right").each(function () {
        if ($(this).css("background-color") === "rgb(49, 176, 213)") {
            LX = $(this).html() === "全部" ? "" : $(this).html();
        }
    });
    $("#div_main_info_head_zjlx").find(".span_main_info_right").each(function () {
        if ($(this).css("background-color") === "rgb(49, 176, 213)") {
            ZJLX = $(this).html() === "全部" ? "" : $(this).html();
        }
    });
    currentIndex = parseInt(PageIndex);
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/WDXJ/LoadSZMX",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID"),
            LX: LX,
            ZJLX: ZJLX,
            PageSize: 5,
            PageIndex: PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadPage(xml.PageCount);
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

function LoadPage(PageCount) {
    var index = parseInt(currentIndex);
    $("#div_main_info_bottom_fy").html('');
    if (index > 1) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadSZMX(\'' + (index - 1) + '\')" class="a_main_info_bottom_fy">上一页</a>');
    }
    for (var i = 1; i <= PageCount; i++) {
        if (i === index)
            $("#div_main_info_bottom_fy").append('<a onclick="LoadSZMX(\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
        else
            $("#div_main_info_bottom_fy").append('<a onclick="LoadSZMX(\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
    }
    if (index < PageCount) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadSZMX(\'' + (index + 1) + '\')" class="a_main_info_bottom_fy">下一页</a>');
    }
}

function LoadInfo(obj) {
    var html = "";
    html += ('<tr class="tr_main_info">');
    html += ('<td style="width:140px;">' + obj.CJSJ.ToString("yyyy-MM-dd hh:mm:ss") + '</td>');
    html += ('<td style="width:70px;">' + obj.LX + '</td>');
    html += ('<td style="width:140px;">' + obj.JYSM + '</td>');
    html += ('<td style="width:120px;">' + obj.JE + '</td>');
    html += ('<td style="width:120px;"><a class="a_main_info_cz" onclick="ViewDetail(' + obj.SZMXID + ')">查看详细</a></td>');
    html += ('</tr>');
    $("#tbody_main_info_xttz").append(html);
}