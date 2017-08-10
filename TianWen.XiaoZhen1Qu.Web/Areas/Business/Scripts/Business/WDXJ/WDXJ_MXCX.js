var currentIndex = 1, currentDJJDIndex = 1;
$(document).ready(function () {
    $("#spanSZMX").css("color", "#31b0d5");
    $("#spanSZMX").css("font-weight", "700");
    $("#emSZMX").css("background-color", "#31b0d5");
    $("#emSZMX").css("height", "2px");
    $(".divstep").bind("click", { PageIndex: currentIndex }, HeadActive);
    $("#div_main_info_head_lx").find(".span_main_info_right").bind("click", { id: "lx", PageIndex: currentIndex }, SZMXSpanActive);
    $("#div_main_info_head_zjlx").find(".span_main_info_right").bind("click", { id: "zjlx", PageIndex: currentIndex }, SZMXSpanActive);
    $("#div_main_info_head_sj").find(".span_main_info_right").bind("click", { id: "sj", PageIndex: currentIndex }, SZMXSpanActive);
    $("#div_main_info_head_djjd_lx").find(".span_main_info_right").bind("click", { id: "lx", PageIndex: currentIndex }, DJJDJLSpanActive);
    $("#div_main_info_head_djjd_sj").find(".span_main_info_right").bind("click", { id: "sj", PageIndex: currentIndex }, DJJDJLSpanActive);
    $("#input_kssj").datepicker({ maxDate: 0 });
    $("#input_jssj").datepicker({ maxDate: 0 });
    $("#input_djjd_kssj").datepicker({ maxDate: 0 });
    $("#input_djjd_jssj").datepicker({ maxDate: 0 });
    $("#span_main_info_right_button").bind("click", { PageIndex: currentIndex }, SelectSZMX);
    $("#span_main_info_right_djjd_button").bind("click", { PageIndex: currentIndex }, SelectDJJDJL);
    $("#span_main_info_right_jt").bind("click", { PageIndex: currentIndex, SJ: "今天" }, SelectSZMXBySJ);
    $("#span_main_info_right_jygy").bind("click", { PageIndex: currentIndex, SJ: "近一个月" }, SelectSZMXBySJ);
    $("#span_main_info_right_jsgy").bind("click", { PageIndex: currentIndex, SJ: "近三个月" }, SelectSZMXBySJ);
    $("#span_main_info_right_djjd_jt").bind("click", { PageIndex: currentIndex, SJ: "今天" }, SelectDJJDJLBySJ);
    $("#span_main_info_right_djjd_jygy").bind("click", { PageIndex: currentIndex, SJ: "近一个月" }, SelectDJJDJLBySJ);
    $("#span_main_info_right_djjd_jsgy").bind("click", { PageIndex: currentIndex, SJ: "近三个月" }, SelectDJJDJLBySJ);
    LoadDefault(currentIndex);
});

function HeadActive(obj) {
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
    LoadDivInfo(this.id, obj.data.PageIndex);
}

