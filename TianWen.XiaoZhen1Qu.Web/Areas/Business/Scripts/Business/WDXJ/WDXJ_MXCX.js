var currentIndex = 1;
$(document).ready(function () {
    $("#spanSZMX").css("color", "#31b0d5");
    $("#spanSZMX").css("font-weight", "700");
    $("#emSZMX").css("background-color", "#31b0d5");
    $("#emSZMX").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    $("#div_main_info_head_lx").find(".span_main_info_right").bind("click", { id: "lx" }, SpanActive);
    $("#div_main_info_head_zjlx").find(".span_main_info_right").bind("click", { id: "zjlx" }, SpanActive);
    $("#div_main_info_head_sj").find(".span_main_info_right").bind("click", { id: "sj" }, SpanActive);
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
    currentIndex = parseInt(PageIndex);
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/WDXJ/LoadSZMX",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID"),
            PageSize: 5,
            PageIndex: PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadPage(xml.PageCount);
                $("#tbody_main_info_xttz").html('');
                $("#span_main_info_head_gjt").html(xml.TotalCount);
                $("#span_main_info_head_wdjt").html(xml.WCCount);
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