function SZMXSpanActive(obj) {
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

function DJJDJLSpanActive(obj) {
    var id = this.id;
    $("#div_main_info_head_djjd_" + obj.data.id).find(".span_main_info_right").each(function () {
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
    LoadDJJDJL(obj.data.PageIndex);
}

function LoadDefault(PageIndex) {
    $("#span_main_info_right_lxqb").css("background-color", "#31b0d5").css("color", "#fff");
    $("#span_main_info_right_zjlxqb").css("background-color", "#31b0d5").css("color", "#fff");
    LoadDivInfo("divSZMX", PageIndex);
}

function LoadDivInfo(id, PageIndex) {
    if (id === "divSZMX") {
        $("#div_SZMX").css("display", "block");
        $("#div_DJJDJL").css("display", "none");
        LoadSZMX(PageIndex);
    }
    else {
        $("#div_SZMX").css("display", "none");
        $("#div_DJJDJL").css("display", "block");
        LoadDJJDJL(PageIndex);
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
            StartTime: $("#input_kssj").val(),
            EndTime: $("#input_jssj").val(),
            PageSize: 5,
            PageIndex: PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadSZMXPage(xml.PageCount);
                $("#tbody_main_info_xttz").html('');
                for (var i = 0; i < xml.list.length; i++) {
                    LoadSZMXInfo(xml.list[i]);
                }
                if (xml.list.length === 0)
                    NoInfo(TYPE);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadDJJDJL(PageIndex) {
    var LX = "";
    $("#div_main_info_head_djjd_lx").find(".span_main_info_right").each(function () {
        if ($(this).css("background-color") === "rgb(49, 176, 213)") {
            LX = $(this).html() === "全部" ? "" : $(this).html();
        }
    });
    currentDJJDIndex = parseInt(PageIndex);
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/WDXJ/LoadDJJDJL",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID"),
            LX: LX,
            StartTime: $("#input_djjd_kssj").val(),
            EndTime: $("#input_djjd_jssj").val(),
            PageSize: 5,
            PageIndex: PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadDJJDJLPage(xml.PageCount);
                $("#tbody_main_info_djjd_xttz").html('');
                for (var i = 0; i < xml.list.length; i++) {
                    LoadDJJDJLInfo(xml.list[i]);
                }
                if (xml.list.length === 0)
                    NoInfo(TYPE);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadSZMXPage(PageCount) {
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

function LoadDJJDJLPage(PageCount) {
    var index = parseInt(currentIndex);
    $("#div_main_info_bottom_djjdjl_fy").html('');
    if (index > 1) {
        $("#div_main_info_bottom_djjdjl_fy").append('<a onclick="LoadDJJDJL(\'' + (index - 1) + '\')" class="a_main_info_bottom_fy">上一页</a>');
    }
    for (var i = 1; i <= PageCount; i++) {
        if (i === index)
            $("#div_main_info_bottom_djjdjl_fy").append('<a onclick="LoadDJJDJL(\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
        else
            $("#div_main_info_bottom_djjdjl_fy").append('<a onclick="LoadDJJDJL(\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
    }
    if (index < PageCount) {
        $("#div_main_info_bottom_djjdjl_fy").append('<a onclick="LoadDJJDJL(\'' + (index + 1) + '\')" class="a_main_info_bottom_fy">下一页</a>');
    }
}

function SelectSZMX(obj) {
    LoadSZMX(obj.data.PageIndex);
}

function SelectDJJDJL(obj) {
    LoadDJJDJL(obj.data.PageIndex);
} 

function SelectSZMXBySJ(obj) {
    var LX = "", ZJLX = "", StartTime, EndTime;
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

    var myDate = new Date();

    if (obj.data.SJ === "今天") {
        myDate = new Date();
        StartTime = getNowFormatDate(myDate);
        EndTime = getNowFormatDate(myDate);
    }
    if (obj.data.SJ === "近一个月") {
        myDate = new Date();
        EndTime = getNowFormatDate(myDate);
        myDate.setMonth(myDate.getMonth() - 1);
        StartTime = getNowFormatDate(myDate);
    }
    if (obj.data.SJ === "近三个月") {
        myDate = new Date();
        EndTime = getNowFormatDate(myDate);
        myDate.setMonth(myDate.getMonth() - 3);
        StartTime = getNowFormatDate(myDate);
    }
    currentIndex = parseInt(obj.data.PageIndex);
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/WDXJ/LoadSZMX",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID"),
            LX: LX,
            ZJLX: ZJLX,
            StartTime: StartTime,
            EndTime: EndTime,
            PageSize: 5,
            PageIndex: obj.data.PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadSZMXPage(xml.PageCount);
                $("#tbody_main_info_xttz").html('');
                for (var i = 0; i < xml.list.length; i++) {
                    LoadSZMXInfo(xml.list[i]);
                }
                if (xml.list.length === 0)
                    NoInfo(TYPE);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function SelectDJJDJLBySJ(obj) {
    var LX = "", StartTime, EndTime;
    $("#div_main_info_head_lx").find(".span_main_info_right").each(function () {
        if ($(this).css("background-color") === "rgb(49, 176, 213)") {
            LX = $(this).html() === "全部" ? "" : $(this).html();
        }
    });

    var myDate = new Date();

    if (obj.data.SJ === "今天") {
        myDate = new Date();
        StartTime = getNowFormatDate(myDate);
        EndTime = getNowFormatDate(myDate);
    }
    if (obj.data.SJ === "近一个月") {
        myDate = new Date();
        EndTime = getNowFormatDate(myDate);
        myDate.setMonth(myDate.getMonth() - 1);
        StartTime = getNowFormatDate(myDate);
    }
    if (obj.data.SJ === "近三个月") {
        myDate = new Date();
        EndTime = getNowFormatDate(myDate);
        myDate.setMonth(myDate.getMonth() - 3);
        StartTime = getNowFormatDate(myDate);
    }
    currentIndex = parseInt(obj.data.PageIndex);
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/WDXJ/LoadDJJDJL",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID"),
            LX: LX,
            StartTime: StartTime,
            EndTime: EndTime,
            PageSize: 5,
            PageIndex: obj.data.PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadDJJDJLPage(xml.PageCount);
                $("#tbody_main_info_djjd_xttz").html('');
                for (var i = 0; i < xml.list.length; i++) {
                    LoadDJJDJLInfo(xml.list[i]);
                }
                if (xml.list.length === 0)
                    NoInfo(TYPE);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadSZMXInfo(obj) {
    var html = "";
    html += ('<tr class="tr_main_info">');
    html += ('<td style="width:140px;">' + obj.CJSJ.ToString("yyyy-MM-dd hh:mm:ss") + '</td>');
    html += ('<td style="width:70px;">' + obj.LX + '</td>');
    html += ('<td style="width:140px;">' + obj.JYSM + '</td>');
    html += ('<td style="width:120px;color:' + (obj.JELX === "+" ? "green" : "red") + ';" >' + obj.JELX + obj.JE.toFixed(2) + '</td>');
    html += ('<td style="width:120px;"><a class="a_main_info_cz" onclick="ViewDetail(' + obj.SZMXID + ')">查看详细</a></td>');
    html += ('</tr>');
    $("#tbody_main_info_xttz").append(html);
}

function LoadDJJDJLInfo(obj) {
    var html = "";
    html += ('<tr class="tr_main_info">');
    html += ('<td style="width:140px;">' + obj.CJSJ.ToString("yyyy-MM-dd hh:mm:ss") + '</td>');
    html += ('<td style="width:140px;">' + obj.LX + '</td>');
    html += ('<td style="width:140px;color:' + (obj.LX === "冻结" ? "green" : "red") + ';" >' + obj.JE.toFixed(2) + '</td>');
    html += ('<td style="width:120px;">' + obj.BZ + '</td>');
    html += ('</tr>');
    $("#tbody_main_info_djjd_xttz").append(html);
}
